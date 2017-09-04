namespace Topevery.Framework.Interface
{
    /// <summary>
    ///     数据注释接口。
    /// </summary>
    public interface IDataAnnotations
    {
        /// <summary>
        ///     初始化 <see cref="IEntityPropertyMetadata" />。
        /// </summary>
        /// <param name="runtimeProperty"></param>
        void SetRuntimeProperty(IEntityPropertyMetadata runtimeProperty);
    }
}