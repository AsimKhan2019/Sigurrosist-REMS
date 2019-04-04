namespace prgRemaxFinalProject.GUI
{
    partial class frmSearchHouse
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefHouse = new System.Windows.Forms.Button();
            this.gridAll = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRefHouse = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNumRoom = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBudget = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBudget = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtBudgetCombine = new System.Windows.Forms.TextBox();
            this.btnCombine = new System.Windows.Forms.Button();
            this.cboNumRoomCombile = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboNumRoom = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 497);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 64);
            this.panel1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Snow;
            this.label5.Location = new System.Drawing.Point(365, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 36);
            this.label5.TabIndex = 11;
            this.label5.Text = "SEARCH HOUSES";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(990, 94);
            this.panel2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(230, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(563, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Administration’s Application For Remax";
            // 
            // btnRefHouse
            // 
            this.btnRefHouse.FlatAppearance.BorderSize = 0;
            this.btnRefHouse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnRefHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefHouse.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefHouse.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnRefHouse.Location = new System.Drawing.Point(10, 103);
            this.btnRefHouse.Name = "btnRefHouse";
            this.btnRefHouse.Size = new System.Drawing.Size(142, 35);
            this.btnRefHouse.TabIndex = 1;
            this.btnRefHouse.Text = "Search";
            this.btnRefHouse.UseVisualStyleBackColor = true;
            this.btnRefHouse.Click += new System.EventHandler(this.btnRefHouse_Click);
            // 
            // gridAll
            // 
            this.gridAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAll.Location = new System.Drawing.Point(19, 260);
            this.gridAll.Name = "gridAll";
            this.gridAll.Size = new System.Drawing.Size(953, 222);
            this.gridAll.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.gridAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(990, 561);
            this.panel3.TabIndex = 13;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDelete.Location = new System.Drawing.Point(842, 28);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 35);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRefHouse);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnRefHouse);
            this.groupBox1.Location = new System.Drawing.Point(19, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 151);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search by House ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "RefHouse : ";
            // 
            // txtRefHouse
            // 
            this.txtRefHouse.Location = new System.Drawing.Point(10, 57);
            this.txtRefHouse.Name = "txtRefHouse";
            this.txtRefHouse.Size = new System.Drawing.Size(142, 26);
            this.txtRefHouse.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboNumRoom);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnNumRoom);
            this.groupBox2.Location = new System.Drawing.Point(191, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 74);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search by Number of Rooms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of Rooms : ";
            // 
            // btnNumRoom
            // 
            this.btnNumRoom.FlatAppearance.BorderSize = 0;
            this.btnNumRoom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnNumRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNumRoom.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNumRoom.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNumRoom.Location = new System.Drawing.Point(265, 25);
            this.btnNumRoom.Name = "btnNumRoom";
            this.btnNumRoom.Size = new System.Drawing.Size(134, 35);
            this.btnNumRoom.TabIndex = 1;
            this.btnNumRoom.Text = "Search";
            this.btnNumRoom.UseVisualStyleBackColor = true;
            this.btnNumRoom.Click += new System.EventHandler(this.btnNumRoom_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBudget);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnBudget);
            this.groupBox3.Location = new System.Drawing.Point(191, 182);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 71);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search by Budget";
            // 
            // txtBudget
            // 
            this.txtBudget.Location = new System.Drawing.Point(134, 31);
            this.txtBudget.Name = "txtBudget";
            this.txtBudget.Size = new System.Drawing.Size(111, 26);
            this.txtBudget.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(6, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Budget (CAD) : ";
            // 
            // btnBudget
            // 
            this.btnBudget.FlatAppearance.BorderSize = 0;
            this.btnBudget.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBudget.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBudget.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBudget.Location = new System.Drawing.Point(265, 25);
            this.btnBudget.Name = "btnBudget";
            this.btnBudget.Size = new System.Drawing.Size(134, 35);
            this.btnBudget.TabIndex = 1;
            this.btnBudget.Text = "Search";
            this.btnBudget.UseVisualStyleBackColor = true;
            this.btnBudget.Click += new System.EventHandler(this.btnBudget_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cboNumRoomCombile);
            this.groupBox4.Controls.Add(this.txtBudgetCombine);
            this.groupBox4.Controls.Add(this.btnCombine);
            this.groupBox4.Location = new System.Drawing.Point(602, 103);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(370, 151);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search by Number of Rooms and Budget";
            // 
            // txtBudgetCombine
            // 
            this.txtBudgetCombine.Location = new System.Drawing.Point(149, 103);
            this.txtBudgetCombine.Name = "txtBudgetCombine";
            this.txtBudgetCombine.Size = new System.Drawing.Size(86, 26);
            this.txtBudgetCombine.TabIndex = 15;
            // 
            // btnCombine
            // 
            this.btnCombine.FlatAppearance.BorderSize = 0;
            this.btnCombine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCombine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCombine.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCombine.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCombine.Location = new System.Drawing.Point(253, 67);
            this.btnCombine.Name = "btnCombine";
            this.btnCombine.Size = new System.Drawing.Size(96, 35);
            this.btnCombine.TabIndex = 13;
            this.btnCombine.Text = "Search";
            this.btnCombine.UseVisualStyleBackColor = true;
            this.btnCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // cboNumRoomCombile
            // 
            this.cboNumRoomCombile.FormattingEnabled = true;
            this.cboNumRoomCombile.Location = new System.Drawing.Point(173, 31);
            this.cboNumRoomCombile.Name = "cboNumRoomCombile";
            this.cboNumRoomCombile.Size = new System.Drawing.Size(62, 28);
            this.cboNumRoomCombile.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(17, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Number of Rooms : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(20, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Budget (CAD) : ";
            // 
            // cboNumRoom
            // 
            this.cboNumRoom.FormattingEnabled = true;
            this.cboNumRoom.Location = new System.Drawing.Point(162, 31);
            this.cboNumRoom.Name = "cboNumRoom";
            this.cboNumRoom.Size = new System.Drawing.Size(83, 28);
            this.cboNumRoom.TabIndex = 16;
            // 
            // frmSearchHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSearchHouse";
            this.Text = "Administration’s Application For Remax";
            this.Load += new System.EventHandler(this.frmSearchHouse_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAll)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefHouse;
        private System.Windows.Forms.DataGridView gridAll;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboNumRoomCombile;
        private System.Windows.Forms.TextBox txtBudgetCombine;
        private System.Windows.Forms.Button btnCombine;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBudget;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBudget;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNumRoom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRefHouse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboNumRoom;
    }
}