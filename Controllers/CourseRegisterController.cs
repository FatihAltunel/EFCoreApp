using EFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Controllers
{
    public class CourseRegisterController: Controller{
        private readonly DataContext _context;

        public CourseRegisterController (DataContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(){
            var courseRegister = await _context.CourseRegisters
                                                                .Include(x=> x.student)
                                                                .Include(x=>x.course)
                                                                .ToListAsync();
            return View(courseRegister);
        }

        [HttpGet]
        public async Task<IActionResult> Create(){
            ViewBag.Students = new SelectList(await _context.Students.ToListAsync(), "StudentId","StudentName"); 
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId","CourseName"); 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseRegister model){
            if (!ModelState.IsValid){
                model.RegsiterDate = DateTime.Now;
                _context.CourseRegisters.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}