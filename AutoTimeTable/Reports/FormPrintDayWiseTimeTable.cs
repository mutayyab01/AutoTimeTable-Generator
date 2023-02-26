using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTimeTable.Reports
{
    public partial class FormPrintDayWiseTimeTable : Form
    {
        public FormPrintDayWiseTimeTable()
        {
            InitializeComponent();
            rpt_PrintDayWiseTimeTable rpt = new rpt_PrintDayWiseTimeTable();
            rpt.Refresh();
            crv.ReportSource = rpt;
        }
    }
}
