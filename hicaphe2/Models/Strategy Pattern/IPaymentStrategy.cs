using hicaphe2.Models.Builder_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hicaphe2.Models.StrategyPattern
{
    /// <summary>
    /// Strategy pattern
    /// </summary>
    public interface IPaymentStrategy
    {
        void ProcessPayment(List<MatHangMua> gioHang, DONDATHANG order);
    }
}
