using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Composite_Pattern
{
    public class CompositeProduct : IProduct
    {

        List<IProduct> listSP;

        public string MaSP { get ; set ; }
        public string TenSP { get ; set ; }
        public string Kichthuoc { get ; set ; }
        public string Donvitinh { get ; set ; }
        public int? MaLoaiSP { get ; set ; }
        public decimal Dongia { get ; set ; }
        public string Mota { get ; set ; }
        public string Hinhminhhoa { get ; set ; }
        public int? Soluongban { get ; set ; }
        public LOAISP LOAISP { get ; set ; }

        public CompositeProduct()
        {
            listSP = new List<IProduct>();  
        }

        public void AddProduct(IProduct sanPham)
        {
            listSP.Add(sanPham);

        }
        public void RemoveProduct(IProduct sanPham)
        {
            listSP.Remove(sanPham);
        }

        public List<IProduct> GetList() => listSP;
        
    }
} 