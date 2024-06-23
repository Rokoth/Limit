using System.ComponentModel.DataAnnotations;

namespace Limit.Contract.Model
{
    public class Entity : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Display(Name = "Идентификатор")]
        public Guid Id { get; set; }
    }
}
