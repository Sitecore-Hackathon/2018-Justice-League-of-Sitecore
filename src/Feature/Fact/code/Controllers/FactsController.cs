using System.Web.Mvc;

namespace AlexConnect.Feature.Fact.Controllers
{
    //api/sitecore/{controller}/{action}/{id}
    public class FactsController : Controller
    {   
        [HttpGet]
        public dynamic AllFacts()
        {  

            var jsonResult = new
            {
                Success = true
            };

            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
    }
}