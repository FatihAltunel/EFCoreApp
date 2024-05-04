using System.Data;
using EFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace EFCoreApp.Controllers
{
    public class StudentController : Controller{
        private readonly DataContext _context;

        public StudentController (DataContext context){
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(){
            return View(await _context.Students.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            if(id==null){
                return NotFound();
            }
            var student = await _context.Students
            .Include(x => x.CourseRegisters)
            .ThenInclude(x => x.course)
            .FirstOrDefaultAsync(p=> p.StudentId==id);
            if(student == null){
                return NotFound();
            }
            return View("Edit",student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //güvenlik önlemi
        public async Task<IActionResult> Edit(int id, Student EditedStudent){
            if(id!=EditedStudent.StudentId){
                return NotFound();
            }
            if(ModelState.IsValid){
                try{
                    _context.Update(EditedStudent);
                    await _context.SaveChangesAsync();
                }catch(DBConcurrencyException){
                    if(!_context.Students.Any(s => s.StudentId==EditedStudent.StudentId)){
                        return NotFound();
                    }else{
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
                return View(EditedStudent);

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
                return RedirectToAction("Index");
            }
            else{
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id){
            if(id==null){
                return NotFound();
            }

            var student = _context.Students.FirstOrDefault(s => s.StudentId == id); 

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, Student student){
            if(id!=student.StudentId){
                return NotFound();
            }
            _context.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}