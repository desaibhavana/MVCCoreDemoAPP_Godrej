using Microsoft.AspNetCore.Mvc;
using MVCCoreDemoAPP_Godrej.Models;

namespace MVCCoreDemoAPP_Godrej.Controllers
{
    public class ServiceDemoController : Controller
    {
        ITransientService _transientService1, _transientService2;
        IScopedService _scopedService1, _scopedService2;
        ISingletonService _singletonService1, _singletonService2;

         
        public ServiceDemoController(ITransientService t1,ITransientService t2, IScopedService sc1, IScopedService sc2, ISingletonService s1, ISingletonService s2)
        {
            //transient - per call new object 
            //both are two different instance
            _transientService1 = t1;
            _transientService2 = t2;

            //for same request same object
            //for new request new object
            _scopedService1 = sc1;
            _scopedService2 = sc2;


            //singlton same object for singlton
            _singletonService1 = s1;
            _singletonService2 = s2;

        }
        public IActionResult Index()
        {

            ViewBag.transient1 = _transientService1.GetOperationID().ToString();
            ViewBag.transient2 = _transientService2.GetOperationID().ToString();

            ViewBag.scoped1 = _scopedService1.GetOperationID().ToString();
            ViewBag.scoped2 = _scopedService2.GetOperationID().ToString();

            ViewBag.singleton1 = _singletonService1.GetOperationID().ToString();
            ViewBag.singleton2 = _singletonService2.GetOperationID().ToString();

            return View();
        }
    }
}
