using System;
using System.Configuration;
using Core;
using System.Collections.Generic;

namespace DataAccess
{
    public class Login
    {
        string _User;

        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
        string _Pass;

        public string Pass
        {
            get { return _Pass; }
            set { _Pass = value; }
        }

        string _Powers = "";

        public string Powers
        {
            get { return _Powers; }
            set { _Powers = value; }
        }

        public static Login FunctionLogin(Login log)
        {
            return CBO.FillObject<Login>(DataProvider.Instance.ExecuteReader("Login_Log", log.Powers, log.User, log.Pass));
        }

        public static bool Add(Login log)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("Login_Add", log.Powers, log.User, log.Pass);
            return MyConvert.ToInt32(rs) > 0;
        }

        public static List<Login> All()
        {
            return CBO.FillCollection<Login>(DataProvider.Instance.ExecuteReader("Login_All"));
        }

        public static Login Single(string userName)
        {
            return CBO.FillObject<Login>(DataProvider.Instance.ExecuteReader("Login_Single", userName));
        }
        

        public static bool Update(Login log)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("Login_Update", log.Powers, log.User, log.Pass);
            return MyConvert.ToInt32(rs) > 0;
        }

        public static bool Delete(string _User)
        {
            object rs = DataProvider.Instance.ExecuteNonQuery("Login_Delete", _User);
            return MyConvert.ToInt32(rs) > 0;
        }
        

    }
}
