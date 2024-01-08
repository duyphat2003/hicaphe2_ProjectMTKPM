using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace hicaphe2.Models.Builder_Pattern
{
    /// <summary>
    /// Builder Pattern
    /// </summary>

    public class Drink : IBuilderSanPham
    {
        HiCaPheEntities1 db = new HiCaPheEntities1();
        string MaSP;
        int soLuong;
        TaoSanPham taoSP;
        SANPHAM sanpham;
        public Drink(string MaSP)
        {
            taoSP = new TaoSanPham();
            this.MaSP = MaSP;
            sanpham = db.SANPHAM.Single(s => s.MaSP == this.MaSP);
            soLuong = 1;
        }

        public void SetMaSP()
        {
            taoSP.AddInfo(MaSP);
        }

        public void SetTenSP()
        {
            taoSP.AddInfo(sanpham.TenSP);
        }

        public void SetHinhMinhHoa()
        {
            taoSP.AddInfo(sanpham.Hinhminhhoa);
        }

        public void SetKichThuoc()
        {
            taoSP.AddInfo(sanpham.Kichthuoc);
        }

        public void SetDongia()
        {
            taoSP.AddInfo(sanpham.Dongia.ToString());
        }

        public void SetLoai()
        {
            taoSP.AddInfo(sanpham.LOAISP.ToString());
        }

        public void SetSoLuong()
        {
            taoSP.AddInfo(soLuong.ToString());
        }

        public TaoSanPham GetSanPham()
        {
            return taoSP;
        }
    }
}