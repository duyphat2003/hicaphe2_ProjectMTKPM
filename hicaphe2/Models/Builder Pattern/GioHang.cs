using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Builder_Pattern
{
    public class GioHang
    {
        IBuilderMatHang builderMatHang;
        public void Construct(IBuilderMatHang builderMatHang) 
        {
            this.builderMatHang = builderMatHang;
            builderMatHang.SetMaSP();
            builderMatHang.SetTenSP();
            builderMatHang.SetHinhminhhoa();
            builderMatHang.SetKichthuoc();
            builderMatHang.SetDongia();
            builderMatHang.SetSoLuong();
        }
    }
}