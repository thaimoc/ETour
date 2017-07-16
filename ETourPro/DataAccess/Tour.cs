using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class Tour
    {
        public int ID { get; set; }
        public string TenTour { get; set; }
        public string XuatPhat { get; set; }
        public string TrangThai { get; set; }


        public static Tour Single(int _MaTour)
        {
            return CBO.FillObject<Tour>(DataProvider.Instance.ExecuteReader("Tour_Single", _MaTour));
        }

        public static List<Tour> All()
        {
            return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("Tour_All"));
        }

        public static List<Tour> FindByMHDV(string _MHDV)
        {
            return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("HDV_Tour_FindByMHDV", _MHDV));
        }

        public static List<Tour> FindByVehicleCode(int _MaPhuongTien)
        {
            return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("Tour_FindByVehicleCode", _MaPhuongTien));
        }        

        public static List<Tour> FindByName(string _TenTour)
        {
            return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("Tour_FindByName", _TenTour));
        }

        public static List<Tour> FindStatus(string _TrangThai)
        {
            return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("Tour_FindStatus", _TrangThai));
        }
        
        public static List<Tour> FindByCodeScenic(int _MDiemDL)
        {
            return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("Tour_FindMDiemDL", _MDiemDL));
        }

        public static List<Tour> FindByMKSan(int _MaKS)
        {
            return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("Tour_FindByMKSan", _MaKS));
        }

        public static List<Tour> SearchByKey(string _Key)
        {
            return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("Tour_SearchByKey", _Key));
        }

        public static List<Tour> StatusAll()
        {
            return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("Tour_StatusAll"));
        }   
        
        

        public static int Add(Tour t)
        {
            object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "Tour_Add", t.ID, t.TenTour, t.XuatPhat, t.TrangThai);
            return MyConvert.ToInt32(rs);
        }

        public static bool Update(Tour t)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("Tour_Update", t.ID, t.TenTour, t.XuatPhat, t.TrangThai);
            return MyConvert.ToInt32(rs) > 0 ? true : false;
        }
        
        public static bool Delete(int _MTour)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("Tour_Delete", _MTour);
            return MyConvert.ToInt32(rs) > 0 ? true : false;
        }

        public static string[] ColumnNames()
        {
            DataSet ds = DataProvider.Instance.ExecuteDataset("Tour_All");
            DataTable dt = ds.Tables[0];
            string[] s = new string[dt.Columns.Count];
            int i = 0;
            foreach (DataColumn col in dt.Columns)
            {
                switch (col.ColumnName)
                {
                    case "ID":
                        s[i++] = "Code";
                        break;
                    case "TenTour":
                        s[i++] = "Name";
                        break;
                    case "XuatPhat":
                        s[i++] = "Start Place";
                        break;
                    case "TrangThai":
                        s[i++] = "Status";
                        break;
                }
            }
            return s;
        }

        public static List<Tour> SearchFields(string field, string expression)
        {
            string s = "";
            switch (field)
            {
                case "Code":
                    s = "ID" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY ID";
                    break;
                case "Name":
                    s = "TenTour" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY TenTour";
                    break;
                case "Start Place":
                    s = "XuatPhat" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY XuatPhat";
                    break;
                case "Status":
                    s = "TrangThai" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY TrangThai";
                    break;
                default:
                    return new List<Tour>();

            }
            return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("SearchByCondition", "Tour", s));
        }

        public static string Expresstion(string expression)
        {
            string[] s = expression.Split('*');
            expression = "";
            for (int i = 0; i < s.Count(); i++)
            {
                switch (s[i])
                {
                    case " Code":
                        expression += "ID" + " " + s[++i];
                        break;
                    case "OR Code":
                        expression += "OR ID" + " " + s[++i];
                        break;
                    case "AND Code":
                        expression += "AND ID" + " " + s[++i];
                        break;
                    case " Name":
                        expression += "TenTour" + " " + s[++i];
                        break;
                    case "OR Name":
                        expression += "OR TenTour" + " " + s[++i];
                        break;
                    case "AND Name":
                        expression += "AND TenTour" + " " + s[++i];
                        break;
                    case " Start Place":
                        expression += "XuatPhat" + " " + s[++i];
                        break;
                    case "OR Start Place":
                        expression += "OR XuatPhat" + " " + s[++i];
                        break;
                    case "AND Start Place":
                        expression += "AND XuatPhat" + " " + s[++i];
                        break;
                    case " Status":
                        expression += "TrangThai" + " " + s[++i];
                        break;
                    case "OR Status":
                        expression += "OR TrangThai" + " " + s[++i];
                        break;
                    case "AND Status":
                        expression += "AND TrangThai" + " " + s[++i];
                        break;
                }
            }
            return expression;
        }

        public static List<Tour> Find(string expression)
        {
            string s = Expresstion(expression);
            return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("SearchByCondition", "Tour", s));
        }
        
    }
}
