using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COVID19TRACK.Models;

namespace COVID19TRACK.Controllers
{
    public class notifyController : Controller
    {
        // GET: notify
        public ActionResult Index()
        {
            getNOTIFY obj = new getNOTIFY();
            DateTime lastRefreshed;
            ViewBag.data = obj.getData(out lastRefreshed)
                .OrderByDescending(x => DateTime.ParseExact(x.date, "dd.MM.yyyy", CultureInfo.InvariantCulture))
                .ToList();
            ViewBag.lastRefreshed = lastRefreshed.ToString("dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            return View();
        }
    }
}