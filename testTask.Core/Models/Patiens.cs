using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTask.Core.Models
{
    public class Patiens
    {
        public Patiens(int id, string second_name, string first_name, string middle_name,
            string address, DateOnly date_of_bith, char gender, int district_id) 
        {
            Id = id;
            Second_name = second_name;
            First_name = first_name;
            Middle_name = middle_name;
            Address = address;
            Date_of_bith = date_of_bith;
            Gender = gender;
            District_id = district_id;
        }
        public int Id { get; set; }
        public string Second_name { get; set; } = string.Empty;
        public string First_name { get; set; } = string.Empty;
        public string Middle_name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly Date_of_bith { get; set; }
        public char Gender { get; set; }
        public int District_id { get; set; }

        public static Patiens Create(int id, string second_name, string first_name,
            string middle_name, string address, DateOnly date_of_bith, char gender, int distrct_id)
        {
            var patient = new Patiens(id, second_name, first_name, middle_name, address, date_of_bith, gender, distrct_id);

            return patient;
        }
    }
}
