using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.Builder_Pattern
{
    public class SanPham
    {
        private List<MatHangMua> matHangMuas;
        private List<string> infos;
        private List<List<string>> sanPhams;
        public SanPham()
        {
            matHangMuas = new List<MatHangMua>();
        }
        public void Add(string info)
        {
            // Adding infos
            infos.Add(info);
        }

        public void NextSanPham()
        {
            sanPhams.Add(infos);
            infos = new List<string>();
        }
        public List<MatHangMua> GetSanPham() 
        {
            foreach(List<string> sanpham in sanPhams)
            {
                matHangMuas.Add(new MatHangMua(sanpham.ElementAt(0), sanpham.ElementAt(1), sanpham.ElementAt(2), sanpham.ElementAt(3), double.Parse(sanpham.ElementAt(4)), int.Parse(sanpham.ElementAt(5))));
            }
            return matHangMuas;
        }
    }
}