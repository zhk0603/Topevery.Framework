using System;
using Topevery.Framework.ObjectModel;

namespace Topevery.Framework.Interface
{
    /// <summary>
    ///     页面视图模型接口。
    /// </summary>
    public interface IPageViewModel
    {
        /// <summary>
        ///     实体元数据。
        /// </summary>
        IEntityMetadata EntityMetadata { get; set; }

        /// <summary>
        ///     实体类型。
        /// </summary>
        Type EntityType { get; set; }

        /// <summary>
        ///     页面配置信息。
        /// </summary>
        IPageConfig PageConfig { get; set; }

        /// <summary>
        ///     分页组件。
        /// </summary>
        Pagination Pagination { get; set; }

        /// <summary>
        ///     获取ColNames.
        /// </summary>
        /// <returns></returns>
        string GetColNames();

        /// <summary>
        ///     获取ColModel.
        /// </summary>
        /// <returns></returns>
        string GetColModel();
    }
}