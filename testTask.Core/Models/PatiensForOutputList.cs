
namespace testTask.Core.Models
{
    public class PatiensForOutputList
    {
        public string Second_name { get; set; } = string.Empty;
        public string First_name { get; set; } = string.Empty;
        public string Middle_name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly Date_of_bith { get; set; }
        public char Gender { get; set; }
        public int District_number { get; set; }
    }
}
