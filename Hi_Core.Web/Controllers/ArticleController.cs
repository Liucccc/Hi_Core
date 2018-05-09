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
    public class ArticleController : BaseController
    {
        private readonly IArticleService _articleService;
        private readonly IViewArticleService _viewArticleService;

        public ArticleController(IViewArticleService viewArticleService, IArticleService articleService)
        {
            _viewArticleService = viewArticleService;
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
            #region ==查询条件==
            StringBuilder where = new StringBuilder();
            if (!string.IsNullOrEmpty(queryJson))
            {
                var ModelQ = Newtonsoft.Json.JsonConvert.DeserializeObject<queryJson>(queryJson);
                where.Append(" and Kind=" + ModelQ.Kind);
                if (!string.IsNullOrEmpty(ModelQ.Atitle))
                    where.Append(" and Atitle like '%" + ModelQ.Atitle + "%'");
                if (!string.IsNullOrEmpty(ModelQ.Atime))
                {
                    string[] Atime = ModelQ.Atime.Split("至");
                    where.Append(" and DATEDIFF(DAY,Atime,'" + Atime[0].ToString().Trim() + "')<=0 and DATEDIFF(DAY,Atime,'" + Atime[1].ToString().Trim() + "')>=0");
                }
                if (!string.IsNullOrEmpty(ModelQ.Asid))
                    where.Append(" and Asid in(" + ModelQ.Asid + ")");
                if (ModelQ.Alive)
                    where.Append(" and Alive=0");
                if (ModelQ.Hot)
                    where.Append(" and Hot=1");
                if (ModelQ.Recommend)
                    where.Append(" and Recommend=1");
            }
            #endregion

            var data = _viewArticleService.FindPagedList(where.ToString(), pagination.sidx + " " + pagination.sord, pagination.page, pagination.rows);
            return Content(JsonConvert.SerializeObject(new { page = pagination.page, total = data.total, records = data.records, rows = data }));
        }
        class queryJson
        {
            public int Kind { get; set; }
            public string Atitle { get; set; }
            public string Atime { get; set; }
            public string Asid { get; set; }
            public bool Alive { get; set; }
            public bool Hot { get; set; }
            public bool Recommend { get; set; }
        }
        #endregion

        #region ==添加编辑==
        public IActionResult Add(int? k, int? id)
        {
            return View();
        }
        #endregion

        #region ==删除==
        public IActionResult Del(string ids)
        {
            var res = _articleService.Delete(m => ids.Contains(m.Aid.ToString()));
            if (res)
                return Success("删除成功！");
            else
                return Error("删除失败！");
        }
        #endregion

        #region ==热点==
        public IActionResult Hot(int id)
        {
            var data = _articleService.FindById(id);
            bool res = false;
            if (data.Hot)
                res = _articleService.Update(m => new Hi_Core_Article { Hot = false }, m => m.Aid == id);
            else
                res = _articleService.Update(m => new Hi_Core_Article { Hot = true }, m => m.Aid == id);

            if (res)
                return Success("操作成功！");
            else
                return Error("操作失败！");
        }
        #endregion

        #region ==推荐==
        public IActionResult Recommend(int id)
        {
            var data = _articleService.FindById(id);
            bool res = false;
            if (data.Recommend)
                res = _articleService.Update(m => new Hi_Core_Article { Recommend = false }, m => m.Aid == id);
            else
                res = _articleService.Update(m => new Hi_Core_Article { Recommend = true }, m => m.Aid == id);

            if (res)
                return Success("操作成功！");
            else
                return Error("操作失败！");
        }
        #endregion

        #region ==屏蔽==
        [HttpPost]
        public IActionResult AliveFalse(string ids)
        {
            var res = _articleService.Update(m => new Hi_Core_Article() { Alive = false }, m => ids.Contains(m.Aid.ToString()));
            if (res)
                return Success("屏蔽成功！");
            else
                return Error("屏蔽失败！");
        }
        #endregion

        #region ==启用==
        [HttpPost]
        public IActionResult AliveTrue(string ids)
        {
            var res = _articleService.Update(m => new Hi_Core_Article() { Alive = true }, m => ids.Contains(m.Aid.ToString()));
            if (res)
                return Success("启用成功！");
            else
                return Error("启用失败！");
        }
        #endregion
    }
}