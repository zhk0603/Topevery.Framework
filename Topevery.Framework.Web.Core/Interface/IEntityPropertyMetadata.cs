using System;
using System.Reflection;
using Topevery.Framework.ObjectModel;

namespace Topevery.Framework.Interface
{
    /// <summary>
    ///     运行时实体属性元数据。
    /// </summary>
    public interface IEntityPropertyMetadata
    {
        /// <summary>
        ///     获取或设置实体属性。
        /// </summary>
        PropertyInfo PropertyInfo { get; set; }

        /// <summary>
        ///     获取实体属性类型。
        /// </summary>
        Type PropertyType { get; }

        /// <summary>
        ///     获取或设置实体属性是否为主键。
        /// </summary>
        bool IsKey { get; set; }

        /// <summary>
        ///     获取或设置实体属性是否隐藏在列表。
        /// </summary>
        bool IsHiddenOnView { get; set; }

        /// <summary>
        ///     获取或设置实体属性是否隐藏在编辑时。
        /// </summary>
        bool IsHiddenOnEdit { get; set; }

        /// <summary>
        ///     获取或设置实体属性是否隐藏在新增时。
        /// </summary>
        bool IsHiddenOnCreate { get; set; }

        /// <summary>
        ///     获取或设置实体属性是否隐藏在查看详情时。
        /// </summary>
        bool IsHiddenOnDetail { get; set; }

        /// <summary>
        ///     获取或设置实体属性是否能搜索。
        /// </summary>
        bool IsSearcher { get; set; }

        #region DisplayAttribute
        /// <summary>
        ///     获取或设置实体属性的显示名称。
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        ///     获取或设置实体属性的排序顺序。
        /// </summary>
        int? Order { get; set; }

        /// <summary>
        ///     获取或设置实体属性的描述信息。
        /// </summary>
        string Description { get; set; }

        /// <summary>
        ///     获取或设置实体属性的组名。
        /// </summary>
        string GroupName { get; set; }

        #endregion

        #region ColModelAttribute
        /// <summary>
        ///     获取或设置引索，与后台交互的参数。
        /// </summary>
        string ColModelIndex { get; set; }

        /// <summary>
        ///     获取或设置表格列的名称。
        /// </summary>
        string ColModelName { get; set; }

        /// <summary>
        ///     获取或设置实体属性的css类。
        /// </summary>
        string CssClass { get; set; }

        /// <summary>
        ///     获取或设置实体属性的列宽。
        /// </summary>
        int Width { get; set; }

        /// <summary>
        ///     获取或设置实体属性在列表时的文字对齐格式。
        /// </summary>
        TextAlign Align { get; set; }

        /// <summary>
        ///     获取或设置实体属性是否能排序。
        /// </summary>
        bool Sortable { get; set; }

        /// <summary>
        ///     获取或设置实体属性的格式化Javascript方法名称。
        /// </summary>
        string FormatterScript { get; set; }

        /// <summary>
        ///     获取或设置实体属性的反格式化Javascript方法名称。
        /// </summary>
        string UnFormatterScript { get; set; }

        /// <summary>
        ///     获取或设置在初始化表格时是否要隐藏此列。
        /// </summary>
        bool Hidden { get; set; }

        #endregion
    }
}