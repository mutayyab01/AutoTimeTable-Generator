namespace AutoTimeTable.Forms.TimeSlotForms
{
    partial class FormDayTimeSLot
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDayTimeSLot));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbnumberoftimeslot = new System.Windows.Forms.ComboBox();
            this.cmbselectdays = new System.Windows.Forms.ComboBox();
            this.dtptotome = new System.Windows.Forms.DateTimePicker();
            this.dtpfromtime = new System.Windows.Forms.DateTimePicker();
            this.btnclear = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chksession = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmsOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmseditstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmsOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btncancel);
            this.groupBox1.Controls.Add(this.btnsave);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbnumberoftimeslot);
            this.groupBox1.Controls.Add(this.cmbselectdays);
            this.groupBox1.Controls.Add(this.dtptotome);
            this.groupBox1.Controls.Add(this.dtpfromtime);
            this.groupBox1.Controls.Add(this.btnclear);
            this.groupBox1.Controls.Add(this.btnupdate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chksession);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(-9, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 402);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Slot Per Day";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 69);
            this.label4.TabIndex = 9;
            this.label4.Text = "Enter Number \r\nof Time Slot Per \r\nDay\r\n";
            // 
            // cmbnumberoftimeslot
            // 
            this.cmbnumberoftimeslot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbnumberoftimeslot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbnumberoftimeslot.FormattingEnabled = true;
            this.cmbnumberoftimeslot.Location = new System.Drawing.Point(163, 231);
            this.cmbnumberoftimeslot.Name = "cmbnumberoftimeslot";
            this.cmbnumberoftimeslot.Size = new System.Drawing.Size(170, 31);
            this.cmbnumberoftimeslot.TabIndex = 8;
            // 
            // cmbselectdays
            // 
            this.cmbselectdays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbselectdays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbselectdays.FormattingEnabled = true;
            this.cmbselectdays.Location = new System.Drawing.Point(131, 56);
            this.cmbselectdays.Name = "cmbselectdays";
            this.cmbselectdays.Size = new System.Drawing.Size(170, 31);
            this.cmbselectdays.TabIndex = 8;
            // 
            // dtptotome
            // 
            this.dtptotome.CustomFormat = "  hh:mm tt";
            this.dtptotome.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptotome.Location = new System.Drawing.Point(131, 162);
            this.dtptotome.Name = "dtptotome";
            this.dtptotome.ShowUpDown = true;
            this.dtptotome.Size = new System.Drawing.Size(170, 30);
            this.dtptotome.TabIndex = 5;
            // 
            // dtpfromtime
            // 
            this.dtpfromtime.CustomFormat = " hh:mm tt";
            this.dtpfromtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfromtime.Location = new System.Drawing.Point(131, 116);
            this.dtpfromtime.Name = "dtpfromtime";
            this.dtpfromtime.ShowUpDown = true;
            this.dtpfromtime.Size = new System.Drawing.Size(170, 30);
            this.dtpfromtime.TabIndex = 5;
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.Olive;
            this.btnclear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnclear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkKhaki;
            this.btnclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclear.ForeColor = System.Drawing.Color.White;
            this.btnclear.Location = new System.Drawing.Point(102, 318);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(94, 40);
            this.btnclear.TabIndex = 4;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click_1);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.Orange;
            this.btncancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btncancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.ForeColor = System.Drawing.Color.Black;
            this.btncancel.Location = new System.Drawing.Point(102, 318);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(94, 40);
            this.btncancel.TabIndex = 2;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Visible = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.Indigo;
            this.btnupdate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnupdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.ForeColor = System.Drawing.Color.White;
            this.btnupdate.Location = new System.Drawing.Point(220, 318);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(94, 40);
            this.btnupdate.TabIndex = 2;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Visible = false;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.DarkRed;
            this.btnsave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(220, 318);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(94, 40);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "End Time";
            // 
            // chksession
            // 
            this.chksession.AutoSize = true;
            this.chksession.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chksession.Checked = true;
            this.chksession.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chksession.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chksession.Location = new System.Drawing.Point(37, 289);
            this.chksession.Name = "chksession";
            this.chksession.Size = new System.Drawing.Size(106, 23);
            this.chksession.TabIndex = 2;
            this.chksession.Text = "Day Status";
            this.chksession.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Select Day";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Time";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.cmsOptions;
            this.dataGridView1.Location = new System.Drawing.Point(336, 138);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(420, 410);
            this.dataGridView1.TabIndex = 13;
            // 
            // cmsOptions
            // 
            this.cmsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmseditstrip});
            this.cmsOptions.Name = "cmsOptions";
            this.cmsOptions.Size = new System.Drawing.Size(133, 26);
            // 
            // cmseditstrip
            // 
            this.cmseditstrip.Name = "cmseditstrip";
            this.cmseditstrip.Size = new System.Drawing.Size(132, 22);
            this.cmseditstrip.Text = "Break Time";
            this.cmseditstrip.Click += new System.EventHandler(this.cmseditstrip_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.Location = new System.Drawing.Point(512, 95);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(203, 26);
            this.txtsearch.TabIndex = 11;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(267, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(430, 82);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // FormDayTimeSLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(768, 560);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDayTimeSLot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Day Time Slot";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmsOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.CheckBox chksession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip cmsOptions;
        private System.Windows.Forms.ToolStripMenuItem cmseditstrip;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbselectdays;
        private System.Windows.Forms.DateTimePicker dtptotome;
        private System.Windows.Forms.DateTimePicker dtpfromtime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbnumberoftimeslot;
    }
}