using EG_MagicCube.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models
{
    public partial class PackageModel:Package_List
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
                context.Package_List.Add(this);
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
        public IQueryable<Package_List> All()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Package_List;
            }
        }

        /// <summary>
        /// 以包裝編號取得包裝品
        /// </summary>
        /// <param name="PG_No">包裝編號</param>
        /// <returns></returns>
        public Package_List GetPackagesByPG_No(string PG_No)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Package_List.FirstOrDefault(x => x.PG_No == Guid.Parse(PG_No));
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// 以包裝資料更新
        /// </summary>
        /// <param name="newPackage">新包裝資料</param>
        /// <returns></returns>
        public bool Update(PackageModel newPackage)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var oldPackage = context.Package_List.First(x => x.PG_No == newPackage.PG_No);
                oldPackage.PG_Name = newPackage.PG_Name;
                oldPackage.PackingDate = newPackage.PackingDate;
                oldPackage.PackageItemList = newPackage.PackageItemList;
                oldPackage.EndDate = newPackage.EndDate;
                oldPackage.ModifyUser = newPackage.ModifyUser;
                oldPackage.ModifyDate = newPackage.ModifyDate;
                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Delete
        public bool Delete(string PG_No)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var package = context.Package_List.FirstOrDefault(x => x.PG_No == Guid.Parse(PG_No));
                if (package == null)
                {
                    return false;
                }

                context.Package_List.Remove(package);
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