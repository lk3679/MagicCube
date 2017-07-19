﻿using EG_MagicCubeEntity;
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
                foreach (HttpPostedFileBase _Files in UploadWorksFiles)
                {
                    string base64_file = WorksModel.FileToBase64(_Files);
                    context.WorksFiles.Add(new WorksFiles() { WorksNo = Guid_WorksNo, FileBase64Str = base64_file });
                }
                if (context.SaveChanges() == 0)
                {
                    return false;
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
                    FileList = context.WorksFiles.AsEnumerable().Where(c => c.WorksNo == Guid_WorksNo).Select(c => new { Key = c.WorksFilesNo, Value = c.FileBase64Str }).AsEnumerable().ToDictionary(c => c.Key, c => c.Value);
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
            using (var context = new EG_MagicCubeEntities())
            {
                var WorksFilesList = context.WorksFiles.AsEnumerable().Where(c => WorksFilesNoList.Contains(c.WorksFilesNo)).Select(c => c);
                if (WorksFilesList != null)
                {
                    foreach (WorksFiles _WorksFiles in WorksFilesList.ToList())
                    {
                        context.WorksFiles.Remove(_WorksFiles);
                    }
                }
                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }



}