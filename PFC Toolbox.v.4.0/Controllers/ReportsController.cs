using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PFC_Toolbox.v._4._0.Models;
using System.Data.SqlClient;
using DataTables;

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

        public ActionResult GetItemSingleTotal(string location, string UPC, string startDate, string endDate, string store)
        {

            store = location.Split(',')[1];

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
            string connect = "Data Source=192.168.0.29\\SQLEXPRESS;Database=STORESQL;Trusted_Connection=false;uid=pfcit;pwd=pfcit";
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

        public ActionResult GetItemSingleTotalbySubdepartment(string location, string subdept, string startDate, string endDate, string sdpCode, string sdpDesc, string store)
        {
            sdpCode = subdept.Split(',')[0];
            sdpDesc = subdept.Split(',')[1];
            store = location.Split(',')[1];

            // create end subdept
            string endSDP = "";
            if (sdpCode == "0")
            {
                endSDP = "999";
            }
            else endSDP = sdpCode;

            // create local objects
            SqlDataReader reader = null;
            List<ItemSingleTotalbySubdepartmentModel> report = new List<ItemSingleTotalbySubdepartmentModel>();
            ItemSingleTotalbySubdepartmentModel item = null;
            decimal totalAmount = 0;
            double totalQty = 0, totalUnits = 0;


            // set query
            string query = "declare @StartDate DateTime "
                                    + " declare @EndDate DateTime "
                                    + " declare @sTarget char(3) "
                                    + " declare @StartSDP int "
                                    + " declare @EndSDP int "
                                    + " set @StartDate = '" + startDate.ToString() + "'"
                                    + " set @EndDate = '" + endDate.ToString() + "' "
                                    + " set @sTarget = '" + location + "' "
                                    + " set @StartSDP = " + sdpCode + " "
                                    + " set @EndSDP = " + endSDP + " "
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
                                    + " and POS.F04 between @StartSDP and @EndSDP "
                                    + " and POS.F1000=(SELECT TOP 1 SUB_POS.F1000  "
                                    + "             FROM POS_TAB SUB_POS  "
                                    + "             JOIN LNK_TAB SUB_LNK ON SUB_POS.F1000=SUB_LNK.F1000  "
                                    + "             JOIN LNK_TAB SUB_LNK2 ON SUB_LNK.F1056=SUB_LNK2.F1056 AND SUB_LNK.F1057=SUB_LNK2.F1057 AND SUB_LNK2.F1000=@sTarget  "
                                    + "             JOIN STO_TAB SUB_STO ON SUB_LNK.F1000=SUB_STO.F1000  "
                                    + "             WHERE SUB_POS.F01=POS.F01 ORDER BY SUB_STO.F1937 DESC) "
                                    + " group by SDP.F04, TRS.F01 order by SDP.F04, MAX(OBJ.F155), MAX(OBJ.F29) ";

            // open db connection
            string connect = "Data Source=192.168.0.29\\SQLEXPRESS;Database=STORESQL;Trusted_Connection=false;uid=pfcit;pwd=pfcit";
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
                            item = new ItemSingleTotalbySubdepartmentModel();
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
            ViewBag.sdpCode = sdpCode;
            ViewBag.sdpDesc = sdpDesc;
            ViewBag.store = store;

            // return results
            return PartialView("_ItemSingleTotalbySubdepartment", report);

        } // end GetItemSingleTotalbySubdepartment


/*******************************************************************************************************************************************************************************************************************/


        // GET: /Reports/CTMSubdepartment
        public ActionResult CTMSubdepartment()
        {
            return View();
        }

        public ActionResult GetCTMSubdepartment(string location, string subdept, string startDate, string endDate, string sdpCode, string sdpDesc, string store)
        {

            sdpCode = subdept.Split(',')[0];
            sdpDesc = subdept.Split(',')[1];
            store = location.Split(',')[1];

            // create end subdept
            string endSDP = "";
            if (sdpCode == "0")
            {
                endSDP = "999";
            }
            else endSDP = sdpCode;

            // create local objects
            SqlDataReader reader = null;
            List<CTMSubdepartmentModel> report = new List<CTMSubdepartmentModel>();
            CTMSubdepartmentModel item = null;
            decimal totalAmount = 0;
            double totalWeight = 0, totalUnits = 0;

            // set query
            string query = " DECLARE @StartDate DateTime "
                         + " DECLARE @EndDate DateTime "
                         + " DECLARE @sTarget char(3) "
                         + " DECLARE @StartSDP int "
                         + " DECLARE @EndSDP int "
                         + " SET @StartDate = '" + startDate.ToString() + "'"
                         + " SET @EndDate = '" + endDate.ToString() + "' "
                         + " SET @sTarget = '" + location + "' "
                         + " SET @StartSDP = " + sdpCode + " "
                         + " SET @EndSDP = " + endSDP + " "
                         + " SELECT TRS.F01 AS 'UPC', "
                         + " 	   MAX(OBJ.F155) AS 'Brand', "
                         + " 	   MAX(POS.F02) AS 'Description', "
                         + " 	   SUM(CASE WHEN TRS.F67=0 THEN 0 ELSE TRS.F64 END) AS 'Weight', "
                         + " 	   SUM(CASE WHEN TRS.F67=0 THEN TRS.F64 ELSE TRS.F67 END) AS 'Quantity', "
                         + " 	   SUM(TRS.F65) AS 'Total Sales', "
                         + " 	   MAX(PRI.F30) AS 'Retail', "
                         + " 	   MAX(COST.F1140) AS 'Cost', "
                         + " 	   MAX(COST.F27) AS 'Vendor ID', "
                         + " 	   MAX(VEND.F334) AS 'Vendor', "
                         + " 	   MAX(COST.F26) AS 'Reorder', "
                         + " 	   SUM(TRS.F65) / NULLIF((SELECT SUM(TRS.F65) "
                         + " 					   FROM RPT_ITM_D TRS "
                         + " 					   INNER JOIN OBJ_TAB OBJ on TRS.F01=OBJ.F01 "
                         + " 					   INNER JOIN TLZ_TAB TLZ on TRS.F1034=TLZ.F1034 "
                         + " 					   INNER JOIN POS_TAB POS on TRS.F01=POS.F01 "
                         + " 					   INNER JOIN PRICE_TAB PRI ON TRS.F01=PRI.F01 AND PRI.F1000 = @sTarget "
                         + " 					   INNER JOIN COST_TAB COST ON TRS.F01=COST.F01 AND (COST.F1000 = @sTarget or COST.F1000 = 'PAL') AND (COST.F90 IS NULL OR COST.F90 = '1') "
                         + " 					   INNER JOIN VENDOR_TAB VEND ON COST.F27=VEND.F27 "
                         + " 					   INNER JOIN SDP_TAB SDP on POS.F04=SDP.F04 "
                         + " 					   INNER JOIN LNK_TAB LNK on TRS.F1056=LNK.F1056 AND TRS.F1057=LNK.F1057 AND LNK.F1000= @sTarget "
                         + " 					   WHERE TRS.F254 BETWEEN @StartDate AND @ENDDate "
                         + " 						AND TRS.F1034 BETWEEN 3 AND 4 "
                         + " 						AND POS.F04 BETWEEN @StartSDP AND @ENDSDP "
                         + " 						AND POS.F1000 = (SELECT TOP 1 SUB_POS.F1000  "
                         + " 										 FROM POS_TAB SUB_POS  "
                         + " 						JOIN LNK_TAB SUB_LNK ON SUB_POS.F1000=SUB_LNK.F1000  "
                         + " 						JOIN LNK_TAB SUB_LNK2 ON SUB_LNK.F1056=SUB_LNK2.F1056 AND SUB_LNK.F1057=SUB_LNK2.F1057 AND SUB_LNK2.F1000= @sTarget  "
                         + " 						JOIN STO_TAB SUB_STO ON SUB_LNK.F1000=SUB_STO.F1000  "
                         + " 						WHERE SUB_POS.F01=POS.F01 ORDER BY SUB_STO.F1937 DESC)), 0) AS '% of Sales', "
                         + " 	   (1 - (MAX(COST.F1140) / NULLIF(MAX(PRI.F30), 0))) AS 'Applied Margin', "
                         + " 	   ((SUM(TRS.F65) - (SUM(CASE WHEN TRS.F67 = 0 THEN TRS.F64 ELSE TRS.F67 END) * MAX(COST.F1140))) / NULLIF((SELECT SUM(TRS.F65) "
                         + " FROM RPT_ITM_D TRS "
                         + " 		INNER JOIN OBJ_TAB OBJ on TRS.F01=OBJ.F01 "
                         + " 		INNER JOIN TLZ_TAB TLZ on TRS.F1034=TLZ.F1034 "
                         + " 		INNER JOIN POS_TAB POS on TRS.F01=POS.F01 "
                         + " 		INNER JOIN PRICE_TAB PRI ON TRS.F01=PRI.F01 AND PRI.F1000 = @sTarget "
                         + " 		INNER JOIN COST_TAB COST ON TRS.F01=COST.F01 AND (COST.F1000 = @sTarget or COST.F1000 = 'PAL') AND (COST.F90 IS NULL OR COST.F90 = '1') "
                         + " 		INNER JOIN VENDOR_TAB VEND ON COST.F27=VEND.F27 "
                         + " 		INNER JOIN SDP_TAB SDP on POS.F04=SDP.F04 "
                         + " 		INNER JOIN LNK_TAB LNK on TRS.F1056=LNK.F1056 AND TRS.F1057=LNK.F1057 AND LNK.F1000= @sTarget "
                         + " WHERE TRS.F254 BETWEEN @StartDate AND @ENDDate "
                         + " 		AND TRS.F1034 BETWEEN 3 AND 4 "
                         + " 		AND POS.F04 BETWEEN @StartSDP AND @ENDSDP "
                         + " 		AND POS.F1000=(SELECT TOP 1 SUB_POS.F1000  "
                         + " 						FROM POS_TAB SUB_POS  "
                         + " 						JOIN LNK_TAB SUB_LNK ON SUB_POS.F1000=SUB_LNK.F1000  "
                         + " 						JOIN LNK_TAB SUB_LNK2 ON SUB_LNK.F1056=SUB_LNK2.F1056 AND SUB_LNK.F1057=SUB_LNK2.F1057 AND SUB_LNK2.F1000= @sTarget  "
                         + " 						JOIN STO_TAB SUB_STO ON SUB_LNK.F1000=SUB_STO.F1000  "
                         + " 						WHERE SUB_POS.F01=POS.F01 ORDER BY SUB_STO.F1937 DESC)), 0)) AS 'CTM' "
                         + " 	    "
                         + " FROM RPT_ITM_D TRS "
                         + " 		INNER JOIN OBJ_TAB OBJ on TRS.F01=OBJ.F01 "
                         + " 		INNER JOIN TLZ_TAB TLZ on TRS.F1034=TLZ.F1034 "
                         + " 		INNER JOIN POS_TAB POS on TRS.F01=POS.F01 "
                         + " 		INNER JOIN PRICE_TAB PRI ON TRS.F01=PRI.F01 AND PRI.F1000 = @sTarget "
                         + " 		INNER JOIN COST_TAB COST ON TRS.F01=COST.F01 AND (COST.F1000 = @sTarget or COST.F1000 = 'PAL') AND (COST.F90 IS NULL OR COST.F90 = '1') "
                         + " 		INNER JOIN VENDOR_TAB VEND ON COST.F27=VEND.F27 "
                         + " 		INNER JOIN SDP_TAB SDP on POS.F04=SDP.F04 "
                         + " 		INNER JOIN LNK_TAB LNK on TRS.F1056=LNK.F1056 AND TRS.F1057=LNK.F1057 AND LNK.F1000= @sTarget "
                         + " WHERE TRS.F254 BETWEEN @StartDate AND @ENDDate "
                         + " 		AND TRS.F1034 BETWEEN 3 AND 4 "
                         + " 		AND POS.F04 BETWEEN @StartSDP AND @ENDSDP "
                         + " 		AND POS.F1000=(SELECT TOP 1 SUB_POS.F1000  "
                         + " 						FROM POS_TAB SUB_POS  "
                         + " 						JOIN LNK_TAB SUB_LNK ON SUB_POS.F1000=SUB_LNK.F1000  "
                         + " 						JOIN LNK_TAB SUB_LNK2 ON SUB_LNK.F1056=SUB_LNK2.F1056 AND SUB_LNK.F1057=SUB_LNK2.F1057 AND SUB_LNK2.F1000= @sTarget  "
                         + " 						JOIN STO_TAB SUB_STO ON SUB_LNK.F1000=SUB_STO.F1000  "
                         + " 						WHERE SUB_POS.F01=POS.F01 ORDER BY SUB_STO.F1937 DESC) "
                         + " GROUP BY SDP.F04, TRS.F01";

            // open db connection
            string connect = "Data Source=192.168.0.29\\SQLEXPRESS;Database=STORESQL;Trusted_Connection=false;uid=pfcit;pwd=pfcit";
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
                            item = new CTMSubdepartmentModel();
                            item.ItemCode = reader["UPC"].ToString();
                            item.ItemBrand = reader["Brand"].ToString();
                            item.ItemDescription = reader["Description"].ToString();
                            if (!reader["Weight"].ToString().Equals(""))
                            {
                                item.SalesWeight = Double.Parse(reader["Weight"].ToString());
                            }
                            else item.SalesWeight = 0; // end if
                            if (!reader["Total Sales"].ToString().Equals(""))
                            {
                                item.SalesAmount = Decimal.Parse(reader["Total Sales"].ToString());
                            }
                            else item.SalesAmount = 0; // end if
                            if (!reader["Quantity"].ToString().Equals(""))
                            {
                                item.SalesQuantity = Double.Parse(reader["Quantity"].ToString());
                            }
                            else item.SalesQuantity = 0; // end if
                            item.SalesRetail = Decimal.Parse(reader["Retail"].ToString());
                            if (!reader["Cost"].ToString().Equals(""))
                            {
                                item.SalesCost = Decimal.Parse(reader["Cost"].ToString());
                            }
                            else item.SalesCost = 0; // end if
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
                            if (!reader["% of Sales"].ToString().Equals(""))
                            {
                                item.SalesPercent = Decimal.Parse(reader["% of Sales"].ToString());
                            }
                            else item.SalesPercent = 0; // end if                            
                            if (!reader["Applied Margin"].ToString().Equals(""))
                            {
                                item.SalesAppliedMargin = Decimal.Parse(reader["Applied Margin"].ToString());
                            }
                            else item.SalesAppliedMargin = 0; // end if
                            if (!reader["CTM"].ToString().Equals(""))
                            {
                                item.SalesCTM = Decimal.Parse(reader["CTM"].ToString());
                            }
                            else item.SalesCTM = 0; // end if
                            totalWeight = totalWeight + item.SalesWeight;
                            totalAmount = totalAmount + item.SalesAmount;
                            totalUnits = totalUnits + item.SalesQuantity;
                            report.Add(item);
                        } // end while
                    } // end if reader.hasrows

                    // close conn
                    conn.Close();

                } // end sqlcommand
            } // end sqlconnection

            // add totals to ViewBag
            ViewBag.TotalWeight = totalWeight;
            ViewBag.TotalAmount = totalAmount;
            ViewBag.TotalUnits = totalUnits;
            ViewBag.sdpCode = sdpCode;
            ViewBag.sdpDesc = sdpDesc;
            ViewBag.store = store;

            // return results
            return PartialView("_CTMSubdepartment", report);

        } // end GetCTMSubdepartment
    }
}