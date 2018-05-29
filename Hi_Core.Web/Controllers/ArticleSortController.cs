using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hi_Core.Services;
using System.Text;
using Newtonsoft.Json;
using Hi_Core.Domain.Entities;

namespace Hi_Core.Web.Controllers
{
    public class ArticleSortController : BaseController
    {
        private readonly IArticleSortService _articleSortService;
        public ArticleSortController(IArticleSortService articleSortService)
        {
            _articleSortService = articleSortService;
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
                if (!string.IsNullOrEmpty(ModelQ.Stitle))
                    where.Append(" and Stitle like '%" + ModelQ.Stitle + "%'");
                if (ModelQ.Alive)
                    where.Append(" and Alive=0");
            }
            #endregion

            var data = _articleSortService.FindPagedList(where.ToString(), pagination.sidx + " " + pagination.sord, pagination.page, pagination.rows);
            return Content(JsonConvert.SerializeObject(new { page = data.page, total = data.total, records = data.records, rows = data }));
        }
        class queryJson
        {
            public int Kind { get; set; }
            public string Stitle { get; set; }
            public bool Alive { get; set; }
        }
        #endregion

        #region ==添加编辑==
        public IActionResult Add(int k, int? id)
        {
            ViewBag.Kind = k;
            return View();
        }
        #endregion

        #region ==获得表单数据==
        [HttpGet]
        public IActionResult GetFromJson(int id)
        {
            var data = _articleSortService.FindById(id);
            return Json(data);
        }
        #endregion

        #region ==保存表单==
        public IActionResult SaveForm(Hi_Core_ArticleSort m)
        {
            try
            {
                m.Alive = true;
                var data = _articleSortService.FindByClause(s => s.Stitle == m.Stitle && s.Kind == m.Kind && s.Asid != m.Asid);
                if (data != null)
                    return Error("此名称已存在！");
                if (m.Asid > 0)
                {
                    //编辑
                    var model = _articleSortService.FindById(m.Asid);
                    m.Layer = model.Layer;
                    m.Alive = model.Alive;
                    bool res = _articleSortService.Update(m);
                    return Success("编辑成功！");
                }
                else
                {
                    //添加
                    long Asid = _articleSortService.Insert(m);
                    return Success("添加成功！");
                }
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        #endregion

        #region ==删除==
        public IActionResult Del(string ids)
        {
            string[] id = ids.Split(',');
            var res = _articleSortService.Delete(m => id.Contains(m.Asid.ToString()));
            if (res)
                return Success("删除成功！");
            else
                return Error("删除失败！");
        }
        #endregion

        #region ==屏蔽==
        [HttpPost]
        public IActionResult AliveFalse(string ids)
        {
            string[] id = ids.Split(',');
            var res = _articleSortService.Update(m => new Hi_Core_ArticleSort() { Alive = false }, m => id.Contains(m.Asid.ToString()));
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
            string[] id = ids.Split(',');
            var res = _articleSortService.Update(m => new Hi_Core_ArticleSort() { Alive = true }, m => id.Contains(m.Asid.ToString()));
            if (res)
                return Success("启用成功！");
            else
                return Error("启用失败！");
        }
        #endregion
        #region ==获得下拉列表Json==
        public IActionResult GetListJson()
        {
            var data = _articleSortService.FindAll();
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
        }
        #endregion
    }
}