using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class DiaDiemDL
    {
        public int ID { get; set; }
        public string TenDD { get; set; }
        public string QuocGia { get; set; }

        public static DiaDiemDL Single(int _ID)
        {
            return CBO.FillObject<DiaDiemDL>(DataProvider.Instance.ExecuteReader("DiaDiem_Single", _ID));
        }

        public static List<DiaDiemDL> All()
        {
            return CBO.FillCollection<DiaDiemDL>(DataProvider.Instance.ExecuteReader("DiaDiem_All"));
        }

        public static List<DiaDiemDL> FindByTenDD_QuocGia(string _TenDD, string _QuocGia)
        {
            return CBO.FillCollection<DiaDiemDL>(DataProvider.Instance.ExecuteReader("DiaDiem_FindByTenDD_QuocGia", _TenDD, _QuocGia));
        }

        public static List<DiaDiemDL> AllCountries()
        {
            return CBO.FillCollection<DiaDiemDL>(DataProvider.Instance.ExecuteReader("DiaDiem_AllCountries"));
        }

        public static List<DiaDiemDL> FindByTenDiem(string _TenDD)
        {
            return CBO.FillCollection<DiaDiemDL>(DataProvider.Instance.ExecuteReader("DiaDiem_FindByTenDiem", _TenDD));
        }

        public static List<DiaDiemDL> FindByContry(string _QuocGia)
        {
            return CBO.FillCollection<DiaDiemDL>(DataProvider.Instance.ExecuteReader("DiaDiem_FindByCountry", _QuocGia));
        }

        public static List<DiaDiemDL> SearchKey(string _Key)
        {
            return CBO.FillCollection<DiaDiemDL>(DataProvider.Instance.ExecuteReader("DiaDiem_SearchKey", _Key));
        }
        
        public static bool Add(DiaDiemDL dd)
        {
            object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "DiaDiem_Add", dd.ID, dd.TenDD, dd.QuocGia);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return true;
            return false;
        }

        public static bool Update(DiaDiemDL dd)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("DiaDiem_Update", dd.ID, dd.TenDD, dd.QuocGia);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return true;
            return false;
        }

        public static string[] ColumnNames()
        {
            DataSet ds = DataProvider.Instance.ExecuteDataset("DiaDiem_All");
            DataTable dt = ds.Tables[0];
            string[] s = new string[dt.Columns.Count];
            int i = 0;
            foreach (DataColumn col in dt.Columns)
            {
                switch (col.ColumnName)
                {
                    case "ID":
                        s[i++] = "Mã số";
                        break;
                    case "TenDD":
                        s[i++] = "Tên địa điểm";
                        break;
                    case "QuocGia":
                        s[i++] = "Quốc gia";
                        break;                    
                }             
            }
            return s;
        }

        public static List<DiaDiemDL> SearchFields(string field, string expression)
        {
            string s = "";
            switch (field)
            {
                case "Mã số":
                    s = "ID" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY ID";
                    break;
                case "Tên địa điểm":
                    s = "TenDD" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY TenDD";
                    break;
                case "Quốc gia":
                    s = "QuocGia" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY QuocGia";
                    break;                
                default:
                    return new List<DiaDiemDL>();
            }
            //s += " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\'";
            return CBO.FillCollection<DiaDiemDL>(DataProvider.Instance.ExecuteReader("SearchByCondition", "DiaDiem", s));
        }

        public static string Expresstion(string expression)
        {
            string[] s = expression.Split('*');
            expression = "";
            for (int i = 0; i < s.Count(); i++)
            {
                switch (s[i])
                {
                    case " Mã số":
                        expression += "ID" + " " + s[++i];
                        break;
                    case "OR Mã số":
                        expression += "OR ID" + " " + s[++i];
                        break;
                    case "AND Mã số":
                        expression += "AND ID" + " " + s[++i];
                        break;
                    case " Tên địa điểm":
                        expression += "TenDD" + " " + s[++i];
                        break;
                    case "OR Tên địa điểm":
                        expression += "OR TenDD" + " " + s[++i];
                        break;
                    case "AND Tên địa điểm":
                        expression += "AND TenDD" + " " + s[++i];
                        break;
                    case " Quốc gia":
                        expression += "QuocGia" + " " + s[++i];
                        break;
                    case "OR Quốc gia":
                        expression += "OR QuocGia" + " " + s[++i];
                        break;
                    case "AND Quốc gia":
                        expression += "AND QuocGia" + " " + s[++i];
                        break;
                }
            }
            return expression;
        }

        public static List<DiaDiemDL> Find(string expression)
        {
            string s = Expresstion(expression);
            return CBO.FillCollection<DiaDiemDL>(DataProvider.Instance.ExecuteReader("SearchByCondition", "DiaDiem", s));
        }


        



    }
}
