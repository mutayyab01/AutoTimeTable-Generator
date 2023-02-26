using AutoTimeTable.SourceCode;
using System;
using System.Data;
using System.Windows.Forms;

namespace AutoTimeTable.Forms.ProgramSmesterForms
{
    public partial class FormSemesterSections : Form
    {
        public FormSemesterSections()
        {
            InitializeComponent();
            ComboHelper.AllProgramSmerterComboBox(cmbSemesters);
            FillGrid(string.Empty);
        }
        public void FillGrid(string searchvalue)
        {

            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchvalue.Trim()))
                {
                    query = " select SectionID, SectionTitle [Section], ProgramSemesterID, Title [Semester],IsActive [Status] from v_AllSemesterSections order by ProgramSemesterID ";
                }
                else
                {
                    query = " select SectionID, SectionTitle [Section], ProgramSemesterID, Title [Semester],IsActive [Status] from v_AllSemesterSections " +
                            " WHERE (SectionTitle + ' ' + Title) like '%" + searchvalue.Trim() + "%' order by ProgramSemesterID";
                }

                DataTable sectionlist = DatabaseLayer.Retrieve(query);
                dataGridView1.DataSource = sectionlist;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns[0].Visible = false; // SectionID
                    dataGridView1.Columns[1].Width = 200; //SectionTitle
                    dataGridView1.Columns[2].Visible = false; // ProgramSemesterID
                    dataGridView1.Columns[3].Width = 200; // Title
                    dataGridView1.Columns[4].Width = 80; // IsActive

                    dataGridView1.ClearSelection();
                }
            }
            catch
            {
                MessageBox.Show("Some unexpected issue occure plz try again!");
            }
        }
        private void FormClear()
        {
            txtTitle.Clear();
            cmbSemesters.SelectedIndex = 0;
        }


        private void txtCapacity_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnclear_Click(object sender, System.EventArgs e)
        {
            FormClear();
        }

        private void txtsearch_TextChanged(object sender, System.EventArgs e)
        {
            FillGrid(txtsearch.Text.Trim());
        }

        private void btnsave_Click(object sender, System.EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (txtTitle.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtTitle, "Please Enter Section Title!");
                    txtTitle.Focus();
                    return;
                }

                if (cmbSemesters.SelectedIndex == 0)
                {
                    errorProvider1.SetError(cmbSemesters, "Please Select Semester!");
                    cmbSemesters.Focus();
                    return;
                }
                // Check Existing Record, if found show "Already Exists" message near txtTitle
                DataTable dt = DatabaseLayer.Retrieve("select * from SectionTable where SectionTitle = '" + txtTitle.Text.Trim() + "' and ProgramSemesterID = '" + cmbSemesters.SelectedValue + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        errorProvider1.SetError(txtTitle, "Already Exists!");
                        txtTitle.Focus();
                        return;
                    }
                }
                // Query for save/insert record in sectiontable
                string insertquery = string.Format("insert into SectionTable(SectionTitle,ProgramSemesterID) values('{0}','{1}')", txtTitle.Text.Trim(), cmbSemesters.SelectedValue);
                bool result = DatabaseLayer.Insert(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Save Successfully!");
                    FillGrid(string.Empty);
                    FormClear();
                }
                else
                {
                    MessageBox.Show("Please Try Again!");
                }
            }
            catch (Exception ex) // Show Error message in any case if exception generate
            {
                MessageBox.Show(ex.Message);
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

                        if (MessageBox.Show("Are you sure you want to change status?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bool existstatus = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value);
                            int sectionid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                            bool status = false;
                            if (existstatus == true)
                            {
                                status = false;
                            }
                            else
                            {
                                status = true;
                            }
                            string updatequery = string.Format("update SectionTable set IsActive = '{0}' where SectionID = '{1}'", status, sectionid);
                            bool result = DatabaseLayer.Update(updatequery);
                            if (result == true)
                            {
                                MessageBox.Show("Change Successfully!");
                                FillGrid(string.Empty);
                            }
                            else
                            {
                                MessageBox.Show("Please Try Again!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record!");
                    }
                }
                else
                {
                    MessageBox.Show("List is Empty!");
                }
            }
            else
            {
                MessageBox.Show("List is Empty!");
            }
        }
    }
}
