using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using eMMA.Controllers;

namespace eMMA.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : eMMAControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
