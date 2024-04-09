using BookLand.Web.Core.ViewModels;

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
    public IActionResult Create()
    {
        return View("Form");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CategoryFromViewModel model)
    {
        if (!ModelState.IsValid)
            return View("Form", model);

        Category category = new() { Name = model.Name };
        _context.Categories.Add(category);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        Category? category = _context.Categories.Find(id);
        if (category is null)
            return NotFound();

        CategoryFromViewModel model = new() { Id = id, Name = category.Name };

        return View("Form", model);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CategoryFromViewModel model)
    {
        if (!ModelState.IsValid)
            return View("Form", model);

        Category? category = _context.Categories.Find(model.Id);

        if (category is null)
            return NotFound();

        category.Name = model.Name;
        category.LastUpdatedOn = DateTime.Now;
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
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
