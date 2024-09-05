using Microsoft.AspNetCore.Mvc;
using testTask.Application.Services;
using testTask.Contracts;

namespace testTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService) 
        {
            _doctorService = doctorService;
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorRequest request)
        {
            await _doctorService.AddDoctor(request.Full_name, request.District_number ,request.Office_number, request.Specialization_name);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditingDoctor(int id, [FromBody] DoctorRequest request) 
        {
            await _doctorService.EditingDoctor(id, request.Full_name, request.Office_number, request.District_number, request.Specialization_name);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorService.DeleteDoctor(id);

            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            return Ok(await _doctorService.GetDoctorBtId(id));
        }
        [HttpGet("{sotringParameter}/{page}")]
        public async Task<IActionResult> GetDoctorslist(string sotringParameter, int page)
        {
            return Ok(await _doctorService.GetDoctorsList(sotringParameter, page));
        }
    }
}
