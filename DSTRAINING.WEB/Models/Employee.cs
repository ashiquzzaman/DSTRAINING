using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSTRAINING.WEB.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(128)]
        public string Email { get; set; }
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Department Department { get; set; }
    }
}