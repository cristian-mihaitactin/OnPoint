using Abp.AspNetCore.Mvc.Authorization;
using eMMA.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Web.Controllers
{
    [AbpMvcAuthorize]
    public class SubjectsController : eMMAControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}