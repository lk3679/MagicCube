using EG_MagicCubeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models
{
    [MetadataType(typeof(WorksModelMetaData))]
    public partial class PackageModel:Packages
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
        public bool Update(PackageModel newPackages)
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
}