namespace AutoTimeTable.Forms
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.newLecturerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignSubjectsToLectureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.roomsLabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.newSemestersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSemesterSectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignSemesterToProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignSubjectToSemesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.addDaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayTimeSlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.printAllTimeTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printAllTeacherTimeTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printAllDaysWiseTimeTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lbl = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton4,
            this.toolStripButton5,
            this.toolStripDropDownButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 62);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslblDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // tsslblDateTime
            // 
            this.tsslblDateTime.Name = "tsslblDateTime";
            this.tsslblDateTime.Size = new System.Drawing.Size(746, 17);
            this.tsslblDateTime.Spring = true;
            this.tsslblDateTime.Text = "toolStripStatusLabel2";
            this.tsslblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::AutoTimeTable.Properties.Resources.programicon;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(57, 59);
            this.toolStripButton1.Text = "Program";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::AutoTimeTable.Properties.Resources.sessionicon;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(50, 59);
            this.toolStripButton2.Text = "Session";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::AutoTimeTable.Properties.Resources.subjecticon;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(53, 59);
            this.toolStripButton3.Text = "Courses";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = global::AutoTimeTable.Properties.Resources.timetableicon;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(67, 59);
            this.toolStripButton5.Text = "Time Table";
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLecturerToolStripMenuItem,
            this.assignSubjectsToLectureToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::AutoTimeTable.Properties.Resources.teachericon;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(59, 59);
            this.toolStripDropDownButton1.Text = "Lecture";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // newLecturerToolStripMenuItem
            // 
            this.newLecturerToolStripMenuItem.Name = "newLecturerToolStripMenuItem";
            this.newLecturerToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.newLecturerToolStripMenuItem.Text = "New Lecturer";
            this.newLecturerToolStripMenuItem.Click += new System.EventHandler(this.newLecturerToolStripMenuItem_Click);
            // 
            // assignSubjectsToLectureToolStripMenuItem
            // 
            this.assignSubjectsToLectureToolStripMenuItem.Name = "assignSubjectsToLectureToolStripMenuItem";
            this.assignSubjectsToLectureToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.assignSubjectsToLectureToolStripMenuItem.Text = "Assign Subjects to Lecture";
            this.assignSubjectsToLectureToolStripMenuItem.Click += new System.EventHandler(this.assignSubjectsToLectureToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomsLabsToolStripMenuItem,
            this.addLabsToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::AutoTimeTable.Properties.Resources.roomsicon;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(98, 59);
            this.toolStripDropDownButton2.Text = "Room\'s / Lab\'s";
            this.toolStripDropDownButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // roomsLabsToolStripMenuItem
            // 
            this.roomsLabsToolStripMenuItem.Name = "roomsLabsToolStripMenuItem";
            this.roomsLabsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.roomsLabsToolStripMenuItem.Text = "Add Room";
            this.roomsLabsToolStripMenuItem.Click += new System.EventHandler(this.roomsLabsToolStripMenuItem_Click);
            // 
            // addLabsToolStripMenuItem
            // 
            this.addLabsToolStripMenuItem.Name = "addLabsToolStripMenuItem";
            this.addLabsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addLabsToolStripMenuItem.Text = "Add Labs";
            this.addLabsToolStripMenuItem.Click += new System.EventHandler(this.addLabsToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSemestersToolStripMenuItem,
            this.addSemesterSectionsToolStripMenuItem,
            this.assignSemesterToProgramToolStripMenuItem,
            this.assignSubjectToSemesterToolStripMenuItem});
            this.toolStripDropDownButton3.Image = global::AutoTimeTable.Properties.Resources.semestericon;
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(76, 59);
            this.toolStripDropDownButton3.Text = "Semester\'s";
            this.toolStripDropDownButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // newSemestersToolStripMenuItem
            // 
            this.newSemestersToolStripMenuItem.Name = "newSemestersToolStripMenuItem";
            this.newSemestersToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.newSemestersToolStripMenuItem.Text = "New Semesters";
            this.newSemestersToolStripMenuItem.Click += new System.EventHandler(this.newSemestersToolStripMenuItem_Click);
            // 
            // addSemesterSectionsToolStripMenuItem
            // 
            this.addSemesterSectionsToolStripMenuItem.Name = "addSemesterSectionsToolStripMenuItem";
            this.addSemesterSectionsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.addSemesterSectionsToolStripMenuItem.Text = "Add Semester Sections";
            this.addSemesterSectionsToolStripMenuItem.Click += new System.EventHandler(this.addSemesterSectionsToolStripMenuItem_Click);
            // 
            // assignSemesterToProgramToolStripMenuItem
            // 
            this.assignSemesterToProgramToolStripMenuItem.Name = "assignSemesterToProgramToolStripMenuItem";
            this.assignSemesterToProgramToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.assignSemesterToProgramToolStripMenuItem.Text = "Assign Semester to Program";
            this.assignSemesterToProgramToolStripMenuItem.Click += new System.EventHandler(this.assignSemesterToProgramToolStripMenuItem_Click);
            // 
            // assignSubjectToSemesterToolStripMenuItem
            // 
            this.assignSubjectToSemesterToolStripMenuItem.Name = "assignSubjectToSemesterToolStripMenuItem";
            this.assignSubjectToSemesterToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.assignSubjectToSemesterToolStripMenuItem.Text = "Assign Subject to Semester";
            this.assignSubjectToSemesterToolStripMenuItem.Click += new System.EventHandler(this.assignSubjectToSemesterToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDaysToolStripMenuItem,
            this.dayTimeSlotToolStripMenuItem});
            this.toolStripDropDownButton4.Image = global::AutoTimeTable.Properties.Resources.daysicon;
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(53, 59);
            this.toolStripDropDownButton4.Text = "Day\'s";
            this.toolStripDropDownButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // addDaysToolStripMenuItem
            // 
            this.addDaysToolStripMenuItem.Name = "addDaysToolStripMenuItem";
            this.addDaysToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addDaysToolStripMenuItem.Text = "Add Day\'s";
            this.addDaysToolStripMenuItem.Click += new System.EventHandler(this.addDaysToolStripMenuItem_Click);
            // 
            // dayTimeSlotToolStripMenuItem
            // 
            this.dayTimeSlotToolStripMenuItem.Name = "dayTimeSlotToolStripMenuItem";
            this.dayTimeSlotToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dayTimeSlotToolStripMenuItem.Text = "Day Time Slot";
            this.dayTimeSlotToolStripMenuItem.Click += new System.EventHandler(this.dayTimeSlotToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton5
            // 
            this.toolStripDropDownButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printAllTimeTablesToolStripMenuItem,
            this.printAllTeacherTimeTablesToolStripMenuItem,
            this.printAllDaysWiseTimeTablesToolStripMenuItem});
            this.toolStripDropDownButton5.Image = global::AutoTimeTable.Properties.Resources.printsicon;
            this.toolStripDropDownButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton5.Name = "toolStripDropDownButton5";
            this.toolStripDropDownButton5.Size = new System.Drawing.Size(53, 59);
            this.toolStripDropDownButton5.Text = "Print\'s";
            this.toolStripDropDownButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // printAllTimeTablesToolStripMenuItem
            // 
            this.printAllTimeTablesToolStripMenuItem.Name = "printAllTimeTablesToolStripMenuItem";
            this.printAllTimeTablesToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.printAllTimeTablesToolStripMenuItem.Text = "Print All Time Tables";
            this.printAllTimeTablesToolStripMenuItem.Click += new System.EventHandler(this.printAllTimeTablesToolStripMenuItem_Click);
            // 
            // printAllTeacherTimeTablesToolStripMenuItem
            // 
            this.printAllTeacherTimeTablesToolStripMenuItem.Name = "printAllTeacherTimeTablesToolStripMenuItem";
            this.printAllTeacherTimeTablesToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.printAllTeacherTimeTablesToolStripMenuItem.Text = "Print All Teacher Time Tables";
            this.printAllTeacherTimeTablesToolStripMenuItem.Click += new System.EventHandler(this.printAllTeacherTimeTablesToolStripMenuItem_Click);
            // 
            // printAllDaysWiseTimeTablesToolStripMenuItem
            // 
            this.printAllDaysWiseTimeTablesToolStripMenuItem.Name = "printAllDaysWiseTimeTablesToolStripMenuItem";
            this.printAllDaysWiseTimeTablesToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.printAllDaysWiseTimeTablesToolStripMenuItem.Text = "Print All Days Wise Time Tables";
            this.printAllDaysWiseTimeTablesToolStripMenuItem.Click += new System.EventHandler(this.printAllDaysWiseTimeTablesToolStripMenuItem_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackgroundImage = global::AutoTimeTable.Properties.Resources.timetablebackgournd;
            this.panelHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHeader.Controls.Add(this.lbl);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeader.Location = new System.Drawing.Point(0, 62);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 366);
            this.panelHeader.TabIndex = 2;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.BackColor = System.Drawing.Color.Transparent;
            this.lbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(12, 103);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(407, 156);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "TimeTable\r\nGenerator\r\n";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "HomeForm";
            this.Text = " HomeForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblDateTime;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem newLecturerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignSubjectsToLectureToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem roomsLabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem newSemestersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSemesterSectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignSemesterToProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignSubjectToSemesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripMenuItem addDaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayTimeSlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton5;
        private System.Windows.Forms.ToolStripMenuItem printAllTimeTablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printAllTeacherTimeTablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printAllDaysWiseTimeTablesToolStripMenuItem;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lbl;
    }
}