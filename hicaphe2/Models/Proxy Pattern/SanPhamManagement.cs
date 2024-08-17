using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Proxy_Pattern
{
    /// <summary>
    /// Proxy pattern
    /// </summary>
    public abstract class SanPhamManagement
    {
        public abstract  List<SANPHAM> FilterSanPham_Name(List<SANPHAM> listSP,string keyword);
        public abstract  List<SANPHAM> FilterSanPham_LoaiSP(List<SANPHAM> listSP, int type);
    }
}