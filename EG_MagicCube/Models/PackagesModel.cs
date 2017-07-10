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
using ZXing;
namespace EG_MagicCube.Models
{
    //[MetadataType(typeof(PackagesModelMetaData))]
    public partial class PackagesModel//:Packages
    {
        /// <summary>
        /// 包裝序號
        /// </summary>
        [DisplayName("包裝序號")]
        public Guid PackagesNo { get; set; }
        /// <summary>
        /// 包裝名稱
        /// </summary>
        [DisplayName("包裝名稱")]
        public string PackagesName { get; set; }
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
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 建立者
        /// </summary>
        [DisplayName("建立者")]
        public string CreateUser { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        [DisplayName("修改者")]
        public string ModifyUser { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        [DisplayName("修改日期")]
        public Nullable<DateTime> ModifyDate { get; set; }
        /// <summary>
        /// 查詢條件
        /// </summary>
        [DisplayName("查詢條件")]
        public string SearchJson { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string PackagesMemo { get; set; }
        /// <summary> 
        /// 作品編號清單
        /// </summary>
        [DisplayName("作品編號清單")]
        public List<string> WorksNos { get; set; }
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
                _Package.PackagesName = this.PackagesName;
                _Package.EndDate = this.EndDate;
                _Package.PackingDate = this.PackingDate;
                _Package.PackagesMemo = this.PackagesMemo;
                _Package.SearchJson = this.SearchJson;
                _Package.CreateDate = DateTime.Now;
                _Package.CreateUser = "";
                _Package.ModifyDate = DateTime.Now;
                _Package.ModifyUser = "";
                foreach (string WorksNo in WorksNos)
                {
                    _Package.PackageItems.Add(new EG_MagicCubeEntity.PackageItems()
                    {
                        PackagesNo = _Package.PackagesNo,
                        WorksNo = Guid.Parse(WorksNo),
                        JoinDate = DateTime.Now,
                        IsJoin = "Y"
                    });
                }
                context.Packages.Add(_Package);
                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Read
        /// <summary>
        /// 取得包裝
        /// </summary>
        public List<Packages> All(int PageIndex = 1, int PageSize = 10)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Packages.OrderBy(c => c.PackagesNo).Skip((PageIndex * PageSize) - PageSize).Take(PageSize).ToList();
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// 以包裝資料更新
        /// </summary>
        /// <param name="newPackages">新包裝資料</param>
        /// <returns></returns>
        public bool Update(PackagesModel newPackages)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var oldPackages = context.Packages.First(x => x.PackagesNo == newPackages.PackagesNo);
                oldPackages.PackagesName = newPackages.PackagesName;
                oldPackages.PackingDate = newPackages.PackingDate;
                oldPackages.EndDate = newPackages.EndDate;
                oldPackages.ModifyUser = newPackages.ModifyUser;
                oldPackages.ModifyDate = newPackages.ModifyDate;
                oldPackages.PackagesMemo = newPackages.PackagesMemo;
                oldPackages.SearchJson = newPackages.SearchJson;
                

                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Delete
        public bool Delete(string PackagesNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var packages = context.Packages.FirstOrDefault(x => x.PackagesNo == Guid.Parse(PackagesNo));
                if (packages == null)
                {
                    return false;
                }

                context.Packages.Remove(packages);
                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #endregion
    }
    public partial class QRCodeWriter
    {
        private string _Base64String = "";
        public string Base64String { get { return _Base64String; } }
        public QRCodeWriter(string _Contens)
        {
            DrawQRcodeToImgBase64sting(_Contens);
        }
        public void DrawQRcodeToImgBase64sting(string _Contens)
        {
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
        }
    }
}