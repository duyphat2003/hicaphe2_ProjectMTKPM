using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Decorator_Pattern
{
    /// <summary>
    /// Decorator Pattern
    /// </summary>
    public class HoTenKHDecorator : AbstractDecorator
    {
        TAIKHOANKHACHHANG kh1;
        public HoTenKHDecorator(AbstractKhachHang kh, string hoTen, TAIKHOANKHACHHANG kh1) : base(kh)
        {
            this.kh1 = kh1;
            HoTenKH = hoTen;
        }

        public override TAIKHOANKHACHHANG MakeKhachHang()
        {
            base.MakeKhachHang();
            TAIKHOANKHACHHANG kh = kh1;
            kh.HoTenKH = HoTenKH;
            return kh;
        }
    }
}