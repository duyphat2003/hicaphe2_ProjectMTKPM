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
    public class Admin : Controller, ILogin<ADMIN>
    {
        public bool DangNhap(string taiKhoan)
        {
            return taiKhoan != null;
        }
        public bool DangNhap(ADMIN x, ref object taikhoan)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(x.UserAdmin))
                    ModelState.AddModelError(string.Empty, "User name không được để trống");
                if (string.IsNullOrEmpty(x.PassAdmin))
                    ModelState.AddModelError(string.Empty, "Password không được để trống");
                //Kiểm tra có admin này hay chưa
                var adminDB = HiCaPheDatabase.Instance.database.ADMIN.FirstOrDefault(ad => ad.UserAdmin == x.UserAdmin && ad.PassAdmin == x.PassAdmin);
                if (adminDB == null)
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng");
                else
                {
                    taikhoan = adminDB;
                    ViewBag.ThongBao = "Đăng nhập admin thành công";
                    return true;
                }
            }
            return false;
        }
    }
}