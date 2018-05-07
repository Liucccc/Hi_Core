using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hi_Core.Web.Models
{
    public class ArticleGrid
    {
        public static Hi_Core.Domain.JQGridModel Index()
        {
            List<Hi_Core.Domain.JQGridColumnModel> lst = new List<Hi_Core.Domain.JQGridColumnModel>();
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "主键", name = "Aid", index = "Aid", hidden = "true" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "标题", name = "Atitle", index = "Atitle", hidden = "false", align = "left", sortable = "true", width = "200" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "链接", name = "Url", index = "Url", hidden = "false", align = "left", sortable = "true", width = "200" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "来源", name = "Source", index = "Source", hidden = "false", align = "left", sortable = "true", width = "100" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "作者", name = "Author", index = "Author", hidden = "false", align = "center", sortable = "true", width = "100" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "提交日期", name = "Atime", index = "Atime", hidden = "false", align = "center", sortable = "true", width = "80", formatter = "'date'", formatoptions = "{ srcformat: 'Y-m-d', newformat: 'Y-m-d' }" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "图片", name = "Pic1", index = "Pic1", hidden = "false", align = "center", sortable = "true", width = "50", formatter = "Pic1_formatter" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "文章分类", name = "Stitle", index = "Stitle", hidden = "false", align = "center", sortable = "true", width = "100" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "热点", name = "Hot", index = "Hot", hidden = "false", align = "center", sortable = "true", width = "50", formatter = "showStatus" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "推荐", name = "Recommend", index = "Recommend", hidden = "center", align = "center", sortable = "true", width = "50", formatter = "showStatus" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "屏蔽", name = "Alive", index = "Alive", hidden = "false", align = "center", sortable = "true", width = "50", formatter = "showStatus" });
            lst.Add(new Hi_Core.Domain.JQGridColumnModel { label = "序号", name = "Layer", index = "Layer", hidden = "false", align = "center", sortable = "true", width = "50" });

            Hi_Core.Domain.JQGridModel model = new Domain.JQGridModel
            {
                GridID = "Article_gridTable",
                url = "/Article/GetJQGridJson",
                pager = "Article_PagerGrid",
                sortname = "Alive desc,Kind,Asid,Layer desc,Aid",
                sortorder = "",
                rownumbers = true,
                viewrecords = true,
                colModel = lst
            };

            return model;
        }
    }
}
