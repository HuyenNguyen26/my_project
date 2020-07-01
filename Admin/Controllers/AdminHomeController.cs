using QLTV_TTN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace QLTV_TTN.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        Mycontent db = new Mycontent();
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(ACCOUNT acc)
        {
            db.ACCOUNTs.Add(acc);
            db.SaveChanges();

            return RedirectToAction("List");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin()
        {
            string us = Request.Form["us"];
            string mk = Request.Form["mk"];
            var result = db.ACCOUNTs.Where(p => p.Username == us && p.Password == mk);
            if (result.Count() > 0)
            {
                Session["username"] = us;
                return RedirectToAction("List");
            }
            else
            {
                TempData["msg"] = "Đăng nhập không thành công !!";
                return RedirectToAction("Login");
            }
        }

        public ActionResult List(int page = 1, int pageSize = 10)
        {
            var lst = db.ACCOUNTs.SqlQuery("select" + "* from ACCOUNT").ToList<ACCOUNT>();

            var mm = lst.ToPagedList(page, pageSize);
            return View(mm);

        }
        public ActionResult Edit(int TK)
        {
            //if (Session["username"] == null) return RedirectToAction("/List");
            //else
            //{

            var list = db.ACCOUNTs.Find(TK);
            return View(list);
            //}
        }

        [HttpPost]
        public ActionResult Edit(ACCOUNT acc)
        {
            ACCOUNT acco = db.ACCOUNTs.Find(acc.TK);
            if (acco != null)
            {
                acco.Username = acc.Username;
                acco.Password = acc.Password;
                acco.HoTen = acc.HoTen;
                acco.TK = acc.TK;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int TK)
        {
            //if (Session["username"] == null) return RedirectToAction("/DangNhap");
            //else
            //{
                var list = db.ACCOUNTs.Find(TK);
                return View(list);
            //}
        }

        [HttpPost]
        public ActionResult Delete(ACCOUNT acc)
        {
            ACCOUNT acco = db.ACCOUNTs.Find(acc.TK);
            if (acco != null)
            {
                db.ACCOUNTs.Remove(acc);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

    }
}