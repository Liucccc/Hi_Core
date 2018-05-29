using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hi_Core.Web.Models
{
    public class ArticleSortGrid
    {
        public static Hi_Core.Domain.JQGridModel Index()
        {
            List<Hi_Core.Domain.JQGridColumnModel> lst = new List<Hi_Core.Domain.JQGridColumnModel>();
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "主键", name = "Asid", index = "Aid", hidden = "true" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "名称", name = "Stitle", index = "Stitle", hidden = "false", align = "left", sortable = "true", width = "100" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "有效", name = "Alive", index = "Alive", hidden = "false", align = "center", sortable = "true", width = "50", formatter = "showStatus" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "序号", name = "Layer", index = "Layer", hidden = "false", align = "center", sortable = "true", width = "50" });


            Hi_Core.Domain.JQGridModel model = new Domain.JQGridModel
            {
                GridID = "ArticleSort_gridTable",
                url = "/ArticleSort/GetJQGridJson",
                pager = "ArticleSort_PagerGrid",
                sortname = "Alive desc,Layer",
                sortorder = "",
                rownumbers = true,
                viewrecords = true,
                multiselect = true,
                colModel = lst
            };

            return model;
        }
    }
}
