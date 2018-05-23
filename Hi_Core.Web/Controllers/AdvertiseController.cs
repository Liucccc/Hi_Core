using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hi_Core.Services;
using Microsoft.AspNetCore.Mvc;
using Hi_Core.Domain.Entities;

namespace Hi_Core.Web.Controllers
{
    public class AdvertiseController : BaseController
    {
        private readonly IAdvertiseService _advertiseService;
        public AdvertiseController(IAdvertiseService advertiseService)
        {
            _advertiseService = advertiseService;
        }

        public IActionResult Index(int k)
        {
            ViewBag.Kind = k;
            return View();
        }

        [HttpGet]
        public IActionResult GetFromJson(int id)
        {
            var data = _advertiseService.FindById(id);
            return Json(data);
        }

        [HttpPost]
        public IActionResult SaveForm(Hi_Core_Advertise m)
        {
            return Success("保存成功！");
        }
    }
}