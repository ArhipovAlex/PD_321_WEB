using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public string Index(int i)
        //{
        //    return "This is My Default action";
        //}
        public string Welcome(string name, int numTimes=1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is:{numTimes}");
            //return "This is the Welcome action method";
        }
    }
}
