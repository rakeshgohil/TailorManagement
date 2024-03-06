using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using TailorManagementModels;

namespace TailorManagementDB
{

    public class ShirtRepository : IRepository<Shirt>
    {
        private readonly string _connectionString;

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
                string query = "SELECT Id, Length, Chest FROM tbShirt";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Shirt shirt = new Shirt
                            {
                                Id = (int)reader["Id"],
                                Length = reader["Length"].ToString(),
                                Chest = reader["Chest"].ToString()
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
                string query = "SELECT Id, Length, Chest FROM tbShirt WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
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
                                Length = reader["Length"].ToString(),
                                Chest = reader["Chest"].ToString()
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
                string query = "INSERT INTO tbShirt (Length, Chest) VALUES (@Length, @Chest); SELECT SCOPE_IDENTITY()";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Length", shirt.Length);
                    command.Parameters.AddWithValue("@Chest", shirt.Chest);
                    connection.Open();
                    int insertedId = Convert.ToInt32(command.ExecuteScalar());
                    shirt.Id = insertedId;
                }
            }
            return shirt.Id;
        }

        public void Update(Shirt shirt)
        {
            using (var connection = GetSqlConnection())
            {
                string query = "UPDATE tbShirt SET Length = @Length, Chest = @Chest WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Length", shirt.Length);
                    command.Parameters.AddWithValue("@Chest", shirt.Chest);
                    command.Parameters.AddWithValue("@Id", shirt.Id);
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
