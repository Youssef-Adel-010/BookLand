using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookLand.Web.Controllers;
public class BooksController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public BooksController(ApplicationDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {

        var authors = _context.Authors
            .Where(a => !a.IsDeleted)
            .OrderBy(a => a.Name)
            .ToList();

        var categories = _context.Categories
            .Where(c => !c.IsDeleted)
            .OrderBy(c => c.Name)
            .ToList();

        BookFormViewModel viewModel = new()
        {
            Authors = _mapper.Map<IEnumerable<SelectListItem>>(authors),
            Categories = _mapper.Map<IEnumerable<SelectListItem>>(categories)
        };

        return View("Form", viewModel);
    }
}
