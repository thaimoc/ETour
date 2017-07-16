using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;

namespace DataAccess
{
    public class PhanCongHDV
    {
        public int MChuyen { get; set; }
        public string MHDV { get; set; }
        public int MTour { get; set; }

        /// <summary>
        /// thêm một phân công cho hướng dẫn viên
        /// </summary>
        /// <param name="c"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool Add(PhanCongHDV pc)
        {
            int rs = DataProvider.Instance.ExecuteNonQuery("PhanCongHDV_Add", pc.MChuyen, pc.MHDV, pc.MTour);
            if (rs > 0)
                return true;
            else
                return false;
        }

        public static void Add(List<PhanCongHDV> list)
        {
            foreach (PhanCongHDV item in list)
            {
                Add(item);
            }
        }

        public static bool DeletePhanCong(int _maChuyen)
        {
            int rs = DataProvider.Instance.ExecuteNonQuery("PhanCongHDV_DeleteByMChuyen", _maChuyen);
            return rs > 0;
        }
                
        public static List<PhanCongHDV> FindByMHDV(HuongDanVien hdv)
        {
            return CBO.FillCollection<PhanCongHDV>(DataProvider.Instance.ExecuteReader("PhanCongHDV_FindByMHDV", hdv.ID));            
        }



    }
}
