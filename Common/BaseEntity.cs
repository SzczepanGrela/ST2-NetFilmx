using System.ComponentModel.DataAnnotations;

namespace st2_projekt.Common
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
