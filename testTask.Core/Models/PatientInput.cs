using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTask.Core.Models
{
    public class PatientInput
    {
        public int Id { get; set; }
        public string Second_name { get; set; } = string.Empty;
        public string First_name { get; set; } = string.Empty;
        public string Middle_name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly Date_of_bith { get; set; }
        public char Gender { get; set; }
        public int District_number { get; set; }
    }
}
