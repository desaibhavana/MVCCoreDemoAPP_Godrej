using ADOLibrary;
using Microsoft.AspNetCore.Mvc;

namespace MVCCoreDemoAPP_Godrej.Controllers
{
    public class DbController : Controller
    {
        EmployeeDataStore _db;

        public DbController(EmployeeDataStore db)  //Constructor DI
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<ADOLibrary.Employee> employees = _db.GetEmployees();
            return View(employees);
        }
    }
}
