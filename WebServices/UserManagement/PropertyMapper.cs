﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility;

namespace UserManagement
{
    public class PropertyMapper
    {
        public static List<PropertyMap> MapSignedInUser()
        {
            List<PropertyMap> listPropertyMap = new List<PropertyMap>();
            listPropertyMap.Add(new PropertyMap("id", "Id"));
            listPropertyMap.Add(new PropertyMap("login_id", "LI"));

            listPropertyMap.Add(new PropertyMap("login_type", "LT"));
            listPropertyMap.Add(new PropertyMap("first_name", "Name"));
            listPropertyMap.Add(new PropertyMap("surname", "LN"));

            listPropertyMap.Add(new PropertyMap("address", "FA"));
            listPropertyMap.Add(new PropertyMap("gst_no", "GST"));
            listPropertyMap.Add(new PropertyMap("mobile_no", "MN"));

            listPropertyMap.Add(new PropertyMap("email_id", "EId"));
            listPropertyMap.Add(new PropertyMap("gender", "Gender"));
            listPropertyMap.Add(new PropertyMap("profile_pic", "Url"));
            //listPropertyMap.Add(new PropertyMap("status", "Status"));
            listPropertyMap.Add(new PropertyMap("dob", "DOB"));
            listPropertyMap.Add(new PropertyMap("access_token", "AT"));
            listPropertyMap.Add(new PropertyMap("shop_no", "SN"));


            return listPropertyMap;
        }
    }
}