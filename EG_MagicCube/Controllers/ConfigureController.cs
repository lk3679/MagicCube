using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EG_MagicCube.Models;
using EG_MagicCube.Models.ViewModel;
namespace EG_MagicCube.Controllers
{
    public class ConfigureController : BaseController
    {
        // GET: Configure
        public ActionResult Index()
        {
            ConfigureViewModels _ConfigureViewModels = new ConfigureViewModels();
            _ConfigureViewModels.OpenDays = SystemGeneralModel.GetConfigure(SystemGeneralModel.ConfigureClassEnum.OpenDays.ToString()).ConfigureContent;
            _ConfigureViewModels.EmptyContent = SystemGeneralModel.GetConfigure(SystemGeneralModel.ConfigureClassEnum.EmptyContent.ToString()).ConfigureContent;
            _ConfigureViewModels.ErrorContent = SystemGeneralModel.GetConfigure(SystemGeneralModel.ConfigureClassEnum.ErrorContent.ToString()).ConfigureContent;
            _ConfigureViewModels.OverDayContent = SystemGeneralModel.GetConfigure(SystemGeneralModel.ConfigureClassEnum.OverDayContent.ToString()).ConfigureContent;
            return View(_ConfigureViewModels);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string id, FormCollection formcollection)
        {
            SystemGeneralModel _SystemGeneralModel_OpenDays = new SystemGeneralModel();
            _SystemGeneralModel_OpenDays = _SystemGeneralModel_OpenDays.ReturnConfigure("OpenDays");
            _SystemGeneralModel_OpenDays.ConfigureContent = formcollection["OpenDays"];
            _SystemGeneralModel_OpenDays.Update();

            SystemGeneralModel _SystemGeneralModel_EmptyContent = new SystemGeneralModel();
            _SystemGeneralModel_EmptyContent = _SystemGeneralModel_EmptyContent.ReturnConfigure("EmptyContent");
            _SystemGeneralModel_EmptyContent.ConfigureContent = formcollection["EmptyContent"];
            _SystemGeneralModel_EmptyContent.Update();

            SystemGeneralModel _SystemGeneralModel_ErrorContent = new SystemGeneralModel();
            _SystemGeneralModel_ErrorContent = _SystemGeneralModel_ErrorContent.ReturnConfigure("ErrorContent");
            _SystemGeneralModel_ErrorContent.ConfigureContent = formcollection["ErrorContent"];
            _SystemGeneralModel_ErrorContent.Update();

            SystemGeneralModel _SystemGeneralModel_OverDayContent = new SystemGeneralModel();
            _SystemGeneralModel_OverDayContent = _SystemGeneralModel_OverDayContent.ReturnConfigure("OverDayContent");
            _SystemGeneralModel_OverDayContent.ConfigureContent = formcollection["OverDayContent"];
            _SystemGeneralModel_OverDayContent.Update();

            return RedirectToAction("Index");
        }
    }
}