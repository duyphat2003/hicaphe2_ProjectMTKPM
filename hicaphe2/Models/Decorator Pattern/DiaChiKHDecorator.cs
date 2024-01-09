using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Decorator_Pattern
{
    /// <summary>
    /// Decorator Pattern
    /// </summary>
    public class DiaChiKHDecorator : AbstractDecorator
    {
        TAIKHOANKHACHHANG kh1;
        public DiaChiKHDecorator(AbstractKhachHang kh, string diaChi, TAIKHOANKHACHHANG kh1) : base(kh)
        {
            this.kh1 = kh1;
            DiachiKH = diaChi;
        }

        public override TAIKHOANKHACHHANG MakeKhachHang()
        {
            base.MakeKhachHang();
            TAIKHOANKHACHHANG kh = kh1;
            kh.DiachiKH = DiachiKH;
            return kh;
        }
    }
}