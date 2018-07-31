using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using PersistenceManager;
using Utility;
using Newtonsoft.Json;
using System.Globalization;
using Newtonsoft.Json.Converters;

namespace OrderManagement
{
    public class PersistentHelper
    {
        internal string CreateOrder(OrderDetails order)
        {
            DateTime dt = (DateTime)order.requestTime;

            string query = "INSERT INTO `mlo`.`orders`(`user_id`,`destination`,`loc_coordinates`,`challan_no`,`no_of_Items`,`request_time`," +
                //"`pickup_by`,`pickup_time`,`drop_time`,`vehicle_no`,`driver`,`load_time`," +
                "`state`) VALUES (" +
                            //"'" + order.Id  +"', "+
                            "'" + order.userId + "'," +
                            "'" + order.destination + "'," +
                            "'" + order.locationCoordinates + "'," +
                            "'" + order.challanNumber + "'," +
                            "" + order.noOfItems + "," +
                            "'" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                            //"" + order.pickupBy  + "," +
                            //"'" + order.pickupTime  + "'," +
                            //"'" + order.dropTime  + "'," +
                            //"'" + order.vehicleNo  + "'," +
                            //"" + order.driver  + "," +
                            //"'" + order.loadTime  + "'," +
                            "'" + order.state + "'" +
                            ")";

            List<List<Dictionary<String, string>>> persistentCarrier = new List<List<Dictionary<String, string>>>();
            try
            {
                persistentCarrier = DBUtility.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                //Logger.Log(Level.Error, "Error in Sign Up :: " + ex.Message + "\n Caused By :- " + ex.StackTrace);
                //throw new WebFaultException<CustomFault>(new CustomFault("Error in Sign Up ", skyboInternalSvrErr, ex.Message), internalSvrErr);
                throw ex;
            }
            return "Success";
        }

        internal List<OrderDetails> GetOrder(string userId, string state)
        {
            string query = "SELECT * FROM mlo.orders where user_id = '" + userId + "' and state = '" + state + "'";
            List<List<Dictionary<String, string>>> persistentCarrier = new List<List<Dictionary<String, string>>>();
            List<OrderDetails> orders = new List<OrderDetails>();
            try
            {
                persistentCarrier = DBUtility.ExecuteQuery(query);

                SBMapper map = new SBMapper();
                List<PropertyMap> listPropertyMap = PropertyMapper.MapOrder();
                map.MapperCollection = listPropertyMap;
                OrderDetails order = null;
                foreach (Dictionary<string, string> eachCarrier in persistentCarrier[0])
                {
                    order = new OrderDetails();
                    string json = DTOMapper.Mapper(eachCarrier, order, map);
                    Console.WriteLine("Destination = " + (json));

                    var format = "dd-MM-yyyy HH:mm:ss"; // your datetime format
                    var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
                    order = Newtonsoft.Json.JsonConvert.DeserializeObject<OrderDetails>(json, dateTimeConverter);



                    //order = JsonConvert.DeserializeObject<OrderDetails>(json);
                    orders.Add(order);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return orders;
        }
    }
}