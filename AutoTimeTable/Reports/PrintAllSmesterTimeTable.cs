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
    public partial class PrintAllSmesterTimeTable : Form
    {
        public PrintAllSmesterTimeTable()
        {
            InitializeComponent();
            rpt_SemesterWiseTimeaTable rpt =new  rpt_SemesterWiseTimeaTable();
            rpt.Refresh();
            crv.ReportSource = rpt;
        }

        private void PrintAllSmesterTimeTable_Load(object sender, EventArgs e)
        {

        }
    }
}
