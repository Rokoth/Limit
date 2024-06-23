namespace Limit.Contract.Model
{
    public class MapFilter(int? size, int? page, string sort, string description, DateTimeOffset? dateFrom, DateTimeOffset? dateTo)
        : Filter<Map>(size, page, sort)
    {
        public string Description { get; set; } = description;
        public DateTimeOffset? DateFrom { get; set; } = dateFrom;
        public DateTimeOffset? DateTo { get; set; } = dateTo;
    }
}
