using System.Linq;

namespace Topevery.Framework.ObjectModel
{
    /// <summary>
    ///     分页组件。
    /// </summary>
    public class Pagination
    {
        /// <summary>
        ///     页面大小。
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///     显示记录数。
        /// </summary>
        public int[] PageSizeList { get; set; }

        /// <summary>
        ///     默认页面大小。
        /// </summary>
        public int DefualtPageSize { get; set; }

        /// <summary>
        ///     当前页。
        /// </summary>
        public int PageCurrent { get; set; }

        /// <summary>
        ///     数据总数。
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        ///     排序字段。
        /// </summary>
        public string OrderField { get; set; }

        /// <summary>
        ///     排序方式。asc\desc。
        /// </summary>
        public string OrderDirection { get; set; }

        public string GetPageSizeList()
        {
            var result = PageSizeList.Aggregate("[", (current, i) => current + (i + ","));
            result = result.Substring(0, result.Length - 1);
            result += ']';
            return result;
        }
    }
}