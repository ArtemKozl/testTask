using System.ComponentModel.DataAnnotations;

namespace testTask.Contracts
{
    public record DoctorRequest(
        [Required] string Full_name,
        [Required] int Office_number,
        [Required] string Specialization_name,
        [Required] int District_number
        );
    
}
