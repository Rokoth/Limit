using Limit.Db.Attributes;
using System;

namespace Limit.Db.Model
{
    [TableName("h_person")]
    public class PersonHistory : EntityHistory
    {
        [ColumnName("userid")]
        public Guid UserId { get; set; }

        [ColumnName("name")]
        public string Name { get; set; }

        [ColumnName("description")]
        public string Description { get; set; }

        [ColumnName("locationid")]
        public Guid LocationId { get; set; }

        [ColumnName("lastactivedate")]
        public DateTimeOffset LastActiveDate { get; set; }

        [ColumnName("createddate")]
        public DateTimeOffset Createddate { get; set; }
    }
}