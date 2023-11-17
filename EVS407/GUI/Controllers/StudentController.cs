using Infrastructure.Implementation;
using Infrastructure.Interface;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace GUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ISetupRepository _setupRepository;

        public StudentController(IStudentRepository studentRepository, ISetupRepository setupRepository)
        {
            _studentRepository = studentRepository;
            _setupRepository = setupRepository;
        }
        public async Task<IActionResult> Students()
        {
            return View(await _studentRepository.StudentGetAll());
        }
        public async Task<IActionResult> StudentCreate()
        {
            return View(new StudentCreateVM
            {
                Genders = await _setupRepository.GenderGetAll()
            });
        }
        [HttpPost]
        public async Task<IActionResult> StudentCreate(StudentCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _studentRepository.StudentCreate(model);
                if (result)
                {
                    ModelState.AddModelError("", "Student Created!");
                }
                else
                {
                    ModelState.AddModelError("", "Student Created!");
                }

            }
            return View(new StudentCreateVM
            {
                Genders = await _setupRepository.GenderGetAll()
            });
        }
        [HttpGet]
        public async Task<IActionResult> StudentUpdate(int Id)
        {
            return View(await _studentRepository.StudentGetById(Id));
        }
        [HttpPost]
        public async Task<IActionResult> StudentUpdate(StudentUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _studentRepository.StudentUpdate(model);
                if (result)
                {
                    ModelState.AddModelError("", "Student Updated!");
                }
                else
                {
                    ModelState.AddModelError("", "error!");
                }
            }
            return View(await _studentRepository.StudentGetById(model.Id)); 
        }
        [HttpGet]
        public async Task<IActionResult> StudentDelete(int Id)
        {
            var result = await _studentRepository.StudentDelete(Id);
            return RedirectToAction("Students", new { Controller = "Student" });
        }
    }
}
