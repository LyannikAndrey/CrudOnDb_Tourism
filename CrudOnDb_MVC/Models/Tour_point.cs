using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOnDb_MVC.Models
{
    public partial class Tour_point
    {
        public Tour_point()
        {
        }

        public Tour_point(int tourId, int? transportId, int? hotelId, string city)
        {
            Tour_ID = tourId;
            Transport_ID = transportId;
            Hotel_ID = hotelId;
            City = city;
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tour_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tour_point_ID { get; set; }

        public int? Transport_ID { get; set; }

        public int? Hotel_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        public virtual Hotels Hotels { get; set; }

        public virtual Tours Tours { get; set; }

        public virtual Transports Transports { get; set; }
    }
}
