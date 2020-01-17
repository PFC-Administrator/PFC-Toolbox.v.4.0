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

        public ActionResult GetItemSingleTotal(string location, string UPC, string startDate, string endDate)
        {
            string store = location.Split(',')[1];

            // create local objects
            SqlDataReader reader = null;
            List<ItemSingleTotalModel> report = new List<ItemSingleTotalModel>();
            ItemSingleTotalModel item = null;
            decimal totalAmount = 0;
            double totalQty = 0, totalUnits = 0;

            // set query
            string query = "declare @StartDate DateTime "
                                    + " declare @EndDate DateTime "
                                    + " declare @sTarget char(3) "
                                    + " declare @UPC varchar(13) "
                                    + " set @StartDate = '" + startDate.ToString() + "'"
                                    + " set @EndDate = '" + endDate.ToString() + "' "
                                    + " set @sTarget = '" + location + "' "
                                    + " set @UPC = '" + UPC + "' "
                                    + " select TRS.F01 UPC, "
                                    + " SDP.F04 SubdeptCode, "
                                    + " MAX(SDP.F1022) SubdeptName, MAX(OBJ.F155) Brand, "
                                    + " MAX(OBJ.F29) ItemDescription, MAX(OBJ.F22) Size, "
                                    + " SUM(case when TRS.F67=0 then 0 else TRS.F64 end) Quantity, "
                                    + " SUM(TRS.F65) Amount, "
                                    + " SUM(case when TRS.F67=0 then TRS.F64 else TRS.F67 end) Units "
                                    + " from RPT_ITM_D TRS join OBJ_TAB OBJ on TRS.F01=OBJ.F01 "
                                    + " join TLZ_TAB TLZ on TRS.F1034=TLZ.F1034 "
                                    + " join POS_TAB POS on TRS.F01=POS.F01  "
                                    + " join SDP_TAB SDP on POS.F04=SDP.F04 "
                                    + " join LNK_TAB LNK on TRS.F1056=LNK.F1056 and TRS.F1057=LNK.F1057 and LNK.F1000=@sTarget "
                                    + " where TRS.F254 between @StartDate and @EndDate "
                                    + " and TRS.F1034 between 3 and 4 "
                                    + " and TRS.F01 = @UPC "
                                    + " and POS.F1000=(SELECT TOP 1 SUB_POS.F1000  "
                                    + "             FROM POS_TAB SUB_POS  "
                                    + "             JOIN LNK_TAB SUB_LNK ON SUB_POS.F1000=SUB_LNK.F1000  "
                                    + "             JOIN LNK_TAB SUB_LNK2 ON SUB_LNK.F1056=SUB_LNK2.F1056 AND SUB_LNK.F1057=SUB_LNK2.F1057 AND SUB_LNK2.F1000=@sTarget  "
                                    + "             JOIN STO_TAB SUB_STO ON SUB_LNK.F1000=SUB_STO.F1000  "
                                    + "             WHERE SUB_POS.F01=POS.F01 ORDER BY SUB_STO.F1937 DESC) "
                                    + " group by SDP.F04, TRS.F01 order by SDP.F04, MAX(OBJ.F155), MAX(OBJ.F29) ";

            // open db connection
            string connect = ConfigurationManager.ConnectionStrings["SMSHostConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // open connection
                    conn.Open();

                    // run query against db
                    reader = cmd.ExecuteReader();

                    // save query results to list
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            item = new ItemSingleTotalModel();
                            item.ItemCode = reader["UPC"].ToString();
                            item.Subdept = reader["SubdeptName"].ToString();
                            item.ItemBrand = reader["Brand"].ToString();
                            item.ItemDescription = reader["ItemDescription"].ToString();
                            item.ItemSize = reader["Size"].ToString();
                            if (!reader["Quantity"].ToString().Equals(""))
                            {
                                item.SalesQuantity = Double.Parse(reader["Quantity"].ToString());
                            } // end if
                            else item.SalesQuantity = 0;
                            if (!reader["Amount"].ToString().Equals(""))
                            {
                                item.SalesAmount = Decimal.Parse(reader["Amount"].ToString());
                            }
                            else item.SalesAmount = 0;
                            if (!reader["Units"].ToString().Equals(""))
                            {
                                item.SalesUnits = Double.Parse(reader["Units"].ToString());
                            }
                            else item.SalesUnits = 0;
                            totalQty = totalQty + item.SalesQuantity;
                            totalAmount = totalAmount + item.SalesAmount;
                            totalUnits = totalUnits + item.SalesUnits;
                            report.Add(item);
                        } // end while
                    } // end if reader.hasrows

                    // close conn
                    conn.Close();

                } // end sqlcommand
            } // end sqlconnection

            // add totals to ViewBag
            ViewBag.TotalQuantity = totalQty;
            ViewBag.TotalAmount = totalAmount;
            ViewBag.TotalUnits = totalUnits;
            ViewBag.store = store;

            // return results
            return PartialView("_ItemSingleTotal", report);

        } // end GetItemSingleTotal


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
            decimal totalAmount = 0;
            double totalQty = 0, totalUnits = 0;
            
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
                            if (Double.TryParse(reader["Quantity"].ToString(), out tempDouble))
                            {
                                item.SalesQuantity = tempDouble;
                            }
                            else item.SalesQuantity = 0;
                            if (Decimal.TryParse(reader["Amount"].ToString(), out tempDecimal))
                            {
                                item.SalesAmount = tempDecimal;
                            }
                            else item.SalesAmount = 0;
                            if (Double.TryParse(reader["Units"].ToString(), out tempDouble))
                            {
                                item.SalesUnits = tempDouble;
                            }
                            else item.SalesUnits = 0;

                            // Sum totals
                            totalQty = totalQty + item.SalesQuantity;
                            totalAmount = totalAmount + item.SalesAmount;
                            totalUnits = totalUnits + item.SalesUnits;

                            // Add results to list
                            report.Add(item);
                        }
                    }

                    // Close connection to SQL server
                    con.Close();
                }
            }

            // Add totals to ViewBag to be used in report display
            ViewBag.TotalQuantity = totalQty;
            ViewBag.TotalAmount = totalAmount;
            ViewBag.TotalUnits = totalUnits;
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
            decimal totalAmount = 0, totalCTM = 0;
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
                                    item.SalesAmount = tempDecimal;
                                }else item.SalesAmount = 0;
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
                                else item.SalesVendorID = "TEST";
                                if (!reader["Reorder"].ToString().Equals(""))
                                {
                                    item.SalesReorder = reader["Reorder"].ToString();
                                }
                                else item.SalesReorder = "na";
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
                                totalAmount = totalAmount + item.SalesAmount;
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
                ViewBag.TotalWeight = totalWeight;
                ViewBag.TotalAmount = totalAmount;
                ViewBag.TotalUnits = totalUnits;
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
                                    item.SalesAmount = tempDecimal;
                                }
                                else item.SalesAmount = 0;
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
                                else item.SalesVendorID = "TEST";
                                if (!reader["Reorder"].ToString().Equals(""))
                                {
                                    item.SalesReorder = reader["Reorder"].ToString();
                                }
                                else item.SalesReorder = "na";
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
                                totalAmount = totalAmount + item.SalesAmount;
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
                ViewBag.TotalWeight = totalWeight;
                ViewBag.TotalAmount = totalAmount;
                ViewBag.TotalUnits = totalUnits;
                ViewBag.TotalCTM = totalCTM;
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