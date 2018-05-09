using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_Core.Web
{
    public static class JQGridHelper
    {
        public static HtmlString JQGrid(this IHtmlHelper helper, Hi_Core.Domain.JQGridModel modelGrid, string ModuleCode = "", string UserID = "", string Url = "")
        {
            string strCols = "";
            string strUrl = modelGrid.url;
            string HidCols = "";
            bool ColControl = false;

            //字段列表
            string strColModel = GetColModel(modelGrid.colModel, ModuleCode, out strCols, HidCols, ColControl);

            if (strUrl.IndexOf("?") > 0)
            {
                strUrl = strUrl + "&Cols=" + strCols;
            }
            else
            {
                strUrl = strUrl + "?Cols=" + strCols;
            }
            bool isPage = true;
            if (string.IsNullOrEmpty(modelGrid.pager.Trim()))
            {
                isPage = false;
                modelGrid.rowNum = 0;
            }
            strUrl = strUrl + "&isPage=" + isPage.ToString().ToLower();

            string strPostData = "{}";
            if (modelGrid.postData != null)
            {
                strPostData = Newtonsoft.Json.JsonConvert.SerializeObject(modelGrid.postData);
            }

            if (modelGrid.beforeSelectRow == "false")
            {
                modelGrid.beforeSelectRow = "function () { return false;}";
            }
            string StyleControl = "";
            if (modelGrid.height == "windowauto")
            {
                StyleControl = ";$('.ui-jqgrid').css('border-bottom','0px').css('border-right', '0px')";
            }
            string strResult = @"
                    <div class='gridPanel'>
                        <table id='" + modelGrid.GridID + @"'></table>
                        " + (isPage ? "<div id='" + modelGrid.pager + "'></div>" : "") + @"
                    </div>
                    <script>
                        $(function () {
                           
                            GetGrid" + modelGrid.GridID + @"();
                           
                            
                                InitialPage" + modelGrid.GridID + @"();
                            
                            $(window).resize(function (e) {
                                    //resize重设(表格、树形)宽高

                                    InitialPage" + modelGrid.GridID + @"();
                                    e.stopPropagation();
                           });
                        });
                        var gridheight ='" + modelGrid.height + @"';
                        var gridwidth ='" + modelGrid.width + @"';
                        
                        function InitialPage" + modelGrid.GridID + @"() {
                            var gridheight ='" + modelGrid.height + @"';
                            var gridwidth ='" + modelGrid.width + @"';
                            if(gridwidth == 'windowauto'){
                                $('#" + modelGrid.GridID + @"').setGridWidth(($('.gridPanel').width()));
                            }
                            if(gridheight == 'windowauto'){
                                var _x = $('.gridPanel').offset();
                                gridheight = $(window).height() - _x.top - 75 -" + modelGrid.exceptheight + @";

                                if( " + modelGrid.minheight + @" > 0 && gridheight < " + modelGrid.minheight + @" )
                                {
                                    gridheight = " + modelGrid.minheight + @";
                                }
                            }
                            $('#" + modelGrid.GridID + @"').setGridHeight(gridheight);
                        }
                        if(gridwidth == 'windowauto'){
                            gridwidth = $('.gridPanel').width();
                        }
                        if(gridheight == 'windowauto'){
                            var x = $('.gridPanel').offset();
                            gridheight = $(window).height() - x.top - 75 -" + modelGrid.exceptheight + @";
                            if( " + modelGrid.minheight + @" > 0 && gridheight < " + modelGrid.minheight + @" )
                            {
                                gridheight = " + modelGrid.minheight + @";
                            }
                        }
                        var selectedRowIndex = 0;
                        var $gridTable = $('#" + modelGrid.GridID + @"');
                     

                        function GetGrid" + modelGrid.GridID + @"() {
                            
                            jQuery('#" + modelGrid.GridID + @"').jqGrid(
			            {
                            url: '" + strUrl + @"',//组件创建完成之后请求数据的url
                            postData: " + strPostData + @",
			                datatype: '" + modelGrid.datatype + @"',//请求数据返回的类型。可选json,xml,txt
			                colModel: [ 
                                " + strColModel + @"
			                ],
                            rowNum: " + modelGrid.rowNum.ToString() + @",//一页显示多少条" + @"
			              
			                rowList: " + modelGrid.rowList + @",//可供用户选择一页显示多少条
			                pager: '#" + modelGrid.pager + @"',//表格页脚的占位符(一般是div)的id
			                sortname: '" + modelGrid.sortname + @"',//初始化的时候排序的字段
			                autowidth: " + modelGrid.autowidth.ToString().ToLower() + @",
			                rownumbers: " + modelGrid.rownumbers.ToString().ToLower() + @",
                            multiselect: " + modelGrid.multiselect.ToString().ToLower() + @",
                            footerrow:" + modelGrid.footerrow.ToString().ToLower() + @",
                            beforeSelectRow: " + modelGrid.beforeSelectRow.ToString() + @",
			                height:gridheight,
                            shrinkToFit : " + modelGrid.shrinkToFit.ToString().ToLower() + @",
                            width:gridwidth,
			                sortorder: '" + modelGrid.sortorder + @"',//排序方式,可选desc,asc
			                mtype: '" + modelGrid.mtype + @"',//向后台请求数据的ajax的类型。可选post,get
			                viewrecords:" + modelGrid.viewrecords.ToString().ToLower() + @",
                            prmNames: { id: '" + modelGrid.prmName_id + @"' },
                            editurl:'" + modelGrid.editurl + @"',
                            editDialogOptions: {'recreateForm': true, errorTextFormat: function (data) { return 'Error: ' + data.responseText },editData: { __RequestVerificationToken: jQuery('input[name=__RequestVerificationToken]').val() } },
                            addDialogOptions: {'recreateForm': true,errorTextFormat: function(data) { return 'Error: ' + data.responseText },editData: { __RequestVerificationToken: jQuery('input[name=__RequestVerificationToken]').val() }},
                            delDialogOptions: {'recreateForm': true, errorTextFormat: function(data) { return 'Error: ' + data.responseText },delData: { __RequestVerificationToken: jQuery('input[name=__RequestVerificationToken]').val() }},
                            searchDialogOptions: { 'recreateForm': true, 'resize': false },
                            loadBeforeSend: function () {" + modelGrid.loadBeforeSend + StyleControl + @"},
                            gridComplete:" + modelGrid.gridComplete + @",
                            onSelectRow:" + modelGrid.onSelectRow + @",
                            onSelectAll:" + modelGrid.onSelectAll + @"
                            
                        })
                        .navGrid('#" + modelGrid.pager + @"', { 'add': false, 'cloneToTop': true, 'del': false, 'edit': false, 'position': 'left', 'refresh': true, 'search': false, 'view': false },
                        jQuery('#" + modelGrid.GridID + @"').getGridParam('editDialogOptions'),
                        jQuery('#" + modelGrid.GridID + @"').getGridParam('addDialogOptions'),
                        jQuery('#" + modelGrid.GridID + @"').getGridParam('delDialogOptions'),
                        jQuery('#" + modelGrid.GridID + @"').getGridParam('searchDialogOptions')).bindKeys();

                    }
                    </script>
            ";



            return new HtmlString(strResult);
        }

        private static string GetColModel(List<Hi_Core.Domain.JQGridColumnModel> lstCol, string ModuleCode, out string strColss, string HidCols = "", bool ColControl = false)
        {
            StringBuilder strCol = new StringBuilder();
            StringBuilder strCols = new StringBuilder();
            List<System.String> listS = new List<string>();
            if (HidCols != null && HidCols != "")
            {
                string[] strHidCols = HidCols.Split(',');
                listS = new List<System.String>(strHidCols);

            }
            foreach (Hi_Core.Domain.JQGridColumnModel model in lstCol)
            {
                if (ColControl)
                {
                    model.hidden = "false";
                    if (listS.IndexOf(model.label) > -1)
                    {
                        model.hidden = "true";
                    }
                }
               
                strCols.Append(model.name + ",");

                if (model.hidden == "true")
                {
                    strCol.Append(
                    string.Format("{{ label: '{0}', name: '{1}', hidden: true, index: '{2}' {3}  }},",
                        model.label,
                        model.name,
                        model.index,
                       (!model.key) ? "" : ", key:true"
                       )
                    );
                }
                else
                {
                    strCol.Append(
                        string.Format("{{ label: '{0}', name: '{1}', index: '{2}', width: '{3}', align: '{4}',sortable: {5} {6} {7} {8} {9} {10}{11} {12}}},",
                        model.label,
                        model.name,
                        model.index,
                        model.width,
                        model.align,
                        model.sortable,
                        (!model.editable) ? "" : ", editable: true",
                        (!model.key) ? "" : ", key:true",
                        string.IsNullOrEmpty(model.edittype) ? "" : " , edittype: " + model.edittype,
                        string.IsNullOrEmpty(model.editrules) ? "" : " , editrules: " + model.editrules,
                        string.IsNullOrEmpty(model.editoptions) ? "" : " , editoptions:" + model.editoptions,
                        string.IsNullOrEmpty(model.formatter) ? "" : " , formatter: " + model.formatter,
                        string.IsNullOrEmpty(model.formatoptions) ? "" : " , formatoptions:" + model.formatoptions
                        )
                        );
                }

            }
            if (strCols.Length > 0)
                strCols.Remove(strCols.Length - 1, 1);
            strColss = strCols.ToString();
            return strCol.ToString();
        }

        private static string GetCols(List<Hi_Core.Domain.JQGridColumnModel> lstCol)
        {
            StringBuilder strCols = new StringBuilder();
            foreach (Hi_Core.Domain.JQGridColumnModel model in lstCol)
            {
                strCols.Append(model.name + ",");
            }
            if (strCols.Length > 0)
                strCols.Remove(strCols.Length, 1);
            return strCols.ToString();
        }
    }
}
