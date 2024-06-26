﻿using BookLand.Web.Core.ViewModels.Authors;
using BookLand.Web.Core.ViewModels.Categories;

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

        var viewModel = _mapper.Map<IEnumerable<AuthorViewModel>>(authors);

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
    public IActionResult Create(AuthorFormViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        Author author = _mapper.Map<Author>(model);

        _context.Authors.Add(author);
        _context.SaveChanges();

        AuthorViewModel viewModel = _mapper.Map<AuthorViewModel>(author);

        return PartialView("_AuthorRaw", viewModel);
    }

    [HttpGet]
    [AjaxOnlyFilter]
    public IActionResult Edit(int id)
    {
        Author? author = _context.Authors.Find(id);

        if (author is null)
            return NotFound();

        AuthorFormViewModel viewModel = _mapper.Map<AuthorFormViewModel>(author);

        return PartialView("_Form", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(AuthorFormViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        Author? author = _context.Authors.Find(model.Id);

        if (author is null)
            return NotFound();

        author = _mapper.Map(model, author);
        author.LastUpdatedOn = DateTime.Now;
        _context.SaveChanges();

        AuthorViewModel viewModel = _mapper.Map<AuthorViewModel>(author);

        return PartialView("_AuthorRaw", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ToggleState(int id)
    {
        Author? author = _context.Authors.Find(id);

        if (author is null)
            return BadRequest();

        author.IsDeleted = !author.IsDeleted;
        author.LastUpdatedOn = DateTime.Now;
        _context.SaveChanges();

        return Ok(author.LastUpdatedOn.ToString());
    }

    public IActionResult IsAllowedRecord(AuthorFormViewModel model)
    {
        Author? author = _context.Authors.SingleOrDefault(a => a.Name == model.Name);


        bool isAllowed = author is null;

        return Json(isAllowed);
    }

}
