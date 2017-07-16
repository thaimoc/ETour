using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class DateTimeComparer : IComparer<string>
    {
        #region IComparer<string> Members

        int IComparer<string>.Compare(string x, string y)
        {
            DateTime xDate = DateTime.MinValue;
            DateTime yDate = DateTime.MinValue;
            if (!string.IsNullOrEmpty(x))
                xDate = DateTime.Parse(x, new System.Globalization.CultureInfo("en-US"));
            if (!string.IsNullOrEmpty(y))
                yDate = DateTime.Parse(y, new System.Globalization.CultureInfo("en-US"));

            return (Comparer<DateTime>.Default.Compare(xDate, yDate));
        }

        #endregion
    }

    public class DoubleComparer : IComparer<double>
    {
        int IComparer<double>.Compare(double x, double y)
        {
            return (Comparer<Double>.Default.Compare(x, y));
        }
    }

    public class IntComparer : IComparer<int>
    {
        int IComparer<int>.Compare(int x, int y)
        {
            return (Comparer<int>.Default.Compare(x, y));
        }
    }

    public class ScenicCompare
    {
        public static int CompareScenicByStartPlace(Chuyen a, Chuyen b)
        {
            string x = a.XuatPhat;
            string y = b.XuatPhat;
            //return String.Compare(x, y);
            return CompareLength(x, y);
        }

        public static int CompareScenicByTourName(Chuyen a, Chuyen b)
        {
            string x = a.TenTour;
            string y = b.TenTour;
            //return String.Compare(x, y);
            return CompareLength(x, y);
        }

        private static int CompareLength(string x, string y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.Length.CompareTo(y.Length);

                    if (retval != 0)
                    {
                        // If the strings are not of equal length,
                        // the longer string is greater.
                        //
                        return retval;
                    }
                    else
                    {
                        // If the strings are of equal length,
                        // sort them with ordinary string comparison.
                        //
                        return x.CompareTo(y);
                    }
                }
            }
        }
    }
    
}
