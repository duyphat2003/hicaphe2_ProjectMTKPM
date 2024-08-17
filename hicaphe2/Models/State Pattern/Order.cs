using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hicaphe2.Models.State_Pattern
{
    public class Order
    {

        private IOrderState _orderState;
        
        public Order(IOrderState state)
        {
            _orderState = state;
        }

        public void SetState(IOrderState state)
        {
            _orderState = state;
        }
        public void ApproveOrder(DONDATHANG order)
        {
            _orderState.ApproveOrder(order);
        }
        public void CancelOrder(DONDATHANG order)
        {
            _orderState.CancelOrder(order);
        }

    }
}