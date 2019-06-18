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
        /// 作品開始年份
        /// </summary>
        public int WorkStartYear { get; set; } = 0;
        /// <summary>
        /// 作品結束年份
        /// </summary>
        public int WorkEndYear { get; set; } = 0;

        /// <summary>
        /// 藝術家出生年
        /// </summary>
        public int BirthStartYear { get; set; } = 0;

        /// <summary>
        /// 藝術家出生年
        /// </summary>
        public int BirthEndYear { get; set; } = 0;
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
        public MenuModel.WorkOrderbyTypeEnum OrderbyType = MenuModel.WorkOrderbyTypeEnum.預設排序;

        public string WorksSizeNo_InputString { get; set; } = "";
        public string AuthorsTagNo_InputString { get; set; } = "";
        public string AuthorsGender_InputString { get; set; } = "";
        public string WorksPropStyle_InputString { get; set; } = "";
        public string WorksWareTypeList_InputString { get; set; } = "";
        public string WorksPropOwnerList_InputString { get; set; } = "";
        public string WorksGenreList_InputString { get; set; } = "";
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
                    var r = context.Works.AsEnumerable().Where(f => f.IsDel != "Y");

                    r = r.Where(f => f.TotalInventory > 0).ToList();

                    if (!string.IsNullOrEmpty(this.WorksNo))
                    {
                        r = r.Where(f => f.WorksNo == Guid.Parse(WorksNo.ToUpper()));
                    }
                    if (!string.IsNullOrEmpty(this.WorksName))
                    {
                        r = r.Where(f => f.WorksName.Contains(this.WorksName));
                    }

                    //作品尺幅查詢
                    if (!string.IsNullOrEmpty(this.WorksSizeNo_InputString))
                    {
                        string[] List = this.WorksSizeNo_InputString.Split(',');
                        string[] WorkSizeList=context.WorksSizes.AsEnumerable().Where(x=>List.Contains(x.SizeNo.ToString())).Select(x => x.WorksNo.ToString()).ToArray();
                        r = r.Where(a => WorkSizeList.Contains(a.WorksNo.ToString()));
                    }

                    //藝術家標籤
                    if (!string.IsNullOrEmpty(this.AuthorsTagNo_InputString))
                    {
                        string[] List = this.AuthorsTagNo_InputString.Split(',');
                        string[] AuthorsList = context.AuthorsPropTag.AsEnumerable().Where(x => List.Contains(x.AuthorsTagNo.ToString())).Select(x => x.AuthorsNo.ToString()).ToArray();
                        string[] LIFNRList = context.Authors.AsEnumerable().Where(x => AuthorsList.Contains(x.AuthorsNo.ToString())&&x.LIFNR>0).Select(x => x.LIFNR.ToString()).ToArray();
                        r = r.Where(a => LIFNRList.Contains(a.AuthorsNo.ToString()));
                    }

                    //作品風格查詢
                    if (!string.IsNullOrEmpty(this.WorksPropStyle_InputString))
                    {
                        string[] List = this.WorksPropStyle_InputString.Split(',');
                        string[] WorkStyleList = context.WorksPropStyle.AsEnumerable().Where(x => List.Contains(x.StyleNo.ToString())).Select(x => x.WorksNo.ToString()).ToArray();
                        r = r.Where(a => WorkStyleList.Contains(a.WorksNo.ToString()));
                    }

                    //存放地查詢
                    if (!string.IsNullOrEmpty(this.WorksWareTypeList_InputString))
                    {
                        string[] List = this.WorksWareTypeList_InputString.Split(',');
                        var WareNo = context.Menu_WareType.AsEnumerable().Where(x => x.IsDel != "Y" && x.Werks != null).ToList();
                        string[] WareNoList = WareNo.AsEnumerable().Where(x => List.Contains(x.WareTypeNo.ToString())).Select(x=>x.Werks).ToArray();
                        string[] WareTypeList = context.WorksStocks.AsEnumerable().Where(x => WareNoList.Contains(x.WERKS.ToString())).Select(x => x.MaterialsID.ToString()).ToArray();
                        r = r.Where(a => WareTypeList.Contains(a.MaterialsID));
                    }

                  
                    //所有人查詢
                    if (!string.IsNullOrEmpty(this.WorksPropOwnerList_InputString))
                    {
                        string[] List = this.WorksPropOwnerList_InputString.Split(',');
                        r = r.Where(a => List.Contains(a.ZZPAGE.ToString())).ToList();
                    }

                    //作品分類查詢
                    if (!string.IsNullOrEmpty(this.WorksGenreList_InputString))
                    {
                        string[] List = this.WorksGenreList_InputString.Split(',');
                        r=r.Where(x=>x.GenreName!=null).ToList();
                        r = r.Where(a => List.Contains(a.GenreName.ToString().Split('-').Last().ToString())).ToList();
                    }

                    List<Guid> _WorksNoList = new List<Guid>();
                    int FilterCount = 1;

                    //藝術家查詢
                    if (this.AuthorNoList != null && this.AuthorNoList.Count > 0)
                    {
                      
                        int[] _AuthorNoArray = this.AuthorNoList.ConvertAll(s => int.Parse(s)).ToArray();
                        var LIFNR_Array = context.Authors.Where(x => _AuthorNoArray.Contains(x.AuthorsNo)).Select(x => x.LIFNR.Value).ToList();
                        r = r.Where(x => LIFNR_Array.Contains(x.AuthorsNo));
                    }

                    //類型
                    if (this.GenreNoList != null && this.GenreNoList.Count > 0)
                    {
                        FilterCount++;
                        int[] _GenreNoArray = this.GenreNoList.ConvertAll(s => int.Parse(s)).ToArray();
                        var wpgwkno = context.WorksPropGenre.AsEnumerable().Where(c => _GenreNoArray.Contains(c.GenreNo)).Select(c => c.WorksNo).ToList();
                        if (wpgwkno != null && wpgwkno.Count > 0)
                        {
                            _WorksNoList.AddRange(wpgwkno);
                        }
                        //r = r.Where(f => f.WorksPropGenre.Any(wpg => _GenreNoArray.Contains(wpg.GenreNo)));
                    }

                    //風格
                    if (this.StyleNoList != null && this.StyleNoList.Count > 0)
                    {
                        FilterCount++;
                        int[] _StyleNoList = this.StyleNoList.ConvertAll(s => int.Parse(s)).ToArray();
                        var wpswkno = context.WorksPropStyle.AsEnumerable().Where(c => _StyleNoList.Contains(c.StyleNo)).Select(c => c.WorksNo).ToList();
                        if (wpswkno != null && wpswkno.Count > 0)
                        {
                            _WorksNoList.AddRange(wpswkno);
                        }
                        //r = r.Where(f => f.WorksPropStyle.Any(wps => _StyleNoList.Contains(wps.StyleNo)));
                    }

                    //以包裝序號查詢
                    if (!string.IsNullOrEmpty(this.PackagesNo))
                    {
                        FilterCount++;
                        var pkgitmwkno = context.PackageItems.AsEnumerable().Where(c => c.PackagesNo == Guid.Parse(this.PackagesNo.ToUpper())).Select(c => c.WorksNo).ToList();

                        if (pkgitmwkno != null && pkgitmwkno.Count > 0)
                        {
                            _WorksNoList.AddRange(pkgitmwkno);
                        }
                        //r = r.Where(f => f.PackageItems.Any(pkg => pkg.PackagesNo == Guid.Parse(this.PackagesNo)));

                    }
                    if (_WorksNoList != null && _WorksNoList.Count > 0)
                    {
                        var _WorksNoArray = _WorksNoList.GroupBy(i => i)
                        .Where(g => g.Count() == FilterCount)
                        .Select(g => g.ElementAt(0)).ToArray();
                        //if (_WorksNoArray != null && _WorksNoArray.Length > 0)
                        //{
                        //    r = r.Where(f => _WorksNoArray.Contains(f.WorksNo));
                        //}
                    }
                    if (MenuModel.WorkOrderbyTypeEnum.預設排序 == this.OrderbyType)
                    {
                        //r = r.OrderByDescending(c => c.YearStart).ThenByDescending(c => c.CreateDate);
                        r = r.OrderBy(c => c.MaterialsID).ThenByDescending(c => c.YearStart).ThenByDescending(c => c.CreateDate);
                    }
                    else
                    if (MenuModel.WorkOrderbyTypeEnum.作品起始年代小至大 == this.OrderbyType)
                    {
                        r = r.OrderBy(c => c.YearStart).ThenByDescending(c => c.CreateDate);
                    }
                    else
                    if (MenuModel.WorkOrderbyTypeEnum.作品起始年代大至小 == this.OrderbyType)
                    {
                        r = r.OrderByDescending(c => c.YearStart).ThenByDescending(c => c.CreateDate);
                    }
                    else
                    //if (MenuModel.WorkOrderbyTypeEnum.定價小至大 == this.OrderbyType)
                    //{
                    //    r = r.OrderBy(c => c.Purchase).ThenByDescending(c => c.CreateDate);
                    //}
                    //else
                    //if (MenuModel.WorkOrderbyTypeEnum.定價大至小 == this.OrderbyType)
                    //{
                    //    r = r.OrderByDescending(c => c.Purchase).ThenByDescending(c => c.CreateDate);
                    //}
                    //else
                    if (MenuModel.WorkOrderbyTypeEnum.名稱姓名小至大 == this.OrderbyType)
                    {
                        r = r.OrderBy(c => c.WorksName).ThenByDescending(c => c.CreateDate);
                    }
                    else
                    if (MenuModel.WorkOrderbyTypeEnum.名稱姓名大至小 == this.OrderbyType)
                    {
                        r = r.OrderByDescending(c => c.WorksName).ThenByDescending(c => c.CreateDate);
                    }
                    else
                    {
                        r = r.OrderByDescending(c => c.CreateDate);
                    }
                    //if (PageIndex > 0 && PageIndex > 0)
                    //{
                    //    r = r.Select(c => c).Skip((PageIndex * PageSize - PageSize)).Take(PageSize + 1);
                    //}

                    var _rw = r.ToList();
                    _WorksModel = WorksListToWorksModelList(_rw);

                    //作品年代
                    if (this.WorkStartYear > 0)
                    {
                        _WorksModel = _WorksModel.Where(f => f.YearStart >= this.WorkStartYear).ToList();
                    }

                    if (this.WorkEndYear > 0)
                    {
                        _WorksModel = _WorksModel.Where( f=> f.YearStart <= this.WorkEndYear).ToList();
                    }

                    //藝術家性別
                    if (!string.IsNullOrEmpty(this.AuthorsGender_InputString))
                    {
                        string[] List = this.AuthorsGender_InputString.Split(',');
                        _WorksModel = _WorksModel.Where(f => List.Contains(f.AuthorsGender.ToString())).ToList();
                    }

     

                    //作者出生年
                    if (this.BirthStartYear > 0)
                    {
                        _WorksModel = _WorksModel.Where(f=>f.AuthorsBirth>=this.BirthStartYear).ToList();
                    }

                    if (this.BirthEndYear > 0)
                    {
                        _WorksModel = _WorksModel.Where(f => f.AuthorsBirth <= this.BirthEndYear).ToList();
                    }

                    //價格
                    if (this.MinePrice > 0)
                    {
                        _WorksModel = _WorksModel.Where(f => f.Price >= this.MinePrice).ToList();
                    }
                    if (this.MaxPrice > 0)
                    {
                        _WorksModel = _WorksModel.Where(f => f.Price <= this.MaxPrice).ToList();
                    }

                    //價格排序
                    if (MenuModel.WorkOrderbyTypeEnum.定價小至大 == this.OrderbyType)
                    {
                        _WorksModel = _WorksModel.OrderBy(c => c.Price).ThenByDescending(c => c.CreateDate).ToList();
                    }
                    else
                   if (MenuModel.WorkOrderbyTypeEnum.定價大至小 == this.OrderbyType)
                    {
                        _WorksModel = _WorksModel.OrderByDescending(c => c.Price).ThenByDescending(c => c.CreateDate).ToList();

                    }

                    //藝術家出生年排序
                    if (MenuModel.WorkOrderbyTypeEnum.出生年由小到大 == this.OrderbyType)
                    {
                        _WorksModel = _WorksModel.OrderBy(c => c.AuthorsBirth).ThenByDescending(c => c.CreateDate).ToList();
                    }

                    if (MenuModel.WorkOrderbyTypeEnum.出生年由大到小 == this.OrderbyType)
                    {
                        _WorksModel = _WorksModel.OrderByDescending(c => c.AuthorsBirth).ThenByDescending(c => c.CreateDate).ToList();
                    }


                    if (PageIndex > 0 && PageIndex > 0)
                    {
                        _WorksModel = _WorksModel.Select(c => c).Skip((PageIndex * PageSize - PageSize)).Take(PageSize + 1).ToList();
                    }
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
                                   AuthorsName ="",
                                   WorksName = c.WorksName,
                                   YearStart = c.YearStart,
                                   YearEnd = c.YearEnd,
                                   Remarks = c.Remarks,
                                   Cost = c.Cost,
                                   //Price = c.Purchase,
                                   //PricingDate = c.PricingDate,
                                   GrossMargin = c.GrossMargin,
                                   Marketability = c.Marketability,
                                   Packageability = c.Packageability,
                                   Valuability = c.Valuability,
                                   Artisticability = c.Artisticability,
                                   CreateUser = c.CreateUser,
                                   CreateDate = c.CreateDate,
                                   ModifyUser = c.ModifyUser,
                                   WorkSize=c.WorkSize,
                                   //ModifyDate = (DateTime)c.ModifyDate,
                                   ModifyDate = DateTime.Now,
                                   MaterialsName=c.Material,
                                   WorksModuleList = new List<WorksModel.WorksModuleModel>() { }
                               }
                        ).ToList();       

            Guid[] _WorksNoArray = _WorksModelList.Select(c => Guid.Parse(c.WorksNo.ToUpper())).ToArray();

            using (var context = new EG_MagicCubeEntities())
            {
                List<WorksAuthors> _WorksAuthors = new List<WorksAuthors>();
                if (context.WorksAuthors.Count() > 0)
                {
                    _WorksAuthors = context.WorksAuthors.Where(c => _WorksNoArray.Contains(c.Works_No)).ToList();
                }
                List<WorksModules> _WorksModules = new List<WorksModules>();
                if (context.WorksModules.Count() > 0)
                {
                    _WorksModules = context.WorksModules.Where(c => _WorksNoArray.Contains(c.WorksNo)).ToList();
                }

                var AuthorNameList = context.Authors.ToList();
                var PriceList = context.WorksPrices.ToList();

                //找出藝術家名稱和價格對映
                foreach (WorksModel item in _WorksModelList)
                {
                    string AuthorName = "";

                    if (item.AuthorsNo != -1)
                    {
                        AuthorName = AuthorNameList.Where(x => x.LIFNR == item.AuthorsNo).Select(x => x.AuthorsCName).FirstOrDefault().ToString();
                    }

                    var r= PriceList.Where(x => x.MaterialsID == item.MaterialsID&&x.Currency== "TWD").Select(x => x.Price).ToList();
                    int AuthorsBirth = AuthorNameList.Where(x => x.LIFNR == item.AuthorsNo).Select(x => x.BirthYear).FirstOrDefault();
                    int AuthorsGender = AuthorNameList.Where(x => x.LIFNR == item.AuthorsNo).Select(x => x.Gender).FirstOrDefault();

                    if (!string.IsNullOrEmpty(AuthorName))
                    {
                        item.AuthorsName = AuthorName;
                        item.AuthorsBirth = AuthorsBirth;
                        item.AuthorsGender = AuthorsGender;
                    }

                    if (r.Count > 0)
                    {
                        item.Price = r.FirstOrDefault();
                    }
                    
                    


                }

             
            }
            return _WorksModelList;
        }

    }


}