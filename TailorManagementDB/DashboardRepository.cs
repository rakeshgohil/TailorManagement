using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TailorManagementModels;

namespace TailorManagementDB
{

    public class DashboardRepository
    {
        private readonly string _connectionString;
        private const string spGetDeliveryDues = "spGetDeliveryDues";
        private const string spGetPaymentDues = "spGetPaymentDues";

        public DashboardRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TailorManagementDB"].ConnectionString; ;
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<DashboardModel> GetDeliveryDues(int deliveryDueDays = 1)
        {
            List<DashboardModel> deliveryDues = new List<DashboardModel>();
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetDeliveryDues, connection))
                {
                    command.Parameters.AddWithValue("@DelDueDays", deliveryDueDays);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DashboardModel deliveryDue = new DashboardModel
                            {
                                BillDate = Convert.ToDateTime(reader["BillDate"]),
                                BillId = Convert.ToInt32(reader["BillId"]),
                                BillNo = Convert.ToInt32(reader["BillNo"]),
                                CustomerMobile = reader["Mobile"].ToString(),
                                CustomerName = reader["Name"].ToString(),
                                DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"]),
                                DueAmount = Convert.ToDecimal(reader["DueAmount"]),
                                PaidAmount = Convert.ToDecimal(reader["PaidAmount"]),
                                TotalAmount = Convert.ToDecimal(reader["TotalAmount"])
                            };
                            deliveryDues.Add(deliveryDue);
                        }
                    }
                }
            }
            return deliveryDues;
        }

        public List<DashboardModel> GetPaymentDues(int payDueDays = 30)
        {
            List<DashboardModel> paymentDues = new List<DashboardModel>();
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetPaymentDues, connection))
                {
                    command.Parameters.AddWithValue("@PayDueDays", payDueDays);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DashboardModel paymentDue = new DashboardModel
                            {
                                BillDate = Convert.ToDateTime(reader["BillDate"]),
                                BillId = Convert.ToInt32(reader["BillId"]),
                                BillNo = Convert.ToInt32(reader["BillNo"]),
                                CustomerMobile = reader["Mobile"].ToString(),
                                CustomerName = reader["Name"].ToString(),
                                DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"]),
                                DueAmount = Convert.ToDecimal(reader["DueAmount"]),
                                PaidAmount = Convert.ToDecimal(reader["PaidAmount"]),
                                TotalAmount = Convert.ToDecimal(reader["TotalAmount"])
                            };
                            paymentDues.Add(paymentDue);
                        }
                    }
                }
            }
            return paymentDues;
        }
    }
}
