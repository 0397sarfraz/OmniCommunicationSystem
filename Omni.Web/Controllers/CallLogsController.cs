using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omni.Persistence.Context;

namespace Omni.Web.Controllers
{
    public class CallLogsController : Controller
    {
        private readonly AppDbContext _db;

        public CallLogsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.CallLogs
                .Include(x=>x.Company)
                .OrderByDescending(x => x.CreatedAt).ToList());
        }
    }
}
