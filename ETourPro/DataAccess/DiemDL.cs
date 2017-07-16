using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class DiemDL
    {
        public int ID { get; set; }
        public string TenDiem { get; set; }
        public int MaDD { get; set; }
        public string DiaChi { get; set; }

        public string TenDD { get; set; }

        public static DiemDL Single(int _ID)
        {
            return CBO.FillObject<DiemDL>(DataProvider.Instance.ExecuteReader("DiemDL_Single", _ID));
        }

        public static List<DiemDL> All()
        {
            return CBO.FillCollection<DiemDL>(DataProvider.Instance.ExecuteReader("DiemDL_All"));
        }

        public static List<DiemDL> FindByMaDD(int _MaDD)
        {
            return CBO.FillCollection<DiemDL>(DataProvider.Instance.ExecuteReader("DiemDL_FindByMaDD", _MaDD));
        }

        public static List<DiemDL> FindByName(string _Name)
        {
            return CBO.FillCollection<DiemDL>(DataProvider.Instance.ExecuteReader("DiemDL_FindByName", _Name));
        }

        public static List<DiemDL> FindByTenD_MaDD(string _TenDDL, int _MaDD)
        {
            return CBO.FillCollection<DiemDL>(DataProvider.Instance.ExecuteReader("DiemDL_FindByTenD_MaDD", _TenDDL, _MaDD));
        }

        public static List<DiemDL> SearchKey(string _Key)
        {
            return CBO.FillCollection<DiemDL>(DataProvider.Instance.ExecuteReader("View_DiemDL_Search", _Key));
        }

        public static List<DiemDL> FindByMaKS(int _MKS)
        {
            return CBO.FillCollection<DiemDL>(DataProvider.Instance.ExecuteReader("DiemDL_FindByMaKS", _MKS));
        }

        public static List<DiemDL> FindByMTour(int _MTour)
        {
            return CBO.FillCollection<DiemDL>(DataProvider.Instance.ExecuteReader("DiemDL_FindByMTour", _MTour));
        }        

        public static List<DiemDL> FindByNotMaKS(int _MKS)
        {
            return CBO.FillCollection<DiemDL>(DataProvider.Instance.ExecuteReader("DiemDL_FindByNotMaKS", _MKS));
        }
        
        public static bool Add(DiemDL dl)
        {
            //
            object rs = DataProvider.Instance.ExecuteNonQuery("DiemDL_Add", dl.ID, dl.TenDiem, dl.MaDD, dl.DiaChi);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return true;
            return false;
        }

        public static bool Update(DiemDL dl)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("DiemDL_Update", dl.ID, dl.TenDiem, dl.MaDD, dl.DiaChi);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return true;
            return false;
        }

        public static string[] ColumnNames()
        {
            DataSet ds = DataProvider.Instance.ExecuteDataset("DiemDL_All");
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
                    case "TenDiem":
                        s[i++] = "Tên điểm";
                        break;
                    //case "MaDD":
                    //    s[i++] = "Mã địa điểm";
                    //    break;
                    case "DiaChi":
                        s[i++] = "Địa chỉ";
                        break;
                    case "TenDD":
                        s[i++] = "Địa điểm";
                        break;
                }
            }
            return s;
        }

        public static List<DiemDL> SearchFields(string field, string expression)
        {
            string s = "";
            switch (field)
            {
                case "Mã số":
                    s = "ID" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY ID";
                    break;
                case "Tên điểm":
                    s = "TenDiem" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY TenDiem";
                    break;
                //case "Mã địa điểm":
                //    s = "MaDD" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY MaDD";
                //    break;
                case "Địa chỉ":
                    s = "DiaChi" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY DiaChi";
                    break;
                case "Địa điểm":
                    s = "TenDD" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY TenDD";
                    break;
                default:
                    return new List<DiemDL>();
            }
            //s += " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\'";
            return CBO.FillCollection<DiemDL>(DataProvider.Instance.ExecuteReader("SearchByCondition", "View_DiemDL", s));
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
                    case "Tên điểm":
                        expression += "TenDiem" + " " + s[++i];
                        break;
                    case "OR Tên điểm":
                        expression += "OR TenDiem" + " " + s[++i];
                        break;
                    case "AND Tên điểm":
                        expression += "AND TenDiem" + " " + s[++i];
                        break;
                    case " Mã địa điểm":
                        expression += "MaDD" + " " + s[++i];
                        break;
                    case "OR Mã địa điểm":
                        expression += "OR MaDD" + " " + s[++i];
                        break;
                    case "AND Mã địa điểm":
                        expression += "AND MaDD" + " " + s[++i];
                        break;
                    case " Địa chỉ":
                        expression += "DiaChi" + " " + s[++i];
                        break;
                    case "OR Địa chỉ":
                        expression += "OR DiaChi" + " " + s[++i];
                        break;
                    case "AND Địa chỉ":
                        expression += "AND DiaChi" + " " + s[++i];
                        break;
                    case " Địa điểm":
                        expression += "TenDD" + " " + s[++i];
                        break;
                    case "OR Địa điểm":
                        expression += "OR TenDD" + " " + s[++i];
                        break;
                    case "AND Địa điểm":
                        expression += "AND TenDD" + " " + s[++i];
                        break;
                }
            }
            return expression;
        }

        public static List<DiemDL> Find(string expression)
        {
            string s = Expresstion(expression);
            return CBO.FillCollection<DiemDL>(DataProvider.Instance.ExecuteReader("SearchByCondition", "View_DiemDL", s));
        }


        
    }
}
