using EG_MagicCubeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EG_MagicCube.Models
{
    public class FromSAPModel
    {
        public class ET_MASTER
        {
            /// <summary>
            /// 商品號碼
            /// </summary>
            private string _MATNR = "";
            /// <summary>
            /// 品名
            /// </summary>
            private string _ZZCT = "";
            /// <summary>
            /// 藝術家號
            /// </summary>
            private string _NAME1 = "";
            /// <summary>
            /// 年代
            /// </summary>
            private string _ZFPRESERVE_D = "";
            /// <summary>
            /// 尺寸
            /// </summary>
            private string _ZZSE = "";
            /// <summary>
            /// 據點
            /// </summary>
            private string _LOCATION = "";
            /// <summary>
            /// 所有人
            /// </summary>
            private string _STATUS = "";
            /// <summary>
            /// 成本
            /// </summary>
            private string _STPRS = "";
            /// <summary>
            /// 定價
            /// </summary>
            private string _NETPR = "";
            /// <summary>
            /// 幣別
            /// </summary>
            private string _WAERS = "";
            /// <summary>
            /// 建立日
            /// </summary>
            private string _ERDAT = "";
            /// <summary>
            /// 異動日
            /// </summary>
            private string _UDATE = "";
            /// <summary>
            /// 商品號碼
            /// </summary>
            public string MATNR { get { return _MATNR; } set { _MATNR = value; } }
            /// <summary>
            /// 作品品名
            /// </summary>
            public string ZZCT { get { return _ZZCT; } set { _ZZCT = value; } }
            /// <summary>
            /// 藝術家名稱
            /// </summary>
            public string NAME1 { get { return _NAME1; } set { _NAME1 = value; } }
            /// <summary>
            /// 年代
            /// </summary>
            public string ZFPRESERVE_D { get { return _ZFPRESERVE_D; } set { _ZFPRESERVE_D = value; } }
            /// <summary>
            /// 尺寸
            /// </summary>
            public string ZZSE { get { return _ZZSE; } set { _ZZSE = value; } }
            /// <summary>
            /// 庫別
            /// </summary>
            public string LOCATION { get { return _LOCATION; } set { _LOCATION = value; } }
            /// <summary>
            /// 所有人
            /// </summary>
            public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
            /// <summary>
            /// 成本
            /// </summary>
            public string STPRS { get { return _STPRS; } set { _STPRS = value; } }
            /// <summary>
            /// 定價
            /// </summary>
            public string NETPR { get { return _NETPR; } set { _NETPR = value; } }
            /// <summary>
            /// 幣別
            /// </summary>
            public string WAERS { get { return _WAERS; } set { _WAERS = value; } }
            /// <summary>
            /// 建立日
            /// </summary>
            public string ERDAT { get { return _ERDAT; } set { _ERDAT = value; } }
            /// <summary>
            /// 異動日
            /// </summary>
            public string UDATE { get { return _UDATE; } set { _UDATE = value; } }

            //private bool Insert()
            //{
            //    bool IsInsert = false;
            //    using (var context = new EG_MagicCubeEntities())
            //    {
            //        context.ET_MASTER.Add(new EG_MagicCubeEntity.ET_MASTER()
            //        {

            //            MATNR = this.MATNR,
            //            ZZCT = this.ZZCT,
            //            NAME1 = this.NAME1,
            //            ZFPRESERVE_D = this.ZFPRESERVE_D,
            //            ZZSE = this.ZZSE,
            //            LOCATION = this.LOCATION,
            //            STATUS = this.STATUS,
            //            STPRS = this.STPRS,
            //            NETPR = this.NETPR,
            //            WAERS = this.WAERS,
            //            ERDAT = this.ERDAT,
            //            UDATE = this.UDATE,
            //        });
            //        if (context.SaveChanges() == 0)
            //        {

            //            IsInsert = true;
            //        }
                    
            //    }
            //    return IsInsert;
            //}
            //public static bool BatchInsert(ET_MASTER [] ET_MASTERArray)
            //{
            //    bool IsInsert = false;
            //    using (var context = new EG_MagicCubeEntities())
            //    {
            //        foreach (var _ET_MASTER in ET_MASTERArray)
            //        {

            //            context.ET_MASTER.Add(new EG_MagicCubeEntity.ET_MASTER()
            //            {

            //                MATNR = _ET_MASTER.MATNR,
            //                ZZCT = _ET_MASTER.ZZCT,
            //                NAME1 = _ET_MASTER.NAME1,
            //                ZFPRESERVE_D = _ET_MASTER.ZFPRESERVE_D,
            //                ZZSE = _ET_MASTER.ZZSE,
            //                LOCATION = _ET_MASTER.LOCATION,
            //                STATUS = _ET_MASTER.STATUS,
            //                STPRS = _ET_MASTER.STPRS,
            //                NETPR = _ET_MASTER.NETPR,
            //                WAERS = _ET_MASTER.WAERS,
            //                ERDAT = _ET_MASTER.ERDAT,
            //                UDATE = _ET_MASTER.UDATE,
            //                CreateTime = DateTime.Now,
            //                IsNew="N",
            //                IsSync="",
            //                SyncTime=null,
            //                SyncUser=""

            //            });
            //        }
            //        if (context.SaveChanges() == 0)
            //        {
            //            IsInsert = true;
            //        }

            //    }
            //    return IsInsert;
            //}

        }
        
        public class ET_VENDOR
        {
            /// <summary>
            /// 供應商名稱
            /// </summary>
            private string _NAME1 = "";
            /// <summary>
            /// 供應商編號
            /// </summary>
            private string _LIFNR = "";
            /// <summary>
            /// 別名(搜尋條件1)
            /// </summary>
            private string _SORTL = "";
            /// <summary>
            /// 國別
            /// </summary>
            private string _LAND1 = "";
            /// <summary>
            /// //建立日
            /// </summary>
            private string _ERDAT = "";
            /// <summary>
            /// 異動日
            /// </summary>
            private string _UDATE = "";
            /// <summary>
            /// 供應商名稱
            /// </summary>
            public string NAME1 { get { return _NAME1; } set { _NAME1 = value; } }
            /// <summary>
            /// 供應商編號
            /// </summary>
            public string LIFNR { get { return _LIFNR; } set { _LIFNR = value; } }
            /// <summary>
            /// 別名(搜尋條件1)
            /// </summary>
            public string SORTL { get { return _SORTL; } set { _SORTL = value; } }
            /// <summary>
            /// 國別
            /// </summary>
            public string LAND1 { get { return _LAND1; } set { _LAND1 = value; } }
            /// <summary>
            /// //建立日
            /// </summary>
            public string ERDAT { get { return _ERDAT; } set { _ERDAT = value; } }
            /// <summary>
            /// 異動日
            /// </summary>
            public string UDATE { get { return _UDATE; } set { _UDATE = value; } }
        }

    }
}