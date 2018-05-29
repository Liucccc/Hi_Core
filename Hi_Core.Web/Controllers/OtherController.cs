using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hi_Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hi_Core.Web.Controllers
{
    public class OtherController : Controller
    {
        private readonly IInfoService _infoService;
        public OtherController(IInfoService infoService)
        {
            _infoService = infoService;
        }
        public IActionResult Index(int iid)
        {
            var data = _infoService.FindById(iid);
            ViewBag.m = data;
            return View();
        }
    }
}