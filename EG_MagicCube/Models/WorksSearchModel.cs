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
    /// <summary>
    /// 作品查詢
    /// </summary>
    public partial class WorksSearchModel
    {
        /// <summary>
        /// 預算
        /// </summary>
        public int Budget { get; set; } = 0;
        /// <summary>
        /// 藝術家編號清單
        /// </summary>
        public List<string> AuthorNoList { get; set; } = new List<string>();
        /// <summary>
        /// 作品名稱
        /// </summary>
        public string WorksName { get; set; } = "";
        /// <summary>
        /// 最小長度
        /// </summary>
        public int MineLength { get; set; } = 0;
        /// <summary>
        /// 最大長度
        /// </summary>
        public int MaxLength { get; set; } = 0;
        /// <summary>
        /// 最小寬度
        /// </summary>
        public int MineWidth { get; set; } = 0;
        /// <summary>
        /// 最大寬度
        /// </summary>
        public int MaxWidth { get; set; } = 0;
        /// <summary>
        /// 最小高度
        /// </summary>
        public int MineHeight { get; set; } = 0;
        /// <summary>
        /// 最大高度
        /// </summary>
        public int MaxHeight { get; set; } = 0;
        /// <summary>
        /// 最小深度
        /// </summary>
        public int MineDeep { get; set; } = 0;
        /// <summary>
        /// 最小深度
        /// </summary>
        public int MaxDeep { get; set; } = 0;
        /// <summary>
        /// 最小時間長度
        /// </summary>
        public int MineTimeLength { get; set; } = 0;
        /// <summary>
        /// 最大時間長度
        /// </summary>
        public int MaxTimeLength { get; set; } = 0;
        /// <summary>
        /// 最小定價
        /// </summary>
        public int MinePrice { get; set; } = 0;
        /// <summary>
        /// 最大定價
        /// </summary>
        public int MaxPrice { get; set; } = 0;
        /// <summary>
        /// 類型編號清單
        /// </summary>
        public List<string> GenreNoList { get; set; } = new List<string>();
        /// <summary>
        /// 風格編號清單
        /// </summary>
        public List<string> StyleNoList { get; set; } = new List<string>();
        /// <summary>
        /// 分級
        /// </summary>
        public List<string> GradedNoList { get; set; } = new List<string>();

        /// <summary>
        /// 包裝編號
        /// </summary>
        public string PackagesNo { get; set; } = "";

        /// <summary>
        /// 作品編號
        /// </summary>
        public string WorksNo { get; set; } = "";
        /// <summary>
        /// 排序方式
        /// </summary>
        public MenuModel.MeunOrderbyTypeEnum OrderbyType= MenuModel.MeunOrderbyTypeEnum.預設排序;
        /// <summary>
        /// 搜尋
        /// </summary>
        /// <param name="PageIndex">頁碼，從1開始0為不分頁</param>
        /// <param name="PageSize">每頁筆數，0為不分頁</param>
        /// <returns></returns>
        public List<WorksModel> Search(int PageIndex = 0, int PageSize = 0)
        {
            //if (PageIndex == 0) PageIndex = 0;
            List<WorksModel> _WorksModel = new List<WorksModel>();
            using (var context = new EG_MagicCubeEntities())
            {
                if (context.Works.Count() > 0)
                {
                    var r = context.Works?.AsQueryable().Where(f=>f.IsDel != "Y");

                    if (!string.IsNullOrEmpty(this.WorksNo))
                    {
                        r = r.Where(f => f.WorksNo == Guid.Parse(WorksNo));
                    }
                    if (!string.IsNullOrEmpty(this.WorksName))
                    {
                        r = r.Where(f => f.WorksName.Contains(this.WorksName));
                    }
                    //價格
                    if (this.MinePrice > 0)
                    {
                        r = r.Where(f => f.Price >= this.MinePrice);
                    }
                    if (this.MinePrice > 0)
                    {
                        r = r.Where(f => f.Price <= this.MinePrice);
                    }

                    List<Guid> _WorksNoList = new List<Guid>();

                    #region 組件查詢
                    var rwm = context.WorksModules?.AsQueryable();
                    //長度
                    if (this.MineLength > 0)
                    {
                        rwm = rwm.Where(f => f.Length >= this.MineLength);
                    }
                    if (this.MaxLength > 0)
                    {
                        rwm = rwm.Where(f => f.Length <= this.MaxLength);
                    }
                    //寬度
                    if (this.MineWidth > 0)
                    {
                        rwm = rwm.Where(f => f.Width >= this.MineWidth);
                    }
                    if (this.MaxLength > 0)
                    {
                        rwm = rwm.Where(f => f.Width <= this.MaxWidth);
                    }
                    //高度
                    if (this.MineHeight > 0)
                    {
                        rwm = rwm.Where(f => f.Height >= this.MineHeight);
                    }
                    if (this.MaxHeight > 0)
                    {
                        rwm = rwm.Where(f => f.Height <= this.MaxHeight);
                    }
                    //深度
                    if (this.MineDeep > 0)
                    {
                        rwm = rwm.Where(f => f.Deep >= this.MineDeep);
                    }
                    if (this.MaxDeep > 0)
                    {
                        rwm = rwm.Where(f => f.Deep <= this.MaxDeep);
                    }
                    //時間長度
                    if (this.MineTimeLength > 0)
                    {
                        rwm = rwm.Where(f => f.TimeLength == this.MineTimeLength.ToString());
                    }
                    if (this.MaxTimeLength > 0)
                    {
                        rwm = rwm.Where(f => f.TimeLength == this.MaxTimeLength.ToString());
                    }

                    var _wkno=rwm.Select(c => c.WorksNo).ToList();
                    if (_wkno != null && _wkno.Count>0)
                    {
                        _WorksNoList.AddRange(_wkno);
                    }

                    #endregion

                    
                    //藝術家
                    if (this.AuthorNoList != null && this.AuthorNoList.Count > 0)
                    {
                        int[] _AuthorNoArray = this.AuthorNoList.ConvertAll(s => int.Parse(s)).ToArray();
                        var _wawkno = context.WorksAuthors?.AsQueryable()?.Where(wa => _AuthorNoArray.Contains(wa.Author_No)).Select(c => c.Works_No).ToList();
                        if(_wawkno != null && _wawkno.Count > 0)
                        {
                            _WorksNoList.AddRange(_wawkno);
                        }
                        //r = r.Where(f => f.WorksAuthors.Any(wa => this.AuthorNoList.Contains(wa.Author_No.ToString())));
                    }

                    //類型
                    if (this.GenreNoList != null && this.GenreNoList.Count > 0)
                    {
                        int[] _GenreNoArray = this.GenreNoList.ConvertAll(s => int.Parse(s)).ToArray();
                        var wpgwkno = context.WorksPropGenre?.AsQueryable()?.Where(c => _GenreNoArray.Contains(c.GenreNo)).Select(c => c.WorksNo).ToList();
                        if (wpgwkno != null && wpgwkno.Count > 0)
                        {
                            _WorksNoList.AddRange(wpgwkno);
                        }
                        //r = r.Where(f => f.WorksPropGenre.Any(wpg => _GenreNoArray.Contains(wpg.GenreNo)));
                    }

                    //風格
                    if (this.StyleNoList != null && this.StyleNoList.Count > 0)
                    {
                        int[] _StyleNoList = this.StyleNoList.ConvertAll(s => int.Parse(s)).ToArray();
                        var wpswkno = context.WorksPropStyle?.AsQueryable()?.Where(c => _StyleNoList.Contains(c.StyleNo)).Select(c => c.WorksNo).ToList();
                        if (wpswkno != null && wpswkno.Count > 0)
                        {
                            _WorksNoList.AddRange(wpswkno);
                        }
                        //r = r.Where(f => f.WorksPropStyle.Any(wps => _StyleNoList.Contains(wps.StyleNo)));
                    }

                    //以包裝序號查詢
                    if (!string.IsNullOrEmpty(this.PackagesNo))
                    {
                        var pkgitmwkno= context.PackageItems?.AsQueryable()?.Where(c => c.PackagesNo== Guid.Parse(this.PackagesNo)).Select(c => c.WorksNo).ToList();

                        if (pkgitmwkno != null && pkgitmwkno.Count > 0)
                        {
                            _WorksNoList.AddRange(pkgitmwkno);
                        }
                        //r = r.Where(f => f.PackageItems.Any(pkg => pkg.PackagesNo == Guid.Parse(this.PackagesNo)));

                    }
                    if (_WorksNoList != null && _WorksNoList.Count > 0)
                    {
                        var _WorksNoArray = _WorksNoList.GroupBy(i => i)
                        .Where(g => g.Count() > 1)
                        .Select(g => g.ElementAt(0)).ToArray();
                        if (_WorksNoArray != null && _WorksNoArray.Length>0)
                        {
                            r = r.Where(f => _WorksNoArray.Contains(f.WorksNo));
                        }
                    }
                    if (MenuModel.MeunOrderbyTypeEnum.預設排序 == this.OrderbyType)
                    {
                        r = r.OrderByDescending(c => c.WorksNo);
                    }
                    else
                    if (MenuModel.MeunOrderbyTypeEnum.建立時間由舊至新 == this.OrderbyType)
                    {
                        r = r.OrderBy(c => c.CreateDate);
                    }
                    else
                    if (MenuModel.MeunOrderbyTypeEnum.建立時間由新至舊 == this.OrderbyType)
                    {
                        r = r.OrderByDescending(c => c.CreateDate);
                    }
                    else
                    if (MenuModel.MeunOrderbyTypeEnum.修改時間由舊至新 == this.OrderbyType)
                    {
                        r = r.OrderBy(c => c.ModifyDate);
                    }
                    else
                    if (MenuModel.MeunOrderbyTypeEnum.修改時間由新至舊 == this.OrderbyType)
                    {
                        r = r.OrderByDescending(c => c.ModifyDate);
                    }
                    else
                    if (MenuModel.MeunOrderbyTypeEnum.名稱姓名小至大 == this.OrderbyType)
                    {
                        r = r.OrderBy(c => c.WorksName);
                    }
                    else
                    if (MenuModel.MeunOrderbyTypeEnum.名稱姓名大至小 == this.OrderbyType)
                    {
                        r = r.OrderByDescending(c => c.WorksName);
                    }
                    else
                    {
                        r = r.OrderByDescending(c => c.WorksNo);
                    }
                    if (PageIndex > 0 && PageIndex > 0)
                    {
                        r = r.Select(c => c).Skip((PageIndex * PageSize - PageSize)).Take(PageSize);
                    }

                    var _rw = r.ToList();
                    _WorksModel = WorksListToWorksModelList(_rw);
                }
                return _WorksModel;
            }
        }
        public List<WorksModel> WorksListToWorksModelList(List<Works> _WorksList)
        {
            List<WorksModel> _WorksModelList = new List<WorksModel>();

            _WorksModelList = _WorksList.Select(c =>
                               new WorksModel()
                               {
                                   WorksNo = c.WorksNo.ToString(),
                                   MaterialsID = c.MaterialsID,
                                   AuthorsNo = c.AuthorsNo,
                                   AuthorsName = "",
                                   WorksName = c.WorksName,
                                   YearStart = c.YearStart,
                                   YearEnd = c.YearEnd,
                                   Remarks = c.Remarks,
                                   Cost = c.Cost,
                                   Price = c.Price,
                                   PricingDate = c.PricingDate,
                                   GrossMargin = c.GrossMargin,
                                   Marketability = c.Marketability,
                                   Packageability = c.Packageability,
                                   Valuability = c.Valuability,
                                   Artisticability = c.Artisticability,
                                   CreateUser = c.CreateUser,
                                   CreateDate = c.CreateDate,
                                   ModifyUser = c.ModifyUser,
                                   ModifyDate = (DateTime)c.ModifyDate,
                                   WorksModuleList = new List<WorksModel.WorksModuleModel>() { }
                               }
                        ).ToList();

            Guid[] _WorksNoArray = _WorksModelList.Select(c => Guid.Parse(c.WorksNo)).ToArray();

            using (var context = new EG_MagicCubeEntities())
            {
                List<WorksAuthors> _WorksAuthors = new List<WorksAuthors>();
                if (context.WorksAuthors.Count() > 0)
                {
                    _WorksAuthors = context?.WorksAuthors?.Where(c => _WorksNoArray.Contains(c.Works_No)).ToList();
                }
                List<WorksModules> _WorksModules = new List<WorksModules>();
                if (context.WorksModules.Count() > 0)
                {
                    _WorksModules = context?.WorksModules?.Where(c => _WorksNoArray.Contains(c.WorksNo)).ToList();
                }

                foreach (WorksModel _WorksModel in _WorksModelList)
                {
                    _WorksModel.AuthorsName = string.Join(",", _WorksAuthors.Where(c => c.Works_No == Guid.Parse(_WorksModel.WorksNo)).Select(c => c.Authors.AuthorsCName).ToArray());

                    foreach (WorksModel.WorksModuleModel _WorksModule in _WorksModel.WorksModuleList)
                    {
                        var wm = _WorksModules.Where(c => c.WorksNo == Guid.Parse(_WorksModel.WorksNo)).FirstOrDefault();
                        if (wm != null)
                        {
                            _WorksModule.WorksModulesNo = wm.WorksModulesNo;
                            _WorksModule.WorksNo = wm.WorksNo.ToString();
                            _WorksModule.Material = new MenuViewModel { MenuID = wm.Menu_Material.MaterialNo, MenuName = wm.Menu_Material.MaterialName };
                            _WorksModule.Measure = wm.Measure;
                            _WorksModule.Length = wm.Length;
                            _WorksModule.Width = wm.Width;
                            _WorksModule.Height = wm.Height;
                            _WorksModule.Deep = wm.Deep;
                            _WorksModule.TimeLength = int.Parse(wm.TimeLength);
                            _WorksModule.Amount = wm.Amount;
                            _WorksModule.CountNoun = new MenuViewModel { MenuID = wm.Menu_CountNoun.CountNounNo, MenuName = wm.Menu_CountNoun.CountNounName };
                        }

                    }
                }
            }
            return _WorksModelList;
        }
    }


}