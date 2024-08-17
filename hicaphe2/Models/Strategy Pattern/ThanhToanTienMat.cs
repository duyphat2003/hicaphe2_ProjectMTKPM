using hicaphe2.Models.Builder_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.StrategyPattern
{
    public class ThanhToanTienMat : IPaymentStrategy
    {
        public void ProcessPayment(List<MatHangMua> gioHang, DONDATHANG order)
        {
            // Logic xử lý thanh toán bằng tiền mặt
            // Đánh dấu đơn hàng là đã thanh toán và lưu vào cơ sở dữ liệu
            order.HTThanhtoan = true;
            HiCaPheDatabase.Instance.database.DONDATHANG.Add(order);

            // Lưu thông tin chi tiết đơn hàng vào cơ sở dữ liệu
            foreach (var sanpham in gioHang)
            {
                CTDATHANG chitiet = new CTDATHANG();
                chitiet.SODH = order.SODH;
                chitiet.MaSP = sanpham.MaSP;
                chitiet.Soluong = sanpham.SoLuong;
                chitiet.Dongia = (decimal)sanpham.Dongia;
                HiCaPheDatabase.Instance.database.CTDATHANG.Add(chitiet);
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            HiCaPheDatabase.Instance.database.SaveChanges();
        }
    }
}