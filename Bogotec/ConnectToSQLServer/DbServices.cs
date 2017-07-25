using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToSQLServer
{
    public class DbServices
    {
        public static void AddTrainingRed(String name, String code, String type)
        {
            //SqlConnection con = DBInstance.Instance;
            //SqlCommand com = new SqlCommand("pa_add_training_red", con);
            //com.CommandType = System.Data.CommandType.StoredProcedure;
            //com.Parameters.Add(new SqlParameter("@name", name));
            //com.Parameters.Add(new SqlParameter("@code", code));
            //com.Parameters.Add(new SqlParameter("@type", type));
            //com.ExecuteNonQuery();

            File.WriteAllBytes(name, Convert.FromBase64String(code));
        }


        public static String GetTrainingRed(String name, String type)
        {
            //string res = "";
            //SqlConnection con = DBInstance.Instance;
            //SqlCommand com = new SqlCommand("pa_get_training_red", con);
            //com.CommandType = System.Data.CommandType.StoredProcedure;
            //com.Parameters.Add(new SqlParameter("@name", name));
            //com.Parameters.Add(new SqlParameter("@type", type));
            //com.CommandTimeout = 120;
            //com.ExecuteNonQuery();

            //using (SqlDataReader rdr = com.ExecuteReader())
            //{
            //    while (rdr.Read())
            //    {
            //        res = (string)rdr["code"];
            //    }
            //}
            //return res;
            return Convert.ToBase64String(File.ReadAllBytes(name));

        }

        public static List<object[]> GetAllRutines()
        {
            List<object[]> res = new List<object[]>();
            SqlConnection con = DBInstance.Instance;
            SqlCommand com = new SqlCommand("pa_get_rutines", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.ExecuteNonQuery();

            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    object[] tmp = new object[2];
                    rdr.GetValues(tmp);
                    res.Add(tmp);
                }
            }
            return res;
        }

        public static List<object[]> GetAllRutinesWithExercises()
        {
            List<object[]> res = new List<object[]>();
            SqlConnection con = DBInstance.Instance;
            SqlCommand com = new SqlCommand("pa_get_all_rutina", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.ExecuteNonQuery();

            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    object[] tmp = new object[3];
                    rdr.GetValues(tmp);
                    res.Add(tmp);
                }
            }
            return res;
        }

        public static List<object[]> GetExercisesFromRutine(int id)
        {
            List<object[]> res = new List<object[]>();
            SqlConnection con = DBInstance.Instance;
            SqlCommand com = new SqlCommand("pa_get_exercise_rutine", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@idrutine", id));
            com.ExecuteNonQuery();

            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    object[] tmp = new object[2];
                    rdr.GetValues(tmp);
                    res.Add(tmp);
                }
            }
            return res;
        }

        public static List<object[]> GetExercise(int id)
        {
            List<object[]> res = new List<object[]>();
            SqlConnection con = DBInstance.Instance;
            SqlCommand com = new SqlCommand("pa_get_exercice", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@id", id));
            com.ExecuteNonQuery();

            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    object[] tmp = new object[3];
                    rdr.GetValues(tmp);
                    res.Add(tmp);
                }
            }
            return res;
        }

        public static void AddFramesToExercise(int id, string[] data)
        {
            SqlConnection con = DBInstance.Instance;
            foreach (var frame in data)
            {
                SqlCommand com = new SqlCommand("pa_set_frame", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@idexercise", id));
                com.Parameters.Add(new SqlParameter("@data", frame));
                com.ExecuteNonQuery();
            }
        }

        public static List<String> GetFramesFromExercise(int id)
        {
            List<String> res = new List<String>();
            SqlConnection con = DBInstance.Instance;
            SqlCommand com = new SqlCommand("pa_get_frames_exercise", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@idexercise", id));
            com.ExecuteNonQuery();

            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    res.Add((String)rdr["nom_frame"]);
                }
            }
            return res;
        }
    }
}
