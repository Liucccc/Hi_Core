using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hi_Core.Repositories
{
    /// <summary>
    /// 分页组件实体类
    /// </summary>
    /// <typeparam name="T">泛型实体</typeparam>
    [Serializable]
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">分页索引</param>
        /// <param name="pageSize">分页大小</param>
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var total = source.Count();
            records = total;
            total = total / pageSize;

            if (total % pageSize > 0)
                total++;

            rows = pageSize;
            page = pageIndex;

            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">分页索引</param>
        /// <param name="pageSize">分页大小</param>
        public PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            records = source.Count();
            total = records / pageSize;

            if (records % pageSize > 0)
                total++;

            rows = pageSize;
            page = pageIndex;
            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">分页索引</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="totalCount">总记录数</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            records = totalCount;
            total = records / pageSize;

            if (records % pageSize > 0)
                total++;

            rows = pageSize;
            page = pageIndex;
            AddRange(source);
        }

        /// <summary>
        /// 分页索引
        /// </summary>
        public int page { get; }
        /// <summary>
        /// 分页大小
        /// </summary>
        public int rows { get; private set; }
        /// <summary>
        /// 排序列
        /// </summary>
        public string sidx { get; }
        /// <summary>
        /// 排序类型
        /// </summary>
        public string sord { get; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int records { get; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int total { get; }
        /// <summary>
        /// 查询条件Json
        /// </summary>
        public string conditionJson { get; }
        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPreviousPage
        {
            get { return (page > 0); }
        }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNextPage
        {
            get { return (page + 1 < total); }
        }
    }
}
