using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Builder_Pattern
{
    /// <summary>
    /// Builder Pattern
    /// </summary>
    public class SanXuatSP
    {
        IBuilderSanPham iBuilderSanPham;

        public void Constructor(IBuilderSanPham iBuilderSanPham, string message, Tuple<int, int, int> color)
        {
            this.iBuilderSanPham = iBuilderSanPham;
            iBuilderSanPham.SetEffectImage(message, color);
            iBuilderSanPham.SetMaSP();
            iBuilderSanPham.SetTenSP();
            iBuilderSanPham.SetHinhMinhHoa();
            iBuilderSanPham.SetKichThuoc();
            iBuilderSanPham.SetDongia();
            iBuilderSanPham.SetLoai();
            iBuilderSanPham.SetSoLuong();
        }
    }
}