using Microsoft.AspNetCore.Mvc;
using StudentRecord.Data;
using StudentRecord.Models;

namespace StudentRecord.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db=db;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["search"] = searchString;
            if (_db.Students == null)
            {
                return Problem("Not Found");
            }
            var student = from s in _db.Students
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                student = student.Where(s => s.Name == searchString);
            }
            return View(student);
            IEnumerable<Student> studentobj = _db.Students;
            return View(studentobj);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
                TempData["success"] ="Student Record Added Successfully";
                return RedirectToAction("Index");
            }
            return View(student);
        }
        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var student = _db.Students.Find(id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(student);
                _db.SaveChanges();
                TempData["success"] = "Student Record Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(student);
        }
    
        public IActionResult Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var student=_db.Students.Find(id);
            if(student == null)
            {
                return NotFound();  
            }
            _db.Students.Remove(student);
            _db.SaveChanges();
            TempData["success"] = "Student Record Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}
