using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hi_Core.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message)
        {
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(new { IsSucceeded = true, Message = message }));
        }
        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Error(string message)
        {
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(new { IsSucceeded = false, Message = message }));
        }
    }
}