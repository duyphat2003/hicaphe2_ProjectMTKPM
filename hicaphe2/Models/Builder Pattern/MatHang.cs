using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Builder_Pattern
{
    public class MatHang : IBuilderMatHang
    {
        HiCaPheEntities1 db = new HiCaPheEntities1();
        SanPham sanPham;
        SANPHAM sanPhamInfo;
        int soLuong = 0;

        public MatHang(string MaSP)
        {
            sanPham = new SanPham();
            sanPhamInfo = db.SANPHAM.Single(s => s.MaSP == MaSP);
            soLuong++;
        }

        public void SetDongia()
        {
            sanPham.Add(sanPhamInfo.Dongia.ToString());
        }

        public void SetHinhminhhoa()
        {
            sanPham.Add(sanPhamInfo.Hinhminhhoa);
        }

        public void SetKichthuoc()
        {
            sanPham.Add(sanPhamInfo.Kichthuoc);
        }

        public void SetMaSP()
        {
            sanPham.Add(sanPhamInfo.MaSP);
        }

        public void SetSoLuong()
        {
            sanPham.Add(soLuong.ToString());
            sanPham.NextSanPham();
        }

        public void SetTenSP()
        {
            sanPham.Add(sanPhamInfo.TenSP);
        }

        public SanPham GetSanPham()
        {
            return sanPham;
        }
    }
}