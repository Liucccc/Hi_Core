using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hi_Core.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string userPwd)
        {
            //return Json(new { type = 2, message = "用户名密码错误！" });
            //var msg = await a.a();
            return Json(new { type = 1, message = "" });
        }
    }
}