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
namespace EG_MagicCube.Models
{
    public class MenuModel
    {
        /// <summary>
        /// Menu類型
        /// </summary>
        public enum MenuClassEnum
        {
            /// <summary>
            /// 全部
            /// </summary>
            [Display(Name = "全部")]
            ALL,
            /// <summary>
            /// 藝術家區域
            /// </summary>
            [Display(Name = "藝術家區域")]
            AuthorArea,
            /// <summary>
            /// 藝術家標籤
            /// </summary>
            [Display(Name = "藝術家標籤")]
            AuthorTag,
            /// <summary>
            /// 量詞
            /// </summary>
            [Display(Name = "量詞")]
            CountNoun,
            /// <summary>
            /// 作品類型
            /// </summary>
            [Display(Name = "作品類型")]
            Genre,
            /// <summary>
            /// 作品組件媒材
            /// </summary>
            [Display(Name = "作品組件媒材")]
            Material,
            /// <summary>
            /// 作品所有人
            /// </summary>
            [Display(Name = "作品所有人")]
            Owner,
            /// <summary>
            /// 作品風格
            /// </summary>
            [Display(Name = "作品風格")]
            Style,
            /// <summary>
            /// 作品庫別
            /// </summary>
            [Display(Name = "作品庫別")]
            WareType,
            /// <summary>
            /// 帳號權限
            /// </summary>
            [Display(Name = "帳號權限")]
            AccountRole
        };

        /// <summary>
        /// 取得Menu
        /// </summary>
        /// <param name="_MenuClass"></param>
        /// <returns></returns>
        public List<MenuViewModel> GetMenu(MenuClassEnum _MenuClass)
        {
            List<MenuViewModel> _MenuViewModel = new List<MenuViewModel>();
            string MenuClassName = Enum.GetName(typeof(MenuClassEnum), _MenuClass);

            using (var context = new EG_MagicCubeEntities())
            {


                switch (_MenuClass)
                {
                    case MenuClassEnum.AuthorArea:
                        _MenuViewModel.AddRange((from f in context.Menu_AuthorsArea
                                                 select new MenuViewModel()
                                                 { MenuClass = MenuClassName, MenuID = f.AuthorsAreaNo, MenuName = f.AuthorsAreaName }).ToList());
                        break;
                    case MenuClassEnum.AuthorTag:
                        _MenuViewModel.AddRange((from f in context.Menu_AuthorsTag
                                                 select new MenuViewModel()
                                                 { MenuClass = MenuClassName, MenuID = f.AuthorsTagNo, MenuName = f.AuthorsTagName }).ToList());
                        break;
                    case MenuClassEnum.CountNoun:
                        _MenuViewModel.AddRange((from f in context.Menu_CountNoun
                                                 select new MenuViewModel()
                                                 { MenuClass = MenuClassName, MenuID = f.CountNounNo, MenuName = f.CountNounName }).ToList());
                        break;
                    case MenuClassEnum.Genre:
                        _MenuViewModel.AddRange((from f in context.Menu_Genre
                                                 select new MenuViewModel()
                                                 { MenuClass = MenuClassName, MenuID = f.GenreNo, MenuName = f.GenreName }).ToList());
                        break;
                    case MenuClassEnum.Material:
                        _MenuViewModel.AddRange((from f in context.Menu_Material
                                                 select new MenuViewModel()
                                                 { MenuClass = MenuClassName, MenuID = f.MaterialNo, MenuName = f.MaterialName }).ToList());
                        break;
                    case MenuClassEnum.Style:
                        _MenuViewModel.AddRange((from f in context.Menu_Style
                                                 select new MenuViewModel()
                                                 { MenuClass = MenuClassName, MenuID = f.StyleNo, MenuName = f.StyleName }).ToList());
                        break;
                    case MenuClassEnum.WareType:
                        _MenuViewModel.AddRange((from f in context.Menu_WareType
                                                 select new MenuViewModel()
                                                 { MenuClass = MenuClassName, MenuID = f.WareTypeNo, MenuName = f.WareTypeName }).ToList());
                        break;

                    case MenuClassEnum.Owner:
                        _MenuViewModel.AddRange((from f in context.Menu_Owner
                                                 select new MenuViewModel()
                                                 { MenuClass = MenuClassName, MenuID = f.OwnerNo, MenuName = f.OwnerName }).ToList());
                        break;
                    case MenuClassEnum.AccountRole:
                        _MenuViewModel.AddRange((from f in context.UserAccountRoles
                                                 select new MenuViewModel()
                                                 { MenuClass = MenuClassName, MenuID = f.RoleNo, MenuName = f.RoleName }).ToList());
                        break;
                }
                
            }
            return _MenuViewModel;
        }

