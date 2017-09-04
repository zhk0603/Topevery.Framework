using System;
using System.Text;
using Topevery.Framework.Interface;
using Topevery.Framework.ObjectModel;

namespace Topevery.Framework.Web.Mvc
{
    /// <summary>
    ///     视图模型。
    /// </summary>
    public class PageViewModel : IPageViewModel
    {
        /// <summary>
        ///     实体元数据。
        /// </summary>
        public IEntityMetadata EntityMetadata { get; set; }

        /// <summary>
        ///     实体类型。
        /// </summary>
        public Type EntityType { get; set; }

        /// <summary>
        ///     页面配置信息。
        /// </summary>
        public IPageConfig PageConfig { get; set; }

        /// <summary>
        ///     分页组件。
        /// </summary>
        public Pagination Pagination { get; set; }

        /// <summary>
        ///     获取ColNames.
        /// </summary>
        /// <returns></returns>
        public virtual string GetColNames()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            IEntityPropertyMetadata item = null;
            var length = EntityMetadata.ViewPropertyMetadatas.Length;
            for (var i = 0; i < length; i++)
            {
                item = EntityMetadata.ViewPropertyMetadatas[i];
                sb.Append($"'{item.DisplayName}'");
                if (i != length - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }

        /// <summary>
        ///     获取ColModel.
        /// </summary>
        /// <returns></returns>
        public virtual string GetColModel()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            IEntityPropertyMetadata item = null;
            var length = EntityMetadata.ViewPropertyMetadatas.Length;
            for (var i = 0; i < length; i++)
            {
                item = EntityMetadata.ViewPropertyMetadatas[i];
                sb.Append("{");

                sb.Append($"name:'{ item.PropertyInfo.Name}'" +
                          $",index:'{item.ColModelIndex ?? item.PropertyInfo.Name}'" +
                          $",width: {item.Width}" +
                          $",align: '{item.Align.ToString().ToLower()}'" +
                          $",sortable: {item.Sortable.ToString().ToLower()}" +
                          $",hidden: {item.Hidden.ToString().ToLower()}");
                if (item.IsKey)
                {
                    sb.Append(",hidedlg: true,key: true");
                }
                if (!string.IsNullOrWhiteSpace(item.CssClass))
                {
                    sb.Append($",classes: '{item.CssClass}'");
                }
                if (!string.IsNullOrWhiteSpace(item.FormatterScript))
                {
                    sb.Append($",formatter: {item.FormatterScript}");
                }
                if (!string.IsNullOrWhiteSpace(item.UnFormatterScript))
                {
                    sb.Append($",unformatter: {item.UnFormatterScript}");
                }

                sb.Append("}");
                if (i != length - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}