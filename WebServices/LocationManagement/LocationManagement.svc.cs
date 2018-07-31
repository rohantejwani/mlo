using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DTO;

namespace LocationManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LocationManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LocationManagement.svc or LocationManagement.svc.cs at the Solution Explorer and start debugging.
    public class LocationManagement : ILocationManagement
    {
        public List<Location> GetAllLocation()
        {
            return new LocMgtBL().GetAllLocation();
        }

        public string RegisterLocation(Location location)
        {
            return new LocMgtBL().RegisterLocation(location);
        }
    }
}
