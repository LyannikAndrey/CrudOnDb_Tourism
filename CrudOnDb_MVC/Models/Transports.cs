using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudOnDb_MVC.Models
{
    public partial class Transports
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transports()
        {
            Tour_point = new HashSet<Tour_point>();
        }

        [Key]
        public int Transport_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour_point> Tour_point { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
