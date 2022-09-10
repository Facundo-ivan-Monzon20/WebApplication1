using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace userApp.DAL.Entities
{

    [Table("user")]
    public class UserContext
    {
        [Key]
        public int userId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DNI { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool Inactive { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateBy { get; set; }
    }
}
