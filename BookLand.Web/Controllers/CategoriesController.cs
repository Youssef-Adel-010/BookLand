using BookLand.Web.Core.ViewModels;
using BookLand.Web.Filters;

namespace BookLand.Web.Controllers;
public class CategoriesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        // TODO: use ViewModel
        List<Category> categories = [.. _context.Categories.AsNoTracking()];
        return View(categories);
    }

    [HttpGet]
    [AjaxOnlyFilter]
    public IActionResult Create()
    {
        return PartialView("_Form");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CategoryFromViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        Category category = new() { Name = model.Name };
        _context.Categories.Add(category);
        _context.SaveChanges();

        return PartialView("_CategoryRaw", category);
    }

    [HttpGet]
    [AjaxOnlyFilter]
    public IActionResult Edit(int id)
    {
        Category? category = _context.Categories.Find(id);
        if (category is null)
            return NotFound();

        CategoryFromViewModel model = new() { Id = id, Name = category.Name };

        return PartialView("_Form", model);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CategoryFromViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        Category? category = _context.Categories.Find(model.Id);

        if (category is null)
            return NotFound();

        category.Name = model.Name;
        category.LastUpdatedOn = DateTime.Now;
        _context.SaveChanges();

        return PartialView("_CategoryRaw", category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ToggleState(int id)
    {
        Category? category = _context.Categories.Find(id);

        if (category is null)
            return NotFound();

        category.IsDeleted = !category.IsDeleted;
        category.LastUpdatedOn = DateTime.Now;

        _context.SaveChanges();

        return Ok(category.LastUpdatedOn.ToString());
    }

}
