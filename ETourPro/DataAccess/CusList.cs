using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class CusList
    {
        public List<KhachHang> List { get; set; }

        public KhachHang CusCompare { get; set; }

        public string KeySearch { get; set; }

        public CusList()
        {
            List = KhachHang.All();
        }

        public List<KhachHang> All()
        {
            return KhachHang.All();
        }

        public KhachHang Single(string _CusID)
        {
            if (List == null) List = All();
            return List.Find(delegate(KhachHang cus)
            {
                return cus.ID == _CusID;
            });
        }

        public bool Add(KhachHang cus)
        {
            if (KhachHang.Add(cus))
            {
                if (List == null) List = All();
                List.Add(cus);
                return true;
            }
            return false;
        }

        public bool Update(KhachHang cus)
        {
            if (KhachHang.Update(cus))
            {
                if (List == null) List = All();
                if (List.Count == 0)
                    List.Add(cus);
                else
                {
                    foreach (KhachHang item in List)
                    {
                        if (item.ID == cus.ID)
                        {
                            item.Ho = cus.Ho;
                            item.Ten = cus.Ten;
                            item.NgaySinh = cus.NgaySinh;
                            item.QuocGia = cus.QuocGia;
                            item.ThanhPho = cus.ThanhPho;
                            item.SoDT = cus.SoDT;
                            item.SoTaiKhoan = cus.SoTaiKhoan;
                            item.GTinh = cus.GTinh;
                            item.DiaChi = cus.DiaChi;
                            break;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public bool Delete(string _CusID)
        {
            if (KhachHang.Delete(_CusID))
            {
                if (List == null) List = All();
                int count = List.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (List[i].ID == _CusID)
                        {
                            List.RemoveAt(i);
                            break;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public List<KhachHang> Find(bool _gender)
        {
            if (List == null) List = All();
            if (List.Count > 0)
            {
                return List.FindAll(delegate(KhachHang cus)
                {
                    return cus.GTinh == _gender;
                });
            }
            return new List<KhachHang>();
        }

        public List<KhachHang> FindCountry(string _Country)
        {
            if (List == null) List = All();
            if (List.Count > 0)
            {
                return List.FindAll(delegate(KhachHang cus)
                {
                    return cus.QuocGia.ToUpper().Contains(_Country.ToUpper());
                });
            }
            return new List<KhachHang>();
        }

        public List<KhachHang> FindByCity(string _City)
        {
            if (List == null) List = All();
            if (List.Count > 0)
            {
                return List.FindAll(delegate(KhachHang cus)
                {
                    return cus.ThanhPho.ToUpper().Contains(_City.ToUpper());
                });
            }
            return new List<KhachHang>();
        }

        public List<KhachHang> FindByMonthBirthDay(int month)
        {
            if (List == null) List = All();
            if (List.Count > 0 && month <= 12 && month >= 1)
            {
                return List.FindAll(delegate(KhachHang cus)
                {
                    return cus.NgaySinh.Month == month;
                });
            }
            return new List<KhachHang>();
        }

        public List<KhachHang> FindByCode(string _code)
        {
            if (List == null) List = All();
            if (List.Count > 0)
            {
                return List.FindAll(delegate(KhachHang cus)
                {
                    return cus.ID.ToUpper().Contains(_code.ToUpper());
                });
            }
            return new List<KhachHang>();
        }

        public List<KhachHang> FindByName(string _name)
        {
            List<KhachHang> result = new List<KhachHang>();
            if (List == null) List = All();
            if (List.Count > 0)
            {
                List<KhachHang> list = List.FindAll(delegate(KhachHang cus)
                {
                    return (cus.Ho + " " + cus.Ten).ToUpper().Contains(_name.ToUpper());
                });
                IOrderedEnumerable<KhachHang> iter = list.OrderByDescending(x => x.Ho).ThenByDescending(x=>x.Ten);
                foreach (KhachHang item in iter)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public bool Test(string _name, string _address, string _city, string _country)
        {
            if (List == null) List = All();
            if (List.Count > 0)
            {
                List<KhachHang> rs = List.FindAll(delegate(KhachHang cus)
                {
                    return (cus.Ho + " " + cus.Ten).ToUpper().Contains(_name.ToUpper())
                        && cus.DiaChi.ToUpper().Contains(_address.ToUpper())
                        && cus.ThanhPho.ToUpper().Contains(_city.ToUpper())
                        && cus.QuocGia.ToUpper().Contains(_country.ToUpper());
                });

                if(rs.Count > 0)
                    return false;                
            }
            return true;
        }

        public List<KhachHang> FindByAccount(string _account)
        {
            if (List == null) List = All();
            if (List.Count > 0)
            {
                return List.FindAll(delegate(KhachHang cus)
                {
                    return cus.SoTaiKhoan.ToUpper().Contains(_account.ToUpper());
                });
            }
            return new List<KhachHang>();
        }

        /// <summary>
        /// Tim theo so dien thoai va sap giam theo so dien thoai
        /// </summary>
        /// <param name="_phone"></param>
        /// <returns></returns>
        public List<KhachHang> FindByPhone(string _phone)
        {
            List<KhachHang> result = new List<KhachHang>();
            if (List == null) List = All();
            if (List.Count > 0)
            {
                List<KhachHang> list = List.FindAll(delegate(KhachHang cus)
                {
                    return cus.SoDT.Contains(_phone);
                });
                IOrderedEnumerable<KhachHang> iter = list.OrderByDescending(x => x.SoDT);
                foreach (KhachHang item in iter)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        /// <summary>
        /// Tim va sap giam theo dia chi tu tren xuong
        /// </summary>
        /// <param name="_address"></param>
        /// <returns></returns>
        public List<KhachHang> FindByAdress(string _address)
        {
            List<KhachHang> result = new List<KhachHang>();
            if (List == null) List = All();
            if (List.Count > 0)
            {
                List<KhachHang> list = List.FindAll(delegate(KhachHang cus)
                {
                    return cus.DiaChi.ToUpper().Contains(_address.ToUpper());
                });
                IOrderedEnumerable<KhachHang> iter = list.OrderByDescending(x => x.DiaChi);
                foreach (KhachHang item in iter)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<KhachHang> FindByBirthDate(DateTime birth)
        {
            if (List == null) List = All();
            if (List.Count > 0)
            {
                return List.FindAll(delegate(KhachHang cus)
                {
                    return cus.NgaySinh.Date == birth.Date && cus.NgaySinh.Month == birth.Month && cus.NgaySinh.Year == birth.Year;
                });
            }
            return new List<KhachHang>();
        }

        
        public List<KhachHang> Find(string _key)
        {
            KeySearch = _key;
            if (List == null) List = All();
            if (List.Count > 0)
            {
                return List.FindAll(FindKey);
            }
            return new List<KhachHang>();
        }

        private bool FindKey(KhachHang _cus)
        {
            KeySearch = KeySearch.ToUpper();
            if (KeySearch != null)
            {
                return _cus.ID.ToUpper().Contains(KeySearch) ? true :

                    (_cus.Ho + " " + _cus.Ten).ToUpper().Contains(KeySearch) ? true :
                    
                    _cus.NgaySinh.ToShortDateString().Contains(KeySearch) ? true :

                    (_cus.GTinh == true && KeySearch.Contains("NAM")) ? true 
                    
                    : (_cus.GTinh == false && KeySearch.Contains("NỮ")) ? true
                    : _cus.SoDT.Contains(KeySearch) ? true :
                    _cus.SoTaiKhoan.Contains(KeySearch) ? true : 
                    _cus.DiaChi.ToUpper().Contains(KeySearch) ? true : _cus.ThanhPho.ToUpper().Contains(KeySearch) ? true : 
                    _cus.QuocGia.ToUpper().Contains(KeySearch) ? true 
                    
                    : false;
            }
            return true;
        }

        public List<KhachHang> FindByBirthDate(DateTime less, DateTime more)
        {
            if (List == null) List = All();
            if (List.Count > 0)
            {
                return List.FindAll(delegate(KhachHang cus)
                {
                    return cus.NgaySinh >= less && cus.NgaySinh <= more;
                });
            }
            return new List<KhachHang>();
        }

        


        //public List<KhachHang> FindByTrip(int _TripID)
        //{
        //    if (List == null) List = All();
        //    if (List.Count > 0)
        //    {
        //        return List.FindAll(delegate(KhachHang cus)
        //        {
        //            return (cus.Ho + " " + cus.Ten).Contains(_name);
        //        });
        //    }
        //    return new List<KhachHang>();
        //}


    }
}
