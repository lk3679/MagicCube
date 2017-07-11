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
        /// <summary>
        /// 藝術家序號
        /// </summary>
        public int AuthorsNo { get; set; } = 0;
        /// <summary>
        /// 物料代碼
        /// </summary>
        public string MaterialsID { get; set; } = "";
        /// <summary>
        /// 藝術家中文名稱
        /// </summary>
        public string AuthorsCName { get; set; } = "";
        /// <summary>
        /// 藝術家外文名稱
        /// </summary>
        public string AuthorsEName { get; set; } = "";
        /// <summary>
        /// 建立者
        /// </summary>
        public string CreateUser { get; set; } = "";
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改者
        /// </summary>
        public string ModifyUser { get; set; } = "";
        /// <summary>
        /// 修改時間
        /// </summary>
        public DateTime ModifyDate { get; set; } = DateTime.Now;

        public List<MenuViewModel> AuthorsPropArea { get; set; }
        public List<MenuViewModel> AuthorsPropTag { get; set; }
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

        public AuthorsModel CreateAndReturn()
        {
            AuthorsModel _AuthorsModel = new AuthorsModel();
            //if (this.Create())
            //{
            //    _AuthorsModel=;
            //}
            return _AuthorsModel;
        }
        #endregion

        #region Read
        /// <summary>
        /// 取得所有藝術家
        /// </summary>
        public static List<AuthorsModel> GetAuthorList(string KeyWords = "", int PageIndex = 1, int PageSize = 10)
        {
            List<AuthorsModel> _AuthorsModel = new List<AuthorsModel>();
            using (var context = new EG_MagicCubeEntities())
            {
                //if (context.Authors.Count() > 0)
                //{
                //    _AuthorsModel=context.Authors.AsEnumerable().Where(c=> c.AuthorsCName)
                //}

                //return context.Authors.ToList();
            }
            return _AuthorsModel;
        }

        /// <summary>
        /// 以藝術家編號取得藝術家
        /// </summary>
        /// <param name="authorsNo">藝術家編號</param>
        /// <returns></returns>
        public Authors GetAuthorDetail(int authorsNo)
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