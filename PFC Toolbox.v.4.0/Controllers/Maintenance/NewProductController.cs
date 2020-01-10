using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class NewProductController : Controller
    {
        public void CreateNewProduct(string UPC, string Brand, string ShortDescription, string Size, string LongDescription, int Category, int Family, int Report,
                                     int Subdepartment, string POSDescription, string SNAP, string WIC, string Others, string ForcePrice, string Scalable, string Tax1, string Tax2, int ClientAge, string PLU, string StopDiscount,
                                     float Retail, int PriceLevel, float Quantity,
                                     string VendorID, string ReorderCode, int Case, float Cost,
                                     string Label,
                                     string Mettler,
                                     string Ingredients1 = null, string Ingredients2 = null, string Ingredients3 = null, string Ingredients4 = null, string Ingredients5 = null, string Ingredients6 = null, string Ingredients7 = null, string Ingredients8 = null, string Ingredients9 = null, string Ingredients10 = null, string Ingredients11 = null, string Ingredients12 = null, string Ingredients13 = null,
                                     float Tare = 0, int ProdLife = 0, int TextLink = 0)
        {
            // Export all basic new product info to La Crosse SMS
            SqlConnection con1 = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["SMSLaxConnection"].ConnectionString
            };
                            // OBJ_TAB
            string query1 = " DECLARE @F01 varchar(13), @F155 varchar(30), @F29 varchar(60), @F22 varchar(30), @F255 varchar(120), @F17 int, @F16 int, @F18 int; "
                             + " SET @F01 = '" + UPC + "' "
                             + " SET @F155 = '" + Brand + "' "
                             + " IF @F155 = '' SET @F155 = NULL ELSE SET @F155 = '" + Brand + "'  "
                             + " SET @F29 = '" + ShortDescription + "' "
                             + " SET @F22 = '" + Size + "' "
                             + " IF @F22 = '' SET @F22 = NULL ELSE SET @F22 = '" + Size + "'  "
                             + " SET @F255 = '" + LongDescription + "' "
                             + " SET @F17 = " + Category + " "
                             + " IF @F17 = '' SET @F17 = NULL ELSE SET @F17 = '" + Category + "'  "
                             + " SET @F16 =  " + Family + "  "
                             + " IF @F16 = '' SET @F16 = NULL ELSE SET @F16 = '" + Family + "'  "
                             + " SET @F18 = " + Report + " "

                             + " INSERT INTO OBJ_TAB(F01, F16, F17, F18, F93, F193, F902, F1001, F07, F11, F12, F13, F14, F21, F22, F23, F29, F155, F180, F213, F214, F215, F218, F253, F255, F270, F1000, F1002, F1004, F1118, F1119, F1168, F1699, F1736, F1737, F1738, F1744, F1759, F1781, F1782, F1783, F1784, F1939, F1940, F1941, F1942, F1957, F1958, F1959, F1960, F1962, F1964, F2600, F2693, F2789, F2119, F940, F941) "

                             + " VALUES(@F01, @F16, @F17, @F18, null, null, 'TOOLBOX', '1', null, null, null, null, null, null, @F22, null, @F29, @F155, null, null, null, null, null, null, @F255, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '001', null, null, null, null, null, null); "

                            // POS_TAB
                         + " DECLARE @F1000 varchar(5), @F04 int, @F02 varchar(40), @F79 varchar(1), @F178 varchar(1), @F1120 varchar(12), @F83 varchar(1), @F82 varchar(1), @F81 varchar(1), @F96 varchar(1), @F171 int, @F123 varchar(13), @F150 varchar(1); "
                             + " SET @F1000 = 'PAL' "
                             + " SET @F04 = '" + Subdepartment + "' "
                             + " SET @F02 = '" + POSDescription + "' "
                             + " SET @F79 = '" + SNAP + "' "
                             + " IF @F79 = '' SET @F79 = NULL ELSE SET @F79 = '1'  "
                             + " SET @F178 = '" + WIC + "' "
                             + " IF @F178 = '' SET @F178 = NULL ELSE SET @F178 = '" + WIC + "'  "
                             + " SET @F1120 = '" + Others + "' "
                             + " IF @F1120 = '' SET @F1120 = NULL ELSE SET @F1120 = '" + Others + "'  "
                             + " SET @F83 = '" + ForcePrice + "' "
                             + " IF @F83 = '' SET @F83 = NULL ELSE SET @F83 = '" + ForcePrice + "'  "
                             + " SET @F82 = '" + Scalable + "' "
                             + " IF @F82 = '' SET @F82 = NULL ELSE SET @F82 = '1'  "
                             + " SET @F81 = '" + Tax1 + "' "
                             + " IF @F81 = '' SET @F81 = NULL ELSE SET @F81 = '1'  "
                             + " SET @F96 = '" + Tax2 + "' "
                             + " IF @F96 = '' SET @F96 = NULL ELSE SET @F96 = '" + Tax2 + "'  "
                             + " SET @F171 = '" + ClientAge + "' "
                             + " IF @F171 = '' SET @F171 = NULL ELSE SET @F171 = '" + ClientAge + "'  "
                             + " SET @F123 = '" + PLU + "' "
                             + " IF @F123 = '' SET @F123 = NULL ELSE SET @F123 = '" + PLU + "'  "
                             + " SET @F150 = '" + StopDiscount + "' "
                             + " IF @F150 = '' SET @F150 = NULL ELSE SET @F150 = '" + '1' + "'  "

                             + " INSERT INTO POS_TAB(F01, F1000, F04, F383, F902, F1001, F02, F03, F05, F06, F07, F08, F09, F24, F40, F50, F60, F61, F66, F77, F78, F79, F80, F81, F82, F83, F84, F85, F86, F87, F88, F92, F96, F97, F98, F99, F100, F101, F102, F104, F106, F107, F108, F110, F114, F115, F121, F123, F124, F125, F141, F149, F150, F153, F158, F159, F160, F161, F162, F163, F170, F171, F172, F173, F174, F176, F178, F188, F189, F209, F210, F211, F217, F253, F302, F303, F304, F306, F388, F397, F1099, F1120, F1124, F1136, F1138, F1139, F1236, F1237, F1735, F1759, F1785, F1786, F1787, F1788, F1789, F1790, F1892, F1926, F1929, F1933, F1964, F2608, F2660, F2119) "

                             + " VALUES(@F01, @F1000, @F04, null, 'TOOLBOX', '1', @F02, null, null, null, null, null, null, null, null, null, null, null, null, null, null, @F79, null, @F81, @F82, @F83, null, null, null, null, null, null, @F96, null, null, null, null, null, null, null, null, null, null, null, null, null, null, @F123, null, null, null, null, @F150, null, null, null, null, null, null, null, null, @F171, null, null, null, null, @F178, null, null, null, null, null, null, null, null, null, null, null, null, null, null, @F1120, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '001', null, null, null); "

                            // PRICE_TAB
                         + " DECLARE @F30 money, @F126 int, @F31 float; "
                             + " SET @F30 = '" + Retail + "' "
                             + " IF @F30 = '' SET @F30 = NULL ELSE SET @F30 = '" + Retail + "'  "
                             + " SET @F126 = '" + PriceLevel + "' "
                             + " IF @F126 = '' SET @F126 = NULL ELSE SET @F126 = '1'  "
                             + " SET @F31 = '" + Quantity + "' "
                             + " IF @F31 = '' SET @F31 = NULL ELSE SET @F31 = '1'  "

                             + " INSERT INTO PRICE_TAB(F01, F1000, F126, F32, F902, F1001, F1014, F07, F21, F30, F31, F33, F34, F35, F36, F37, F41, F42, F43, F49, F59, F62, F63, F109, F111, F112, F113, F119, F122, F129, F130, F133, F135, F136, F137, F138, F139, F140, F142, F143, F144, F145, F146, F147, F148, F164, F166, F167, F168, F169, F175, F177, F179, F181, F182, F183, F184, F205, F221, F232, F253, F903, F1005, F1006, F1007, F1008, F1009, F1010, F1011, F1012, F1013, F1015, F1133, F1134, F1135, F1186, F1187, F1188, F1189, F1190, F1191, F1192, F1193, F1194, F1195, F1196, F1197, F1198, F1199, F1200, F1201, F1202, F1203, F1204, F1205, F1206, F1207, F1208, F1209, F1210, F1211, F1212, F1213, F1214, F1215, F1216, F1217, F1218, F1219, F1220, F1221, F1222, F1223, F1224, F1225, F1226, F1227, F1228, F1229, F1230, F1231, F1232, F1233, F1234, F1235, F1713, F1714, F1759, F1767, F1768, F1769, F1770, F1799, F1800, F1801, F1802, F1803, F1804, F1805, F1806, F1885, F1927, F1928, F1930, F1934, F1935, F1964, F2569, F2570, F2571, F2572, F2573, F2574, F2575, F2576, F2577, F2578, F2579, F2580, F2667, F2668, F2694, F2695, F2696, F2744, F2119) "

                             + " VALUES(@F01, @F1000, @F126, null, 'TOOLBOX', '1', null, null, null, @F30, @F31, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '001', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null); "

                            // COST_TAB
                         + " DECLARE @F27 varchar(14), @F26 varchar(15), @F19 float, @F38 money; "
                             + " SET @F27 = '" + VendorID + "' "
                             + " IF @F27 = '' SET @F27 = NULL ELSE SET @F27 = '" + VendorID + "'  "
                             + " SET @F26 = '" + ReorderCode + "' "
                             + " IF @F26 = '' SET @F26 = NULL ELSE SET @F26 = '" + ReorderCode + "'  "
                             + " SET @F19 = '" + Case + "' "
                             + " IF @F19 IS NOT NULL SET @F19 = '" + Case + "' ELSE SET @F19 = '1'  "
                             + " SET @F38 = '" + Cost + "' "
                             + " IF @F38 = '' SET @F38 = NULL ELSE SET @F38 = '" + Cost + "'  "

                             + " INSERT INTO COST_TAB(F01, F1000, F27, F1184, F26, F902, F1001, F07, F08, F19, F20, F28, F38, F39, F90, F120, F127, F131, F134, F151, F152, F156, F165, F185, F194, F195, F196, F201, F202, F203, F204, F212, F216, F219, F220, F222, F223, F224, F225, F226, F227, F228, F229, F230, F231, F233, F234, F235, F236, F237, F253, F325, F326, F327, F328, F329, F1037, F1038, F1121, F1122, F1140, F1168, F1657, F1658, F1659, F1660, F1661, F1662, F1663, F1664, F1665, F1666, F1667, F1668, F1669, F1670, F1685, F1759, F1760, F1761, F1766, F1791, F1792, F1793, F1794, F1795, F1796, F1797, F1798, F1875, F1887, F1961, F1964, F1973, F1974, F1975, F1976, F1977, F1978, F1979, F2566, F2567, F2568, F2601, F2624, F2626, F2628, F2666, F2699, F2119) "

                             + " VALUES(@F01, @F1000, @F27, 'CASE', @F26, 'TOOLBOX', '1', null, null, @F19, null, null, @F38, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '001', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null) "

                            // LABEL_TAB
                         + " DECLARE @F95 varchar(80); "
                             + " SET @F95 = '" + Label + "' "

                         + " INSERT INTO LABEL_TAB(F1148, F95, F01, F126, F02, F04, F05, F08, F16, F17, F18, F19, F21, F22, F23, F24, F25, F26, F27, F29, F30, F31, F32, F33, F35, F36, F38, F62, F63, F81, F82, F94, F96, F97, F98, F105, F111, F112, F113, F117, F129, F130, F140, F142, F154, F155, F164, F166, F167, F168, F169, F253, F255, F902, F903, F1030, F1184, F1301, F1302, F1401, F1402, F1744, F1806, F2588) "

                         + " VALUES('PAL', @F95, @F01, @F126, @F02, @F04, null, null, null, @F17, @F18, null, '1' , @F22, null, null, null, null, null, @F29, @F30, @F31, null, null, null, null, null, null, null, null, @F82, '1', null, null, null, null, null, null, 'BOX', null, null, null, null, null, null, @F155, null, null, null, null, null, null, @F255, null, null, null, null, null, null, null, null, null, null, null); ";

            SqlCommand cmd1 = new SqlCommand(query1, con1);
            con1.Open();
            cmd1.ExecuteNonQuery();
            con1.Close();
            
            // Export all basic new product info to Rochester SMS
            //    SqlConnection con2 = new SqlConnection
            //    {
            //        ConnectionString = ConfigurationManager.ConnectionStrings["SMSRochConnection"].ConnectionString
            //    };

            //string query2 = " DECLARE @F01 varchar(13), @F155 varchar(30), @F29 varchar(60), @F22 varchar(30), @F255 varchar(120), @F17 int, @F16 int, @F18 int; "
            //                 + " SET @F01 = '" + UPC + "' "
            //                 + " SET @F155 = '" + Brand + "' "
            //                 + " IF @F155 = '' SET @F155 = NULL ELSE SET @F155 = '" + Brand + "'  "
            //                 + " SET @F29 = '" + ShortDescription + "' "
            //                 + " SET @F22 = '" + Size + "' "
            //                 + " IF @F22 = '' SET @F22 = NULL ELSE SET @F22 = '" + Size + "'  "
            //                 + " SET @F255 = '" + LongDescription + "' "
            //                 + " SET @F17 = " + Category + " "
            //                 + " IF @F17 = '' SET @F17 = NULL ELSE SET @F17 = '" + Category + "'  "
            //                 + " SET @F16 =  " + Family + "  "
            //                 + " IF @F16 = '' SET @F16 = NULL ELSE SET @F16 = '" + Family + "'  "
            //                 + " SET @F18 = " + Report + " "

            //                 + " INSERT INTO OBJ_TAB(F01, F16, F17, F18, F93, F193, F902, F1001, F07, F11, F12, F13, F14, F21, F22, F23, F29, F155, F180, F213, F214, F215, F218, F253, F255, F270, F1000, F1002, F1004, F1118, F1119, F1168, F1699, F1736, F1737, F1738, F1744, F1759, F1781, F1782, F1783, F1784, F1939, F1940, F1941, F1942, F1957, F1958, F1959, F1960, F1962, F1964, F2600, F2693, F2789, F2119, F940, F941) "

            //                 + " VALUES(@F01, @F16, @F17, @F18, null, null, 'TOOLBOX', '1', null, null, null, null, null, null, @F22, null, @F29, @F155, null, null, null, null, null, null, @F255, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '002', null, null, null, null, null, null); "

            //             + " DECLARE @F1000 varchar(5), @F04 int, @F02 varchar(40), @F79 varchar(1), @F178 varchar(1), @F1120 varchar(12), @F83 varchar(1), @F82 varchar(1), @F81 varchar(1), @F96 varchar(1), @F171 int, @F123 varchar(13), @F150 varchar(1); "
            //                 + " SET @F1000 = 'PAL' "
            //                 + " SET @F04 = '" + Subdepartment + "' "
            //                 + " SET @F02 = '" + POSDescription + "' "
            //                 + " SET @F79 = '" + SNAP + "' "
            //                 + " IF @F79 = '' SET @F79 = NULL ELSE SET @F79 = '1'  "
            //                 + " SET @F178 = '" + WIC + "' "
            //                 + " IF @F178 = '' SET @F178 = NULL ELSE SET @F178 = '" + WIC + "'  "
            //                 + " SET @F1120 = '" + Others + "' "
            //                 + " IF @F1120 = '' SET @F1120 = NULL ELSE SET @F1120 = '" + Others + "'  "
            //                 + " SET @F83 = '" + ForcePrice + "' "
            //                 + " IF @F83 = '' SET @F83 = NULL ELSE SET @F83 = '" + ForcePrice + "'  "
            //                 + " SET @F82 = '" + Scalable + "' "
            //                 + " IF @F82 = '' SET @F82 = NULL ELSE SET @F82 = '1'  "
            //                 + " SET @F81 = '" + Tax1 + "' "
            //                 + " IF @F81 = '' SET @F81 = NULL ELSE SET @F81 = '1'  "
            //                 + " SET @F96 = '" + Tax2 + "' "
            //                 + " IF @F96 = '' SET @F96 = NULL ELSE SET @F96 = '" + Tax2 + "'  "
            //                 + " SET @F171 = '" + ClientAge + "' "
            //                 + " IF @F171 = '' SET @F171 = NULL ELSE SET @F171 = '" + ClientAge + "'  "
            //                 + " SET @F123 = '" + PLU + "' "
            //                 + " IF @F123 = '' SET @F123 = NULL ELSE SET @F123 = '" + PLU + "'  "
            //                 + " SET @F150 = '" + StopDiscount + "' "
            //                 + " IF @F150 = '' SET @F150 = NULL ELSE SET @F150 = '" + '1' + "'  "

            //                 + " INSERT INTO POS_TAB(F01, F1000, F04, F383, F902, F1001, F02, F03, F05, F06, F07, F08, F09, F24, F40, F50, F60, F61, F66, F77, F78, F79, F80, F81, F82, F83, F84, F85, F86, F87, F88, F92, F96, F97, F98, F99, F100, F101, F102, F104, F106, F107, F108, F110, F114, F115, F121, F123, F124, F125, F141, F149, F150, F153, F158, F159, F160, F161, F162, F163, F170, F171, F172, F173, F174, F176, F178, F188, F189, F209, F210, F211, F217, F253, F302, F303, F304, F306, F388, F397, F1099, F1120, F1124, F1136, F1138, F1139, F1236, F1237, F1735, F1759, F1785, F1786, F1787, F1788, F1789, F1790, F1892, F1926, F1929, F1933, F1964, F2608, F2660, F2119) "

            //                 + " VALUES(@F01, @F1000, @F04, null, 'TOOLBOX', '1', @F02, null, null, null, null, null, null, null, null, null, null, null, null, null, null, @F79, null, @F81, @F82, @F83, null, null, null, null, null, null, @F96, null, null, null, null, null, null, null, null, null, null, null, null, null, null, @F123, null, null, null, null, @F150, null, null, null, null, null, null, null, null, @F171, null, null, null, null, @F178, null, null, null, null, null, null, null, null, null, null, null, null, null, null, @F1120, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '002', null, null, null); "

            //             + " DECLARE @F30 money, @F126 int, @F31 float; "
            //                 + " SET @F30 = '" + Retail + "' "
            //                 + " IF @F30 = '' SET @F30 = NULL ELSE SET @F30 = '" + Retail + "'  "
            //                 + " SET @F126 = '" + PriceLevel + "' "
            //                 + " IF @F126 = '' SET @F126 = NULL ELSE SET @F126 = '1'  "
            //                 + " SET @F31 = '" + Quantity + "' "
            //                 + " IF @F31 = '' SET @F31 = NULL ELSE SET @F31 = '1'  "

            //                 + " INSERT INTO PRICE_TAB(F01, F1000, F126, F32, F902, F1001, F1014, F07, F21, F30, F31, F33, F34, F35, F36, F37, F41, F42, F43, F49, F59, F62, F63, F109, F111, F112, F113, F119, F122, F129, F130, F133, F135, F136, F137, F138, F139, F140, F142, F143, F144, F145, F146, F147, F148, F164, F166, F167, F168, F169, F175, F177, F179, F181, F182, F183, F184, F205, F221, F232, F253, F903, F1005, F1006, F1007, F1008, F1009, F1010, F1011, F1012, F1013, F1015, F1133, F1134, F1135, F1186, F1187, F1188, F1189, F1190, F1191, F1192, F1193, F1194, F1195, F1196, F1197, F1198, F1199, F1200, F1201, F1202, F1203, F1204, F1205, F1206, F1207, F1208, F1209, F1210, F1211, F1212, F1213, F1214, F1215, F1216, F1217, F1218, F1219, F1220, F1221, F1222, F1223, F1224, F1225, F1226, F1227, F1228, F1229, F1230, F1231, F1232, F1233, F1234, F1235, F1713, F1714, F1759, F1767, F1768, F1769, F1770, F1799, F1800, F1801, F1802, F1803, F1804, F1805, F1806, F1885, F1927, F1928, F1930, F1934, F1935, F1964, F2569, F2570, F2571, F2572, F2573, F2574, F2575, F2576, F2577, F2578, F2579, F2580, F2667, F2668, F2694, F2695, F2696, F2744, F2119) "

            //                 + " VALUES(@F01, @F1000, @F126, null, 'TOOLBOX', '1', null, null, null, @F30, @F31, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '002', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null); "

            //             + " DECLARE @F27 varchar(14), @F26 varchar(15), @F19 float, @F38 money; "
            //                 + " SET @F27 = '" + VendorID + "' "
            //                 + " IF @F27 = '' SET @F27 = NULL ELSE SET @F27 = '" + VendorID + "'  "
            //                 + " SET @F26 = '" + ReorderCode + "' "
            //                 + " IF @F26 = '' SET @F26 = NULL ELSE SET @F26 = '" + ReorderCode + "'  "
            //                 + " SET @F19 = '" + Case + "' "
            //                 + " IF @F19 IS NOT NULL SET @F19 = '" + Case + "' ELSE SET @F19 = '1'  "
            //                 + " SET @F38 = '" + Cost + "' "
            //                 + " IF @F38 = '' SET @F38 = NULL ELSE SET @F38 = '" + Cost + "'  "

            //                 + " INSERT INTO COST_TAB(F01, F1000, F27, F1184, F26, F902, F1001, F07, F08, F19, F20, F28, F38, F39, F90, F120, F127, F131, F134, F151, F152, F156, F165, F185, F194, F195, F196, F201, F202, F203, F204, F212, F216, F219, F220, F222, F223, F224, F225, F226, F227, F228, F229, F230, F231, F233, F234, F235, F236, F237, F253, F325, F326, F327, F328, F329, F1037, F1038, F1121, F1122, F1140, F1168, F1657, F1658, F1659, F1660, F1661, F1662, F1663, F1664, F1665, F1666, F1667, F1668, F1669, F1670, F1685, F1759, F1760, F1761, F1766, F1791, F1792, F1793, F1794, F1795, F1796, F1797, F1798, F1875, F1887, F1961, F1964, F1973, F1974, F1975, F1976, F1977, F1978, F1979, F2566, F2567, F2568, F2601, F2624, F2626, F2628, F2666, F2699, F2119) "

            //                 + " VALUES(@F01, @F1000, @F27, 'CASE', @F26, 'TOOLBOX', '1', null, null, @F19, null, null, @F38, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '002', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null) "

            //             + " DECLARE @F95 varchar(80); "
            //                 + " SET @F95 = '" + Label + "' "

            //             + " INSERT INTO LABEL_TAB(F1148, F95, F01, F126, F02, F04, F05, F08, F16, F17, F18, F19, F21, F22, F23, F24, F25, F26, F27, F29, F30, F31, F32, F33, F35, F36, F38, F62, F63, F81, F82, F94, F96, F97, F98, F105, F111, F112, F113, F117, F129, F130, F140, F142, F154, F155, F164, F166, F167, F168, F169, F253, F255, F902, F903, F1030, F1184, F1301, F1302, F1401, F1402, F1744, F1806, F2588) "

            //             + " VALUES('PAL', @F95, @F01, @F126, @F02, @F04, null, null, null, @F17, @F18, null, '1' , @F22, null, null, null, null, null, @F29, @F30, @F31, null, null, null, null, null, null, null, null, @F82, '1', null, null, null, null, null, null, 'BOX', null, null, null, null, null, null, @F155, null, null, null, null, null, null, @F255, null, null, null, null, null, null, null, null, null, null, null); ";

            //SqlCommand cmd2 = new SqlCommand(query2, con2);
            //con2.Open();
            //cmd2.ExecuteNonQuery();
            //con2.Close();

            // Export new product's scale info directly to Host SMS, if it's a mettler product.
            // Tare, ProdLife, and TextLink are optional parameters with default values assigned to them at method declaration.
            if (Mettler.Equals("Yes"))
            {
                SqlConnection con3 = new SqlConnection
                {
                    // Change to host
                    ConnectionString = ConfigurationManager.ConnectionStrings["SMSHostConnection"].ConnectionString
                };
                                // SCL_TAB
                string query3 = " DECLARE @F01 varchar(13), @F155 varchar(30), @F256 varchar(120), @F258 float, @F264 int, @F267 int, @F04 int;"
                                + " SET @F01 = '" + UPC + "' "
                                + " SET @F155 = '" + Brand + "' "
                                + " SET @F256 = '" + LongDescription + "' "
                                + " SET @F04 = '" + Subdepartment + "' "
                                + " IF @F256 = '' SET @F256 = '-' ELSE SET @F256 = '" + LongDescription + "'  "
                                + " SET @F258 = '" + Tare + "' "
                                + " IF @F258 = '' SET @F258 = NULL ELSE SET @F258 = '" + Tare + "'  "
                                + " SET @F264 = '" + ProdLife + "' "
                                + " IF @F264 = '' SET @F264 = NULL ELSE SET @F264 = '" + ProdLife + "'  "
                                + " SET @F267 = '" + TextLink + "' "
                                + " IF @F267 = '' SET @F267 = NULL ELSE SET @F267 = '" + TextLink + "'  "

                                + " INSERT INTO SCL_TAB(F01, F1000, F902, F1001, F253, F256, F257, F258, F259, F260, F261, F262, F263, F264, F265, F266, F267, F268, F269, F270, F271, F272, F273, F274, F275, F1759, F1840, F1952, F1964, F2581, F2582, F2583, F2584, F2585, F2586, F2792, F2793, F2796, F2797, F2799, F2800, F2801, F2939, F2940, F2941, F2942, F2944, F2945, F2946, F2947, F2948, F2949, F2950, F2952) "

                                + " VALUES(@F01, 'PAL', 'MANUAL', '1', null, @F256, null, @F258, null, null, null, null, null, @F264, null, null, @F267, null, null, null, null, null, null, null, null, null, null, @F155, '999', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null); "

                                // SCL_TXT_TAB
                              + " DECLARE @F297 varchar(251), @F1836 varchar(40), @F1837 varchar(251), @F1838 varchar(251), @F1839 varchar(251), @F1853 varchar(251), @F1854 varchar(251), @F1855 varchar(251), @F1856 varchar(251), @F1968 varchar(251), @F1969 varchar(251), @F1970 varchar(251), @F1971 varchar(251), @F1972 varchar(251); "
                                + " SET @F297 = '" + Ingredients1 + "' "
                                + " IF  @F297 = '' SET @F297 = NULL ELSE SET  @F297 = '" + Ingredients1 + "'  "
                                + " SET @F1837 = '" + Ingredients2 + "' "
                                + " IF @F1837 = '' SET @F1837 = NULL ELSE SET @F1837 = '" + Ingredients2 + "'  "
                                + " SET @F1838 = '" + Ingredients3 + "' "
                                + " IF @F1838 = '' SET @F1838 = NULL ELSE SET @F1838 = '" + Ingredients3 + "'  "
                                + " SET @F1839 = '" + Ingredients4 + "' "
                                + " IF @F1839 = '' SET @F1839 = NULL ELSE SET @F1839 = '" + Ingredients4 + "'  "
                                + " SET @F1853 = '" + Ingredients5 + "' "
                                + " IF @F1853 = '' SET @F1853 = NULL ELSE SET @F1853 = '" + Ingredients5 + "'  "
                                + " SET @F1854 = '" + Ingredients6 + "' "
                                + " IF @F1854 = '' SET @F1854 = NULL ELSE SET @F1854 = '" + Ingredients6 + "'  "
                                + " SET @F1855 = '" + Ingredients7 + "' "
                                + " IF @F1855 = '' SET @F1855 = NULL ELSE SET @F1855 = '" + Ingredients7 + "'  "
                                + " SET @F1856 = '" + Ingredients8 + "' "
                                + " IF @F1856 = '' SET @F1856 = NULL ELSE SET @F1856 = '" + Ingredients8 + "'  "
                                + " SET @F1968 = '" + Ingredients9 + "' "
                                + " IF @F1968 = '' SET @F1968 = NULL ELSE SET @F1968 = '" + Ingredients9 + "'  "
                                + " SET @F1969 = '" + Ingredients10 + "' "
                                + " IF @F1969 = '' SET @F1969 = NULL ELSE SET @F1969 = '" + Ingredients10 + "'  "
                                + " SET @F1970 = '" + Ingredients11 + "' "
                                + " IF @F1970 = '' SET @F1970 = NULL ELSE SET @F1970 = '" + Ingredients11 + "'  "
                                + " SET @F1971 = '" + Ingredients12 + "' "
                                + " IF @F1971 = '' SET @F1971 = NULL ELSE SET @F1971 = '" + Ingredients12 + "'  "
                                + " SET @F1972 = '" + Ingredients13 + "' "
                                + " IF @F1972 = '' SET @F1972 = NULL ELSE SET @F1972 = '" + Ingredients13 + "'  "

                                + " SET @F1836 = '" + LongDescription + "' "

                                + " INSERT INTO SCL_TXT_TAB(F267, F1000, F04, F253, F297, F902, F1001, F1517, F1518, F1519, F1759, F1836, F1837, F1838, F1839, F1853, F1854, F1855, F1856, F1964, F1968, F1969, F1970, F1971, F1972, F2943) "

                                + " VALUES(@F267, 'PAL', @F04, null, @F297, 'TOOLBOX', '0', null, null, null, null, @F1836, @F1837, @F1838, @F1839, @F1853, @F1854, @F1855, @F1856, '999', @F1968, @F1969, @F1970, @F1971, @F1972, null);  ";

                SqlCommand cmd3 = new SqlCommand(query3, con3);
                con3.Open();
                cmd3.ExecuteNonQuery();
                con3.Close();
            }
        }
    }
}