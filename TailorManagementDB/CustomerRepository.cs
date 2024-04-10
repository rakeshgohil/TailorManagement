using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TailorManagementModels;

namespace TailorManagementDB
{

    public class CustomerRepository : IRepository<Customer>
    {
        private readonly string _connectionString;
        private const string spGetCustomers = "spGetCustomers";
        private const string spGetCustomerById = "spGetCustomerById";
        private const string spSaveCustomer = "spSaveCustomer";
        private const string spUpdateCustomer = "spUpdateCustomer";
        private const string spDeleteCustomerById = "spDeleteCustomerById";
        private const string spGetCustomerByMobile = "spGetCustomerByMobile";

        public CustomerRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TailorManagementDB"].ConnectionString; ;
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetCustomers, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Mobile = reader["Mobile"].ToString()
                            };
                            customers.Add(customer);
                        }
                    }
                }
            }
            return customers;
        }

        public Customer GetById(int id)
        {
            Customer customer = null;
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetCustomerById, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Mobile = reader["Mobile"].ToString()
                            };
                        }
                    }
                }
            }
            return customer;
        }

        public Customer GetByMobileNo(string mobile)
        {
            Customer customer = null;
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetCustomerByMobile, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Mobile", mobile);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Mobile = reader["Mobile"].ToString()
                            };
                        }
                    }
                }
            }
            return customer;
        }

        public Customer Insert(Customer customer)
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spSaveCustomer, connection))
                {
                    command.Parameters.AddWithValue("@Name", customer.Name);                    
                    command.Parameters.AddWithValue("@Mobile", customer.Mobile);
                    command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.ExecuteNonQuery();

                    int insertedId = (int)command.Parameters["@Id"].Value;
                    customer.Id = insertedId;
                }
            }
            return customer;
        }

        public void Update(Customer customer)
        {

            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spUpdateCustomer, connection))
                {
                    command.Parameters.AddWithValue("@Id", customer.Id);
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Mobile", customer.Mobile);

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
                using (var command = new SqlCommand(spDeleteCustomerById, connection))
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
