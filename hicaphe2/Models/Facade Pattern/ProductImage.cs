using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Facade_Pattern
{
	public class ProductImage
	{
		string FileImage;

		public ProductImage(string FileImage)
		{
			this.FileImage = FileImage;
			
		}
		public void SetImage(SANPHAM sanpham)
		{
			sanpham.Hinhminhhoa = FileImage;
		}
		

	}
}