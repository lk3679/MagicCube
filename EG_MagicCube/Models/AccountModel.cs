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
    public partial class AccountModel
    {
        /// <summary>
        /// 帳號序號
        /// </summary>
        public int UserAccountsNo { get; set; } = 0;

        /// <summary>
        /// 帳號
        /// </summary>
        [Required(ErrorMessage ="請輸入帳號")]
        [Display(Name = "帳號", Prompt = "請輸入帳號")]
        public string UserAccount { get; set; } = "";

        /// <summary>
        /// 密碼
        /// </summary>
        [Display(Name = "密碼", Prompt = "請輸入長度8 - 16的密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "請輸入長度8-16的密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        /// <summary>
        /// 密碼確認
        /// </summary>
        [Required(ErrorMessage = "請輸入密碼確認")]
        [Display(Name ="密碼確認", Prompt = "請再次輸入密碼")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "密碼與確認密碼不符")]
        public string Password_Confirm { get; set; } = "";
        /// <summary>
        /// 密碼金鑰
        /// </summary>
        private string Pwdself { get; set; } = "";
        /// <summary>
        /// 名稱
        /// </summary>
        [Required(ErrorMessage = "請輸入名稱")]
        [Display(Name = "名稱", Prompt = "請輸入名稱")]
        public string Name { get; set; } = "";
        /// <summary>
        /// 權限
        /// </summary>
        [Required(ErrorMessage = "請選擇權限")]
        [DisplayName("權限")]
        public int RoleNo { get; set; } = 0;
        /// <summary>
        /// 帳號狀態
        /// </summary>
        public string AccountStatus { get; set; } = "";
        /// <summary>
        /// 備註
        /// </summary>
        public string AccountNote { get; set; } = "";
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;
        /// <summary>
        /// 建立者
        /// </summary>
        public string CreateUser { get; set; } = "";
        /// <summary>
        /// 修改者
        /// </summary>
        public string ModifyUser { get; set; } = "";
        /// <summary>
        /// 修改時間
        /// </summary>
        public DateTime ModifyDate { get; set; } = DateTime.Now;

        #region Create
        /// <summary>
        /// 新增帳號
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                UserAccounts _UserAccounts = new UserAccounts();
                _UserAccounts.UserAccount = this.UserAccount;
                _UserAccounts.Name = this.Name;
                
                PasswordHandler _PasswordHandler = new PasswordHandler(this.Password);

                _UserAccounts.Password = this.Password = _PasswordHandler.EnStrPw;
                _UserAccounts.Pwdself = this.Pwdself = _PasswordHandler.SaltKey;
                _UserAccounts.RoleNo = this.RoleNo;
                _UserAccounts.AccountStatus = this.AccountStatus;
                _UserAccounts.AccountNote = this.AccountNote;
                _UserAccounts.CreateDate = DateTime.Now;
                _UserAccounts.CreateUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                _UserAccounts.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                _UserAccounts.ModifyDate = DateTime.Now;
                _UserAccounts.IsDel = "";
                context.UserAccounts.Add(_UserAccounts);
                if (context.SaveChanges() == 0)
                {
                    this.UserAccountsNo = _UserAccounts.UserAccountsNo;
                    return false;
                }
            }
            return true;
        }
        public AccountModel CreateAndReturn()
        {
            AccountModel _AccountModel = new AccountModel();
            if (this.Create())
            {
                _AccountModel = GetAccountModelDetail(this.UserAccountsNo.ToString());
            }
            return _AccountModel;
        }

        #endregion

        #region Read
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="strAccount">帳號</param>
        /// <param name="strPwd">密碼</param>
        /// <param name="IsAccount">帳號是否存在</param>
        /// <param name="IsPwd">帳號是否正確</param>
        /// <returns></returns>
        public static AccountModel Login(string strAccount,string strPwd,out bool IsAccount, out bool IsPwd)
        {
            IsPwd = false;
            IsAccount = true;
            AccountModel _AccountModel = null;
            using (var context = new EG_MagicCubeEntities())
            {
                var UserAccount = context.UserAccounts?.AsQueryable()?.FirstOrDefault(c => c.IsDel!="Y" && c.UserAccount == strAccount);

                if (UserAccount != null)
                {
                    IsPwd = PasswordHandler.CompareEncryptHashString(strPwd, UserAccount.Pwdself, UserAccount.Password);
                    if (IsPwd)
                    {
                        _AccountModel = new AccountModel()
                        {
                            UserAccountsNo = UserAccount.UserAccountsNo,
                            Name = UserAccount.Name,
                            UserAccount = UserAccount.UserAccount,
                            Password = UserAccount.Password,
                            Password_Confirm = UserAccount.Password,
                            Pwdself = UserAccount.Pwdself,

                            AccountStatus = UserAccount.AccountStatus,
                            AccountNote = UserAccount.AccountNote,
                            RoleNo = UserAccount.RoleNo,
                            CreateDate = UserAccount.CreateDate,
                            CreateUser = UserAccount.CreateUser,
                            ModifyDate = UserAccount.ModifyDate.Value,
                            ModifyUser = UserAccount.ModifyUser
                        };
                    }
                    IsAccount = true;
                }
                else
                {
                    IsAccount = false;
                }


            }

            return _AccountModel;
        }


        /// <summary>
        /// 取得帳號明細
        /// </summary>
        /// <param name="UserAccountsNo"></param>
        /// <returns></returns>
        public static AccountModel GetAccountModelDetail(string UserAccountsNo)
        {
            AccountModel _AccountModel = new AccountModel();
            int int_UserAccountsNo = int.Parse(UserAccountsNo);
            using (var context = new EG_MagicCubeEntities())
            {
                if (context.UserAccounts.Count() > 0)
                {
                    _AccountModel = context.UserAccounts.AsEnumerable().Where(c => c.IsDel!="Y" && c.UserAccountsNo == int_UserAccountsNo).Select(c =>
                    new AccountModel()
                    {
                        UserAccountsNo = c.UserAccountsNo,
                        Name = c.Name,
                        UserAccount = c.UserAccount,
                        Password = c.Password,
                        Password_Confirm = c.Password,
                        Pwdself = c.Password,
                        
                        AccountStatus = c.AccountStatus,
                        AccountNote = c.AccountNote,
                        RoleNo = c.RoleNo,
                        CreateDate = c.CreateDate,
                        CreateUser = c.CreateUser,
                        ModifyDate = c.ModifyDate.Value,
                        ModifyUser = c.ModifyUser
                    }).FirstOrDefault();
                }
            }
            return _AccountModel;
        }

        /// <summary>
        /// 取得帳號清單
        /// </summary>
        /// <param name="KeyWords">帳號、名稱關鍵字</param>
        /// <param name="PageIndex">頁碼，從1開始0為不分頁</param>
        /// <param name="PageSize">每頁筆數，0為不分頁</param>
        /// <param name="OrderbyType">排序方式</param>
        /// <returns></returns>
        public static List<AccountModel> GetAccountList(string KeyWords = "", int PageIndex = 0, int PageSize = 0, MenuModel.MeunOrderbyTypeEnum OrderbyType = MenuModel.MeunOrderbyTypeEnum.預設排序)
        {
            List<AccountModel> _AccountModelList = new List<AccountModel>();
            using (var context = new EG_MagicCubeEntities())
            {
                if (context.UserAccounts.Count() > 0)
                {
                    var uas = context.UserAccounts.AsQueryable().Where(c => c.IsDel != "Y" && (c.Name.Contains(KeyWords) || c.UserAccount.Contains(KeyWords))).Select(c =>c);

                    if (MenuModel.MeunOrderbyTypeEnum.預設排序 == OrderbyType)
                    {
                        uas = uas.OrderByDescending(c => c.UserAccountsNo);
                    }
                    else
                      if (MenuModel.MeunOrderbyTypeEnum.建立時間由舊至新 == OrderbyType)
                    {
                        uas = uas.OrderBy(c => c.CreateDate);
                    }
                    else
                      if (MenuModel.MeunOrderbyTypeEnum.建立時間由新至舊 == OrderbyType)
                    {
                        uas = uas.OrderByDescending(c => c.CreateDate);
                    }
                    else
                      if (MenuModel.MeunOrderbyTypeEnum.修改時間由舊至新 == OrderbyType)
                    {
                        uas = uas.OrderBy(c => c.ModifyDate);
                    }
                    else
                      if (MenuModel.MeunOrderbyTypeEnum.修改時間由新至舊 == OrderbyType)
                    {
                        uas = uas.OrderByDescending(c => c.ModifyDate);
                    }
                    else
                      if (MenuModel.MeunOrderbyTypeEnum.名稱姓名小至大 == OrderbyType)
                    {
                        uas = uas.OrderBy(c => c.UserAccount);
                    }
                    else
                      if (MenuModel.MeunOrderbyTypeEnum.名稱姓名大至小 == OrderbyType)
                    {
                        uas = uas.OrderByDescending(c => c.UserAccount);
                    }
                    else
                    {
                        uas = uas.OrderByDescending(c => c.UserAccountsNo);
                    }
                    if (PageIndex > 0 && PageIndex > 0)
                    {
                        uas = uas.Select(c => c).Skip((PageIndex * PageSize - PageSize)).Take(PageSize+1);
                    }
                    var r_uas = uas.ToList();

                    _AccountModelList = r_uas.AsEnumerable().Select(c =>
                    new AccountModel()
                    {
                        UserAccountsNo = c.UserAccountsNo,
                        UserAccount = c.UserAccount,
                        Name = c.Name,
                        Password = c.Password,
                        Password_Confirm = c.Password,
                        Pwdself = c.Password,
                        AccountStatus = c.AccountStatus,
                        AccountNote = c.AccountNote,
                        RoleNo = c.RoleNo,
                        CreateDate = c.CreateDate,
                        CreateUser = c.CreateUser,
                        ModifyDate = c.ModifyDate.Value,
                        ModifyUser = c.ModifyUser
                    }).ToList();
                }
            }
            return _AccountModelList;
        }


        #endregion

        #region Update
        /// <summary>
        /// 帳號資料更新
        /// </summary>
        /// <param name="newPackages">新帳號資料</param>
        /// <returns></returns>
        public static bool Update(AccountModel newAccountModel)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var oldUserAccount = context.UserAccounts.First(x => x.UserAccountsNo == newAccountModel.UserAccountsNo);
                if (newAccountModel.Password != "nopwdnopwd" && newAccountModel.Password_Confirm != "nopwdnopwd")
                {
                    if (oldUserAccount.Password != newAccountModel.Password)
                    {
                        PasswordHandler _PasswordHandler = new PasswordHandler(newAccountModel.Password);
                        oldUserAccount.Password = _PasswordHandler.EnStrPw;
                        oldUserAccount.Pwdself = _PasswordHandler.SaltKey;
                    }
                }

                oldUserAccount.UserAccount = newAccountModel.UserAccount;
                oldUserAccount.Name = newAccountModel.Name;
                oldUserAccount.RoleNo = newAccountModel.RoleNo;
                oldUserAccount.AccountNote = newAccountModel.AccountNote;
                oldUserAccount.AccountStatus = newAccountModel.AccountStatus;
                oldUserAccount.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                oldUserAccount.ModifyDate = DateTime.Now;

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
        public static bool Delete(int UserAccountsNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var UserAccount = context.UserAccounts.FirstOrDefault(x => x.UserAccountsNo == UserAccountsNo);
                if (UserAccount != null)
                {
                    UserAccount.IsDel = "Y";
                    UserAccount.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                    UserAccount.ModifyDate = DateTime.Now;
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
            return Delete(this.UserAccountsNo);
        }
        #endregion

    }
    /// <summary>
    /// 密碼加密及比較
    /// </summary>
    public partial class PasswordHandler
    {
        private static string HashType = "SHA1";
        private string _EnStrPw = "";
        private string _SaltKey = "";

        public string EnStrPw { get { return _EnStrPw; } }
        public string SaltKey { get { return _SaltKey; } }
        public PasswordHandler(string StrPwd)
        {
            _EnStrPw = GenerateSalt();
            _SaltKey = EncryptToHashString(StrPwd, SaltKey);
        }
        /// <summary>
        /// 產生哈希密碼金鑰
        /// </summary>
        /// <returns></returns>
        protected static string GenerateSalt()
        {
            byte[] data = new byte[256];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(data);
            return Convert.ToBase64String(data);
        }
        /// <summary>  
        /// 哈希密碼加密(不可還原)  
        /// </summary>  
        /// <param name="StrPwd">原始字串</param>  
        /// <param name="SaltKey">Salt加密字串</param>  
        protected static string EncryptToHashString(string StrPwd, string SaltKey)
        {
            byte[] src = System.Text.Encoding.Unicode.GetBytes(StrPwd);
            byte[] saltbuf = Convert.FromBase64String(SaltKey);
            byte[] dst = new byte[saltbuf.Length + src.Length];
            byte[] inArray = null;
            System.Buffer.BlockCopy(saltbuf, 0, dst, 0, saltbuf.Length);
            System.Buffer.BlockCopy(src, 0, dst, saltbuf.Length, src.Length);

            System.Security.Cryptography.HashAlgorithm algorithm = System.Security.Cryptography.HashAlgorithm.Create(HashType);
            inArray = algorithm.ComputeHash(dst);

            return Convert.ToBase64String(inArray);
        }

        /// <summary>  
        /// 比較加密哈希密碼
        /// </summary>  
        /// <param name="StrPwd">原始字串</param>  
        /// <param name="saltKey">Salt加密字串</param>  
        /// <param name="EncryptHashString">已加密哈希密碼字串</param>  
        public static bool CompareEncryptHashString(string StrPwd, string saltKey, string EncryptHashString)
        {
            byte[] src = System.Text.Encoding.Unicode.GetBytes(StrPwd);
            byte[] saltbuf = Convert.FromBase64String(saltKey);
            byte[] dst = new byte[saltbuf.Length + src.Length];
            byte[] inArray = null;
            System.Buffer.BlockCopy(saltbuf, 0, dst, 0, saltbuf.Length);
            System.Buffer.BlockCopy(src, 0, dst, saltbuf.Length, src.Length);

            System.Security.Cryptography.HashAlgorithm algorithm = System.Security.Cryptography.HashAlgorithm.Create(HashType);
            inArray = algorithm.ComputeHash(dst);

            return (Convert.ToBase64String(inArray) == EncryptHashString);
        }
    }
}