        /// <summary>
        /// 新增Menu
        /// </summary>
        /// <param name="_MenuClass">Meun類型</param>
        /// <param name="_MenuViewModelList"></param>
        /// <returns></returns>
        public bool InsertMenu(MenuClassEnum _MenuClass, List<MenuViewModel> _MenuViewModelList)
        {
            string MenuClassName = Enum.GetName(typeof(MenuClassEnum), _MenuClass);
            using (var context = new EG_MagicCubeEntities())
            {
                switch (_MenuClass)
                {
                    case MenuClassEnum.AuthorArea:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            context.Menu_AuthorsArea.Add(new Menu_AuthorsArea() { AuthorsAreaNo = _MenuViewModel.MenuID, AuthorsAreaName = _MenuViewModel.MenuName });
                        }
                        break;
                    case MenuClassEnum.AuthorTag:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            context.Menu_AuthorsTag.Add(new Menu_AuthorsTag() { AuthorsTagNo = _MenuViewModel.MenuID, AuthorsTagName = _MenuViewModel.MenuName });
                        }
                        break;
                    case MenuClassEnum.CountNoun:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            context.Menu_CountNoun.Add(new Menu_CountNoun() { CountNounNo = _MenuViewModel.MenuID, CountNounName = _MenuViewModel.MenuName });
                        }
                        break;
                    case MenuClassEnum.Genre:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            context.Menu_Genre.Add(new Menu_Genre() { GenreNo = _MenuViewModel.MenuID, GenreName = _MenuViewModel.MenuName });
                        }
                        break;
                    case MenuClassEnum.Material:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            context.Menu_Material.Add(new Menu_Material() { MaterialNo = _MenuViewModel.MenuID, MaterialName = _MenuViewModel.MenuName });
                        }
                        break;
                    case MenuClassEnum.Style:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            context.Menu_Style.Add(new Menu_Style() { StyleNo = _MenuViewModel.MenuID, StyleName = _MenuViewModel.MenuName });
                        }
                        break;
                    case MenuClassEnum.WareType:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            context.Menu_WareType.Add(new Menu_WareType() { WareTypeNo = _MenuViewModel.MenuID, WareTypeName = _MenuViewModel.MenuName });
                        }
                        break;

                    case MenuClassEnum.Owner:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            context.Menu_Owner.Add(new Menu_Owner() { OwnerNo = _MenuViewModel.MenuID, OwnerName = _MenuViewModel.MenuName });
                        }
                        break;
                }
                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool UpdateMenu(MenuClassEnum _MenuClass,string MenuNo,string MenuName)
        {
            int _MenuNo = int.Parse(MenuNo);
            using (var context = new EG_MagicCubeEntities())
            {

                string MenuClassName = Enum.GetName(typeof(MenuClassEnum), _MenuClass);
                switch (_MenuClass)
                {
                    case MenuClassEnum.AuthorArea:
                        
                        break;
                    case MenuClassEnum.AuthorTag:

                        var AuthorTag = context.Menu_AuthorsTag.First(c => c.AuthorsTagNo == _MenuNo);
                        if(AuthorTag!=null) AuthorTag.AuthorsTagName = MenuName;

                        break;
                    case MenuClassEnum.CountNoun:

                        var CountNoun = context.Menu_CountNoun.First(c => c.CountNounNo == _MenuNo);
                        if (CountNoun != null) CountNoun.CountNounName = MenuName;

                        break;
                    case MenuClassEnum.Genre:

                        var Genre = context.Menu_Genre.First(c => c.GenreNo == _MenuNo);
                        if (Genre != null) Genre.GenreName = MenuName;

                        break;
                    case MenuClassEnum.Material:

                        var Material = context.Menu_Material.First(c => c.MaterialNo == _MenuNo);
                        if (Material != null) Material.MaterialName = MenuName;

                        break;
                    case MenuClassEnum.Style:

                        var Style = context.Menu_Style.First(c => c.StyleNo == _MenuNo);
                        if (Style != null) Style.StyleName = MenuName;

                        break;
                    case MenuClassEnum.WareType:

                        var WareType = context.Menu_WareType.First(c => c.WareTypeNo == _MenuNo);
                        if (WareType != null) WareType.WareTypeName = MenuName;

                        break;

                    case MenuClassEnum.Owner:

                        var Owner = context.Menu_Owner.First(c => c.OwnerNo == _MenuNo);
                        if (Owner != null) Owner.OwnerName = MenuName;

                        break;
                    case MenuClassEnum.AccountRole:

                        var AccountRole = context.UserAccountRoles.First(c => c.RoleNo == _MenuNo);
                        if (AccountRole != null) AccountRole.RoleName = MenuName;

                        break;
                }
                if (context.SaveChanges() == 0)
                {
                    return false;
                }

            }
            return true;
        }


        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="_MenuClass"></param>
        /// <param name="_MenuViewModelList"></param>
        /// <returns></returns>
        public static bool DeleteMenu(MenuClassEnum _MenuClass, List<MenuViewModel> _MenuViewModelList)
        {

            string MenuClassName = Enum.GetName(typeof(MenuClassEnum), _MenuClass);
            using (var context = new EG_MagicCubeEntities())
            {
                switch (_MenuClass)
                {
                    case MenuClassEnum.AuthorArea:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            var delobj = context.Menu_AuthorsArea.FirstOrDefault(x => x.AuthorsAreaNo == _MenuViewModel.MenuID);
                            if (delobj != null)
                            {
                                context.Menu_AuthorsArea.Remove(delobj);
                            }
                        }
                        break;
                    case MenuClassEnum.AuthorTag:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            var delobj = context.Menu_AuthorsTag.FirstOrDefault(x => x.AuthorsTagNo == _MenuViewModel.MenuID);
                            if (delobj != null)
                            {
                                context.Menu_AuthorsTag.Remove(delobj);
                            }
                        }
                        break;
                    case MenuClassEnum.CountNoun:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            var delobj = context.Menu_CountNoun.FirstOrDefault(x => x.CountNounNo == _MenuViewModel.MenuID);
                            if (delobj != null)
                            {
                                context.Menu_CountNoun.Remove(delobj);
                            }
                        }
                        break;
                    case MenuClassEnum.Genre:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            var delobj = context.Menu_Genre.FirstOrDefault(x => x.GenreNo == _MenuViewModel.MenuID);
                            if (delobj != null)
                            {
                                context.Menu_Genre.Remove(delobj);
                            }
                        }
                        break;
                    case MenuClassEnum.Material:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            var delobj = context.Menu_Material.FirstOrDefault(x => x.MaterialNo == _MenuViewModel.MenuID);
                            if (delobj != null)
                            {
                                context.Menu_Material.Remove(delobj);
                            }
                        }
                        break;
                    case MenuClassEnum.Style:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            var delobj = context.Menu_Style.FirstOrDefault(x => x.StyleNo == _MenuViewModel.MenuID);
                            if (delobj != null)
                            {
                                context.Menu_Style.Remove(delobj);
                            }
                        }
                        break;
                    case MenuClassEnum.WareType:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            var delobj = context.Menu_WareType.FirstOrDefault(x => x.WareTypeNo == _MenuViewModel.MenuID);
                            if (delobj != null)
                            {
                                context.Menu_WareType.Remove(delobj);
                            }
                        }
                        break;
                    case MenuClassEnum.Owner:
                        foreach (MenuViewModel _MenuViewModel in _MenuViewModelList)
                        {
                            var delobj = context.Menu_Owner.FirstOrDefault(x => x.OwnerNo == _MenuViewModel.MenuID);
                            if (delobj != null)
                            {
                                context.Menu_Owner.Remove(delobj);
                            }
                        }
                        break;
                }
                if (context.SaveChanges() == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary>
    /// 選項
    /// </summary>
    public class MenuViewModel
    {
        /// <summary>
        /// Menu類型
        /// </summary>
        public string MenuClass { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public int MenuID { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string MenuName { get; set; }
    }
}