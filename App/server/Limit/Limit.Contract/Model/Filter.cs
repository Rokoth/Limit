namespace Limit.Contract.Model
{
    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="size">Page size</param>
    /// <param name="page">Page number</param>
    /// <param name="sort">Sort field</param>
    public abstract class Filter<T>(int? size, int? page, string sort) : IFilter<T> where T : Entity
    {
        /// <summary>
        /// Page size
        /// </summary>
        public int? Size { get; } = size;
        /// <summary>
        /// Page number
        /// </summary>
        public int? Page { get; } = page;
        /// <summary>
        /// Sort field
        /// </summary>
        public string Sort { get; } = sort;
    }
}
