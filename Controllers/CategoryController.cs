using freecode.Data;
using freecode.Models;
using Microsoft.AspNetCore.Mvc;

    namespace freecode.Controllers;
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categorys;
            return View(objCategoryList);
        }
    }


