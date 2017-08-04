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
        public partial class FileGroup
        {
            /// <summary>
            /// 檔案序號
            /// </summary>
            public long WorksFilesNo { get; set; } = 0;
            /// <summary>
            /// 小尺吋檔案Base64
            /// </summary>
            public string FileBase64 { get; set; } = "";
            /// <summary>
            /// 原始尺吋檔案Base64
            /// </summary>
            public string File_o_Url { get; set; } = "";
            /// <summary>
            /// 中尺吋檔案Base64
            /// </summary>
            public string File_m_Url { get; set; } = "";
            /// <summary>
            /// 小尺吋檔案Base64
            /// </summary>
            public string File_s_Url { get; set; } = "";
            /// <summary>
            /// 排序號碼
            /// </summary>
            public short Sorting { get; set; } = 0;

        }
        /// <summary>
        /// 檔案排序項目
        /// </summary>
        public class FileSortingItem
        {
            /// <summary>
            /// 檔案序號
            /// </summary>
            public long WorksFilesNo { get; set; } = 0;
            /// <summary>
            /// 排序號碼
            /// </summary>
            public short Sorting { get; set; } = 0;
        }
        #region Properties
        /// <summary>
        /// 作品序號
        /// </summary>
        [DisplayName("作品序號")]
        public string WorksNo { get; set; } = "";
        /// <summary>
        /// 檔案Base64清單
        /// </summary>
        public List<FileGroup> FileList = new List<FileGroup>();

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
            if (UploadWorksFiles != null)
            {
                using (var context = new EG_MagicCubeEntities())
                {
                    foreach (HttpPostedFileBase _Files in UploadWorksFiles)
                    {
                        if (_Files != null)
                        {
                            byte[] thePictureAsBytes = new byte[_Files.ContentLength];
                            //string filebase64 = "";
                            using (BinaryReader theReader = new BinaryReader(_Files.InputStream))
                            {
                                thePictureAsBytes = theReader.ReadBytes(_Files.ContentLength);
                                //filebase64 = Convert.ToBase64String(thePictureAsBytes);
                            }
                            string FileName_o = Math.Abs(Guid.NewGuid().GetHashCode()).ToString() + ".jpg";
                            string FileName_m = Math.Abs(Guid.NewGuid().GetHashCode()).ToString() + ".jpg";
                            string FileName_s = Math.Abs(Guid.NewGuid().GetHashCode()).ToString() + ".jpg";

                            byte[] FileBinary_o = ImgFileToFileBinary(new MagickImage(thePictureAsBytes),0, 70);
                            byte[] FileBinary_m = ImgFileToFileBinary(new MagickImage(thePictureAsBytes), 800, 70);
                            byte[] FileBinary_s = ImgFileToFileBinary(new MagickImage(thePictureAsBytes), 200, 40);
                            
                            string img_o_url = SaveToAzure(FileName_o, FileBinary_o);
                            string img_m_url = SaveToAzure(FileName_m, FileBinary_m);
                            string img_s_url = SaveToAzure(FileName_s, FileBinary_s);

                            context.WorksFiles.Add(new WorksFiles() { WorksNo = Guid_WorksNo, Sorting = 0, FileBase64Str = Convert.ToBase64String(FileBinary_s), File_o_Url = img_o_url, File_m_Url = img_m_url, File_s_Url = img_s_url });
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
        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="_FileSortingItemList"></param>
        /// <returns></returns>
        public static bool UpdateSorting(FileSortingItem [] _FileSortingItemList)
        {
            if (_FileSortingItemList != null)
            {
                using (var context = new EG_MagicCubeEntities())
                {

                    foreach (FileSortingItem _FileSortingItem in _FileSortingItemList)
                    {
                        var _File = context.WorksFiles.AsQueryable().FirstOrDefault(c => c.WorksFilesNo == _FileSortingItem.WorksFilesNo);
                        if (_File != null)
                        {
                            _File.Sorting = _FileSortingItem.Sorting;
                        }
                        if (context.SaveChanges() == 0)
                        {
                           
                        }
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
        public List<FileGroup> GetFileList(int PageIndex = 1, int PageSize = 10)
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
        public static List<FileGroup> GetFileList(string WorksNo, int PageIndex = 1, int PageSize = 10)
        {
            Guid Guid_WorksNo = Guid.Parse(WorksNo);

            List<FileGroup> _FileList = new List<FileGroup>();
            
            using (var context = new EG_MagicCubeEntities())
            {
                if (context.WorksFiles.Count() > 0)
                {
                    _FileList = context.WorksFiles.AsQueryable().Where(c => c.WorksNo == Guid_WorksNo).OrderBy(c=>c.Sorting).ThenBy(c => c.WorksFilesNo).Select(c => new FileGroup() { WorksFilesNo=c.WorksFilesNo,FileBase64=c.FileBase64Str,File_o_Url=c.File_o_Url,File_m_Url=c.File_m_Url, File_s_Url=c.File_s_Url,Sorting=c.Sorting}).ToList();
                }
            }
            return _FileList;
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
                            string filename_o = _WorksFiles.File_o_Url.Substring(_WorksFiles.File_o_Url.LastIndexOf("/")+1);
                            CloudBlockBlob blockBlob = container.GetBlockBlobReference(filename_o);
                            if (blockBlob.Exists())
                            {
                                blockBlob.Delete();
                            }
                            string filename_m = _WorksFiles.File_m_Url.Substring(_WorksFiles.File_m_Url.LastIndexOf("/") + 1);
                            CloudBlockBlob blockBlob_m = container.GetBlockBlobReference(filename_m);
                            if (blockBlob_m.Exists())
                            {
                                blockBlob_m.Delete();
                            }
                            string filename_s = _WorksFiles.File_s_Url.Substring(_WorksFiles.File_s_Url.LastIndexOf("/") + 1);
                            CloudBlockBlob blockBlob_s = container.GetBlockBlobReference(filename_s);
                            if (blockBlob_s.Exists())
                            {
                                blockBlob_s.Delete();
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
        public static string SaveToAzure(string FileName, byte[] FileBinary)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient _CloudBlobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = _CloudBlobClient.GetContainerReference("worksimg");      
            CloudBlockBlob blockBlob_o = container.GetBlockBlobReference(FileName);
            blockBlob_o.Properties.ContentType = "image/jpg";
            blockBlob_o.UploadFromStream(new MemoryStream(FileBinary));
            var uriBuilder = new UriBuilder(blockBlob_o.Uri);
            string imgurl = blockBlob_o.StorageUri.PrimaryUri.ToString();
            return imgurl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_File"></param>
        /// <param name="maxedge"></param>
        /// <returns></returns>
        public static byte[] ImgFileToFileBinary(MagickImage _ImgFile,int maxedge=0,int CompressionQuality=70)
        {
            string thePictureDataAsString = "";
            MemoryStream ms_mini = new MemoryStream();
            _ImgFile.Format = MagickFormat.Jpeg;
            if (CompressionQuality <= 0)
            {
                _ImgFile.Quality = 70;
            }
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
            _ImgFile.Dispose();
            return ms_mini.ToArray();
        }
        public static string ImgFileToBase64(MagickImage _ImgFile, int maxedge = 0, int CompressionQuality = 70)
        {
            string thePictureDataAsString = "";
            MemoryStream ms_mini = new MemoryStream();

            _ImgFile.Format = MagickFormat.Jpeg;
            if (CompressionQuality <= 0)
            {
                _ImgFile.Quality = 70;
            }
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