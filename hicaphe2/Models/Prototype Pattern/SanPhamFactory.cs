using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

///<summary>
/// Prototype Pattern
/// </summary>

namespace hicaphe2.Models
{
    public class SanPhamFactory
    {
        private readonly SanPhamX adminSP, hiCaPheSP;
        public SanPhamFactory()
        {
            adminSP = new SanPhamAdmin(5);
            hiCaPheSP = new SanPhamHiCaPhe(7);
        }
        public SanPhamX GetAdminSP()
        {
            return adminSP.Clone();
        }
        public SanPhamX GetHiCaPheSP()
        {
            return hiCaPheSP.Clone();
        }
    }
}