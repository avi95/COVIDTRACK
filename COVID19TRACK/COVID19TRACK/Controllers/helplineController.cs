using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COVID19TRACK.Models;

namespace COVID19TRACK.Controllers
{
    public class helplineController : Controller
    {
        // GET: helpline
        public ActionResult Index()
        {
            getHelpline obj = new getHelpline();
            string number;
            string numbertollfree;
            string email;
            string facebook;
            ViewBag.data = obj.getData(out number,out numbertollfree,out email,out facebook);
            ViewBag.number = number;
            ViewBag.numbertollfree = numbertollfree;
            ViewBag.email = email;
            ViewBag.facebook = facebook;
            return View();
        }
    }
}