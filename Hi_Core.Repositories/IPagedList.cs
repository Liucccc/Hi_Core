using System;
using System.Collections.Generic;
using System.Text;

namespace Hi_Core.Repositories
{
    public interface IPagedList<T> : IList<T>
    {

        /// <summary>
        /// 每页行数
        /// </summary>
        int rows { get; }
        /// <summary>
        /// 当前页
        /// </summary>
        int page { get; }
        /// <summary>
        /// 排序列
        /// </summary>
        string sidx { get;  }
        /// <summary>
        /// 排序类型
        /// </summary>
        string sord { get;  }
        /// <summary>
        /// 总记录数
        /// </summary>
        int records { get;  }
        /// <summary>
        /// 总页数
        /// </summary>
        int total { get; }
        /// <summary>
        /// 是否有上一页
        /// </summary>
        bool HasPreviousPage { get; }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        bool HasNextPage { get; }
        /// <summary>
        /// 查询条件Json
        /// </summary>
        string conditionJson { get; }
    }
}
