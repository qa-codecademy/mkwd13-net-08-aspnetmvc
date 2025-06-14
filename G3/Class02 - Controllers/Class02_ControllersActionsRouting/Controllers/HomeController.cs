using Microsoft.AspNetCore.Mvc;

namespace Class02_ControllersActionsRouting.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
			return "Hello class, we are returning result via HTTP";
		}
	}
}
