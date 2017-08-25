using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EG_MagicCube.Controllers
{
    public class VerificationCodeController : Controller
    {
        // GET: VerificationCode
        public PartialViewResult Index()
        {
            return PartialView();
        }

        public ContentResult VerificationCode()
        {
            // 是否產生驗證碼
            bool isCreate = true;

            Response.ContentType = "image/gif";
            //建立 Bitmap 物件和繪製
            Bitmap basemap = new Bitmap(150, 60);
            Graphics graph = Graphics.FromImage(basemap);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, 150, 60);
            Font font = new Font(FontFamily.GenericSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel);
            Random random = new Random();
            // 英數
            //string letters = "ABCDEFGHIJKLMNPQRSTUVWXYZabcdefghijklmnpqrstuvwxyz0123456789";
            // 天干地支生肖
            // string letters = "甲乙丙丁戊己庚辛壬癸子丑寅卯辰巳午未申酉戍亥鼠牛虎免龍蛇馬羊猴雞狗豬";

            // 隨機數字
            string letters = "";
            int number;
            char code;
            for (int i = 0; i < 4; i++)
            {
                number = random.Next();
                switch (number % 3)
                {
                    default:
                        code = (char)('0' + (char)(number % 10));
                        break;
                }
                letters += code.ToString();
            }
            string letter;
            StringBuilder sb = new StringBuilder();
            // 混亂背景
            Pen linePen = new Pen(new SolidBrush(Color.FromArgb(100, 100, 100)), 2);
            for (int x = 0; x < 60; x++)
            {
                graph.DrawLine(linePen, new Point(random.Next(0, 149), random.Next(0, 59)), new Point(random.Next(0, 149), random.Next(0, 59)));
            }
            if (isCreate)
            {
                // 加入隨機二個字
                // 英文4 ~ 5字，中文2 ~ 3字
                for (int word = 0; word < 4; word++)
                {
                    letter = letters.Substring(word, 1);
                    sb.Append(letter);
                    // 繪製字串 
                    graph.DrawString(letter, font, new SolidBrush(Color.Black), word * 38, random.Next(0, 15));
                }
            }
            else
            {
                // 使用先前的驗證碼來產生
                string currentCode = Session["ValidateCode"].ToString();
                sb.Append(currentCode);
                foreach (char item in currentCode)
                {
                    letter = item.ToString();
                    // 繪製字串
                    graph.DrawString(letter, font, new SolidBrush(Color.Black), currentCode.IndexOf(item) * 38, random.Next(0, 15));
                }
            }
            MemoryStream stream = new MemoryStream();
            //// 儲存圖片並輸出至stream      
            basemap.Save(stream, ImageFormat.Gif);
            byte[] imageBytes = stream.ToArray();
            stream.Close();
            string strB64 = "data:image/gif;base64," + Convert.ToBase64String(imageBytes);

            // 將產生字串儲存至 Sesssion
            Session["ValidateCode"] = sb.ToString();
            return Content(strB64);
        }

        public ActionResult ValidateCode(string InputCode)
        {
            if (InputCode == null)
                return Content("輸入空白");

            if (InputCode.Trim().ToLower().Equals(Session["ValidateCode"].ToString().ToLower()))
            {
                return Content("成功");
            }
            else
            {
                return Content("失敗");
            }
        }
    }
}