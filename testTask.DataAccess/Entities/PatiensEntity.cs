using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTask.DataAccess.Entities
{
    public class PatiensEntity
    {
        public int id { get; set; }
        public string second_name { get; set; } = string.Empty;
        public string first_name { get; set; } = string.Empty;
        public string middle_name { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public DateOnly date_of_bith {  get; set; }
        public char gender {  get; set; } 
        public int district_id { get; set; }
    }
}
