using Microsoft.AspNetCore.Mvc;
using MVCCoreDemoAPP_Godrej.Models;

namespace MVCCoreDemoAPP_Godrej.Controllers
{
    public class DeptController : Controller
    {
        TrainingDbContext _db;

        public DeptController(TrainingDbContext db)
        {
            _db = db;       
        }


        public IActionResult Index()
        {
            var data = _db.Depts.ToList();
            return View(data);
        }
    }
}
