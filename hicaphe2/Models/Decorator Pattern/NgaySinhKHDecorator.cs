using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Decorator_Pattern
{
    /// <summary>
    /// Decorator Pattern
    /// </summary>
    public class NgaySinhKHDecorator : AbstractDecorator
    {
        TAIKHOANKHACHHANG kh1;
        public NgaySinhKHDecorator(AbstractKhachHang kh, DateTime? ngaySinh, TAIKHOANKHACHHANG kh1) : base(kh)
        {
            Ngaysinh = ngaySinh;
            this.kh1 = kh1;
        }

        public override TAIKHOANKHACHHANG MakeKhachHang()
        {
            base.MakeKhachHang();
            TAIKHOANKHACHHANG kh = kh1;
            kh.Ngaysinh = Ngaysinh;
            return base.MakeKhachHang();
        }
    }
}