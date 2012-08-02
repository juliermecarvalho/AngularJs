using System.Web.Mvc;
using Dtos;

namespace Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        
        public ActionResult Index()
        {
            return View( new DtoPessoa());
        }

    }
}
