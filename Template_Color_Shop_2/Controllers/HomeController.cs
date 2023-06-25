using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template_Color_Shop_2.Models;

namespace Template_Color_Shop_2.Controllers
{
    public class HomeController : Controller
    {
        QLBCCEntity db = new QLBCCEntity();
        public ActionResult Index()
        {
            var sp = db.SanPhams.ToList();
            ViewBag.PhanLoaiPhu = db.PhanLoaiPhus.ToList();
            return View(sp);
        }
        public JsonResult Load(int? MaPhanLoai)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var sp = db.SanPhams.ToList();
            if (MaPhanLoai.HasValue)
            {
                sp = sp.Where(s => s.MaPhanLoaiPhu == MaPhanLoai).ToList();
            }
            return Json(sp, JsonRequestBehavior.AllowGet);
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