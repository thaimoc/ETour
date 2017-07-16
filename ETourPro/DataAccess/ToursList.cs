using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class ToursList
    {
        public List<Tour> List { get; set; }

        public ToursList()
        {
            List = Tour.All();
        }

        public List<Tour> Find(List<Chuyen> trips)
        {
            List<Tour> result = new List<Tour>();
            List<Chuyen> tripscopy = new List<Chuyen>();
            foreach (Chuyen item in trips)
            {
                Chuyen i = new Chuyen();
                i.MTour = item.MTour;
                tripscopy.Add(i);
            }

            foreach (Tour item in List)
            {
                if (Find(item, tripscopy))
                    result.Add(item);
            }
            return result;
        }

        private bool Find(Tour tour, List<Chuyen> trips)
        {
            for(int i = 0; i < trips.Count; i++)
            {
                if (trips[i].MTour == tour.ID)
                {
                    trips.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public List<Tour> FindByStatus(string _trangThai)
        {
            List<Tour> result = new List<Tour>();
            if (List == null) List = Tour.All();
            result = List.FindAll(delegate(Tour t) { 
                return t.TrangThai.ToUpper().CompareTo(_trangThai.ToUpper()) == 0;
            });
            return result;
        }



    }
}
