using AutoTimeTable.Forms.ConfrigurationForm;
using AutoTimeTable.Forms.LecturerSubjectForms;
using AutoTimeTable.Forms.ProgramSmesterForms;
using AutoTimeTable.Forms.TimeSlotForms;
using AutoTimeTable.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTimeTable.Forms
{
    public partial class HomeForm : Form
    {
        FormCourses CoursesForm;
        FormDays DaysForm;
        FormLabs LabsForm;
        FormLecturer LecturesForm;
        ProgramForm ProgramForm;
        FormRooms RoomForm;
        SmesterForm SemestersForm;
        SessionForm SessionForm;
        LecturerSubjectForm LecturesSubjectForm;
        FormProgramSmester ProgramSemestersForm;
        FormProgramSmesterSubject ProgramSemesterSubjectForm;
        FormDayTimeSLot DayTimeSlotsForm;
        FormSemesterSections SemesterSectionsForm;
        FormGenerateTimeTable AutoGenerateTimeTableForm;
        PrintAllSmesterTimeTable PrintAllTimeTablesForm;
        FormPrintTeacherWiseTimeTable PrintAllTeacherTimeTablesForm;
        FormPrintDayWiseTimeTable PrintAllDaysTimeTablesForm;
        public HomeForm()
        {
            InitializeComponent();
            tsslblDateTime.Text = DateTime.Now.ToString("dd MMM yyyy");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ProgramForm == null)
            {
                ProgramForm = new ProgramForm();
            }
            ProgramForm.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (SessionForm == null)
            {
                SessionForm = new SessionForm();
            }
            SessionForm.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (CoursesForm == null)
            {
                CoursesForm = new FormCourses();
            }
            CoursesForm.ShowDialog();

        }

        private void newLecturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LecturesForm == null)
            {
                LecturesForm = new FormLecturer();
            }
            LecturesForm.ShowDialog();
        }

        private void assignSubjectsToLectureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LecturesSubjectForm == null)
            {
                LecturesSubjectForm = new LecturerSubjectForm();
            }
            LecturesSubjectForm.ShowDialog();
        }

        private void roomsLabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RoomForm == null)
            {
                RoomForm = new FormRooms();
            }
            RoomForm.ShowDialog();
        }

        private void addLabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LabsForm == null)
            {
                LabsForm = new FormLabs();
            }
            LabsForm.ShowDialog();
        }

        private void newSemestersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SemestersForm == null)
            {
                SemestersForm = new SmesterForm();
            }
            SemestersForm.ShowDialog();
        }

        private void addSemesterSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SemesterSectionsForm == null)
            {
                SemesterSectionsForm = new FormSemesterSections();
            }
            SemesterSectionsForm.ShowDialog();
        }

        private void assignSemesterToProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramSemestersForm == null)
            {
                ProgramSemestersForm = new FormProgramSmester();
            }
            ProgramSemestersForm.ShowDialog();
        }

        private void assignSubjectToSemesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramSemesterSubjectForm == null)
            {
                ProgramSemesterSubjectForm = new FormProgramSmesterSubject();
            }
            ProgramSemesterSubjectForm.ShowDialog();
        }

        private void addDaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DaysForm == null)
            {
                DaysForm = new FormDays();
            }
            DaysForm.ShowDialog();
        }

        private void dayTimeSlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DayTimeSlotsForm == null)
            {
                DayTimeSlotsForm = new FormDayTimeSLot();
            }
            DayTimeSlotsForm.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (AutoGenerateTimeTableForm == null)
            {
                AutoGenerateTimeTableForm = new FormGenerateTimeTable();
            }
            AutoGenerateTimeTableForm.ShowDialog();
        }

        private void printAllTimeTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PrintAllTimeTablesForm == null)
            {
                PrintAllTimeTablesForm = new PrintAllSmesterTimeTable();
            }
            PrintAllTimeTablesForm.TopLevel = false;
            panelHeader.Controls.Add(PrintAllTimeTablesForm);
            PrintAllTimeTablesForm.Dock = DockStyle.Fill;
            PrintAllTimeTablesForm.FormBorderStyle = FormBorderStyle.None;
            PrintAllTimeTablesForm.BringToFront();
            PrintAllTimeTablesForm.Show();
        }

        private void printAllTeacherTimeTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PrintAllTeacherTimeTablesForm == null)
            {
                PrintAllTeacherTimeTablesForm = new FormPrintTeacherWiseTimeTable();
            }
            PrintAllTeacherTimeTablesForm.TopLevel = false;
            panelHeader.Controls.Add(PrintAllTeacherTimeTablesForm);
            PrintAllTeacherTimeTablesForm.Dock = DockStyle.Fill;
            PrintAllTeacherTimeTablesForm.FormBorderStyle = FormBorderStyle.None;
            PrintAllTeacherTimeTablesForm.BringToFront();
            PrintAllTeacherTimeTablesForm.Show();
        }

        private void printAllDaysWiseTimeTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PrintAllDaysTimeTablesForm == null)
            {
                PrintAllDaysTimeTablesForm = new FormPrintDayWiseTimeTable();
            }
            PrintAllDaysTimeTablesForm.TopLevel = false;
            panelHeader.Controls.Add(PrintAllDaysTimeTablesForm);
            PrintAllDaysTimeTablesForm.Dock = DockStyle.Fill;
            PrintAllDaysTimeTablesForm.FormBorderStyle = FormBorderStyle.None;
            PrintAllDaysTimeTablesForm.BringToFront();
            PrintAllDaysTimeTablesForm.Show();
        }
    }
}
