using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class KhachHang
    {
        public string ID { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public Boolean GTinh { get; set; }
        public string SoDT { get; set; }
        public string SoTaiKhoan { get; set; }
        public string DiaChi { get; set; }
        public string ThanhPho { get; set; }
        public string QuocGia { get; set; }

        public static KhachHang Single(string _MaKH)
        {
            return CBO.FillObject<KhachHang>(DataProvider.Instance.ExecuteReader("KhachHang_Single", _MaKH));
        }

        public static bool Add(KhachHang kh)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("KhachHang_Add", kh.ID, kh.Ho, kh.Ten, kh.NgaySinh, kh.GTinh, kh.SoDT, kh.SoTaiKhoan, 
                kh.DiaChi, kh.ThanhPho, kh.QuocGia);
            return MyConvert.ToInt32(rs) > 0;            
        }        

        public static bool Update(KhachHang kh)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("KhachHang_UPDATE", kh.ID, kh.Ho, kh.Ten, kh.NgaySinh, kh.GTinh, kh.SoDT, kh.SoTaiKhoan, 
                kh.DiaChi, kh.ThanhPho, kh.QuocGia);
            return MyConvert.ToInt32(rs) > 0;            
        }

        public static bool Delete(string _maKHang)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("KhachHang_Delete", _maKHang);
            return MyConvert.ToInt32(rs) > 0;            
        }
        

        public static List<KhachHang> All()
        {
            return CBO.FillCollection<KhachHang>(DataProvider.Instance.ExecuteReader("KhachHang_All"));
        }

        public static List<KhachHang> FindByGende(bool _gender)
        {
            return CBO.FillCollection<KhachHang>(DataProvider.Instance.ExecuteReader("KhachHang_FindByGender", _gender));
        }

        public static List<KhachHang> FindCountries()
        {
            return CBO.FillCollection<KhachHang>(DataProvider.Instance.ExecuteReader("KhachHang_FindCountries"));
        }

        public static List<KhachHang> FindByCountry(string _country)
        {
            return CBO.FillCollection<KhachHang>(DataProvider.Instance.ExecuteReader("KhachHang_FindByCountry", _country));
        }

        public static List<KhachHang> FindMothCurrentBirthDay()
        {
            return CBO.FillCollection<KhachHang>(DataProvider.Instance.ExecuteReader("KhachHang_FindMothCurrentBirthDay"));
        }
        
        public static List<KhachHang> FindCities()
        {
            return CBO.FillCollection<KhachHang>(DataProvider.Instance.ExecuteReader("KhachHang_FindCities"));
        }
        
        public static List<KhachHang> FindByCity(string _city)
        {
            return CBO.FillCollection<KhachHang>(DataProvider.Instance.ExecuteReader("KhachHang_FindByCity", _city));
        }

        public static List<KhachHang> FindByName(string _name)
        {
            return CBO.FillCollection<KhachHang>(DataProvider.Instance.ExecuteReader("KhachHang_FindByName", _name));
        }

        public static List<KhachHang> FindByMChuyen(int _MChuyen)
        {
            return CBO.FillCollection<KhachHang>(DataProvider.Instance.ExecuteReader("KhachHang_FindByMChuyen", _MChuyen));
        }
        
        
        #region Find Advance

        public static string[] ColumnNames()
        {
            using (DataSet ds = DataProvider.Instance.ExecuteDataset("KhachHang_All"))
            {
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
                        case "Ho":
                            s[i++] = "First Name";
                            break;
                        case "Ten":
                            s[i++] = "Last Name";
                            break;
                        case "NgaySinh":
                            s[i++] = "Birth date";
                            break;
                        //case "GioiTinh":
                        //    s[i++] = "Gender";
                        //    break;
                        case "DiaChi":
                            s[i++] = "Address";
                            break;
                        case "QuocGia":
                            s[i++] = "Country";
                            break;
                        case "SoDT":
                            s[i++] = "Phone";
                            break;
                        case "SoTaiKhoan":
                            s[i++] = "Account";
                            break;
                        //case "ThanhPho":
                        //    s[i++] = "City";
                        //    break;
                    }
                }
                dt.Dispose();
                return s;
            }
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
                    case " First Name":
                        expression += "Ho" + " " + s[++i];
                        break;
                    case "OR First Name":
                        expression += "OR Ho" + " " + s[++i];
                        break;
                    case "AND First Name":
                        expression += "AND Ho" + " " + s[++i];
                        break;
                    case " Last Name":
                        expression += "Ten" + " " + s[++i];
                        break;
                    case "OR Last Name":
                        expression += "OR Ten" + " " + s[++i];
                        break;
                    case "AND Last Name":
                        expression += "AND Ten" + " " + s[++i];
                        break;
                    case " Birth date":
                        expression += "NgaySinh" + " " + s[++i];
                        break;
                    case "OR Birth date":
                        expression += "OR NgaySinh" + " " + s[++i];
                        break;
                    case "AND Birth date":
                        expression += "AND NgaySinh" + " " + s[++i];
                        break;
                    case " Gender":
                        expression += "GioiTinh" + " " + s[++i];
                        break;
                    case "OR Gender":
                        expression += "OR GioiTinh" + " " + s[++i];
                        break;
                    case "AND Gender":
                        expression += "AND GioiTinh" + " " + s[++i];
                        break;
                    case " Address":
                        expression += "DiaChi" + " " + s[++i];
                        break;
                    case "OR Address":
                        expression += "OR DiaChi" + " " + s[++i];
                        break;
                    case "AND Address":
                        expression += "AND DiaChi" + " " + s[++i];
                        break;
                    case " Country":
                        expression += "QuocGia" + " " + s[++i];
                        break;
                    case "OR Country":
                        expression += "OR QuocGia" + " " + s[++i];
                        break;
                    case "AND Country":
                        expression += "AND QuocGia" + " " + s[++i];
                        break;
                    case " Phone":
                        expression += "SoDT" + " " + s[++i];
                        break;
                    case "OR Phone":
                        expression += "OR SoDT" + " " + s[++i];
                        break;
                    case "AND Phone":
                        expression += "AND SoDT" + " " + s[++i];
                        break;
                    case " Account":
                        expression += "SoTaiKhoan" + " " + s[++i];
                        break;
                    case "OR Account":
                        expression += "OR SoTaiKhoan" + " " + s[++i];
                        break;
                    case "AND Account":
                        expression += "AND SoTaiKhoan" + " " + s[++i];
                        break;
                    case " City":
                        expression += "ThanhPho" + " " + s[++i];
                        break;
                    case "OR City":
                        expression += "OR ThanhPho" + " " + s[++i];
                        break;
                    case "AND City":
                        expression += "AND ThanhPho" + " " + s[++i];
                        break; 
                }
            }
            return expression;
        }

        public static List<KhachHang> Find(string expression)
        {
            string s = Expresstion(expression);
            return CBO.FillCollection<KhachHang>(DataProvider.Instance.ExecuteReader("SearchByCondition", "KhachHang", s));
        }

        #endregion Find Advance
        
    }
}
