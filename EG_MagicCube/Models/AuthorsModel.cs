using EG_MagicCubeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EG_MagicCube.Models
{
    public partial class AuthorsModel 
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
                //context.Authors.Add(this);
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
        public List<Authors> All()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.Authors.ToList();
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
                //var oldAuthors = context.Authors.First(x => x.AuthorsNo == newAuthors.);

                //oldAuthors.MaterialsID = newAuthors.MaterialsID;
                //oldAuthors.AuthorsCName = newAuthors.AuthorsCName;
                //oldAuthors.AuthorsEName = newAuthors.AuthorsEName;
                //oldAuthors.ModifyUser = newAuthors.ModifyUser;
                //oldAuthors.ModifyDate = DateTime.Now;

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
}