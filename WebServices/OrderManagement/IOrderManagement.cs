using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OrderManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrderManagement" in both code and config file together.
    [ServiceContract]
    public interface IOrderManagement
    {
        [WebInvoke(UriTemplate = "CreateOrder", Method = "POST", ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string CreateOrder(OrderDetails location);

        [WebInvoke(UriTemplate = "GetOrder?userId={userId}&state={state}", Method = "GET", ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<OrderDetails> GetOrder(string userId, string state);
    }
}
