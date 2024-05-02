using Microsoft.AspNetCore.Mvc;
using EFCoreApp.Data;
using Microsoft.EntityFrameworkCore;
namespace EFCoreApp.Controllers
{
    public class CourseController:Controller{

        private readonly DataContext _context;

        public CourseController (DataContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Index(){
            return View(await _context.Courses.ToListAsync());
        }

        [HttpGet]
        public ActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Course course){
            if (ModelState.IsValid){
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else{
                return View(course);
            }
        }

    }
}