using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController: Controller
    {
        public HomeController(IClock clock)
        {

        }
    }
}
