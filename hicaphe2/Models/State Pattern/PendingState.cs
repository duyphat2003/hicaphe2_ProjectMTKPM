using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.State_Pattern
{
    public class PendingState : IOrderState
    {
        public void ApproveOrder(DONDATHANG order)
        {
            order.Dagiao = true;
            order.Ngaygiaohang = DateTime.Now;
        }

        public void CancelOrder(DONDATHANG order)
        {
            order.Ngaygiaohang = null; // Đặt lại ngày giao hàng
            // Thực hiện xử lý hủy đơn hàng (cập nhật trạng thái, gửi thông báo, v.v.)
            order.Dagiao = false; // Đặt lại trạng thái là chưa giao

            order.Dahuy = true; // Đặt trạng thái đã hủy
        }
    }
}