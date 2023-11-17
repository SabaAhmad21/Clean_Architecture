using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<IActionResult> Students()
        {
            return View(await _studentRepository.StudentGetAll());
        }
    }
}
