using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Topevery.Framework.Entity;

namespace Topevery.Framework.Web.Mvc
{
    /// <summary>
    ///     数据模型。
    /// </summary>
    /// <typeparam name="TKey">实体主键类型。</typeparam>
    public class PageDataViewModel<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public PageDataViewModel(int total, int pageCurrent, int pageSize)
        {
            Total = total;
            PageCurrent = pageCurrent;
            TotalPage = (int)Math.Ceiling(total / (double)pageSize);
        }

        [JsonProperty("rows")]
        public IEnumerable<TEntity> Items { get; set; }

        [JsonProperty("total")]
        public int TotalPage { get; private set; }


        [JsonProperty("records")]
        public int Total { get; set; }

        [JsonProperty("page")]
        public int PageCurrent { get; set; }
    }
}