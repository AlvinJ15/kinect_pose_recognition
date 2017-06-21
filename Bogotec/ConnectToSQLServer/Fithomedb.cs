using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToSQLServer
{
    class Fithomedb
    {
        private SqlConnection con;

        public void OpenConnection()
        {
            con.ConnectionString = "Database=Kinect;Data Source=DESKTOP-I13JUQ1;Integrated Security=True";
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }

        public void AddTrainingRed(String name, String code)
        {
            SqlCommand com = new SqlCommand("pa_add_training_red", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@name", name));
            com.Parameters.Add(new SqlParameter("@code", code));
            com.ExecuteNonQuery();
        }

        public List<object[]> GetTrainingRed(String name)
        {
            List<object[]> res = new List<object[]>; int i = 0;
            SqlCommand com = new SqlCommand("pa_get_training_red", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@name", name));
            com.ExecuteNonQuery();

            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    object[] tmp = new object[4];
                    rdr.GetValues(tmp);
                    res.Add(tmp);
                }
            }
            return res;
        }

        public List<object[]> GetAllRutine()
        {
            List<object[]> res = new List<object[]>; int i = 0;
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
                    //rdr["id_ejercicio"], rdr["nom_rutina"], rdr["id_rutina"]));
                }
            }
            return res;
        }

        public List<object[]> GetExercise(int id)
        {
            List<object[]> res = new List<object[]>; int i = 0;
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

        public List<object[]> GetExercises()
        {
            List<object[]> res = new List<object[]>; int i = 0;
            SqlCommand com = new SqlCommand("pa_get_exercices", con);
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
    }
}
