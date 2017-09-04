using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Topevery.Framework.ComponentModel.DataAnnotations;
using Topevery.Framework.Interface;
using Topevery.Framework.Utility;

namespace Topevery.Framework.Web.Mvc
{
    /// <summary>
    ///     实体元数据。
    /// </summary>
    public class EntityMetadata : IEntityMetadata
    {
        private static readonly object _lockObj = new object();
        private readonly Type _entityType;
        private PropertyInfo[] _entityPropertys;
        private IEntityPropertyMetadata[] _propertyMetadatas;

        /// <summary>
        /// 初始化一个<see cref="EntityMetadata"/>。
        /// </summary>
        /// <param name="entityType">实体类型。</param>
        public EntityMetadata(Type entityType)
        {
            if (entityType == null)
                throw new ArgumentNullException(nameof(entityType));

            _entityType = entityType;
        }

        /// <summary>
        ///     获取实体所有公开的属性元数据。
        /// </summary>
        public IEntityPropertyMetadata[] PropertyMetadatas
        {
            get
            {
                if (_propertyMetadatas == null)
                {
                    lock (_lockObj)
                    {
                        if (_propertyMetadatas == null)
                            _propertyMetadatas = GetPropertyMetadatas();
                    }
                }
                return _propertyMetadatas;
            }
        }

        /// <summary>
        ///     获取实体所有的公共属性。
        /// </summary>
        public PropertyInfo[] EntityPropertyInfos
        {
            get { return _entityPropertys ?? (_entityPropertys = _entityType.GetProperties()); }
        }

        /// <summary>
        ///     获取实体在创建时的属性元数据。
        /// </summary>
        public IEntityPropertyMetadata[] CreatePropertyMetadatas
        {
            get { return PropertyMetadatas.Where(x => !x.IsHiddenOnCreate).ToArray(); }
        }

        /// <summary>
        ///     获取在查看实体详情时的属性元数据。
        /// </summary>
        public IEntityPropertyMetadata[] DetailPropertyMetadatas
        {
            get { return PropertyMetadatas.Where(x => !x.IsHiddenOnDetail).ToArray(); }
        }

        /// <summary>
        ///     获取实体在编辑时的属性元数据。
        /// </summary>
        public IEntityPropertyMetadata[] EditPropertyMetadatas
        {
            get { return PropertyMetadatas.Where(x => !x.IsHiddenOnEdit).ToArray(); }
        }

        /// <summary>
        ///     获取能搜索实体的属性元数据。
        /// </summary>
        public IEntityPropertyMetadata[] SearcherPropertyMetadatas
        {
            get { return PropertyMetadatas.Where(x => x.IsSearcher).ToArray(); }
        }

        /// <summary>
        ///     获取实体在列表中的属性元数据。
        /// </summary>
        public IEntityPropertyMetadata[] ViewPropertyMetadatas
        {
            get { return PropertyMetadatas.Where(x => !x.IsHiddenOnView).ToArray(); }
        }

        /// <summary>
        ///     获取属性元数据。
        /// </summary>
        /// <returns></returns>
        protected virtual EntityPropertyMetadata[] GetPropertyMetadatas()
        {
            var propertys = EntityPropertyInfos.Select(property => new EntityPropertyMetadata(property)).ToList();
            return propertys.OrderBy(x => x.Order).ToArray();
        }
    }
}