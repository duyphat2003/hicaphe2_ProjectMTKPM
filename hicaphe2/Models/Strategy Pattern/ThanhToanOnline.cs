using hicaphe2.Models.Builder_Pattern;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hicaphe2.Models.StrategyPattern
{
    public class ThanhToanOnline : IPaymentStrategy
    {
        public void ProcessPayment(List<MatHangMua> gioHang, DONDATHANG order)
        {
            // Tạo danh sách line items cho session Stripe
            var lineItems = new List<SessionLineItemOptions>();
            HiCaPheDatabase.Instance.database.DONDATHANG.Add(order);
            foreach (var sanPham in gioHang)
            {
                var lineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(sanPham.Dongia),
                        Currency = "VND",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = sanPham.TenSP,
                        },
                    },
                    Quantity = sanPham.SoLuong,
                };

                lineItems.Add(lineItem);
            }

            // Tạo options cho session Stripe
            var options = new Stripe.Checkout.SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
            {
                "card",
            },
                LineItems = lineItems,
                SuccessUrl = "https://localhost:44322/GioHang/HoanThanhDonDatHang",
                CancelUrl = "https://localhost:44322/GioHang/HienThiGioHang",
                Mode = "payment"
            };

            // Tạo session Stripe
            var service = new SessionService();
            Session session = service.Create(options);


            // Sau khi thanh toán thành công, trạng thái đơn hàng sẽ được cập nhật thành đã thanh toán
            order.HTThanhtoan = true;
            order.HTGiaohang = true;

            HttpContext.Current.Response.Redirect(session.Url, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

            HiCaPheDatabase.Instance.database.SaveChanges();
        }
    }
}