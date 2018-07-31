using DTO;
using System;
using System.Configuration;
using Utility;

namespace MedicinalLogistics
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                LoginInfo loginInfo = new LoginInfo();
                loginInfo.Name = Name.Text;
                loginInfo.last_name = LastName.Text;
                loginInfo.FirmAddress = FirmAddress.Text;
                loginInfo.MobileNumber = Contact.Text;
                loginInfo.GSTNo = GSTNo.Text;
                loginInfo.EMailId = Email.Text;
                loginInfo.Password = Password.Text;
                loginInfo.ShopNo = ShopNo.Text;
                loginInfo.LoginType = "Wholesaler";
                // Create Login Id generator function

               // loginInfo.LoginType = LoginType.SelectedItem.Text;
                new RESTWebClient().Post<String>(ConfigurationManager.AppSettings["UserManagementURI"].ToString() + "/SignUp", loginInfo);
            }
            catch (Exception ex)
            {
                throw ex;
                //Logger.Log(Level.Error, "Error in raising event " + ex);
            }


            //string connStr = ConfigurationManager.AppSettings["SQLConnectionStr"];
            //string userId = "";//DB.PersistentHelper.Login(TextBox1.Text, TextBox2.Text);          

            //if (!userId.Equals("0"))
            //{
            //    Session["id"] = userId;
            //    Session["userName"] = TextBox1.Text;
            //    Response.Redirect("Redirectform.aspx");
            //    Session.RemoveAll();
            //}
            //else
            //{
            //    Label1.Text = "You're username and password is incorrect";
            //    Label1.ForeColor = System.Drawing.Color.Red;
            //}
        }
    }
}