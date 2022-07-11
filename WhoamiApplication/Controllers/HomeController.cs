using Microsoft.AspNetCore.Mvc;

namespace WhoamiApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

    }
}
