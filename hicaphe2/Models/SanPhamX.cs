using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

///<summary>
/// Prototype Pattern
/// </summary>

namespace hicaphe2.Models
{
    public abstract class SanPhamX : Controller
    {
        public int productEachPage = 10;
        public IPagedList<SANPHAM> SetSanPham(int? page, string timkiemchuoi, double minPrice, double maxPrice)
        {
            var sanphams = HiCaPheDatabase.Instance.database.SANPHAM.ToList();
            //Tạo biến cho biết số sách mỗi trang
            int pageSize = productEachPage;
            //Tạo biến số trang
            int pageNum = (page ?? 1);

            //Tìm kiếm chuỗi truy vấn theo NamePro, nếu chuỗi truy vấn SearchString khác rỗng, null
            if (!String.IsNullOrEmpty(timkiemchuoi) && timkiemchuoi.Trim().Length != 0)
            {
                String lowerCaseSearchText = timkiemchuoi.ToLower();
                sanphams = sanphams.Where(s => s.TenSP.ToLower().Contains(timkiemchuoi)).ToList();
            }
            // Tìm kiếm chuỗi truy vấn theo đơn giá
            if (minPrice < maxPrice && minPrice >= 0 && maxPrice >= 0)
            {
                if (minPrice >= 0 && maxPrice > 0)
                {
                    sanphams = sanphams.OrderByDescending(x => x.Dongia).Where(p => (double)p.Dongia >= minPrice && (double)p.Dongia <= maxPrice).ToList();
                }
            }

            return sanphams.OrderBy(sanpham => sanpham.MaSP).ToPagedList(pageNum, pageSize);
        }   
        public abstract SanPhamX Clone();
    }
}