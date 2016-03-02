using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Portal.Core
{
    public class Project
    {
        public int Id { get; set; }
        public string Period { get; set; }
        public int Team { get; set; }
        public string Position { get; set; }
    }
}
