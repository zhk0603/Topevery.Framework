namespace Topevery.Framework.Interface
{
    /// <summary>
    ///     页面配置信息。
    /// </summary>
    public interface IPageConfig
    {
        /// <summary>
        ///     获取或设置页面标题名称。
        /// </summary>
        string Title { get; set; }

        /// <summary>
        ///     获取或设置默认排序字段。
        /// </summary>
        string DefaultSortname { get; set; }

        /// <summary>
        ///     获取或设置是否倒序排序。
        /// </summary>
        bool IsDescending { get; set; }

        /// <summary>
        ///     获取或设置Ajax请求数据的控制器Action。
        /// </summary>
        string DataActin { get; set; }

        /// <summary>
        ///     获取或设置保存编辑、添加数据的控制器Action。
        /// </summary>
        string EditAction { get; set; }

        /// <summary>
        ///     获取或设置删除数据的控制器Action。
        /// </summary>
        string DelAction { get; set; }

        /// <summary>
        ///     获取或设置是否可多选。
        /// </summary>
        bool MultiSelect { get; set; }

        /// <summary>
        ///     获取或设置是否显示行号。
        /// </summary>
        bool ShowRowNumber { get; set; }

        /// <summary>
        ///     获取或设置加载完后执行的脚本方法。
        /// </summary>
        string OnLoadCompleteScript { get; set; }

        /// <summary>
        ///     获取或设置提交数据的脚本方法。
        /// </summary>
        string PostDataScript { get; set; }
    }
}