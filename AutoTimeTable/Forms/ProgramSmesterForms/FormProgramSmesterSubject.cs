using AutoTimeTable.SourceCode;
using System;
using System.Data;
using System.Windows.Forms;

namespace AutoTimeTable.Forms.ProgramSmesterForms
{
    public partial class FormProgramSmesterSubject : Form
    {
        public FormProgramSmesterSubject()
        {
            InitializeComponent();
            ComboHelper.AllProgramSmerterComboBox(cmbSmerter);
            ComboHelper.AllTeacherSubjectComboBox(cmbSubjects);
            FillGrid(string.Empty);
        }

        private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTitle.Text = cmbSubjects.SelectedIndex == 0 ? string.Empty : cmbSubjects.Text;
        }
        public void FillGrid(string searchtext)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchtext.Trim()))
                {
                    query = "select [ProgramSmesterSubjectId][ID],[ProgramID],[Program]," +
                        "ProgramSmesterId,Title[Smester],LectureSubjectID,SSTitle[Subject],Capacity," +
                        "isSubjectActive[Status] from v_AllSemestersSubjects where [ProgramSemesterIsActive]=1 and [ProgramIsActive]=1 and " +
                        "[SemesterIsActive]=1 and [SubjectIsActive]=1 Order By ProgramSmesterId ";
                }
                else
                {

                    query = "select [ProgramSmesterSubjectId][ID],[ProgramID],[Program]," +
                       "ProgramSmesterId,Title[Smester],LectureSubjectID,SSTitle[Subject],Capacity," +
                       "isSubjectActive[Status] from v_AllSemestersSubjects where [ProgramSemesterIsActive]=1 and [ProgramIsActive]=1 and " +
                       "[SemesterIsActive]=1 and [SubjectIsActive]=1 and (ProgramName+' '+ Title+' '+SSTitle) like '%" + searchtext + "%'  Order By ProgramSmesterId ";
                }
                DataTable Smesterlist = DatabaseLayer.Retrieve(query);
                dataGridView1.DataSource = Smesterlist;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns[0].Visible = false; // ProgramSmesterSubjectId
                    dataGridView1.Columns[1].Visible = false; // ProgramID
                    dataGridView1.Columns[2].Width = 120; // ProgramName
                    dataGridView1.Columns[3].Visible = false; // ProgramSmesterId
                    dataGridView1.Columns[4].Width = 150; // Smester
                    dataGridView1.Columns[5].Visible = false; // LectureSubjectID
                    dataGridView1.Columns[6].Width = 300; // Subject
                    dataGridView1.Columns[7].Width = 80; // Capacity
                    dataGridView1.Columns[8].Width = 80; // Status
                    dataGridView1.ClearSelection();
                }
            }
            catch
            {

                MessageBox.Show("Some Unexpected Issue Occur  Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void FormClear()
        {
            txtTitle.Clear();
            cmbSubjects.SelectedIndex = 0;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtsearch.Text.Trim());
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtTitle.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(this.txtTitle, "PLease Enter Smester Subject Title");
                txtTitle.Focus();
                txtTitle.SelectAll();
                return;
            }
            if (cmbSmerter.SelectedIndex == 0)
            {
                errorProvider1.SetError(this.cmbSmerter, "PLease Select Smester");
                cmbSmerter.Focus();
                return;
            }
            if (cmbSubjects.SelectedIndex == 0)
            {
                errorProvider1.SetError(this.cmbSubjects, "PLease Select Subject");
                cmbSubjects.Focus();
                return;
            }
            string checkquery = "select * from ProgramSmesterSubjectTable where ProgramSmesterId='" + cmbSmerter.SelectedValue + "' " +
                "and LectureSubjectId='" + cmbSubjects.SelectedValue + "'";
            DataTable dt = DatabaseLayer.Retrieve(checkquery);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(cmbSubjects, "Allready Exist");
                    cmbSubjects.Focus();
                    return;
                }
            }
            string insertquery = string.Format("insert into ProgramSmesterSubjectTable (SSTitle,ProgramSmesterId,LectureSubjectId) values ('{0}','{1}','{2}')",
                txtTitle.Text.Trim(), cmbSmerter.SelectedValue, cmbSubjects.SelectedValue);
            bool result = DatabaseLayer.Insert(insertquery);
            if (result == true)
            {
                MessageBox.Show("Subject Assigned SucccessFully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGrid(string.Empty);
                FormClear();
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
                        if (MessageBox.Show("Are You Sure You Want to Change Status", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                bool existStatus = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[8].Value);
                                int SmesterId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                                bool status = false;
                                if (existStatus == true)
                                {
                                    status = false;
                                }
                                else
                                {
                                    status = true;
                                }
                                string UpdateQuery = string.Format("update ProgramSmesterSubjectTable set isSubjectActive='{0}' where ProgramSmesterSubjectID ='{1}'",
                                    status, SmesterId);
                                bool result = DatabaseLayer.Update(UpdateQuery);
                                if (result == true)
                                {
                                    MessageBox.Show("Status Changed SuccessFully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    FillGrid(string.Empty);
                                }
                                else
                                {
                                    MessageBox.Show("Please Try Again!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch 
                            {
                                MessageBox.Show("Selected Row Is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("List Is Empty", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                
            }
            else
            {
                MessageBox.Show("List Is Empty", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
        