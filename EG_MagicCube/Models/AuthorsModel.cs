using EG_MagicCubeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models
{
    [MetadataType(typeof(AuthorsModelMetaData))]
    public partial class AuthorsModel : Authors
    {
        #region Methods
        #region Create
        /// <summary>
        /// 新增藝術家
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                context.Authors.Add(this);
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
        /// 取得所有藝術家
        /// </summary>
        public IQueryable<Authors> All()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Authors;
            }
        }

        /// <summary>
        /// 以藝術家編號取得藝術家
        /// </summary>
        /// <param name="authorsNo">藝術家編號</param>
        /// <returns></returns>
        public Authors GetAuthorByAuthorNo(int authorsNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Authors.FirstOrDefault(x => x.AuthorsNo == authorsNo);
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// 以新藝術家資料更新
        /// </summary>
        /// <param name="newAuthors">新藝術家資料</param>
        /// <returns></returns>
        public bool Update(AuthorsModel newAuthors)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var oldAuthors = context.Authors.First(x => x.AuthorsNo == newAuthors.AuthorsNo);

                oldAuthors.MaterialsID = newAuthors.MaterialsID;
                oldAuthors.AuthorsCName = newAuthors.AuthorsCName;
                oldAuthors.AuthorsEName = newAuthors.AuthorsEName;
                oldAuthors.ModifyUser = newAuthors.ModifyUser;
                oldAuthors.ModifyDate = DateTime.Now;

                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Delete
        public bool Delete(int authorNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var author = context.Authors.FirstOrDefault(x => x.AuthorsNo == authorNo);
                if (author == null)
                {
                    return false;
                }

                context.Authors.Remove(author);
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

    public partial class AuthorsModelMetaData
    {
        #region Properties
        [Required]
        public int AuthorsNo { get; set; }

        public string MaterialsID { get; set; }

        [Required]
        [DisplayName("藝術家名稱")]
        public string AuthorsCName { get; set; }

        [Required]
        [DisplayName("藝術家英文名稱")]
        public string AuthorsEName { get; set; }

        [Required]
        public string CreateUser { get; set; }

        [Required]
        public System.DateTime CreateDate { get; set; }

        [Required]
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        #endregion
    }
}