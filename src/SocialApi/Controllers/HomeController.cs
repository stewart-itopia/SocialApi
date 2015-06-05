using System.Web.Mvc;

namespace SocialApi.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}