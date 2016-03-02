using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Portal.Core
{
    public class CV
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
    }
}
