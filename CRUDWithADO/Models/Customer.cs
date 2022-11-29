using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace CRUDWithADO.Models
{
    [Table("customer")]
    public class Customer //entity model business object(BO)
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required (ErrorMessage ="Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        public string? Contact { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }




    }
}
