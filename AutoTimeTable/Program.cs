using AutoTimeTable.Forms;
using AutoTimeTable.Forms.ConfrigurationForm;
using AutoTimeTable.Forms.LecturerSubjectForms;
using AutoTimeTable.Forms.ProgramSmesterForms;
using AutoTimeTable.Forms.TimeSlotForms;
using AutoTimeTable.Reports;
using LoginScreen;
using Mart_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTimeTable
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static HomeForm Home;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Home = new HomeForm();
            Application.Run(Program.Home);
        }
    }
}
