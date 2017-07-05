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
    public partial class WorksModel:Works
    {
        #region Methods
        #region Create
        /// <summary>
        /// 新增作品
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                
                context.Works.Add(this);
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
        /// 取得作品
        /// </summary>
        public IQueryable<Works> All()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Works;
            }
        }

        /// <summary>
        /// 以作品編號取得作品
        /// </summary>
        /// <param name="WorksNo">作品編號</param>
        /// <returns></returns>
        public Works GetWorksByWorksNo(string WorksNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Works.FirstOrDefault(x => x.WorksNo == Guid.Parse(WorksNo));
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// 以作品資料更新
        /// </summary>
        /// <param name="newWorks">新作品資料</param>
        /// <returns></returns>
        public bool Update(WorksModel newWorks)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var oldWorks = context.Works.First(x => x.WorksNo == newWorks.WorksNo);
                oldWorks.AuthorsNo = newWorks.AuthorsNo;
                oldWorks.WorksName = newWorks.WorksName;
                
                
                oldWorks.YearStart = newWorks.YearStart;
                oldWorks.YearEnd = newWorks.YearEnd;
                oldWorks.Remarks = newWorks.Remarks;
                oldWorks.Cost = newWorks.Cost;
                oldWorks.Price = newWorks.Price;
                oldWorks.PricingDate = newWorks.PricingDate;
                oldWorks.GrossMargin = newWorks.GrossMargin;
                oldWorks.Marketability = newWorks.Marketability;
                oldWorks.Packageability = newWorks.Packageability;
                oldWorks.Valuability = newWorks.Valuability;
                oldWorks.Artisticability = newWorks.Artisticability;

                oldWorks.ModifyUser = newWorks.ModifyUser;
                oldWorks.ModifyDate = DateTime.Now;

                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Delete
        public bool Delete(string WorksNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var works = context.Works.FirstOrDefault(x => x.WorksNo == Guid.Parse(WorksNo));
                if (works == null)
                {
                    return false;
                }

                context.Works.Remove(works);
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

    public partial class WorksModelMetaData
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