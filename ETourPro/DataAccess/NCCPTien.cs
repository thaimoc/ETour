using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class NCCPTien
    {
        public int ID { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public static NCCPTien Single(int _ID)
        {
            return CBO.FillObject<NCCPTien>(DataProvider.Instance.ExecuteReader("NCCPTien_Single", _ID));
        }

        public static NCCPTien FindByTenNCC(string _TenNCC)
        {
            return CBO.FillObject<NCCPTien>(DataProvider.Instance.ExecuteReader("NCCPTien_FindByTenNCC", _TenNCC));
        }

        public static NCCPTien FindByVehicleCode(int _MaPt)
        {
            return CBO.FillObject<NCCPTien>(DataProvider.Instance.ExecuteReader("NCCPTien_FindByVehicleCode", _MaPt));
        }

        public static List<NCCPTien> SearchKeyWords(string _key)
        {
            return CBO.FillCollection<NCCPTien>(DataProvider.Instance.ExecuteReader("NCCPTien_FindByKeyWord", _key));
        }        
        
        public static List<NCCPTien> All()
        {
            return CBO.FillCollection<NCCPTien>(DataProvider.Instance.ExecuteReader("NCCPTien_All"));
        }

        public static int Add(NCCPTien _Nccc)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("NCCPTien_Add", _Nccc.ID, _Nccc.TenNCC, _Nccc.DiaChi, _Nccc.DienThoai);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return affected;
            return 0;
        }

        public static int Update(NCCPTien _Nccc)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("NCCPTien_Update", _Nccc.ID, _Nccc.TenNCC, _Nccc.DiaChi, _Nccc.DienThoai);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return affected;
            return 0;
        }

        #region Find Advance

        public static string[] ColumnNames()
        {
            DataSet ds = DataProvider.Instance.ExecuteDataset("NCCPTien_All");
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
                    case "TenNCC":
                        s[i++] = "Tên nhà cung cấp";
                        break;
                    case "DiaChi":
                        s[i++] = "Địa chỉ";
                        break;
                    case "DienThoai":
                        s[i++] = "Điện thoại";
                        break;
                }
            }
            return s;
        }

        public static List<NCCPTien> SearchFields(string field, string expression)
        {
            string s = "";
            switch (field)
            {
                case "Mã số":
                    s = "ID";
                    break;
                case "Tên nhà cung cấp":
                    s = "TenNCC";
                    break;
                case "Địa chỉ":
                    s = "DiaChi";
                    break;
                case "Điện thoại":
                    s = "DienThoai";
                    break;
                default:
                    return new List<NCCPTien>();

            }
            s += " LIKE " + "\'%\' +" + "\'" + expression + "\'" + "+\'%\'";
            return CBO.FillCollection<NCCPTien>(DataProvider.Instance.ExecuteReader("SearchByCondition", "NCCPTien", s));
        }

        #endregion


    }
}
