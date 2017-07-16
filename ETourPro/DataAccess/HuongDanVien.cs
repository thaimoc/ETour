using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DataAccess
{
    public class HuongDanVien
    {
        
        public string ID { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string QuocGia { get; set; }
        public string DienThoai { get; set; }
        public bool TrangThai { get; set; }

        public static HuongDanVien Single(string _ID)
        {
            return CBO.FillObject<HuongDanVien>(DataProvider.Instance.ExecuteReader("HDV_Single", _ID));
        }

        public static List<HuongDanVien> All()
        {
            return CBO.FillCollection<HuongDanVien>(DataProvider.Instance.ExecuteReader("HDV_All"));
        }

        public static bool Add(HuongDanVien hdv)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("HDV_Add", hdv.ID, hdv.Ho, hdv.Ten, hdv.NgaySinh, hdv.GioiTinh, hdv.DiaChi, hdv.QuocGia, hdv.DienThoai, hdv.TrangThai);
            return MyConvert.ToInt32(rs) > 0;
        }
        
        public static bool Update(HuongDanVien hdv, List<HDV_Tour> list)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("HDV_Update", hdv.ID, hdv.Ho, hdv.Ten, hdv.NgaySinh, hdv.GioiTinh, hdv.DiaChi, hdv.QuocGia, hdv.DienThoai, hdv.TrangThai);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
            {
                foreach (HDV_Tour i in list)
	            {
                    if (!HDV_Tour.Add(i))
                    {
                        MessageBox.Show(String.Format("Adding the specialized tour is faile at ID = {0}",i.MTour), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
	            }
                return true;
            }
            return false;
        }

        public static bool Delete(string _MaHDV)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("HDV_Delete", _MaHDV);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)                
                return true;
            return false;
        }
        
        public static List<HuongDanVien> FindByName(string _Ten)
        {
            return CBO.FillCollection<HuongDanVien>(DataProvider.Instance.ExecuteReader("HDV_FindByName", _Ten));
        }

        public static HuongDanVien FindByNameSingle(string _Ho, string _Ten)
        {
            return CBO.FillObject<HuongDanVien>(DataProvider.Instance.ExecuteReader("HDV_FindByNameSingle", _Ho, _Ten));
        }

        public static List<HuongDanVien> FindGender(bool _GioiTinh)
        {
            return CBO.FillCollection<HuongDanVien>(DataProvider.Instance.ExecuteReader("HDV_FindGender", _GioiTinh));
        }

        public static List<HuongDanVien> FindStatus(bool _TrangThai)
        {
            return CBO.FillCollection<HuongDanVien>(DataProvider.Instance.ExecuteReader("HDV_FindByStatus", _TrangThai));
        }

        public static List<HuongDanVien> FindByCountry(string _QuocGia)
        {
            return CBO.FillCollection<HuongDanVien>(DataProvider.Instance.ExecuteReader("HDV_FindByCountry", _QuocGia));
        }

        public static List<HuongDanVien> FindByGenderAndCountry(bool _GioiTinh, string _QuocGia)
        {
            return CBO.FillCollection<HuongDanVien>(DataProvider.Instance.ExecuteReader("HDV_FindByGenderAndCountry", _GioiTinh, _QuocGia));
        }

        public static List<HuongDanVien> FindAllCountries()
        {
            return CBO.FillCollection<HuongDanVien>(DataProvider.Instance.ExecuteReader("HDV_FindAllCountries"));
        }

        public static List<HuongDanVien> FindByMTour(int _MTour)
        {
            return CBO.FillCollection<HuongDanVien>(DataProvider.Instance.ExecuteReader("HDV_FindByMTour", _MTour));
        }

        public static List<HuongDanVien> FindByMChuyen(int _MChuyen)
        {
            return CBO.FillCollection<HuongDanVien>(DataProvider.Instance.ExecuteReader("HDV_FindByMChuyen", _MChuyen));
        }

        //Ds hdv dang lam viec va khong ban theo ma tour
        public static List<HuongDanVien> FindBy_MTour_NotBusy(int _MTour)
        {
            return CBO.FillCollection<HuongDanVien>(DataProvider.Instance.ExecuteReader("HDV_FindBy_MTour_NotBusy", _MTour));
        }
        

        public static List<HuongDanVien> Search(string word)
        {
            return CBO.FillCollection<HuongDanVien>(DataProvider.Instance.ExecuteReader("HDV_Search", word));
        }
        

        #region Find Advance

        public static string[] ColumnNames()
        {
            DataSet ds = DataProvider.Instance.ExecuteDataset("HDV_All");
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
                    case "Ho":
                        s[i++] = "Họ";
                        break;
                    case "Ten":
                        s[i++] = "Tên";
                        break;
                    case "NgaySinh":
                        s[i++] = "Ngày Sinh";
                        break;
                    //case "GioiTinh":
                    //    s[i++] = "Giới Tính";
                    //    break;
                    case "DiaChi":
                        s[i++] = "Địa Chỉ";
                        break;
                    case "QuocGia":
                        s[i++] = "Quốc Gia";
                        break;
                    case "DienThoai":
                        s[i++] = "Điện Thoại";
                        break;
                    //case "TrangThai":
                    //    s[i++] = "Trạng Thái";
                    //    break;
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
                    case " Họ":
                        expression += "Ho" + " " + s[++i];
                        break;
                    case "OR Họ":
                        expression += "OR Ho" + " " + s[++i];
                        break;
                    case "AND Họ":
                        expression += "AND Ho" + " " + s[++i];
                        break;
                    case " Tên":
                        expression += "Ten" + " " + s[++i];
                        break;
                    case "OR Tên":
                        expression += "OR Ten" + " " + s[++i];
                        break;
                    case "AND Tên":
                        expression += "AND Ten" + " " + s[++i];
                        break;
                    case " Ngày Sinh":
                        expression += "NgaySinh" + " " + s[++i];
                        break;
                    case "OR Ngày Sinh":
                        expression += "OR NgaySinh" + " " + s[++i];
                        break;
                    case "AND Ngày Sinh":
                        expression += "AND NgaySinh" + " " + s[++i];
                        break;
                    //case " Giới Tính":
                    //    expression += "GioiTinh" + " " + s[++i];
                    //    break;
                    //case "OR Giới Tính":
                    //    expression += "OR GioiTinh" + " " + s[++i];
                    //    break;
                    //case "AND Giới Tính":
                    //    expression += "AND GioiTinh" + " " + s[++i];
                    //    break;
                    case " Địa Chỉ":
                        expression += "DiaChi" + " " + s[++i];
                        break;
                    case "OR Địa Chỉ":
                        expression += "OR DiaChi" + " " + s[++i];
                        break;
                    case "AND Địa Chỉ":
                        expression += "AND DiaChi" + " " + s[++i];
                        break;
                    case " Quốc Gia":
                        expression += "QuocGia" + " " + s[++i];
                        break;
                    case "OR Quốc Gia":
                        expression += "OR QuocGia" + " " + s[++i];
                        break;
                    case "AND Quốc Gia":
                        expression += "AND QuocGia" + " " + s[++i];
                        break;
                    case " Điện Thoại":
                        expression += "DienThoai" + " " + s[++i];
                        break;
                    case "OR Điện Thoại":
                        expression += "OR DienThoai" + " " + s[++i];
                        break;
                    case "AND Điện Thoại":
                        expression += "AND DienThoai" + " " + s[++i];
                        break;
                    //case " Trạng Thái":
                    //    expression += "TrangThai" + " " + s[++i];
                    //    break;
                    //case "OR Trạng Thái":
                    //    expression += "OR TrangThai" + " " + s[++i];
                    //    break;
                    //case "AND Trạng Thái":
                    //    expression += "AND TrangThai" + " " + s[++i];
                    //    break;
                }
            }
            
            return expression;
        }

        public static List<HuongDanVien> Find(string expression)
        {
            string s = Expresstion(expression);
            return CBO.FillCollection<HuongDanVien>(DataProvider.Instance.ExecuteReader("SearchByCondition", "HDV", s));
        }

        public static List<HuongDanVien> SearchFields(string field, string expression)
        {
            string s = "";
           switch (field)
                {
                    case "Mã số":
                        s = "ID LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\'  ORDER BY ID";
                        break;
                    case "Họ":
                        s = "Ho LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\'  ORDER BY Ho";
                        break;
                    case "Tên":
                        s = "Ten LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\'  ORDER BY Ten";
                        break;
                    case "Ngày Sinh":
                        s = "NgaySinh LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\'  ORDER BY NgaySinh";
                        break;
                    //case "Giới Tính":
                    //    s = "GioiTinh" + " LIKE ";
                    //    break;
                    case "Địa Chỉ":
                        s = "DiaChi LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\'  ORDER BY DiaChi";
                        break;
                    case "Quốc Gia":
                        expression += "QuocGia LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\'  ORDER BY QuocGia";
                        break;
                    case "Điện Thoại":
                        s = "DienThoai LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\'  ORDER BY DienThoai";
                        break;
               default:
                        return new List<HuongDanVien>();
                    //case "Trạng Thái":
                    //    s = "TrangThai" + " LIKE ";
                    //    break;
                }
           //s += " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\'";
           return CBO.FillCollection<HuongDanVien>(DataProvider.Instance.ExecuteReader("SearchByCondition", "HDV", s));
        }

        #endregion Find Advance


        public static string NewBestID()
        {
            List<HuongDanVien> list = HuongDanVien.All();
            if (list.Count > 0)
            {
                string id = list[list.Count - 1].ID;
                string[] s = id.Split('V');
                id = s[1];
                int newMaSo = MyConvert.ToInt32(id) + 1;
                if (newMaSo >= 99999)
                {
                    MessageBox.Show("Cạn kho mã số cho hướng dẫn viên!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
                id = newMaSo.ToString();
                while (id.Length < 4)
                    id = "0" + id;
                id = "HDV" + id;
                return id;
            }
            return "HDV0000";
        }

    }
}
