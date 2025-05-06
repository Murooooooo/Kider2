using AspNetCoreGeneratedDocument;
using Kider2.DAL;

using Kider2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kider2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TeacherController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var teachers = _context.teachers.ToList();
            return View(teachers);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher, IFormFile file)
        {
            string filename = @"Upload/" + Guid.NewGuid() + file.FileName;
            string path = Path.Combine(_env.WebRootPath, filename);
            using FileStream fileStream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(fileStream);
            teacher.PhotoUrl = "/" + filename;

            await _context.teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var teachers= _context.teachers.FirstOrDefault(x=>x.Id==id);

            return View(teachers);
        }
        [HttpPost]
        public IActionResult Edit(Teacher teacher,IFormFile file,int id)
        {
            var teachers = _context.teachers.FirstOrDefault(x => x.Id == id);

            string filename = @"Upload/" + Guid.NewGuid() + file.FileName;
            string path = Path.Combine(_env.WebRootPath, filename);
            using FileStream fileStream = new FileStream(path, FileMode.Create);
            file.CopyTo(fileStream);
            teacher.PhotoUrl = "/" + filename;

            teachers.Name=teacher.Name;
            teachers.Duty=teacher.Duty;
            teachers.Title=teacher.Title;
            teachers.Description=teacher.Description;
            teachers.PhotoUrl=teacher.PhotoUrl;
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var delete=_context.teachers.FirstOrDefault(y=>y.Id==id);
            _context.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
