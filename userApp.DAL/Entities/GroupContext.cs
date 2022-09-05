using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace userApp.DAL.Entities
{

    [Table("group")]
    public class GroupContext
    {
        [Key]
        public int groupId { get; set; }
        public string groupName { get; set; }
        public bool Disabled { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string LastUpdateBy { get; set; }
    }
}
