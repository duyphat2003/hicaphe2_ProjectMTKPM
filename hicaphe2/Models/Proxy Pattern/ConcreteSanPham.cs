using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Tokenizer.Symbols;

namespace hicaphe2.Models.Proxy_Pattern
{
    public class ConcreteSanPham : SanPhamManagement
    {
        public override List<SANPHAM> FilterSanPham_LoaiSP(List<SANPHAM> listSP, int type)
        {
            if (type == -1)
                return listSP;
            else
                listSP = listSP.Where(sanpham => sanpham.MaLoaiSP == type).ToList();

            return listSP;
        }

        public override List<SANPHAM> FilterSanPham_Name(List<SANPHAM> listSP, string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return listSP;
            else
                listSP = listSP.Where(sanpham => sanpham.TenSP.ToLower().Contains(keyword.ToLower())).ToList();

            return listSP;
        }
    }

}