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
using ZXing;
namespace EG_MagicCube.Models
{

    public partial class PackagesModel
    {
        public enum OrderByTypeEnum
        {
            /// <summary>
            /// 無
            /// </summary>
            None,
            /// <summary>
            /// 時間最新再前面
            /// </summary>
            MaxTime,
            /// <summary>
            /// 時間最舊再前面
            /// </summary>
            MineTime
        }
        /// <summary>
        /// 包裝序號
        /// </summary>
        [DisplayName("包裝序號")]
        public string PackagesNo { get; set; } = "";
        /// <summary>
        /// 包裝名稱
        /// </summary>
        [DisplayName("包裝名稱")]
        public string PackagesName { get; set; } = "";
        /// <summary>
        /// 截止日期
        /// </summary>
        [DisplayName("截止日期")]
        public Nullable<DateTime> EndDate { get; set; }
        /// <summary>
        /// 打包日期
        /// </summary>
        [DisplayName("打包日期")]
        public Nullable<DateTime> PackingDate { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        [DisplayName("建立日期")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        /// <summary>
        /// 建立者
        /// </summary>
        [DisplayName("建立者")]
        public string CreateUser { get; set; } = "";
        /// <summary>
        /// 修改者
        /// </summary>
        [DisplayName("修改者")]
        public string ModifyUser { get; set; } = "";
        /// <summary>
        /// 修改日期
        /// </summary>
        [DisplayName("修改日期")]
        public Nullable<DateTime> ModifyDate { get; set; }
        /// <summary>
        /// 查詢條件
        /// </summary>
        [DisplayName("查詢條件")]
        public string SearchJson { get; set; } = "";
        /// <summary>
        /// 備註
        /// </summary>
        public string PackagesMemo { get; set; } = "";
        /// <summary>
        /// 包裝內作品項目
        /// </summary>
        [DisplayName("包裝內作品項目")]
        public List<PackageItemModel> PackageItems { get; set; } = new List<PackageItemModel>();
        /// <summary>
        /// QRCode Base64圖片
        /// </summary>
        [DisplayName("QRCode Base64圖片")]
        public string QRImg { get; set; } = "";
        /// <summary>
        /// 包裝項目數量
        /// </summary>
        public string ItemAmount { get; set; } = "";
        /// <summary>
        /// 預算
        /// </summary>
        public int Budget { get; set; } = 0;
        /// <summary>
        /// 排序方式
        /// </summary>
        public MenuModel.MeunOrderbyTypeEnum OrderbyType = MenuModel.MeunOrderbyTypeEnum.預設排序;
        #region Methods

        #region Create
        /// <summary>
        /// 新增包裝
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                Packages _Package = new Packages();
                _Package.PackagesNo = Guid.NewGuid();
                this.PackagesNo = _Package.PackagesNo.ToString();
                _Package.PackagesName = this.PackagesName;
                _Package.EndDate = this.EndDate;
                _Package.PackingDate = this.PackingDate;
                _Package.PackagesMemo = this.PackagesMemo;
                _Package.SearchJson = this.SearchJson;
                _Package.CreateDate = DateTime.Now;
                _Package.CreateUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                _Package.ModifyDate = DateTime.Now;
                _Package.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                _Package.Budget = this.Budget;
                _Package.IsDel = "";
                context.Packages.Add(_Package);
                if (context.SaveChanges() > 0)
                {
                    foreach (PackageItemModel _PackageItemModel in PackageItems)
                    {
                        Guid Guid_WorksNo = Guid.Parse(_PackageItemModel.WorksNo);
                        context.PackageItems.Add(new PackageItems()
                        {
                            PackagesNo = _Package.PackagesNo,
                            WorksNo = Guid_WorksNo,
                            JoinDate = DateTime.Now,
                            IsJoin = _PackageItemModel.IsJoin,
                            DelDate = new Nullable<DateTime>()
                        });
                    }
                    if (context.SaveChanges() == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 新增並回傳
        /// </summary>
        /// <returns></returns>
        public PackagesModel CreateAndReturn()
        {
            PackagesModel _PackagesModel = new PackagesModel();
            if (this.Create())
            {
                _PackagesModel = GetPackageDetail(this.PackagesNo);
            }
            return _PackagesModel;
        }
        #endregion


        #region Read

        /// <summary>
        /// 取得包裝
        /// </summary>
        /// <param name="KeyWords">關鍵字,包裝名稱、包裝備註</param>
        /// <param name="PageIndex">頁碼，從1開始0為不分頁</param>
        /// <param name="PageSize">每頁筆數，0為不分頁</param>
        /// <param name="OrderbyType">排序方式</param>
        /// <returns></returns>
        public static List<PackagesModel> GetPackageList(string KeyWords = "", int PageIndex = 0, int PageSize = 0, MenuModel.MeunOrderbyTypeEnum OrderbyType = MenuModel.MeunOrderbyTypeEnum.預設排序)
        {
            List<PackagesModel> _PackagesList = new List<PackagesModel>();
            using (var context = new EG_MagicCubeEntities())
            {
                if (context.Packages.Count() > 0)
                {
                    var pgl = context.Packages.AsQueryable().Where(f =>
                                f.IsDel != "Y" &&
                                (f.PackagesName.Contains(KeyWords)
                               || f.PackagesMemo.Contains(KeyWords))).Select(c =>c);

                    if (MenuModel.MeunOrderbyTypeEnum.預設排序 == OrderbyType)
                    {
                        pgl = pgl.OrderByDescending(c => c.PackagesNo);
                    }
                    else
                     if (MenuModel.MeunOrderbyTypeEnum.建立時間由舊至新 == OrderbyType)
                    {
                        pgl = pgl.OrderBy(c => c.CreateDate);
                    }
                    else
                     if (MenuModel.MeunOrderbyTypeEnum.建立時間由新至舊 == OrderbyType)
                    {
                        pgl = pgl.OrderByDescending(c => c.CreateDate);
                    }
                    else
                     if (MenuModel.MeunOrderbyTypeEnum.修改時間由舊至新 == OrderbyType)
                    {
                        pgl = pgl.OrderBy(c => c.ModifyDate);
                    }
                    else
                     if (MenuModel.MeunOrderbyTypeEnum.修改時間由新至舊 == OrderbyType)
                    {
                        pgl = pgl.OrderByDescending(c => c.ModifyDate);
                    }
                    else
                     if (MenuModel.MeunOrderbyTypeEnum.名稱姓名小至大 == OrderbyType)
                    {
                        pgl = pgl.OrderBy(c => c.PackagesName);
                    }
                    else
                     if (MenuModel.MeunOrderbyTypeEnum.名稱姓名大至小 == OrderbyType)
                    {
                        pgl = pgl.OrderByDescending(c => c.PackagesName);
                    }
                    else
                    {
                        pgl = pgl.OrderByDescending(c => c.PackagesNo);
                    }
                    if (PageIndex > 0 && PageIndex > 0)
                    {
                        pgl = pgl.Select(c => c).Skip((PageIndex * PageSize - PageSize)).Take(PageSize);
                    }

                    var r_pgl = pgl.ToList();

                    _PackagesList = r_pgl.AsEnumerable().Select(c =>
                               new PackagesModel()
                               {
                                   PackagesNo = c.PackagesNo.ToString(),
                                   PackagesName = c.PackagesName,
                                   EndDate = c.EndDate,
                                   PackingDate = c.PackingDate,
                                   CreateDate = c.CreateDate,
                                   CreateUser = c.CreateUser,
                                   ModifyUser = c.ModifyUser,
                                   ModifyDate = c.ModifyDate,
                                   SearchJson = c.SearchJson,
                                   PackagesMemo = c.PackagesMemo,
                                   ItemAmount = c.PackageItems.Where(pi => pi.IsJoin == "Y").Count().ToString() + " (" + c.PackageItems.Count.ToString() + ")",
                                   Budget=c.Budget
                               }).ToList();

                }

            }
            return _PackagesList;
        }
       
        /// <summary>
        /// 取得包裝明細
        /// </summary>
        /// <param name="PackagesNo">包裝編號</param>
        /// <returns></returns>
        public static PackagesModel GetPackageDetail(string PackagesNo)
        {
            PackagesModel _PackagesModel = new PackagesModel();
            using (var context = new EG_MagicCubeEntities())
            {
                if (context.Packages.Count() > 0)
                {
                    var Guid_PackagesNo = Guid.Parse(PackagesNo.ToString());
                    _PackagesModel = context.Packages.AsEnumerable().Where(f => f.IsDel !="Y" && f.PackagesNo == Guid_PackagesNo).Select(c =>
                                  new PackagesModel()
                                  {
                                      PackagesNo = c.PackagesNo.ToString(),
                                      QRImg = "",
                                      PackagesName = c.PackagesName,
                                      EndDate = c.EndDate,
                                      PackingDate = c.PackingDate,
                                      CreateDate = c.CreateDate,
                                      CreateUser = c.CreateUser,
                                      ModifyUser = c.ModifyUser,
                                      ModifyDate = c.ModifyDate,
                                      SearchJson = c.SearchJson,
                                      PackagesMemo = c.PackagesMemo,
                                      ItemAmount = c.PackageItems.Where(pi => pi.IsJoin == "Y").Count().ToString() + " (" + c.PackageItems.Count.ToString() + ")",
                                      Budget=c.Budget
                                      //,PackageItems = c.PackageItems.Select(pi => new PackageItemModel()
                                      //{
                                      //    WorksNo = pi.WorksNo.ToString(),
                                      //    WorksName = pi.Works.WorksName,
                                      //    Price = pi.Works.Price,
                                      //    AuthorsName = pi.Works.WorksAuthors.FirstOrDefault().Authors.AuthorsCName,
                                      //    IsJoin = pi.IsJoin
                                      //}
                                      //).ToList()
                                  }

                               ).FirstOrDefault();
                }

            }

            return _PackagesModel;
        }

        /// <summary>
        /// 取得包裝項目
        /// </summary>
        /// <param name="ShowJoin">只顯示加入包裝的</param>
        /// <returns></returns>
        public bool GetPackageItemList(bool ShowJoin = false)
        {
            List<PackageItemModel> _PackageItemList = new List<PackageItemModel>();
            
            using (var context = new EG_MagicCubeEntities())
            {
                if (context.PackageItems.Count() > 0)
                {
                    var Guid_PackagesNo = Guid.Parse(this.PackagesNo);
                    List<PackageItems> PackageItems = new List<PackageItems>() ;
                    if (ShowJoin)
                    {
                        PackageItems = context.PackageItems.AsQueryable().Where(f => f.PackagesNo == Guid_PackagesNo && f.IsJoin == "Y").Select(c=>c).ToList();
                        //_PackageItemList = r.Where(f => f.IsJoin == "Y").ToList();
                    }
                    else
                    {
                        PackageItems = context.PackageItems.AsQueryable().Where(f => f.PackagesNo == Guid_PackagesNo ).Select(c => c).ToList();
                        // _PackageItemList = r.ToList();
                    }
                    if (PackageItems != null)
                    {
                        _PackageItemList = PackageItems.Select(c =>
                              new PackageItemModel()
                              {
                                  WorksNo = c.WorksNo.ToString(),
                                                      WorksImg = c.Works.WorksFiles?.FirstOrDefault()?.FileBase64Str,
                                                      //WorksImgID = c.Works.WorksFiles?.FirstOrDefault()?.WorksFilesNo.ToString(),
                                  AuthorsName = c.Works.WorksAuthors?.FirstOrDefault()?.Authors?.AuthorsCName,
                                  WorksName = c.Works.WorksName,
                                  IsJoin = c.IsJoin,
                                  Price = c.Works.Price
                              }

                           ).ToList();
                    }

                }
                else
                {
                    return false;
                }
            }
            this.PackageItems = _PackageItemList;
            if (_PackageItemList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 回傳包裝項目
        /// </summary>
        /// <param name="PackagesNo"></param>
        /// <param name="ShowJoin"></param>
        /// <returns></returns>
        public static List<PackageItemModel> ReturnPackageItemList(string PackagesNo, bool ShowJoin)
        {
            List<PackageItemModel> _PackageItemList = new List<PackageItemModel>();
            using (var context = new EG_MagicCubeEntities())
            {
                if (context.PackageItems.Count() > 0)
                {
                    var Guid_PackagesNo = Guid.Parse(PackagesNo);
                    var r = context.PackageItems?.AsEnumerable().Where(f => f.PackagesNo == Guid_PackagesNo).Select(c =>
                                  new PackageItemModel()
                                  {
                                      WorksNo = c.WorksNo.ToString(),
                                      WorksImg = c.Works?.WorksFiles?.FirstOrDefault().FileBase64Str,
                                      //WorksImgID = c.Works?.WorksFiles?.FirstOrDefault().WorksFilesNo.ToString(),
                                      AuthorsName = c.Works?.WorksAuthors?.FirstOrDefault().Authors.AuthorsCName,
                                      WorksName = c.Works?.WorksName,
                                      IsJoin = c.IsJoin,
                                      Price = c.Works.Price
                                  }
                               );
                    if (ShowJoin)
                    {
                        _PackageItemList = r.Where(f => f.IsJoin == "Y").ToList();
                    }
                    else
                    {
                        _PackageItemList = r.ToList();
                    }
                }

            }
            return _PackageItemList;
        }

        #endregion

        #region Update
        /// <summary>
        /// 以包裝資料更新
        /// </summary>
        /// <param name="newPackages">新包裝資料</param>
        /// <returns></returns>
        public static bool Update(PackagesModel newPackages)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var Guid_PackagesNo = Guid.Parse(newPackages.PackagesNo);
                var oldPackages = context.Packages.AsEnumerable().AsEnumerable().First(x => x.PackagesNo == Guid_PackagesNo);
                if (oldPackages != null)
                {
                    if (!string.IsNullOrEmpty(newPackages.PackagesName))
                    {
                        oldPackages.PackagesName = newPackages.PackagesName;
                    }
                    oldPackages.PackingDate = newPackages.PackingDate;
                    oldPackages.EndDate = newPackages.EndDate;
                    oldPackages.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                    oldPackages.ModifyDate = newPackages.ModifyDate;
                    oldPackages.PackagesMemo = newPackages.PackagesMemo;
                    oldPackages.SearchJson = newPackages.SearchJson;
                    oldPackages.Budget = newPackages.Budget;
                    foreach (PackageItemModel _PackageItemModel in newPackages.PackageItems)
                    {
                        var Guid_WorksNo = Guid.Parse(_PackageItemModel.WorksNo);
                        int PackageItemCount = context.PackageItems.AsEnumerable().Where(c => c.PackagesNo == oldPackages.PackagesNo && c.WorksNo == Guid_WorksNo).Count();
                        if (PackageItemCount == 0)
                        {
                            context.PackageItems.Add(new PackageItems()
                            {
                                PackagesNo = oldPackages.PackagesNo,
                                WorksNo = Guid_WorksNo,
                                JoinDate = DateTime.Now,
                                IsJoin = _PackageItemModel.IsJoin,
                                DelDate = new Nullable<DateTime>()
                            });
                        }
                    }
                    if (context.SaveChanges() == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 更新包裝資料
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            return Update(this);
        }

        /// <summary>
        /// 更新包裝項目
        /// </summary>
        /// <returns></returns>
        public bool UpdatePackageItem()
        {
            UpdatePackageItem(this.PackagesNo, this.PackageItems);
            return true;
        }

        /// <summary>
        /// 更新包裝項目
        /// </summary>
        /// <param name="PackagesNo">包裝序號</param>
        /// <param name="PackageItemModelList">包裝項目清單</param>
        /// <returns></returns>
        public static bool UpdatePackageItem(string PackagesNo, List<PackageItemModel> PackageItemModelList)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var Guid_PackagesNo = Guid.Parse(PackagesNo);

                var oldPackages = context.Packages.AsEnumerable().First(x => x.PackagesNo == Guid_PackagesNo);
                if (oldPackages != null)
                {
                    foreach (PackageItemModel _PackageItemModel in PackageItemModelList)
                    {
                        var Guid_WorksNo = Guid.Parse(_PackageItemModel.WorksNo);
                        int PackageItemCount = context.PackageItems.AsEnumerable().Where(c => c.PackagesNo == oldPackages.PackagesNo && c.WorksNo == Guid_WorksNo).Count();
                        if (PackageItemCount == 0)
                        {
                            context.PackageItems.Add(new PackageItems()
                            {
                                PackagesNo = oldPackages.PackagesNo,
                                WorksNo = Guid_WorksNo,
                                JoinDate = DateTime.Now,
                                IsJoin = _PackageItemModel.IsJoin,
                                DelDate = new Nullable<DateTime>()
                            });
                        }
                    }
                    if (context.SaveChanges() == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }

            return true;
        }

        /// <summary>
        /// 設定作品是否加入包裝
        /// </summary>
        /// <param name="PackagesNo">包裝序號</param>
        /// <param name="WorksNo">作品序號</param>
        /// <param name="ShowJoin">是否加入包裝</param>
        /// <returns></returns>
        public static bool SetPackageItemJoin(string PackagesNo, string WorksNo, bool ShowJoin)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var Guid_PackagesNo = Guid.Parse(PackagesNo);
                var Guid_WorksNo = Guid.Parse(WorksNo);
                var PackageItemList = context.PackageItems.AsEnumerable().Where(x => x.PackagesNo == Guid_PackagesNo && x.WorksNo == Guid_WorksNo).Select(c => c).ToList();

                if (PackageItemList != null | PackageItemList.Count > 0)
                {
                    foreach (PackageItems _PackageItem in PackageItemList)
                    {
                        _PackageItem.IsJoin = ShowJoin ? "Y" : "N";
                        _PackageItem.JoinDate = DateTime.Now;
                    }
                    if (context.SaveChanges() == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Delete

        /// <summary>
        /// 刪除包裝
        /// </summary>
        /// <param name="PackagesNo">包裝序號</param>
        /// <returns></returns>
        public static bool Delete(string PackagesNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var Guid_PackagesNo = Guid.Parse(PackagesNo);
                var package = context.Packages.AsQueryable().FirstOrDefault(x => x.PackagesNo == Guid_PackagesNo);

                if (package != null)
                {
                    package.IsDel = "Y";
                    package.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                    package.ModifyDate = DateTime.Now;
                    if (context.SaveChanges() == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// 刪除包裝
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            return Delete(this.PackagesNo);
        }

        /// <summary>
        /// 刪除包裝項目
        /// </summary>
        /// <param name="PackagesNo">包裝序號</param>
        /// <param name="WorksNo">作品序號</param>
        /// <returns></returns>
        public static bool DeletePackageItem(string PackagesNo, string WorksNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var Guid_PackagesNo = Guid.Parse(PackagesNo);
                var Guid_WorksNo = Guid.Parse(WorksNo);
                var PackageItemList = context.PackageItems.AsEnumerable().Where(x => x.PackagesNo == Guid_PackagesNo && x.WorksNo == Guid_WorksNo).Select(c => c).ToList();

                if (PackageItemList != null | PackageItemList.Count > 0)
                {
                    foreach (PackageItems _PackageItem in PackageItemList)
                    {
                        context.PackageItems.Remove(_PackageItem);
                    }
                    if (context.SaveChanges() == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 包裝內作品項目
        /// </summary>
        public partial class PackageItemModel
        {
            /// <summary>
            /// 作品序號
            /// </summary>
            public string WorksNo { set; get; } = "";
            /// <summary>
            /// 作品名稱
            /// </summary>
            public string WorksName { set; get; } = "";
            /// <summary>
            /// 藝術家名稱
            /// </summary>
            public string AuthorsName { set; get; } = "";
            /// <summary>
            /// 作品圖片
            /// </summary>
            public string WorksImg { set; get; } = "";
            /// <summary>
            /// 作品圖片ID
            /// </summary>
            public string WorksImgID { set; get; } = "";
            /// <summary>
            /// 是否加入包裝
            /// </summary>
            public string IsJoin { set; get; } = "N";
            /// <summary>
            /// 價格
            /// </summary>
            public int Price { set; get; } = 0;

        }

        /// <summary>
        /// 產生QRCODE圖片
        /// </summary>
        /// <param name="_Contens"></param>
        /// <returns></returns>
        public static string DrawQRcodeToImgBase64sting(string _Contens)
        {
            string _Base64String = "";
            MemoryStream ms_qr = new MemoryStream();
            //產生256*2562的QRCode PNG圖片物件
            ((System.Drawing.Image)(new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Renderer = new ZXing.Rendering.BitmapRenderer(),
                Options = new ZXing.QrCode.QrCodeEncodingOptions
                {
                    Height = 256,
                    Width = 256,
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.M,
                    Margin = 1,
                }
            }).Write(_Contens)).Save(ms_qr, System.Drawing.Imaging.ImageFormat.Png);

            MemoryStream ms_mini = new MemoryStream();
            //將圖片轉成png8,壓縮率70，
            (new MagickImage(ms_qr.ToArray()) { Format = MagickFormat.Png8, Quality = 70 }).Write(ms_mini);
            //轉成Base64
            _Base64String = Convert.ToBase64String(ms_mini.ToArray());

            ms_qr.Dispose();
            ms_mini.Dispose();

            return _Base64String;
        }
        #endregion
    }

}