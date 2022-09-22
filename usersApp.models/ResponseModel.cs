using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userApp.models
{
    public class ResponseModel
    {
        public bool Succes { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
        
        
    }
}
