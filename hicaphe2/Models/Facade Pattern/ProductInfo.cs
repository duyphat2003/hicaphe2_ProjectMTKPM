using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Facade_Pattern
{
	public class ProductInfo
	{
		public ProductInfo(string maSP, string tenSP, string kichthuoc, string donvitinh, decimal? dongia, string mota, string hinhminhhoa, int? maLoaiSP, int? soluongban)
		{
			MaSP = maSP;
			TenSP = tenSP;
			Kichthuoc = kichthuoc;
			Donvitinh = donvitinh;
			Dongia = dongia;
			Mota = mota;
			Hinhminhhoa = hinhminhhoa;
			MaLoaiSP = maLoaiSP;
			Soluongban = soluongban;
		}

		string MaSP { get; set; }
		string TenSP { get; set; }
		string Kichthuoc { get; set; }
		string Donvitinh { get; set; }
		decimal? Dongia { get; set; }
		string Mota { get; set; }
		string Hinhminhhoa { get; set; }
		int? MaLoaiSP { get; set; }
		int? Soluongban { get; set; }
		public void SetInfo(SANPHAM sanpham)
		{
			sanpham.MaSP = MaSP;
			sanpham.TenSP = TenSP;
			sanpham.Kichthuoc = Kichthuoc;
			sanpham.Donvitinh = Donvitinh;
			sanpham.Dongia = Dongia;
			sanpham.Mota = Mota;
			sanpham.Hinhminhhoa = Hinhminhhoa;
			sanpham.MaLoaiSP = MaLoaiSP;
			sanpham.Soluongban = Soluongban;
		}
	}
        
}