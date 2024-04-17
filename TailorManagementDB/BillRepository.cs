using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TailorManagementModels;

namespace TailorManagementDB
{

    public class BillRepository : IRepository<Bill>
    {
        private readonly string _connectionString;
        private const string spGetBills = "spGetBills";
        private const string spGetBillById = "spGetBillById";
        //private const string spSaveBill = "spSaveBill";
        private const string spUpdateBill = "spUpdateBill";
        private const string spDeleteBillById = "spDeleteBillById";
        private const string spSaveBillFromUI = "spSaveBillFromUI";
        private const string spGetBillDetailsByBillId = "spGetBillDetailsByBillId";

        public BillRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TailorManagementDB"].ConnectionString; ;
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<Bill> GetAll()
        {
            List<Bill> bills = new List<Bill>();
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetBills, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Bill bill = new Bill
                            {
                                Id = (int)reader["Id"],
                                BillDate = (DateTime)reader["BillDate"],
                                BillNo = (int)reader["BillNo"],
                                DeliveryDate = (DateTime)reader["DeliveryDate"],
                                ExtraCost = (decimal)reader["ExtraCost"],
                                Discount = (decimal)reader["Discount"],
                                PaidAmount = (decimal)reader["PaidAmount"],
                                TotalAmount = (decimal)reader["TotalAmount"],
                                TrialDate = (DateTime)reader["TrialDate"],
                                Customer = new Customer()
                                {
                                    Id = (int)reader["CustomerId"],
                                    Mobile = reader["Mobile"].ToString(),
                                    Name = reader["Name"].ToString(),
                                },
                                Pant = new Pant
                                {
                                    Id = (int)reader["PantId"],
                                    Customer = new Customer()
                                    {
                                        Id = (int)reader["CustomerId"],
                                        Mobile = reader["Mobile"].ToString(),
                                        Name = reader["Name"].ToString()
                                    },
                                    Length1 = reader["PantLength1"].ToString(),
                                    Length2 = reader["PantLength2"].ToString(),
                                    Length3 = reader["PantLength3"].ToString(),
                                    Length4 = reader["PantLength4"].ToString(),
                                    Length5 = reader["PantLength5"].ToString(),
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
                                    Notes = reader["PantNotes"].ToString()
                                },
                                Shirt = new Shirt
                                {
                                    Id = (int)reader["ShirtId"],
                                    Customer = new Customer()
                                    {
                                        Id = (int)reader["CustomerId"],
                                        Mobile = reader["Mobile"].ToString(),
                                        Name = reader["Name"].ToString()
                                    },
                                    Length1 = reader["ShirtLength1"].ToString(),
                                    Length2 = reader["ShirtLength2"].ToString(),
                                    Length3 = reader["ShirtLength3"].ToString(),
                                    Length4 = reader["ShirtLength4"].ToString(),
                                    Length5 = reader["ShirtLength5"].ToString(),
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
                                    Notes = reader["ShirtNotes"].ToString()
                                },
                        };
                            bills.Add(bill);
                        }
                    }
                }
            }
            return bills;
        }

        public Bill GetById(int id)
        {
            Bill bill = null;
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetBillById, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            bill = new Bill
                            {
                                Id = (int)reader["Id"],
                                BillDate = (DateTime)reader["BillDate"],
                                BillNo = (int)reader["BillNo"],
                                DeliveryDate = (DateTime)reader["DeliveryDate"],
                                ExtraCost = (decimal)reader["ExtraCost"],
                                Discount = (decimal)reader["Discount"],
                                PaidAmount = (decimal)reader["PaidAmount"],
                                TotalAmount = (decimal)reader["TotalAmount"],
                                TrialDate = (DateTime)reader["TrialDate"],
                                Customer = new Customer()
                                {
                                    Id = (int)reader["CustomerId"],
                                    Mobile = reader["Mobile"].ToString(),
                                    Name = reader["Name"].ToString(),
                                },
                                Pant = new Pant
                                {
                                    Id = (int)reader["PantId"],
                                    Customer = new Customer()
                                    {
                                        Id = (int)reader["CustomerId"],
                                        Mobile = reader["Mobile"].ToString(),
                                        Name = reader["Name"].ToString()
                                    },
                                    Length1 = reader["PantLength1"].ToString(),
                                    Length2 = reader["PantLength2"].ToString(),
                                    Length3 = reader["PantLength3"].ToString(),
                                    Length4 = reader["PantLength4"].ToString(),
                                    Length5 = reader["PantLength5"].ToString(),
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
                                    Notes = reader["PantNotes"].ToString()
                                },
                                Shirt = new Shirt
                                {
                                    Id = (int)reader["ShirtId"],
                                    Customer = new Customer()
                                    {
                                        Id = (int)reader["CustomerId"],
                                        Mobile = reader["Mobile"].ToString(),
                                        Name = reader["Name"].ToString()
                                    },
                                    Length1 = reader["ShirtLength1"].ToString(),
                                    Length2 = reader["ShirtLength2"].ToString(),
                                    Length3 = reader["ShirtLength3"].ToString(),
                                    Length4 = reader["ShirtLength4"].ToString(),
                                    Length5 = reader["ShirtLength5"].ToString(),
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
                                    Notes = reader["ShirtNotes"].ToString()
                                },
                            };
                            bill.BillDetails = GetBillDetailsByBillId(id);
                        }
                    }
                }
            }
            return bill;
        }

        private List<BillDetail> GetBillDetailsByBillId(int billId)
        {
            List<BillDetail> billDetails = new List<BillDetail>();
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spGetBillDetailsByBillId, connection))
                {
                    command.Parameters.AddWithValue("@BillId", billId);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BillDetail billDetail = new BillDetail
                            {
                                Id = (int)reader["Id"],
                                Price = Convert.ToDecimal(reader["Price"]),
                                Product = new Product() 
                                    { 
                                        Id = (int) reader["ProductId"], 
                                        Name = reader["ProductName"].ToString(),
                                        Price = Convert.ToDecimal(reader["ProductPrice"])
                                    },
                                BillId = (int)reader["BillId"],
                                Qty = Convert.ToDecimal(reader["Qty"])
                            };
                            billDetails.Add(billDetail);
                        }
                    }
                }
            }
            return billDetails;
        }

        public Bill Insert(Bill bill)
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spSaveBillFromUI, connection))
                {
                    command.Parameters.AddWithValue("@Name", bill.Customer.Name);
                    command.Parameters.AddWithValue("@Mobile", bill.Customer.Mobile);
                    command.Parameters.AddWithValue("@PantLength1", bill.Pant.Length1);
                    command.Parameters.AddWithValue("@PantLength2", bill.Pant.Length2);
                    command.Parameters.AddWithValue("@PantLength3 ", bill.Pant.Length3);
                    command.Parameters.AddWithValue("@PantLength4", bill.Pant.Length4);
                    command.Parameters.AddWithValue("@PantLength5", bill.Pant.Length5);
                    command.Parameters.AddWithValue("@Kamar1", bill.Pant.Kamar1);
                    command.Parameters.AddWithValue("@Kamar2", bill.Pant.Kamar2);
                    command.Parameters.AddWithValue("@Kamar3", bill.Pant.Kamar3);
                    command.Parameters.AddWithValue("@Kamar4", bill.Pant.Kamar4);
                    command.Parameters.AddWithValue("@Kamar5", bill.Pant.Kamar5);
                    command.Parameters.AddWithValue("@Seat1", bill.Pant.Seat1);
                    command.Parameters.AddWithValue("@Seat2", bill.Pant.Seat2);
                    command.Parameters.AddWithValue("@Seat3", bill.Pant.Seat3);
                    command.Parameters.AddWithValue("@Seat4", bill.Pant.Seat4);
                    command.Parameters.AddWithValue("@Seat5", bill.Pant.Seat5);
                    command.Parameters.AddWithValue("@Jangh1", bill.Pant.Jangh1);
                    command.Parameters.AddWithValue("@Jangh2", bill.Pant.Jangh2);
                    command.Parameters.AddWithValue("@Jangh3", bill.Pant.Jangh3);
                    command.Parameters.AddWithValue("@Jangh4", bill.Pant.Jangh4);
                    command.Parameters.AddWithValue("@Jangh5", bill.Pant.Jangh5);
                    command.Parameters.AddWithValue("@Gothan1", bill.Pant.Gothan1);
                    command.Parameters.AddWithValue("@Gothan2", bill.Pant.Gothan2);
                    command.Parameters.AddWithValue("@Gothan3", bill.Pant.Gothan3);
                    command.Parameters.AddWithValue("@Gothan4", bill.Pant.Gothan4);
                    command.Parameters.AddWithValue("@Gothan5", bill.Pant.Gothan5);
                    command.Parameters.AddWithValue("@Jolo1", bill.Pant.Jolo1);
                    command.Parameters.AddWithValue("@Jolo2", bill.Pant.Jolo2);
                    command.Parameters.AddWithValue("@Jolo3", bill.Pant.Jolo3);
                    command.Parameters.AddWithValue("@Jolo4", bill.Pant.Jolo4);
                    command.Parameters.AddWithValue("@Jolo5", bill.Pant.Jolo5);
                    command.Parameters.AddWithValue("@Moli1", bill.Pant.Moli1);
                    command.Parameters.AddWithValue("@Moli2", bill.Pant.Moli2);
                    command.Parameters.AddWithValue("@Moli3", bill.Pant.Moli3);
                    command.Parameters.AddWithValue("@Moli4", bill.Pant.Moli4);
                    command.Parameters.AddWithValue("@Moli5", bill.Pant.Moli5);
                    command.Parameters.AddWithValue("@PantNotes", bill.Pant.Notes);
                    command.Parameters.AddWithValue("@ShirtLength1", bill.Shirt.Length1);
                    command.Parameters.AddWithValue("@ShirtLength2", bill.Shirt.Length2);
                    command.Parameters.AddWithValue("@ShirtLength3", bill.Shirt.Length3);
                    command.Parameters.AddWithValue("@ShirtLength4", bill.Shirt.Length4);
                    command.Parameters.AddWithValue("@ShirtLength5", bill.Shirt.Length5);
                    command.Parameters.AddWithValue("@Chati1", bill.Shirt.Chati1);
                    command.Parameters.AddWithValue("@Chati2", bill.Shirt.Chati2);
                    command.Parameters.AddWithValue("@Chati3", bill.Shirt.Chati3);
                    command.Parameters.AddWithValue("@Chati4", bill.Shirt.Chati4);
                    command.Parameters.AddWithValue("@Chati5", bill.Shirt.Chati5);
                    command.Parameters.AddWithValue("@Solder1", bill.Shirt.Solder1);
                    command.Parameters.AddWithValue("@Solder2", bill.Shirt.Solder2);
                    command.Parameters.AddWithValue("@Solder3", bill.Shirt.Solder3);
                    command.Parameters.AddWithValue("@Solder4", bill.Shirt.Solder4);
                    command.Parameters.AddWithValue("@Solder5", bill.Shirt.Solder5);
                    command.Parameters.AddWithValue("@Bye1", bill.Shirt.Bye1);
                    command.Parameters.AddWithValue("@Bye2", bill.Shirt.Bye2);
                    command.Parameters.AddWithValue("@Bye3", bill.Shirt.Bye3);
                    command.Parameters.AddWithValue("@Bye4", bill.Shirt.Bye4);
                    command.Parameters.AddWithValue("@Bye5", bill.Shirt.Bye5);
                    command.Parameters.AddWithValue("@Front1", bill.Shirt.Front1);
                    command.Parameters.AddWithValue("@Front2", bill.Shirt.Front2);
                    command.Parameters.AddWithValue("@Front3", bill.Shirt.Front3);
                    command.Parameters.AddWithValue("@Front4", bill.Shirt.Front4);
                    command.Parameters.AddWithValue("@Front5", bill.Shirt.Front5);
                    command.Parameters.AddWithValue("@Kolor1", bill.Shirt.Kolor1);
                    command.Parameters.AddWithValue("@Kolor2", bill.Shirt.Kolor2);
                    command.Parameters.AddWithValue("@Kolor3", bill.Shirt.Kolor3);
                    command.Parameters.AddWithValue("@Kolor4", bill.Shirt.Kolor4);
                    command.Parameters.AddWithValue("@Kolor5", bill.Shirt.Kolor5);
                    command.Parameters.AddWithValue("@Cuff1", bill.Shirt.Cuff1);
                    command.Parameters.AddWithValue("@Cuff2", bill.Shirt.Cuff2);
                    command.Parameters.AddWithValue("@Cuff3", bill.Shirt.Cuff3);
                    command.Parameters.AddWithValue("@Cuff4", bill.Shirt.Cuff4);
                    command.Parameters.AddWithValue("@Cuff5", bill.Shirt.Cuff5);
                    command.Parameters.AddWithValue("@ShirtNotes", bill.Shirt.Notes);
                    command.Parameters.AddWithValue("@BillDate", bill.BillDate);
                    command.Parameters.AddWithValue("@DeliveryDate", bill.DeliveryDate);
                    command.Parameters.AddWithValue("@TrialDate", bill.TrialDate);
                    command.Parameters.AddWithValue("@PantQty", bill.BillDetails.Where(x => x.Product.Name.ToLower() == "pant").FirstOrDefault().Qty);
                    command.Parameters.AddWithValue("@ShirtQty", bill.BillDetails.Where(x => x.Product.Name.ToLower() == "shirt").FirstOrDefault().Qty);
                    command.Parameters.AddWithValue("@ExtraCost", bill.ExtraCost);
                    command.Parameters.AddWithValue("@Discount", bill.Discount);
                    command.Parameters.AddWithValue("@PaidAmount", bill.PaidAmount);
                    command.Parameters.AddWithValue("@TotalAmount", bill.TotalAmount);
                    command.Parameters.Add("@BillId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@BillNo", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.ExecuteNonQuery();

                    int insertedId = (int)command.Parameters["@BillId"].Value;
                    int billNo = (int)command.Parameters["@BillNo"].Value;
                    bill.Id = insertedId;
                    bill.BillNo = billNo;
                }
            }
            return bill;
        }

        //====Use below one later
        //public int Insert(Bill bill)
        //{
        //    using (var connection = GetSqlConnection())
        //    {
        //        using (var command = new SqlCommand(spSaveBill, connection))
        //        {
        //            command.Parameters.AddWithValue("@CustomerId", bill.Customer.Id);                    
        //            command.Parameters.AddWithValue("@BillDate", bill.BillDate);
        //            command.Parameters.AddWithValue("@DeliveryDate", bill.DeliveryDate);
        //            command.Parameters.AddWithValue("@TrialDate", bill.TrialDate);
        //            command.Parameters.AddWithValue("@ExtraCost", bill.ExtraCost);
        //            command.Parameters.AddWithValue("@Discount", bill.Discount);
        //            command.Parameters.AddWithValue("@TotalAmount", bill.TotalAmount);
        //            command.Parameters.AddWithValue("@PaidAmount", bill.PaidAmount);
        //            command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

        //            command.CommandType = CommandType.StoredProcedure;
        //            connection.Open();
        //            command.ExecuteNonQuery();

        //            int insertedId = (int)command.Parameters["@Id"].Value;
        //            bill.Id = insertedId;
        //        }
        //    }
        //    return bill.Id;
        //}

        //====To Do
        public void Update(Bill customer)
        {

            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(spUpdateBill, connection))
                {
                    command.Parameters.AddWithValue("@Id", customer.Id);

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
                using (var command = new SqlCommand(spDeleteBillById, connection))
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
