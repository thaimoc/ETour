using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ETourPro.travel_guide;
using ETourPro.vehicles;
using ETourPro.Admin_Tool;
using ETourPro.Suppliers_Vehicle;
using ETourPro.Locals;
using ETourPro.Scenic;
using ETourPro.Hotels;
using ETourPro.Tours;
using ETourPro.Travel_Trips;
using ETourPro.Customers;

namespace ETourPro
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
