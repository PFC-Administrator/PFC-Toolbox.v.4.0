using System.Web.Mvc;
using System.Data.SqlClient;

namespace PFC_Toolbox.v._4._0.Controllers
{
    public class NewProductController : Controller
    {   
        public void CreateNewProduct(string F01, string F155, string F29, string F22, string F255, int F17, int F16, int F18,  string F1000, int F04, string F02, string F79, string F178, string F1120, string F83, string F82, string F81, string F96, int F171, string F123, string F150,  float F30, int F126, float F31,  string F27, string F26, int F19, float F38)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=192.168.0.29\\SQLEXPRESS;Database=STORESQL;Trusted_Connection=false;uid=pfcit;pwd=pfcit";

            string query = " DECLARE @F01 varchar(13), @F155 varchar(30), @F29 varchar(60), @F22 varchar(30), @F255 varchar(120), @F17 int, @F16 int, @F18 int; "
                             + " SET @F01 = '" + F01 + "' "
                             + " SET @F155 = '" + F155 + "' "
                             + " IF @F155 = '' SET @F155 = NULL ELSE SET @F155 = '" + F155 + "'  "
                             + " SET @F29 = '" + F29 + "' "
                             + " SET @F22 = '" + F22 + "' "
                             + " IF @F22 = '' SET @F22 = NULL ELSE SET @F22 = '" + F22 + "'  "
                             + " SET @F255 = '" + F255 + "' "
                             + " SET @F17 = " + F17 + " "
                             + " SET @F16 =  " + F16 + "  "
                             + " IF @F16 = '' SET @F16 = NULL ELSE SET @F16 = '" + F16 + "'  "
                             + " SET @F18 = " + F18 + " "

                             + " INSERT INTO OBJ_TAB(F01, F16, F17, F18, F93, F193, F902, F1001, F07, F11, F12, F13, F14, F21, F22, F23, F29, F155, F180, F213, F214, F215, F218, F253, F255, F270, F1000, F1002, F1004, F1118, F1119, F1168, F1699, F1736, F1737, F1738, F1744, F1759, F1781, F1782, F1783, F1784, F1939, F1940, F1941, F1942, F1957, F1958, F1959, F1960, F1962, F1964, F2600, F2693, F2789, F2119, F940, F941) "
                             + " VALUES(@F01, @F16, @F17, @F18, null, null, 'TOOLBOX', '1', null, null, null, null, null, null, @F22, null, @F29, @F155, null, null, null, null, null, null, @F255, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '999', null, null, null, null, null, null); "

                         + " DECLARE @F1000 varchar(5), @F04 int, @F02 varchar(40), @F79 varchar(1), @F178 varchar(1), @F1120 varchar(12), @F83 varchar(1), @F82 varchar(1), @F81 varchar(1), @F96 varchar(1), @F171 int, @F123 varchar(13), @F150 varchar(1) "
                             + " SET @F1000 = 'PAL' "
                             + " SET @F04 = '" + F04 + "' "
                             + " SET @F02 = '" + F02 + "' "
                             + " SET @F79 = '" + F79 + "' "
                             + " IF @F79 = '' SET @F79 = NULL ELSE SET @F79 = '1'  "
                             + " SET @F178 = '" + F178 + "' "
                             + " IF @F178 = '' SET @F178 = NULL ELSE SET @F178 = '" + F178 + "'  "
                             + " SET @F1120 = '" + F1120 + "' "
                             + " IF @F1120 = '' SET @F1120 = NULL ELSE SET @F1120 = '" + F1120 + "'  "
                             + " SET @F83 = '" + F83 + "' "
                             + " IF @F83 = '' SET @F83 = NULL ELSE SET @F83 = '" + F83 + "'  "
                             + " SET @F82 = '" + F82 + "' "
                             + " IF @F82 = '' SET @F82 = NULL ELSE SET @F82 = '1'  "
                             + " SET @F81 = '" + F81 + "' "
                             + " IF @F81 = '' SET @F81 = NULL ELSE SET @F81 = '1'  "
                             + " SET @F96 = '" + F96 + "' "
                             + " IF @F96 = '' SET @F96 = NULL ELSE SET @F96 = '" + F96 + "'  "
                             + " SET @F171 = '" + F171 + "' "
                             + " IF @F171 = '' SET @F171 = NULL ELSE SET @F171 = '" + F171 + "'  "
                             + " SET @F123 = '" + F123 + "' "
                             + " IF @F123 = '' SET @F123 = NULL ELSE SET @F123 = '" + F123 + "'  "
                             + " SET @F150 = '" + F150 + "' "
                             + " IF @F150 = '' SET @F150 = NULL ELSE SET @F150 = '" + F150 + "'  "

                             + " INSERT INTO POS_TAB(F01, F1000, F04, F383, F902, F1001, F02, F03, F05, F06, F07, F08, F09, F24, F40, F50, F60, F61, F66, F77, F78, F79, F80, F81, F82, F83, F84, F85, F86, F87, F88, F92, F96, F97, F98, F99, F100, F101, F102, F104, F106, F107, F108, F110, F114, F115, F121, F123, F124, F125, F141, F149, F150, F153, F158, F159, F160, F161, F162, F163, F170, F171, F172, F173, F174, F176, F178, F188, F189, F209, F210, F211, F217, F253, F302, F303, F304, F306, F388, F397, F1099, F1120, F1124, F1136, F1138, F1139, F1236, F1237, F1735, F1759, F1785, F1786, F1787, F1788, F1789, F1790, F1892, F1926, F1929, F1933, F1964, F2608, F2660, F2119) "
                         
