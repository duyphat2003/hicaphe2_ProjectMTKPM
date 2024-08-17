using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hicaphe2.Models.StrategyPattern
{
    public class PaymentStrategyFactory
    {
        public IPaymentStrategy CreatePaymentStrategy(string paymentMethod)
        {
            switch (paymentMethod)
            {
                case "OnlinePayment":
                    return new ThanhToanOnline();
                case "CashPayment":
                    return new ThanhToanTienMat();
                default:
                    throw new ArgumentException("Invalid payment method", nameof(paymentMethod));
            }
        }
    }
}