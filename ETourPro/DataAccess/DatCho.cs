using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DatCho
    {
        public int MChuyen { get; set; }
        public string MKHang { get; set; }

        public static List<DatCho> All()
        {
            return CBO.FillCollection<DatCho>(DataProvider.Instance.ExecuteReader("DatCho_All"));
        }

        public static bool Add(DatCho dc)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("DatCho_Add", dc.MChuyen, dc.MKHang);
            return MyConvert.ToInt32(rs) > 0;
        }

        public static bool Delete(DatCho dc)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("DatCho_Delete", dc.MChuyen, dc.MKHang);
            return MyConvert.ToInt32(rs) > 0;
        }
        

        public static void Add(List<DatCho> list)
        {
            foreach (DatCho item in list)
            {
                Add(item);
            }
        }

        public static bool Delete(string _MKHang)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("DatCho_DeleteByMKHang", _MKHang);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)                
                return true;
            return false;
        }

        
    }
}
