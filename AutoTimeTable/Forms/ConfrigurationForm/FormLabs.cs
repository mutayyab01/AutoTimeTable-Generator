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
    public partial class FormLabs : Form
    {
        public FormLabs()
        {
            InitializeComponent();
            FillGrid(string.Empty);
        }

        private void txtcapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public void FillGrid(string searchtext)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchtext.Trim()))
                {
                    query = "select LabId [ID],LabNo [Room],Capacity [Capacity],isActive [Status] from LabTable";
                }
                else
                {

                    query = "select LabId [ID],LabNo [Room],Capacity [Capacity],isActive [Status] from LabTable where LabNo like'%" + searchtext.Trim() + "%'";
                }
                DataTable lablist = DatabaseLayer.Retrieve(query);
                dataGridView1.DataSource = lablist;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns[0].Width = 80;
                    dataGridView1.Columns[1].Width = 150;
                    dataGridView1.Columns[2].Width = 100;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch
            {

                MessageBox.Show("Some Issue Occur ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtsearch.Text.Trim());

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtlabno.Text.Length == 0 || txtlabno.Text.Length > 31)
            {
                errorProvider1.SetError(this.txtlabno, "Please Enter Lab No/Name Correct ANd Must Be Less Than 31 Character !");
                txtlabno.Focus();
                txtlabno.SelectAll();
                return;
            }
            if (txtcapacity.Text.Length == 0)
            {
                errorProvider1.SetError(this.txtcapacity, "Please Enter Lab Capacity!");
                txtcapacity.Focus();
                txtcapacity.SelectAll();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from LabTable where LabNo='" + txtlabno.Text.Trim() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtlabno, "ALready Exist Data !");
                    txtlabno.Focus();
                    txtlabno.SelectAll();
                    return;
                }
            }
            string insertquery = string.Format("insert into LabTable (LabNo,Capacity,isActive) values('{0}','{1}','{2}')",
                txtlabno.Text.Trim(), txtcapacity.Text.Trim(), chksession.Checked);

            bool result = DatabaseLayer.Insert(insertquery);
            if (result == true)
            {
                MessageBox.Show("Save Successfully ","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                DisbleComponent();
            }
            else
            {

                MessageBox.Show("Please Provide Correct Smester Details\n Try Again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtlabno.Clear();
            txtcapacity.Clear();
            chksession.Checked = false;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DisbleComponent();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clearform();
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
                            txtlabno.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                            txtcapacity.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                            chksession.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[3].Value);
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtlabno.Text.Length == 0 || txtlabno.Text.Length > 31)
            {
                errorProvider1.SetError(this.txtlabno, "Please Enter Lab No/Name Correct ANd Must Be Less Than 31 Character !");
                txtlabno.Focus();
                txtlabno.SelectAll();
                return;
            }
            if (txtcapacity.Text.Length == 0)
            {
                errorProvider1.SetError(this.txtcapacity, "Please Enter Lab Capacity!");
                txtcapacity.Focus();
                txtcapacity.SelectAll();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from LabTable where LabNo='" + txtlabno.Text.Trim() + "' and LabId !='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtlabno, "ALready Exist Data !");
                    txtlabno.Focus();
                    txtlabno.SelectAll();
                    return;
                }
            }
            string updatequery = string.Format("update LabTable set LabNo='{0}',Capacity='{1}',isActive='{2}' where LabId='{3}'",
                txtlabno.Text.Trim(), txtcapacity.Text.Trim(), chksession.Checked, dataGridView1.CurrentRow.Cells[0].Value.ToString());

            bool result = DatabaseLayer.Update(updatequery);
            if (result == true)
            {
                MessageBox.Show("Update Successfully ", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisbleComponent();
            }
            else
            {

                MessageBox.Show("Please Provide Correct Smester Details\n Try Again ");
            }
        }
    }
}
