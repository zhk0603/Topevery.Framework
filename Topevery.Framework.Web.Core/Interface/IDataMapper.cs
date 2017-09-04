using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Topevery.Framework.Interface
{
    /// <summary>
    ///     数据映射器接口。
    /// </summary>
    public interface IDataMapper
    {
        /// <summary>
        ///     获取实体源数据。
        /// </summary>
        IEntityMetadata EntityMetadata { get; }

        /// <summary>
        ///     映射数据。
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        List<TEntity> MapTo<TEntity>(DataTable dataTable) where TEntity : class, new();

        /// <summary>
        ///     映射数据。
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        List<TEntity> MapTo<TEntity>(DataSet dataSet, string tableName = null) where TEntity : class, new();

        /// <summary>
        ///     映射数据。
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        List<TEntity> MapTo<TEntity>(DataRow dataRow) where TEntity : class, new();

        /// <summary>
        ///     映射数据。
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dataRows"></param>
        /// <returns></returns>
        List<TEntity> MapTo<TEntity>(IEnumerable<DataRow> dataRows) where TEntity : class, new();
    }
}
