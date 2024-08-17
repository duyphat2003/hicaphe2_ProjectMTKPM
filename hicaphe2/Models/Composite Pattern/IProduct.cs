using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hicaphe2.Models.Composite_Pattern
{
    /// <summary>
    /// Composite Pattern
    /// </summary>
    public interface IProduct
    {
         string MaSP { get; set; }
         string TenSP { get; set; }
         string Kichthuoc { get; set; }
         string Donvitinh { get; set; }
         int? MaLoaiSP {  get; set; }
         decimal Dongia { get; set; }
         string Mota { get; set; }
         string Hinhminhhoa { get; set; }
        int? Soluongban { get; set; }
         LOAISP LOAISP { get; set; }
    }
}
