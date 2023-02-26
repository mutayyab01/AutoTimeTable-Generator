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

namespace AutoTimeTable.Forms.ConfrigurationForm
{
    public partial class FormDays : Form
    {
        public FormDays()
        {
            InitializeComponent();
            FillGrid(string.Empty);
        }
        public void FillGrid(string searchtext)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchtext.ToUpper().Trim()))
                {
                    query = "select DayId [ID],Name [Name],isActive [Status] from DayTable";
                }
                else
                {

                    query = "select DayId [ID],Name [Name],isActive [Status] from DayTable where Name like'%" + searchtext.Trim().ToUpper() + "%'";
                }
                DataTable Programlist = DatabaseLayer.Retrieve(query);
                dataGridView1.DataSource = Programlist;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns[0].Width = 80;
                    dataGridView1.Columns[1].Width = 150;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch
            {

                MessageBox.Show("Some Issue Occur ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EnableComponent()
        {
            dataGridView1.Enabled = false;
            btnclear.Visible = false;
            btnsave.Visible = false;
            btnupdate.Visible = true;
            btncancel.Visible = true;
            txtsearch.Enabled = false;

        }
        public void DisbleComponent()
        {
            dataGridView1.Enabled = true;
            btnclear.Visible = true;
            btnsave.Visible = true;
            btnupdate.Visible = false;
            btncancel.Visible = false;
            txtsearch.Enabled = true;
            clearform();

            FillGrid(string.Empty);

        }
        public void clearform()
        {
            txtdayname.Clear();
            chksession.Checked = false;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtsearch.Text.ToUpper().Trim());

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtdayname.Text.Length == 0)
            {
                errorProvider1.SetError(this.txtdayname, "Please Enter Day Name !");
                txtdayname.Focus();
                txtdayname.SelectAll();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from DayTable where Name='" + txtdayname.Text.Trim().ToUpper() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtdayname, "ALready Exist Data !");
                    txtdayname.Focus();
                    txtdayname.SelectAll();
                    return;
                }
            }
            string insertquery = string.Format("insert into DayTable (Name,isActive) values('{0}','{1}')",
                txtdayname.Text.Trim().ToUpper(), chksession.Checked);

            bool result = DatabaseLayer.Insert(insertquery);
            if (result == true)
            {
                MessageBox.Show("Save Successfully ","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                DisbleComponent();
            }
            else
            {

                MessageBox.Show("Please Provide  Day Details\n Try Again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DisbleComponent();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clearform();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtdayname.Text.Length == 0)
            {
                errorProvider1.SetError(this.txtdayname, "Please Enter  Day Name !");
                txtdayname.Focus();
                txtdayname.SelectAll();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from DayTable where Name='" + txtdayname.Text.Trim().ToUpper() + "' and DayId !='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtdayname, "ALready Exist Data !");
                    txtdayname.Focus();
                    txtdayname.SelectAll();
                    return;
                }
            }
            string updatequery = string.Format("update DayTable set Name='{0}',isActive='{1}' where DayId='{2}'",
                txtdayname.Text.Trim().ToUpper(), chksession.Checked, dataGridView1.CurrentRow.Cells[0].Value.ToString());

            bool result = DatabaseLayer.Update(updatequery);
            if (result == true)
            {
                MessageBox.Show("Update Successfully ", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisbleComponent();
            }
            else
            {
                MessageBox.Show("Please Provide  Day Details\n Try Again ", "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmseditstrip_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (dataGridView1.SelectedRows.Count == 1)
                    {

                        try
                        {
                            txtdayname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                            chksession.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[2].Value);
                            EnableComponent();
                        }
                        catch
                        {
                            MessageBox.Show("Selected Row Is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Row ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("List Is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("List Is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }

}
