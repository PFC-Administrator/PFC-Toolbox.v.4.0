using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PFC_Toolbox.v._4._0.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using PFC_Toolbox.v._4._0.Models.SMS;

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
            else if (location.Equals("002, Rochester")){
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

        public ActionResult GetItemCodeInfoByDescription(string UPCs, string location)
        {
            // Creates variables for use within stored procedure and report display
            string storeCode = location.Split(',')[0];
            string storeDescription = location.Split(',')[1];

            // Create local objects
            SqlDataReader reader = null;
            ItemLookupByDescriptionModel item = new ItemLookupByDescriptionModel();

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

                return PartialView("_ItemLookupByDescription", item);
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

                return PartialView("_ItemLookupByDescription", item);
            }
            else
            {
                Response.Redirect("Error");
                return null;
            }
        }
    }
}

//        // GET: /SMS/ItemVendorCodeLookup
//        public ActionResult ItemVendorCodeLookup()
//        {
//            return View();
//        }

//        // ItemVendorCodeLookup
//        public ActionResult GetItemVendorCodeInfo(string itemcode, string location)
//        {
//            ItemCodeInfo item = new ItemCodeInfo();
//            SqlDataReader reader = null;

//            // get the item id code
//            string itemID = itemcode;

//            // get location code
//            string Location = location;

//            // set query
//            string query = "select top 1 OBJ.F01 ItemCode, OBJ.F155 Brand, OBJ.F29 ReceiptDescription, "
//                + " OBJ.F255 LongDescription, OBJ.F22 Size, CAT.F1023 Category, RPT.F1024 Report, OBJ.F193 Location, SDP.F1022 Subdepartment, "
//                + " case when POS.F106=1 then SDP.F82 else POS.F82 end Scalable, "
//                + " case when POS.F106=1 then SDP.F81 else POS.F81 end Tax, "
//                + " case when POS.F106=1 then SDP.F79 else POS.F79 end FoodStamp, "
//                + " PRICE.F30 RegularPrice, PRICE.F181 TPRPrice, PRICE.F183 TPRStart, PRICE.F184 TPREnd, "
//                + " PRICE.F140 PackagePrice, PRICE.F1186 PackageTPR, VENDOR.F334 ActiveVendor, COST.F26 VendorCode, COST.F1140 Cost "
//                + " from OBJ_TAB OBJ left join CAT_TAB CAT on OBJ.F17=CAT.F17 left join POS_TAB POS on OBJ.F01=POS.F01 "
//                + " left join SDP_TAB SDP on POS.F04=SDP.F04 left join PRICE_TAB PRICE on OBJ.F01=PRICE.F01 "
//                + " left join COST_TAB COST on OBJ.F01=COST.F01 left join VENDOR_TAB VENDOR on COST.F27=VENDOR.F27 "
//                + " left join RPC_TAB RPT on OBJ.F18=RPT.F18 "
//                + " where COST.F26 LIKE '%" + itemID + "%' and PRICE.F126=1 "
//                + " and (POS.F1000='" + Location + "' or POS.F1000='PAL')"
//                + " and (PRICE.F1000='" + Location + "' or PRICE.F1000='PAL')"
//                + " and (COST.F1000='" + Location + "' or COST.F1000='PAL')"
//                + " order by POS.F1000 asc, PRICE.F1000 asc, COST.F1000 asc, COST.F90 desc";

//            // open db connection
//            string connect = "Data Source=192.168.0.29\\SQLEXPRESS;Database=STORESQL;Trusted_Connection=false;uid=pfcit;pwd=pfcit";
//            using (SqlConnection conn = new SqlConnection(connect))
//            {
//                using (SqlCommand cmd = new SqlCommand(query, conn))
//                {
//                    // add itemID to SQL query
//                    //cmd.Parameters.AddWithValue("ITEMID",itemID);
//                    conn.Open();

//                    // run query against db
//                    reader = cmd.ExecuteReader();

//                    // save query results to item
//                    if (reader.HasRows)
//                    {
//                        while (reader.Read())
//                        {
//                            item.ItemCode = reader["ItemCode"].ToString();
//                            item.ItemBrand = reader["Brand"].ToString();
//                            item.ItemDescription = reader["ReceiptDescription"].ToString();
//                            item.ItemLongDesc = reader["LongDescription"].ToString();
//                            item.ItemSize = reader["Size"].ToString();
//                            item.ItemCategory = reader["Category"].ToString();
//                            item.ItemReport = reader["Report"].ToString();
//                            item.ItemLocation = reader["Location"].ToString();
//                            item.ItemSubdepartment = reader["Subdepartment"].ToString();
//                            if (reader["Scalable"].ToString().Equals("0"))
//                                item.ItemScaled = "No";
//                            else if (reader["Scalable"].ToString().Equals("1"))
//                                item.ItemScaled = "Yes";
//                            if (reader["Tax"].ToString().Equals("0"))
//                                item.ItemTaxed = "No";
//                            else if (reader["Tax"].ToString().Equals("1"))
//                                item.ItemTaxed = "Yes";
//                            if (reader["FoodStamp"].ToString().Equals("0"))
//                                item.ItemFoodStamp = "No";
//                            else if (reader["FoodStamp"].ToString().Equals("1"))
//                                item.ItemFoodStamp = "Yes";
//                            if (!reader["RegularPrice"].ToString().Equals(""))
//                                item.ItemRegPrice = Decimal.Parse(reader["RegularPrice"].ToString());
//                            if (!reader["TPRPrice"].ToString().Equals(""))
//                            {
//                                item.ItemTPR = Decimal.Parse(reader["TPRPrice"].ToString());
//                                item.ItemStartTPR = DateTime.Parse(reader["TPRStart"].ToString());
//                                item.ItemEndTPR = DateTime.Parse(reader["TPREnd"].ToString());
//                                if (!reader["PackageTPR"].ToString().Equals(""))
//                                    item.ItemPkgTPR = Decimal.Parse(reader["PackageTPR"].ToString());
//                            }
//                            if (!reader["PackagePrice"].ToString().Equals(""))
//                                item.ItemPkgPrice = Decimal.Parse(reader["PackagePrice"].ToString());
//                            if (!reader["ActiveVendor"].ToString().Equals(""))
//                            {
//                                item.ItemVendor = reader["ActiveVendor"].ToString();
//                                if (!reader["VendorCode"].ToString().Equals(""))
//                                    item.ItemVendorCode = reader["VendorCode"].ToString();
//                                if (!reader["Cost"].ToString().Equals(""))
//                                {
//                                    item.ItemCost = Decimal.Parse(reader["Cost"].ToString());
//                                    if (item.ItemCost != 0)
//                                        item.ItemMargin = ((item.ItemRegPrice - item.ItemCost) / item.ItemRegPrice) * 100;
//                                }
//                            }
//                        }// end while
//                    } // end if
//                    else item.ItemCode = "Item Not Found";

//                    // close connection to db
//                    conn.Close();

//                } // end using cmd

//            } // end using conn

//            return PartialView("_ItemVendorCodeResults", item);

//        } // end GetItemVendorCodeInfo

//    }

//}
