using MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MVC.Controllers
{
    public class SinhViensController : Controller
    {
        private QLSVEntities qlsv = new QLSVEntities();

        // GET: SinhViens
        public ActionResult Index()
        {
            ViewBag.name = "DKC";
            List<SINHVIEN> data = qlsv.SINHVIENs.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(string ID)
        {
            SINHVIEN sv = qlsv.SINHVIENs.FirstOrDefault(x => x.MASV == ID);
            return View(sv);
        }

        [HttpPost]
        public ActionResult Edit(SINHVIEN sv, string phai)
        {
            sv.PHAI = Convert.ToBoolean(int.Parse(phai));
            qlsv.Entry(sv).State = EntityState.Modified;
            qlsv.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(SINHVIEN sv,string phai)
        {
            sv.PHAI = Convert.ToBoolean(int.Parse(phai));
           //qlsv.Entry(sv).State = EntityState.Added;
            qlsv.SINHVIENs.Add(sv);
            qlsv.SaveChanges();
           TempData["ThongBao"] = "Thêm thành công";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(string ID)
        {
            SINHVIEN sv = qlsv.SINHVIENs.FirstOrDefault(x => x.MASV == ID);
            return View(sv);
        }
        [HttpPost]
        public ActionResult Delete(SINHVIEN sv)
        {
            qlsv.Entry(sv).State = EntityState.Deleted;
            qlsv.SaveChanges();
            TempData["ThongBao"] = "Xóa thành công";
            return RedirectToAction("Index");
        }
    }
}