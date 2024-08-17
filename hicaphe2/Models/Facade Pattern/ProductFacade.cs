using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Facade_Pattern
{
	public class ProductFacade
	{
		ProductImage productImage;
		ProductInfo productInfo;

		public ProductFacade(string FileImage, string maSP, string tenSP, string kichthuoc, string donvitinh, decimal? dongia, string mota, string hinhminhhoa, int? maLoaiSP, int? soluongban)
		{
			productImage = new ProductImage(FileImage);
			productInfo = new ProductInfo(maSP, tenSP, kichthuoc, donvitinh, dongia, mota, hinhminhhoa, maLoaiSP, soluongban);
		}
		public void ConstructProduct(SANPHAM sanpham)
		{
			productImage.SetImage(sanpham);
			productInfo.SetInfo(sanpham);
		}
	}
}