using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace hicaphe2.Models.Decorator_Pattern
{
    /// <summary>
    /// Decorator Pattern
    /// </summary>
    public class EmailKHDecorator : AbstractDecorator
    {
        TAIKHOANKHACHHANG kh1;
        public EmailKHDecorator(AbstractKhachHang kh, string email, TAIKHOANKHACHHANG kh1) : base(kh)
        {
            this.kh1 = kh1;
            Email = email;
        }

        public override TAIKHOANKHACHHANG MakeKhachHang()
        {
            base.MakeKhachHang();
            TAIKHOANKHACHHANG kh = kh1;
            kh.Email = Email;
            return kh;
        }
    }
}