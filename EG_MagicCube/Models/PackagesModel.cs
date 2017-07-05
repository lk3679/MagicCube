using EG_MagicCubeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models
{
    [MetadataType(typeof(PackagesModelMetaData))]
    public partial class PackagesModel:Packages
    {
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
                context.Packages.Add(this);
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
        public IQueryable<Packages> All()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Packages;
            }
        }

        /// <summary>
        /// 以包裝編號取得包裝品
        /// </summary>
        /// <param name="PackagesNo">包裝編號</param>
        /// <returns></returns>
        public Packages GetPackagesByPG_No(string PackagesNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Packages.FirstOrDefault(x => x.PackagesNo == Guid.Parse(PackagesNo));
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
                oldPackages.PackageItems = newPackages.PackageItems;
                oldPackages.EndDate = newPackages.EndDate;
                oldPackages.ModifyUser = newPackages.ModifyUser;
                oldPackages.ModifyDate = newPackages.ModifyDate;
                oldPackages.PackagesMemo = newPackages.PackagesMemo;
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
    public partial class PackagesModelMetaData
    {
        #region Properties
        [Required]
        [DisplayName("作品序號")]
        public string WorksNo { get; set; }
        [Required]
        [DisplayName("物料代碼")]
        public string MaterialsID { get; set; }
        [Required]
        [DisplayName("藝術家編號")]
        public string AuthorsNo { get; set; }
        [Required]
        [DisplayName("作品名稱")]
        public string WorksName { get; set; }
        [Required]
        [DisplayName("作品起始年分")]
        public string YearStart { get; set; }
        [Required]
        [DisplayName("作品結束年分")]
        public string YearEnd { get; set; }
        [Required]
        [DisplayName("備註")]
        public string Remarks { get; set; }
        [Required]
        [DisplayName("成本價")]
        public string Cost { get; set; }
        [Required]
        [DisplayName("定價")]
        public string Price { get; set; }
        [Required]
        [DisplayName("定價時間")]
        public string PricingDate { get; set; }
        [Required]
        [DisplayName("毛利率")]
        public string GrossMargin { get; set; }
        [Required]
        [DisplayName("市場性")]
        public string Marketability { get; set; }
        [Required]
        [DisplayName("包裹性")]
        public string Packageability { get; set; }
        [Required]
        [DisplayName("增值性")]
        public string Valuability { get; set; }
        [Required]
        [DisplayName("藝術性")]
        public string Artisticability { get; set; }
        #endregion
    }
}