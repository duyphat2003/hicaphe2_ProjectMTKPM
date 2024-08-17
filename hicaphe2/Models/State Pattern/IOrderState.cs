using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hicaphe2.Models.State_Pattern
{
    /// <summary>
    /// State Pattern
    /// </summary>
    public interface IOrderState
    {
        void ApproveOrder(DONDATHANG order);
        void CancelOrder(DONDATHANG order);
    }
}   
