using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess
{
    public class MyConvert
    {
        public static double ToDouble(object value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Int32 ToInt32(object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static short ToShort(object value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static DateTime ToDateTime(object value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

        public static bool ToBool(object value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static String ToString(object value)
        {
            try
            {
                return Convert.ToString(value);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
