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

            // Connect to Host SMS and run Toolbox-ISTBySubdepartmentReport stored procedure
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


        // GET: /Reports/ItemSingleTotalbyBrand
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


        // GET: /Reports/ItemSingleTotalbySubdepartment
        public ActionResult ItemSingleTotalbySubdepartment()
        {
            return View();
        }

        public ActionResult GetItemSingleTotalbySubdepartment(string location, string subdepartment, string startDate, string endDate)
        {
            // Create variables for use within stored procedure and report display
            string subdepartmentCode = subdepartment.Split(',')[0];
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
                    cmd.Parameters.Add("@subdepartment", SqlDbType.Int).Value = subdepartmentCode;

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
            ViewBag.sdpCode = subdepartmentCode;
            ViewBag.sdpDesc = subdepartmentDescription;
            ViewBag.store = storeDescription;

            // Return results to report display
            return PartialView("_ItemSingleTotalbySubdepartment", report);
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
    }
}