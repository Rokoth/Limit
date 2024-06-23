namespace Limit.Contract.Model
{
    public class CharacteristicFilter(int? size, int? page, string sort, string description, DateTimeOffset? dateFrom, DateTimeOffset? dateTo) 
        : Filter<Characteristic>(size, page, sort)
    {
        public string Description { get; set; } = description;
        public DateTimeOffset? DateFrom { get; set; } = dateFrom;
        public DateTimeOffset? DateTo { get; set; } = dateTo;
    }
}
