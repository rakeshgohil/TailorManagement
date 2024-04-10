using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TailorManagementModels;

namespace TailorManagementDB
{

    public class PantConfigurationRepository : IRepository<PantConfiguration>
    {
        private readonly string _connectionString;
        private const string spGetPantConfigurations = "spGetPantConfigurations";
        private const string spGetPantConfigurationById = "spGetPantConfigurationById";
        private const string spSavePantConfiguration = "spSavePantConfiguration";
        private const string spUpdatePantConfiguration = "spUpdatePantConfiguration";
        private const string spDeletePantConfigurationById = "spDeletePantConfigurationById";

        public PantConfigurationRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TailorManagementDB"].ConnectionString; ;
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<PantConfiguration> GetAll()
        {
            List<PantConfiguration> pantConfigurations = new List<PantConfiguration>();
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetPantConfigurations, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PantConfiguration pantConfiguration = new PantConfiguration
                            {
                                Id = (int)reader["Id"],
                                Description = reader["Description"].ToString(),
                                LocalDescription = reader["LocalDescription"].ToString()
                            };
                            pantConfigurations.Add(pantConfiguration);
                        }
                    }
                }
            }
            return pantConfigurations;
        }

        public PantConfiguration GetById(int id)
        {
            PantConfiguration pantConfiguration = null;
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetPantConfigurationById, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pantConfiguration = new PantConfiguration
                            {
                                Id = (int)reader["Id"],
                                Description = reader["Description"].ToString(),
                                LocalDescription = reader["LocalDescription"].ToString()
                            };
                        }
                    }
                }
            }
            return pantConfiguration;
        }

        public PantConfiguration Insert(PantConfiguration pantConfiguration)
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spSavePantConfiguration, connection))
                {
                    command.Parameters.AddWithValue("@Description", pantConfiguration.Description);                    
                    command.Parameters.AddWithValue("@LocalDescription", pantConfiguration.LocalDescription);
                    command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.ExecuteNonQuery();

                    int insertedId = (int)command.Parameters["@Id"].Value;
                    pantConfiguration.Id = insertedId;
                }
            }
            return pantConfiguration;
        }

        public void Update(PantConfiguration pantConfiguration)
        {

            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spUpdatePantConfiguration, connection))
                {
                    command.Parameters.AddWithValue("@Id", pantConfiguration.Id);
                    command.Parameters.AddWithValue("@Description", pantConfiguration.Description);
                    command.Parameters.AddWithValue("@LocalDescription", pantConfiguration.LocalDescription);

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
                using (var command = new SqlCommand(spDeletePantConfigurationById, connection))
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
