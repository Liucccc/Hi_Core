using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hi_Core.Services;
using Hi_Core.Repositories;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Hi_Core.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region ==获取JQGrid列表==
        public IActionResult GetJQGridJson(Hi_Core.Domain.Pagination pagination, string queryJson = "")
        {
            var data = _articleService.FindPagedList(m => m.Aid == 1, pagination.sidx + " " + pagination.sord, pagination.page, pagination.rows);
            return Content(JsonConvert.SerializeObject(new { page = pagination.page, total = data.total, records = data.records, rows = data }));
        }
        #endregion
    }
}