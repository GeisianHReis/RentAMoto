using System.ComponentModel.DataAnnotations;

namespace RentAMoto.Domain.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}