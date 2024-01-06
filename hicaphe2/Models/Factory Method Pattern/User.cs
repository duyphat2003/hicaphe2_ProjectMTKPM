using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/// <summary>
/// Factory Method Pattern
/// </summary>
namespace hicaphe2.Models.Factory_Method_Pattern
{
    public class User : Controller, ILogin<TAIKHOANKHACHHANG>
    {
        [HttpGet]
        public bool DangNhap(string taiKhoan)
        {
            //if (taiKhoan != null)
            return taiKhoan != null;
        }
        [HttpPost]
        public bool DangNhap(TAIKHOANKHACHHANG x, ref object taikhoan)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(x.Email))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(x.Matkhau))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    //Tìm khách hàng có tên đăng nhập và password hợp lệ trong CSDL
                    var khach = HiCaPheDatabase.Instance.database.TAIKHOANKHACHHANG.FirstOrDefault(k => k.Email == x.Email && k.Matkhau == x.Matkhau);
                    if (khach != null)
                    {
                        // lưu vào session
                        taikhoan = khach;
                        return true;
                    }
                    else
                    {
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                        return false;
                    }
                }
            }
            return false;
        }
    }
}