using hicaphe2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;

namespace hicaphe2.Controllers
{
    public class HiCaPheController : Controller
    {
        public static SanPhamFactory sanPhamFactory = new SanPhamFactory();
        // Use DbContext to manage database
        private List<SANPHAM> LaySanPhamMoi(int soluong)
        {
            return HiCaPheDatabase.Instance.database.SANPHAM.OrderByDescending(sanpham => sanpham.MaSP).Take(soluong).ToList();
        }
        // GET: BookStore
        public ActionResult Index(int? page)
        {
            new HiCaPheDatabase();
            int pageSize = 5;
            int pageNum = (page ?? 1);
            var dsSanPhamMoi = LaySanPhamMoi(5);
            return View(dsSanPhamMoi.ToPagedList(pageNum, pageSize));
        }

        public ActionResult SanPham(int? page, string timkiemchuoi, double minPrice = double.MinValue, double maxPrice = double.MaxValue)
        {
            SanPhamX sanPhamX = sanPhamFactory.GetHiCaPheSP();

            return View(sanPhamX.SetSanPham(page, timkiemchuoi, minPrice, maxPrice));
        }

        public ActionResult SPTheoLoai(int? page, int id)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);
            var dsSanPhamTheoLoai = HiCaPheDatabase.Instance.database.SANPHAM.Where(sanpham => sanpham.MaLoaiSP == id).ToList();
            return View("SPTheoLoai", dsSanPhamTheoLoai.ToPagedList(pageNum, pageSize));
        }

        public ActionResult LayLoaiSP() 
        {
            var dsLoai = HiCaPheDatabase.Instance.database.LOAISP.ToList();
            return PartialView(dsLoai);
        }

        public ActionResult Details(string id) 
        { 
            var sanpham= HiCaPheDatabase.Instance.database.SANPHAM.FirstOrDefault(s => s.MaSP == id);
            return View(sanpham);
        }
    }
}