using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TailorManagementModels;

namespace TailorManagementDB
{

    public class ShirtConfigurationRepository : IRepository<ShirtConfiguration>
    {
        private readonly string _connectionString;
        private const string spGetShirtConfigurations = "spGetShirtConfigurations";
        private const string spGetShirtConfigurationById = "spGetShirtConfigurationById";
        private const string spSaveShirtConfiguration = "spSaveShirtConfiguration";
        private const string spUpdateShirtConfiguration = "spUpdateShirtConfiguration";
        private const string spDeleteShirtConfigurationById = "spDeleteShirtConfigurationById";

        public ShirtConfigurationRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TailorManagementDB"].ConnectionString; ;
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<ShirtConfiguration> GetAll()
        {
            List<ShirtConfiguration> shirtConfigurations = new List<ShirtConfiguration>();
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetShirtConfigurations, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ShirtConfiguration shirtConfiguration = new ShirtConfiguration
                            {
                                Id = (int)reader["Id"],
                                Description = reader["Description"].ToString(),
                                LocalDescription = reader["LocalDescription"].ToString()
                            };
                            shirtConfigurations.Add(shirtConfiguration);
                        }
                    }
                }
            }
            return shirtConfigurations;
        }

        public ShirtConfiguration GetById(int id)
        {
            ShirtConfiguration shirtConfiguration = null;
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetShirtConfigurationById, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            shirtConfiguration = new ShirtConfiguration
                            {
                                Id = (int)reader["Id"],
                                Description = reader["Description"].ToString(),
                                LocalDescription = reader["LocalDescription"].ToString()
                            };
                        }
                    }
                }
            }
            return shirtConfiguration;
        }

        public ShirtConfiguration Insert(ShirtConfiguration shirtConfiguration)
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spSaveShirtConfiguration, connection))
                {
                    command.Parameters.AddWithValue("@Description", shirtConfiguration.Description);                    
                    command.Parameters.AddWithValue("@LocalDescription", shirtConfiguration.LocalDescription);
                    command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.ExecuteNonQuery();

                    int insertedId = (int)command.Parameters["@Id"].Value;
                    shirtConfiguration.Id = insertedId;
                }
            }
            return shirtConfiguration;
        }

        public void Update(ShirtConfiguration shirtConfiguration)
        {

            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spUpdateShirtConfiguration, connection))
                {
                    command.Parameters.AddWithValue("@Id", shirtConfiguration.Id);
                    command.Parameters.AddWithValue("@Description", shirtConfiguration.Description);
                    command.Parameters.AddWithValue("@LocalDescription", shirtConfiguration.LocalDescription);

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
                using (var command = new SqlCommand(spDeleteShirtConfigurationById, connection))
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
