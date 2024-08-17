using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Composite_Pattern
{
    public class Product : IProduct
    {
        public Product(string maSP, string tenSP, string kichthuoc, string donvitinh, int? maLoaiSP, decimal dongia, string mota, string hinhminhhoa, int? soluongban)
        {
            MaSP = maSP;
            TenSP = tenSP;
            Kichthuoc = kichthuoc;
            Donvitinh = donvitinh;
            MaLoaiSP = maLoaiSP;
            Dongia = dongia;
            Mota = mota;
            Hinhminhhoa = hinhminhhoa;
            Soluongban = soluongban;
        }

        public string MaSP { get; set; }
        public string TenSP { get ; set ; }
        public string Kichthuoc { get ; set ; }
        public string Donvitinh { get ; set ; }
        public int? MaLoaiSP { get; set; }
        public decimal Dongia { get ; set ; }
        public string Mota { get ; set ; }
        public string Hinhminhhoa { get ; set ; }
        public int? Soluongban { get; set; }
        public LOAISP LOAISP { get; set; }
    }
}