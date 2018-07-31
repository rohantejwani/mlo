using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public class LoginInfo
    {
        // ???
        [DataMember(Name = "Id")]
        [Description("Id")]
        public int Id { get; set; }

        // ???
        //[DataMember(Name = "UN")]
        //[Description("User name")]
        //public string UserName { get; set; }

        [DataMember(Name = "LI")]
        [Description("LoginId")]
        public string LoginId { get; set; }

        [DataMember(Name = "Pwd")]
        [Description("Password")]
        public string Password { get; set; }

        [DataMember(Name = "FA")]
        [Description("FirmAddress")]
        public string FirmAddress { get; set; }

        [DataMember(Name = "GST")]
        [Description("GSTNo")]
        public string GSTNo { get; set; }


        [DataMember(Name = "SN")]
        [Description("Shop no")]
        public string ShopNo { get; set; }

        [DataMember(Name = "LT")]
        [Description("Login type")]
        public string LoginType { get; set; }

        [DataMember(Name = "Name")]
        [Description("First name")]
        public string Name { get; set; }

        [DataMember(Name = "LN")]
        [Description("Last Name")]
        public string last_name { get; set; }

        [DataMember(Name = "MN")]
        [Description("Mobile number")]
        public string MobileNumber { get; set; }

        [DataMember(Name = "EId")]
        [Description("EmailId")]
        public string EMailId { get; set; }

        [DataMember(Name = "Gender")]
        [Description("Gender")]
        public string Gender { get; set; }

        [DataMember(Name = "AT")]
        [Description("Access Token")]
        public string AccessToken { get; set; }

        [DataMember(Name = "DOB")]
        [Description("Date of birth")]
        public DateTime? DOB { get; set; }

        [DataMember(Name = "Status")]
        [Description("Status")]
        public string Status { get; set; }

        [DataMember(Name = "Url")]
        [Description("Url")]
        public string Url { get; set; }


    }

}
