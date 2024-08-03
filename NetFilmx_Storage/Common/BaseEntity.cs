using System.ComponentModel.DataAnnotations;

namespace NetFilmx_Storage.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
