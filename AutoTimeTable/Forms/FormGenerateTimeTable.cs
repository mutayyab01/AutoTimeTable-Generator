using AutoTimeTable.SourceCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTimeTable.Forms
{
    public partial class FormGenerateTimeTable : Form
    {
        public FormGenerateTimeTable()
        {
            InitializeComponent();
        }

        private void btnGenerateTimeTable_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                string message = GenerateTimeTable.AutoGenerateTimeTable(dtpStartDate.Value, dtpEndDate.Value);
                MessageBox.Show(message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
