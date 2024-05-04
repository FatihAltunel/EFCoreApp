using Microsoft.AspNetCore.Mvc;
using EFCoreApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace EFCoreApp.Controllers
{
    public class CourseController:Controller{

        private readonly DataContext _context;

        public CourseController (DataContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Index(){
            return View(await _context.Courses.Include(m=>m.lecturer).ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult> Create(){
            var lecturers = await _context.Lecturers.ToListAsync();
            ViewBag.Lecturers = new SelectList(lecturers, "LecturerId", "LecturerName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Course course){
            if(course==null){return NotFound();}
            if (!ModelState.IsValid==true){
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else{
                var lecturers = await _context.Lecturers.ToListAsync();
                ViewBag.Lecturers = new SelectList(lecturers, "LecturerId", "LecturerName");
                return View(course);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            if(id==null){
                return NotFound();
            }
            var course = await _context.Courses
            .Include(x=>x.lecturer)
            .Include(x => x.CourseRegisters)
            .ThenInclude(x => x.student)
            .FirstOrDefaultAsync(c => c.CourseId==id);
            if(course==null){
                return NotFound();
            }
            ViewBag.Lecturers = new SelectList(await _context.Lecturers.ToListAsync(),"LecturerId","LecturerName");
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
         ViewBag.Lecturers = new SelectList(await _context.Lecturers.ToListAsync(),"LecturerId","LecturerName");
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