using AutoTimeTable.Forms.Models;
using AutoTimeTable.SourceCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AutoTimeTable.Forms.TimeSlotForms
{
    public partial class FormDayTimeSLot : Form
    {
        public FormDayTimeSLot()
        {
            InitializeComponent();
            dtpfromtime.Value = new DateTime(2020, 01, 01, 08, 00, 00);
            dtptotome.Value = new DateTime(2020, 01, 01, 17, 00, 00);
            ComboHelper.AllDaysComboBox(cmbselectdays);
            ComboHelper.TimeSlotNumberComboBox(cmbnumberoftimeslot);
            FillGrid(string.Empty);
        }
        public void FillGrid(string searchtext)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchtext.Trim()))
                {
                    query = "select DayTimeSlotId,ROW_NUMBER() OVER (Order by DayTimeSlotId) AS [S No],DayID,[Name],SlotTitle[Slot Title],StartTime[Start Time],EndTime[End Time],isActive[Status] from v_allTimeSlots where isActive='1'";
                }
                else
                {

                    query = "select DayTimeSlotId,ROW_NUMBER() OVER (Order by DayTimeSlotId) AS [S No],DayID,[Name],SlotTitle[Slot Title],StartTime[Start Time],EndTime[End Time],isActive[Status] from v_allTimeSlots where isActive='1' and ([Name]+' '+SlotTitle) like'%" + searchtext.Trim() + "%'";
                }
                DataTable sessionlist = DatabaseLayer.Retrieve(query);
                dataGridView1.DataSource = sessionlist;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns[0].Visible = false; // DayTimeSlotId
                    dataGridView1.Columns[1].Width = 80; // S NO
                    dataGridView1.Columns[2].Visible = false; // DayID
                    dataGridView1.Columns[3].Width = 100; // Name
                    dataGridView1.Columns[4].Width = 150; // SlotTitle
                    dataGridView1.Columns[5].Width = 100; // StartTime
                    dataGridView1.Columns[6].Width = 100; // EndTime
                    dataGridView1.Columns[7].Width = 80; // isActive

                }
            }
            catch
            {

                MessageBox.Show("Some Issue Occur ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public void clearform()
        {
            cmbselectdays.SelectedIndex = 0;
            cmbnumberoftimeslot.SelectedIndex = 0;
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
                if (cmbselectdays.SelectedIndex == 0)
                {
                    errorProvider1.SetError(this.cmbselectdays, "Please Select Day !");
                    cmbselectdays.Focus();
                    return;
                }
                if (cmbnumberoftimeslot.SelectedIndex == 0)
                {
                    errorProvider1.SetError(this.cmbnumberoftimeslot, "Please Enter Number Of Time Slot !");
                    cmbnumberoftimeslot.Focus();
                    return;
                }

                string udatequery = "update DayTimeSlotTable set isActive='0' where DayID = '" + cmbselectdays.SelectedValue + "'";
                bool updateresult = DatabaseLayer.Update(udatequery);
                if (updateresult == true)
                {

                    List<TimeSlotMV> timeslot = new List<TimeSlotMV>();
                    TimeSpan time = dtptotome.Value - dtpfromtime.Value;
                    int totalminutes = (int)time.TotalMinutes;
                    int numberofslots = Convert.ToInt32(cmbnumberoftimeslot.SelectedValue);
                    int slot = totalminutes / numberofslots;

                    int i = 0;
                    do
                    {
                        var timeslots = new TimeSlotMV();
                        var FromTime = (dtpfromtime.Value).AddMinutes(slot * i);
                        i++;
                        var ToTime = (dtpfromtime.Value).AddMinutes(slot * i);
                        string title = FromTime.ToString("hh:mm tt") + "-" + ToTime.ToString("hh:mm tt");
                        timeslots.FromTime = FromTime;
                        timeslots.ToTime = ToTime;
                        timeslots.SlotTitle = title;
                        timeslot.Add(timeslots);
                    } while (i < numberofslots);
                    bool insetstatus = true;
                    foreach (TimeSlotMV slottime in timeslot)
                    {
                        string insertquery = String.Format("insert into DayTimeSlotTable (DayID,SlotTitle,StartTime,EndTime,isActive) values ('{0}','{1}','{2}','{3}','{4}')",
                            cmbselectdays.SelectedValue, slottime.SlotTitle, slottime.FromTime, slottime.ToTime, chksession.Checked);
                        bool result = DatabaseLayer.Insert(insertquery);
                        if (result = false)
                        {
                            insetstatus = false;
                        }

                    }
                    if (insetstatus = true)
                    {
                        MessageBox.Show("Slot Created Succesfully", "Slot Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisbleComponent();
                    }
                    else
                    {
                        MessageBox.Show("Please Provide Correct details And Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Please Provide Correct details And Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch
            {

                MessageBox.Show("Check Sql Server Agent Connectivity ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmseditstrip_Click(object sender, EventArgs e)
        {
            if (dataGridView1!=null)
            {
                if (dataGridView1.Rows.Count>0)
                {
                    if (dataGridView1.SelectedRows.Count==1)
                    {
                        string slotid =dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        string updatequery = "update DayTimeSlotTable set isActive='0' where DayTimeSlotId='"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'";
                        bool result = DatabaseLayer.Update(updatequery);
                        if (result==true)
                        {
                            MessageBox.Show("Break Time Is Marked ANd Excluded From TimeTable! ","Break Time",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            DisbleComponent();
                        }

                    }
                }
            }
        }
    }
}
