using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOnDb_MVC.Models
{
    public partial class Clients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clients()
        {
            Orders = new HashSet<Orders>();
        }

        public Clients(string surname, string name, string patronymic, string phone, string email, string address)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Phone = phone;
            Email = email;
            Address = address;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Client_ID { get; set; }

        [Required]
        [StringLength(18)]
        public string Surname { get; set; }

        [Required]
        [StringLength(18)]
        public string Name { get; set; }

        [StringLength(18)]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(20)]
        public string Email { get; set; }

        [Required]
        [StringLength(40)]
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }

        public override string ToString()
        {
            return Surname + " " + Name + " " + Patronymic;
        }
    }
}
