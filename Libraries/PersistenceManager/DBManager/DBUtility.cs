﻿using log4net.Core;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PersistenceManager
{
    public class DBUtility
    {
        public static ArrayList InvokeProcedure(string procedure, List<SqlParameter> values)
        {
            string connStr = ConfigurationManager.AppSettings["SQLConnectionStr"];
            ArrayList rowList = new ArrayList();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(values.ToArray());
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            object[] rdrValue = new object[rdr.FieldCount];
                            rdr.GetValues(rdrValue);
                            rowList.Add(rdrValue);
                        }
                    }
                }
                return rowList;
            }
            
        }

        public static List<List<Dictionary<String, string>>> ExecuteQuery(string procedure, List<SqlParameter> values)
        {
            string connStr = ConfigurationManager.AppSettings["MySQLConnectionStr"];
            MySqlConnection mySQLConnection = new MySqlConnection(connStr);

            ArrayList rowList = new ArrayList();
            List<DataRow> dr = null;
            List<List<Dictionary<String, string>>> persistentCarrier = new List<List<Dictionary<string, string>>>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(procedure, conn))
                {

                    cmd.CommandText = procedure;

                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddRange(values.ToArray());
                    //cmd.Parameters.Add("?person", MySqlDbType.VarChar).Value = "myname";

                    conn.Open();
                    List<Dictionary<String, string>> tempCarrier = null;
                    bool nextTable;
                    
                    try
                    {
                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            do
                            {
                                tempCarrier = new List<Dictionary<string, string>>();
                                nextTable = false;
                                DataTable dt = new DataTable();
                                // Reader.loads the next table also and updates the reader object
                                dt.Load(rdr);
                                dr = dt.AsEnumerable().ToList();
                                foreach (DataRow row in dt.Rows)
                                {
                                    Dictionary<string, string> columnValues = new Dictionary<string, string>();
                                    foreach (DataColumn c in row.Table.Columns)
                                    {
                                        columnValues.Add(c.ColumnName, row[c].ToString());
                                    }
                                    tempCarrier.Add(columnValues);
                                }
                                persistentCarrier.Add(tempCarrier);
                                if (!rdr.IsClosed && rdr.FieldCount != 0)
                                {
                                    
                                    nextTable = true;
                                }

                            } while (nextTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return persistentCarrier;
            }

        }

        public static List<List<Dictionary<String, string>>> ExecuteQuery(string procedure)
        {
            string connStr = ConfigurationManager.AppSettings["MySQLConnectionStr"];
            MySqlConnection mySQLConnection = new MySqlConnection(connStr);

            ArrayList rowList = new ArrayList();
            List<DataRow> dr = null;
            List<List<Dictionary<String, string>>> persistentCarrier = new List<List<Dictionary<string, string>>>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(procedure, conn))
                {

                    cmd.CommandText = procedure;

                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddRange(values.ToArray());
                    //cmd.Parameters.Add("?person", MySqlDbType.VarChar).Value = "myname";

                    conn.Open();
                    List<Dictionary<String, string>> tempCarrier = null;
                    bool nextTable;

                    try
                    {
                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            do
                            {
                                tempCarrier = new List<Dictionary<string, string>>();
                                nextTable = false;
                                DataTable dt = new DataTable();
                                // Reader.loads the next table also and updates the reader object
                                dt.Load(rdr);
                                dr = dt.AsEnumerable().ToList();
                                foreach (DataRow row in dt.Rows)
                                {
                                    Dictionary<string, string> columnValues = new Dictionary<string, string>();
                                    foreach (DataColumn c in row.Table.Columns)
                                    {
                                        columnValues.Add(c.ColumnName, row[c].ToString());
                                    }
                                    tempCarrier.Add(columnValues);
                                }
                                persistentCarrier.Add(tempCarrier);
                                if (!rdr.IsClosed && rdr.FieldCount != 0)
                                {

                                    nextTable = true;
                                }

                            } while (nextTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return persistentCarrier;
            }

        }

        public static DataSet InvokeProcWithMultiSelect(string procedure,Dictionary<string, object> values)
        {
            string connStr = ConfigurationManager.AppSettings["SQLConnectionStr"];
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                DataSet dataset = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(procedure, conn);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (KeyValuePair<string, object> eachValue in values)
                    {
                        adapter.SelectCommand.Parameters.AddWithValue(eachValue.Key, eachValue.Value);
                    }
                    adapter.Fill(dataset);
                }
                return dataset;
            }
        }

        public static int InvokeSPWithReturnVal(string procedure, List<SqlParameter> values)
        {
            string connStr = ConfigurationManager.AppSettings["SQLConnectionStr"];
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter returnParameter = cmd.Parameters.Add("@RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.AddRange(values.ToArray());

                    conn.Open();
                    cmd.ExecuteReader();
                    int id = 0;
                    id = Convert.ToInt32(returnParameter.Value);                    
                    return id;
                }
            }          
        }

        public static string InvokeSPScalar(string procedure, List<SqlParameter> values)
        {
            string connStr = ConfigurationManager.AppSettings["SQLConnectionStr"];
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddRange(values.ToArray()); conn.Open();
                    object response = cmd.ExecuteScalar();

                    if (response != DBNull.Value)
                        return (string)response;

                    return string.Empty;
                }
            }
        }
    }



}
