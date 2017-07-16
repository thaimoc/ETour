using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;

namespace DataAccess
{
    public class KSanDLich
    {
        public int MKS { get; set; }
        public int MDiemDL { get; set; }

        public static bool Add(KSanDLich ksdl)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("KSanDLich_Add", ksdl.MKS, ksdl.MDiemDL);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return true;
            return false;
        }

        public static bool Delete(KSanDLich ksdl)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("KSanDLich_Delete", ksdl.MKS, ksdl.MDiemDL);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return true;
            return false;
        }

        public static bool DeleteMKS(int _MKS)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("KSanDLich_DeleteMKS", _MKS);
            int affected = MyConvert.ToInt32(rs);
            if (affected > 0)
                return true;
            return false;
        }

        public static List<KSanDLich> FindByMKS(int _MKS)
        {
            return CBO.FillCollection <KSanDLich>(DataProvider.Instance.ExecuteReader("KSanDLich_FindByMKS", _MKS));
        }
        
        
    }
}
