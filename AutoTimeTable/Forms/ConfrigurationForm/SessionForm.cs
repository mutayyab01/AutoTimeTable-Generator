using AutoTimeTable.SourceCode;
using System;
using System.Data;
using System.Windows.Forms;

namespace AutoTimeTable.Forms.ConfrigurationForm
{
    public partial class SessionForm : Form
    {
        public SessionForm()
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
                    query = "select SessionID [ID],Title,isActive [Status] from SessionTable";
                }
                else
                {

                    query = "select SessionID [ID],Title,isActive [Status] from SessionTable where Title like'%" + searchtext.Trim() + "%'";
                }
                DataTable sessionlist = DatabaseLayer.Retrieve(query);
                dataGridView1.DataSource = sessionlist;
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

        private void txtsearch_TextChanged(object sender, System.EventArgs e)
        {
            FillGrid(txtsearch.Text.Trim());
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtsessionTitle.Text.Length < 9)
            {
                errorProvider1.SetError(this.txtsessionTitle, "Please Enter Correct Session Title !");
                txtsessionTitle.Focus();
                txtsessionTitle.SelectAll();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from SessionTable where Title='" + txtsessionTitle.Text.Trim() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtsessionTitle, "ALready Exist Data !");
                    txtsessionTitle.Focus();
                    txtsessionTitle.SelectAll();
                    return;
                }
            }
            string insertquery = string.Format("insert into SessionTable (Title,isActive) values('{0}','{1}')",
                txtsessionTitle.Text.Trim(), chksession.Checked);

            bool result = DatabaseLayer.Insert(insertquery);
            if (result == true)
            {
                MessageBox.Show("Save Successfully ");
                DisbleComponent();
            }
            else
            {

                MessageBox.Show("Please Provide Correct Session Details\n Try Again ");
            }

        }
        public void clearform()
        {
            txtsessionTitle.Clear();
            chksession.Checked = false;
        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            clearform();
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
                            txtsessionTitle.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
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

        private void btncancel_Click(object sender, EventArgs e)
        {
            DisbleComponent();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtsessionTitle.Text.Length < 9)
            {
                errorProvider1.SetError(this.txtsessionTitle, "Please Enter Correct Session Title !");
                txtsessionTitle.Focus();
                txtsessionTitle.SelectAll();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from SessionTable where Title='" + txtsessionTitle.Text.Trim() + "' and SessionID !='"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtsessionTitle, "ALready Exist Data !");
                    txtsessionTitle.Focus();
                    txtsessionTitle.SelectAll();
                    return;
                }
            }
            string updatequery = string.Format("update SessionTable set Title='{0}',isActive='{1}' where SessionID='{2}'",
                txtsessionTitle.Text.Trim(), chksession.Checked, dataGridView1.CurrentRow.Cells[0].Value.ToString());

            bool result = DatabaseLayer.Update(updatequery);
            if (result == true)
            {
                MessageBox.Show("Update Successfully ");
                DisbleComponent();
            }
            else
            {

                MessageBox.Show("Please Provide Correct Session Details\n Try Again ");
            }
        }
    }
}
