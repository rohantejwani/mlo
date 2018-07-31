using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility;

namespace LocationManagement
{
    public class PropertyMapper
    {
        internal static List<PropertyMap> MapLocation()
        {
            List<PropertyMap> listPropertyMap = new List<PropertyMap>();
            listPropertyMap.Add(new PropertyMap("name", "ln"));
            listPropertyMap.Add(new PropertyMap("coordinates", "coord"));
            listPropertyMap.Add(new PropertyMap("address", "address"));
            return listPropertyMap;
        }
    }
}