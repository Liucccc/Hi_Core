using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hi_Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hi_Core.Web.Controllers
{
    public class OtherController : BaseController
    {
        private readonly IInfoService _infoService;
        private readonly IInitService _initService;
        public OtherController(IInfoService infoService,IInitService initService)
        {
            _infoService = infoService;
            _initService = initService;
        }

        #region ==Info==
        public IActionResult Index(int iid)
        {
            var data = _infoService.FindById(iid);
            ViewBag.m = data;
            return View();
        }

        public IActionResult SaveForm(Hi_Core.Domain.Entities.Hi_Core_Info m)
        {
            var data = _infoService.FindById(m.Iid);
            m.Ititle = data.Ititle;
            m.Type = data.Type;
            bool res = _infoService.Update(m);
            if (res)
                return Success("保存成功！");
            else
                return Error("保存失败！");
        }
        #endregion

        #region ==Init==
        public IActionResult Set()
        {
            var data = _initService.FindAll();
            ViewBag.m = data;
            return View();
        }

        public IActionResult SetSaveForm(string str)
        {
            return Success("保存成功！");
        }
        #endregion
    }
}