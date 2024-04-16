using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TailorManagementModels;

namespace TailorManagementDB
{

    public class CompanyConfigurationRepository : IRepository<CompanyConfiguration>
    {
        private readonly string _connectionString;
        private const string spGetCompanyConfigurations = "spGetCompanyConfigurations";
        private const string spGetCompanyConfigurationById = "spGetCompanyConfigurationById";
        private const string spSaveCompanyConfiguration = "spSaveCompanyConfiguration";
        private const string spUpdateCompanyConfiguration = "spUpdateCompanyConfiguration";
        private const string spDeleteCompanyConfigurationById = "spDeleteCompanyConfigurationById";

        public CompanyConfigurationRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TailorManagementDB"].ConnectionString; ;
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<CompanyConfiguration> GetAll()
        {
            List<CompanyConfiguration> companyConfigurations = new List<CompanyConfiguration>();
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetCompanyConfigurations, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CompanyConfiguration companyConfiguration = new CompanyConfiguration
                            {
                                Id = (int)reader["Id"],
                                ConfigKey = reader["ConfigKey"].ToString(),
                                ConfigValue = reader["ConfigValue"].ToString()
                            };
                            companyConfigurations.Add(companyConfiguration);
                        }
                    }
                }
            }
            return companyConfigurations;
        }

        public CompanyConfiguration GetById(int id)
        {
            CompanyConfiguration companyConfiguration = null;
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetCompanyConfigurationById, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            companyConfiguration = new CompanyConfiguration
                            {
                                Id = (int)reader["Id"],
                                ConfigKey = reader["ConfigKey"].ToString(),
                                ConfigValue = reader["ConfigValue"].ToString()
                            };
                        }
                    }
                }
            }
            return companyConfiguration;
        }

        public CompanyConfiguration Insert(CompanyConfiguration companyConfiguration)
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spSaveCompanyConfiguration, connection))
                {
                    command.Parameters.AddWithValue("@ConfigKey", companyConfiguration.ConfigKey);                    
                    command.Parameters.AddWithValue("@ConfigValue", companyConfiguration.ConfigValue);
                    command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.ExecuteNonQuery();

                    int insertedId = (int)command.Parameters["@Id"].Value;
                    companyConfiguration.Id = insertedId;
                }
            }
            return companyConfiguration;
        }

        public void Update(CompanyConfiguration companyConfiguration)
        {

            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spUpdateCompanyConfiguration, connection))
                {
                    command.Parameters.AddWithValue("@Id", companyConfiguration.Id);
                    command.Parameters.AddWithValue("@ConfigKey", companyConfiguration.ConfigKey);
                    command.Parameters.AddWithValue("@ConfigValue", companyConfiguration.ConfigValue);

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
                using (var command = new SqlCommand(spDeleteCompanyConfigurationById, connection))
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
