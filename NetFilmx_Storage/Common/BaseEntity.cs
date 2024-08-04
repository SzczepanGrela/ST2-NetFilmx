using System.ComponentModel.DataAnnotations;

namespace NetFilmx_Storage.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
