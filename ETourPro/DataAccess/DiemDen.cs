using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataAccess
{
    public class DiemDen
    {
        public int MTour { get; set; }
        public int MDiemDL { get; set; }
        public int MaKS { get; set; }
        public int MaPT { get; set; }
        public string TenTour { get; set; }
        public string TenDD { get; set; }
        public string TenDiem { get; set; }
        public string TenKS { get; set; }        
        public string QuocGia { get; set; }
        public string TenPT { get; set; }
        public string TenNCC { get; set; }
        
        public static List<DiemDen> FindByMaPT(int _MaPT)
        {
            return CBO.FillCollection<DiemDen>(DataProvider.Instance.ExecuteReader("View_DiemDen_FindByMaPT", _MaPT));
        }

        public static List<DiemDen> FindByMTour(int _MTour)
        {
            return CBO.FillCollection<DiemDen>(DataProvider.Instance.ExecuteReader("DiemDen_FindByMTour", _MTour));
        }

        public static int Add(DiemDen dd)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("DiemDen_Add", dd.MTour, dd.MDiemDL, dd.MaKS, dd.MaPT);
            return MyConvert.ToInt32(rs);
        }

        public static void Add(List<DiemDen> list)
        {
            foreach (DiemDen item in list)
            {
                if (!(Add(item) > 0))
                {
                    MessageBox.Show(String.Format("Inserting had been failse! Destination - Scenic:{0}", item.TenDiem) , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static int DeleteByMTour(int _MTour)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("DiemDen_DeleteByMTour", _MTour);
            return MyConvert.ToInt32(rs);
        }

        
    }
}
