using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectToSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection con = new SqlConnection())
            {
                Console.WriteLine("Connecting to DB");
                con.ConnectionString = "Database=Kinect;Data Source=DESKTOP-I13JUQ1;Integrated Security=True";
                con.Open();

                /*
                Console.WriteLine("Inserting");
                SqlCommand ins = new SqlCommand("INSERT INTO tkp_rutina (id_rutina, nom_rutina) VALUES (@0, @1)", con);
                ins.Parameters.Add(new SqlParameter("0", 11));
                ins.Parameters.Add(new SqlParameter("1", "easy"));
                */

                Console.WriteLine("Executing command select");
                SqlCommand command = new SqlCommand("SELECT * FROM tkp_rutina", con);                

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2}", reader[0], reader[1], reader[2]));
                    }
                }

                Console.WriteLine("Stored Procedure");
                SqlCommand com = new SqlCommand("pa_get_all_rutina", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.ExecuteNonQuery();

                using (SqlDataReader rdr = com.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2}", rdr["id_ejercicio"], rdr["nom_rutina"], rdr["id_rutina"]));
                    }
                }

                Console.WriteLine("Finish command");
                Console.Read();
            }
        }
    }
}
