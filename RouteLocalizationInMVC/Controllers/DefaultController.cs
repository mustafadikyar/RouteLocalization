using System.Web.Mvc;

namespace RouteLocalizationInMVC.Controllers
{
    public class DefaultController : Controller
    {
        [Route("anasayfa")]
        public ActionResult Index()
        {
            return View();
        }
        
        [Route("hakkinda")]
        public ActionResult About()
        {
            return View();
        }

        [Route("iletisim")]
        public ActionResult Contact()
        {
            return View();
        }

    }
}