using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTask.Core.Models
{
    public class DoctorsForOutputList
    {
        public string Full_name { get; set; } = string.Empty;
        public int Office_number { get; set; }
        public string Specialization_name { get; set; } = string.Empty;
        public int District_number { get; set; }
    }
}
