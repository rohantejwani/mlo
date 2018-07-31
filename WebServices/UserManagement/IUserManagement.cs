using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UserManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserManagement" in both code and config file together.
    [ServiceContract]
    public interface IUserManagement
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "SignUp", Method = "POST", ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string SignUp(LoginInfo userInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "SignIn", Method = "POST", ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        LoginInfo SignIn(String userId, String password);
    }
}
