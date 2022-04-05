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
        public IActionResult Create()
        {
        
        return View();
        }
      [HttpPost]
      [ValidateAntiForgeryToken]
       public IActionResult Create(Category obj)
       {
        if (ModelState.IsValid)
        {
            _db.Categorys.Add(obj);
            _db.SaveChanges();
            TempData["successs"] = "Category created succesfully";
            return RedirectToAction("Index");
        }
        return View(obj);
       }
    public IActionResult Edit(int? id)
    {
        if(id == null|| id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categorys.Find(id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
            return View(categoryFromDb);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (ModelState.IsValid)
        {
            _db.Categorys.Update(obj);
            _db.SaveChanges();
            TempData["successs"] = "Category Edited succesfully";
            return View();
        }
        return View(obj);
    }
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categorys.Find(id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _db.Categorys.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
        _db.Categorys.Remove(obj);
            _db.SaveChanges();
        TempData["successs"] = "Category Deleted succesfully";
        return RedirectToAction("Index");
    }
}


