using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using Topevery.Framework.ComponentModel.DataAnnotations;
using Topevery.Framework.Entity;
using Topevery.Framework.Interface;
using Topevery.Framework.ObjectModel;
using Topevery.Framework.Utility;
using System.Data;
using Topevery.Framework.Data;

namespace Topevery.Framework.Web.Mvc
{
    /// <summary>
    ///     实体控制器。
    /// </summary>
    /// <typeparam name="TEntity">实体。</typeparam>
    /// <typeparam name="TKey">实体主键类型。</typeparam>
    public abstract class EntityController<TEntity, TKey> : Controller
        where TEntity : class, IEntity<TKey>, new()
    {
        private IEntityMetadataProvider _entityMetadataProvider;
        private IDataMapper _dataMapper;

        /// <summary>
        ///     初始化一个新的<see cref="EntityController{TEntity, TKey}"/>。
        /// </summary>
        protected EntityController()
        {
            PageSizeList = new[] { 30, 60, 120, 150 };
            PageConfig = typeof(TEntity).GetAttribute<PageAttribute>() ??
                         new PageAttribute();
            EntityMetadata = this.EntityMetadataProvider.GetEntityMetadata<TEntity>();
        }

        /// <summary>
        ///     获取或设置显示记录数。
        /// </summary>
        public int[] PageSizeList { get; set; }

        /// <summary>
        ///     获取或设置配置信息。
        /// </summary>
        public IPageConfig PageConfig { get; set; }

        /// <summary>
        ///     获取或设置实体元数据。
        /// </summary>
        public IEntityMetadata EntityMetadata { get; set; }

        /// <summary>
        ///     获取或设置实体元数据提供者。
        /// </summary>
        public IEntityMetadataProvider EntityMetadataProvider
        {
            get
            {
                if (_entityMetadataProvider == null)
                {
                    _entityMetadataProvider = CreateEntityMetadataProvider();
                }
                return _entityMetadataProvider;
            }
            set { _entityMetadataProvider = value; }
        }

        /// <summary>
        ///     获取或设置数据映射器。
        /// </summary>
        public IDataMapper DataMapper
        {
            get
            {
                if(_dataMapper == null)
                {
                    _dataMapper = CreateDataMapper();
                }
                return _dataMapper;
            }
            set
            {
                _dataMapper = value;
            }
        }

        /// <summary>
        ///     Index Action.
        /// </summary>
        /// <param name="orderField">排序字段。</param>
        /// <param name="orderDirection">排序方向。</param>
        /// <param name="pageSize">页面大小。</param>
        /// <param name="pageCurrent">当前页。</param>
        /// <returns></returns>
        public virtual ActionResult Index(string orderField, string orderDirection,
            int pageSize = 30, int pageCurrent = 1)
        {
            if (pageCurrent < 1)
            {
                pageCurrent = 1;
            }
            if (pageSize < 1)
            {
                pageSize = PageSizeList[0];
            }
            orderDirection = string.IsNullOrWhiteSpace(orderDirection)
                ? PageConfig.IsDescending ? "desc" : "asc"
                : orderDirection;
            orderField = string.IsNullOrWhiteSpace(orderField) ? PageConfig.DefaultSortname ?? "c_id" : orderField;

            var pagination = new Pagination
            {
                PageSize = pageSize,
                PageCurrent = pageCurrent,
                PageSizeList = PageSizeList,
                DefualtPageSize = pageSize,
                OrderField = orderField,
                OrderDirection = orderDirection
            };

            var pageViewModel = CreateIndexViewModel(pagination);
            return View(pageViewModel);
        }

        /// <summary>
        ///     List Action.
        /// </summary>
        /// <param name="orderField">排序字段。</param>
        /// <param name="orderDirection">排序方向。</param>
        /// <param name="pageSize">页面大小。</param>
        /// <param name="pageCurrent">当前页。</param>
        /// <returns></returns>
        public virtual ActionResult List(string orderField, string orderDirection,
            int pageSize = 30, int pageCurrent = 1)
        {

            if (pageCurrent < 1)
            {
                pageCurrent = 1;
            }
            if (pageSize < 1)
            {
                pageSize = PageSizeList[0];
            }
            orderDirection = string.IsNullOrWhiteSpace(orderDirection)
                ? PageConfig.IsDescending ? "desc" : "asc"
                : orderDirection;
            orderField = string.IsNullOrWhiteSpace(orderField) ? PageConfig.DefaultSortname ?? "c_id" : orderField;

            var pagination = new Pagination
            {
                PageSize = pageSize,
                PageCurrent = pageCurrent,
                PageSizeList = PageSizeList,
                DefualtPageSize = pageSize,
                OrderField = orderField,
                OrderDirection = orderDirection
            };

            var pageDataViewModel = CreateListViewModel(pageCurrent, pageSize, pagination);
            return Json(pageDataViewModel, new JsonSerializerSettings { DateFormatString = "yyyy-MM-dd HH:mm:ss" });
        }

        public virtual ActionResult Edit(string id)
        {
            return View();
        }

        public virtual ActionResult Delete(string ids)
        {
            return View();
        }

        /// <summary>
        ///     获取数据集，在派生类中实现。
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        protected abstract DataSet GetDataSet(Pagination pagination);

        /// <summary>
        ///     创建一个<see cref="PageViewModel"/>实例。
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        protected virtual PageViewModel CreateIndexViewModel(Pagination pagination)
        {
            return new PageViewModel
            {
                EntityMetadata = EntityMetadata,
                EntityType = typeof(TEntity),
                Pagination = pagination,
                PageConfig = PageConfig
            };
        }

        /// <summary>
        ///     创建一个<see cref="PageDataViewModel{TEntity, TKey}"/>实例。
        /// </summary>
        /// <param name="pageCurrent"></param>
        /// <param name="pageSize"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        protected virtual PageDataViewModel<TEntity, TKey> CreateListViewModel(int pageCurrent, int pageSize, Pagination pagination)
        {
            var dataset = GetDataSet(pagination);
            var totalRecords = int.Parse(dataset.Tables[1].Rows[0][0].ToString());
            var pageDataViewModel = new PageDataViewModel<TEntity, TKey>(totalRecords, pageCurrent, pageSize);
            pageDataViewModel.Items = CreateDataItem(dataset.Tables[0]);
            return pageDataViewModel;
        }

        /// <summary>
        ///     创建数据模型的数据。
        /// </summary>
        /// <param name="dataTable">数据table</param>
        /// <returns></returns>
        protected virtual List<TEntity> CreateDataItem(DataTable dataTable)
        {
            return DataMapper.MapTo<TEntity>(dataTable);
        }

        /// <summary>
        ///     创建实体元数据提供者，默认创建<see cref="Mvc.EntityMetadataProvider"/>实例。可在派生类中重写。
        /// </summary>
        /// <returns></returns>
        protected virtual IEntityMetadataProvider CreateEntityMetadataProvider()
        {
            return new EntityMetadataProvider();
        }

        /// <summary>
        ///     创建数据映射器。
        /// </summary>
        /// <returns></returns>
        protected virtual IDataMapper CreateDataMapper()
        {
            return new DataMapper(EntityMetadata);
        }

        /// <summary>
        ///     创建一个<see cref="JsonReader"/>对象，将指定的对象序列化为JavaScript Object Notation（JSON）。
        /// </summary>
        /// <param name="data">要序列化的对象。</param>
        /// <param name="serializerSettings">设置。</param>
        /// <returns></returns>
        protected virtual JsonResult Json(object data, JsonSerializerSettings serializerSettings)
        {
            return Json(data, null, null, JsonRequestBehavior.DenyGet, serializerSettings);
        }

        /// <summary>
        ///     创建一个<see cref="JsonReader"/>对象，将指定的对象序列化为JavaScript Object Notation（JSON）。
        /// </summary>
        /// <param name="data">要序列化的对象。</param>
        /// <param name="contentType">内容类型（MIME类型）。</param>
        /// <param name="contentEncoding">内容编码。</param>
        /// <returns></returns>
        protected override System.Web.Mvc.JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return Json(data, contentType, contentEncoding, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        ///     创建一个<see cref="JsonReader"/>对象，将指定的对象序列化为JavaScript Object Notation（JSON）。
        /// </summary>
        /// <param name="data">要序列化的对象。</param>
        /// <param name="contentType">内容类型（MIME类型）。</param>
        /// <param name="contentEncoding">内容编码。</param>
        /// <param name="behavior">JSON请求行为。</param>
        /// <returns></returns>
        protected override System.Web.Mvc.JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return Json(data, contentType, contentEncoding, behavior, null);
        }

        /// <summary>
        ///     创建一个<see cref="JsonReader"/>对象，将指定的对象序列化为JavaScript Object Notation（JSON）。
        /// </summary>
        /// <param name="data">要序列化的对象。</param>
        /// <param name="contentType">内容类型（MIME类型）。</param>
        /// <param name="contentEncoding">内容编码。</param>
        /// <param name="behavior">JSON请求行为。</param>
        /// <param name="serializerSettings">设置。</param>
        /// <returns></returns>
        protected virtual JsonResult Json(object data, string contentType, Encoding contentEncoding,
    JsonRequestBehavior behavior,
    JsonSerializerSettings serializerSettings)
        {
            return new JsonResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                SerializerSettings = serializerSettings
            };
        }

    }
}