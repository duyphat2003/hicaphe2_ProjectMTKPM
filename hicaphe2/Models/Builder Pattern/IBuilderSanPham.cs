using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Builder_Pattern
{
    /// <summary>
    /// Builder Pattern
    /// </summary>
    public interface IBuilderSanPham
    {
        void SetMaSP();
        void SetTenSP();
        void SetHinhMinhHoa();
        void SetKichThuoc();
        void SetDongia();
        void SetLoai();
        void SetSoLuong();
        TaoSanPham GetSanPham();
    }
}