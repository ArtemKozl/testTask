using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTask.DataAccess.Entities
{
    public class DoctorsEntity
    {
        public int id {  get; set; }
        public string full_name { get; set; } = string.Empty;
        public int office_id { get; set; }
        public int specialization_id { get; set; }
        public int district_id { get; set; }
    }
}
