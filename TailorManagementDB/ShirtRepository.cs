using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using TailorManagementModels;

namespace TailorManagementDB
{

    public class ShirtRepository : IRepository<Shirt>
    {
        private readonly string _connectionString;
        private const string spGetShirts = "spGetShirts";
        private const string spGetShirtById = "spGetShirtById";
        private const string spSaveShirt = "spSaveShirt";
        private const string spUpdateShirt = "spUpdateShirt";

        public ShirtRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TailorManagementDB"].ConnectionString; ;
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<Shirt> GetAll()
        {
            List<Shirt> shirts = new List<Shirt>();
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetShirts, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Shirt shirt = new Shirt
                            {
                                Id = (int)reader["Id"],
                                CustomerId = (int)reader["CustomerId"],
                                Length1 = reader["Length1"].ToString(),
                                Length2 = reader["Length2"].ToString(),
                                Length3 = reader["Length3"].ToString(),
                                Length4 = reader["Length4"].ToString(),
                                Length5 = reader["Length5"].ToString(),
                                Chati1 = reader["Chati1"].ToString(),
                                Chati2 = reader["Chati2"].ToString(),
                                Chati3 = reader["Chati3"].ToString(),
                                Chati4 = reader["Chati4"].ToString(),
                                Chati5 = reader["Chati5"].ToString(),
                                Solder1 = reader["Solder1"].ToString(),
                                Solder2 = reader["Solder2"].ToString(),
                                Solder3 = reader["Solder3"].ToString(),
                                Solder4 = reader["Solder4"].ToString(),
                                Solder5 = reader["Solder5"].ToString(),
                                Bye1 = reader["Bye1"].ToString(),
                                Bye2 = reader["Bye2"].ToString(),
                                Bye3 = reader["Bye3"].ToString(),
                                Bye4 = reader["Bye4"].ToString(),
                                Bye5 = reader["Bye5"].ToString(),
                                Front1 = reader["Front1"].ToString(),
                                Front2 = reader["Front2"].ToString(),
                                Front3 = reader["Front3"].ToString(),
                                Front4 = reader["Front4"].ToString(),
                                Front5 = reader["Front5"].ToString(),
                                Kolor1 = reader["Kolor1"].ToString(),
                                Kolor2 = reader["Kolor2"].ToString(),
                                Kolor3 = reader["Kolor3"].ToString(),
                                Kolor4 = reader["Kolor4"].ToString(),
                                Kolor5 = reader["Kolor5"].ToString(),
                                Cuff1 = reader["Cuff1"].ToString(),
                                Cuff2 = reader["Cuff2"].ToString(),
                                Cuff3 = reader["Cuff3"].ToString(),
                                Cuff4 = reader["Cuff4"].ToString(),
                                Cuff5 = reader["Cuff5"].ToString(),
                                Notes = reader["Notes"].ToString()
                            };
                            shirts.Add(shirt);
                        }
                    }
                }
            }
            return shirts;
        }

        public Shirt GetById(int id)
        {
            Shirt shirt = null;
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetShirtById, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                             shirt = new Shirt
                            {
                                Id = (int)reader["Id"],
                                CustomerId = (int)reader["CustomerId"],
                                Length1 = reader["Length1"].ToString(),
                                Length2 = reader["Length2"].ToString(),
                                Length3 = reader["Length3"].ToString(),
                                Length4 = reader["Length4"].ToString(),
                                Length5 = reader["Length5"].ToString(),
                                Chati1 = reader["Chati1"].ToString(),
                                Chati2 = reader["Chati2"].ToString(),
                                Chati3 = reader["Chati3"].ToString(),
                                Chati4 = reader["Chati4"].ToString(),
                                Chati5 = reader["Chati5"].ToString(),
                                Solder1 = reader["Solder1"].ToString(),
                                Solder2 = reader["Solder2"].ToString(),
                                Solder3 = reader["Solder3"].ToString(),
                                Solder4 = reader["Solder4"].ToString(),
                                Solder5 = reader["Solder5"].ToString(),
                                Bye1 = reader["Bye1"].ToString(),
                                Bye2 = reader["Bye2"].ToString(),
                                Bye3 = reader["Bye3"].ToString(),
                                Bye4 = reader["Bye4"].ToString(),
                                Bye5 = reader["Bye5"].ToString(),
                                Front1 = reader["Front1"].ToString(),
                                Front2 = reader["Front2"].ToString(),
                                Front3 = reader["Front3"].ToString(),
                                Front4 = reader["Front4"].ToString(),
                                Front5 = reader["Front5"].ToString(),
                                Kolor1 = reader["Kolor1"].ToString(),
                                Kolor2 = reader["Kolor2"].ToString(),
                                Kolor3 = reader["Kolor3"].ToString(),
                                Kolor4 = reader["Kolor4"].ToString(),
                                Kolor5 = reader["Kolor5"].ToString(),
                                Cuff1 = reader["Cuff1"].ToString(),
                                Cuff2 = reader["Cuff2"].ToString(),
                                Cuff3 = reader["Cuff3"].ToString(),
                                Cuff4 = reader["Cuff4"].ToString(),
                                Cuff5 = reader["Cuff5"].ToString(),
                                Notes = reader["Notes"].ToString()
                            };
                        }
                    }
                }
            }
            return shirt;
        }

        public int Insert(Shirt shirt)
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spSaveShirt, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", shirt.CustomerId);                    
                    command.Parameters.AddWithValue($"@Length1", shirt.Length1);
                    command.Parameters.AddWithValue($"@Chati1", shirt.Chati1);
                    command.Parameters.AddWithValue($"@Solder1", shirt.Solder1);
                    command.Parameters.AddWithValue($"@Bye1", shirt.Bye1);
                    command.Parameters.AddWithValue($"@Front1", shirt.Front1);
                    command.Parameters.AddWithValue($"@Kolor1", shirt.Kolor1);
                    command.Parameters.AddWithValue($"@Cuff1", shirt.Cuff1);
                    command.Parameters.AddWithValue($"@Length2", shirt.Length2);
                    command.Parameters.AddWithValue($"@Chati2", shirt.Chati2);
                    command.Parameters.AddWithValue($"@Solder2", shirt.Solder2);
                    command.Parameters.AddWithValue($"@Bye2", shirt.Bye2);
                    command.Parameters.AddWithValue($"@Front2", shirt.Front2);
                    command.Parameters.AddWithValue($"@Kolor2", shirt.Kolor2);
                    command.Parameters.AddWithValue($"@Cuff2", shirt.Cuff2);
                    command.Parameters.AddWithValue($"@Length3", shirt.Length3);
                    command.Parameters.AddWithValue($"@Chati3", shirt.Chati3);
                    command.Parameters.AddWithValue($"@Solder3", shirt.Solder3);
                    command.Parameters.AddWithValue($"@Bye3", shirt.Bye3);
                    command.Parameters.AddWithValue($"@Front3", shirt.Front3);
                    command.Parameters.AddWithValue($"@Kolor3", shirt.Kolor3);
                    command.Parameters.AddWithValue($"@Cuff3", shirt.Cuff3);
                    command.Parameters.AddWithValue($"@Length4", shirt.Length4);
                    command.Parameters.AddWithValue($"@Chati4", shirt.Chati4);
                    command.Parameters.AddWithValue($"@Solder4", shirt.Solder4);
                    command.Parameters.AddWithValue($"@Bye4", shirt.Bye4);
                    command.Parameters.AddWithValue($"@Front4", shirt.Front4);
                    command.Parameters.AddWithValue($"@Kolor4", shirt.Kolor4);
                    command.Parameters.AddWithValue($"@Cuff4", shirt.Cuff4);
                    command.Parameters.AddWithValue($"@Length5", shirt.Length5);
                    command.Parameters.AddWithValue($"@Chati5", shirt.Chati5);
                    command.Parameters.AddWithValue($"@Solder5", shirt.Solder5);
                    command.Parameters.AddWithValue($"@Bye5", shirt.Bye5);
                    command.Parameters.AddWithValue($"@Front5", shirt.Front5);
                    command.Parameters.AddWithValue($"@Kolor5", shirt.Kolor5);
                    command.Parameters.AddWithValue($"@Cuff5", shirt.Cuff5);
                    command.Parameters.AddWithValue("@Notes", shirt.Notes);
                    command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    int insertedId = (int)command.Parameters["@Id"].Value;
                    shirt.Id = insertedId;
                }
            }
            return shirt.Id;
        }

        public void Update(Shirt shirt)
        {

            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spUpdateShirt, connection))
                {
                    command.Parameters.AddWithValue("@Id", shirt.Id);
                    command.Parameters.AddWithValue("@CustomerId", shirt.CustomerId);
                    command.Parameters.AddWithValue($"@Length1", shirt.Length1);
                    command.Parameters.AddWithValue($"@Chati1", shirt.Chati1);
                    command.Parameters.AddWithValue($"@Solder1", shirt.Solder1);
                    command.Parameters.AddWithValue($"@Bye1", shirt.Bye1);
                    command.Parameters.AddWithValue($"@Front1", shirt.Front1);
                    command.Parameters.AddWithValue($"@Kolor1", shirt.Kolor1);
                    command.Parameters.AddWithValue($"@Cuff1", shirt.Cuff1);
                    command.Parameters.AddWithValue($"@Length2", shirt.Length2);
                    command.Parameters.AddWithValue($"@Chati2", shirt.Chati2);
                    command.Parameters.AddWithValue($"@Solder2", shirt.Solder2);
                    command.Parameters.AddWithValue($"@Bye2", shirt.Bye2);
                    command.Parameters.AddWithValue($"@Front2", shirt.Front2);
                    command.Parameters.AddWithValue($"@Kolor2", shirt.Kolor2);
                    command.Parameters.AddWithValue($"@Cuff2", shirt.Cuff2);
                    command.Parameters.AddWithValue($"@Length3", shirt.Length3);
                    command.Parameters.AddWithValue($"@Chati3", shirt.Chati3);
                    command.Parameters.AddWithValue($"@Solder3", shirt.Solder3);
                    command.Parameters.AddWithValue($"@Bye3", shirt.Bye3);
                    command.Parameters.AddWithValue($"@Front3", shirt.Front3);
                    command.Parameters.AddWithValue($"@Kolor3", shirt.Kolor3);
                    command.Parameters.AddWithValue($"@Cuff3", shirt.Cuff3);
                    command.Parameters.AddWithValue($"@Length4", shirt.Length4);
                    command.Parameters.AddWithValue($"@Chati4", shirt.Chati4);
                    command.Parameters.AddWithValue($"@Solder4", shirt.Solder4);
                    command.Parameters.AddWithValue($"@Bye4", shirt.Bye4);
                    command.Parameters.AddWithValue($"@Front4", shirt.Front4);
                    command.Parameters.AddWithValue($"@Kolor4", shirt.Kolor4);
                    command.Parameters.AddWithValue($"@Cuff4", shirt.Cuff4);
                    command.Parameters.AddWithValue($"@Length5", shirt.Length5);
                    command.Parameters.AddWithValue($"@Chati5", shirt.Chati5);
                    command.Parameters.AddWithValue($"@Solder5", shirt.Solder5);
                    command.Parameters.AddWithValue($"@Bye5", shirt.Bye5);
                    command.Parameters.AddWithValue($"@Front5", shirt.Front5);
                    command.Parameters.AddWithValue($"@Kolor5", shirt.Kolor5);
                    command.Parameters.AddWithValue($"@Cuff5", shirt.Cuff5);
                    command.Parameters.AddWithValue("@Notes", shirt.Notes);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = GetSqlConnection())
            {
                string query = "DELETE FROM tbShirt WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
