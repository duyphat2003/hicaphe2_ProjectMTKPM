using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hicaphe2.Models.Builder_Pattern
{
    public interface IBuilderMatHang
    {
        void SetMaSP();
        void SetTenSP();
        void SetHinhminhhoa();
        void SetKichthuoc();
        void SetDongia();
        void SetSoLuong();
        SanPham GetSanPham();
    }
}
