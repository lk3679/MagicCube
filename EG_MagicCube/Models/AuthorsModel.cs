using EG_MagicCubeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Security;
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
        /// 藝術家中文姓名
        /// </summary>
        [Display(Name = "藝術家中文姓名", Prompt = "藝術家中文姓名")]
        public string AuthorsCName { get; set; } = "";
        /// <summary>
        /// 藝術家外文姓名
        /// </summary>
        [Display(Name = "藝術家外文姓名", Prompt = "藝術家外文姓名")]
        public string AuthorsEName { get; set; } = "";
        /// <summary>
        /// 建立者
        /// </summary>
        [Display(Name = "建立者")]
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
        /// <summary>
        /// 作品數量
        /// </summary>
        [DisplayName("作品數量")]
        public int WorksAmount { get; set; } = 0;
        /// <summary>
        /// 作品數量分級
        /// </summary>
        [DisplayName("作品數量分級")]
        public string Rating { get; set; } = "";

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
                _Authors.AuthorsCName = this.AuthorsCName ?? "";
                _Authors.AuthorsEName = this.AuthorsEName ?? "";
                _Authors.CreateDate = DateTime.Now;
                _Authors.CreateUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                _Authors.ModifyDate = DateTime.Now;
                _Authors.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                _Authors.MaterialsID = "";
                _Authors.IsDel = "";
                _Authors.Rating = this.Rating ?? "";
                _Authors.WorksAmount = this.WorksAmount;
                context.Authors.Add(_Authors);
                if (context.SaveChanges() > 0)
                {
                    this.AuthorsNo = _Authors.AuthorsNo;
                    if (this.AuthorsAreaNo_InputString.Count > 0)
                    {
                        foreach (int _AuthorsAreaNo in this.AuthorsAreaNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                        {
                            context.AuthorsPropArea.Add(new AuthorsPropArea() { AuthorsNo = this.AuthorsNo, AuthorsAreaNo = _AuthorsAreaNo });
                        }
                    }
                    if (this.AuthorsTagNo_InputString.Count > 0)
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
                _AuthorsModel = this;
            }
            return _AuthorsModel;
        }
        #endregion

        #region Read
        /// <summary>
        /// 取得藝術家清單
        /// </summary>
        /// <param name="KeyWords">藝術家名稱關鍵字</param>
        /// <param name="PageIndex">頁碼，從1開始0為不分頁</param>
        /// <param name="PageSize">每頁筆數，0為不分頁</param>
        /// <param name="OrderbyType">排序方式</param>
        /// <returns></returns>
        public static List<AuthorsModel> GetAuthorList(string KeyWords = "", int PageIndex = 0, int PageSize = 0, MenuModel.MeunOrderbyTypeEnum OrderbyType = MenuModel.MeunOrderbyTypeEnum.預設排序)
        {
            if (string.IsNullOrEmpty(KeyWords)) KeyWords = "";

            List<AuthorsModel> _AuthorsModel = new List<AuthorsModel>();
            using (var context = new EG_MagicCubeEntities())
            {
                var atrs = context?.Authors?.AsQueryable()?.Where(c => c.IsDel != "Y");

                if (MenuModel.MeunOrderbyTypeEnum.預設排序 == OrderbyType)
                {
                    atrs = atrs.OrderByDescending(c => c.AuthorsNo);
                }
                else if (MenuModel.MeunOrderbyTypeEnum.建立時間由舊至新 == OrderbyType)
                {
                    atrs = atrs.OrderBy(c => c.CreateDate);
                }
                else if (MenuModel.MeunOrderbyTypeEnum.建立時間由新至舊 == OrderbyType)
                {
                    atrs = atrs.OrderByDescending(c => c.CreateDate);
                }
                else if (MenuModel.MeunOrderbyTypeEnum.修改時間由舊至新 == OrderbyType)
                {
                    atrs = atrs.OrderBy(c => c.ModifyDate);
                }
                else if (MenuModel.MeunOrderbyTypeEnum.修改時間由新至舊 == OrderbyType)
                {
                    atrs = atrs.OrderByDescending(c => c.ModifyDate);
                }
                else if (MenuModel.MeunOrderbyTypeEnum.名稱姓名小至大 == OrderbyType)
                {
                    atrs = atrs.OrderBy(c => c.AuthorsCName).ThenBy(c => c.AuthorsEName);
                }
                else if (MenuModel.MeunOrderbyTypeEnum.名稱姓名大至小 == OrderbyType)
                {
                    atrs = atrs.OrderByDescending(c => c.AuthorsCName).ThenByDescending(c => c.AuthorsEName);
                }
                else
                {
                    atrs = atrs.OrderByDescending(c => c.AuthorsNo);
                }
                if (PageIndex > 0 && PageIndex > 0)
                {
                    atrs = atrs.Skip(((PageIndex * PageSize) - PageSize)).Take(PageSize + 1);
                }
                var r_atrs = atrs.Select(c => c).ToList();
                if (r_atrs != null && r_atrs.Count > 0)
                {
                    int[] AuthorArray = r_atrs.Select(c => c.AuthorsNo).ToArray();
                    var r_AuthorsPropArea = context?.AuthorsPropArea?.AsQueryable()?.Where(apa => AuthorArray.Contains(apa.AuthorsNo)).ToList();
                    var r_AuthorsPropTag = context?.AuthorsPropTag?.AsQueryable()?.Where(apt => AuthorArray.Contains(apt.AuthorsNo)).ToList();

                    _AuthorsModel = r_atrs?.AsEnumerable().Select(c =>
                     new AuthorsModel
                     {
                         AuthorsNo = c.AuthorsNo,
                         AuthorsCName = c.AuthorsCName,
                         AuthorsEName = c.AuthorsEName,
                         AuthorsAreaNo_InputString = r_AuthorsPropArea?.Where(apa => apa.AuthorsNo == c.AuthorsNo).Select(apa => Convert.ToString(apa.AuthorsAreaNo)).ToList(),
                         AuthorsTagNo_InputString = r_AuthorsPropTag?.Where(apt => apt.AuthorsNo == c.AuthorsNo).Select(apt => Convert.ToString(apt.AuthorsTagNo)).ToList(),
                         AuthorsPropArea = r_AuthorsPropArea?.Where(apa => apa.AuthorsNo == c.AuthorsNo).Select(apa =>
                         new MenuViewModel() { MenuID = apa.Menu_AuthorsArea.AuthorsAreaNo, MenuName = apa.Menu_AuthorsArea.AuthorsAreaName }).ToList(),
                         AuthorsPropTag = r_AuthorsPropTag?.Where(apt => apt.AuthorsNo == c.AuthorsNo).Select(apa =>
                                             new MenuViewModel() { MenuID = apa.Menu_AuthorsTag.AuthorsTagNo, MenuName = apa.Menu_AuthorsTag.AuthorsTagName }).ToList(),
                         CreateDate = c.CreateDate,
                         MaterialsID = c.MaterialsID,
                         CreateUser = c.CreateUser,
                         ModifyDate = c.ModifyDate.Value,
                         ModifyUser = c.ModifyUser
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
                    var r_Authors = context?.Authors?.AsQueryable()?.Where(c => c.IsDel != "Y" && c.AuthorsNo == authorsNo).Select(c => c).FirstOrDefault();


                    if (r_Authors != null)
                    {
                        var r_AuthorsPropArea = context?.AuthorsPropArea?.AsQueryable()?.Where(c => c.AuthorsNo == r_Authors.AuthorsNo).ToList();
                        var r_AuthorsPropTag = context?.AuthorsPropTag?.AsQueryable()?.Where(c => c.AuthorsNo == r_Authors.AuthorsNo).ToList();
                        int _WorksAmount = (context?.WorksAuthors?.AsQueryable()?.Where(c => c.Author_No == r_Authors.AuthorsNo).Count()).Value;
                        _AuthorsModel.AuthorsNo = r_Authors.AuthorsNo;
                        _AuthorsModel.AuthorsCName = r_Authors.AuthorsCName;
                        _AuthorsModel.AuthorsEName = r_Authors.AuthorsEName;

                        if (r_AuthorsPropArea != null && r_AuthorsPropArea.Count > 0)
                        {
                            _AuthorsModel.AuthorsAreaNo_InputString = r_AuthorsPropArea.Select(apa => Convert.ToString(apa.AuthorsAreaNo)).ToList();
                            _AuthorsModel.AuthorsPropArea = r_AuthorsPropArea.Select(apa =>
                        new MenuViewModel() { MenuID = apa.Menu_AuthorsArea.AuthorsAreaNo, MenuName = apa.Menu_AuthorsArea.AuthorsAreaName }).ToList();
                        }
                        if (r_AuthorsPropTag != null && r_AuthorsPropTag.Count > 0)
                        {
                            _AuthorsModel.AuthorsTagNo_InputString = r_AuthorsPropTag.Select(apt => Convert.ToString(apt.AuthorsTagNo)).ToList();
                            _AuthorsModel.AuthorsPropTag = r_AuthorsPropTag.Select(apa =>
                         new MenuViewModel() { MenuID = apa.Menu_AuthorsTag.AuthorsTagNo, MenuName = apa.Menu_AuthorsTag.AuthorsTagName }).ToList();
                        }
                        _AuthorsModel.CreateDate = r_Authors.CreateDate;
                        _AuthorsModel.MaterialsID = r_Authors.MaterialsID;
                        _AuthorsModel.CreateUser = r_Authors.CreateUser;
                        _AuthorsModel.ModifyDate = r_Authors.ModifyDate.Value;
                        _AuthorsModel.ModifyUser = r_Authors.ModifyUser;
                        _AuthorsModel.WorksAmount = r_Authors.WorksAmount;
                        _AuthorsModel.Rating = r_Authors.Rating;
                    }
                }
            }

            return _AuthorsModel;
        }
        #endregion
        /// <summary>
        /// 計算數量等級
        /// </summary>
        /// <param name="_WorksAmount"></param>
        /// <returns></returns>
        public static int CalculateAuthorsRating(int _WorksAmount)
        {
            int _Rating = 0;
            if (_WorksAmount >= 1 && _WorksAmount <= 10)
            {
                _Rating = 1;
            }
            if (_WorksAmount >= 11 && _WorksAmount <= 20)
            {
                _Rating = 2;
            }
            if (_WorksAmount >= 21 && _WorksAmount <= 30)
            {
                _Rating = 3;
            }
            if (_WorksAmount >= 31 && _WorksAmount <= 40)
            {
                _Rating = 4;
            }
            if (_WorksAmount >= 41 && _WorksAmount < 40)
            {
                _Rating = 5;
            }
            return _Rating;
        }
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
                var oldAuthors = context.Authors.AsQueryable().First(x => x.AuthorsNo == newAuthors.AuthorsNo);

                if (oldAuthors.AuthorsPropArea != null)
                {
                    foreach (AuthorsPropArea _AuthorsPropArea in oldAuthors.AuthorsPropArea.ToList())
                    {
                        var del_AuthorsPropArea = context.AuthorsPropArea.AsQueryable().FirstOrDefault(c => c.AuthorsPropAreaNo == _AuthorsPropArea.AuthorsPropAreaNo);
                        context.AuthorsPropArea.Remove(del_AuthorsPropArea);
                    }
                }
                if (oldAuthors.AuthorsPropTag != null)
                {
                    foreach (AuthorsPropTag _AuthorsPropTag in oldAuthors.AuthorsPropTag.ToList())
                    {
                        var del_del_AuthorsPropTag = context.AuthorsPropTag.AsQueryable().FirstOrDefault(c => c.AuthorsPropTagNo == _AuthorsPropTag.AuthorsPropTagNo);
                        context.AuthorsPropTag.Remove(del_del_AuthorsPropTag);
                    }
                }

                if (oldAuthors != null)
                {
                    oldAuthors.MaterialsID = newAuthors.MaterialsID ?? "";
                    oldAuthors.AuthorsCName = newAuthors.AuthorsCName ?? "";
                    oldAuthors.AuthorsEName = newAuthors.AuthorsEName ?? "";
                    oldAuthors.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                    oldAuthors.ModifyDate = DateTime.Now;
                    oldAuthors.Rating = newAuthors.Rating ?? "";
                    oldAuthors.WorksAmount = newAuthors.WorksAmount;
                }
                if (newAuthors.AuthorsAreaNo_InputString.Count > 0)
                {
                    foreach (int _AuthorsAreaNo in newAuthors.AuthorsAreaNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.AuthorsPropArea.Add(new AuthorsPropArea() { AuthorsNo = newAuthors.AuthorsNo, AuthorsAreaNo = _AuthorsAreaNo });
                    }
                }
                if (newAuthors.AuthorsTagNo_InputString.Count > 0)
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
        public static bool Delete(int authorNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var author = context.Authors.FirstOrDefault(x => x.AuthorsNo == authorNo);
                if (author != null)
                {
                    author.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                    author.ModifyDate = DateTime.Now;
                    author.IsDel = "Y";
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
        public bool Delete()
        {
            return Delete(this.AuthorsNo);
        }
        #endregion

        #endregion
    }
}