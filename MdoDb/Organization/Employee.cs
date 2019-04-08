using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MdoDb.Organization.Model
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]        
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }        

        public int BirthYear { get; set; }
        
        public string Title { get; set; }               
    }
}
