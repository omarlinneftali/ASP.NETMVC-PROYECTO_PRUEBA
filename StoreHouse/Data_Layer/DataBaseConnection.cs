using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace StoreHouse.Data_Layer
{
    public class DataBaseConnection
    {

        private static readonly SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StoreHouse"].ConnectionString);


        public static SqlConnection Connection
        {
            get
            {
                return _connection;
            }

        }

        private DataBaseConnection()
        {

        }



    }
}