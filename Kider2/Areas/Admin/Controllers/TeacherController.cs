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
            string filename = $"/images/" + Guid.NewGuid() + file.FileName;
            string path = Path.Combine(_env.WebRootPath, filename);
            using FileStream fileStream = new FileStream(path, FileMode.Create);

            teacher.PhotoUrl =filename;

            await _context.teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
