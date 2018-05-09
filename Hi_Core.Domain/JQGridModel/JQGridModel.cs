using System;
using System.Collections.Generic;
using System.Text;

namespace Hi_Core.Domain
{
    public class JQGridModel
    {
        /// <summary>
        /// GridID
        /// </summary>
        public string GridID { get; set; }
        /// <summary>
        /// 组件创建完成之后请求数据的url
        /// </summary>
        public string url { get; set; }

        private string _editurl = "";
        /// <summary>
        /// 编辑完成后保存提交的url
        /// </summary>
        public string editurl
        {
            get { return _editurl; }
            set { _editurl = value; }
        }

        private string _datatype = "json";
        /// <summary>
        /// 请求数据返回的类型。可选json,xml,txt
        /// </summary>
        public string datatype
        {
            get { return _datatype; }
            set { _datatype = value; }
        }

        /// <summary>
        /// 列
        /// </summary>
        public List<JQGridColumnModel> colModel { get; set; }

        private int _rowNum = 20;
        /// <summary>
        /// 一页显示多少条
        /// </summary>
        public int rowNum
        {
            get { return _rowNum; }
            set { _rowNum = value; }
        }

        private string _rowList = "[10, 20, 30]";
        /// <summary>
        /// 可供用户选择一页显示多少条
        /// </summary>
        public string rowList
        {
            get { return _rowList; }
            set { _rowList = value; }
        }

        private string _pager = "";
        /// <summary>
        /// 表格页脚的占位符(一般是div)的id
        /// </summary>
        public string pager
        {
            get { return _pager; }
            set { _pager = value; }
        }

        /// <summary>
        /// 初始化的时候排序的字段
        /// </summary>
        public string sortname { get; set; }

        private bool _autowidth = true;
        /// <summary>
        /// 表如果为ture时，
        /// 则当表格在首次被创建时会根据父元素比例重新调整表格宽度。
        /// 如果父元素宽度改变，为了使表格宽度能够自动调整则需要实现函数：setGridWidth
        /// </summary>
        public bool autowidth
        {
            get { return _autowidth; }
            set { _autowidth = value; }
        }

        private bool _multiselect = false;
        /// <summary>
        /// 是否显示多选框
        /// </summary>
        public bool multiselect
        {
            get { return _multiselect; }
            set { _multiselect = value; }
        }


        private bool _rownumbers = false;
        /// <summary>
        /// 如果为ture则会在表格左边新增一列，显示行顺序号，从1开始递增。此列名为'rn'.
        /// </summary>
        public bool rownumbers
        {
            get { return _rownumbers; }
            set { _rownumbers = value; }
        }

        private bool _shrinkToFit = true;
        /// <summary>
        /// 当初始化列宽度时候的计算类型，如果为ture，则按比例初始化列宽度。如果为false，则列宽度使用 colModel指定的宽度
        /// 同时需要控制jqgrid的宽度。通过autowidth:true属性可以达到目地
        /// </summary>
        public bool shrinkToFit
        {
            get { return _shrinkToFit; }
            set { _shrinkToFit = value; }
        }

        private string _height = "windowauto";
        /// <summary>
        /// 表格高度，可以是数字，像素值或者百分比
        /// </summary>
        public string height
        {
            get { return _height; }
            set { _height = value; }
        }

        private string _width = "windowauto";
        /// <summary>
        /// 表格宽度，可以是数字，像素值或者百分比
        /// </summary>
        public string width
        {
            get { return _width; }
            set { _width = value; }
        }

        private string _exceptheight = "0";
        /// <summary>
        /// 如果_height为自动auto则减去除外的高度
        /// </summary>
        public string exceptheight
        {
            get { return _exceptheight; }
            set { _exceptheight = value; }
        }

        private int _minheight = 0;
        /// <summary>
        /// 如果_height为自动auto则不可小于最小高度
        /// </summary>
        public int minheight
        {
            get { return _minheight; }
            set { _minheight = value; }
        }


        private string _sortorder = "asc";
        /// <summary>
        /// 排序顺序，升序或者降序（asc or desc）
        /// </summary>
        public string sortorder
        {
            get { return _sortorder; }
            set { _sortorder = value; }
        }

        private string _mtype = "GET";
        /// <summary>
        /// ajax提交方式。POST或者GET，默认GET
        /// </summary>
        public string mtype
        {
            get { return _mtype; }
            set { _mtype = value; }
        }

        private bool _viewrecords = false;
        /// <summary>
        /// 定义是否要显示总记录数
        /// </summary>
        public bool viewrecords
        {
            get { return _viewrecords; }
            set { _viewrecords = value; }
        }

        private string _prmName_id = "id";
        /// <summary>
        /// 定义是否要显示总记录数
        /// </summary>
        public string prmName_id
        {
            get { return _prmName_id; }
            set { _prmName_id = value; }
        }


        private string _loadBeforeSend = "";
        /// <summary>
        /// 数据加载之前出发的事件
        /// </summary>
        public string loadBeforeSend
        {
            get { return _loadBeforeSend; }
            set { _loadBeforeSend = value; }
        }


        string _beforeSelectRow = "function () { return true;}";
        /// <summary>
        /// 参数：	rowid, e
        /// 此事件发生在用户点击行，选中该行前。
        /// rowid 为行的ID，e为事件对象
        /// 该事件将返回布尔值true（行被选中）或false（行未被选中）。
        /// </summary>
        /// 
        public string beforeSelectRow
        {
            get { return _beforeSelectRow; }
            set { _beforeSelectRow = value; }
        }

        /// <summary>
        /// grid加载后处理，用于checkbox绑定等后续操作。
        /// </summary>
        private string _gridComplete = "null";
        public string gridComplete
        {
            get { return _gridComplete; }
            set { _gridComplete = value; }
        }
        public object postData { get; set; }

        /// <summary>
        /// 当选择行时触发此事件。rowid：当前行id；status：选择状态，当multiselect 为true时此参数才可用
        /// </summary>
        private string _onSelectRow = "null";
        public string onSelectRow
        {
            get { return _onSelectRow; }
            set { _onSelectRow = value; }
        }

        /// <summary>
        /// 全选时触发此事件。rowids：选中行id；status：选择状态，当multiselect 为true时此参数才可用
        /// </summary>
        private string _onSelectAll = "null";
        public string onSelectAll
        {
            get { return _onSelectAll; }
            set { _onSelectAll = value; }
        }

        /// <summary>
        /// 底部行
        /// </summary>
        private bool _footerrow = false;
        public bool footerrow
        {
            get { return _footerrow; }
            set { _footerrow = value; }
        }

    }
}
