using QLTV_TTN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace QLTV_TTN.Areas.Admin.Controllers
{
    public class ThongKe_BaoCaoController : Controller
    {
        Mycontent content = new Mycontent();
        // GET: Admin/ThongKe_BaoCao
        public ActionResult BaoCaoSach(int? page)
        {
            var model = content.BaoCaoSaches.Where(x => x.TenTuaSach != null).OrderByDescending(x => x.MaCuonSach).ToPagedList(page ?? 1, 10);
            return View(model);
            
        }
        public ActionResult ThongKeTheoKy()
        {
            
            return View();
        }
        public ActionResult ThongKeDocGia(int? page)
        {
            var model = content.TKDocGias.Where(x => x.TenDG != null).OrderBy(x=>x.MaDG).ToPagedList(page ??1, 10);
            return View(model);
        }
    }
}