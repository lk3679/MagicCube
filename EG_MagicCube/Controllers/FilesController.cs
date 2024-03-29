﻿using EG_MagicCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace EG_MagicCube.Controllers
{
    public class FilesController : BaseController
    {
        [AllowAnonymous]
        // GET: Files
        public ActionResult Index(string id)
        {
            List<WorksFilesModel.FileGroup> Model = new List<WorksFilesModel.FileGroup>();
            if (!string.IsNullOrEmpty(id))
            {
                Model = WorksFilesModel.GetFileList(id);
            }
            return PartialView(Model);
        }
        /// <summary>
        /// 回傳圖片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FileStreamResult Img(int id)
        {
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(WorksFilesModel.GetFile(id)));
            return new FileStreamResult(ms, "image/jpg");
        }
        // GET: Files/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Files/Create
        [HttpPost]
        public ActionResult Create(string id ,List<HttpPostedFileBase> Img)
        {
            //try
            //{
                WorksFilesModel.InsFile(id, Img);

                return RedirectToAction("Edit" , new { id = id});
            //}
            //catch(Exception exp)
            //{
            //    return RedirectToAction("Edit", new { id = id });
            //}
        }

        // GET: Files/Edit/5
        public ActionResult Edit(string id)
        {
            
            List<WorksFilesModel.FileGroup> Model = new List<WorksFilesModel.FileGroup>();
            if (!string.IsNullOrEmpty(id))
            {
                Model = WorksFilesModel.GetFileList(id);
                //ViewBag.pn = id;
                return View(Model);
            }
            else
            {
                return RedirectToAction("Index", "Works");
            }
        }

        // POST: Files/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Files/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Files/Delete/5
        [HttpPost]
        public JsonResult Delete(string[] id)
        {
            // TODO: Add delete logic here
            List<long> value = new List<long>();
            for(int i = 0; i < id.Length; i++)
            {
                value.Add(Convert.ToInt64(id[i]));
            }
            var _r = WorksFilesModel.DelFile(value);
            return Json(_r);

        }

        [HttpPost]
        public JsonResult UPdateSorting(WorksFilesModel.FileSortingItem [] data)
        {
            // TODO: Add delete logic here
            return Json(WorksFilesModel.UpdateSorting(data));

        }
    }
}
