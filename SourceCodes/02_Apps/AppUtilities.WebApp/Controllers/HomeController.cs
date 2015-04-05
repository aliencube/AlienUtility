using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aliencube.AppUtilities.WebApp.Models;

namespace Aliencube.AppUtilities.WebApp.Controllers
{
    public partial class HomeController : Controller
    {
        // GET: Home
        public virtual async Task<ActionResult> Index()
        {
            var vm = new HomeIndexViewModel();
            return View(vm);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Index(HomeIndexViewModel vm)
        {
            using (var appUtil = new AppUtility())
            {
                try
                {
                    var fullpath = appUtil.MapPath(vm.Directory);
                    vm.FullPath = fullpath;
                }
                catch (Exception ex)
                {
                    vm.FullPath = String.Format("FAIL!!: {0}", ex.Message);
                }
            }
            return View(vm);
        }
    }
}