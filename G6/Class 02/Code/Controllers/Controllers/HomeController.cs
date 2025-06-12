using Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Controllers.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello class, we are returning result via HTTP";
        }
    }
}
