using EG_MagicCubeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using ImageMagick;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;
namespace EG_MagicCube.Models
{
    public class WorksFilesModel
    {
        #region Properties
        /// <summary>
        /// 作品序號
        /// </summary>
        [DisplayName("作品序號")]
        public string WorksNo { get; set; } = "";
        /// <summary>
        /// 檔案Base64清單
        /// </summary>
        public Dictionary<long, string> FileList = new Dictionary<long, string>();

        #endregion

        public WorksFilesModel() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WorksNo"></param>
        public WorksFilesModel(string WorksNo)
        {
            this.WorksNo = WorksNo;
            this.FileList = GetFileList(WorksNo);
        }
        /// <summary>
        /// 新增檔案
        /// </summary>
        /// <param name="UploadWorksFiles">http檔案清單</param>
        /// <returns></returns>
        public bool InsFile(List<HttpPostedFileBase> UploadWorksFiles)
        {
            bool IsIns = InsFile(this.WorksNo, UploadWorksFiles);
            GetFileList();
            return IsIns;
        }
        /// <summary>
        /// 批次新增檔案
        /// </summary>
        /// <param name="UploadWorksFile">http檔案</param>
        /// <returns></returns>
        public bool InsFile(HttpPostedFileBase UploadWorksFile)
        {
            bool IsIns = InsFile(this.WorksNo, new List<HttpPostedFileBase>() { UploadWorksFile });
            GetFileList();
            return IsIns;
        }
        /// <summary>
        /// 批次新增檔案
        /// </summary>
        /// <param name="WorksNo">作品序號</param>
        /// <param name="UploadWorksFiles">http檔案清單</param>
        /// <returns></returns>
        public static bool InsFile(string WorksNo, List<HttpPostedFileBase> UploadWorksFiles)
        {
            Guid Guid_WorksNo = Guid.Parse(WorksNo);
            using (var context = new EG_MagicCubeEntities())
            {
                if (UploadWorksFiles != null)
                {
                    foreach (HttpPostedFileBase _Files in UploadWorksFiles)
                    {
                        string s = SaveToAzure(_Files);
                        context.WorksFiles.Add(new WorksFiles() { WorksNo = Guid_WorksNo, FileBase64Str = s });
                        //string base64_file = WorksModel.FileToBase64(_Files);
                        //context.WorksFiles.Add(new WorksFiles() { WorksNo = Guid_WorksNo, FileBase64Str = base64_file });
                    }
                    if (context.SaveChanges() == 0)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        /// <summary>
        /// 新增檔案
        /// </summary>
        /// <param name="WorksNo">作品序號</param>
        /// <param name="UploadWorksFile">http檔案</param>
        /// <returns></returns>
        public static bool InsFile(string WorksNo, HttpPostedFileBase UploadWorksFile)
        {
            return InsFile(WorksNo, new List<HttpPostedFileBase>() { UploadWorksFile });
        }

        public static string GetFile(int WorksFilesNo)
        {
            string strStream = "";
            using (var context = new EG_MagicCubeEntities())
            {
                if (context.WorksFiles.Count() > 0)
                {
                    strStream = context.WorksFiles.AsQueryable().Where(c => c.WorksFilesNo == WorksFilesNo).Select(c => c.FileBase64Str).FirstOrDefault();
                }
            }
            return strStream;
        }


        /// <summary>
        /// 取得檔案清單
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public Dictionary<long, string> GetFileList(int PageIndex = 1, int PageSize = 10)
        {
            this.FileList = GetFileList(this.WorksNo, PageIndex, PageSize);
            return this.FileList;
        }

        /// <summary>
        /// 取得檔案清單
        /// </summary>
        /// <param name="WorksNo"></param>
        /// <param name="PageIndex">頁碼</param>
        /// <param name="PageSize">每頁筆數</param>
        /// <returns></returns>
        public static Dictionary<long, string> GetFileList(string WorksNo, int PageIndex = 1, int PageSize = 10)
        {
            Guid Guid_WorksNo = Guid.Parse(WorksNo);
            Dictionary<long, string> FileList = new Dictionary<long, string>();
            using (var context = new EG_MagicCubeEntities())
            {
                if (context.WorksFiles.Count() > 0)
                {
                    FileList = context.WorksFiles.AsQueryable().Where(c => c.WorksNo == Guid_WorksNo).Select(c => new { Key = c.WorksFilesNo, Value = c.FileBase64Str }).AsEnumerable().ToDictionary(c => c.Key, c => c.Value);
                }
            }
            return FileList;
        }

        /// <summary>
        /// 刪除檔案By 檔案序號
        /// </summary>
        /// <param name="WorksFilesNo">檔案序號</param>
        /// <returns></returns>
        public static bool DelFile(long WorksFilesNo)
        {
            return DelFile(new List<long>() { WorksFilesNo });
        }

        /// <summary>
        /// 刪除檔案By 序號清單
        /// </summary>
        /// <param name="WorksFilesNoList">檔案序號清單</param>
        /// <returns></returns>
        public static bool DelFile(List<long> WorksFilesNoList)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient _CloudBlobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = _CloudBlobClient.GetContainerReference("worksimg");

            long[] WorksFilesNoArray = WorksFilesNoList.ToArray();
            if (WorksFilesNoArray != null && WorksFilesNoArray.Length > 0)
            {
                using (var context = new EG_MagicCubeEntities())
                {
                    var WorksFilesList = context.WorksFiles.AsQueryable().Where(c => WorksFilesNoArray.Contains(c.WorksFilesNo)).Select(c => c).ToList();
                    if (WorksFilesList != null)
                    {
                        foreach (var _WorksFiles in WorksFilesList)
                        {
                            string filename = _WorksFiles.FileBase64Str.Substring(_WorksFiles.FileBase64Str.LastIndexOf("/")+1);
                            CloudBlockBlob blockBlob = container.GetBlockBlobReference(filename);
                            if (blockBlob.Exists())
                            {
                                blockBlob.Delete();
                            }
                            context.WorksFiles.Remove(_WorksFiles);
                        }
                    }
                    if (context.SaveChanges() == 0)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool DelAzure()
        {
            return true;
        }
        public static string SaveToAzure(HttpPostedFileBase UploadWorksFiles)
        {
            byte[] thePictureAsBytes = new byte[UploadWorksFiles.ContentLength];
            string filebase64 = "";
            using (BinaryReader theReader = new BinaryReader(UploadWorksFiles.InputStream))
            {
                thePictureAsBytes = theReader.ReadBytes(UploadWorksFiles.ContentLength);
                filebase64 = Convert.ToBase64String(thePictureAsBytes);
            }
            

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudBlobClient _CloudBlobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = _CloudBlobClient.GetContainerReference("worksimg");

            string FileName = Guid.NewGuid().GetHashCode().ToString();
            string FileName_o = FileName+".jpg";
            string FileName_m= FileName + "_m.jpg";
            string FileName_s = FileName + "_s.jpg";
            
            string FileBase64_o = ImgFileToBase64(new MagickImage(Convert.FromBase64String(filebase64)));
            string FileBase64_m = ImgFileToBase64(new MagickImage(Convert.FromBase64String(filebase64)), 600);
            string FileBase64_s = ImgFileToBase64(new MagickImage(Convert.FromBase64String(filebase64)), 200);

            CloudBlockBlob blockBlob_o = container.GetBlockBlobReference(FileName_o);
            blockBlob_o.Properties.ContentType = "image/jpg";
            blockBlob_o.UploadFromStream(new MemoryStream(Convert.FromBase64String(FileBase64_o)));
            var uriBuilder = new UriBuilder(blockBlob_o.Uri);

            CloudBlockBlob blockBlob_m = container.GetBlockBlobReference(FileName_m);
            blockBlob_m.Properties.ContentType = "image/jpg";
            blockBlob_m.UploadFromStream(new MemoryStream(Convert.FromBase64String(FileBase64_m)));

            CloudBlockBlob blockBlob_s = container.GetBlockBlobReference(FileName_s);
            blockBlob_s.Properties.ContentType = "image/jpg";
            blockBlob_s.UploadFromStream(new MemoryStream(Convert.FromBase64String(FileBase64_s)));


            string imgurl = blockBlob_o.StorageUri.PrimaryUri.ToString();

            return imgurl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_File"></param>
        /// <param name="maxedge"></param>
        /// <returns></returns>
        public static string ImgFileToBase64(MagickImage _ImgFile,int maxedge=0)
        {
            string thePictureDataAsString = "";
            MemoryStream ms_mini = new MemoryStream();

            _ImgFile.Format = MagickFormat.Jpeg;
            _ImgFile.Quality = 70;
            _ImgFile.CompressionMethod = CompressionMethod.JPEG;
            if (maxedge > 0)
            {
                if (_ImgFile.Width > maxedge || _ImgFile.Height > maxedge)
                {
                    _ImgFile.Resize(new MagickGeometry(maxedge));
                }
                _ImgFile.Sharpen(0, 0.8, Channels.All);
            }
            _ImgFile.Strip();
            _ImgFile.Write(ms_mini);
            thePictureDataAsString = Convert.ToBase64String(ms_mini.ToArray());
            ms_mini.Dispose();
            _ImgFile.Dispose();
            return thePictureDataAsString;
        }
    }



}