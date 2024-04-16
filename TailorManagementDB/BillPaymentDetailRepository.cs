using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TailorManagementModels;

namespace TailorManagementDB
{

    public class BillPaymentDetailRepository : IRepository<BillPaymentDetail>
    {
        private readonly string _connectionString;
        private const string spGetBillPaymentDetails = "spGetBillPaymentDetails";
        private const string spGetBillPaymentDetailById = "spGetBillPaymentDetailById";
        private const string spSaveBillPaymentDetail = "spSaveBillPaymentDetail";
        private const string spUpdateBillPaymentDetail = "spUpdateBillPaymentDetail";
        private const string spDeleteBillPaymentDetailById = "spDeleteBillPaymentDetailById";

        public BillPaymentDetailRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TailorManagementDB"].ConnectionString; ;
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<BillPaymentDetail> GetAll()
        {
            List<BillPaymentDetail> billPaymentDetails = new List<BillPaymentDetail>();
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetBillPaymentDetails, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BillPaymentDetail billPaymentDetail = new BillPaymentDetail
                            {
                                Id = (int)reader["Id"],
                                PaidAmount = (decimal)reader["PaidAmount"],
                                BillId = (int)reader["BillId"]
                            };
                            billPaymentDetails.Add(billPaymentDetail);
                        }
                    }
                }
            }
            return billPaymentDetails;
        }

        public BillPaymentDetail GetById(int id)
        {
            BillPaymentDetail billPaymentDetail = null;
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetBillPaymentDetailById, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            billPaymentDetail = new BillPaymentDetail
                            {
                                Id = (int)reader["Id"],
                                BillId = (int)reader["BillId"],
                                PaidAmount = (decimal)reader["PaidAmount"]
                            };
                        }
                    }
                }
            }
            return billPaymentDetail;
        }

        public BillPaymentDetail Insert(BillPaymentDetail billPaymentDetail)
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spSaveBillPaymentDetail, connection))
                {
                    command.Parameters.AddWithValue("@BillId", billPaymentDetail.BillId);                    
                    command.Parameters.AddWithValue("@PaidAmount", billPaymentDetail.PaidAmount);
                    command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.ExecuteNonQuery();

                    int insertedId = (int)command.Parameters["@Id"].Value;
                    billPaymentDetail.Id = insertedId;
                }
            }
            return billPaymentDetail;
        }

        public void Update(BillPaymentDetail billPaymentDetail)
        {

            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spUpdateBillPaymentDetail, connection))
                {
                    command.Parameters.AddWithValue("@Id", billPaymentDetail.Id);
                    command.Parameters.AddWithValue("@BillId", billPaymentDetail.BillId);
                    command.Parameters.AddWithValue("@PaidAmount", billPaymentDetail.PaidAmount);

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
                using (var command = new SqlCommand(spDeleteBillPaymentDetailById, connection))
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
