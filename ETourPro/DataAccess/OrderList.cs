using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class OrderList
    {
        public List<DatCho> List { get; set; }

        public OrderList()
        {
            List = new List<DatCho>();
            List = DatCho.All();
        }

        public List<DatCho> All()
        {
            return List = DatCho.All();
        }

        public bool Add(DatCho order)
        {
            if (DatCho.Add(order))
            {
                if (List == null) List = DatCho.All();
                List.Add(order);
                return true;
            }
            return false;
        }

        public bool Delete(DatCho order)
        {
            if (DatCho.Delete(order))
            {
                if (List == null) List = DatCho.All();
                for (int i = 0; i < List.Count; i++)
                {
                    if (List[i].MChuyen == order.MChuyen && List[i].MKHang == order.MKHang)
                        List.RemoveAt(i);
                }
                return true;
            }
            return false;
        }



        public List<DatCho> Find(string _CusID)
        {
            List<DatCho> orders = new List<DatCho>();
            if (List.Count > 0)
            {
                orders = List.FindAll(
                        delegate(DatCho ord)
                        {
                            return ord.MKHang == _CusID;
                        }
                    );
            }
            return orders;
        }
        

    }
}
