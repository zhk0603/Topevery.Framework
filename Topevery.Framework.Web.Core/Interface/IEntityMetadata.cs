using System.Reflection;

namespace Topevery.Framework.Interface
{
    /// <summary>
    ///     实体元数据。
    /// </summary>
    public interface IEntityMetadata
    {
        /// <summary>
        ///     获取实体所有公开的属性元数据。
        /// </summary>
        IEntityPropertyMetadata[] PropertyMetadatas { get; }
        /// <summary>
        ///     获取实体所有的公共属性。
        /// </summary>
        PropertyInfo[] EntityPropertyInfos { get; }
        /// <summary>
        ///     获取实体在列表中的属性元数据。
        /// </summary>
        IEntityPropertyMetadata[] ViewPropertyMetadatas { get; }

        /// <summary>
        ///     获取实体在创建时的属性元数据。
        /// </summary>
        IEntityPropertyMetadata[] CreatePropertyMetadatas { get; }

        /// <summary>
        ///     获取实体在编辑时的属性元数据。
        /// </summary>
        IEntityPropertyMetadata[] EditPropertyMetadatas { get; }

        /// <summary>
        ///     获取在查看实体详情时的属性元数据。
        /// </summary>
        IEntityPropertyMetadata[] DetailPropertyMetadatas { get; }

        /// <summary>
        ///     获取能搜索实体的属性元数据。
        /// </summary>
        IEntityPropertyMetadata[] SearcherPropertyMetadatas { get; }
    }
}