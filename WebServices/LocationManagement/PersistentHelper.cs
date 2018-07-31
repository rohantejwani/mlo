using System;
using System.Collections.Generic;
using DTO;
using PersistenceManager;
using Utility;
using Newtonsoft.Json;

namespace LocationManagement
{
    internal class PersistentHelper
    {
        public PersistentHelper()
        {
        }

        internal List<Location> GetAllLocation()
        {
            List<Location> locations = new List<Location>();
            List<List<Dictionary<String, string>>> persistentCarrier = new List<List<Dictionary<String, string>>>();
            try
            {
                String query = "SELECT * FROM `mlo`.`location`;";
                persistentCarrier = DBUtility.ExecuteQuery(query);

                SBMapper map = new SBMapper();
                map.MapperCollection = PropertyMapper.MapLocation();
                Location loc = null;
                foreach (Dictionary<string, string> eachCarrier in persistentCarrier[0])
                {
                    loc = new Location();
                    string json = DTOMapper.Mapper(eachCarrier, loc, map);
                    Console.WriteLine("Destination = " + (json));
                    loc = JsonConvert.DeserializeObject<Location>(json);
                    locations.Add(loc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //Logger.Log(Level.Error, "Error in SignIn :: " + ex.Message + "\n Caused By :- " + ex.StackTrace);
                //throw new WebFaultException<CustomFault>(new CustomFault("Error in SignIn ", skyboInternalSvrErr, ex.Message), internalSvrErr);
            }
            return locations;
        }

        internal string RegisterLocation(Location location)
        {
            String query = "INSERT INTO `mlo`.`location` (`name`, `coordinates`, `address`) VALUES ('" + location.name + "','" + location.coordinates + "','" + location.address + "'); ";
            try
            {
                DBUtility.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                //Logger.Log(Level.Error, "Error in Sign Up :: " + ex.Message + "\n Caused By :- " + ex.StackTrace);
                //throw new WebFaultException<CustomFault>(new CustomFault("Error in Sign Up ", skyboInternalSvrErr, ex.Message), internalSvrErr);
                throw ex;
            }
            return "Success";
        }
    }
}