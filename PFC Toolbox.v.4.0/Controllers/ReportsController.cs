using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PFC_Toolbox.v._4._0.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        /*******************************************************************************************************************************************************************************************************************/

        // GET: /Reports/ItemSingleTotal
        public ActionResult ItemSingleTotal()
        {
            return View();
        }

        public ActionResult GetItemSingleTotal(string location, string startDate, string endDate, string UPCs)
        {
            // Creates variables for use within stored procedure and report display
            string storeCode = location.Split(',')[0];
            string storeDescription = location.Split(',')[1];

            // Create local objects
            SqlDataReader reader = null;
            List<ItemSingleTotalModel> report = new List<ItemSingleTotalModel>();
            ItemSingleTotalModel item = null;
            decimal totalSales = 0;
            double totalWeight = 0, totalUnits = 0;

            // Connect to Host SMS and run Toolbox-ISTByUPCReport stored procedure
            using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSHostConnection"].ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand("[Toolbox-ISTByUPCReport]", con))
                {
                    // Set the command type as a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set the stored procedure parameters
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
                    cmd.Parameters.Add("@storeTarget", SqlDbType.VarChar).Value = storeCode;
                    cmd.Parameters.Add("@UPC", SqlDbType.VarChar).Value = UPCs;

                    // Open connection to SQL server and set a timeout of 1000 in case report takes a while
                    con.Open();
                    cmd.CommandTimeout = 1000;

                    // Execute cmd against server and store in reader object
                    reader = cmd.ExecuteReader();

                    // Save query results to list
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Temp variables for TryParse
                            decimal tempDecimal;
                            double tempDouble;

                            // Store results in ItemSingleTotalModel model
                            item = new ItemSingleTotalModel();
                            item.ItemCode = reader["UPC"].ToString();
                            item.Subdept = reader["Subdepartment"].ToString();
                            item.ItemBrand = reader["Brand"].ToString();
                            item.ItemDescription = reader["Description"].ToString();
                            item.ItemSize = reader["Size"].ToString();
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

                            // Sum totals
                            totalWeight = totalWeight + item.SalesWeight;
                            totalSales = totalSales + item.SalesTotal;
                            totalUnits = totalUnits + item.SalesQuantity;
                            
                            // Add results to list
                            report.Add(item);
                        }
                    }

                    // Close connection to SQL server
                    con.Close();
                }
            }

            // Add totals to ViewBag to be used in report display
            ViewBag.totalWeight = totalWeight;
            ViewBag.totalSales = totalSales;
            ViewBag.totalUnits = totalUnits;
            ViewBag.store = storeDescription;

            // Return results to report display
            return PartialView("_ItemSingleTotal", report);
        }


        /*******************************************************************************************************************************************************************************************************************/


        // GET: /Reports/ItemSingleTotalbyBrand
        public ActionResult ItemSingleTotalbyBrand()
        {
            return View();
        }

        public ActionResult GetItemSingleTotalbyBrand(string location, string brand, string startDate, string endDate)
        {
            // Create variables for use within stored procedure and report display
            string storeCode = location.Split(',')[0];
            string storeDescription = location.Split(',')[1];

            // Create local objects
            SqlDataReader reader = null;
            List<ItemSingleTotalbyBrandModel> report = new List<ItemSingleTotalbyBrandModel>();
            ItemSingleTotalbyBrandModel item = null;
            decimal totalSales = 0;
            double totalWeight = 0, totalUnits = 0;

            // Connect to Host SMS and run Toolbox-ISTByBrandReport stored procedure
            using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSHostConnection"].ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand("[Toolbox-ISTByBrandReport]", con))
                {
                    // Set the command type as a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set the stored procedure parameters
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
                    cmd.Parameters.Add("@storeTarget", SqlDbType.VarChar).Value = storeCode;
                    cmd.Parameters.Add("@brand", SqlDbType.VarChar).Value = brand;

                    // Open connection to SQL server and set a timeout of 1000 in case report takes a while
                    con.Open();
                    cmd.CommandTimeout = 1000;

                    // Execute cmd against server and store in reader object
                    reader = cmd.ExecuteReader();

                    // Save query results to list
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Temp variables for TryParse
                            decimal tempDecimal;
                            double tempDouble;

                            // Store results in ItemSingleTotalbyBrandModel model
                            item = new ItemSingleTotalbyBrandModel();
                            item.ItemCode = reader["UPC"].ToString();
                            item.Subdept = reader["Subdepartment"].ToString();
                            item.ItemBrand = reader["Brand"].ToString();
                            item.ItemDescription = reader["Description"].ToString();
                            item.ItemSize = reader["Size"].ToString();
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

                            // Sum totals
                            totalWeight = totalWeight + item.SalesWeight;
                            totalSales = totalSales + item.SalesTotal;
                            totalUnits = totalUnits + item.SalesQuantity;

                            // Add results to list
                            report.Add(item);
                        }
                    }

                    // Close connection to SQL server
                    con.Close();
                }
            }

            // Add totals to ViewBag to be used in report display
            ViewBag.totalWeight = totalWeight;
            ViewBag.totalSales = totalSales;
            ViewBag.totalUnits = totalUnits;
            ViewBag.brand = brand;
            ViewBag.store = storeDescription;

            // Return results to report display
            return PartialView("_ItemSingleTotalbyBrand", report);
        }


        /*******************************************************************************************************************************************************************************************************************/


        // GET: /Reports/ItemSingleTotalbyCategory
        public ActionResult ItemSingleTotalbyCategory()
        {
            return View();
        }

        public ActionResult GetItemSingleTotalbyCategory(string location, string category, string startDate, string endDate)
        {
            // Create variables for use within stored procedure and report display
            string categoryCode = category.Split(',')[0];
            string categoryDescription = category.Split(',')[1];
            string storeCode = location.Split(',')[0];
            string storeDescription = location.Split(',')[1];

            // Create local objects
            SqlDataReader reader = null;
            List<ItemSingleTotalbyCategoryModel> report = new List<ItemSingleTotalbyCategoryModel>();
            ItemSingleTotalbyCategoryModel item = null;
            decimal totalSales = 0;
            double totalWeight = 0, totalUnits = 0;

            // Connect to Host SMS and run Toolbox-ISTByCategoryReport stored procedure
            using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSHostConnection"].ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand("[Toolbox-ISTByCategoryReport]", con))
                {
                    // Set the command type as a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set the stored procedure parameters
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
                    cmd.Parameters.Add("@storeTarget", SqlDbType.VarChar).Value = storeCode;
                    cmd.Parameters.Add("@category", SqlDbType.VarChar).Value = categoryCode;

                    // Open connection to SQL server and set a timeout of 1000 in case report takes a while
                    con.Open();
                    cmd.CommandTimeout = 1000;

                    // Execute cmd against server and store in reader object
                    reader = cmd.ExecuteReader();

                    // Save query results to list
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Temp variables for TryParse
                            decimal tempDecimal;
                            double tempDouble;

                            // Store results in ItemSingleTotalbyCategoryModel model
                            item = new ItemSingleTotalbyCategoryModel();
                            item.ItemCode = reader["UPC"].ToString();
                            item.Subdept = reader["Subdepartment"].ToString();
                            item.ItemBrand = reader["Brand"].ToString();
                            item.ItemDescription = reader["Description"].ToString();
                            item.ItemSize = reader["Size"].ToString();
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

                            // Sum totals
                            totalWeight = totalWeight + item.SalesWeight;
                            totalSales = totalSales + item.SalesTotal;
                            totalUnits = totalUnits + item.SalesQuantity;

                            // Add results to list
                            report.Add(item);
                        }
                    }

                    // Close connection to SQL server
                    con.Close();
                }
            }

            // Add totals to ViewBag to be used in report display
            ViewBag.totalWeight = totalWeight;
            ViewBag.totalSales = totalSales;
            ViewBag.totalUnits = totalUnits;
            ViewBag.categoryCode = categoryCode;
            ViewBag.categoryDescription = categoryDescription;
            ViewBag.store = storeDescription;

            // Return results to report display
            return PartialView("_ItemSingleTotalbyCategory", report);
        }


        /*******************************************************************************************************************************************************************************************************************/


        // GET: /Reports/ItemSingleTotalbyCoupon
        public ActionResult ItemSingleTotalbyCoupon()
        {
            return View();
        }

        public ActionResult GetItemSingleTotalbyCoupon(string location, string startDate, string endDate)
        {
            // Create variables for use within stored procedure and report display
            string storeCode = location.Split(',')[0];
            string storeDescription = location.Split(',')[1];

            // Create local objects
            SqlDataReader reader = null;
            List<ItemSingleTotalbyCouponModel> report = new List<ItemSingleTotalbyCouponModel>();
            ItemSingleTotalbyCouponModel item = null;
            decimal totalSales = 0;
            double totalUnits = 0;

            // Connect to Host SMS and run Toolbox-ISTByCouponReport stored procedure
            using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSHostConnection"].ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand("[Toolbox-ISTByCouponReport]", con))
                {
                    // Set the command type as a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set the stored procedure parameters
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
                    cmd.Parameters.Add("@storeTarget", SqlDbType.VarChar).Value = storeCode;

                    // Open connection to SQL server and set a timeout of 1000 in case report takes a while
                    con.Open();
                    cmd.CommandTimeout = 1000;

                    // Execute cmd against server and store in reader object
                    reader = cmd.ExecuteReader();

                    // Save query results to list
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Temp variables for TryParse
                            decimal tempDecimal;
                            double tempDouble;

                            // Store results in ItemSingleTotalbyCouponModel model
                            item = new ItemSingleTotalbyCouponModel();
                            item.ItemCode = reader["UPC"].ToString();
                            item.Subdept = reader["Subdepartment"].ToString();
                            item.ItemBrand = reader["Brand"].ToString();
                            item.ItemDescription = reader["Description"].ToString();
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

                            // Sum totals
                            totalSales = totalSales + item.SalesTotal;
                            totalUnits = totalUnits + item.SalesQuantity;

                            // Add results to list
                            report.Add(item);
                        }
                    }

                    // Close connection to SQL server
                    con.Close();
                }
            }

            // Add totals to ViewBag to be used in report display
            ViewBag.totalSales = totalSales;
            ViewBag.totalUnits = totalUnits;
            ViewBag.store = storeDescription;

            // Return results to report display
            return PartialView("_ItemSingleTotalbyCoupon", report);
        }


        /*******************************************************************************************************************************************************************************************************************/


        // GET: /Reports/ItemSingleTotalbySubdepartment
        public ActionResult ItemSingleTotalbySubdepartment()
        {
            return View();
        }

        public ActionResult GetItemSingleTotalbySubdepartment(string location, string subdepartment, string startDate, string endDate)
        {
            // Create variables for use within stored procedure and report display
            string subdepartmentStart = subdepartment.Split(',')[0];
            string subdepartmentEnd = subdepartment.Split(',')[0];
            if (subdepartment.Split(',')[0].Equals("0"))
            {
                subdepartmentStart = "0";
                subdepartmentEnd = "999";
            }

            string subdepartmentDescription = subdepartment.Split(',')[1];
            string storeCode = location.Split(',')[0];
            string storeDescription = location.Split(',')[1];

            // Create local objects
            SqlDataReader reader = null;
            List<ItemSingleTotalbySubdepartmentModel> report = new List<ItemSingleTotalbySubdepartmentModel>();
            ItemSingleTotalbySubdepartmentModel item = null;
            decimal totalSales = 0;
            double totalWeight = 0, totalUnits = 0;

            // Connect to Host SMS and run Toolbox-ISTBySubdepartmentReport stored procedure
            using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSHostConnection"].ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand("[Toolbox-ISTBySubdepartmentReport]", con))
                {
                    // Set the command type as a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set the stored procedure parameters
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
                    cmd.Parameters.Add("@storeTarget", SqlDbType.VarChar).Value = storeCode;
                    cmd.Parameters.Add("@subdepartmentStart", SqlDbType.Int).Value = subdepartmentStart;
                    cmd.Parameters.Add("@subdepartmentEnd", SqlDbType.Int).Value = subdepartmentEnd;

                    // Open connection to SQL server and set a timeout of 1000 incase report takes a while
                    con.Open();
                    cmd.CommandTimeout = 1000;

                    // Execute cmd against server and store in reader object
                    reader = cmd.ExecuteReader();

                    // Save query results to list
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Temp variables for TryParse
                            decimal tempDecimal;
                            double tempDouble;

                            // Store results in ItemSingleTotalbySubdepartmentModel model
                            item = new ItemSingleTotalbySubdepartmentModel();
                            item.ItemCode = reader["UPC"].ToString();
                            item.Subdept = reader["Subdepartment"].ToString();
                            item.ItemBrand = reader["Brand"].ToString();
                            item.ItemDescription = reader["Description"].ToString();
                            item.ItemSize = reader["Size"].ToString();
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

                            // Sum totals
                            totalWeight = totalWeight + item.SalesWeight;
                            totalSales = totalSales + item.SalesTotal;
                            totalUnits = totalUnits + item.SalesQuantity;

                            // Add results to list
                            report.Add(item);
                        }
                    }

                    // Close connection to SQL server
                    con.Close();
                }
            }

            // Add totals to ViewBag to be used in report display
            ViewBag.totalWeight = totalWeight;
            ViewBag.totalSales = totalSales;
            ViewBag.totalUnits = totalUnits;
            ViewBag.sdpCode = subdepartmentStart;
            ViewBag.sdpDesc = subdepartmentDescription;
            ViewBag.store = storeDescription;

            // Return results to report display
            return PartialView("_ItemSingleTotalbySubdepartment", report);
        }


        /*******************************************************************************************************************************************************************************************************************/


        // GET: /Reports/ItemSingleTotalbySubdepartmentbyPeriod
        public ActionResult ItemSingleTotalbySubdepartmentbyPeriod()
        {
            return View();
        }

        public ActionResult GetItemSingleTotalbySubdepartmentbyPeriod(string location, string subdepartment, string startDate, string endDate, string startDate2, string endDate2, string startDate3, string endDate3)
        {
            // Create variables for use within stored procedure and report display
            string subdepartmentStart = subdepartment.Split(',')[0];
            string subdepartmentEnd = subdepartment.Split(',')[0];
            if (subdepartment.Split(',')[0].Equals("0"))
            {
                subdepartmentStart = "0";
                subdepartmentEnd = "999";
            }

            string subdepartmentDescription = subdepartment.Split(',')[1];
            string storeCode = location.Split(',')[0];
            string storeDescription = location.Split(',')[1];

            // Create local objects
            SqlDataReader reader = null;
            List<ItemSingleTotalbySubdepartmentbyPeriodModel> report = new List<ItemSingleTotalbySubdepartmentbyPeriodModel>();
            ItemSingleTotalbySubdepartmentbyPeriodModel item = null;
            decimal totalSales = 0, totalSales2 = 0, totalSales3 = 0; ;
            double totalWeight = 0, totalUnits = 0, totalWeight2 = 0, totalUnits2 = 0, totalWeight3 = 0, totalUnits3 = 0;

            // Connect to Host SMS and run Toolbox-ISTBySubdepartmentReport stored procedure
            using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSHostConnection"].ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand("[Toolbox-ISTBySubdepartmentPeriodReport]", con))
                {
                    // Set the command type as a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set the stored procedure parameters
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
                    cmd.Parameters.Add("@startDate2", SqlDbType.DateTime).Value = startDate2;
                    cmd.Parameters.Add("@endDate2", SqlDbType.DateTime).Value = endDate2;
                    cmd.Parameters.Add("@startDate3", SqlDbType.DateTime).Value = startDate3;
                    cmd.Parameters.Add("@endDate3", SqlDbType.DateTime).Value = endDate3;
                    cmd.Parameters.Add("@storeTarget", SqlDbType.VarChar).Value = storeCode;
                    cmd.Parameters.Add("@subdepartmentStart", SqlDbType.Int).Value = subdepartmentStart;
                    cmd.Parameters.Add("@subdepartmentEnd", SqlDbType.Int).Value = subdepartmentEnd;

                    // Open connection to SQL server and set a timeout of 1000 incase report takes a while
                    con.Open();
                    cmd.CommandTimeout = 1000;

                    // Execute cmd against server and store in reader object
                    reader = cmd.ExecuteReader();

                    // Save query results to list
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Temp variables for TryParse
                            decimal tempDecimal;
                            double tempDouble;

                            // Store results in ItemSingleTotalbySubdepartmentbyPeriodModel model
                            item = new ItemSingleTotalbySubdepartmentbyPeriodModel();
                            item.ItemCode = reader["UPC"].ToString();
                            item.Subdept = reader["Subdepartment"].ToString();
                            item.ItemBrand = reader["Brand"].ToString();
                            item.ItemDescription = reader["Description"].ToString();
                            item.ItemSize = reader["Size"].ToString();
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

                            if (Double.TryParse(reader["Weight2"].ToString(), out tempDouble))
                            {
                                item.SalesWeight2 = tempDouble;
                            }
                            else item.SalesWeight2 = 0;
                            if (Decimal.TryParse(reader["Total Sales2"].ToString(), out tempDecimal))
                            {
                                item.SalesTotal2 = tempDecimal;
                            }
                            else item.SalesTotal2 = 0;
                            if (Double.TryParse(reader["Quantity2"].ToString(), out tempDouble))
                            {
                                item.SalesQuantity2 = tempDouble;
                            }
                            else item.SalesQuantity2 = 0;

                            if (Double.TryParse(reader["Weight3"].ToString(), out tempDouble))
                            {
                                item.SalesWeight3 = tempDouble;
                            }
                            else item.SalesWeight3 = 0;
                            if (Decimal.TryParse(reader["Total Sales3"].ToString(), out tempDecimal))
                            {
                                item.SalesTotal3 = tempDecimal;
                            }
                            else item.SalesTotal3 = 0;
                            if (Double.TryParse(reader["Quantity3"].ToString(), out tempDouble))
                            {
                                item.SalesQuantity3 = tempDouble;
                            }
                            else item.SalesQuantity3 = 0;
                            if (Decimal.TryParse(reader["Trend"].ToString(), out tempDecimal))
                            {
                                item.SalesTrend = tempDecimal;
                            }
                            else item.SalesTrend = 0;

                            // Sum totals
                            totalWeight = totalWeight + item.SalesWeight;
                            totalSales = totalSales + item.SalesTotal;
                            totalUnits = totalUnits + item.SalesQuantity;
                            totalWeight2 = totalWeight2 + item.SalesWeight2;
                            totalSales2 = totalSales2 + item.SalesTotal2;
                            totalUnits2 = totalUnits2 + item.SalesQuantity2;
                            totalWeight3 = totalWeight3 + item.SalesWeight3;
                            totalSales3 = totalSales3 + item.SalesTotal3;
                            totalUnits3 = totalUnits3 + item.SalesQuantity3;

                            // Add results to list
                            report.Add(item);
                        }
                    }

                    // Close connection to SQL server
                    con.Close();
                }
            }

            // Add totals to ViewBag to be used in report display
            ViewBag.totalWeight = totalWeight;
            ViewBag.totalSales = totalSales;
            ViewBag.totalUnits = totalUnits;
            ViewBag.totalWeight2 = totalWeight2;
            ViewBag.totalSales2 = totalSales2;
            ViewBag.totalUnits2 = totalUnits2;
            ViewBag.totalWeight3 = totalWeight3;
            ViewBag.totalSales3 = totalSales3;
            ViewBag.totalUnits3 = totalUnits3;
            ViewBag.sdpCode = subdepartmentStart;
            ViewBag.sdpDesc = subdepartmentDescription;
            ViewBag.store = storeDescription;

            // Return results to report display
            return PartialView("_ItemSingleTotalbySubdepartmentbyPeriod", report);
        }
        
        
        /*******************************************************************************************************************************************************************************************************************/


        // GET: /Reports/CTMSubdepartment
        public ActionResult CTMSubdepartment()
        {
            return View();
        }

        public ActionResult GetCTMSubdepartment(string location, string subdepartment, string startDate, string endDate)
        {
            // Creates variables for use within stored procedure and report display
            string subdepartmentCode = subdepartment.Split(',')[0];
            string subdepartmentDescription = subdepartment.Split(',')[1];
            string storeCode = location.Split(',')[0];
            string storeDescription = location.Split(',')[1];

            // Create local objects
            SqlDataReader reader = null;
            List<CTMSubdepartmentModel> report = new List<CTMSubdepartmentModel>();
            CTMSubdepartmentModel item = null;
            decimal totalSales = 0, totalCTM = 0;
            double totalWeight = 0, totalUnits = 0;

            // Connect to La Crosse or Rochester SMS and run Toolbox-CTMReport stored procedure
            if (location.Equals("001, La Crosse"))
            {
                using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSLaxConnection"].ConnectionString })
                {
                    using (SqlCommand cmd = new SqlCommand("[Toolbox-CTMReport]", con))
                    {
                        // Set the command type as a stored procedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Set the stored procedure parameters
                        cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                        cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
                        cmd.Parameters.Add("@subdepartment", SqlDbType.Int).Value = subdepartmentCode;

                        // Open connection to SQL server and set a timeout of 1000 in case report takes a while
                        con.Open();
                        cmd.CommandTimeout = 1000;

                        // Execute cmd against server and store in reader object
                        reader = cmd.ExecuteReader();

                        // Save query results to list
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Temp variables for TryParse
                                decimal tempDecimal;
                                double tempDouble;

                                // Store results in CTMSubdepartmentModel model
                                item = new CTMSubdepartmentModel();
                                item.ItemCode = reader["UPC"].ToString();
                                item.ItemBrand = reader["Brand"].ToString();
                                item.ItemDescription = reader["Description"].ToString();
                                if (Double.TryParse(reader["Weight"].ToString(), out tempDouble))
                                {
                                    item.SalesWeight = tempDouble;
                                }
                                else item.SalesWeight = 0;
                                if (Double.TryParse(reader["Quantity"].ToString(), out tempDouble))
                                {
                                    item.SalesQuantity = tempDouble;
                                }
                                else item.SalesQuantity = 0;
                                if (Decimal.TryParse(reader["Total Sales"].ToString(), out tempDecimal))
                                {
                                    item.SalesTotal = tempDecimal;
                                }else item.SalesTotal = 0;
                                if (Decimal.TryParse(reader["Retail"].ToString(), out tempDecimal))
                                {
                                    item.SalesRetail = tempDecimal;
                                }
                                else item.SalesRetail = 0;
                                if (Decimal.TryParse(reader["Cost"].ToString(), out tempDecimal))
                                {
                                    item.SalesCost = tempDecimal;
                                }
                                else item.SalesCost = 0;
                                if (!reader["Vendor ID"].ToString().Equals(""))
                                {
                                    item.SalesVendorID = reader["Vendor ID"].ToString();
                                }
                                else item.SalesVendorID = "UNDEF";
                                if (!reader["Reorder"].ToString().Equals(""))
                                {
                                    item.SalesReorder = reader["Reorder"].ToString();
                                }
                                else item.SalesReorder = "UNDEF";
                                if (Decimal.TryParse(reader["% of Sales"].ToString(), out tempDecimal))
                                {
                                    item.SalesPercent = tempDecimal;
                                }
                                else item.SalesPercent = 0;
                                if (Decimal.TryParse(reader["Applied Margin"].ToString(), out tempDecimal))
                                {
                                    item.SalesAppliedMargin = tempDecimal;
                                }
                                else item.SalesAppliedMargin = 0;
                                if (Decimal.TryParse(reader["CTM"].ToString(), out tempDecimal))
                                {
                                    item.SalesCTM = tempDecimal;
                                }
                                else item.SalesCTM = 0;

                                // Sum totals
                                totalWeight = totalWeight + item.SalesWeight;
                                totalSales = totalSales + item.SalesTotal;
                                totalUnits = totalUnits + item.SalesQuantity;
                                totalCTM = totalCTM + item.SalesCTM;

                                // Add results to list
                                report.Add(item);
                            }
                        }

                        // Close connection to SQL server
                        con.Close();
                    }
                }

                // Add totals to ViewBag to be used in report display
                ViewBag.totalWeight = totalWeight;
                ViewBag.totalSales = totalSales;
                ViewBag.totalUnits = totalUnits;
                ViewBag.TotalCTM = totalCTM;
                ViewBag.sdpCode = subdepartmentCode;
                ViewBag.sdpDesc = subdepartmentDescription;
                ViewBag.store = storeDescription;

                // Return results to report display
                return PartialView("_CTMSubdepartment", report);
            }
            else if (location.Equals("002, Rochester"))
            {
                using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSRochConnection"].ConnectionString })
                {
                    using (SqlCommand cmd = new SqlCommand("[Toolbox-CTMReport]", con))
                    {
                        // Set the command type as a stored procedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Set the stored procedure parameters
                        cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                        cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
                        cmd.Parameters.Add("@subdepartment", SqlDbType.Int).Value = subdepartmentCode;

                        // Open connection to SQL server and set a timeout of 1000 in case report takes a while
                        con.Open();
                        cmd.CommandTimeout = 1000;

                        // Execute cmd against server and store in reader object
                        reader = cmd.ExecuteReader();

                        // Save query results to list
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Temp variables for TryParse
                                decimal tempDecimal;
                                double tempDouble;

                                // Store results in CTMSubdepartmentModel model
                                item = new CTMSubdepartmentModel();
                                item.ItemCode = reader["UPC"].ToString();
                                item.ItemBrand = reader["Brand"].ToString();
                                item.ItemDescription = reader["Description"].ToString();
                                if (Double.TryParse(reader["Weight"].ToString(), out tempDouble))
                                {
                                    item.SalesWeight = tempDouble;
                                }
                                else item.SalesWeight = 0;
                                if (Double.TryParse(reader["Quantity"].ToString(), out tempDouble))
                                {
                                    item.SalesQuantity = tempDouble;
                                }
                                else item.SalesQuantity = 0;
                                if (Decimal.TryParse(reader["Total Sales"].ToString(), out tempDecimal))
                                {
                                    item.SalesTotal = tempDecimal;
                                }
                                else item.SalesTotal = 0;
                                if (Decimal.TryParse(reader["Retail"].ToString(), out tempDecimal))
                                {
                                    item.SalesRetail = tempDecimal;
                                }
                                else item.SalesRetail = 0;
                                if (Decimal.TryParse(reader["Cost"].ToString(), out tempDecimal))
                                {
                                    item.SalesCost = tempDecimal;
                                }
                                else item.SalesCost = 0;
                                if (!reader["Vendor ID"].ToString().Equals(""))
                                {
                                    item.SalesVendorID = reader["Vendor ID"].ToString();
                                }
                                else item.SalesVendorID = "UNDEF";
                                if (!reader["Reorder"].ToString().Equals(""))
                                {
                                    item.SalesReorder = reader["Reorder"].ToString();
                                }
                                else item.SalesReorder = "UNDEF";
                                if (Decimal.TryParse(reader["% of Sales"].ToString(), out tempDecimal))
                                {
                                    item.SalesPercent = tempDecimal;
                                }
                                else item.SalesPercent = 0;
                                if (Decimal.TryParse(reader["Applied Margin"].ToString(), out tempDecimal))
                                {
                                    item.SalesAppliedMargin = tempDecimal;
                                }
                                else item.SalesAppliedMargin = 0;
                                if (Decimal.TryParse(reader["CTM"].ToString(), out tempDecimal))
                                {
                                    item.SalesCTM = tempDecimal;
                                }
                                else item.SalesCTM = 0;

                                // Sum totals
                                totalWeight = totalWeight + item.SalesWeight;
                                totalSales = totalSales + item.SalesTotal;
                                totalUnits = totalUnits + item.SalesQuantity;
                                totalCTM = totalCTM + item.SalesCTM;

                                // Add results to list
                                report.Add(item);
                            }
                        }

                        // Close connection to SQL server
                        con.Close();
                    }
                }

                // Add totals to ViewBag to be used in report display
                ViewBag.totalWeight = totalWeight;
                ViewBag.totalSales = totalSales;
                ViewBag.totalUnits = totalUnits;
                ViewBag.totalCTM = totalCTM;
                ViewBag.sdpCode = subdepartmentCode;
                ViewBag.sdpDesc = subdepartmentDescription;
                ViewBag.store = storeDescription;

                // Return results to report display
                return PartialView("_CTMSubdepartment", report);
            }
            else
            {
                Response.Redirect("Error");
                return null;
            }
        }


        /*******************************************************************************************************************************************************************************************************************/


        // GET: /Reports/PurchasesSummary
        public ActionResult PurchasesSummary()
        {
            return View();
        }

        public ActionResult GetPUrchasesSummary()
        {
            // Create local objects
            SqlDataReader reader = null;
            List<PurchasesSummaryModel> report = new List<PurchasesSummaryModel>();
            PurchasesSummaryModel item = null;

            // Connect to Host SMS and run Toolbox-ISTBySubdepartmentReport stored procedure
            using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand("[Toolbox-PurchasesSummary]", con))
                {
                    // Set the command type as a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Open connection to SQL server and set a timeout of 1000 incase report takes a while
                    con.Open();
                    cmd.CommandTimeout = 1000;

                    // Execute cmd against server and store in reader object
                    reader = cmd.ExecuteReader();

                    // Save query results to list
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Temp variables for TryParse
                            decimal tempDecimal;

                            // Store results in PurchasesSummaryModel model
                            item = new PurchasesSummaryModel();
                            item.Subdept = reader["Subdepartment"].ToString();
                            item.Location = reader["Location"].ToString();
                            item.WeekStart = reader["WeekStart"].ToString();

                            if (Decimal.TryParse(reader["TotalAmount"].ToString(), out tempDecimal))
                            {
                                item.SalesTotal = tempDecimal;
                            }
                            else item.SalesTotal = 0;
                            if (Decimal.TryParse(reader["ReconciledAmount"].ToString(), out tempDecimal))
                            {
                                item.SalesReconciled = tempDecimal;
                            }
                            else item.SalesReconciled = 0;
                            if (Decimal.TryParse(reader["AmountDifferent"].ToString(), out tempDecimal))
                            {
                                item.SalesDifferent = tempDecimal;
                            }
                            else item.SalesDifferent = 0;

                            // Add results to list
                            report.Add(item);
                        }
                    }

                    // Close connection to SQL server
                    con.Close();
                }
            }

            // Return results to report display
            return PartialView("PurchasesSummary", report);
        }

        /*******************************************************************************************************************************************************************************************************************/


        // GET: /Reports/WriteoffsSummary
        public ActionResult WriteoffsSummary()
        {
            return View();
        }

        public ActionResult GetWriteoffsSummary()
        {
            // Create local objects
            SqlDataReader reader = null;
            List<WriteoffsSummaryModel> report = new List<WriteoffsSummaryModel>();
            WriteoffsSummaryModel item = null;

            // Connect to Host SMS and run Toolbox-ISTBySubdepartmentReport stored procedure
            using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand("[Toolbox-WriteoffsSummary]", con))
                {
                    // Set the command type as a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Open connection to SQL server and set a timeout of 1000 incase report takes a while
                    con.Open();
                    cmd.CommandTimeout = 1000;

                    // Execute cmd against server and store in reader object
                    reader = cmd.ExecuteReader();

                    // Save query results to list
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Temp variables for TryParse
                            decimal tempDecimal;

                            // Store results in WriteoffsSummaryModel model
                            item = new WriteoffsSummaryModel();
                            item.Subdept = reader["Subdepartment"].ToString();
                            item.Location = reader["Location"].ToString();
                            item.WeekStart = reader["WeekStart"].ToString();

                            if (Decimal.TryParse(reader["TotalAmount"].ToString(), out tempDecimal))
                            {
                                item.SalesTotal = tempDecimal;
                            }
                            else item.SalesTotal = 0;

                            // Add results to list
                            report.Add(item);
                        }
                    }

                    // Close connection to SQL server
                    con.Close();
                }
            }

            // Return results to report display
            return PartialView("WriteoffsSummary", report);
        }


        /*******************************************************************************************************************************************************************************************************************/


        // GET: PurchasesReports
        public ActionResult PurchasesReport()
        {
            return View();
        }

        public ActionResult GetPurchasesReport(string location, string subdepartment, string startDate, string endDate)
        {
            // Create variables for use within stored procedure and report display
            string storeCodeStart = location.Split(',')[0];
            string storeCodeEnd = location.Split(',')[0];
            string storeDescription = location.Split(',')[1];
            if (storeCodeStart.Equals("3"))
            {
                storeCodeStart = "0";
                storeCodeEnd = "999";
            }
            string subdepartmentStart = subdepartment.Split(',')[0];
            string subdepartmentEnd = subdepartment.Split(',')[0];
            string subdepartmentDescription = subdepartment.Split(',')[1];
            if (subdepartment.Split(',')[0].Equals("0"))
            {
                subdepartmentStart = "0";
                subdepartmentEnd = "999";
            }

            // Create local objects
            SqlDataReader reader = null;
            List<PurchasesReportModel> report = new List<PurchasesReportModel>();
            PurchasesReportModel item = null;;

            // Connect to Host SMS and run Toolbox-PurchasesReport stored procedure
            using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand("[Toolbox-PurchasesReport]", con))
                {
                    // Set the command type as a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set the stored procedure parameters
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime2).Value = startDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime2).Value = endDate;
                    cmd.Parameters.Add("@storeStart", SqlDbType.VarChar).Value = storeCodeStart;
                    cmd.Parameters.Add("@storeEnd", SqlDbType.VarChar).Value = storeCodeEnd;
                    cmd.Parameters.Add("@subdepartmentStart", SqlDbType.VarChar).Value = subdepartmentStart;
                    cmd.Parameters.Add("@subdepartmentEnd", SqlDbType.VarChar).Value = subdepartmentEnd;

                    // Open connection to SQL server and set a timeout of 1000 in case report takes a while
                    con.Open();
                    cmd.CommandTimeout = 1000;

                    // Execute cmd against server and store in reader object
                    reader = cmd.ExecuteReader();

                    // Save query results to list
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Temp variables for TryParse
                            decimal tempDecimal;

                            // Store results in PurchasesReportModel model
                            item = new PurchasesReportModel();
                            item.PurchaseID = reader["Purchase ID"].ToString();
                            item.InvoiceNumber = reader["Invoice Number"].ToString();
                            item.VendorID = reader["Vendor ID"].ToString();
                            item.PurchaseDate = reader["Purchase Date"].ToString();
                            if (Decimal.TryParse(reader["Purchase Amount"].ToString(), out tempDecimal))
                            {
                                item.PurchaseAmount = tempDecimal;
                            }
                            else item.PurchaseAmount = 0;
                            item.PurchaseReconciled = reader["Purchase Reconciled"].ToString();
                            item.SubdepartmentID = reader["Subdepartment"].ToString();
                            item.LocationID = reader["Location"].ToString();
                            item.PurchaseMemo = reader["Memo"].ToString();
                            item.CreatedBy = reader["Created By"].ToString();
                            item.DateCreated = reader["Date Created"].ToString();

                            // Add results to list
                            report.Add(item);
                        }
                    }

                    // Close connection to SQL server
                    con.Close();
                }
            }

            // Add totals to ViewBag to be used in report display
            ViewBag.sdpCode = subdepartmentStart;
            ViewBag.sdpDesc = subdepartmentDescription;
            ViewBag.store = storeDescription;

            // Return results to report display
            return PartialView("_PurchasesReport", report);
        }


        /*******************************************************************************************************************************************************************************************************************/


        // GET: WriteoffsReports
        public ActionResult WriteoffsReport()
        {
            return View();
        }

        public ActionResult GetWriteoffsReport(string location, string subdepartment, string startDate, string endDate)
        {
            // Create variables for use within stored procedure and report display
            string storeCodeStart = location.Split(',')[0];
            string storeCodeEnd = location.Split(',')[0];
            string storeDescription = location.Split(',')[1];
            if (storeCodeStart.Equals("3"))
            {
                storeCodeStart = "0";
                storeCodeEnd = "999";
            }
            string subdepartmentStart = subdepartment.Split(',')[0];
            string subdepartmentEnd = subdepartment.Split(',')[0];
            string subdepartmentDescription = subdepartment.Split(',')[1];
            if (subdepartment.Split(',')[0].Equals("0"))
            {
                subdepartmentStart = "0";
                subdepartmentEnd = "999";
            }

            // Create local objects
            SqlDataReader reader = null;
            List<WriteoffsReportModel> report = new List<WriteoffsReportModel>();
            WriteoffsReportModel item = null; ;

            // Connect to Host SMS and run Toolbox-WriteoffsReport stored procedure
            using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["ToolboxConnection"].ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand("[Toolbox-WriteoffsReport]", con))
                {
                    // Set the command type as a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set the stored procedure parameters
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime2).Value = startDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime2).Value = endDate;
                    cmd.Parameters.Add("@storeStart", SqlDbType.VarChar).Value = storeCodeStart;
                    cmd.Parameters.Add("@storeEnd", SqlDbType.VarChar).Value = storeCodeEnd;
                    cmd.Parameters.Add("@subdepartmentStart", SqlDbType.VarChar).Value = subdepartmentStart;
                    cmd.Parameters.Add("@subdepartmentEnd", SqlDbType.VarChar).Value = subdepartmentEnd;

                    // Open connection to SQL server and set a timeout of 1000 in case report takes a while
                    con.Open();
                    cmd.CommandTimeout = 1000;

                    // Execute cmd against server and store in reader object
                    reader = cmd.ExecuteReader();

                    // Save query results to list
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Temp variables for TryParse
                            decimal tempDecimal;

                            // Store results in WriteoffsReportModel model
                            item = new WriteoffsReportModel();
                            item.WriteoffCode = reader["Writeoff Code"].ToString();
                            item.ItemName = reader["Item Name"].ToString();
                            item.Quantity = reader["Quantity"].ToString();
                            if (Decimal.TryParse(reader["Unit Price"].ToString(), out tempDecimal))
                            {
                                item.UnitPrice = tempDecimal;
                            }
                            else item.UnitPrice = 0;
                            if (Decimal.TryParse(reader["Total Price"].ToString(), out tempDecimal))
                            {
                                item.TotalPrice = tempDecimal;
                            }
                            else item.TotalPrice = 0;
                            item.SubdepartmentID = reader["Subdepartment"].ToString();
                            item.LocationID = reader["Location"].ToString();
                            item.PurchaseMemo = reader["Memo"].ToString();
                            item.CreatedBy = reader["Created By"].ToString();
                            item.DateCreated = reader["Date Created"].ToString();

                            // Add results to list
                            report.Add(item);
                        }
                    }

                    // Close connection to SQL server
                    con.Close();
                }
            }

            // Add totals to ViewBag to be used in report display
            ViewBag.sdpCode = subdepartmentStart;
            ViewBag.sdpDesc = subdepartmentDescription;
            ViewBag.store = storeDescription;

            // Return results to report display
            return PartialView("_WriteoffsReport", report);
        }
    }
}