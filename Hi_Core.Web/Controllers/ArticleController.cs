using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hi_Core.Services;
using Hi_Core.Repositories;
using Newtonsoft.Json;

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
        public IActionResult GetJQGridJson(int page, int rows)
        {
            var data = _articleService.FindPagedList(null, "Aid", page);
            return Content(JsonConvert.SerializeObject(new { page = page, total = data.total, records = data.records, rows = data }));
        }
        #endregion
    }

    /// <summary>
    /// 分页参数
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// 每页行数
        /// </summary>
        public int rows { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 排序列
        /// </summary>
        public string sidx { get; set; }
        /// <summary>
        /// 排序类型
        /// </summary>
        public string sord { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int records { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int total
        {
            get
            {
                if (records > 0)
                {
                    return records % this.rows == 0 ? records / this.rows : records / this.rows + 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 查询条件Json
        /// </summary>
        public string conditionJson { get; set; }
    }
}