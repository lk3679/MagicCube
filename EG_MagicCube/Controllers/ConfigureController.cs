using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models;
namespace EG_MagicCube.Controllers
{
    public class ConfigureController : Controller
    {
        // GET: Configure
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(string id)
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection formcollection)
        {

            return RedirectToAction("Index");
        }
    }
}