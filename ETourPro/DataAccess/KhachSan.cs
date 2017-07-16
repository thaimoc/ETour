using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class KhachSan
    {
        public int ID { get; set; }
        public string TenKS { get; set; }
        public double SoSao { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public static KhachSan Single(int _ID)
        {
            return CBO.FillObject<KhachSan>(DataProvider.Instance.ExecuteReader("KhachSan_Single", _ID));
        }

        public static List<KhachSan> FindByName(string name, string adr)
        {
            return CBO.FillCollection<KhachSan>(DataProvider.Instance.ExecuteReader("KhachSan_FindByName", name, adr));
        }

        public static List<KhachSan> All()
        {
            return CBO.FillCollection<KhachSan>(DataProvider.Instance.ExecuteReader("KhachSan_All"));
        }

        public static int Add(KhachSan ks)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "KhachSan_Add", ks.ID, ks.TenKS, ks.SoSao, ks.DiaChi, ks.SoDienThoai);
                int affected = MyConvert.ToInt32(rs);
                if (affected > 0)
                    return int.Parse(rs.ToString());
                return 0;
            }
            catch { return 0; }
        }

        public static bool Update(KhachSan ks)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("KhachSan_Update", ks.ID, ks.TenKS, ks.SoSao, ks.DiaChi, ks.SoDienThoai);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return true;
            return false;
        }

        public static bool Delete(int _id)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("KhachSan_Delete", _id);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return true;
            return false;
        }

        public static List<KhachSan> FindByName(string _name)
        {
            return CBO.FillCollection<KhachSan>(DataProvider.Instance.ExecuteReader("KhachSan_FindByTenKS", _name));
        }

        public static List<KhachSan> SearchKey(string _Key)
        {
            return CBO.FillCollection<KhachSan>(DataProvider.Instance.ExecuteReader("KhachSan_SearchKey", _Key));
        }        

        public static List<KhachSan> FindMDiemDL(int _MDiemDL)
        {
            return CBO.FillCollection<KhachSan>(DataProvider.Instance.ExecuteReader("KhachSan_FindMDiemDL", _MDiemDL));
        }

        public static List<KhachSan> FindByMTour(int _MTour)
        {
            return CBO.FillCollection<KhachSan>(DataProvider.Instance.ExecuteReader("KhachSan_FindByMTour", _MTour));
        }  
        

        public static string[] ColumnNames()
        {
            DataSet ds = DataProvider.Instance.ExecuteDataset("KhachSan_All");
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
                    case "TenKS":
                        s[i++] = "Tên Khách sạn";
                        break;
                    case "SoSao":
                        s[i++] = "Số sao";
                        break;
                    case "DiaChi":
                        s[i++] = "Địa chỉ";
                        break;
                    case "SoDienThoai":
                        s[i++] = "Số điện thoại";
                        break;
                }
            }
            return s;
        }

        public static List<KhachSan> SearchFields(string field, string expression)
        {
            string s = "";
            switch (field)
            {
                case "Mã số":
                    s = "ID" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY ID";
                    break;
                case "Tên Khách sạn":
                    s = "TenKS" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY TenKS";
                    break;
                case "Số sao":
                    s = "SoSao" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY SoSao";
                    break;
                case "Địa chỉ":
                    s = "DiaChi" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY DiaChi";
                    break;

                case "Số điện thoại":
                    s = "SoDienThoai" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY SoDienThoai";
                    break;
                default:
                    return new List<KhachSan>();

            }
            //s += + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\'";
            return CBO.FillCollection<KhachSan>(DataProvider.Instance.ExecuteReader("SearchByCondition", "KhachSan", s));
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
                    case " Tên Khách sạn":
                        expression += "TenKS" + " " + s[++i];
                        break;
                    case "OR Tên Khách sạn":
                        expression += "OR TenKS" + " " + s[++i];
                        break;
                    case "AND Tên Khách sạn":
                        expression += "AND TenKS" + " " + s[++i];
                        break;
                    case " Số sao":
                        expression += "SoSao" + " " + s[++i];
                        break;
                    case "OR Số sao":
                        expression += "OR SoSao" + " " + s[++i];
                        break;
                    case "AND Số sao":
                        expression += "AND SoSao" + " " + s[++i];
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
                    case " Số điện thoại":
                        expression += "SoDienThoai" + " " + s[++i];
                        break;
                    case "OR Số điện thoại":
                        expression += "OR SoDienThoai" + " " + s[++i];
                        break;
                    case "AND Số điện thoại":
                        expression += "AND SoDienThoai" + " " + s[++i];
                        break;
                }
            }
            return expression;
        }

        

        public static List<KhachSan> Find(string expression)
        {
            string s = Expresstion(expression);
            return CBO.FillCollection<KhachSan>(DataProvider.Instance.ExecuteReader("SearchByCondition", "KhachSan", s));
        }

    }
}
