using PFC_Toolbox.v._4._0.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLaxStoreMultiTotals()
        {
            // Create local objects
            SqlDataReader reader = null;
            List<StoreMultiTotalsModel> report = new List<StoreMultiTotalsModel>();
            StoreMultiTotalsModel item = null;

            var date = DateTime.Now.ToString("MM/dd/yyyy");

            // Executes Toolbox-StoreMultiTotals stored procedure located on La Crosse SMS SQL Server and provides parameters
            using (SqlConnection con1 = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSLaxConnection"].ConnectionString })
            {
                using (SqlCommand cmd1 = new SqlCommand("[Toolbox-StoreMultiTotals]", con1))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.Add("@date", SqlDbType.DateTime).Value = date;

                    con1.Open();

                    // Execute cmd against server and store in reader object
                    reader = cmd1.ExecuteReader();

                    // Save query results to list
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Temp variables for TryParse
                            decimal tempDecimal;
                            double tempDouble;
                            Int32 tempInt;

                            // Store results in ItemSingleTotalModel model
                            item = new StoreMultiTotalsModel();
                            if (Double.TryParse(reader["Weight"].ToString(), out tempDouble))
                            {
                                item.SalesWeight = tempDouble;
                            }
                            else item.SalesWeight = 0;
                            if (Decimal.TryParse(reader["Total Sales"].ToString(), out tempDecimal))
                            {
                                item.SalesTotal = tempDecimal;
                            }
                            else item.SalesTotal = 0;
                            if (Double.TryParse(reader["Quantity"].ToString(), out tempDouble))
                            {
                                item.SalesQuantity = tempDouble;
                            }
                            else item.SalesQuantity = 0;
                            if (Int32.TryParse(reader["Transactions"].ToString(), out tempInt))
                            {
                                item.SalesTransactions = tempInt;
                            }
                            else item.SalesTransactions = 0;

                            // Add results to list
                            report.Add(item);
                        }
                    }

                    // Close connection to SQL server
                    con1.Close();
                }
            }

            // Return results to report display
            return View("Index", report);
        }

        public ActionResult GetRochStoreMultiTotals()
        {
            // Create local objects
            SqlDataReader reader = null;
            List<StoreMultiTotalsModel> report = new List<StoreMultiTotalsModel>();
            StoreMultiTotalsModel item = null;

            var date = DateTime.Now.ToString("MM/dd/yyyy");

            // Executes Toolbox-StoreMultiTotals stored procedure located on La Crosse SMS SQL Server and provides parameters
            using (SqlConnection con1 = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSRochConnection"].ConnectionString })
            {
                using (SqlCommand cmd1 = new SqlCommand("[Toolbox-StoreMultiTotals]", con1))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.Add("@date", SqlDbType.DateTime).Value = date;

                    con1.Open();

                    // Execute cmd against server and store in reader object
                    reader = cmd1.ExecuteReader();

                    // Save query results to list
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Temp variables for TryParse
                            decimal tempDecimal;
                            double tempDouble;
                            Int32 tempInt;

                            // Store results in ItemSingleTotalModel model
                            item = new StoreMultiTotalsModel();
                            if (Double.TryParse(reader["Weight"].ToString(), out tempDouble))
                            {
                                item.SalesWeight = tempDouble;
                            }
                            else item.SalesWeight = 0;
                            if (Decimal.TryParse(reader["Total Sales"].ToString(), out tempDecimal))
                            {
                                item.SalesTotal = tempDecimal;
                            }
                            else item.SalesTotal = 0;
                            if (Double.TryParse(reader["Quantity"].ToString(), out tempDouble))
                            {
                                item.SalesQuantity = tempDouble;
                            }
                            else item.SalesQuantity = 0;
                            if (Int32.TryParse(reader["Transactions"].ToString(), out tempInt))
                            {
                                item.SalesTransactions = tempInt;
                            }
                            else item.SalesTransactions = 0;

                            // Add results to list
                            report.Add(item);
                        }
                    }

                    // Close connection to SQL server
                    con1.Close();
                }
            }

            // Return results to report display
            return View("Index", report);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}