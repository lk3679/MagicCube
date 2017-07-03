using EG_MagicCube.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models
{
    [MetadataType(typeof(WorksModelMetaData))]
    public partial class WorksModel:Works_List
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
                context.Works_List.Add(this);
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
        public IQueryable<Works_List> All()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Works_List;
            }
        }

        /// <summary>
        /// 以作品編號取得作品
        /// </summary>
        /// <param name="Works_No">作品編號</param>
        /// <returns></returns>
        public Works_List GetWorksByWorksNo(string Works_No)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Works_List.FirstOrDefault(x => x.Works_No == Guid.Parse(Works_No));
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
                var oldWorks = context.Works_List.First(x => x.Works_No == newWorks.Works_No);
                oldWorks.Author_No = newWorks.Author_No;
                oldWorks.WorksName = newWorks.WorksName;
                
                
                oldWorks.Year_Start = newWorks.Year_Start;
                oldWorks.Year_End = newWorks.Year_End;
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
        public bool Delete(string Works_No)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var works = context.Works_List.FirstOrDefault(x => x.Works_No == Guid.Parse(Works_No));
                if (works == null)
                {
                    return false;
                }

                context.Works_List.Remove(works);
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
        public string Works_No { get; set; }
        [Required]
        [DisplayName("物料代碼")]
        public string Materials_ID { get; set; }
        [Required]
        [DisplayName("藝術家編號")]
        public string Author_No { get; set; }
        [Required]
        [DisplayName("作品名稱")]
        public string WorksName { get; set; }
        [Required]
        [DisplayName("作品起始年分")]
        public string Year_Start { get; set; }
        [Required]
        [DisplayName("作品結束年分")]
        public string Year_End { get; set; }
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