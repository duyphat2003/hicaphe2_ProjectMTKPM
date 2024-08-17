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
    public class Admin : ILogin<ADMIN>
    {
        public bool DangNhap(string taiKhoan)
        {
            return taiKhoan != null;
        }
        public bool DangNhap(ADMIN x, ref object taikhoan)
        {
            //Tìm khách hàng có tên đăng nhập và password hợp lệ trong CSDL
            var khach = HiCaPheDatabase.Instance.database.ADMIN.FirstOrDefault(k => k.UserAdmin == x.UserAdmin && k.PassAdmin == x.PassAdmin);
            if (khach != null)
            {
                taikhoan = khach;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}