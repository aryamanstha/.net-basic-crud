using Microsoft.AspNetCore.Mvc;
using StudentRecord.Data;
using StudentRecord.Models;

namespace StudentRecord.Controllers
{
    public class ImageController : Controller
    {
        public readonly ApplicationDbContext _db;
        public ImageController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        //get
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentImage image)
        {
            if (image.ImageFile != null && image.ImageFile.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await image.ImageFile.CopyToAsync(stream);
                    image.ImageData = stream.ToArray();
                }
                await _db.StudentImages.AddAsync(image);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please select an image file.");
            return View(image);
        }

    }
}
