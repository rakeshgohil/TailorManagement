using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using TailorManagementModels;

namespace TailorManagementDB
{

    public class PantRepository : IRepository<Pant>
    {
        private readonly string _connectionString;
        private const string spGetPants = "spGetPants";
        private const string spGetPantById = "spGetPantById";
        private const string spSavePant = "spSavePant";
        private const string spUpdatePant = "spUpdatePant";
        private const string spDeletePantById = "spDeletePantById";
        private const string spGetPantByCustomerId = "spGetPantByCustomerId";

        public PantRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TailorManagementDB"].ConnectionString; ;
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<Pant> GetAll()
        {
            List<Pant> pants = new List<Pant>();
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetPants, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pant pant = GetPantFromReader(reader);
                            pants.Add(pant);
                        }
                    }
                }
            }
            return pants;
        }

        private static Pant GetPantFromReader(SqlDataReader reader)
        {
            return new Pant
            {
                Id = (int)reader["Id"],
                Length1 = reader["Length1"].ToString(),
                Length2 = reader["Length2"].ToString(),
                Length3 = reader["Length3"].ToString(),
                Length4 = reader["Length4"].ToString(),
                Length5 = reader["Length5"].ToString(),
                Gothan1 = reader["Gothan1"].ToString(),
                Gothan2 = reader["Gothan2"].ToString(),
                Gothan3 = reader["Gothan3"].ToString(),
                Gothan4 = reader["Gothan4"].ToString(),
                Gothan5 = reader["Gothan5"].ToString(),
                Jangh1 = reader["Jangh1"].ToString(),
                Jangh2 = reader["Jangh2"].ToString(),
                Jangh3 = reader["Jangh3"].ToString(),
                Jangh4 = reader["Jangh4"].ToString(),
                Jangh5 = reader["Jangh5"].ToString(),
                Jolo1 = reader["Jolo1"].ToString(),
                Jolo2 = reader["Jolo2"].ToString(),
                Jolo3 = reader["Jolo3"].ToString(),
                Jolo4 = reader["Jolo4"].ToString(),
                Jolo5 = reader["Jolo5"].ToString(),
                Kamar1 = reader["Kamar1"].ToString(),
                Kamar2 = reader["Kamar2"].ToString(),
                Kamar3 = reader["Kamar3"].ToString(),
                Kamar4 = reader["Kamar4"].ToString(),
                Kamar5 = reader["Kamar5"].ToString(),
                Moli1 = reader["Moli1"].ToString(),
                Moli2 = reader["Moli2"].ToString(),
                Moli3 = reader["Moli3"].ToString(),
                Moli4 = reader["Moli4"].ToString(),
                Moli5 = reader["Moli5"].ToString(),
                Seat1 = reader["Seat1"].ToString(),
                Seat2 = reader["Seat2"].ToString(),
                Seat3 = reader["Seat3"].ToString(),
                Seat4 = reader["Seat4"].ToString(),
                Seat5 = reader["Seat5"].ToString(),
                Notes = reader["Notes"].ToString()
            };
        }

        public Pant GetById(int id)
        {
            Pant pant = null;
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetPantById, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                             pant = GetPantFromReader(reader);
                        }
                    }
                }
            }
            return pant;
        }

        public Pant GetByCustomerId(int customerId)
        {
            Pant pant = null;
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetPantByCustomerId, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pant = GetPantFromReader(reader);
                        }
                    }
                }
            }
            return pant;
        }

        public Pant Insert(Pant pant)
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spSavePant, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", pant.Customer.Id);  
                    command.Parameters.AddWithValue($"@Gothan1", pant.Gothan1);
                    command.Parameters.AddWithValue($"@Jangh1", pant.Jangh1);
                    command.Parameters.AddWithValue($"@Jolo1", pant.Jolo1);
                    command.Parameters.AddWithValue($"@Kamar1", pant.Kamar1);
                    command.Parameters.AddWithValue($"@Length1", pant.Length1);
                    command.Parameters.AddWithValue($"@Moli1", pant.Moli1);
                    command.Parameters.AddWithValue($"@Seat1", pant.Seat1);
                    command.Parameters.AddWithValue($"@Gothan2", pant.Gothan2);
                    command.Parameters.AddWithValue($"@Jangh2", pant.Jangh2);
                    command.Parameters.AddWithValue($"@Jolo2", pant.Jolo2);
                    command.Parameters.AddWithValue($"@Kamar2", pant.Kamar2);
                    command.Parameters.AddWithValue($"@Length2", pant.Length2);
                    command.Parameters.AddWithValue($"@Moli2", pant.Moli2);
                    command.Parameters.AddWithValue($"@Seat2", pant.Seat2);
                    command.Parameters.AddWithValue($"@Gothan3", pant.Gothan3);
                    command.Parameters.AddWithValue($"@Jangh3", pant.Jangh3);
                    command.Parameters.AddWithValue($"@Jolo3", pant.Jolo3);
                    command.Parameters.AddWithValue($"@Kamar3", pant.Kamar3);
                    command.Parameters.AddWithValue($"@Length3", pant.Length3);
                    command.Parameters.AddWithValue($"@Moli3", pant.Moli3);
                    command.Parameters.AddWithValue($"@Seat3", pant.Seat3);
                    command.Parameters.AddWithValue($"@Gothan4", pant.Gothan4);
                    command.Parameters.AddWithValue($"@Jangh4", pant.Jangh4);
                    command.Parameters.AddWithValue($"@Jolo4", pant.Jolo4);
                    command.Parameters.AddWithValue($"@Kamar4", pant.Kamar4);
                    command.Parameters.AddWithValue($"@Length4", pant.Length4);
                    command.Parameters.AddWithValue($"@Moli4", pant.Moli4);
                    command.Parameters.AddWithValue($"@Seat4", pant.Seat4);
                    command.Parameters.AddWithValue($"@Gothan5", pant.Gothan5);
                    command.Parameters.AddWithValue($"@Jangh5", pant.Jangh5);
                    command.Parameters.AddWithValue($"@Jolo5", pant.Jolo5);
                    command.Parameters.AddWithValue($"@Kamar5", pant.Kamar5);
                    command.Parameters.AddWithValue($"@Length5", pant.Length5);
                    command.Parameters.AddWithValue($"@Moli5", pant.Moli5);
                    command.Parameters.AddWithValue($"@Seat5", pant.Seat5);
                    command.Parameters.AddWithValue("@Notes", pant.Notes);
                    command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.ExecuteNonQuery();

                    int insertedId = (int)command.Parameters["@Id"].Value;
                    pant.Id = insertedId;
                }
            }
            return pant;
        }

        public void Update(Pant pant)
        {

            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spUpdatePant, connection))
                {
                    command.Parameters.AddWithValue("@Id", pant.Id);
                    command.Parameters.AddWithValue("@CustomerId", pant.Customer.Id);
                    command.Parameters.AddWithValue($"@Gothan1", pant.Gothan1);
                    command.Parameters.AddWithValue($"@Jangh1", pant.Jangh1);
                    command.Parameters.AddWithValue($"@Jolo1", pant.Jolo1);
                    command.Parameters.AddWithValue($"@Kamar1", pant.Kamar1);
                    command.Parameters.AddWithValue($"@Length1", pant.Length1);
                    command.Parameters.AddWithValue($"@Moli1", pant.Moli1);
                    command.Parameters.AddWithValue($"@Seat1", pant.Seat1);
                    command.Parameters.AddWithValue($"@Gothan2", pant.Gothan2);
                    command.Parameters.AddWithValue($"@Jangh2", pant.Jangh2);
                    command.Parameters.AddWithValue($"@Jolo2", pant.Jolo2);
                    command.Parameters.AddWithValue($"@Kamar2", pant.Kamar2);
                    command.Parameters.AddWithValue($"@Length2", pant.Length2);
                    command.Parameters.AddWithValue($"@Moli2", pant.Moli2);
                    command.Parameters.AddWithValue($"@Seat2", pant.Seat2);
                    command.Parameters.AddWithValue($"@Gothan3", pant.Gothan3);
                    command.Parameters.AddWithValue($"@Jangh3", pant.Jangh3);
                    command.Parameters.AddWithValue($"@Jolo3", pant.Jolo3);
                    command.Parameters.AddWithValue($"@Kamar3", pant.Kamar3);
                    command.Parameters.AddWithValue($"@Length3", pant.Length3);
                    command.Parameters.AddWithValue($"@Moli3", pant.Moli3);
                    command.Parameters.AddWithValue($"@Seat3", pant.Seat3);
                    command.Parameters.AddWithValue($"@Gothan4", pant.Gothan4);
                    command.Parameters.AddWithValue($"@Jangh4", pant.Jangh4);
                    command.Parameters.AddWithValue($"@Jolo4", pant.Jolo4);
                    command.Parameters.AddWithValue($"@Kamar4", pant.Kamar4);
                    command.Parameters.AddWithValue($"@Length4", pant.Length4);
                    command.Parameters.AddWithValue($"@Moli4", pant.Moli4);
                    command.Parameters.AddWithValue($"@Seat4", pant.Seat4);
                    command.Parameters.AddWithValue($"@Gothan5", pant.Gothan5);
                    command.Parameters.AddWithValue($"@Jangh5", pant.Jangh5);
                    command.Parameters.AddWithValue($"@Jolo5", pant.Jolo5);
                    command.Parameters.AddWithValue($"@Kamar5", pant.Kamar5);
                    command.Parameters.AddWithValue($"@Length5", pant.Length5);
                    command.Parameters.AddWithValue($"@Moli5", pant.Moli5);
                    command.Parameters.AddWithValue($"@Seat5", pant.Seat5);
                    command.Parameters.AddWithValue("@Notes", pant.Notes);
                    
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spDeletePantById, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.CommandType = CommandType.StoredProcedure; 
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
