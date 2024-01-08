using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Builder_Pattern
{
    /// <summary>
    /// Builder Pattern
    /// </summary>
    public class TaoSanPham
    {
        List<string> infos;
        Tuple<int, int, int> color;
        string text;

        public TaoSanPham() => infos = new List<string>();

        public void AddInfo(string info) => infos.Add(info);

        public void DecorateSPCart(string text, Tuple<int, int, int> color)
        {
            this.text = text;
            this.color = color;
        }

        public MatHangMua matHangMua()
        {
            string maSP = infos.ElementAt(0).ToString();
            string ten = infos.ElementAt(1).ToString();
            string hinhMinhHoa = infos.ElementAt(2).ToString();
            string kichThuoc = infos.ElementAt(3).ToString();
            double.TryParse(infos.ElementAt(4).ToString(), out double donGia);
            int.TryParse(infos.ElementAt(5).ToString(), out int loai);
            int.TryParse(infos.ElementAt(6).ToString(), out int soLuong);
            return new MatHangMua(maSP,
                ten,
                hinhMinhHoa,
                kichThuoc,
                donGia,
                loai,
                soLuong,
                text, 
                color);
        }
    }
}