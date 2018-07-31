using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;

namespace LocationManagement
{
    public class LocMgtBL
    {
        internal List<Location> GetAllLocation()
        {
            return new PersistentHelper().GetAllLocation();
        }

        internal string RegisterLocation(Location location)
        {
            return new PersistentHelper().RegisterLocation(location);
        }
    }
}