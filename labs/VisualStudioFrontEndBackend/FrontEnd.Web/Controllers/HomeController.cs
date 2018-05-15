using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string backendUrl)
        {
            string url = backendUrl;
            var getRequest = (HttpWebRequest)WebRequest.Create(url);
            getRequest.Method = "GET";

            var getResponse = (HttpWebResponse)getRequest.GetResponse();
            var newStream = getResponse.GetResponseStream();
            StreamReader sr = new StreamReader(newStream);
            var result = sr.ReadToEnd();

            var values = JsonConvert.DeserializeObject<IEnumerable<string>>(result);
            
            

            return View(values);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}