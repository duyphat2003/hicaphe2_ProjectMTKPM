using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Decorator_Pattern
{
    /// <summary>
    /// Decorator Pattern
    /// </summary>
    public class AbstractDecorator : AbstractKhachHang
    {
        AbstractKhachHang kh;
        public AbstractDecorator(AbstractKhachHang kh)
        {
            this.kh = kh;
        }
        public override TAIKHOANKHACHHANG MakeKhachHang()
        {
            return kh.MakeKhachHang();
        }
    }
}