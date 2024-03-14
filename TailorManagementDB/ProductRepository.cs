using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TailorManagementModels;

namespace TailorManagementDB
{

    public class ProductRepository : IRepository<Product>
    {
        private readonly string _connectionString;
        private const string spGetProducts = "spGetProducts";
        private const string spGetProductById = "spGetProductById";
        private const string spSaveProduct = "spSaveProduct";
        private const string spUpdateProduct = "spUpdateProduct";
        private const string spDeleteProductById = "spDeleteProductById";

        public ProductRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TailorManagementDB"].ConnectionString; ;
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetProducts, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                Id = (int)reader["Id"],
                                Price = (decimal)reader["Price"],
                                Name = reader["Name"].ToString()
                            };
                            products.Add(product);
                        }
                    }
                }
            }
            return products;
        }

        public Product GetById(int id)
        {
            Product product = null;
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetProductById, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Price = (decimal)reader["Price"]
                            };
                        }
                    }
                }
            }
            return product;
        }

        public int Insert(Product product)
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spSaveProduct, connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);                    
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.ExecuteNonQuery();

                    int insertedId = (int)command.Parameters["@Id"].Value;
                    product.Id = insertedId;
                }
            }
            return product.Id;
        }

        public void Update(Product product)
        {

            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spUpdateProduct, connection))
                {
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);

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
                using (var command = new SqlCommand(spDeleteProductById, connection))
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
