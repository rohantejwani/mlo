using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement
{
    public class UserMgtBL
    {
        internal LoginInfo SignIn(String userId, String password)
        {
            return PersistentHelper.SignIn(userId, password);
        }

        internal string SignUp(LoginInfo loginInfo)
        {
            String query = String.Empty;
            switch(loginInfo.LoginType.ToLower())
            {
                case "distributor":
                case "wholesaler":
                case "retailer":
                    query = "INSERT INTO `mlo`.`users`(`login_id`,`password`,`first_name`,`surname`,`mobile_no`,`email_id`,`gender`,`profile_pic`,`dob`," +
                           "`access_token`)VALUES('" + loginInfo.LoginId + "','" + loginInfo.Password + "','" + loginInfo.Name + "','" + loginInfo.last_name + "','" + loginInfo.MobileNumber + "','" + loginInfo.EMailId + "','"
                            + loginInfo.Gender + "','" + loginInfo.Url + "','" + new DateTime() + "','" + loginInfo.AccessToken + "');";
                    

                    break;
                case "collector":
                    query = "INSERT INTO `mlo`.`collector`(`login_id`,`password`,`first_name`,`surname`,`mobile_no`,`email_id`,`gender`,`profile_pic`,`dob`," +
                           "`access_token`)VALUES('" + loginInfo.LoginId + "','" + loginInfo.Password + "','" + loginInfo.Name + "','" + loginInfo.last_name + "','" + loginInfo.MobileNumber + "','" + loginInfo.EMailId + "','"
                            + loginInfo.Gender + "','" + loginInfo.Url + "','" + new DateTime() + "','" + loginInfo.AccessToken + "');";

                    break;
                case "loader":
                    query = "INSERT INTO `mlo`.`loader`(`login_id`,`password`,`first_name`,`surname`,`mobile_no`,`email_id`,`gender`,`profile_pic`,`dob`," +
                          "`access_token`)VALUES('" + loginInfo.LoginId + "','" + loginInfo.Password + "','" + loginInfo.Name + "','" + loginInfo.last_name + "','" + loginInfo.MobileNumber + "','" + loginInfo.EMailId + "','"
                            + loginInfo.Gender + "','" + loginInfo.Url + "','" + new DateTime() + "','" + loginInfo.AccessToken + "');";

                    break;
                case "driver":
                    query = "INSERT INTO `mlo`.`driver`(`login_id`,`password`,`first_name`,`surname`,`mobile_no`,`email_id`,`gender`,`profile_pic`,`dob`," +
                          "`access_token`)VALUES('" + loginInfo.LoginId + "','" + loginInfo.Password + "','" + loginInfo.Name + "','" + loginInfo.last_name + "','" + loginInfo.MobileNumber + "','" + loginInfo.EMailId + "','"
                            + loginInfo.Gender + "','" + loginInfo.Url + "','" + new DateTime() + "','" + loginInfo.AccessToken + "');";

                    break;
                default:
                    throw new Exception("Login type has not been specified.");
            }

            return PersistentHelper.SignUp(loginInfo, query);
        }
    }
}