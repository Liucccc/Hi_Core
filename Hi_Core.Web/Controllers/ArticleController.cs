using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hi_Core.Services;
using Hi_Core.Repositories;
using Newtonsoft.Json;
using System.Linq.Expressions;
using Hi_Core.Domain.Entities;
using Hi_Core.Common;
using System.Text;

namespace Hi_Core.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index(int k)
        {
            ViewBag.Kind = k;
            return View();
        }

        #region ==获取JQGrid列表==
        public IActionResult GetJQGridJson(Hi_Core.Domain.Pagination pagination, string queryJson = "")
        {
            StringBuilder where = new StringBuilder();
            if (!string.IsNullOrEmpty(queryJson))
            {
                var ModelQ = Newtonsoft.Json.JsonConvert.DeserializeObject<Hi_Core_Article>(queryJson);
                if (!string.IsNullOrEmpty(ModelQ.Atitle))
                    where.Append(" and Atitle like '%" + ModelQ.Atitle + "%'");
                if (!string.IsNullOrEmpty(ModelQ.Atime.ToString()))
                    where.Append(" and Atime = '" + Convert.ToDateTime(ModelQ.Atime).ToString("yyyy-MM-dd") + "'");
            }

            var data = _articleService.FindPagedList(where.ToString(), pagination.sidx + " " + pagination.sord, pagination.page, pagination.rows);
            return Content(JsonConvert.SerializeObject(new { page = pagination.page, total = data.total, records = data.records, rows = data }));
        }
        #endregion
    }
}