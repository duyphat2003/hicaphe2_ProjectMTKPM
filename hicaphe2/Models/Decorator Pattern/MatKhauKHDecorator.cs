using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Decorator_Pattern
{
    /// <summary>
    /// Decorator Pattern
    /// </summary>
    public class MatKhauKHDecorator : AbstractDecorator
    {
        TAIKHOANKHACHHANG kh1;
        public MatKhauKHDecorator(AbstractKhachHang kh, string matkhau, TAIKHOANKHACHHANG kh1) : base(kh)
        {
            Matkhau = matkhau;
            this.kh1 = kh1;
        }

        public override TAIKHOANKHACHHANG MakeKhachHang()
        {
            base.MakeKhachHang();
            TAIKHOANKHACHHANG kh = kh1;
            kh.Matkhau = Matkhau;
            return base.MakeKhachHang();
        }
    }
}