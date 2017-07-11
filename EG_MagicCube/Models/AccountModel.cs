using EG_MagicCubeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using ImageMagick;
using EG_MagicCube.Models;

namespace EG_MagicCube.Models
{
    public partial class AccountModel
    {

        #region Create
        /// <summary>
        /// 新增包裝
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                //PasswordHandler _PasswordHandler = new PasswordHandler(this.Password);
                //this.Password = _PasswordHandler.EnStrPw;
                //this.Pwdself = _PasswordHandler.SaltKey;
                //this.RoleNo = 1;
                //context.UserAccounts.Add(this);
                //if (context.SaveChanges() == 0)
                //{
                //    return false;
                //}
            }
            return true;
        }


        #endregion

        #region Read
        /// <summary>
        /// 取得包裝
        /// </summary>
        public IQueryable<UserAccounts> All()
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.UserAccounts;
            }
        }

        /// <summary>
        /// 以包裝編號取得包裝品
        /// </summary>
        /// <param name="UserAccountsNo">包裝編號</param>
        /// <returns></returns>
        public UserAccounts GetUserAccountByUserAccountsNo(int UserAccountsNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                return context.UserAccounts.FirstOrDefault(x => x.UserAccountsNo == UserAccountsNo);
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// 帳號資料更新
        /// </summary>
        /// <param name="newPackages">新帳號資料</param>
        /// <returns></returns>
        public bool Update(UserAccounts newUserAccount)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var oldUserAccount = context.UserAccounts.First(x => x.UserAccountsNo == newUserAccount.UserAccountsNo);
                if (oldUserAccount.Password != newUserAccount.Password)
                {
                    PasswordHandler _PasswordHandler = new PasswordHandler(newUserAccount.Password);
                    oldUserAccount.Password = _PasswordHandler.EnStrPw;
                    oldUserAccount.Pwdself = _PasswordHandler.SaltKey;
                }
                oldUserAccount.Name = newUserAccount.Name;
                oldUserAccount.RoleNo = newUserAccount.RoleNo;
                oldUserAccount.AccountNote = newUserAccount.AccountNote;
                oldUserAccount.AccountStatus = newUserAccount.AccountStatus;
                oldUserAccount.ModifyUser = newUserAccount.ModifyUser;
                oldUserAccount.ModifyDate = DateTime.Now;

                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Delete
        public bool Delete(int UserAccountsNo)
        {
            using (var context = new EG_MagicCubeEntities())
            {
                var UserAccount = context.UserAccounts.FirstOrDefault(x => x.UserAccountsNo == UserAccountsNo);
                if (UserAccount == null)
                {
                    return false;
                }

                context.UserAccounts.Remove(UserAccount);
                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        //取得帳號清單
        //取得帳號
        //更新資料
        //變更密碼

        //public void chgpw()
        //{

        //    PasswordHandler _PasswordHandler = new PasswordHandler("23456789");

        //}
    }
    public partial class AccountModelMetaData
    {
        #region Properties

        [DisplayName("帳號序號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int UserAccountsNo { get; set; }

        [Required(ErrorMessage = "請輸入姓名")]
        [DisplayName("姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        [DisplayName("密碼")]
        public string Password { get; set; }

        [Required(ErrorMessage = "請輸入密碼key")]
        [DisplayName("密碼key")]
        public string Pwdself { get; set; }

        [Required(ErrorMessage = "請輸入帳號權限")]
        [DisplayName("帳號權限")]
        public int RoleNo { get; set; }

        [DisplayName("帳號狀態")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string AccountStatus { get; set; }

        [DisplayName("帳號備註")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string AccountNote { get; set; }

        [DisplayName("建立時間")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string CreateDate { get; set; }

        [Required(ErrorMessage = "請輸入建立者")]
        [DisplayName("建立者")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string CreateUser { get; set; }

        [DisplayName("修改者")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string ModifyUser { get; set; }

        [DisplayName("修改時間")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string ModifyDate { get; set; }
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
        
        public string EnStrPw { get { return _EnStrPw;  } }
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