using AutoTimeTable.SourceCode;
using System;
using System.Data;
using System.Windows.Forms;


namespace AutoTimeTable.Forms.ProgramSmesterForms
{
    public partial class FormProgramSmester : Form
    {
        public FormProgramSmester()
        {
            InitializeComponent();
            ComboHelper.ProgramComboBox(cmbselectProgram);
            ComboHelper.SmesterComboBox(cmbselectSmester);
            FillGrid(string.Empty);
        }
        public void FillGrid(string searchtext)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchtext.Trim()))
                {
                    query = "select  ProgramSmesterId[ID],Title,Capacity,ProgramSemesterIsActive[Status],ProgramID,SmesterID from v_ProgramSmesteerActiveList";
                }
                else
                {

                    query = "select  ProgramSmesterId[ID],Title,Capacity,ProgramSemesterIsActive[Status],ProgramID,SmesterID from v_ProgramSmesteerActiveList where Title like'%" + searchtext.Trim() + "%'";
                }
                DataTable lablist = DatabaseLayer.Retrieve(query);
                dataGridView1.DataSource = lablist;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns[0].Width = 80;  // ProgramSmesterId
                    dataGridView1.Columns[1].Width = 250; // Title
                    dataGridView1.Columns[2].Width = 100; // Capacity
                    dataGridView1.Columns[3].Width = 100; // ProgramSmesterisActive
                    dataGridView1.Columns[4].Visible = false; // ProgramID
                    dataGridView1.Columns[5].Visible = false; // SmesterID
                }
            }
            catch
            {

                MessageBox.Show("Some Issue Occur ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region Full Grid Un Active List Logic
        public void FillGridUnActive(string searchtext)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchtext.Trim()))
                {
                    query = "select  ProgramSmesterId[ID],Title,ProgramSmesterisActive[Status],ProgramID,SmesterID from v_ProgramSmesteerUnActiveList";
                }
                else
                {

                    query = "select  ProgramSmesterId[ID],Title,ProgramSmesterisActive[Status],ProgramID,SmesterID from v_ProgramSmesteerUnActiveList where Title like'%" + searchtext.Trim() + "%'";
                }
                DataTable lablist = DatabaseLayer.Retrieve(query);
                dataGridView1.DataSource = lablist;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns[0].Width = 80;  // ProgramSmesterId
                    dataGridView1.Columns[1].Width = 250; // Title
                    dataGridView1.Columns[2].Width = 100; // ProgramSmesterisActive
                    dataGridView1.Columns[3].Visible = false; // ProgramID
                    dataGridView1.Columns[4].Visible = false; // SmesterID
                }
                else if (lablist==null)
                {
                    MessageBox.Show("List Is Empty !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    FillGrid(string.Empty);
                    return;
                }
            }
            catch
            {

                MessageBox.Show("Some Issue Occur ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        #endregion

        private void cmbselectProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbselectProgram.Text.Contains("Select"))
            {
                if (cmbselectSmester.SelectedIndex > 0)
                {
                    txtsmestertitle.Text = cmbselectProgram.Text + " | " + cmbselectSmester.Text + " ";
                }
            }
        }

        private void cmbselectSmester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbselectSmester.Text.Contains("Select"))
            {
                if (cmbselectProgram.SelectedIndex > 0)
                {
                    txtsmestertitle.Text = cmbselectProgram.Text + " | " + cmbselectSmester.Text + " ";
                }
               
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtsearch.Text.Trim());

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtsmestertitle.Text.Length == 0 )
            {
                errorProvider1.SetError(this.txtsmestertitle, "Please Select Again!  title Is Empty");
                txtsmestertitle.Focus();
                txtsmestertitle.SelectAll();
                return;
            }
            if (cmbselectProgram.SelectedIndex== 0)
            {
                errorProvider1.SetError(this.cmbselectProgram, "Please Select Program !");
                cmbselectProgram.Focus();

                return;
            }
            if (cmbselectSmester.SelectedIndex == 0)
            {
                errorProvider1.SetError(this.cmbselectSmester, "Please Select Smester !");
                cmbselectSmester.Focus();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from ProgramSmesterTable where ProgramID='" + cmbselectProgram.SelectedValue + "' and SmesterID='"+cmbselectSmester.SelectedValue+"'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtsmestertitle, "ALready Exist Data !");
                    txtsmestertitle.Focus();
                    txtsmestertitle.SelectAll();
                    return;
                }
            }
            if (txtcapacity.Text.Trim().Length==0)
            {
                errorProvider1.SetError(this.txtcapacity, "Please Enter Smester Capacity !");
                txtcapacity.Focus();
                return;
            }
            string insertquery = string.Format("insert into ProgramSmesterTable (Title,ProgramID,SmesterID,isActive,Capacity) values('{0}','{1}','{2}','{3}','{4}')",
                txtsmestertitle.Text.Trim(), cmbselectProgram.SelectedValue,cmbselectSmester.SelectedValue, chksession.Checked,txtcapacity.Text.Trim());

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
            txtsmestertitle.Clear();
            cmbselectProgram.SelectedIndex = 0;
            cmbselectSmester.SelectedIndex = 0;
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtsmestertitle.Text.Length == 0)
            {
                errorProvider1.SetError(this.txtsmestertitle, "Please Select Again!  title Is Empty");
                txtsmestertitle.Focus();
                txtsmestertitle.SelectAll();
                return;
            }
            if (cmbselectProgram.SelectedIndex == 0)
            {
                errorProvider1.SetError(this.cmbselectProgram, "Please Select Program !");
                cmbselectProgram.Focus();

                return;
            }
            if (cmbselectSmester.SelectedIndex == 0)
            {
                errorProvider1.SetError(this.cmbselectSmester, "Please Select Smester !");
                cmbselectSmester.Focus();
                return;
            }
            DataTable checktitle = DatabaseLayer.Retrieve("select * from ProgramSmesterTable where ProgramID='" + cmbselectProgram.SelectedValue + "' and SmesterID='" + cmbselectSmester.SelectedValue + "' and ProgramSmesterId!='"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    errorProvider1.SetError(this.txtsmestertitle, "ALready Exist Data !");
                    txtsmestertitle.Focus();
                    txtsmestertitle.SelectAll();
                    return;
                }
            }
            string updatequery = string.Format("update ProgramSmesterTable set Title='{0}',ProgramID='{1}',SmesterID='{2}',isActive='{3}',Capacity='{4}' where ProgramSmesterId='{5}'",
                txtsmestertitle.Text.Trim(), cmbselectProgram.SelectedValue, cmbselectSmester.SelectedValue, chksession.Checked, txtcapacity.Text.Trim(),dataGridView1.CurrentRow.Cells[0].Value.ToString());

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
                            txtsmestertitle.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                            txtcapacity.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                            chksession.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[3].Value);
                            cmbselectProgram.SelectedValue= dataGridView1.CurrentRow.Cells[4].Value.ToString(); // ProgramID
                            cmbselectSmester.SelectedValue = dataGridView1.CurrentRow.Cells[5].Value.ToString(); // SmesterID
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

        private void btnunactive_Click(object sender, EventArgs e)
        {
            FillGridUnActive(string.Empty);
        }
    }
}
