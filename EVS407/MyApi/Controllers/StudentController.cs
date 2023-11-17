using Infrastructure.Implementation;
using Infrastructure.Interface;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [Route("Students")]
        [HttpGet]
        public async Task<IActionResult> Students()
        {
            var students = await _studentRepository.StudentGetAll();
            students = null;
            foreach(var item in students)
            {
                item.PhoneNumber = string.Empty;
            }
            return Ok(await _studentRepository.StudentGetAll());
        }
        [Route("StudentGetById")]
        [HttpGet]
        public async Task<IActionResult> StudentGetById(int Id)
        {
            var result = await _studentRepository.StudentGetById(Id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("StudentUpdate")]
        public async Task<IActionResult> StudentUpdate([FromBody] StudentUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _studentRepository.StudentUpdate(model));
            }
            else
            {
                return Ok("please provide all information");
            }
        }
        [HttpDelete]
        [Route("StudentDelete")]
        public async Task<IActionResult> StudentDelete(int Id)
        {
            return Ok(await _studentRepository.StudentDelete(Id));
        }
    }
}
