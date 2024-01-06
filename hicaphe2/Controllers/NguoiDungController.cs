﻿using hicaphe2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace hicaphe2.Controllers
{
    public class NguoiDungController : Controller, ILogin<TAIKHOANKHACHHANG>
    {
        // GET: NguoiDung
        [HttpGet]
        public ActionResult DangKy()
        {
            String taiKhoan = Session["TaiKhoan"] as String;
            if (taiKhoan != null)
                return Redirect("/HiCaPhe/Index");
            return View();
        }
        
        [HttpPost]
        public ActionResult DangKy(TAIKHOANKHACHHANG kh)
        {
            if (ModelState.IsValid) 
            {
                if (string.IsNullOrEmpty(kh.HoTenKH))
                    ModelState.AddModelError(string.Empty, "Họ tên không được để trống");
                if (string.IsNullOrEmpty(kh.Email))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(kh.Matkhau))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(kh.SDT))
                    ModelState.AddModelError(string.Empty, "Số điện thoại không được để trống");

                var khachhang = HiCaPheDatabase.Instance.database.TAIKHOANKHACHHANG.FirstOrDefault(k => k.Email == kh.Email);
                if (khachhang != null)
                    ModelState.AddModelError(string.Empty, "Đã có người đăng ký tên này");
                if (ModelState.IsValid)
                {
                    HiCaPheDatabase.Instance.database.TAIKHOANKHACHHANG.Add(kh);
                    HiCaPheDatabase.Instance.database.SaveChanges();
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("DangNhap");
        }
        [HttpGet]
        public ActionResult DangNhap()
        {           
            String taiKhoan = Session["TaiKhoan"] as String;
            if (taiKhoan != null)
                return Redirect("/HiCaPhe/Index");
            return View();

        }
        [HttpPost]
        public ActionResult DangNhap(TAIKHOANKHACHHANG kh)
        {
            
            if (ModelState.IsValid) 
            {
                if (string.IsNullOrEmpty(kh.Email))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(kh.Matkhau))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    //Tìm khách hàng có tên đăng nhập và password hợp lệ trong CSDL
                    var khach = HiCaPheDatabase.Instance.database.TAIKHOANKHACHHANG.FirstOrDefault(k => k.Email == kh.Email && k.Matkhau == kh.Matkhau);
                    if (khach != null)
                    {
                        // lưu vào session
                        Session["TaiKhoan"] = khach;                    
                        return Redirect("/");
                    }
                    else
                    {                    
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                        return View();
                    }
                }
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("/DangNhap");
        }
        public ActionResult QuanLyDonHang()
        {
            // Lấy mã tài khoản của người đăng nhập
            int maTaiKhoan = ((TAIKHOANKHACHHANG)Session["TaiKhoan"]).MaTK;

            // Lấy danh sách đơn hàng của người đăng nhập từ cơ sở dữ liệu
            var danhSachDonHang = HiCaPheDatabase.Instance.database.DONDATHANG.Where(dh => dh.MaTK == maTaiKhoan).ToList();

            return View(danhSachDonHang);
        }
        public ActionResult HuyDonHang(int soDonHang)
        {
            // Lấy thông tin đơn hàng từ cơ sở dữ liệu
            var donHang = HiCaPheDatabase.Instance.database.DONDATHANG.SingleOrDefault(dh => dh.SODH == soDonHang);

            if (donHang == null)
            {
                return HttpNotFound();
            }

            // Kiểm tra xem đơn hàng đã được giao chưa
            if ((bool)donHang.Dagiao)
            {
                // Nếu đã giao, bạn có thể thực hiện các xử lý hoặc trả về trang thông báo tùy thuộc vào yêu cầu của bạn.
                // Ở đây chúng ta trả về trang thông báo để không thực hiện thêm hành động.
                ViewBag.Message = "Đơn hàng đã được giao và không thể hủy.";
                return View("ThongBao"); // Tạo view ThongBao.cshtml để hiển thị thông báo.
            }

            // Thực hiện xử lý hủy đơn hàng (cập nhật trạng thái, gửi thông báo, v.v.)
            donHang.Dagiao = false; // Đặt lại trạng thái là chưa giao
            donHang.Ngaygiaohang = null; // Đặt lại ngày giao hàng
            donHang.Dahuy = true; // Đặt trạng thái đã hủy

            // Lưu thay đổi vào cơ sở dữ liệu
            HiCaPheDatabase.Instance.database.SaveChanges();

            // Thêm thông điệp vào TempData
            TempData["HuyDonHangSuccess"] = "Đơn hàng đã được hủy thành công.";

            // Chuyển hướng về trang quản lý đơn hàng hoặc trang chi tiết đơn hàng đã hủy
            return RedirectToAction("QuanLyDonHang");
        }
    }
}
    