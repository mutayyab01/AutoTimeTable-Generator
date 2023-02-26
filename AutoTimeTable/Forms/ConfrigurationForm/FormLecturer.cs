using AutoTimeTable.SourceCode;
using System;
using System.Data;
using System.Windows.Forms;

namespace AutoTimeTable.Forms.ConfrigurationForm
{
    public partial class FormLecturer : Form
    {
        public FormLecturer()
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
                    query = "select LectureId [ID],Fullname [Name],ContactNo [Contact],isActive [Status] from LecturerTable";
                }
                else
                {

                    query = "select LectureId [ID],Fullname [Name],ContactNo [Contact],isActive [Status] from LecturerTable where (Fullname+' '+ ContactNo) like'%" + searchtext.Trim() + "%'";
                }
                DataTable lectruelist = DatabaseLayer.Retrieve(query);
                dataGridView1.DataSource = lectruelist;
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
            if (txtlecturername.Text.Length == 0 || txtlecturername.Text.Length > 31)
            {
                errorProvider1.SetError(this.txtlecturername, "Please Enter Lab No/Name Correct ANd Must Be Less Than 31 Character !");
                txtlecturername.Focus();
                txtlecturername.SelectAll();
                return;
            }
            if (txtcontactno.Text.Length < 12)
            {
                errorProvider1.SetError(this.txtcontactno, "Please Enter Contact No!");
                txtcontactno.Focus();
                txtcontactno.SelectAll();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from LecturerTable where Fullname='" + txtlecturername.Text.Trim() + "' and  ContactNo='"+txtcontactno.Text.Trim()+"'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtlecturername, "ALready Exist Data !");
                    txtlecturername.Focus();
                    txtlecturername.SelectAll();
                    return;
                }
            }
            string insertquery = string.Format("insert into LecturerTable (Fullname,ContactNo,isActive) values('{0}','{1}','{2}')",
                txtlecturername.Text.Trim(), txtcontactno.Text.Trim(), chksession.Checked);

            bool result = DatabaseLayer.Insert(insertquery);
            if (result == true)
            {
                MessageBox.Show("Save Successfully ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtlecturername.Clear();
            txtcontactno.Clear();
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
                            txtlecturername.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                            txtcontactno.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
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
            if (txtlecturername.Text.Length == 0 || txtlecturername.Text.Length > 31)
            {
                errorProvider1.SetError(this.txtlecturername, "Please Enter Lab No/Name Correct ANd Must Be Less Than 31 Character !");
                txtlecturername.Focus();
                txtlecturername.SelectAll();
                return;
            }
            if (txtcontactno.Text.Length < 12)
            {
                errorProvider1.SetError(this.txtcontactno, "Please Enter Contact No!");
                txtcontactno.Focus();
                txtcontactno.SelectAll();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from LecturerTable where Fullname='" + txtlecturername.Text.Trim() + "' and ContactNo='" + txtcontactno.Text.Trim() +"'  and LectureId !='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtlecturername, "ALready Exist Data !");
                    txtlecturername.Focus();
                    txtlecturername.SelectAll();
                    return;
                }
            }
            string updatequery = string.Format("update LecturerTable set Fullname='{0}',ContactNo='{1}',isActive='{2}' where LectureId='{3}'",
                txtlecturername.Text.Trim(), txtcontactno.Text.Trim(), chksession.Checked, dataGridView1.CurrentRow.Cells[0].Value.ToString());

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
