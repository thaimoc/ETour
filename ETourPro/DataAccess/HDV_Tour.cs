using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;

namespace DataAccess
{
    public class HDV_Tour
    {
        public string MHDV { get; set; }
        public int MTour { get; set; }

        public HDV_Tour()
        {

        }

        public HDV_Tour(string _mhdv, int _mtour)
        {
            MHDV = _mhdv;
            MTour = _mtour;
        }

        public static bool Add(HDV_Tour thongThuoc)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("HDV_Tour_Add", thongThuoc.MHDV, thongThuoc.MTour);
            return MyConvert.ToInt32(rs) > 0;
        }

        public static List<Tour> FindByMHDV(string _MHDV)
        {
            return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("HDV_Tour_FindByMHDV", _MHDV));
        }

        public static List<Tour> NotFindByMHDV(string _MHDV)
        {
            return CBO.FillCollection<Tour>(DataProvider.Instance.ExecuteReader("HDV_Tour_NotFindByMHDV", _MHDV));
        }

    }
}
