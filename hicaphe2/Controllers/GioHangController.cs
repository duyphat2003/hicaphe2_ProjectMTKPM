﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using hicaphe2.Models;
using hicaphe2.Models.Builder_Pattern;

namespace hicaphe2.Controllers
{
    public class GioHangController : Controller
    {

        public List<MatHangMua> LayGioHang()
        {
            List<MatHangMua> gioHang = Session["GioHang"] as List<MatHangMua>;
            if (gioHang == null)
            {
                gioHang = new List<MatHangMua>();
                Session["GioHang"] = gioHang;
            }
            return gioHang;
        }

        public ActionResult ThemSanPhamVaoGio(string MaSP)
        {
            //GioHang director = new GioHang();

            //IBuilderMatHang matHang = new MatHang(MaSP);
            //// Making Car
            //director.Construct(matHang);
            //SanPham sp1 = matHang.GetSanPham();
            //sp1.GetSanPham();


            List<MatHangMua> gioHang = LayGioHang();
            MatHangMua sanPham = gioHang.FirstOrDefault(s => s.MaSP == MaSP);
            if (sanPham == null)
            {
                sanPham = new MatHangMua(MaSP);
                gioHang.Add(sanPham);
            }
            else
            {
                sanPham.SoLuong++;
            }
            return RedirectToAction("Details", "HiCaPhe", new { id = MaSP });

        }

        private int TinhTongSL()
        {
            int tongSL = 0;
            List<MatHangMua> gioHang = LayGioHang();
            if (gioHang != null)
                tongSL = gioHang.Sum(sp => sp.SoLuong);
            return tongSL;
        }

        private double TinhTongTien()
        {
            double TongTien = 0;
            List<MatHangMua> gioHang = LayGioHang();
            if (gioHang != null)
                TongTien = gioHang.Sum(sp => sp.ThanhTien());
            return TongTien;
        }

        public ActionResult HienThiGioHang()
        {
            List<MatHangMua> gioHang = LayGioHang();
            if (gioHang == null || gioHang.Count == 0)
                return RedirectToAction("Index", "HiCaPhe");
            ViewBag.TongSL = TinhTongSL();
            ViewBag.TongTien = TinhTongTien();
            return View(gioHang);
        }
        public ActionResult GioHangPartial()
        {
           
            ViewBag.TongSL = TinhTongSL();
            ViewBag.TongTien = TinhTongTien();
            return PartialView();
        }

        public ActionResult XoaMatHang(string MaSP)
        {
            List<MatHangMua> gioHang = LayGioHang();
            var sanpham = gioHang.FirstOrDefault(s => s.MaSP == MaSP);
            if (sanpham != null)
            {
                gioHang.RemoveAll(s => s.MaSP == MaSP);
                return RedirectToAction("HienThiGioHang");
            }
            if (gioHang.Count == 0)
                return RedirectToAction("Index", "HiCaPhe");
            return RedirectToAction("HienThiGioHang");
        }

        public ActionResult CapNhatMatHang(string MaSP, int SoLuong)
        {
            List<MatHangMua> gioHang = LayGioHang();
            var sanpham = gioHang.FirstOrDefault(s => s.MaSP == MaSP);
            if (gioHang != null)
                sanpham.SoLuong = SoLuong;
            return RedirectToAction("HienThiGioHang");
        }

        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null)
                return RedirectToAction("DangNhap", "NguoiDung");
            List<MatHangMua> gioHang = LayGioHang();
            if (gioHang == null || gioHang.Count == 0)
                return RedirectToAction("Index", "HiCaPhe");
            ViewBag.TongSL = TinhTongSL();
            ViewBag.TongTien = TinhTongTien();
            return View(gioHang);
        }


        
        public ActionResult DongYDatHang()
        {
            TAIKHOANKHACHHANG khach = Session["TaiKhoan"] as TAIKHOANKHACHHANG;
            List<MatHangMua> gioHang = LayGioHang();



            DONDATHANG DonHang = new DONDATHANG();
            DonHang.MaTK = khach.MaTK;
            DonHang.NgayDH = DateTime.Now;
            DonHang.Trigia = (decimal)TinhTongTien();
            DonHang.Dagiao = false;
            DonHang.Tennguoinhan = khach.HoTenKH;
            DonHang.Diachinhan = khach.DiachiKH;
            DonHang.Dienthoainhan = khach.SDT;
            DonHang.HTThanhtoan = false;
            DonHang.HTGiaohang = false;



            HiCaPheDatabase.Instance.database.DONDATHANG.Add(DonHang);
            HiCaPheDatabase.Instance.database.SaveChanges();



            foreach (var sanpham in gioHang)
            {
                CTDATHANG chitiet = new CTDATHANG();
                chitiet.SODH = DonHang.SODH;
                chitiet.MaSP = sanpham.MaSP;
                chitiet.Soluong = sanpham.SoLuong;
                chitiet.Dongia = (decimal)sanpham.Dongia;
                HiCaPheDatabase.Instance.database.CTDATHANG.Add(chitiet);
            }
            HiCaPheDatabase.Instance.database.SaveChanges();

            //Xóa giỏ hàng
            Session["GioHang"] = null;
            return RedirectToAction("HoanThanhDonDatHang");
        }

        public ActionResult HoanThanhDonDatHang()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }       
    }
}