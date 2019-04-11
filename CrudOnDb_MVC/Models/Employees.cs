using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOnDb_MVC.Models
{
    public partial class Employees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employees()
        {
            Orders = new HashSet<Orders>();
        }

        public Employees(string surname, string name, string patronymic, string phone, string email)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Phone = phone;
            Email = email;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Employee_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string Surname { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(15)]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(13)]
        public string Phone { get; set; }

        [Required]
        [StringLength(20)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }

        public override string ToString()
        {
            return Surname + " " + Name + " " + Patronymic;
        }
    }
}
