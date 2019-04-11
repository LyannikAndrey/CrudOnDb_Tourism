using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOnDb_MVC.Models
{
    public partial class Tours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tours()
        {
            Orders = new HashSet<Orders>();
            Tour_point = new HashSet<Tour_point>();
        }

        public Tours(string country, DateTime arrivalDate, DateTime departureDate, double tourCost, int numberOfPersons, string type)
        {
            Country = country;
            ArrivalDate = arrivalDate;
            DepartureDate = departureDate;
            Tour_cost = tourCost;
            NumberOfPersons = numberOfPersons;
            Type = type;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tour_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Country { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime ArrivalDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DepartureDate { get; set; }

        public int? LengthOfStay { get; set; }

        public double Tour_cost { get; set; }

        public int NumberOfPersons { get; set; }

        [Required]
        [StringLength(15)]
        public string Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour_point> Tour_point { get; set; }

        public override string ToString()
        {
            return Country;
        }
    }
}
