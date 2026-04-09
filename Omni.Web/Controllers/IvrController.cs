using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Omni.Domain.Entities;
using Omni.Persistence.Context;

namespace Omni.Web.Controllers
{
    public class IvrController : Controller
    {
        private readonly AppDbContext _db;

        public IvrController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.IvrMenus.Include(x=>x.Company).ToList());
        }

        public IActionResult Create()
        {

            ViewBag.CompanyList = _db.Companies.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text=x.Name
            }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(IvrMenu model)
        {
            _db.IvrMenus.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
