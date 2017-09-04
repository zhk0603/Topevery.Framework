using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Topevery.Framework.ComponentModel.DataAnnotations;
using Topevery.Framework.Interface;
using Topevery.Framework.ObjectModel;
using Topevery.Framework.Utility;

namespace Topevery.Framework.Web.Mvc
{
    /// <summary>
    ///     实体属性元数据。
    /// </summary>
    public class EntityPropertyMetadata : IEntityPropertyMetadata
    {
        /// <summary>
        ///     初始化一个<see cref="EntityPropertyMetadata" />实例。
        /// </summary>
        /// <param name="propertyInfo"></param>
        public EntityPropertyMetadata(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                throw new ArgumentNullException(nameof(propertyInfo));

            PropertyInfo = propertyInfo;
            PropertyType = propertyInfo.PropertyType;
            Initialization();
        }

        /// <summary>
        ///     获取或设置实体属性在列表时的文字对齐格式。
        /// </summary>
        public TextAlign Align { get; set; }

        /// <summary>
        ///     获取或设置实体属性的css类。
        /// </summary>
        public string CssClass { get; set; }

        /// <summary>
        ///     获取或设置实体属性的描述信息。
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     获取或设置实体属性的格式化Javascript方法名称。
        /// </summary>
        public string FormatterScript { get; set; }

        /// <summary>
        ///     获取或设置实体属性的组名。
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        ///     获取或设置实体属性是否隐藏在新增时。
        /// </summary>
        public bool IsHiddenOnCreate { get; set; }

        /// <summary>
        ///     获取或设置实体属性是否隐藏在查看详情时。
        /// </summary>
        public bool IsHiddenOnDetail { get; set; }

        /// <summary>
        ///     获取或设置实体属性是否隐藏在编辑时。
        /// </summary>
        public bool IsHiddenOnEdit { get; set; }

        /// <summary>
        ///     获取或设置实体属性是否隐藏在列表。
        /// </summary>
        public bool IsHiddenOnView { get; set; }

        /// <summary>
        ///     获取或设置实体属性是否为主键。
        /// </summary>
        public bool IsKey { get; set; }

        /// <summary>
        ///     获取或设置实体属性是否能搜索。
        /// </summary>
        public bool IsSearcher { get; set; }

        /// <summary>
        ///     获取或设置实体属性的显示名称。
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        ///     获取或设置实体属性的排序顺序。
        /// </summary>
        public int? Order { get; set; }

        /// <summary>
        ///     获取或设置实体属性。
        /// </summary>
        public PropertyInfo PropertyInfo { get; set; }

        /// <summary>
        ///     获取实体属性类型。
        /// </summary>
        public Type PropertyType { get; set; }

        /// <summary>
        ///     获取或设置实体属性是否能排序。
        /// </summary>
        public bool Sortable { get; set; }

        /// <summary>
        ///     获取或设置实体属性的反格式化Javascript方法名称。
        /// </summary>
        public string UnFormatterScript { get; set; }

        /// <summary>
        ///     获取或设置实体属性的列宽。
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        ///     获取或设置引索，与后台交互的参数。
        /// </summary>
        public string ColModelIndex { get; set; }

        /// <summary>
        ///     获取或设置表格列的名称。
        /// </summary>
        public string ColModelName { get; set; }

        /// <summary>
        ///     获取或设置在初始化表格时是否要隐藏此列。
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        ///     初始化。
        /// </summary>
        protected virtual void Initialization()
        {
            IsSearcher = PropertyInfo.HasAttribute<SerializableAttribute>();
            IsKey = PropertyInfo.HasAttribute<KeyAttribute>();

            var colModelAttribute = PropertyInfo.GetAttribute<ColModelAttribute>();
            colModelAttribute?.SetRuntimeProperty(this);

            var hideAttribute = PropertyInfo.GetAttribute<HideAttribute>();
            hideAttribute?.SetRuntimeProperty(this);


            var displayAttribute = PropertyInfo.GetAttribute<DisplayAttribute>();
            if (displayAttribute != null)
            {
                DisplayName = displayAttribute.GetName() ?? PropertyInfo.Name;
                Order = displayAttribute.GetOrder();
                Description = displayAttribute.GetDescription();
                GroupName = displayAttribute.GetGroupName();
            }
        }
    }
}