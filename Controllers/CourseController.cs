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
        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            if(id==null){
                return NotFound();
            }
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId==id);
            if(course==null){
                return NotFound();
            }

            return View("Edit", course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Course course){
         if(id!=course.CourseId){
            return NotFound();
         }   
         if(ModelState.IsValid){
            _context.Update(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
         }
         return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id){
            if(id==null){ return NotFound();}
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId==id);
            if(course == null){
                return NotFound();
            }
            return View("Delete", course);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Course course){
            if(id!=course.CourseId){ return NotFound(); }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}