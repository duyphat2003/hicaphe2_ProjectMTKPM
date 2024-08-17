using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Tokenizer.Symbols;

namespace hicaphe2.Models.Proxy_Pattern
{
    public class Proxy : SanPhamManagement
    {
        SanPhamManagement _manPhamManagement;

        public override List<SANPHAM> FilterSanPham_LoaiSP(List<SANPHAM> listSP, int type)
        {
            if (_manPhamManagement == null)
                _manPhamManagement = new ConcreteSanPham();


            return _manPhamManagement.FilterSanPham_LoaiSP(listSP, type);
        }

        public override List<SANPHAM> FilterSanPham_Name(List<SANPHAM> listSP, string keyword)
        {
            if(_manPhamManagement == null)
                _manPhamManagement = new ConcreteSanPham();
            

             return _manPhamManagement.FilterSanPham_Name(listSP, keyword);
        }
    }
}