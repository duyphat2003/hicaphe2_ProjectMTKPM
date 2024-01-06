using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

///<summary>
/// Prototype Pattern
/// </summary>

namespace hicaphe2.Models
{
    public class SanPhamAdmin : SanPhamX
    {
        public SanPhamAdmin(int sizePage) 
        {
            productEachPage = sizePage;
        }

        public override SanPhamX Clone()
        {
            return this.MemberwiseClone() as SanPhamAdmin;
        }
    }
}