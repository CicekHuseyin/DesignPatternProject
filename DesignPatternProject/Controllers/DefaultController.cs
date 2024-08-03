using DesignPatternProject.ChainOfResponsibility;
using DesignPatternProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternProject.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee cashier = new Cashier();
            Employee asistantManager = new AsisstantManager();
            Employee manager = new Manager();
            Employee regionManager=new RegionManager();

            cashier.SetNextApprover(asistantManager);
            asistantManager.SetNextApprover(manager);
            manager.SetNextApprover(regionManager);

            cashier.ProcessRequest(model);

            return View();
        }
    }
}
