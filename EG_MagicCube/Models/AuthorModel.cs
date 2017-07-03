using EG_MagicCube.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models
{
    [MetadataType(typeof(AuthorModelMetaData))]
    public partial class AuthorModel : Author_List
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
                context.Author_List.Add(this);
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
        public IQueryable<Author_List> All()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Author_List;
            }
        }

        /// <summary>
        /// 以藝術家編號取得藝術家
        /// </summary>
        /// <param name="authorNo">藝術家編號</param>
        /// <returns></returns>
        public Author_List GetAuthorByAuthorNo(int authorNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Author_List.FirstOrDefault(x => x.Author_No == authorNo);
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// 以新藝術家資料更新
        /// </summary>
        /// <param name="newAuthor">新藝術家資料</param>
        /// <returns></returns>
        public bool Update(AuthorModel newAuthor)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var oldAuthor = context.Author_List.First(x => x.Author_No == newAuthor.Author_No);

                oldAuthor.Materials_ID = newAuthor.Materials_ID;
                oldAuthor.AuthorCName = newAuthor.AuthorCName;
                oldAuthor.AuthorEName = newAuthor.AuthorEName;
                oldAuthor.ModifyUser = newAuthor.ModifyUser;
                oldAuthor.ModifyDate = DateTime.Now;

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
                var author = context.Author_List.FirstOrDefault(x => x.Author_No == authorNo);
                if (author == null)
                {
                    return false;
                }

                context.Author_List.Remove(author);
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

    public partial class AuthorModelMetaData
    {
        #region Properties
        [Required]
        public int Author_No { get; set; }

        public string Materials_ID { get; set; }

        [Required]
        [DisplayName("藝術家名稱")]
        public string AuthorCName { get; set; }

        [Required]
        [DisplayName("藝術家英文名稱")]
        public string AuthorEName { get; set; }

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