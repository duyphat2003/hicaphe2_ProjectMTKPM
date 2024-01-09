using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Decorator_Pattern
{
    /// <summary>
    /// Decorator Pattern
    /// </summary>
    public class ConcreteKhachHang : AbstractKhachHang
    {
        public ConcreteKhachHang() 
        {
            HoTenKH = "";
            Email = "";
            DiachiKH = "";
            SDT = "";
            Matkhau = "";
            Ngaysinh = new DateTime();
        }
        public override TAIKHOANKHACHHANG MakeKhachHang()
        {
            TAIKHOANKHACHHANG kh = new TAIKHOANKHACHHANG();
            kh.HoTenKH = HoTenKH;
            kh.Email = Email;
            kh.DiachiKH= DiachiKH;
            kh.SDT = SDT;
            kh.Matkhau = Matkhau;
            kh.Ngaysinh = Ngaysinh;
            return kh;
        }
    }
}