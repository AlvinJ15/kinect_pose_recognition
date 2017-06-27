using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace ConnectToSQLServer
{
    class Program
    {
        static void Main(string[] args)        
        {
            String test = DbServices.GetTrainingRed("prueba1", "static");
            Console.WriteLine("Respuesta " + test);
            List<object[]> tt = DbServices.GetAllRutinesWithExercises();
            foreach (var obj in tt)
            {
                Console.WriteLine(String.Format("{0} \t | {1} \t | {2}", obj[0], obj[1], obj[2]));
            }
            //string[] data = { "asdasdasdasdasdasdasd", "asdfdsfksdbfjsdbfj", "asdasjkdashjd" };
            //DbServices.AddFramesToExercise(1, data);
            List<String> ttt = DbServices.GetFramesFromExercise(1);
            foreach (var obj in ttt)
            {
                Console.WriteLine(obj);
            }

            DBInstance.closeConnection();
            Console.Read();
            
            /*
            using (SqlConnection con = new SqlConnection())
            {
                Console.WriteLine("Connecting to DB");
                con.ConnectionString = "Database=Kinect;Data Source=DESKTOP-I13JUQ1;Integrated Security=True";
                con.Open();

                
                Console.WriteLine("Inserting");
                SqlCommand ins = new SqlCommand("INSERT INTO tkp_rutina (id_rutina, nom_rutina) VALUES (@0, @1)", con);
                ins.Parameters.Add(new SqlParameter("0", 11));
                ins.Parameters.Add(new SqlParameter("1", "easy"));
                

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
            */
        }
    }
}
