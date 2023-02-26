using AutoTimeTable.SourceCode;
using System;
using System.Data;
using System.Windows.Forms;

namespace AutoTimeTable.Forms.ConfrigurationForm
{
    public partial class FormRooms : Form
    {
        public FormRooms()
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
                    query = "select RoomId [ID],RoomNo [Room],Capacity [Capacity],isActive [Status] from RoomTable";
                }
                else
                {

                    query = "select RoomId [ID],RoomNo [Room],Capacity [Capacity],isActive [Status] from RoomTable where RoomNo like'%" + searchtext.Trim() + "%'";
                }
                DataTable Roomlist = DatabaseLayer.Retrieve(query);
                dataGridView1.DataSource = Roomlist;
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
            if (txtroomno.Text.Length == 0|| txtroomno.Text.Length > 10)
            {
                errorProvider1.SetError(this.txtroomno, "Please Enter Room No/Name Correct ANd Must Be Less Than 11 Character !");
                txtroomno.Focus();
                txtroomno.SelectAll();
                return;
            }
            if (txtcapacity.Text.Length == 0)
            {
                errorProvider1.SetError(this.txtcapacity, "Please Enter Room Capacity!");
                txtcapacity.Focus();
                txtcapacity.SelectAll();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from RoomTable where RoomNo='" + txtroomno.Text.Trim() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtroomno, "ALready Exist Data !");
                    txtroomno.Focus();
                    txtroomno.SelectAll();
                    return;
                }
            }
            string insertquery = string.Format("insert into RoomTable (RoomNo,Capacity,isActive) values('{0}','{1}','{2}')",
                txtroomno.Text.Trim(), txtcapacity.Text.Trim(), chksession.Checked);

            bool result = DatabaseLayer.Insert(insertquery);
            if (result == true)
            {
                MessageBox.Show("Save Successfully ");
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
            txtroomno.Clear();
            txtcapacity.Clear();
            chksession.Checked = false;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clearform();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DisbleComponent();
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
                            txtroomno.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
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
            if (txtroomno.Text.Length == 0 || txtroomno.Text.Length > 10)
            {
                errorProvider1.SetError(this.txtroomno, "Please Enter Room No/Name Correct ANd Must Be Less Than 11 Character !");
                txtroomno.Focus();
                txtroomno.SelectAll();
                return;
            }
            if (txtcapacity.Text.Length == 0)
            {
                errorProvider1.SetError(this.txtcapacity, "Please Enter Room Capacity!");
                txtcapacity.Focus();
                txtcapacity.SelectAll();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from RoomTable where RoomNo='" + txtroomno.Text.Trim() + "' and RoomId !='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtroomno, "ALready Exist Data !");
                    txtroomno.Focus();
                    txtroomno.SelectAll();
                    return;
                }
            }
            string updatequery = string.Format("update RoomTable set RoomNo='{0}',Capacity='{1}',isActive='{2}' where RoomId='{3}'",
                txtroomno.Text.Trim(), txtcapacity.Text.Trim(),chksession.Checked, dataGridView1.CurrentRow.Cells[0].Value.ToString());

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
