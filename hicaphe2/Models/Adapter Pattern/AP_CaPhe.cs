using hicaphe2.Models.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Adapter_Pattern
{
    public class AP_CaPhe : ISanPhamDataProvider
    {
      
        public string HinhAnh { get; set; }

        public string TenSP { get; set; }
        public string Kichthuoc { get; set; }
        public string Donvitinh { get; set; }
        public decimal? Dongia { get; set; }
        public AP_CaPhe(string tenSP, string kichthuoc, string donvitinh, decimal? dongia, string hinhAnh)
        {
            TenSP = tenSP;
            Kichthuoc = kichthuoc;
            Donvitinh = donvitinh;
            Dongia = dongia;
            HinhAnh = hinhAnh;
        }

        public List<string> LaySanPhamMoi(int soLuong)
        {
            return new List<string>()
            {
                TenSP,
                Kichthuoc,
                Donvitinh,
                Dongia.ToString(),
                HinhAnh
            };
        }
    }
}