using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DTO;

namespace OrderManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrderManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OrderManagement.svc or OrderManagement.svc.cs at the Solution Explorer and start debugging.
    public class OrderManagement : IOrderManagement
    {
        public string CreateOrder(OrderDetails location)
        {
            return new OrderMgtBL().CreateOrder(location);
        }

        public List<OrderDetails> GetOrder(string userId, string state)
        {
            return new OrderMgtBL().GetOrder(userId, state);
        }
    }
}
