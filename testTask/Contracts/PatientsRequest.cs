using System.ComponentModel.DataAnnotations;

namespace testTask.Contracts
{
    public record PatientsRequest(
        [Required] string Second_name,
        [Required] string First_name,
        [Required] string Middle_name,
        [Required] string Address,
        [Required] DateOnly Date_of_bith,
        [Required] char Gender,
        [Required] int District_number
        );
    
}
