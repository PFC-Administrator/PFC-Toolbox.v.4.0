using System;
using System.Web.Mvc;
using PFC_Toolbox.v._4._0.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class SMSController : Controller
    {
        // GET: SMS
        public ActionResult Index()
        {
            return View();
        }

        /*******************************************************************************************************************************************************************************************************************/

        // GET: /SMS/ItemLookupByUPC
        public ActionResult ItemLookupByUPC()
        {
            return View();
        }

        public ActionResult GetItemCodeInfo(string UPCs, string location)
        {
            // Creates variables for use within stored procedure and report display
            string storeCode = location.Split(',')[0];
            string storeDescription = location.Split(',')[1];

            // Create local objects
            SqlDataReader reader = null;
            ItemLookupByUPCModel item = new ItemLookupByUPCModel();

            if (location.Equals("001, La Crosse"))
            {
                // Connect to Host SMS and run Toolbox-ItemLookupByUPC stored procedure
                using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSLaxConnection"].ConnectionString })
                {
                    using (SqlCommand cmd = new SqlCommand("[Toolbox-ItemLookupByUPC]", con))
                    {
                        // Set the command type as a stored procedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Set the stored procedure parameters
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
                                item.ItemCode = reader["ItemCode"].ToString();
                                item.ItemBrand = reader["Brand"].ToString();
                                item.ItemDescription = reader["ReceiptDescription"].ToString();
                                item.ItemLongDesc = reader["LongDescription"].ToString();
                                item.ItemSize = reader["Size"].ToString();
                                item.ItemCategory = reader["Category"].ToString();
                                item.ItemReport = reader["Report"].ToString();
                                item.ItemSubdepartment = reader["Subdepartment"].ToString();
                                if (reader["Scalable"].ToString().Equals("0"))
                                    item.ItemScaled = "No";
                                else if (reader["Scalable"].ToString().Equals("1"))
                                    item.ItemScaled = "Yes";
                                if (reader["Tax"].ToString().Equals("0") || reader["Tax"].ToString().Equals(""))
                                    item.ItemTaxed = "No";
                                else if (reader["Tax"].ToString().Equals("1"))
                                    item.ItemTaxed = "Yes";
                                if (reader["FoodStamp"].ToString().Equals("0"))
                                    item.ItemFoodStamp = "No";
                                else if (reader["FoodStamp"].ToString().Equals("1"))
                                    item.ItemFoodStamp = "Yes";
                                if (!reader["RegularPrice"].ToString().Equals(""))
                                    item.ItemRegPrice = Decimal.Parse(reader["RegularPrice"].ToString());
                                if (!reader["TPRPrice"].ToString().Equals(""))
                                {
                                    item.ItemTPR = Decimal.Parse(reader["TPRPrice"].ToString());
                                    item.ItemStartTPR = DateTime.Parse(reader["TPRStart"].ToString());
                                    item.ItemEndTPR = DateTime.Parse(reader["TPREnd"].ToString());
                                    if (!reader["PackageTPR"].ToString().Equals(""))
                                        item.ItemPkgTPR = Decimal.Parse(reader["PackageTPR"].ToString());
                                }
                                if (!reader["PackagePrice"].ToString().Equals(""))
                                    item.ItemPkgPrice = Decimal.Parse(reader["PackagePrice"].ToString());
                                if (!reader["ActiveVendor"].ToString().Equals(""))
                                {
                                    item.ItemVendor = reader["ActiveVendor"].ToString();
                                    if (!reader["VendorCode"].ToString().Equals(""))
                                        item.ItemVendorCode = reader["VendorCode"].ToString();
                                    if (!reader["Cost"].ToString().Equals(""))
                                    {
                                        item.ItemCost = Decimal.Parse(reader["Cost"].ToString());
                                        if (item.ItemCost != 0)
                                            item.ItemMargin = ((item.ItemRegPrice - item.ItemCost) / item.ItemRegPrice) * 100;
                                    }
                                }
                            }
                        }
                        else item.ItemCode = "Item Not Found";

                        // Close connection to SQL server
                        con.Close();
                    }
                }

                // Add totals to ViewBag to be used in report display
                ViewBag.store = storeDescription;

                return PartialView("_ItemLookupByUPC", item);
            }
            else if (location.Equals("002, Rochester"))
            {
                // Connect to Host SMS and run Toolbox-ItemLookupByUPC stored procedure
                using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSRochConnection"].ConnectionString })
                {
                    using (SqlCommand cmd = new SqlCommand("[Toolbox-ItemLookupByUPC]", con))
                    {
                        // Set the command type as a stored procedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Set the stored procedure parameters
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
                                item.ItemCode = reader["ItemCode"].ToString();
                                item.ItemBrand = reader["Brand"].ToString();
                                item.ItemDescription = reader["ReceiptDescription"].ToString();
                                item.ItemLongDesc = reader["LongDescription"].ToString();
                                item.ItemSize = reader["Size"].ToString();
                                item.ItemCategory = reader["Category"].ToString();
                                item.ItemReport = reader["Report"].ToString();
                                item.ItemSubdepartment = reader["Subdepartment"].ToString();
                                if (reader["Scalable"].ToString().Equals("0"))
                                    item.ItemScaled = "No";
                                else if (reader["Scalable"].ToString().Equals("1"))
                                    item.ItemScaled = "Yes";
                                if (reader["Tax"].ToString().Equals("0") || reader["Tax"].ToString().Equals(""))
                                    item.ItemTaxed = "No";
                                else if (reader["Tax"].ToString().Equals("1"))
                                    item.ItemTaxed = "Yes";
                                if (reader["FoodStamp"].ToString().Equals("0"))
                                    item.ItemFoodStamp = "No";
                                else if (reader["FoodStamp"].ToString().Equals("1"))
                                    item.ItemFoodStamp = "Yes";
                                if (!reader["RegularPrice"].ToString().Equals(""))
                                    item.ItemRegPrice = Decimal.Parse(reader["RegularPrice"].ToString());
                                if (!reader["TPRPrice"].ToString().Equals(""))
                                {
                                    item.ItemTPR = Decimal.Parse(reader["TPRPrice"].ToString());
                                    item.ItemStartTPR = DateTime.Parse(reader["TPRStart"].ToString());
                                    item.ItemEndTPR = DateTime.Parse(reader["TPREnd"].ToString());
                                    if (!reader["PackageTPR"].ToString().Equals(""))
                                        item.ItemPkgTPR = Decimal.Parse(reader["PackageTPR"].ToString());
                                }
                                if (!reader["PackagePrice"].ToString().Equals(""))
                                    item.ItemPkgPrice = Decimal.Parse(reader["PackagePrice"].ToString());
                                if (!reader["ActiveVendor"].ToString().Equals(""))
                                {
                                    item.ItemVendor = reader["ActiveVendor"].ToString();
                                    if (!reader["VendorCode"].ToString().Equals(""))
                                        item.ItemVendorCode = reader["VendorCode"].ToString();
                                    if (!reader["Cost"].ToString().Equals(""))
                                    {
                                        item.ItemCost = Decimal.Parse(reader["Cost"].ToString());
                                        if (item.ItemCost != 0)
                                            item.ItemMargin = ((item.ItemRegPrice - item.ItemCost) / item.ItemRegPrice) * 100;
                                    }
                                }
                            }
                        }
                        else item.ItemCode = "Item Not Found";

                        // Close connection to SQL server
                        con.Close();
                    }
                }

                // Add totals to ViewBag to be used in report display
                ViewBag.store = storeDescription;

                return PartialView("_ItemLookupByUPC", item);
            }
            else
            {
                Response.Redirect("Error");
                return null;
            }
        }

        /*******************************************************************************************************************************************************************************************************************/

        // GET: /SMS/ItemLookupByDescription
        public ActionResult ItemLookupByDescription()
        {
            return View();
        }

        public ActionResult GetItemCodeInfoByDescription(string description, string location)
        {
            // Creates variables for use within stored procedure and report display
            string storeCode = location.Split(',')[0];
            string storeDescription = location.Split(',')[1];

            // Create local objects
            SqlDataReader reader = null;
            List<ItemLookupByDescriptionModel> report = new List<ItemLookupByDescriptionModel>();
            ItemLookupByDescriptionModel item = null;

            if (location.Equals("001, La Crosse"))
            {
                // Connect to Host SMS and run Toolbox-ItemLookupByDescription stored procedure
                using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSLaxConnection"].ConnectionString })
                {
                    using (SqlCommand cmd = new SqlCommand("[Toolbox-ItemLookupByDescription]", con))
                    {
                        // Set the command type as a stored procedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Set the stored procedure parameters
                        cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;

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

                                // Store results in PurchasesSummaryModel model
                                item = new ItemLookupByDescriptionModel();
                                item.ItemCode = reader["ItemCode"].ToString();
                                item.ItemBrand = reader["Brand"].ToString();
                                item.ItemDescription = reader["ReceiptDescription"].ToString();
                                item.ItemLongDesc = reader["LongDescription"].ToString();
                                item.ItemSize = reader["Size"].ToString();
                                item.ItemCategory = reader["Category"].ToString();
                                item.ItemReport = reader["Report"].ToString();
                                item.ItemSubdepartment = reader["Subdepartment"].ToString();

                                if (reader["Scalable"].ToString().Equals("0") || reader["Scalable"].ToString().Equals(""))
                                {
                                    item.ItemScaled = "No";
                                }
                                else if (reader["Scalable"].ToString().Equals("1"))
                                {
                                    item.ItemScaled = "Yes";
                                }

                                if (reader["Tax"].ToString().Equals("0") || reader["Tax"].ToString().Equals(""))
                                {
                                    item.ItemTaxed = "No";
                                }
                                else if (reader["Tax"].ToString().Equals("1"))
                                {
                                    item.ItemTaxed = "Yes";
                                }

                                if (reader["FoodStamp"].ToString().Equals("0") || reader["FoodStamp"].ToString().Equals(""))
                                {
                                    item.ItemFoodStamp = "No";
                                }
                                else if (reader["Tax"].ToString().Equals("1"))
                                {
                                    item.ItemFoodStamp = "Yes";
                                }

                                if (Decimal.TryParse(reader["RegularPrice"].ToString(), out tempDecimal))
                                {
                                    item.ItemRegPrice = tempDecimal;
                                }
                                else item.ItemRegPrice = 0;

                                if (!reader["TPRPrice"].ToString().Equals(""))
                                {
                                    if (Decimal.TryParse(reader["TPRPrice"].ToString(), out tempDecimal))
                                    {
                                        item.ItemTPR = tempDecimal;
                                    }
                                    else item.ItemTPR = 0;

                                    item.ItemStartTPR = reader["TPRStart"].ToString();
                                    item.ItemEndTPR = reader["TPREnd"].ToString();
                                    if (Decimal.TryParse(reader["PackageTPR"].ToString(), out tempDecimal))
                                    {
                                        item.ItemPkgTPR = tempDecimal;
                                    }
                                    else item.ItemPkgTPR = 0;
                                }

                                if (Decimal.TryParse(reader["PackagePrice"].ToString(), out tempDecimal))
                                {
                                    item.ItemPkgPrice = tempDecimal;
                                }
                                else item.ItemPkgPrice = 0;

                                if (!reader["ActiveVendor"].ToString().Equals(""))
                                {
                                    item.ItemVendor = reader["ActiveVendor"].ToString();
                                    if (!reader["VendorCode"].ToString().Equals(""))
                                    {
                                        item.ItemVendorCode = reader["VendorCode"].ToString();
                                    }
                                    if (!reader["Cost"].ToString().Equals(""))
                                    {
                                        if (Decimal.TryParse(reader["Cost"].ToString(), out tempDecimal))
                                        {
                                            item.ItemCost = tempDecimal;
                                        }
                                        else item.ItemCost = 0;
                                        if (item.ItemCost != 0)
                                        {
                                            if (item.ItemRegPrice != 0)
                                            {
                                                item.ItemMargin = ((item.ItemRegPrice - item.ItemCost) / item.ItemRegPrice) * 100;
                                            }
                                        }
                                    }
                                }

                                // Add results to list
                                report.Add(item);
                            }
                        }
                        else item.ItemCode = "Item Not Found";

                        // Close connection to SQL server
                        con.Close();
                    }
                }

                // Add totals to ViewBag to be used in report display
                ViewBag.store = storeDescription;

                return PartialView("_ItemLookupByDescription", report);
            }
            else if (location.Equals("002, Rochester"))
            {
                // Connect to Host SMS and run Toolbox-ItemLookupByDescription stored procedure
                using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSRochConnection"].ConnectionString })
                {
                    using (SqlCommand cmd = new SqlCommand("[Toolbox-ItemLookupByDescription]", con))
                    {
                        // Set the command type as a stored procedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Set the stored procedure parameters
                        cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;

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

                                // Store results in PurchasesSummaryModel model
                                item = new ItemLookupByDescriptionModel();
                                item.ItemCode = reader["ItemCode"].ToString();
                                item.ItemBrand = reader["Brand"].ToString();
                                item.ItemDescription = reader["ReceiptDescription"].ToString();
                                item.ItemLongDesc = reader["LongDescription"].ToString();
                                item.ItemSize = reader["Size"].ToString();
                                item.ItemCategory = reader["Category"].ToString();
                                item.ItemReport = reader["Report"].ToString();
                                item.ItemSubdepartment = reader["Subdepartment"].ToString();

                                if (reader["Scalable"].ToString().Equals("0") || reader["Scalable"].ToString().Equals(""))
                                {
                                    item.ItemScaled = "No";
                                }
                                else if (reader["Scalable"].ToString().Equals("1"))
                                {
                                    item.ItemScaled = "Yes";
                                }

                                if (reader["Tax"].ToString().Equals("0") || reader["Tax"].ToString().Equals(""))
                                {
                                    item.ItemTaxed = "No";
                                }
                                else if (reader["Tax"].ToString().Equals("1"))
                                {
                                    item.ItemTaxed = "Yes";
                                }

                                if (reader["FoodStamp"].ToString().Equals("0") || reader["FoodStamp"].ToString().Equals(""))
                                {
                                    item.ItemFoodStamp = "No";
                                }
                                else if (reader["Tax"].ToString().Equals("1"))
                                {
                                    item.ItemFoodStamp = "Yes";
                                }

                                if (Decimal.TryParse(reader["RegularPrice"].ToString(), out tempDecimal))
                                {
                                    item.ItemRegPrice = tempDecimal;
                                }
                                else item.ItemRegPrice = 0;

                                if (!reader["TPRPrice"].ToString().Equals(""))
                                {
                                    if (Decimal.TryParse(reader["TPRPrice"].ToString(), out tempDecimal))
                                    {
                                        item.ItemTPR = tempDecimal;
                                    }
                                    else item.ItemTPR = 0;

                                    item.ItemStartTPR = reader["TPRStart"].ToString();
                                    item.ItemEndTPR = reader["TPREnd"].ToString();
                                    if (Decimal.TryParse(reader["PackageTPR"].ToString(), out tempDecimal))
                                    {
                                        item.ItemPkgTPR = tempDecimal;
                                    }
                                    else item.ItemPkgTPR = 0;
                                }

                                if (Decimal.TryParse(reader["PackagePrice"].ToString(), out tempDecimal))
                                {
                                    item.ItemPkgPrice = tempDecimal;
                                }
                                else item.ItemPkgPrice = 0;

                                if (!reader["ActiveVendor"].ToString().Equals(""))
                                {
                                    item.ItemVendor = reader["ActiveVendor"].ToString();
                                    if (!reader["VendorCode"].ToString().Equals(""))
                                    {
                                        item.ItemVendorCode = reader["VendorCode"].ToString();
                                    }
                                    if (!reader["Cost"].ToString().Equals(""))
                                    {
                                        if (Decimal.TryParse(reader["Cost"].ToString(), out tempDecimal))
                                        {
                                            item.ItemCost = tempDecimal;
                                        }
                                        else item.ItemCost = 0;
                                        if (item.ItemCost != 0)
                                        {
                                            if (item.ItemRegPrice != 0)
                                            {
                                                item.ItemMargin = ((item.ItemRegPrice - item.ItemCost) / item.ItemRegPrice) * 100;
                                            }
                                        }
                                    }
                                }

                                // Add results to list
                                report.Add(item);
                            }
                        }
                        else item.ItemCode = "Item Not Found";

                        // Close connection to SQL server
                        con.Close();
                    }
                }

                // Add totals to ViewBag to be used in report display
                ViewBag.store = storeDescription;

                return PartialView("_ItemLookupByDescription", report);
            }
            else
            {
                Response.Redirect("Error");
                return null;
            }
        }
    }
}