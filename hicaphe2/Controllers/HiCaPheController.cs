using hicaphe2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;
using hicaphe2.Models.Proxy_Pattern;
using hicaphe2.Models.Adapter;
using hicaphe2.Models.Adapter_Pattern;

namespace hicaphe2.Controllers
{
    public class HiCaPheController : Controller
    {
        public static SanPhamFactory sanPhamFactory = new SanPhamFactory();
        // Use DbContext to manage database
        private List<SANPHAM> LaySanPhamMoi(int soluong)
        {
            #region Singleton
            return HiCaPheDatabase.Instance.database.SANPHAM.OrderByDescending(sanpham => sanpham.MaSP).Take(soluong).ToList();
            #endregion
        }
        // GET: BookStore
        public ActionResult Index(int? page)
        {
            #region Singleton
            new HiCaPheDatabase();
            #endregion

            int pageSize = 5;
            int pageNum = (page ?? 1);
            var dsSanPhamMoi = LaySanPhamMoi(5);

            #region
            List<List<string>> spCaPhePackage = new List<List<string>>();
            foreach (SANPHAM sp in dsSanPhamMoi)
            {
                ISanPhamDataProvider caphe = new AP_CaPhe(sp.TenSP, sp.Kichthuoc, sp.Donvitinh, sp.Dongia, sp.Hinhminhhoa);
                ISanPhamDataProvider spApdater = new HiCaPheDatabaseAdapter(caphe);
                spCaPhePackage.Add(spApdater.LaySanPhamMoi(5));
            }
            ViewBag.ListSPPackage = spCaPhePackage;
            #endregion
            return View(dsSanPhamMoi.ToPagedList(pageNum, pageSize));
        }


        #region Proxy Pattern
        SanPhamManagement sanPhamManagement;
        #endregion

        public ActionResult SanPham(int? page, string timkiemchuoi, double minPrice = double.MinValue, double maxPrice = double.MaxValue)
        {
            #region Prototype Pattern
            SanPhamX sanPhamX = sanPhamFactory.GetHiCaPheSP();
            #endregion

            #region Proxy Pattern
            sanPhamManagement = new Proxy();
            List<SANPHAM> listSP = sanPhamManagement.FilterSanPham_Name(sanPhamX.SetSanPham(page, timkiemchuoi, minPrice, maxPrice, out int pageSize, out int pageNum), timkiemchuoi);


            return View(listSP.ToPagedList(pageNum, pageSize));
            #endregion

            #region Prototype Pattern
            //   return View(sanPhamX.SetSanPham(page, timkiemchuoi, minPrice, maxPrice));
            #endregion
        }

        public ActionResult SPTheoLoai(int? page, int id)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);
            #region Singleton
            var dsSanPhamTheoLoai = HiCaPheDatabase.Instance.database.SANPHAM.Where(sanpham => sanpham.MaLoaiSP == id).ToList();
            #endregion
            return View("SPTheoLoai", dsSanPhamTheoLoai.ToPagedList(pageNum, pageSize));
        }

        public ActionResult LayLoaiSP() 
        {
            #region Singleton
            var dsLoai = HiCaPheDatabase.Instance.database.LOAISP.ToList();
            #endregion
            return PartialView(dsLoai);
        }

        public ActionResult Details(string id) 
        {
            #region Singleton
            var sanpham = HiCaPheDatabase.Instance.database.SANPHAM.FirstOrDefault(s => s.MaSP == id);
            #endregion
            return View(sanpham);
        }
    }
}