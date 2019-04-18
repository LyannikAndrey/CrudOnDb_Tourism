using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOnDb_MVC.Models
{
    public partial class Hotels
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotels()
        {
            Tour_point = new HashSet<Tour_point>();
        }

        public Hotels(byte rating, string name, double hotelCost, string typeOfRoom, string accommodation, string food, string address)
        {
            Rating = rating;
            Name = name;
            HotelCost = hotelCost;
            TypeOfRoom = typeOfRoom;
            Accommodation = accommodation;
            Food = food;
            Address = address;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Hotel_ID { get; set; }

        public byte Rating { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public double HotelCost { get; set; }

        [StringLength(15)]
        public string TypeOfRoom { get; set; }

        [Required]
        [StringLength(15)]
        public string Accommodation { get; set; }

        [StringLength(15)]
        public string Food { get; set; }

        [Required]
        [StringLength(60)]
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour_point> Tour_point { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
