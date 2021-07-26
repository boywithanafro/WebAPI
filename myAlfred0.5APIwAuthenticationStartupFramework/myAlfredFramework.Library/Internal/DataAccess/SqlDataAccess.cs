using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myAlfredFramework.Library.Internal.DataAccess
{
    internal class SqlDataAccess // Internal as can't be seen or used outside of Library to strengthen security
    { //Read Method, Write Method, ConnectionString

        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString; // Gets connectionString from web.config/app.config
        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName) // Generic Load data method to allow us to work with Dapper easier
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            { // Query/Method to load and get data
                List<T> rows = connection.Query<T>(storedProcedure, parameters, 
                    commandType: CommandType.StoredProcedure).ToList(); // Using Dapper(like EF) to call storedProcedure, pass in params and return rows

                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName) // Generic Save data method to allow us to work with Dapper easier
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            { // Query/Method to load and get data
                connection.Execute(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure); // Using Dapper(like EF) to call storedProcedure, pass in params and execute query
            }
        }
    }
}
