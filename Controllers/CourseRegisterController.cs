using System.Data;
using System.Diagnostics.Eventing.Reader;
using EFCoreApp.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                var courseRegister =await _context.CourseRegisters.ToListAsync();
                if(courseRegister.FirstOrDefault(x=>x.CourseId==model.CourseId && x.StudentId==model.StudentId)!=null){
                    {
                        TempData["Message"] = "Course registration already exists.";
                    }
                    ViewBag.Students = new SelectList(await _context.Students.ToListAsync(), "StudentId","StudentName"); 
                    ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId","CourseName"); 
                    return View(model);
                }
                _context.CourseRegisters.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Students = new SelectList(await _context.Students.ToListAsync(), "StudentId","StudentName"); 
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId","CourseName"); 
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            if(id==null){
                return NotFound();
            }
            ViewBag.Students = new SelectList(await _context.Students.ToListAsync(), "StudentId","StudentName"); 
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId","CourseName"); 
            var model = await _context.CourseRegisters
            .Include(x=>x.course)
            .Include(x=>x.student)
            .FirstOrDefaultAsync(x=>x.CourseRegisterId==id);

            return View ("Edit",model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseRegister model){
            if(!_context.CourseRegisters.Any(s => s.CourseRegisterId==model.CourseRegisterId)){
                return NotFound();
            }
            if(model.CourseRegisterId!=id){
                return NotFound();
            }
            if(_context.CourseRegisters.FirstOrDefault(x=> x.CourseId==model.CourseId && x.StudentId==model.StudentId && x.RegsiterDate == model.RegsiterDate)!=null){
                    {
                    TempData["Message"] = "Course registration already exists.";
                    }
                    ViewBag.Students = new SelectList(await _context.Students.ToListAsync(), "StudentId","StudentName"); 
                    ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId","CourseName"); 
                    return View(model);
            }
            _context.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id){
            if(id==null){ 
                return NotFound();
            }
            var model = await _context.CourseRegisters
            .Include(x=>x.course)
            .Include(x=>x.student)
            .FirstOrDefaultAsync(x => x.CourseRegisterId == id);
            if(model==null){
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete( int? id, CourseRegister model){
            if(id!=model.CourseRegisterId){
                return NotFound();
            }
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}