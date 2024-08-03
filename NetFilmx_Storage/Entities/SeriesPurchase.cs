using NetFilmx_Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("SeriesPurchases", Schema = "NetFilmx")]
    public class SeriesPurchase : BaseEntity
    {
        public SeriesPurchase() { }

        public SeriesPurchase(int userId, int seriesId)
        {
            UserId = userId;
            SeriesId = seriesId;
            PurchaseDate = DateTime.Now;
        }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(User.SeriesPurchases))]
        public virtual User User { get; set; }

        [Required]
        public int SeriesId { get; set; }

        [ForeignKey(nameof(SeriesId))]
        [InverseProperty(nameof(Series.SeriesPurchases))]
        public virtual Series Series { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }
    }
}
