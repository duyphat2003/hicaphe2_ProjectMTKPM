using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Factory Method Pattern
/// </summary>
namespace hicaphe2.Models.Factory_Method_Pattern
{
    public class DangNhapAdmin : DangNhapFactory<ADMIN>
    {
        public override ILogin<ADMIN> CreateLogin()
        {
            return new Admin();
        }
    }
}