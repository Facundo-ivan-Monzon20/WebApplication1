using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userApp.models
{
    public class GroupModel
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string Inactive { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateBy { get; set; }
    }
}
