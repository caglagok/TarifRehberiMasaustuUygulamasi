using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Yazlab_1
{
    public class DatabaseHelper
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["description"].ConnectionString;

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
