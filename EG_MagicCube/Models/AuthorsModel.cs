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
        [Display(Name = "藝術家中文名稱", Prompt = "藝術家中文名稱")]
        public string AuthorsCName { get; set; } = "";
        /// <summary>
        /// 藝術家外文名稱
        /// </summary>
        [Display(Name = "藝術家外文名稱", Prompt = "藝術家外文名稱")]
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
        /// <summary>
        /// 藝術家區域
        /// </summary>
        [DisplayName("藝術家區域")]
        public List<MenuViewModel> AuthorsPropArea { get; set; }
        /// <summary>
        /// 新增修改藝術家區域清單字串，用,分隔
        /// </summary>
        [DisplayName("新增修改藝術家區域清單字串")]
        public List<string> AuthorsAreaNo_InputString { get; set; } = new List<string>();
        /// <summary>
        /// 藝術家標籤
        /// </summary>
        [DisplayName("藝術家標籤")]
        public List<MenuViewModel> AuthorsPropTag { get; set; }
        /// <summary>
        /// 新增修改藝術家標籤清單字串，用,分隔
        /// </summary>
        [DisplayName("新增修改藝術家標籤清單字串")]
        public List<string> AuthorsTagNo_InputString { get; set; } = new List<string>();
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
                Authors _Authors = new Authors();
                _Authors.AuthorsCName = this.AuthorsCName;
                _Authors.AuthorsEName = this.AuthorsEName;
                _Authors.CreateDate = DateTime.Now;
                _Authors.CreateUser = "";
                _Authors.ModifyDate = DateTime.Now;
                _Authors.ModifyUser = "";
                _Authors.MaterialsID = "";
                context.Authors.Add(_Authors);
                if (context.SaveChanges() > 0)
                {
                    this.AuthorsNo = _Authors.AuthorsNo;
                    if (this.AuthorsAreaNo_InputString.Count>0)
                    {
                        foreach (int _AuthorsAreaNo in this.AuthorsAreaNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                        {
                            context.AuthorsPropArea.Add(new AuthorsPropArea() { AuthorsNo = this.AuthorsNo, AuthorsAreaNo = _AuthorsAreaNo });
                        }
                    }
                    if (this.AuthorsTagNo_InputString.Count>0)
                    {
                        foreach (int _AuthorsTagNo in this.AuthorsTagNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                        {
                            context.AuthorsPropTag.Add(new AuthorsPropTag() { AuthorsNo = this.AuthorsNo, AuthorsTagNo = _AuthorsTagNo });
                        }
                    }
                    if (context.SaveChanges() == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public AuthorsModel CreateAndReturn()
        {
            AuthorsModel _AuthorsModel = new AuthorsModel();
            if (this.Create())
            {
                _AuthorsModel =this;
            }
            return _AuthorsModel;
        }
        #endregion

        #region Read
        /// <summary>
        /// 取得藝術家清單
        /// </summary>
        public static List<AuthorsModel> GetAuthorList(string KeyWords = "", int PageIndex = 1, int PageSize = 10)
        {
            if (string.IsNullOrEmpty(KeyWords)) KeyWords = "";

            List<AuthorsModel> _AuthorsModel = new List<AuthorsModel>();
            using (var context = new EG_MagicCubeEntities())
            {
                if (context.Authors.Count() > 0)
                {
                    _AuthorsModel = context.Authors.AsEnumerable().Where(c=> c.AuthorsCName.Contains(KeyWords) || c.AuthorsCName.Contains(KeyWords)).Select(c =>
                    new AuthorsModel
                    {
                        AuthorsNo = c.AuthorsNo,
                        AuthorsCName = c.AuthorsCName,
                        AuthorsEName = c.AuthorsEName,
                        AuthorsAreaNo_InputString = c.AuthorsPropArea.Select(apa => Convert.ToString(apa.AuthorsAreaNo)).ToList(),
                        AuthorsTagNo_InputString = c.AuthorsPropTag.Select(apt => Convert.ToString(apt.AuthorsTagNo)).ToList(),
                        AuthorsPropArea = c.AuthorsPropArea.Select(apa => 
                        new MenuViewModel() { MenuID = apa.Menu_AuthorsArea.AuthorsAreaNo, MenuName = apa.Menu_AuthorsArea.AuthorsAreaName }).ToList(),
                        AuthorsPropTag= c.AuthorsPropTag.Select(apa =>
                        new MenuViewModel() { MenuID = apa.Menu_AuthorsTag.AuthorsTagNo, MenuName = apa.Menu_AuthorsTag.AuthorsTagName }).ToList(),
                        CreateDate=c.CreateDate,
                        MaterialsID =c.MaterialsID,
                        CreateUser =c.CreateUser,
                        ModifyDate =c.ModifyDate.Value,
                        ModifyUser =c.ModifyUser
                    }).ToList();

                }
            }
            return _AuthorsModel;
        }

        /// <summary>
        /// 以藝術家編號取得藝術家
        /// </summary>
        /// <param name="authorsNo">藝術家編號</param>
        /// <returns></returns>
        public static AuthorsModel GetAuthorDetail(int authorsNo)
        {
            AuthorsModel _AuthorsModel = new AuthorsModel();
            using (var context = new EG_MagicCubeEntities())
            {
                if (context.Authors.Count() > 0)
                {
                    _AuthorsModel = context.Authors.AsEnumerable().Where(c => c.AuthorsNo == authorsNo).Select(c => new AuthorsModel()
                    {
                        AuthorsNo = c.AuthorsNo,
                        AuthorsCName = c.AuthorsCName,
                        AuthorsEName = c.AuthorsEName,
                        AuthorsAreaNo_InputString = c.AuthorsPropArea.Select(apa => Convert.ToString(apa.AuthorsAreaNo)).ToList(),
                        AuthorsTagNo_InputString = c.AuthorsPropTag.Select(apt => Convert.ToString(apt.AuthorsTagNo)).ToList(),
                        AuthorsPropArea = c.AuthorsPropArea.Select(apa =>
                        new MenuViewModel() { MenuID = apa.Menu_AuthorsArea.AuthorsAreaNo, MenuName = apa.Menu_AuthorsArea.AuthorsAreaName }).ToList(),
                        AuthorsPropTag = c.AuthorsPropTag.Select(apa =>
                         new MenuViewModel() { MenuID = apa.Menu_AuthorsTag.AuthorsTagNo, MenuName = apa.Menu_AuthorsTag.AuthorsTagName }).ToList(),
                        CreateDate = c.CreateDate,
                        MaterialsID = c.MaterialsID,
                        CreateUser = c.CreateUser,
                        ModifyDate = c.ModifyDate.HasValue ? c.ModifyDate.Value:DateTime.MinValue,
                        ModifyUser = c.ModifyUser
                    }).FirstOrDefault();
                }
            }

            return _AuthorsModel;
        }
        #endregion

        #region Update
        /// <summary>
        /// 以新藝術家資料更新
        /// </summary>
        /// <param name="newAuthors">新藝術家資料</param>
        /// <returns></returns>
        public static bool Update(AuthorsModel newAuthors)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var oldAuthors = context.Authors.AsEnumerable().First(x => x.AuthorsNo == newAuthors.AuthorsNo);

                if (oldAuthors.AuthorsPropArea != null)
                {
                    foreach (AuthorsPropArea _AuthorsPropArea in oldAuthors.AuthorsPropArea.ToList())
                    {
                        context.AuthorsPropArea.Remove(_AuthorsPropArea);
                    }
                }
                if (oldAuthors.AuthorsPropTag != null)
                {
                    foreach (AuthorsPropTag _AuthorsPropTag in oldAuthors.AuthorsPropTag.ToList())
                    {
                        context.AuthorsPropTag.Remove(_AuthorsPropTag);
                    }
                }

                if (oldAuthors != null)
                {
                    oldAuthors.MaterialsID = newAuthors.MaterialsID;
                    oldAuthors.AuthorsCName = newAuthors.AuthorsCName;
                    oldAuthors.AuthorsEName = newAuthors.AuthorsEName;
                    oldAuthors.ModifyUser = newAuthors.ModifyUser;
                    oldAuthors.ModifyDate = DateTime.Now;
                }
                if (newAuthors.AuthorsAreaNo_InputString.Count>0)
                {
                    foreach (int _AuthorsAreaNo in newAuthors.AuthorsAreaNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.AuthorsPropArea.Add(new AuthorsPropArea() { AuthorsNo = newAuthors.AuthorsNo, AuthorsAreaNo = _AuthorsAreaNo });
                    }
                }
                if (newAuthors.AuthorsTagNo_InputString.Count>0)
                {
                    foreach (int _AuthorsTagNo in newAuthors.AuthorsTagNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.AuthorsPropTag.Add(new AuthorsPropTag() { AuthorsNo = newAuthors.AuthorsNo, AuthorsTagNo = _AuthorsTagNo });
                    }
                }

                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }

            return true;
        }
        public bool Update()
        {
            return Update(this);
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
                if (author.AuthorsPropArea != null)
                {
                    foreach (AuthorsPropArea _AuthorsPropArea in author.AuthorsPropArea.ToList())
                    {
                        context.AuthorsPropArea.Remove(_AuthorsPropArea);
                    }
                }
                if (author.AuthorsPropTag != null)
                {
                    foreach (AuthorsPropTag _AuthorsPropTag in author.AuthorsPropTag.ToList())
                    {
                        context.AuthorsPropTag.Remove(_AuthorsPropTag);
                    }
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