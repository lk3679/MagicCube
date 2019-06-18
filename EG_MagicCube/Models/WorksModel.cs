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
    #region 作品

    /// <summary>
    /// 作品
    /// </summary>
    public partial class WorksModel
    {
        #region Properties
        /// <summary>
        /// 作品序號
        /// </summary>
        [DisplayName("作品序號")]
        public string WorksNo { get; set; } = "";
        /// <summary>
        /// 物料代碼
        /// </summary>
        [DisplayName("物料代碼")]
        public string MaterialsID { get; set; } = "";
        /// <summary>
        /// 物料名稱
        /// </summary>
        [DisplayName("物料名稱")]
        public string MaterialsName { get; set; } = "";
        /// <summary>
        /// 藝術家編號
        /// </summary>
        [DisplayName("藝術家編號")]
        public int AuthorsNo { get; set; } = 0;
        /// <summary>
        /// 藝術家名稱
        /// </summary>
        [DisplayName("藝術家(中)")]
        public string AuthorsName { get; set; } = "";

        [DisplayName("藝術家(英)")]
        public string AuthorsEnName { get; set; } = "";

        [DisplayName("藝術家國別")]
        public string AuthorsNation { get; set; } = "";


        [DisplayName("藝術家出生年")]
        public int AuthorsBirth { get; set; } = 0;

        [DisplayName("藝術家性別")]
        public int AuthorsGender { get; set; } = 0;

        /// <summary>
        /// 作品名稱
        /// </summary>
        [Required]
        [DisplayName("作品名稱")]
        public string WorksName { get; set; } = "";
        /// <summary>
        /// 作品起始年分
        /// </summary>
        [DisplayName("起迄年分")]
        public short YearStart { get; set; } = 0;
        /// <summary>
        /// 作品結束年分
        /// </summary>
        [DisplayName("作品結束年分")]
        public short YearEnd { get; set; } = 0;
        /// <summary>
        /// 備註
        /// </summary>
        [DisplayName("備註")]
        public string Remarks { get; set; } = "";
        /// <summary>
        /// 成本價
        /// </summary>
        [DisplayName("成本(NT未稅)")]
        public int Cost { get; set; } = 0;
        /// <summary>
        /// 定價
        /// </summary>
        [DisplayName("定價")]
        public int Price { get; set; } = 0;
        /// <summary>
        /// 定價時間
        /// </summary>
        [DisplayName("定價時間")]
        public DateTime PricingDate { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 毛利率
        /// </summary>
        [DisplayName("毛利率")]
        public double GrossMargin { get; set; } = 0.0;
        /// <summary>
        /// 市場性
        /// </summary>
        [DisplayName("市場性")]
        [Range(0.0, 10.0)]
        public double Marketability { get; set; } = 0.0;
        /// <summary>
        /// 包裹性
        /// </summary>
        [DisplayName("包裹性")]
        [Range(0.0, 10.0)]
        public double Packageability { get; set; } = 0.0;
        /// <summary>
        /// 增值性
        /// </summary>
        [DisplayName("增值性")]
        [Range(0.0, 10.0)]
        public double Valuability { get; set; } = 0.0;
        /// <summary>
        /// 藝術性
        /// </summary>
        [DisplayName("藝術性")]
        [Range(0.0,10.0)]
        public double Artisticability { get; set; } = 0.0;
        /// <summary>
        /// 建立者
        /// </summary>
        [DisplayName("建立者")]
        public string CreateUser { get; set; } = "";
        /// <summary>
        /// 建立時間
        /// </summary>
        [DisplayName("建立時間")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改者
        /// </summary>
        [DisplayName("修改者")]
        public string ModifyUser { get; set; } = "";
        /// <summary>
        /// 修改時間
        /// </summary>
        [DisplayName("修改時間")]
        public DateTime ModifyDate { get; set; }
        /// <summary>
        /// 作品所屬藝術家
        /// </summary>
        [DisplayName("作品所屬藝術家")]
        public List<MenuViewModel> WorksAuthors { get; set; } = new List<MenuViewModel>();
        /// <summary>
        /// 新增修改藝術家序號清單字串，用,分隔
        /// </summary>
        [Required]
        [DisplayName("藝術家")]
        public List<string> AuthorNo_InputString { get; set; } = new List<string>();
        /// <summary>
        /// 作品圖片數量
        /// </summary>
        [DisplayName("作品圖片數量")]
        public int ImageCount { get; set; } = 0;
        /// <summary>
        /// 檢視作品檔案Base64
        /// </summary>
        [DisplayName("作品檔案")]
        public List<string> ViewWorksFiles { get; set; } = new List<string>();
        /// <summary>
        /// 上傳作品檔案
        /// </summary>
        [DisplayName("上傳作品")]
        public List<HttpPostedFileBase> UploadWorksFiles { get; set; } = new List<HttpPostedFileBase>();
        /// <summary>
        /// 作品組件
        /// </summary>
        [DisplayName("作品組件")]
        public List<WorksModuleModel> WorksModuleList { get; set; } = new List<WorksModuleModel>();
        /// <summary>
        /// 作品類型
        /// </summary>
        [DisplayName("作品類型")]
        public List<MenuViewModel> WorksPropGenreList { get; set; } = new List<MenuViewModel>();
        /// <summary>
        /// 新增修改作品類型清單字串，用,分隔
        /// </summary>
        [Required]
        [DisplayName("作品類型")]
        public List<string> GenreNo_InputString { get; set; } = new List<string>();
        /// <summary>
        /// 作品所有人
        /// </summary>
        [DisplayName("所有人")]
        public List<MenuViewModel> WorksPropOwnerList { get; set; } = new List<MenuViewModel>();
        /// <summary>
        /// 新增修改作品所有人清單字串，用,分隔
        /// </summary>
        [Required]
        [DisplayName("作品所有人")]
        public List<string> OwnerNo_InputString { get; set; } = new List<string>();
        /// <summary>
        /// 作品風格
        /// </summary>
        [DisplayName("作品風格")]
        public List<MenuViewModel> WorksPropStyleList { get; set; } = new List<MenuViewModel>();
        /// <summary>
        /// 新增修改作品風格清單字串，用,分隔
        /// </summary>
        //[Required]
        [DisplayName("作品風格")]
        public List<string> StyleNo_InputString { get; set; } = new List<string>();
        /// <summary>
        /// 庫別
        /// </summary>
        [DisplayName("庫別")]
        public List<MenuViewModel> WorksPropWareTypeList { get; set; } = new List<MenuViewModel>();
        /// <summary>
        /// 新增修改庫別清單字串，用,分隔
        /// </summary>
        [Required]
        [DisplayName("庫別")]
        public List<string> WareTypeNo_InputString { get; set; } = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        public bool IsJoin { get; set; } = false;
        /// <summary>
        /// 作品等級
        /// </summary>
        [Required]
        [DisplayName("作品等級")]
        public string Rating { get; set; } = "";
        /// <summary>
        /// 作品數量
        /// </summary>
        [Required]
        [DisplayName("作品數量")]
        public int WorksAmount { get; set; } = 0;

        [Required]
        [DisplayName("庫存數量")]
        public int WorksStocks{ get; set; } = 0;

        [DisplayName("作品類別")]
        public string GenreName { get; set; } = "";

        [DisplayName("尺寸")]
        public string WorkSize { get; set; } = "";

        [DisplayName("作品尺幅")]
        public int WorkSizeNo { get; set; } = 0;

        [DisplayName("庫存總數")]
        public int TotalInventory { get; set; } = 0;

        [DisplayName("材質(中)")]
        public string Material { get; set; } = "";

        [DisplayName("材質(英)")]
        public string MaterialEng { get; set; } = "";

        [DisplayName("作品尺幅選單")]
        public List<MenuViewModel> WorksWorksSize { get; set; } = new List<MenuViewModel>();

  
        [DisplayName("作品尺幅")]
        public List<string> WorksSizeNo_InputString { get; set; } = new List<string>();

        [DisplayName("組件")]
        public string ZFVOLUME { get; set; } = "";

        [DisplayName("數量分級")]
        public int AuthorsRating { get; set; } = 0;

        [DisplayName("定價")]
        public List<WorksPrices> WorksPricesList { get; set; } = new List<WorksPrices>();
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

        #endregion

        #region Methods

        #region Create
        /// <summary>
        /// 新增作品
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            int AuthorsNo = 0;

            using (var context = new EG_MagicCubeEntities())
            {

                DateTime gtm = new DateTime(1970, 1, 1);
                DateTime utc = DateTime.UtcNow.AddHours(8);
                this.MaterialsID = Convert.ToInt32(((TimeSpan)utc.Subtract(gtm)).TotalSeconds).ToString();

                Works _Works = new Works();
                _Works.WorksNo = Guid.NewGuid();
                this.WorksNo = _Works.WorksNo.ToString();
                _Works.MaterialsID = this.MaterialsID;
                _Works.AuthorsNo = this.AuthorNo_InputString.Select(n => Convert.ToInt32(n)).ToArray()[0];
                //轉換為SAP的藝術家key值
                AuthorsNo = context.Authors.Where(x => x.AuthorsNo == _Works.AuthorsNo).Select(x => x.LIFNR.Value).FirstOrDefault();
                _Works.AuthorsNo = AuthorsNo;
                _Works.GenreName = this.GenreName;
                _Works.TotalInventory = this.TotalInventory;
                _Works.Material = this.Material;
                _Works.MaterialEng = this.MaterialEng;
                _Works.WorkSize = this.WorkSize;
                _Works.WorksName = this.WorksName;
                _Works.YearStart = this.YearStart;
                _Works.YearEnd = this.YearEnd;
                _Works.Cost = this.Cost;
                _Works.Purchase = this.Price;
                _Works.GrossMargin = Math.Round((((Convert.ToDouble((this.Price / double.Parse("1.05"))) - Convert.ToDouble(this.Cost)) / Convert.ToDouble((this.Price / double.Parse("1.05")))) * Convert.ToDouble(100)), 3);
                _Works.PricingDate = DateTime.Now;
                _Works.Artisticability = this.Artisticability;
                _Works.Marketability = this.Marketability;
                _Works.Packageability = this.Packageability;
                _Works.Valuability = this.Valuability;
                _Works.CreateUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                _Works.CreateDate = DateTime.Now;
                _Works.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                _Works.ModifyDate = DateTime.Now;
                _Works.Remarks = this.Remarks;
                _Works.Rating = CalculateWorksRating(this).ToString();
                _Works.IsDel = "";

                context.Works.Add(_Works);

                if (context.SaveChanges() > 0)
                {                  
                    //圖片
                    foreach (HttpPostedFileBase _Files in this.UploadWorksFiles)
                    {
                        if (_Files != null)
                        {
                            WorksFilesModel.InsFile(_Works.WorksNo.ToString(), _Files);
                            //context.WorksFiles.Add(new WorksFiles() { WorksNo = _Works.WorksNo, FileBase64Str = FileUrl });
                        }

                    }
                    //藝術家
                    //foreach (int _AuthorNo in this.AuthorNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    //{
                    //    context.WorksAuthors.Add(new WorksAuthors() { Works_No = _Works.WorksNo, Author_No = _AuthorNo });
                    //}
                    //類型
                    //foreach (int _GenreNo in this.GenreNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    //{
                    //    context.WorksPropGenre.Add(new WorksPropGenre() { WorksNo = _Works.WorksNo, GenreNo = _GenreNo });
                    //}
                    //風格
                    foreach (int _StyleNo in this.StyleNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.WorksPropStyle.Add(new WorksPropStyle() { WorksNo = _Works.WorksNo, StyleNo = _StyleNo });
                    }
                    //擁有者
                    foreach (int _OwnerNo in this.OwnerNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        //context.WorksPropOwner.Add(new WorksPropOwner() { WorksNo = _Works.WorksNo, OwnerNo = _OwnerNo });
                        //修正擁有者記錄的位置
                        _Works.ZZPAGE = _OwnerNo.ToString();
                    }
                    //庫別
                    //foreach (int _WareTypeNo in this.WareTypeNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    //{
                    //    context.WorksPropWareType.Add(new WorksPropWareType() { WorksNo = _Works.WorksNo, WareTypeNo = _WareTypeNo });
                    //}

                    //新增商品售價
                    context.WorksPrices.Add(new WorksPrices() { MaterialsID=this.MaterialsID,Price=this.Price,Currency= "TWD", CreateDate=DateTime.Now,ModifyDate=DateTime.Now,PricingDate=this.PricingDate,source="Cube"});

                    if (context.SaveChanges() == 0)
                    {
                        return false;
                    }
                    else
                    {


                        //藝術家作品總數總
                        var _Authors = context?.Authors?.FirstOrDefault(c => c.LIFNR== AuthorsNo);
                        _Authors.WorksAmount = _Authors.WorksAmount+1;
                        context.SaveChanges();

                        //foreach (int _AuthorNo in this.AuthorNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                        //{
                        //    var _Authors = context?.Authors?.FirstOrDefault(c => c.AuthorsNo == _AuthorNo);
                        //    int _WorksAmount = (context?.WorksAuthors?.AsEnumerable().Where(c => c.Author_No == _AuthorNo).Count()).Value;
                        //    int _AuthorsRating = AuthorsModel.CalculateAuthorsRating(_WorksAmount);
                        //    _Authors.Rating = _AuthorsRating.ToString();
                        //    _Authors.WorksAmount = _WorksAmount;
                        //    context.SaveChanges();
                        //}
                    }
                }
                else
                {
                    return false;
                }

            }
            return true;
        }
        /// <summary>
        /// 計算作品分級
        /// </summary>
        /// <param name="_WorksModel"></param>
        /// <returns></returns>
        public static int CalculateWorksRating(WorksModel _WorksModel)
        {
            double _Rating = 0;
            int _WorksAmount = 0;
            using (var context = new EG_MagicCubeEntities())
            {
                foreach (int _AuthorNo in _WorksModel.AuthorNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                {
                    _WorksAmount = _WorksAmount + (context?.WorksAuthors?.AsEnumerable().Where(c => c.Author_No == _AuthorNo).Count()).Value;
                }
            }
            _WorksAmount = (_WorksAmount + 1) / _WorksModel.AuthorNo_InputString.Select(n => Convert.ToInt32(n)).Count();
            double _AuthorsRating = Convert.ToDouble(AuthorsModel.CalculateAuthorsRating(_WorksAmount));

            _Rating = (_WorksModel.Marketability * 0.3) + (_WorksModel.Packageability * 0.1) + (_WorksModel.Valuability * 0.25) + (_WorksModel.Artisticability * 0.2)+ (_AuthorsRating * 0.15);
            return Convert.ToInt32(_Rating);
        }

        
        /// <summary>
        /// 新增並回傳
        /// </summary>
        /// <returns></returns>
        public WorksModel CreateAndReturn()
        {
            WorksModel _PackagesModel = new WorksModel();
            if (this.Create())
            {
                _PackagesModel = GetWorksModelDetail(this.WorksNo);
            }
            return _PackagesModel;
        }

        #endregion

        /// <summary>
        /// 用作品編號找作品
        /// </summary>
        /// <param name="WorksNo"></param>
        /// <returns></returns>
        public static WorksModel GetWorksModelDetail(string WorksNo)
        {
            WorksModel _WorksModel = new WorksModel();
            Guid Guid_WorksNo = Guid.Parse(WorksNo.ToUpper());
            using (var context = new EG_MagicCubeEntities())
            {
                Works _Works = context.Works.AsEnumerable().Where(c => c.IsDel != "Y" && c.WorksNo.Equals(Guid_WorksNo)).Select(c => c).FirstOrDefault<Works>();
                if (_Works != null)
                {
                    //var _WorksAuthorsist = context.WorksAuthors.AsEnumerable().Where(c => c.Works_No.Equals(Guid_WorksNo)).Select(wa => wa).ToList();
                    //var _WorksPropGenreList = context.WorksPropGenre.AsEnumerable().Where(c => c.WorksNo.Equals(Guid_WorksNo)).Select(wpg => wpg).ToList();
                    //var _WorksPropOwnerList = context.WorksPropOwner.AsEnumerable().Where(c => c.WorksNo.Equals(Guid_WorksNo)).Select(wpo => wpo).ToList();
                    var _WorksPropStyleList = context.WorksPropStyle.AsEnumerable().Where(c => c.WorksNo.Equals(Guid_WorksNo)).Select(wps => wps).ToList();
                    //var _WorksPropWareTypeList = context.WorksPropWareType.AsEnumerable().Where(c => c.WorksNo.Equals(Guid_WorksNo)).Select(wpwt => wpwt).ToList();

                    //找出對映的倉別位置
                    var a = context.WorksStocks.AsEnumerable().Where(c => c.MaterialsID.Equals(_Works.MaterialsID)).Select(x => x).ToList();
                    var b= context.Menu_WareType.AsEnumerable().Where(c=>c.Werks!=null).Select(x => x).ToList();

                    var _WorksPropWareTypeList = from x in a
                            join y in b  on x.WERKS equals y.Werks
                            select new { y.WareTypeNo,y.WareTypeName };

                    var _WorksWorksFilesList = context.WorksFiles.AsEnumerable().Where(c => c.WorksNo.Equals(Guid_WorksNo)).OrderBy(c=>c.Sorting).ThenBy(c => c.WorksFilesNo).Select(wf => wf).ToList();
                    var _WorksWorksModulesList = context.WorksModules.AsEnumerable().Where(c => c.WorksNo.Equals(Guid_WorksNo)).Select(wm => wm).ToList();

                    //找出訂價
                    //找出訂價時間
                    var _WorksPriceList = context.WorksPrices.AsEnumerable().Where(c => c.MaterialsID.Equals(_Works.MaterialsID)).Select(x => x).ToList();
                    if (_WorksPriceList.Count > 0)
                    {
                        _WorksModel.Price = _WorksPriceList.Where(c=> c.Currency == "TWD").FirstOrDefault().Price;
                        _WorksModel.PricingDate = _WorksPriceList.Where(c=> c.Currency == "TWD").FirstOrDefault().PricingDate;
                        _WorksModel.WorksPricesList = _WorksPriceList;
                    }

                    //找出作品數量
                    //動態計算作品等級
                    var _WorksAuthorsist = context.Authors.AsEnumerable().Where(c => c.LIFNR.Equals(_Works.AuthorsNo)).Select(x => x).ToList();
                    int _AuthorsRating = 0;
                    if (_WorksAuthorsist.Count>0)
                    {
                        _WorksModel.WorksAmount = _WorksAuthorsist.FirstOrDefault().WorksAmount;
                        _AuthorsRating = AuthorsModel.CalculateAuthorsRating(_WorksModel.WorksAmount);
                        _WorksModel.AuthorsRating = _AuthorsRating;
                    }

                     _WorksModel.WorksNo = _Works.WorksNo.ToString();
                    _WorksModel.MaterialsID = _Works.MaterialsID;
                    //_WorksModel.AuthorsNo = _Works.AuthorsNo;
                    //_WorksModel.AuthorsName = _Works.WorksAuthors.FirstOrDefault().Authors.AuthorsCName;
                    _WorksModel.AuthorsName = _Works.AuthorsNo <= 0 ? "" : context.Authors.Where(x => x.LIFNR == _Works.AuthorsNo).FirstOrDefault().AuthorsCName.ToString();
                    _WorksModel.AuthorsEnName = _Works.AuthorsNo <= 0 ? "" : context.Authors.Where(x => x.LIFNR == _Works.AuthorsNo).FirstOrDefault().AuthorsEName.ToString();
                    string LAND1 = _Works.AuthorsNo <= 0 ? "" : context.Authors.Where(x => x.LIFNR == _Works.AuthorsNo).FirstOrDefault().LAND1.ToString();
                    //var r_AuthorsPropTag = context.AuthorsPropTag.AsEnumerable().Where(c => c.AuthorsNo == _Works.AuthorsNo).ToList();
                    //if (r_AuthorsPropTag != null && r_AuthorsPropTag.Count > 0)
                    //{
                    //    _WorksModel.AuthorsTagNo_InputString = r_AuthorsPropTag.Select(apt => Convert.ToString(apt.AuthorsTagNo)).ToList();
                       
                    //}

                    //該作品的藝術家標籤
                    int AuthorsNo = context.Authors.AsEnumerable().Where(x => x.LIFNR == _Works.AuthorsNo).FirstOrDefault().AuthorsNo;
                    var r_AuthorsPropTag = context.AuthorsPropTag.Where(x => x.AuthorsNo== AuthorsNo).Select(x =>x).ToList();
                    if (r_AuthorsPropTag != null && r_AuthorsPropTag.Count > 0)
                    {
                        _WorksModel.AuthorsTagNo_InputString = r_AuthorsPropTag.Select(apt => Convert.ToString(apt.AuthorsTagNo)).ToList();
                    }


                    _WorksModel.AuthorsNation = context.Menu_Nation.Where(x => x.AreaCode == LAND1).FirstOrDefault().AreaName;

                    _WorksModel.AuthorsNo = context.Authors.Where(x => x.LIFNR == _Works.AuthorsNo).FirstOrDefault().AuthorsNo;
                    _WorksModel.ZFVOLUME = _Works.ZFVOLUME;
                    _WorksModel.WorksName = _Works.WorksName;
                    _WorksModel.YearStart = _Works.YearStart;
                    _WorksModel.YearEnd = _Works.YearEnd;
                    _WorksModel.Remarks = _Works.Remarks;
                    _WorksModel.Cost = _Works.Cost;
             
                    _WorksModel.GrossMargin = _WorksModel.Price==0?0:Math.Round((double)((_WorksModel.Price - _WorksModel.Cost) * 100 / _WorksModel.Price), 2);
                    _WorksModel.Marketability = _Works.Marketability;
                    _WorksModel.Packageability = _Works.Packageability;
                    _WorksModel.Valuability = _Works.Valuability;
                    _WorksModel.Artisticability = _Works.Artisticability;
                    _WorksModel.CreateUser = _Works.CreateUser;
                    _WorksModel.CreateDate = _Works.CreateDate;
                    _WorksModel.ModifyUser = _Works.ModifyUser;
                    _WorksModel.Rating = ((_WorksModel.Marketability * 0.3) + (_WorksModel.Packageability * 0.1) + (_WorksModel.Valuability * 0.25) + (_WorksModel.Artisticability * 0.2) + (_AuthorsRating * 0.15)).ToString();
                    _WorksModel.ModifyDate = (DateTime)_Works.ModifyDate;
                    _WorksModel.GenreName = _Works.GenreName;
                    _WorksModel.WorkSize = _Works.WorkSize;
                    _WorksModel.TotalInventory = _Works.TotalInventory;
                    _WorksModel.Material = _Works.Material;
                    _WorksModel.MaterialEng = _Works.MaterialEng;
                    //_WorksModel.WorkSizeNo = _Works.WorksSizeNo==null?0: _Works.WorksSizeNo.Value;

                    //帶入作者
                    List<string> AuthorsList = new List<string>();
                    AuthorsList.Add(_WorksModel.AuthorsNo.ToString());
                    _WorksModel.AuthorNo_InputString = AuthorsList;

                    //代入作品尺幅
                    _WorksModel.WorksSizeNo_InputString = context.WorksSizes.AsEnumerable().Where(x => x.WorksNo == _Works.WorksNo).Select(x => x.SizeNo.ToString()).ToList();

                    //帶入作品所有人
                    List<string> OwnerNoList = new List<string>();
                    OwnerNoList.Add(_Works.ZZPAGE.ToString());
                    _WorksModel.OwnerNo_InputString = OwnerNoList;

                   
                    //_WorksModel.AuthorNo_InputString = _WorksAuthorsist?.Select(wa => wa.Author_No.ToString()).ToList();
                    //_WorksModel.GenreNo_InputString = _WorksPropGenreList?.Select(wpg => wpg.GenreNo.ToString()).ToList();
                    _WorksModel.StyleNo_InputString = _WorksPropStyleList?.Select(wpo => wpo.StyleNo.ToString()).ToList();
                    //_WorksModel.OwnerNo_InputString = _WorksPropOwnerList?.Select(wps => wps.OwnerNo.ToString()).ToList();
               
                    //_WorksModel.WareTypeNo_InputString = _WorksPropWareTypeList?.Select(wpwt => wpwt.WareTypeNo.ToString()).ToList();
                    var WareTypeLsit = context.WorksStocks.Where(x => x.MaterialsID == _Works.MaterialsID).ToList();
                    List<string> WareNoList = new List<string>();
                    foreach (var item in WareTypeLsit)
                    {
                        var WareTypeList = context.Menu_WareType.AsEnumerable().Where(x => x.Werks != null).ToList();
                        string WareNo = WareTypeList.Where(x => x.Werks == item.WERKS).FirstOrDefault().WareTypeNo.ToString()??"";
                        WareNoList.Add(WareNo);
                    }
                    _WorksModel.WareTypeNo_InputString = WareNoList;

                    _WorksModel.WorksAuthors = context.Authors.Select(wa => new MenuViewModel() { MenuID = wa.AuthorsNo,MenuName=wa.AuthorsCName }).ToList();
                    _WorksModel.WorksWorksSize=context.Menu_WorksSize.Select(wa => new MenuViewModel() { MenuID = wa.WorksSizeNo, MenuName = wa.WorksSizeName }).ToList();
                    //_WorksModel.WorksAuthors = _WorksAuthorsist?.Select(wa => new MenuViewModel() { MenuID = wa.Author_No, MenuName = wa.Authors.AuthorsCName }).ToList();
                    //_WorksModel.WorksPropGenreList = _WorksPropGenreList?.Select(wpg => new MenuViewModel() { MenuID = wpg.GenreNo, MenuName = wpg.Menu_Genre.GenreName }).ToList();
                    _WorksModel.WorksPropOwnerList = context.Menu_Owner.Select(wpo=>new MenuViewModel { MenuID=wpo.OwnerNo,MenuName=wpo.OwnerName}).ToList();                   
                    _WorksModel.WorksPropStyleList = _WorksPropStyleList?.Select(wps => new MenuViewModel() { MenuID = wps.StyleNo, MenuName = wps.Menu_Style.StyleName }).ToList();
                    _WorksModel.WorksPropWareTypeList = _WorksPropWareTypeList?.Select(wpwt => new MenuViewModel() { MenuID = wpwt.WareTypeNo, MenuName = wpwt.WareTypeName }).ToList();
                    _WorksModel.ImageCount = _WorksWorksFilesList.Count;
                    //_WorksModel.WorksAmount = _Works.WorksAuthors.FirstOrDefault().Authors.WorksAmount;
                    _WorksModel.ViewWorksFiles = _Works.WorksFiles.Select(wf => wf.FileBase64Str).ToList();

                 

                }


            }
            return _WorksModel;
        }

        #region Update
        /// <summary>
        /// 更新作品資料
        /// </summary>
        /// <param name="newWorks">新作品資料</param>
        /// <returns></returns>
        public static bool Update(WorksModel newWorks)
        {
            Guid Guid_WorksNo = Guid.Parse(newWorks.WorksNo.ToUpper());
            using (var context = new EG_MagicCubeEntities())
            {
                var oldWorks = context.Works.AsEnumerable().First(x => x.WorksNo == Guid_WorksNo);
                if (oldWorks != null)
                {
                    //清空舊資料
                    if (oldWorks.WorksModules != null)
                    {
                        foreach (WorksModules _WorksModules in oldWorks.WorksModules.ToList())
                        {
                            var del_WorksModules = context.WorksModules.AsEnumerable().FirstOrDefault(c => c.WorksModulesNo == _WorksModules.WorksModulesNo);
                            context.WorksModules.Remove(del_WorksModules);
                        }
                    }
                    if (oldWorks.WorksAuthors != null)
                    {
                        foreach (WorksAuthors _WorksAuthors in oldWorks.WorksAuthors.ToList())
                        {
                            var del_WorksAuthors = context.WorksAuthors.AsEnumerable().FirstOrDefault(c => c.Works_Author_No == _WorksAuthors.Works_Author_No);
                            context.WorksAuthors.Remove(del_WorksAuthors);
                        }
                    }
                    if (oldWorks.WorksPropGenre != null)
                    {
                        foreach (WorksPropGenre _WorksPropGenre in oldWorks.WorksPropGenre.ToList())
                        {
                            var del_WorksPropGenre = context.WorksPropGenre.AsEnumerable().FirstOrDefault(c => c.WorksPropGenreNo == _WorksPropGenre.WorksPropGenreNo);
                            context.WorksPropGenre.Remove(del_WorksPropGenre);
                        }
                    }
                    if (oldWorks.WorksPropStyle != null)
                    {
                        foreach (WorksPropStyle _WorksPropStyle in oldWorks.WorksPropStyle.ToList())
                        {
                            var del_WorksPropStyle = context.WorksPropStyle.AsEnumerable().FirstOrDefault(c => c.WorksPropStyleNo == _WorksPropStyle.WorksPropStyleNo);
                            context.WorksPropStyle.Remove(del_WorksPropStyle);
                        }
                    }
                    if (oldWorks.WorksPropOwner != null)
                    {
                        foreach (WorksPropOwner _WorksPropOwner in oldWorks.WorksPropOwner.ToList())
                        {
                            var del_WorksPropOwner =context.WorksPropOwner.AsEnumerable().FirstOrDefault(c => c.WorksPropOwnerNo == _WorksPropOwner.WorksPropOwnerNo);
                            context.WorksPropOwner.Remove(del_WorksPropOwner);
                        }
                    }
                    if (oldWorks.WorksPropWareType != null)
                    {
                        foreach (WorksPropWareType _WorksPropWareType in oldWorks.WorksPropWareType.ToList())
                        {
                            var del_WorksPropWareType = context.WorksPropWareType.AsEnumerable().FirstOrDefault(c => c.WorksPropWareTypeNo == _WorksPropWareType.WorksPropWareTypeNo);
                            context.WorksPropWareType.Remove(del_WorksPropWareType);
                        }
                    }

                    var worksizelist = context.WorksSizes.AsEnumerable().Where(x => x.WorksNo == oldWorks.WorksNo).ToList();
                    if (worksizelist.Count > 0)
                    {
                        foreach(WorksSizes _WorksSizes in worksizelist)
                        {
                            context.WorksSizes.Remove(_WorksSizes);
                        }
                    }

                }
                oldWorks.MaterialsID = newWorks.MaterialsID;
                //oldWorks.AuthorsNo = newWorks.AuthorsNo;
                oldWorks.WorksName = newWorks.WorksName;
                oldWorks.YearStart = newWorks.YearStart;
                oldWorks.YearEnd = newWorks.YearEnd;
                oldWorks.Cost = newWorks.Cost;
                oldWorks.Purchase = newWorks.Price;
                //oldWorks.GrossMargin = newWorks.GrossMargin = Math.Round((((Convert.ToDouble((newWorks.Price / double.Parse("1.05"))) - Convert.ToDouble(newWorks.Cost)) / Convert.ToDouble((newWorks.Price / double.Parse("1.05")))) * Convert.ToDouble(100)), 3); ;
                //oldWorks.PricingDate = newWorks.PricingDate;
                oldWorks.Artisticability = newWorks.Artisticability;
                oldWorks.Marketability = newWorks.Marketability;
                oldWorks.Packageability = newWorks.Packageability;
                oldWorks.Valuability = newWorks.Valuability;
                oldWorks.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                oldWorks.ModifyDate = System.DateTime.Now;
                oldWorks.Remarks = newWorks.Remarks;
                oldWorks.ChangeState = "Complete";
                oldWorks.WorkSize = newWorks.WorkSize;
                oldWorks.TotalInventory = newWorks.TotalInventory;
                oldWorks.GenreName = newWorks.GenreName;
                oldWorks.Material = newWorks.Material;
                oldWorks.MaterialEng = newWorks.MaterialEng;
                oldWorks.ZFVOLUME = newWorks.ZFVOLUME;
                //oldWorks.WorksSizeNo = newWorks.WorksSizeNo_InputString.Select(n => Convert.ToInt32(n)).ToArray()[0];

                //oldWorks.Rating = CalculateWorksRating(newWorks).ToString();
                //foreach (int _AuthorNo in newWorks.AuthorNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                //{
                //    var _Authors = context?.Authors?.FirstOrDefault(c => c.AuthorsNo == _AuthorNo);
                //    int _WorksAmount = (context?.WorksAuthors?.AsEnumerable().Where(c => c.Author_No == _AuthorNo).Count()).Value;
                //    int _AuthorsRating = AuthorsModel.CalculateAuthorsRating(_WorksAmount);
                //    _Authors.Rating = _AuthorsRating.ToString();
                //    _Authors.WorksAmount = _WorksAmount;
                //}
                //組件
                //foreach (WorksModuleModel _WorksModuleModel in newWorks.WorksModuleList)
                //{
                //    WorksModules _WorksModules = new WorksModules();
                //    _WorksModules.WorksNo = oldWorks.WorksNo;
                //    _WorksModules.Material = _WorksModuleModel.Material.MenuID;
                //    _WorksModules.Measure = _WorksModuleModel.Measure;

                //    _WorksModules.Length = _WorksModuleModel.Length;
                //    _WorksModules.Width = _WorksModuleModel.Width;
                //    _WorksModules.Height = _WorksModuleModel.Height;
                //    _WorksModules.Deep = _WorksModuleModel.Deep;
                //    _WorksModules.TimeLength = _WorksModuleModel.TimeLength ?? "";

                //    _WorksModules.Amount = _WorksModuleModel.Amount;
                //    _WorksModules.CountNoun = _WorksModuleModel.CountNoun.MenuID;
                //    context.WorksModules.Add(_WorksModules);
                //}
                foreach (HttpPostedFileBase _Files in newWorks.UploadWorksFiles)
                {
                    if (_Files != null)
                    {
                        WorksFilesModel.InsFile(oldWorks.WorksNo.ToString(), _Files);
                        //context.WorksFiles.Add(new WorksFiles() { WorksNo = oldWorks.WorksNo, FileBase64Str = FileUrl });
                    }
                }
                //更新藝術家
                if (newWorks.AuthorNo_InputString.Count != 0)
                {
                    foreach (int _AuthorNo in newWorks.AuthorNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        oldWorks.AuthorsNo = context.Authors.Where(x => x.AuthorsNo == _AuthorNo).Select(x => x.LIFNR).FirstOrDefault().Value;
                    }
                }

                //更新類型
                //if (newWorks.GenreNo_InputString.Count != 0)
                //{
                //    foreach (int _GenreNo in newWorks.GenreNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                //    {
                //        context.WorksPropGenre.Add(new WorksPropGenre() { WorksNo = oldWorks.WorksNo, GenreNo = _GenreNo });
                //    }
                //}

                //更新風格
                if (newWorks.StyleNo_InputString.Count != 0)
                {
                    foreach (int _StyleNo in newWorks.StyleNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.WorksPropStyle.Add(new WorksPropStyle() { WorksNo = oldWorks.WorksNo, StyleNo = _StyleNo });
                    }
                }

                //更新作品尺幅
                if (newWorks.WorksSizeNo_InputString.Count != 0)
                {
                    foreach (int _SizeNo in newWorks.WorksSizeNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    {
                        context.WorksSizes.Add(new WorksSizes() {WorksNo=oldWorks.WorksNo,SizeNo=_SizeNo });
                    }
                }

                //更新擁有者
                //if (newWorks.OwnerNo_InputString.Count != 0)
                //{
                //    foreach (int _OwnerNo in newWorks.OwnerNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                //    {
                //        context.WorksPropOwner.Add(new WorksPropOwner() { WorksNo = oldWorks.WorksNo, OwnerNo = _OwnerNo });
                //    }
                //}

                //更新庫別
                //if (newWorks.WareTypeNo_InputString.Count != 0)
                //{
                //    foreach (int _WareTypeNo in newWorks.WareTypeNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                //    {
                //        context.WorksPropWareType.Add(new WorksPropWareType() { WorksNo = oldWorks.WorksNo, WareTypeNo = _WareTypeNo });
                //    }
                //}


                //定價不可修改
                //var _Prices = context.WorksPrices.Where(x => x.MaterialsID == newWorks.MaterialsID && x.Currency == "TWD").FirstOrDefault();
                //if (_Prices != null)
                //{
                //    _Prices.Price = newWorks.Price;
                //    _Prices.PricingDate = newWorks.PricingDate;
                //}
                //else
                //{
                //    context.WorksPrices.Add(new WorksPrices {
                //        MaterialsID =newWorks.MaterialsID,
                //        Price=newWorks.Price,
                //        PricingDate=newWorks.PricingDate,
                //        Currency="TWD",
                //        CreateDate=DateTime.Now,
                //        ModifyDate=DateTime.Now,
                //        source = "Cube"
                //    });
                //}

                if (context.SaveChanges() == 0)
                {
                    return false;
                }
                else
                {
                    //foreach (int _AuthorNo in newWorks.AuthorNo_InputString.Select(n => Convert.ToInt32(n)).ToArray())
                    //{
                    //    var _Authors = context?.Authors?.FirstOrDefault(c => c.AuthorsNo == _AuthorNo);
                    //    int _WorksAmount = (context?.WorksAuthors?.AsEnumerable().Where(c => c.Author_No == _AuthorNo).Count()).Value;
                    //    int _AuthorsRating = AuthorsModel.CalculateAuthorsRating(_WorksAmount);
                    //    _Authors.Rating = _AuthorsRating.ToString();
                    //    _Authors.WorksAmount = _WorksAmount;
                    //    context.SaveChanges();
                    //}
                    
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
        /// <summary>
        /// 刪除作品
        /// </summary>
        /// <param name="WorksNo"></param>
        /// <returns></returns>
        public static bool Delete(string WorksNo)
        {
            Guid Guid_WorksNo = Guid.Parse(WorksNo.ToUpper());
            using (var context = new EG_MagicCubeEntities())
            {
                var works = context.Works.AsEnumerable().FirstOrDefault(x => x.WorksNo == Guid_WorksNo);
                if (works != null)
                {
                    works.IsDel = "Y";
                    works.ModifyUser = HttpContext.Current?.User?.Identity?.Name ?? "";
                    works.ModifyDate = DateTime.Now;
                    if (context.SaveChanges() == 0)
                    {
                        return false;
                    }
                    else
                    {
                        //重新計算作品總數
                        //找出作者AuthoNo，並計算作品總數
                        int AuthorsNo = works.AuthorsNo;
                        var Author = context.Authors.AsEnumerable().FirstOrDefault(x => x.LIFNR == AuthorsNo);
                        Author.WorksAmount = context.Works.AsEnumerable().Where(x => x.AuthorsNo == AuthorsNo && x.IsDel != "Y").Count();
                        context.SaveChanges();
                    }
                }
                else
                {
                    return false;
                }
                
            }

            return true;
        }
        #endregion

        #endregion

        /// <summary>
        /// 作品組件
        /// </summary>
        public partial class WorksModuleModel
        {
            /// <summary>
            /// 組件序號
            /// </summary>
            public int WorksModulesNo { get; set; } = 0;
            /// <summary>
            /// 作品編號
            /// </summary>
            public string WorksNo { get; set; } = "";
            /// <summary>
            /// 媒材
            /// </summary>
            public MenuViewModel Material { get; set; } = new MenuViewModel() { MenuID = 1 };
            /// <summary>
            /// 不計算尺寸
            /// </summary>
            public string Measure { get; set; } = "";
            /// <summary>
            /// 長
            /// </summary>
            public double Length { get; set; } = 0.0;
            /// <summary>
            /// 寬
            /// </summary>
            public double Width { get; set; } = 0.0;
            /// <summary>
            /// 高
            /// </summary>
            public double Height { get; set; } = 0.0;
            /// <summary>
            /// 深
            /// </summary>
            public double Deep { get; set; } = 0.0;
            /// <summary>
            /// 時間長度
            /// </summary>
            public string TimeLength { get; set; } = "";
            /// <summary>
            /// 數量
            /// </summary>
            public int Amount { get; set; } = 0;
            /// <summary>
            /// 單位詞
            /// </summary>
            public MenuViewModel CountNoun { get; set; } = new MenuViewModel() { MenuID = 1 };

        }


    }

    #endregion
}