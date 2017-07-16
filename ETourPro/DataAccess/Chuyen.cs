using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class Chuyen
    {
        public int MChuyen { get; set; }
        public int MTour { get; set; }
        public DateTime NgayDi { get; set; }
        public DateTime NgayVe { get; set; }
        public double Gia { get; set; }
        public int TrangThai { get; set; }
        public string TenTour { get; set; }
        public string XuatPhat { get; set; }

        private string _dasdfa;

        public string Dasdfa
        {
            get { return _dasdfa; }
            set { _dasdfa = value; }
        }

        public static List<Chuyen> FindByHDV(string _MHDV)
        {
            return CBO.FillCollection<Chuyen>(DataProvider.Instance.ExecuteReader("Chuyen_FindByHDVien", _MHDV));
        }

        public static List<Chuyen> FindByGia(double _Gia)
        {
            return CBO.FillCollection<Chuyen>(DataProvider.Instance.ExecuteReader("Chuyen_FindByGia", _Gia));
        }        

        public static List<Chuyen> FindByNameTour(string _TenTour)
        {
            return CBO.FillCollection<Chuyen>(DataProvider.Instance.ExecuteReader("Chuyen_FindByNameTour", _TenTour));
        }
        
        public static List<Chuyen> FindByStatus(int _TrangThai)
        {
            return CBO.FillCollection<Chuyen>(DataProvider.Instance.ExecuteReader("Chuyen_FindByStatus", _TrangThai));
        }

        public static List<Chuyen> FindByMTour(int _MTour)
        {
            return CBO.FillCollection<Chuyen>(DataProvider.Instance.ExecuteReader("Chuyen_FindByMTour", _MTour));
        }

        public static List<Chuyen> FindByMaKH(string _MKHang)
        {
            return CBO.FillCollection<Chuyen>(DataProvider.Instance.ExecuteReader("Chuyen_FindByMaKH", _MKHang));
        }        

        public static int Add(Chuyen c)
        {
            object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@MChuyen", "Chuyen_Add", c.MChuyen, c.MTour, c.NgayDi, c.NgayVe, c.Gia, c.TrangThai);
            return MyConvert.ToInt32(rs);
        }

        public static bool Update(Chuyen c)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("Chuyen_Update", c.MChuyen, c.MTour, c.NgayDi, c.NgayVe, c.Gia, c.TrangThai);
            return MyConvert.ToInt32(rs) > 0 ? true : false;
        }

        public static bool Delete(int _MaChuyen)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("Chuyen_Delete", _MaChuyen);
            return MyConvert.ToInt32(rs) > 0 ? true : false;
        }
        

        public static List<Chuyen> All()
        {
            return CBO.FillCollection<Chuyen>(DataProvider.Instance.ExecuteReader("Chuyen_All"));
        }

        public static Chuyen Single(int _MChuyen)
        {
            return CBO.FillObject<Chuyen>(DataProvider.Instance.ExecuteReader("Chuyen_Single", _MChuyen));
        }

        #region Find Advance

        public static string[] ColumnNames()
        {
            DataSet ds = DataProvider.Instance.ExecuteDataset("Chuyen_All");
            DataTable dt = ds.Tables[0];
            string[] s = new string[dt.Columns.Count - 2];
            int i = 0;
            foreach (DataColumn col in dt.Columns)
            {
                switch (col.ColumnName)
                {
                    case "MChuyen":
                        s[i++] = "Code";
                        break;
                    //case "MTour":
                    //    s[i++] = "Mã tour";
                    //    break;
                    case "TenTour":
                        s[i++] = "Tour";
                        break;
                    case "NgayDi":
                        s[i++] = "Start Date";
                        break;
                    case "NgayVe":
                        s[i++] = "End Date";
                        break;
                    case "Gia":
                        s[i++] = "Price";
                        break;
                    //case "TrangThai":
                    //    s[i++] = "Status";
                    //    break;
                    case "XuatPhat":
                        s[i++] = "Start Place";
                        break;
                }               
            }
            return s;
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
                        expression += "MChuyen" + " " + s[++i];
                        break;
                    case "OR Code":
                        expression += "OR MChuyen" + " " + s[++i];
                        break;
                    case "AND Code":
                        expression += "AND MChuyen" + " " + s[++i];
                        break;
                    //case " Mã tour":
                    //    expression += "MTour" + " " + s[++i];
                    //    break;
                    //case "OR Mã tour":
                    //    expression += "OR MTour" + " " + s[++i];
                    //    break;
                    //case "AND Mã tour":
                    //    expression += "AND MTour" + " " + s[++i];
                    //    break;
                    case " Tour":
                        expression += "TenTour" + " " + s[++i];
                        break;
                    case "OR Tour":
                        expression += "OR TenTour" + " " + s[++i];
                        break;
                    case "AND Tour":
                        expression += "AND TenTour" + " " + s[++i];
                        break;
                    case " Start Date":
                        expression += "CONVERT(VARCHAR(10),NgayDi,110)" + " " + s[++i];
                        break;
                    case "OR Start Date":
                        expression += "OR CONVERT(VARCHAR(10),NgayDi,110)" + " " + s[++i];
                        break;
                    case "AND Start Date":
                        expression += "AND CONVERT(VARCHAR(10),NgayDi,110)" + " " + s[++i];
                        break;
                    case " End Date":
                        expression += "CONVERT(VARCHAR(10),NgayVe,110)" + " " + s[++i];
                        break;
                    case "OR End Date":
                        expression += "OR CONVERT(VARCHAR(10),NgayVe,110)" + " " + s[++i];
                        break;
                    case "AND End Date":
                        expression += "AND CONVERT(VARCHAR(10),NgayVe,110)" + " " + s[++i];
                        break;
                    case " Price":
                        expression += "Gia" + " " + s[++i];
                        break;
                    case "OR Price":
                        expression += "OR Gia" + " " + s[++i];
                        break;
                    case "AND Price":
                        expression += "AND Gia" + " " + s[++i];
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
                    case " Start Place":
                        expression += "XuatPhat" + " " + s[++i];
                        break;
                    case "OR Start Place":
                        expression += "OR XuatPhat" + " " + s[++i];
                        break;
                    case "AND Start Place":
                        expression += "AND XuatPhat" + " " + s[++i];
                        break;
                }
            }
            return expression;
        }

        public static List<Chuyen> Find(string expression)
        {
            string s = Expresstion(expression);
            return CBO.FillCollection<Chuyen>(DataProvider.Instance.ExecuteReader("SearchByCondition", "View_Chuyen_Tour", s));
        }

        #endregion Find Advance
        
        

        
    }
}
