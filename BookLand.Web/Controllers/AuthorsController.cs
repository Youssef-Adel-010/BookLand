using BookLand.Web.Core.ViewModels.Authors;

namespace BookLand.Web.Controllers;
public class AuthorsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AuthorsController(ApplicationDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    public IActionResult Index()
    {
        var authors = _context.Authors.AsNoTracking().ToList();

        var viewModel = _mapper.Map<AuthorViewModel>(authors);

        return View(viewModel);
    }
}
