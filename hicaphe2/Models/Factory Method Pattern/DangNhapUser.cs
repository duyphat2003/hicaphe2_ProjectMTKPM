using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Factory Method Pattern
/// </summary>
namespace hicaphe2.Models.Factory_Method_Pattern
{
    public class DangNhapUser : DangNhapFactory<TAIKHOANKHACHHANG>
    {
        public override ILogin<TAIKHOANKHACHHANG> CreateLogin()
        {
            return new User();
        }
    }
}