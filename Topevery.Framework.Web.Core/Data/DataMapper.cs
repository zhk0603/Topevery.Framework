using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Topevery.Framework.Interface;
using Topevery.Framework.Utility;

namespace Topevery.Framework.Data
{
    /// <summary>
    ///     默认的数据映射器。
    /// </summary>
    public class DataMapper : IDataMapper
    {
        private readonly IEntityMetadata _entityMetadata;

        /// <summary>
        ///     初始化<see cref="DataMapper"/>。
        /// </summary>
        /// <param name="entityMetadata"></param>
        public DataMapper(IEntityMetadata entityMetadata)
        {
            _entityMetadata = entityMetadata;
        }

        /// <summary>
        ///     获取实体源数据。
        /// </summary>
        public IEntityMetadata EntityMetadata
        {
            get
            {
                return _entityMetadata;
            }
        }

        /// <summary>
        ///     映射数据。
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public List<TEntity> MapTo<TEntity>(DataTable dataTable)
            where TEntity : class, new()
        {
            if (dataTable == null)
                throw new ArgumentNullException(nameof(dataTable));

            return FillEntitys<TEntity>(dataTable.AsEnumerable());
        }

        /// <summary>
        ///     映射数据。
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dataRows"></param>
        /// <returns></returns>
        public List<TEntity> MapTo<TEntity>(IEnumerable<DataRow> dataRows)
            where TEntity : class, new()
        {
            if (dataRows == null)
                throw new ArgumentNullException(nameof(dataRows));

            return FillEntitys<TEntity>(dataRows);
        }

        /// <summary>
        ///     映射数据。
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        public List<TEntity> MapTo<TEntity>(DataRow dataRow)
            where TEntity : class, new()
        {
            if (dataRow == null)
                throw new ArgumentNullException(nameof(dataRow));

            return FillEntitys<TEntity>(new List<DataRow> { dataRow });
        }

        /// <summary>
        ///     映射数据。
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<TEntity> MapTo<TEntity>(DataSet dataSet, string tableName = null)
            where TEntity : class, new()
        {
            if (dataSet == null)
                throw new ArgumentNullException(nameof(dataSet));

            var dataTable = string.IsNullOrEmpty(tableName) ? dataSet.Tables[0] : dataSet.Tables[tableName];
            return FillEntitys<TEntity>(dataTable.AsEnumerable());
        }

        /// <summary>
        ///     填充。
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dataRows"></param>
        /// <returns></returns>
        protected virtual List<TEntity> FillEntitys<TEntity>(IEnumerable<DataRow> dataRows) where TEntity : class, new()
        {
            var result = new List<TEntity>();
            foreach (DataRow row in dataRows)
            {
                TEntity model = new TEntity();
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    var columnName = row.Table.Columns[i].ColumnName;
                    var propertyInfo = EntityMetadata.PropertyMetadatas
                        .SingleOrDefault(x => x.ColModelName == columnName
                                            || x.ColModelIndex == columnName
                                            || x.PropertyInfo.Name == columnName)
                        ?.PropertyInfo;

                    if (propertyInfo != null && row[i] != DBNull.Value)
                        propertyInfo.SetValue(model, row[i], null);
                }
                result.Add(model);
            }
            return result;
        }
    }
}
