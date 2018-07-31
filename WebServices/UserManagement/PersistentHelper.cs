using DTO;
using Newtonsoft.Json;
using PersistenceManager;
using Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using Utility;

namespace UserManagement
{
    static class Helper
    {
        public static string GetUntilOrEmpty(this string text, string stopAt = "_")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }
            return String.Empty;
        }
    }

    public class PersistentHelper
    {
        internal static LoginInfo SignIn(string userId, String password)
        {
            LoginInfo user = null;
            try
            {
                List<SqlParameter> ParametersList = new List<SqlParameter>()
                {
                    //new SqlParameter("@user_id", SqlDbType.NVarChar) {Value = userId}
                };
                // userId.GetUntilOrEmpty();
                String query = string.Empty;
                switch(userId.GetUntilOrEmpty().ToLower())
                {
                    case "di":
                    case "wh":
                    case "re":
                        query = "Select * from mlo.users where login_id='" + userId + "' and password='" + password + "' and active=1";
                        break;
                    case "co":
                        query = "Select * from mlo.collector where login_id='" + userId + "' and password='" + password + "' and active=1";
                        break;
                    case "lo":
                        query = "Select * from mlo.loader where login_id='" + userId + "' and password='" + password + "' and active=1";
                        break;
                    case "dr":
                        query = "Select * from mlo.driver where login_id='" + userId + "' and password='" + password + "' and active=1";
                        break;
                    default:
                        throw new Exception("Login Id not in proper format.!");
                }
                List<List<Dictionary<String, string>>> persistentCarrier = new List<List<Dictionary<String, string>>>();
                
                persistentCarrier = DBUtility.ExecuteQuery(query, ParametersList);

                SBMapper map = new SBMapper();
                List<PropertyMap> listPropertyMap = PropertyMapper.MapSignedInUser();
                map.MapperCollection = listPropertyMap;
                foreach (Dictionary<string, string> eachCarrier in persistentCarrier[0])
                {
                    user = new LoginInfo();
                    string json = DTOMapper.Mapper(eachCarrier, user, map);
                    Console.WriteLine("Destination = " + (json));
                    user = JsonConvert.DeserializeObject<LoginInfo>(json);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //Logger.Log(Level.Error, "Error in SignIn :: " + ex.Message + "\n Caused By :- " + ex.StackTrace);
                //throw new WebFaultException<CustomFault>(new CustomFault("Error in SignIn ", skyboInternalSvrErr, ex.Message), internalSvrErr);
            }

            //LoginInfo user = new LoginInfo(1, "Bradley", "Sharman", "Live", "https://bj1spjdj5z-flywheel.netdna-ssl.com/wp-content/uploads/2015/08/RushHour-1100x733.jpg");
            return user;
        }

        internal static string SignUp(LoginInfo userInfo, String query)
        {
            int userId = 0;
            List<SqlParameter> ParametersList = new List<SqlParameter>()
            {
                //new SqlParameter("@first_name", SqlDbType.NVarChar) {Value = userInfo.Name},
                //new SqlParameter("@surname", SqlDbType.NVarChar) {Value = userInfo.last_name },
                //new SqlParameter("@mobile_no", SqlDbType.NVarChar) {Value = userInfo.MobileNumber},
                ////new SqlParameter("@user_name", SqlDbType.NVarChar) {Value = userInfo.UserName },
                //new SqlParameter("@profile_pic", SqlDbType.NVarChar) {Value = userInfo.Url},
                //new SqlParameter("@dob", SqlDbType.Date) {Value = userInfo.DOB},
                //new SqlParameter("@email_id", SqlDbType.NVarChar) {Value = userInfo.EMailId},
                //new SqlParameter("@gender", SqlDbType.NVarChar) {Value = userInfo.Gender },
                //new SqlParameter("@access_token", SqlDbType.NVarChar) {Value = userInfo.AccessToken}
            };

            List<List<Dictionary<String, string>>> persistentCarrier = new List<List<Dictionary<String, string>>>();
            try
            {
                persistentCarrier = DBUtility.ExecuteQuery(query, ParametersList);
            }
            catch (Exception ex)
            {
                //Logger.Log(Level.Error, "Error in Sign Up :: " + ex.Message + "\n Caused By :- " + ex.StackTrace);
                //throw new WebFaultException<CustomFault>(new CustomFault("Error in Sign Up ", skyboInternalSvrErr, ex.Message), internalSvrErr);
                throw ex;
            }
            return Convert.ToString(userId);
        }
    }
}