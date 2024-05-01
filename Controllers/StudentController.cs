using EFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace EFCoreApp.Controllers
{
    public class StudentController : Controller{
        private readonly DataContext _context;

        public StudentController (DataContext context){
            _context = context;
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student model){
            if (ModelState.IsValid){
                _context.Students.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            else{
                return View(model);
            }
        }
    }
}