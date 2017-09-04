using System;
using Topevery.Framework.Interface;
using Topevery.Framework.ObjectModel;

namespace Topevery.Framework.ComponentModel.DataAnnotations
{
    /// <summary>
    ///     JQgrid表格的colModel配置信息约束。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColModelAttribute : Attribute, IDataAnnotations
    {
        /// <summary>
        ///     获取或设置引索，与后台交互的参数。
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        ///     获取或设置表格列的名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     获取或设置css样式类。
        /// </summary>
        public string CssClass { get; set; }

        /// <summary>
        ///     获取或设置列宽。
        /// </summary>
        public int Width { get; set; } = 150;

        /// <summary>
        ///     获取或设置对齐方式。
        /// </summary>
        public TextAlign Align { get; set; } = TextAlign.Left;

        /// <summary>
        ///     获取或设置格式化脚本方法。
        /// </summary>
        public string FormatterScript { get; set; }

        /// <summary>
        ///     获取或设置反格式化脚本方法。
        /// </summary>
        public string UnFormatterScript { get; set; }

        /// <summary>
        ///     获取或设置是否可排序。
        /// </summary>
        public bool Sortable { get; set; }

        /// <summary>
        ///     获取或设置在初始化表格时是否要隐藏此列。
        /// </summary>
        public bool Hidden { get; set; }

        public void SetRuntimeProperty(IEntityPropertyMetadata runtimeProperty)
        {
            if (runtimeProperty == null)
                throw new ArgumentNullException(nameof(runtimeProperty));
            runtimeProperty.Width = Width;
            runtimeProperty.Align = Align;
            runtimeProperty.FormatterScript = FormatterScript;
            runtimeProperty.UnFormatterScript = UnFormatterScript;
            runtimeProperty.Sortable = Sortable;
            runtimeProperty.CssClass = CssClass;
            runtimeProperty.ColModelIndex = Index;
            runtimeProperty.ColModelName = Name;
            runtimeProperty.Hidden = Hidden;
        }
    }
}