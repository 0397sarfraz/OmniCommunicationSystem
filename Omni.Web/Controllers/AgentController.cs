using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Omni.Domain.Entities;
using Omni.Persistence.Context;

namespace Omni.Web.Controllers
{
    public class AgentsController : Controller
    {
        private readonly AppDbContext _db;

        public AgentsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Agents.Include(x=>x.Company).ToList());
        }

        public async Task<IActionResult> Create() {

            ViewBag.CompanyList = await _db.Companies.Select(x=> new SelectListItem
            {
                Value=x.Id.ToString(),
                Text=x.Name
            }).ToListAsync();
            return View();
        } 

        [HttpPost]
        public IActionResult Create(Agent model)
        {
            _db.Agents.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var a = _db.Agents.Find(id);
            _db.Agents.Remove(a);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
