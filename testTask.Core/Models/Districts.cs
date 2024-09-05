using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTask.Core.Models
{
    public class Districts
    {
        public Districts(int number) 
        { 
            Number = number;
        }
        public int Id { get; set; }
        public int Number { get; set; }
    }
}
