using System;
using System.Collections.Concurrent;
using Topevery.Framework.Interface;

namespace Topevery.Framework.Web.Mvc
{
    /// <summary>
    ///     默认的实体元数据提供者。
    /// </summary>
    public class EntityMetadataProvider : IEntityMetadataProvider
    {
        private static readonly ConcurrentDictionary<string, IEntityMetadata> RuntimeEntityMetadata;

        static EntityMetadataProvider()
        {
            RuntimeEntityMetadata = new ConcurrentDictionary<string, IEntityMetadata>();
        }

        /// <summary>
        ///     获取实体元数据。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual IEntityMetadata GetEntityMetadata(Type type)
        {
            var key = type.FullName;
            IEntityMetadata runtimeEntity;

            if (RuntimeEntityMetadata.TryGetValue(key, out runtimeEntity))
            {
                return runtimeEntity;
            }
            runtimeEntity = new EntityMetadata(type);
            RuntimeEntityMetadata[key] = runtimeEntity;
            return runtimeEntity;
        }

        /// <summary>
        ///     获取实体元数据。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IEntityMetadata GetEntityMetadata<T>()
        {
            return GetEntityMetadata(typeof (T));
        }
    }
}