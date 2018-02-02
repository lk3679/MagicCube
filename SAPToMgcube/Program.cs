using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


using SAP.Middleware.Connector;
using SAP.Middleware;
using SAP;
namespace SAPToMgcube
{
    class Program
    {
        static void Main(string[] args)
        {
            List<connect_sap_Mcube.ET_MASTER> _ET_MASTERList = connect_sap_Mcube.GetSap_Z_MM_ZHAW_CUBE1("20180101", "20180101");

            string s = JsonConvert.SerializeObject(_ET_MASTERList);
            Console.Write(s);
            Console.ReadLine();
        }
    }
    public class connect_sap_Mcube
    {
        public connect_sap_Mcube()
        {

        }


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

        /// <summary>
        /// 取得商品(作品)主檔
        /// </summary>
        /// <param name="P_DATE_from">異動日期起始,yyyyMMdd</param>
        /// <param name="P_DATE_TO">異動日期迄止,yyyyMMdd</param>
        /// <param name="P_DESC">作品名</param>
        /// <param name="P_YEAR">年代，傳入格式%yyyy%yyyy%，兩個年份間，及前後加百分比</param>
        /// <param name="P_NAME1">作者名名</param>
        /// <returns></returns>
        public static List<ET_MASTER> GetSap_Z_MM_ZHAW_CUBE1(string P_DATE_from, string P_DATE_TO, string P_DESC = "", string P_YEAR = "", string P_NAME1 = "")
        {

            IDestinationConfiguration ID = new MyBackendConfig();
            IRfcTable IRetTable = null;

            bool bRegistered = false;
            List<ET_MASTER> ET_MASTERList = new List<ET_MASTER>();

            try
            {
                RfcDestination rfcDest = null;
                try
                {
                    rfcDest = RfcDestinationManager.GetDestination("PRD");
                    bRegistered = true;
                }
                catch (Exception ex)
                {
                    if (ex.GetType().Name == "RfcInvalidStateException")
                    {

                    }
                }
                finally
                {
                    if (rfcDest == null && bRegistered == false)
                    {
                        bRegistered = true;
                        RfcDestinationManager.RegisterDestinationConfiguration(ID);
                        rfcDest = RfcDestinationManager.GetDestination("PRD");
                    }
                }
                RfcRepository rfcRepo = rfcDest.Repository;
                IRfcFunction IReader = rfcRepo.CreateFunction("Z_MM_ZHAW_CUBE1");
                IReader.SetValue("P_DATE_from", P_DATE_from);
                IReader.SetValue("P_DATE_TO", P_DATE_TO);
                IReader.SetValue("P_DESC", P_DESC);
                IReader.SetValue("P_YEAR", P_YEAR);
                IReader.SetValue("P_NAME1", P_NAME1);
                //每幾筆資料切成一個檔案
                //IReader.SetValue("COUNT", "1000");
                //執行查詢
                IReader.Invoke(rfcDest);
                IRetTable = IReader.GetTable("ET_MASTER");
                ET_MASTERList = IRetTable.AsEnumerable().Select(x =>
                 new ET_MASTER()
                 {
                     MATNR = x.GetString("MATNR") ?? "",
                     ZZCT = x.GetString("ZZCT") ?? "",
                     NAME1 = x.GetString("NAME1") ?? "",
                     ZFPRESERVE_D = x.GetString("ZFPRESERVE_D") ?? "",
                     ZZSE = x.GetString("ZZSE") ?? "",
                     LOCATION = x.GetString("LOCATION") ?? "",
                     STATUS = x.GetString("STATUS") ?? "",
                     STPRS = x.GetString("STPRS") ?? "",
                     NETPR = x.GetString("NETPR") ?? "",
                     WAERS = x.GetString("WAERS") ?? "",
                     ERDAT = x.GetString("ERDAT") ?? "",
                     UDATE = x.GetString("UDATE") ?? ""
                 }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (bRegistered)
                    RfcDestinationManager.UnregisterDestinationConfiguration(ID);

            }

            return ET_MASTERList;
        }

        /// <summary>
        /// 取得供應商(藝術家)主檔
        /// </summary>
        /// <param name="P_DATE_from">異動日期起始,yyyyMMdd</param>
        /// <param name="P_DATE_TO">異動日期迄止,yyyyMMdd</param>
        /// <param name="P_NAME1">藝術家名</param>
        /// <returns></returns>
        public static List<ET_VENDOR> GetSap_Z_MM_ZHAW_CUBE2(string P_DATE_from, string P_DATE_TO, string P_NAME1)
        {

            IDestinationConfiguration ID = new MyBackendConfig();
            IRfcTable IRetTable = null;

            bool bRegistered = false;
            List<ET_VENDOR> ET_VENDORList = new List<ET_VENDOR>();

            try
            {
                RfcDestination rfcDest = null;
                try
                {
                    rfcDest = RfcDestinationManager.GetDestination("PRD");
                    bRegistered = true;
                }
                catch (Exception ex)
                {
                    if (ex.GetType().Name == "RfcInvalidStateException")
                    {

                    }
                }
                finally
                {
                    if (rfcDest == null && bRegistered == false)
                    {
                        bRegistered = true;
                        RfcDestinationManager.RegisterDestinationConfiguration(ID);
                        rfcDest = RfcDestinationManager.GetDestination("PRD");
                    }
                }
                RfcRepository rfcRepo = rfcDest.Repository;
                IRfcFunction IReader = rfcRepo.CreateFunction("Z_MM_ZHAW_CUBE2");
                IReader.SetValue("P_DATE_from", P_DATE_from);
                IReader.SetValue("P_DATE_TO", P_DATE_TO);
                IReader.SetValue("P_NAME1", P_NAME1);
                //每幾筆資料切成一個檔案
                //IReader.SetValue("COUNT", "1000");
                //執行查詢
                IReader.Invoke(rfcDest);
                IRetTable = IReader.GetTable("ET_VENDOR");

                ET_VENDORList = IRetTable.AsEnumerable().Select(x =>
                 new ET_VENDOR()
                 {
                     NAME1 = x.GetString("NAME1"),
                     LIFNR = x.GetString("LIFNR"),
                     SORTL = x.GetString("SORTL"),
                     LAND1 = x.GetString("LAND1"),
                     ERDAT = x.GetString("ERDAT"),
                     UDATE = x.GetString("UDATE") ?? ""
                 }).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (bRegistered)
                    RfcDestinationManager.UnregisterDestinationConfiguration(ID);

            }

            return ET_VENDORList;
        }

        public class MyBackendConfig : IDestinationConfiguration
        {

            public RfcConfigParameters GetParameters(String destinationName)
            {
                RfcConfigParameters parms = null;
                if ("PRD".Equals(destinationName))
                {
                    parms = new RfcConfigParameters();
                    #region 正式機
                    parms.Add(RfcConfigParameters.AppServerHost, "192.168.82.8");   //SAP主机IP
                                                                                    //parms.Add(RfcConfigParameters.AppServerHost, "192.168.82.27");   //SAP主机IP
                    parms.Add(RfcConfigParameters.SystemNumber, "00");  //SAP实例
                    parms.Add(RfcConfigParameters.User, "portal");  //用户名
                    parms.Add(RfcConfigParameters.Password, "v25vd2am");  //密码
                    parms.Add(RfcConfigParameters.Client, "800");  // Client
                    parms.Add(RfcConfigParameters.Language, "zf");  //登陆语言
                                                                    //parms.Add(RfcConfigParameters.SystemID, "ESP");  //登陆语言
                    parms.Add(RfcConfigParameters.PoolSize, "5");
                    parms.Add(RfcConfigParameters.MaxPoolSize, "10");
                    parms.Add(RfcConfigParameters.IdleTimeout, "600");
                    #endregion
                }
                else if ("HKP".Equals(destinationName))
                {
                    parms = new RfcConfigParameters();
                    #region 正式機
                    parms.Add(RfcConfigParameters.AppServerHost, "192.168.78.110");   //SAP主机IP
                                                                                      //parms.Add(RfcConfigParameters.AppServerHost, "192.168.78.111");   //SAP主机IP
                    parms.Add(RfcConfigParameters.SystemNumber, "73");  //SAP实例
                    parms.Add(RfcConfigParameters.User, "NETAGE");  //用户名
                    parms.Add(RfcConfigParameters.Password, "NETAGE");  //密码
                    parms.Add(RfcConfigParameters.Client, "810");  // Client
                    parms.Add(RfcConfigParameters.Language, "zf");  //登陆语言
                                                                    //parms.Add(RfcConfigParameters.SystemID, "HKP");  //登陆语言
                    parms.Add(RfcConfigParameters.PoolSize, "5");
                    parms.Add(RfcConfigParameters.MaxPoolSize, "10");
                    parms.Add(RfcConfigParameters.IdleTimeout, "600");
                    #endregion
                }
                return parms;

            }

            public bool ChangeEventsSupported()
            {

                return false;

            }

            public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        }
    }

}
