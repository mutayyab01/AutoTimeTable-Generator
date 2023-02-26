using AutoTimeTable.SourceCode;
using System;
using System.Data;
using System.Windows.Forms;

namespace AutoTimeTable.Forms.LecturerSubjectForms
{
    public partial class LecturerSubjectForm : Form
    {
        public LecturerSubjectForm()
        {
            InitializeComponent();
            ComboHelper.AllTeachersComboBox(cmbTeacher);
            ComboHelper.AllSubjectsComboBox(cmbSubjects);
            FillGrid(string.Empty);
        }
        public void FillGrid(string searchtext)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchtext.Trim()))
                {
                    query = "select LectureSubjectId[ID],SubjectTitle[Subject Title],LectureID,Fullname[Lecture],CourseID,Title[Course],isActive[Status] from v_AllSubjectTeacher";
                }
                else
                {

                    query = "select LectureSubjectId[ID],SubjectTitle[Subject Title],LectureID,Fullname[Lecture],CourseID,Title[Course],isActive[Status] from v_AllSubjectTeacher where  (SubjectTitle+' '+Fullname+' '+Title) like'%" + searchtext.Trim() + "%'";
                }
                DataTable sessionlist = DatabaseLayer.Retrieve(query);
                dataGridView1.DataSource = sessionlist;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns[0].Visible = false; // LectureSubjectId
                    dataGridView1.Columns[1].Width = 250; // SubjectTitle
                    dataGridView1.Columns[2].Visible = false; // LectureID
                    dataGridView1.Columns[3].Width = 150; // Fullname
                    dataGridView1.Columns[4].Visible = false; // CourseID
                    dataGridView1.Columns[5].Width = 300; // Title
                    dataGridView1.Columns[6].Width = 60; // isActive


                }
            }
            catch
            {

                MessageBox.Show("Some Issue Occur ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public void clearform()
        {
            cmbTeacher.SelectedIndex = 0;
            cmbSubjects.SelectedIndex = 0;
            chksession.Checked = true;
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
            //btnupdate.Visible = true;
            //btncancel.Visible = true;
            txtsearch.Enabled = false;

        }
        public void DisbleComponent()
        {
            dataGridView1.Enabled = true;
            btnclear.Visible = true;
            btnsave.Visible = true;
            //btnupdate.Visible = false;
            //btncancel.Visible = false;
            txtsearch.Enabled = true;
            clearform();

            FillGrid(string.Empty);

        }

        private void btnclear_Click_1(object sender, EventArgs e)
        {
            clearform();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DisbleComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (cmbTeacher.SelectedIndex == 0)
                {
                    errorProvider1.SetError(this.cmbTeacher, "Please Select Teachers !");
                    cmbTeacher.Focus();
                    return;
                }
                if (cmbSubjects.SelectedIndex == 0)
                {
                    errorProvider1.SetError(this.cmbSubjects, "Please Select Subject !");
                    cmbSubjects.Focus();
                    return;
                }
                DataTable dt = DatabaseLayer.Retrieve("select * from LectureSubjectTable where LectureID='" + cmbTeacher.SelectedValue + "' and CourseID='" + cmbSubjects.SelectedValue + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        errorProvider1.SetError(this.cmbSubjects, "Already Registered !");
                        cmbSubjects.Focus();
                        return;
                    }
                }
                string insertquery = string.Format("insert into LectureSubjectTable (SubjectTitle,LectureID,CourseID,isActive) values('{0}','{1}','{2}','{3}')",
                    cmbSubjects.Text + "(" + cmbTeacher.Text + ")", cmbTeacher.SelectedValue, cmbSubjects.SelectedValue, chksession.Checked);
                bool result = DatabaseLayer.Insert(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Subject Assigned SuccessFully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisbleComponent();
                    return;
                }
                else
                {
                    MessageBox.Show("Some Unexpected Issue Is Found Please Try Again", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

                MessageBox.Show("Please Check Sql Server Connectivity And Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmseditstrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1 != null)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        if (dataGridView1.SelectedRows.Count == 1)
                        {
                            if (MessageBox.Show("Are you Sure You Want To Update Selected Record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                string ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                                bool status = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[6].Value) == true ? false : true;
                                string updatequery = "update LectureSubjectTable set isActive='" + status + "' where LectureSubjectId='" + ID + "'";

                                bool result = DatabaseLayer.Update(updatequery);
                                if (result == true)
                                {
                                    MessageBox.Show("Status Changed SuccessFully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    DisbleComponent();
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Some Unexpected Issue Is Found Please Try Again", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {


            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtsearch.Text.Trim());
        }
    }
}
