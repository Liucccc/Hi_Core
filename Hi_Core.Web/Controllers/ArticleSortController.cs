using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hi_Core.Services;

namespace Hi_Core.Web.Controllers
{
    public class ArticleSortController : Controller
    {
        private readonly IArticleSortService _articleSortService;
        public ArticleSortController(IArticleSortService articleSortService)
        {
            _articleSortService = articleSortService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetListJson()
        {
            var data = _articleSortService.FindAll();
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
        }
    }
}