using EFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Controllers
{
    public class LecturerController : Controller{
        private readonly DataContext _context;

        public LecturerController (DataContext context){
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(){
            return View(await _context.Lecturers.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Create(){
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId","CourseName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lecturer model){
            if (model == null){return NotFound();}
            if(ModelState.IsValid){
                _context.Lecturers.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId","CourseName");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            if (id == null){return NotFound();}
            var model = await _context.Lecturers
            .Include(x=>x.Courses)
            .FirstOrDefaultAsync(x=>x.LecturerId==id);
            if(model==null){
                return NotFound();
            }
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId","CourseName");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(int id, Lecturer model){
            if(model.LecturerId != id){return NotFound();}
            if(ModelState.IsValid){
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId","CourseName");
            return View(model);
        }
        [HttpGet]
        public  IActionResult Delete(int? id){
            if(id==null){return NotFound();}
            var model = _context.Lecturers.FirstOrDefault(x=>x.LecturerId==id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Lecturer lecturer){

            if (lecturer.LecturerId != id)
            {
                return NotFound();
            }
            
            var course =  await _context.Courses.FirstOrDefaultAsync(x=>x.LecturerId ==lecturer.LecturerId);
            if(course!=null){
                 course.lecturer = null;
                 course.LecturerId=null;
                 await _context.SaveChangesAsync();
            }
            _context.Lecturers.Remove(lecturer);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
    }
}