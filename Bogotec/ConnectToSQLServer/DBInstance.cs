using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectToSQLServer
{
    public sealed class DBInstance
    {
        private static readonly DBInstance instance = new DBInstance();
        private SqlConnection con;
        private DBInstance()
        {
            con = new SqlConnection();
            String constr = "Database=Kinect;Data Source=DESKTOP-I13JUQ1;Integrated Security=True";
            String constrazure = "Server=tcp:fithome.database.windows.net,1433;Initial Catalog=fithomedb;Persist Security Info=False;User ID=episadmin;Password='@112:EpiS;';MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.ConnectionString = constrazure;
            Console.WriteLine("Base de Datos abierta.");
            con.Open();
        }

        public static void closeConnection()
        {
            Console.WriteLine("Base de Datos cerrada.");
            instance.con.Close();
        }

        public static SqlConnection Instance
        {
            get
            {
                return instance.con;
            }
        }
    }
}
