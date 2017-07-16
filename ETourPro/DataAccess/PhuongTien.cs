using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class PhuongTien
    {
        public int ID { get; set; }
        public string TenPT { get; set; }
        public string TienNghi { get; set; }
        public int SoChoToiDa { get; set; }
        public int SoChoToiThieu { get; set; }
        public int NhaCungCap { get; set; }
        public string TenNCC { get; set; }

        public static PhuongTien Single(int _MaPT)
        {
            return CBO.FillObject<PhuongTien>(DataProvider.Instance.ExecuteReader("PTien_FindMaPT", _MaPT));
        }

        public static List<PhuongTien> All()
        {
            return CBO.FillCollection<PhuongTien>(DataProvider.Instance.ExecuteReader("PTien_All"));
        }

        public static int Add(PhuongTien _Pt)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("PTien_Add", _Pt.ID, _Pt.TenPT, _Pt.TienNghi, _Pt.SoChoToiDa, _Pt.SoChoToiThieu,
                _Pt.NhaCungCap);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return affected;
            return 0;
        }

        public static int Update(PhuongTien _Pt)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("PTien_Update", _Pt.ID, _Pt.TenPT, _Pt.TienNghi, _Pt.SoChoToiDa, _Pt.SoChoToiThieu,
                _Pt.NhaCungCap);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return affected;
            return 0;
        }

        public static int Delete(int _MaPT)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("PTien_Delete", _MaPT);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return affected;
            return 0;
        }
        

        public static List<PhuongTien> FindByTen_NCC(string _TenPT, int _NhaCungCap)
        {
            return CBO.FillCollection<PhuongTien>(DataProvider.Instance.ExecuteReader("PTien_FindByTen_NCC", _TenPT, _NhaCungCap));
        }

        public static List<PhuongTien> FindByTienNghi(string _TienNghi)
        {
            return CBO.FillCollection<PhuongTien>(DataProvider.Instance.ExecuteReader("PTien_FindByTienNghi", _TienNghi));
        }

        public static List<PhuongTien> FindBy_SearchKey(string _SearchKey)
        {
            return CBO.FillCollection<PhuongTien>(DataProvider.Instance.ExecuteReader("PTien_SearchKey", _SearchKey));
        }
                
        public static List<PhuongTien> FindByTenPT(string _TenPT)
        {
            return CBO.FillCollection<PhuongTien>(DataProvider.Instance.ExecuteReader("PTien_FindByTenPT", _TenPT));
        }

        public static List<PhuongTien> FindByMaNCC(int _MaNCC)
        {
            return CBO.FillCollection<PhuongTien>(DataProvider.Instance.ExecuteReader("PTien_FindByMaNCC", _MaNCC));
        }

        public static List<PhuongTien> FindBySoChoTD_TT(int _SoChoTD, int _SoChoTT)
        {
            return CBO.FillCollection<PhuongTien>(DataProvider.Instance.ExecuteReader("PTien_SoChoTD_TT", _SoChoTD, _SoChoTT));
        }

        public static List<PhuongTien> FindByMTour(int _MTour)
        {
            return CBO.FillCollection<PhuongTien>(DataProvider.Instance.ExecuteReader("PTien_FindByMTour", _MTour));
        }
        

        
        #region Find Advance

        public static string[] ColumnNames()
        {
            DataSet ds = DataProvider.Instance.ExecuteDataset("PTien_All");
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
                    case "TenPT":
                        s[i++] = "Tên phương tiễn";
                        break;
                    case "TienNghi":
                        s[i++] = "Tiễn nghi";
                        break;
                    case "SoChoToiDa":
                        s[i++] = "Số chỗ tối đa";
                        break;
                    case "SoChoToiThieu":
                        s[i++] = "Số chỗ tối thiểu";
                        break;
                    case "NhaCungCap":
                        s[i++] = "Mã nhà cung cấp";
                        break;
                    case "TenNCC":
                        s[i++] = "Nhà cung cấp";
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
                    case " Mã số":
                        expression += "ID" + " " + s[++i];
                        break;
                    case "OR Mã số":
                        expression += "OR ID" + " " + s[++i];
                        break;
                    case "AND Mã số":
                        expression += "AND ID" + " " + s[++i];
                        break;
                    case " Tên phương tiễn":
                        expression += "TenPT" + " " + s[++i];;
                        break;
                    case "OR Tên phương tiễn":
                        expression += "OR TenPT" + " " + s[++i]; ;
                        break;
                    case "AND Tên phương tiễn":
                        expression += "AND TenPT" + " " + s[++i];
                        break;
                    case " Tiễn nghi":
                        expression += "TienNghi" + " " + s[++i];
                        break;
                    case "OR Tiễn nghi":
                        expression += "OR TienNghi" + " " + s[++i];
                        break;
                    case "AND Tiễn nghi":
                        expression += "AND TienNghi" + " " + s[++i];
                        break;
                    case " Số chỗ tối đa":
                        expression += "SoChoToiDa" + " " + s[++i];
                        break;
                    case "OR Số chỗ tối đa":
                        expression += "OR SoChoToiDa" + " " + s[++i];
                        break;
                    case "AND Số chỗ tối đa":
                        expression += "AND SoChoToiDa" + " " + s[++i];
                        break;
                    case " Số chỗ tối thiểu":
                        expression += "SoChoToiThieu" + " " + s[++i];
                        break;
                    case "OR Số chỗ tối thiểu":
                        expression += "OR SoChoToiThieu" + " " + s[++i];
                        break;
                    case "AND Số chỗ tối thiểu":
                        expression += "AND SoChoToiThieu" + " " + s[++i];
                        break;
                    case " Mã nhà cung cấp":
                        expression += "NhaCungCap" + " " + s[++i];
                        break;
                    case "OR Mã nhà cung cấp":
                        expression += "OR NhaCungCap" + " " + s[++i];
                        break;
                    case "AND Mã nhà cung cấp":
                        expression += "AND NhaCungCap" + " " + s[++i];
                        break;
                    case " Nhà cung cấp":
                        expression += "TenNCC" + " " + s[++i];
                        break;
                    case "OR Nhà cung cấp":
                        expression += "OR TenNCC" + " " + s[++i];
                        break;
                    case "AND Nhà cung cấp":
                        expression += "AND TenNCC" + " " + s[++i];
                        break;
                }
            }
            return expression;
        }

        public static List<PhuongTien> SearchFields(string field, string expression)
        {
            string s = "";
            switch (field)
            {
                case "Mã số":
                    s = "ID" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY ID";
                    break;
                case "Tên phương tiễn":
                    s = "TenPT" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY TenPT";
                    break;
                case "Tiễn nghi":
                    s = "TienNghi" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY TienNghi";
                    break;
                case "Số chỗ tối đa":
                    s = "SoChoToiDa" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY SoChoToiDa";
                    break;
                case "Số chỗ tối thiểu":
                    s = "SoChoToiThieu" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY SoChoToiThieu";
                    break;
                case "Mã nhà cung cấp":
                    s = "NhaCungCap" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY NhaCungCap";
                    break;
                case "Nhà cung cấp":
                    s = "TenNCC" + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\' ORDER BY TenNCC";
                    break;
                default:
                    return new List<PhuongTien>();

            }
            //s += + " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\'";
            return CBO.FillCollection<PhuongTien>(DataProvider.Instance.ExecuteReader("SearchByCondition", "View_PhuongTien", s));
        }

        public static List<PhuongTien> Find(string expression)
        {
            string s = Expresstion(expression);
            return CBO.FillCollection<PhuongTien>(DataProvider.Instance.ExecuteReader("SearchByCondition", "View_PhuongTien", s));
        }

        #endregion Find Advance






    }
}
