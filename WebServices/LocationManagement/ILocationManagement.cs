using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LocationManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILocationManagement" in both code and config file together.
    [ServiceContract]
    public interface ILocationManagement
    {
        [WebInvoke(UriTemplate = "RegisterLocation", Method = "POST", ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string RegisterLocation(Location location);

        [WebInvoke(UriTemplate = "GetAllLocation", Method = "GET", ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<Location> GetAllLocation();
    }
}
