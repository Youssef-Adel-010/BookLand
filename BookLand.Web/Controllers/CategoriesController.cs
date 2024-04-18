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
        List<CategoryViewModel> categories = [.. _context.Categories
            .Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                IsDeleted = c.IsDeleted,
                CreatedOn = c.CreatedOn,
                LastUpdatedOn = c.LastUpdatedOn
            })
            .AsNoTracking()];

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

        CategoryViewModel viewModel = new()
        {
            Id = category.Id,
            Name = category.Name,
            IsDeleted = category.IsDeleted,
            CreatedOn = category.CreatedOn,
            LastUpdatedOn = category.LastUpdatedOn
        };

        return PartialView("_CategoryRaw", viewModel);
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

        CategoryViewModel viewModel = new()
        {
            Id = category.Id,
            Name = category.Name,
            IsDeleted = category.IsDeleted,
            CreatedOn = category.CreatedOn,
            LastUpdatedOn = category.LastUpdatedOn
        };

        return PartialView("_CategoryRaw", viewModel);
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

    public IActionResult IsAllowdRecord(CategoryFromViewModel model)
    {
        Category? category = _context.Categories.SingleOrDefault(c => c.Name == model.Name);
        bool isAllowed = category is null || category.Id == model.Id;

        return Json(isAllowed);
    }

}
