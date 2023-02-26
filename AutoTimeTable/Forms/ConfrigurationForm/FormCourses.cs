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
    public partial class FormCourses : Form
    {
        public FormCourses()
        {
            InitializeComponent();
            //cmbcrHrs.SelectedIndex = 0;
            ComboHelper.RoomTypesComboBox(cmbselectType);
            FillGrid(string.Empty);
            cmbselectType.SelectedIndex = 0;
        }
        public void FillGrid(string searchtext)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchtext.Trim()))
                {
                    query = "select CourseId[ID],Title[Subject],CrHour,RoomTypeID,TypeName[Room Type] ,isActive from v_AllSubject";
                }
                else
                {

                    query = "select CourseId[ID],Title[Subject],CrHour,RoomTypeID,TypeName[Room Type] ,isActive from v_AllSubject where (Title+' '+TypeName) like'%" + searchtext.Trim() + "%'";
                }
                DataTable lablist = DatabaseLayer.Retrieve(query);
                dataGridView1.DataSource = lablist;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns[0].Width = 40;  // CourseId
                    dataGridView1.Columns[1].Width = 250; // Title
                    dataGridView1.Columns[2].Width = 40; // CrHour
                    dataGridView1.Columns[3].Visible = false; // RoomTypeID
                    dataGridView1.Columns[4].Width = 50; // TypeName
                    dataGridView1.Columns[5].Width = 80; // isActive
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
            if (txtsubjecttitle.Text.Length == 0)
            {
                errorProvider1.SetError(this.txtsubjecttitle, "Please Enter Title !");
                txtsubjecttitle.Focus();
                txtsubjecttitle.SelectAll();
                return;
            }
            if (cmbselectType.SelectedIndex == 0)
            {
                errorProvider1.SetError(this.cmbselectType, "Please Select Type !");
                cmbselectType.Focus();
                return;
            }
            if (cmbcrHrs.Text==string.Empty)
            {
                errorProvider1.SetError(this.cmbcrHrs, "Please Select Credit Hours !");
                cmbcrHrs.Focus();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from CourseTable where Title='" + txtsubjecttitle.Text.Trim() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtsubjecttitle, "ALready Exist Data !");
                    txtsubjecttitle.Focus();
                    txtsubjecttitle.SelectAll();
                    return;
                }
            }
            string insertquery = string.Format("insert into CourseTable (Title,CrHour,RoomTypeID,isActive) values('{0}','{1}','{2}','{3}')",
                txtsubjecttitle.Text.Trim(), cmbcrHrs.Text, cmbselectType.SelectedValue, chksession.Checked);

            bool result = DatabaseLayer.Insert(insertquery);
            if (result == true)
            {
                MessageBox.Show("Save Successfully ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisbleComponent();
            }
            else
            {

                MessageBox.Show("Please Provide Correct  Details\n Try Again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtsubjecttitle.Clear();
            cmbselectType.SelectedIndex = 0;
            cmbcrHrs.SelectedIndex = 0;
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
                            txtsubjecttitle.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                            chksession.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[5].Value);
                            cmbselectType.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value.ToString(); // ProgramID
                            cmbcrHrs.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString(); // SmesterID
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
            if (txtsubjecttitle.Text.Length == 0)
            {
                errorProvider1.SetError(this.txtsubjecttitle, "Please Enter Title !");
                txtsubjecttitle.Focus();
                txtsubjecttitle.SelectAll();
                return;
            }
            if (cmbselectType.SelectedIndex == 0)
            {
                errorProvider1.SetError(this.cmbselectType, "Please Select Type !");
                cmbselectType.Focus();
                return;
            }

            DataTable checktitle = DatabaseLayer.Retrieve("select * from CourseTable where Title='" + txtsubjecttitle.Text.Trim() + "' and CourseId!='"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtsubjecttitle, "ALready Exist Data !");
                    txtsubjecttitle.Focus();
                    txtsubjecttitle.SelectAll();
                    return;
                }
            }
            string updatequery = string.Format("update CourseTable set Title='{0}',CrHour='{1}',RoomTypeID='{2}',isActive='{3}' where CourseId='{4}'",
                txtsubjecttitle.Text.Trim(), cmbcrHrs.Text, cmbselectType.SelectedValue, chksession.Checked, dataGridView1.CurrentRow.Cells[0].Value.ToString());

            bool result = DatabaseLayer.Update(updatequery);
            if (result == true)
            {
                MessageBox.Show("Updated Successfully ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisbleComponent();
            }
            else
            {

                MessageBox.Show("Please Provide Correct  Details\n Try Again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
