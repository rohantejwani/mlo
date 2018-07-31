using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;

namespace OrderManagement
{
    public class OrderMgtBL
    {
        internal string CreateOrder(OrderDetails location)
        {
            return new PersistentHelper().CreateOrder(location);
        }

        internal List<OrderDetails> GetOrder(string userId, string state)
        {
            return new PersistentHelper().GetOrder(userId, state);
        }
    }
}