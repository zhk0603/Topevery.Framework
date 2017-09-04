using System;

namespace Topevery.Framework.Interface
{
    /// <summary>
    ///     实体元数据提供者。
    /// </summary>
    public interface IEntityMetadataProvider
    {
        /// <summary>
        ///     获取实体元数据。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IEntityMetadata GetEntityMetadata(Type type);

        /// <summary>
        ///     获取实体元数据。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEntityMetadata GetEntityMetadata<T>();
    }
}