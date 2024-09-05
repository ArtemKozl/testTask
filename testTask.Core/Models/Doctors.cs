using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTask.Core.Models
{
    public class Doctors
    {
        public Doctors(int id, string full_name, int office_id, int specialization_id, int distrct_id) 
        {
            Id = id;
            Full_name = full_name;
            Office_id = office_id;
            Specialization_id = specialization_id;
            District_id = distrct_id;
        }
        public int Id { get; set; }
        public string Full_name { get; set; }
        public int Office_id { get; set; }
        public int Specialization_id { get; set; }
        public int District_id { get; set; }

        public static Doctors Create(int id, string full_name, int office_id, int specialization_id, int district_id)
        {
            var doctor = new Doctors(id, full_name, office_id, specialization_id, district_id);

            return doctor;
        }
    }
}
