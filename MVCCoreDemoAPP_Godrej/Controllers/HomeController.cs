using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreDemoAPP_Godrej.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MVCCoreDemoAPP_Godrej.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
            
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


      //  [Route("home/sum/{num1:int:range(1,50)}/{num2:int}")]
     //   [Route("home/sum/{num1:int:range(1,50)}/{num2:int}")]
        public IActionResult AddNumbers(int num1, int num2)
        {
            int result = num1 + num2;
            ViewBag.result = result;
            return View();
        }

        public IActionResult GetEmpData()
        {
            return View(new Employee());
        }

        public IActionResult ReadEmpData(Employee employee)
        {
            
            return View(employee);
        }


        public IActionResult AddSessionValues()
        {
            //Session["key"]=value;
           // HttpContext.Session.SetString("key", "value");
             HttpContext.Session.SetString("message", "Session test");
            HttpContext.Session.SetInt32("count", 5);

            Employee employee = new Employee() { FirstName = "Bhavana", LastName = "desai" };
            string empserializedata = JsonSerializer.Serialize(employee);
            HttpContext.Session.SetString("empobj", empserializedata);

            return RedirectToAction("GetSessionValues");
        }

        public IActionResult GetSessionValues()
        {
            ViewBag.message = HttpContext.Session.GetString("message");
            ViewBag.count = HttpContext.Session.GetInt32("count");

            string emp = HttpContext.Session.GetString("empobj");
            Employee empobj = JsonSerializer.Deserialize<Employee>(emp);
            ViewBag.emp = empobj;

            return View();
        }

        public IActionResult ReadAppsettingjson()
        {
            ViewBag.data = _configuration["CustomKey"];
            return View();

        }



    }

}

