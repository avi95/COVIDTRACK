using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COVID19TRACK.Models;

namespace COVID19TRACK.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            getCOVIDdata obj = new getCOVIDdata();
            int total;
            float death;
            float discharged;
            float closed;
            float deathper;
            float recper;
            DateTime lastRefreshed;
            ViewBag.data = obj.getData(out total, out death, out discharged, out lastRefreshed);
            ViewBag.testingData = obj.getTestingData();
            if(ViewBag.testingData == null)
            {
                ViewBag.testingData = "-";
            }
            ViewBag.total = total;
            ViewBag.death = death;
            ViewBag.discharged = discharged;
            ViewBag.active = total - (death + discharged);
            closed = (death + discharged);
            ViewBag.closed = closed;
            deathper = (death / closed) * 100;
            recper = (discharged / closed) * 100;
            ViewBag.deathper = deathper.ToString("#.##");
            ViewBag.recper = recper.ToString("#.##");
            ViewBag.lastRefreshed = lastRefreshed.ToString("dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            return View();
        }

        public EmptyResult notify() 
        {
           
            return  new EmptyResult();
        }
    }
}