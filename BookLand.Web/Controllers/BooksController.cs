namespace BookLand.Web.Controllers;
public class BooksController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View("Form");
    }
}
