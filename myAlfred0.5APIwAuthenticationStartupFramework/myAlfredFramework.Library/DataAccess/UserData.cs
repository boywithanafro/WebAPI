using myAlfredFramework.Library.Internal.DataAccess;
using myAlfredFramework.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myAlfredFramework.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = Id }; // Parsing in the method Id param and setting property name to Id

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "myAlfredData"); //(Stored Procedure, Parameters, ConnectionString in Web.config)

            return output;
        }
    }
}