                             + " VALUES(@F01, @F1000, @F04, null, 'TOOLBOX', '1', @F02, null, null, null, null, null, null, null, null, null, null, null, null, null, null, @F79, null, @F81, @F82, @F83, null, null, null, null, null, null, @F96, null, null, null, null, null, null, null, null, null, null, null, null, null, null, @F123, null, null, null, null, @F150, null, null, null, null, null, null, null, null, @F171, null, null, null, null, @F178, null, null, null, null, null, null, null, null, null, null, null, null, null, null, @F1120, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '999', null, null, null); "

                         + " DECLARE @F30 money, @F126 int, @F31 float "
                             + " SET @F30 = '" + F30 + "' "
                             + " IF @F30 = '' SET @F30 = NULL ELSE SET @F30 = '" + F30 + "'  "
                             + " SET @F126 = '" + F126 + "' "
                             + " IF @F126 = '' SET @F126 = NULL ELSE SET @F126 = '1'  "
                             + " SET @F31 = '" + F31 + "' "
                             + " IF @F31 = '' SET @F31 = NULL ELSE SET @F31 = '1'  "

                             + " INSERT INTO PRICE_TAB(F01, F1000, F126, F32, F902, F1001, F1014, F07, F21, F30, F31, F33, F34, F35, F36, F37, F41, F42, F43, F49, F59, F62, F63, F109, F111, F112, F113, F119, F122, F129, F130, F133, F135, F136, F137, F138, F139, F140, F142, F143, F144, F145, F146, F147, F148, F164, F166, F167, F168, F169, F175, F177, F179, F181, F182, F183, F184, F205, F221, F232, F253, F903, F1005, F1006, F1007, F1008, F1009, F1010, F1011, F1012, F1013, F1015, F1133, F1134, F1135, F1186, F1187, F1188, F1189, F1190, F1191, F1192, F1193, F1194, F1195, F1196, F1197, F1198, F1199, F1200, F1201, F1202, F1203, F1204, F1205, F1206, F1207, F1208, F1209, F1210, F1211, F1212, F1213, F1214, F1215, F1216, F1217, F1218, F1219, F1220, F1221, F1222, F1223, F1224, F1225, F1226, F1227, F1228, F1229, F1230, F1231, F1232, F1233, F1234, F1235, F1713, F1714, F1759, F1767, F1768, F1769, F1770, F1799, F1800, F1801, F1802, F1803, F1804, F1805, F1806, F1885, F1927, F1928, F1930, F1934, F1935, F1964, F2569, F2570, F2571, F2572, F2573, F2574, F2575, F2576, F2577, F2578, F2579, F2580, F2667, F2668, F2694, F2695, F2696, F2744, F2119) "

                             + " VALUES(@F01, @F1000, @F126, null, 'TOOLBOX', '1', null, null, null, @F30, @F31, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '999', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null); "

                         + " DECLARE @F27 varchar(14), @F26 varchar(15), @F19 float, @F38 money "
                             + " SET @F27 = '" + F27 + "' "
                             + " IF @F27 = '' SET @F27 = NULL ELSE SET @F27 = '" + F27 + "'  "
                             + " SET @F26 = '" + F26 + "' "
                             + " IF @F26 = '' SET @F26 = NULL ELSE SET @F26 = '" + F26 + "'  "
                             + " SET @F19 = '" + F19 + "' "
                             + " IF @F19 IS NOT NULL SET @F19 = '" + F19 + "' ELSE SET @F19 = '1'  "
                             + " SET @F38 = '" + F38 + "' "
                             + " IF @F38 = '' SET @F38 = NULL ELSE SET @F38 = '" + F38 + "'  "

                             + " INSERT INTO COST_TAB(F01, F1000, F27, F1184, F26, F902, F1001, F07, F08, F19, F20, F28, F38, F39, F90, F120, F127, F131, F134, F151, F152, F156, F165, F185, F194, F195, F196, F201, F202, F203, F204, F212, F216, F219, F220, F222, F223, F224, F225, F226, F227, F228, F229, F230, F231, F233, F234, F235, F236, F237, F253, F325, F326, F327, F328, F329, F1037, F1038, F1121, F1122, F1140, F1168, F1657, F1658, F1659, F1660, F1661, F1662, F1663, F1664, F1665, F1666, F1667, F1668, F1669, F1670, F1685, F1759, F1760, F1761, F1766, F1791, F1792, F1793, F1794, F1795, F1796, F1797, F1798, F1875, F1887, F1961, F1964, F1973, F1974, F1975, F1976, F1977, F1978, F1979, F2566, F2567, F2568, F2601, F2624, F2626, F2628, F2666, F2699, F2119) "

                             + " VALUES(@F01, @F1000, @F27, 'CASE', @F26, 'TOOLBOX', '1', null, null, @F19, null, null, @F38, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '999', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null) ";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}