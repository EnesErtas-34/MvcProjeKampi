using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValues = hm.TGetList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName,
                                                      Value=x.CategoryID.ToString()
                                                  }
                                                ).ToList();
            List<SelectListItem> valueWriter = (from x in wm.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName+" "+x.WriterSurName,
                                                      Value = x.WriterID.ToString()
                                                  }
                                                ).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.TInsert(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                ).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = hm.TGetByID(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.TUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.TGetByID(id);
            headingValue.HeadingStatus = false;
            hm.TDelete(headingValue);
            return RedirectToAction("Index");
        }
    }
}