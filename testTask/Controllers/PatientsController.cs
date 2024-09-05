using Microsoft.AspNetCore.Mvc;
using testTask.Application.Services;
using testTask.Contracts;

namespace testTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientsRequest request)
        {
            await _patientService.AddPatient(request.Second_name, request.First_name, request.Middle_name,
                request.Address, request.Date_of_bith, request.Gender, request.District_number);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditingPatient(int id, [FromBody] PatientsRequest request)
        {
            await _patientService.EditingPatient(id, request.Second_name, request.First_name, request.Middle_name,
                request.Address, request.Date_of_bith, request.Gender, request.District_number);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientService.DeletePatienr(id);

            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            return Ok(await _patientService.GetPatientById(id));
        }
        [HttpGet("{sotringParameter}/{page}")]
        public async Task<IActionResult> GetPatientslist(string sotringParameter, int page)
        {
            return Ok(await _patientService.GetPatientsList(sotringParameter, page));
        }
    }
}
