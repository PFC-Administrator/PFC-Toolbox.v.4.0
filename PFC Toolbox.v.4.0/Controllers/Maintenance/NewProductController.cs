using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class NewProductController : Controller
    {
        public void CreateNewProduct(
                // Required Parameters:
                int store, string UPC, string Brand, string ShortDescription, string Size, string LongDescription, int Category, int Report,
                int Subdepartment, string POSDescription,
                float Retail, int PriceLevel, float Quantity,
                string VendorID, string ReorderCode, int Case, float Cost,
                string Label,
                string Mettler,
                // Optional Parameters:
                string SNAP = null, string WIC = null, string Others = null, string ForcePrice = null, string Scalable = null, string Tax1 = null, string Tax2 = null, string PLU = null, string StopDiscount = null, int Family = 0, int ClientAge = 0,
                int Like = 0,
                string Ingredients1 = null, string Ingredients2 = null, string Ingredients3 = null, string Ingredients4 = null, string Ingredients5 = null, string Ingredients6 = null, string Ingredients7 = null, string Ingredients8 = null, string Ingredients9 = null, string Ingredients10 = null, string Ingredients11 = null, string Ingredients12 = null, string Ingredients13 = null,
                float Tare = 0, int ProdLife = 0, int TextLink = 0)
        {

            // Executes Toolbox-Add-NewProduct stored procedure located on La Crosse SMS SQL Server and provides parameters
            using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSLaxConnection"].ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand("[Toolbox-Add-NewProduct]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@F01", SqlDbType.VarChar).Value = UPC;
                    cmd.Parameters.Add("@F155", SqlDbType.VarChar).Value = Brand;
                    cmd.Parameters.Add("@F29", SqlDbType.VarChar).Value = ShortDescription;
                    cmd.Parameters.Add("@F22", SqlDbType.VarChar).Value = Size;
                    cmd.Parameters.Add("@F255", SqlDbType.VarChar).Value = LongDescription;
                    cmd.Parameters.Add("@F17", SqlDbType.Int).Value = Category;
                    cmd.Parameters.Add("@F16", SqlDbType.Int).Value = Family;
                    cmd.Parameters.Add("@F18", SqlDbType.Int).Value = Report;
                    cmd.Parameters.Add("@F1000", SqlDbType.VarChar).Value = "PAL";
                    cmd.Parameters.Add("@F04", SqlDbType.Int).Value = Subdepartment;
                    cmd.Parameters.Add("@F02", SqlDbType.VarChar).Value = POSDescription;
                    cmd.Parameters.Add("@F79", SqlDbType.VarChar).Value = SNAP;
                    cmd.Parameters.Add("@F178", SqlDbType.VarChar).Value = WIC;
                    cmd.Parameters.Add("@F1120", SqlDbType.VarChar).Value = Others;
                    cmd.Parameters.Add("@F83", SqlDbType.VarChar).Value = ForcePrice;
                    cmd.Parameters.Add("@F82", SqlDbType.VarChar).Value = Scalable;
                    cmd.Parameters.Add("@F81", SqlDbType.VarChar).Value = Tax1;
                    cmd.Parameters.Add("@F96", SqlDbType.VarChar).Value = Tax2;
                    cmd.Parameters.Add("@F171", SqlDbType.Int).Value = ClientAge;
                    cmd.Parameters.Add("@F123", SqlDbType.VarChar).Value = PLU;
                    cmd.Parameters.Add("@F150", SqlDbType.VarChar).Value = StopDiscount;
                    cmd.Parameters.Add("@F30", SqlDbType.Money).Value = Retail;
                    cmd.Parameters.Add("@F126", SqlDbType.Int).Value = PriceLevel;
                    cmd.Parameters.Add("@F31", SqlDbType.Float).Value = Quantity;
                    cmd.Parameters.Add("@F122", SqlDbType.Int).Value = Like;
                    cmd.Parameters.Add("@F27", SqlDbType.VarChar).Value = VendorID;
                    cmd.Parameters.Add("@F26", SqlDbType.VarChar).Value = ReorderCode;
                    cmd.Parameters.Add("@F19", SqlDbType.Float).Value = Case;
                    cmd.Parameters.Add("@F38", SqlDbType.Money).Value = Cost;
                    cmd.Parameters.Add("@F95", SqlDbType.VarChar).Value = Label;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Executes Toolbox-Add - NewProduct stored procedure located on Rochester SMS SQL Server and provides parameters
            using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSRochConnection"].ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand("[Toolbox-Add-NewProduct]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@F01", SqlDbType.VarChar).Value = UPC;
                    cmd.Parameters.Add("@F155", SqlDbType.VarChar).Value = Brand;
                    cmd.Parameters.Add("@F29", SqlDbType.VarChar).Value = ShortDescription;
                    cmd.Parameters.Add("@F22", SqlDbType.VarChar).Value = Size;
                    cmd.Parameters.Add("@F255", SqlDbType.VarChar).Value = LongDescription;
                    cmd.Parameters.Add("@F17", SqlDbType.Int).Value = Category;
                    cmd.Parameters.Add("@F16", SqlDbType.Int).Value = Family;
                    cmd.Parameters.Add("@F18", SqlDbType.Int).Value = Report;
                    cmd.Parameters.Add("@F1000", SqlDbType.VarChar).Value = "PAL";
                    cmd.Parameters.Add("@F04", SqlDbType.Int).Value = Subdepartment;
                    cmd.Parameters.Add("@F02", SqlDbType.VarChar).Value = POSDescription;
                    cmd.Parameters.Add("@F79", SqlDbType.VarChar).Value = SNAP;
                    cmd.Parameters.Add("@F178", SqlDbType.VarChar).Value = WIC;
                    cmd.Parameters.Add("@F1120", SqlDbType.VarChar).Value = Others;
                    cmd.Parameters.Add("@F83", SqlDbType.VarChar).Value = ForcePrice;
                    cmd.Parameters.Add("@F82", SqlDbType.VarChar).Value = Scalable;
                    cmd.Parameters.Add("@F81", SqlDbType.VarChar).Value = Tax1;
                    cmd.Parameters.Add("@F96", SqlDbType.VarChar).Value = Tax2;
                    cmd.Parameters.Add("@F171", SqlDbType.Int).Value = ClientAge;
                    cmd.Parameters.Add("@F123", SqlDbType.VarChar).Value = PLU;
                    cmd.Parameters.Add("@F150", SqlDbType.VarChar).Value = StopDiscount;
                    cmd.Parameters.Add("@F30", SqlDbType.Money).Value = Retail;
                    cmd.Parameters.Add("@F126", SqlDbType.Int).Value = PriceLevel;
                    cmd.Parameters.Add("@F31", SqlDbType.Float).Value = Quantity;
                    cmd.Parameters.Add("@F122", SqlDbType.Int).Value = Like;
                    cmd.Parameters.Add("@F27", SqlDbType.VarChar).Value = VendorID;
                    cmd.Parameters.Add("@F26", SqlDbType.VarChar).Value = ReorderCode;
                    cmd.Parameters.Add("@F19", SqlDbType.Float).Value = Case;
                    cmd.Parameters.Add("@F38", SqlDbType.Money).Value = Cost;
                    cmd.Parameters.Add("@F95", SqlDbType.VarChar).Value = Label;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Executes Toolbox-Add-ScaleInfo stored procedure located on Host SMS SQL Server and provides parameters
            if (Mettler.Equals("Yes"))
            {
                using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSHostConnection"].ConnectionString })
                {
                    using (SqlCommand cmd = new SqlCommand("[Toolbox-Add-ScaleInfo]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@F01", SqlDbType.VarChar).Value = UPC;
                        cmd.Parameters.Add("@F155", SqlDbType.VarChar).Value = Brand;
                        cmd.Parameters.Add("@F256", SqlDbType.VarChar).Value = LongDescription;
                        cmd.Parameters.Add("@F258", SqlDbType.Float).Value = Tare * 1000;
                        cmd.Parameters.Add("@F264", SqlDbType.Int).Value = ProdLife;
                        cmd.Parameters.Add("@F267", SqlDbType.Int).Value = TextLink;
                        cmd.Parameters.Add("@F04", SqlDbType.Int).Value = Subdepartment;
                        cmd.Parameters.Add("@F1836", SqlDbType.VarChar).Value = LongDescription;
                        cmd.Parameters.Add("@F297", SqlDbType.VarChar).Value = Ingredients1;
                        cmd.Parameters.Add("@F1837", SqlDbType.VarChar).Value = Ingredients2;
                        cmd.Parameters.Add("@F1838", SqlDbType.VarChar).Value = Ingredients3;
                        cmd.Parameters.Add("@F1839", SqlDbType.VarChar).Value = Ingredients4;
                        cmd.Parameters.Add("@F1853", SqlDbType.VarChar).Value = Ingredients5;
                        cmd.Parameters.Add("@F1854", SqlDbType.VarChar).Value = Ingredients6;
                        cmd.Parameters.Add("@F1855", SqlDbType.VarChar).Value = Ingredients7;
                        cmd.Parameters.Add("@F1856", SqlDbType.VarChar).Value = Ingredients8;
                        cmd.Parameters.Add("@F1968", SqlDbType.VarChar).Value = Ingredients9;
                        cmd.Parameters.Add("@F1969", SqlDbType.VarChar).Value = Ingredients10;
                        cmd.Parameters.Add("@F1970", SqlDbType.VarChar).Value = Ingredients11;
                        cmd.Parameters.Add("@F1971", SqlDbType.VarChar).Value = Ingredients12;
                        cmd.Parameters.Add("@F1972", SqlDbType.VarChar).Value = Ingredients12;

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // Executes Toolbox-Queue-Label stored procedure located on store argument given; 1 for La Crosse, 2 for Rochester, or both stores.
            if (!Label.Equals("5 - No Label - Do Not Print"))
            {
                if (store == 1)
                {
                    using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSLaxConnection"].ConnectionString })
                    {
                        using (SqlCommand cmd = new SqlCommand("[Toolbox-Queue-Label]", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@F01", SqlDbType.VarChar).Value = UPC;
                            cmd.Parameters.Add("@F155", SqlDbType.VarChar).Value = Brand;
                            cmd.Parameters.Add("@F29", SqlDbType.VarChar).Value = ShortDescription;
                            cmd.Parameters.Add("@F22", SqlDbType.VarChar).Value = Size;
                            cmd.Parameters.Add("@F255", SqlDbType.VarChar).Value = LongDescription;
                            cmd.Parameters.Add("@F17", SqlDbType.Int).Value = Category;
                            cmd.Parameters.Add("@F18", SqlDbType.Int).Value = Report;
                            cmd.Parameters.Add("@F04", SqlDbType.Int).Value = Subdepartment;
                            cmd.Parameters.Add("@F02", SqlDbType.VarChar).Value = POSDescription;
                            cmd.Parameters.Add("@F82", SqlDbType.VarChar).Value = Scalable;
                            cmd.Parameters.Add("@F30", SqlDbType.Money).Value = Retail;
                            cmd.Parameters.Add("@F126", SqlDbType.Int).Value = PriceLevel;
                            cmd.Parameters.Add("@F31", SqlDbType.Float).Value = Quantity;
                            cmd.Parameters.Add("@F95", SqlDbType.VarChar).Value = Label;

                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else if (store == 2)
                {
                    using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSRochConnection"].ConnectionString })
                    {
                        using (SqlCommand cmd = new SqlCommand("[Toolbox-Queue-Label]", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@F01", SqlDbType.VarChar).Value = UPC;
                            cmd.Parameters.Add("@F155", SqlDbType.VarChar).Value = Brand;
                            cmd.Parameters.Add("@F29", SqlDbType.VarChar).Value = ShortDescription;
                            cmd.Parameters.Add("@F22", SqlDbType.VarChar).Value = Size;
                            cmd.Parameters.Add("@F255", SqlDbType.VarChar).Value = LongDescription;
                            cmd.Parameters.Add("@F17", SqlDbType.Int).Value = Category;
                            cmd.Parameters.Add("@F18", SqlDbType.Int).Value = Report;
                            cmd.Parameters.Add("@F04", SqlDbType.Int).Value = Subdepartment;
                            cmd.Parameters.Add("@F02", SqlDbType.VarChar).Value = POSDescription;
                            cmd.Parameters.Add("@F82", SqlDbType.VarChar).Value = Scalable;
                            cmd.Parameters.Add("@F30", SqlDbType.Money).Value = Retail;
                            cmd.Parameters.Add("@F126", SqlDbType.Int).Value = PriceLevel;
                            cmd.Parameters.Add("@F31", SqlDbType.Float).Value = Quantity;
                            cmd.Parameters.Add("@F95", SqlDbType.VarChar).Value = Label;

                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSLaxConnection"].ConnectionString })
                    {
                        using (SqlCommand cmd = new SqlCommand("[Toolbox-Queue-Label]", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@F01", SqlDbType.VarChar).Value = UPC;
                            cmd.Parameters.Add("@F155", SqlDbType.VarChar).Value = Brand;
                            cmd.Parameters.Add("@F29", SqlDbType.VarChar).Value = ShortDescription;
                            cmd.Parameters.Add("@F22", SqlDbType.VarChar).Value = Size;
                            cmd.Parameters.Add("@F255", SqlDbType.VarChar).Value = LongDescription;
                            cmd.Parameters.Add("@F17", SqlDbType.Int).Value = Category;
                            cmd.Parameters.Add("@F18", SqlDbType.Int).Value = Report;
                            cmd.Parameters.Add("@F04", SqlDbType.Int).Value = Subdepartment;
                            cmd.Parameters.Add("@F02", SqlDbType.VarChar).Value = POSDescription;
                            cmd.Parameters.Add("@F82", SqlDbType.VarChar).Value = Scalable;
                            cmd.Parameters.Add("@F30", SqlDbType.Money).Value = Retail;
                            cmd.Parameters.Add("@F126", SqlDbType.Int).Value = PriceLevel;
                            cmd.Parameters.Add("@F31", SqlDbType.Float).Value = Quantity;
                            cmd.Parameters.Add("@F95", SqlDbType.VarChar).Value = Label;

                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    using (SqlConnection con = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SMSRochConnection"].ConnectionString })
                    {
                        using (SqlCommand cmd = new SqlCommand("[Toolbox-Queue-Label]", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@F01", SqlDbType.VarChar).Value = UPC;
                            cmd.Parameters.Add("@F155", SqlDbType.VarChar).Value = Brand;
                            cmd.Parameters.Add("@F29", SqlDbType.VarChar).Value = ShortDescription;
                            cmd.Parameters.Add("@F22", SqlDbType.VarChar).Value = Size;
                            cmd.Parameters.Add("@F255", SqlDbType.VarChar).Value = LongDescription;
                            cmd.Parameters.Add("@F17", SqlDbType.Int).Value = Category;
                            cmd.Parameters.Add("@F18", SqlDbType.Int).Value = Report;
                            cmd.Parameters.Add("@F04", SqlDbType.Int).Value = Subdepartment;
                            cmd.Parameters.Add("@F02", SqlDbType.VarChar).Value = POSDescription;
                            cmd.Parameters.Add("@F82", SqlDbType.VarChar).Value = Scalable;
                            cmd.Parameters.Add("@F30", SqlDbType.Money).Value = Retail;
                            cmd.Parameters.Add("@F126", SqlDbType.Int).Value = PriceLevel;
                            cmd.Parameters.Add("@F31", SqlDbType.Float).Value = Quantity;
                            cmd.Parameters.Add("@F95", SqlDbType.VarChar).Value = Label;

                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}