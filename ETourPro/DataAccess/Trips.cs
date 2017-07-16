using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class Trips
    {
        public List<Chuyen> List { get; set; }

        public Trips()
        {
            List = new List<Chuyen>();
            List = Chuyen.All();
        }

        public Chuyen Single(int code)
        { 
            if(List == null) List = Chuyen.All();
            return List.Find(delegate(Chuyen t) {
                return t.MChuyen == code;
            });
        }

        public List<Chuyen> Find(List<DatCho> order, int status)
        {
            List<Chuyen> result = new List<Chuyen>();
            List<Chuyen> temp = Find(order);
            foreach (Chuyen item in temp)
            {
                if (item.TrangThai == status)
                    result.Add(item);
            }
            return result;
        }

        public List<Chuyen> Find(List<DatCho> order)
        {
            List<Chuyen> result = new List<Chuyen>();
            List<DatCho> ordercopy = new List<DatCho>();
            foreach (DatCho item in order)
            {
                DatCho i = new DatCho();
                i.MChuyen = item.MChuyen;
                ordercopy.Add(i);
            }            
            foreach (Chuyen item in List)
            {
                if (Find(item, ordercopy))
                    result.Add(item);
            }
            return result;
        }

        private bool Find(Chuyen trip, List<DatCho> orders)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].MChuyen == trip.MChuyen)
                {
                    orders.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public List<Chuyen> FindByCodeTour(int _tourCode)
        {
            if (List == null) List = Chuyen.All();
            return List.FindAll(delegate(Chuyen t)
            {
                return t.MTour == _tourCode;
            });
        }

        public List<Chuyen> FindByCodeTourAndStatus(int _tourCode, int _status)
        {
            if (List == null) List = Chuyen.All();
            return List.FindAll(delegate(Chuyen t){
                return t.MTour == _tourCode && t.TrangThai == _status;
            });
        }

        public List<Chuyen> FindByStatus(int _status)
        {
            if (List == null) List = Chuyen.All();
            return List.FindAll(delegate(Chuyen t)
            {
                return t.TrangThai == _status;
            });
        }

        public List<Chuyen> FindByLessThanPrice(double _price)
        {
            List<Chuyen> result = new List<Chuyen>();
            if (List == null) List = Chuyen.All();
            result = List.FindAll(delegate(Chuyen t) {
                return t.Gia <= _price;
            });
            IOrderedEnumerable<Chuyen> temp = result.OrderByDescending(x => x.Gia);
            result = new List<Chuyen>();
            foreach (Chuyen item in temp)
            {
                result.Add(item);
            }
            return result;
        }

        public List<Chuyen> FindByPerodTime(DateTime start, DateTime end)
        { 
            if(start.Date > end.Date) return new List<Chuyen>();
            return List.FindAll(
                delegate(Chuyen t)
                {
                    return t.NgayDi.Date >= start.Date && t.NgayVe.Date <= end.Date;
                }
                );
        }



    }
}
