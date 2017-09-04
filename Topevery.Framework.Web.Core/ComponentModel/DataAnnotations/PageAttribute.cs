using System;
using Topevery.Framework.Interface;

namespace Topevery.Framework.ComponentModel.DataAnnotations
{
    /// <summary>
    ///     页面配置属性。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class PageAttribute : Attribute, IPageConfig
    {
        /// <summary>
        ///     获取或设置Ajax请求数据的控制器Action。
        /// </summary>
        public string DataActin { get; set; } = "List";

        /// <summary>
        ///     获取或设置默认排序字段。
        /// </summary>
        public string DefaultSortname { get; set; }

        /// <summary>
        ///     获取或设置删除数据的控制器Action。
        /// </summary>
        public string DelAction { get; set; } = "Delete";

        /// <summary>
        ///     获取或设置保存编辑、添加数据的控制器Action。
        /// </summary>
        public string EditAction { get; set; } = "Edit";

        /// <summary>
        ///     获取或设置是否倒序排序。
        /// </summary>
        public bool IsDescending { get; set; }

        /// <summary>
        ///     获取或设置是否可多选。
        /// </summary>
        public bool MultiSelect { get; set; }

        /// <summary>
        ///     获取或设置加载完后执行的脚本方法。
        /// </summary>
        public string OnLoadCompleteScript { get; set; }

        /// <summary>
        ///     获取或设置提交数据的脚本方法。
        /// </summary>
        public string PostDataScript { get; set; }

        /// <summary>
        ///     获取或设置是否显示行号。
        /// </summary>
        public bool ShowRowNumber { get; set; }

        /// <summary>
        ///     获取或设置页面标题名称。
        /// </summary>
        public string Title { get; set; }
    }
}