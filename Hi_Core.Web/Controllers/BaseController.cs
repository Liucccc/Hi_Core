using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hi_Core.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual IActionResult Success(string message)
        {
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(new { IsSucceeded = true, Message = message }));
        }
        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual IActionResult Error(string message)
        {
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(new { IsSucceeded = false, Message = message }));
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            byte[] result;
            filterContext.HttpContext.Session.TryGetValue("Hi_Core_adminUsers", out result);
            //if (result == null)
            //{
            //    filterContext.Result = new RedirectResult("/Account/Login");
            //    return;
            //}
            base.OnActionExecuting(filterContext);
        }
    }
}