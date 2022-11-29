using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDWithADO.DAL
{
    [Table("emp")]

    public class Employee
    {
        [Key] // this is my PK in table
        [ScaffoldColumn(false)]

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
