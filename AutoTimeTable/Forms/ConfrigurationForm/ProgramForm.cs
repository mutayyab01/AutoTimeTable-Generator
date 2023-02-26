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
    public partial class ProgramForm : Form
    {
        public ProgramForm()
        {
            InitializeComponent();
            FillGrid(string.Empty);
        }
        public void FillGrid(string searchtext)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchtext.Trim()))
                {
                    query = "select ProgramId [ID],Title [Program],isActive [Status] from ProgramTable";
                }
                else
                {

                    query = "select ProgramId [ID],Title [Program],isActive [Status] from ProgramTable where Title like'%" + searchtext.Trim() + "%'";
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
            txtprogramname.Clear();
            chksession.Checked = false;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtprogramname.Text.Trim());
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtprogramname.Text.Length == 0)
            {
                errorProvider1.SetError(this.txtprogramname, "Please Enter Program Name !");
                txtprogramname.Focus();
                txtprogramname.SelectAll();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from ProgramTable where Title='" + txtprogramname.Text.Trim() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtprogramname, "ALready Exist Data !");
                    txtprogramname.Focus();
                    txtprogramname.SelectAll();
                    return;
                }
            }
            string insertquery = string.Format("insert into ProgramTable (Title,isActive) values('{0}','{1}')",
                txtprogramname.Text.Trim(), chksession.Checked);

            bool result = DatabaseLayer.Insert(insertquery);
            if (result == true)
            {
                MessageBox.Show("Save Successfully ");
                DisbleComponent();
            }
            else
            {

                MessageBox.Show("Please Provide Correct Program Details\n Try Again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clearform();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DisbleComponent();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtprogramname.Text.Length == 0)
            {
                errorProvider1.SetError(this.txtprogramname, "Please Enter Correct Program Name !");
                txtprogramname.Focus();
                txtprogramname.SelectAll();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from ProgramTable where Title='" + txtprogramname.Text.Trim() + "' and ProgramId !='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtprogramname, "ALready Exist Data !");
                    txtprogramname.Focus();
                    txtprogramname.SelectAll();
                    return;
                }
            }
            string updatequery = string.Format("update ProgramTable set Title='{0}',isActive='{1}' where ProgramId='{2}'",
                txtprogramname.Text.Trim(), chksession.Checked, dataGridView1.CurrentRow.Cells[0].Value.ToString());

            bool result = DatabaseLayer.Update(updatequery);
            if (result == true)
            {
                MessageBox.Show("Update Successfully ","Succes",MessageBoxButtons.OK,MessageBoxIcon.Information);
                DisbleComponent();
            }
            else
            {
                MessageBox.Show("Please Provide Correct Program Details\n Try Again ","Errror",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                            txtprogramname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
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
