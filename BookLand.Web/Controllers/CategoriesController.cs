namespace BookLand.Web.Controllers;
public class CategoriesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public CategoriesController(ApplicationDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var categories = _context.Categories.AsNoTracking().ToList();

        var viewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

        return View(viewModel);
    }

    [HttpGet]
    [AjaxOnlyFilter]
    public IActionResult Create()
    {
        return PartialView("_Form");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CategoryFormViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        Category category = _mapper.Map<Category>(model);

        _context.Categories.Add(category);
        _context.SaveChanges();

        CategoryViewModel viewModel = _mapper.Map<CategoryViewModel>(category);

        return PartialView("_CategoryRaw", viewModel);
    }

    [HttpGet]
    [AjaxOnlyFilter]
    public IActionResult Edit(int id)
    {
        Category? category = _context.Categories.Find(id);

        if (category is null)
            return NotFound();

        CategoryFormViewModel model = _mapper.Map<CategoryFormViewModel>(category);

        return PartialView("_Form", model);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CategoryFormViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        Category? category = _context.Categories.Find(model.Id);

        if (category is null)
            return NotFound();

        category = _mapper.Map(model, category);
        category.LastUpdatedOn = DateTime.Now;
        _context.SaveChanges();

        CategoryViewModel viewModel = _mapper.Map<CategoryViewModel>(category);

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

    public IActionResult IsAllowdRecord(CategoryFormViewModel model)
    {
        Category? category = _context.Categories.SingleOrDefault(c => c.Name == model.Name);

        bool isAllowed = category is null || category.Id == model.Id;

        return Json(isAllowed);
    }

}
