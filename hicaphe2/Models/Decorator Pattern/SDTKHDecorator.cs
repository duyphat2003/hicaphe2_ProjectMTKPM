using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Decorator_Pattern
{
    /// <summary>
    /// Decorator Pattern
    /// </summary>
    public class SDTKHDecorator : AbstractDecorator
    {
        TAIKHOANKHACHHANG kh1;
        public SDTKHDecorator(AbstractKhachHang kh, string sdt, TAIKHOANKHACHHANG kh1) : base(kh)
        {
            SDT = sdt;
            this.kh1 = kh1;
        }

        public override TAIKHOANKHACHHANG MakeKhachHang()
        {
            base.MakeKhachHang();
            TAIKHOANKHACHHANG kh = kh1;
            kh.SDT = SDT;
            return kh;
        }
    }
}