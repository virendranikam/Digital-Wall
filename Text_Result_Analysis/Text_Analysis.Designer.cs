namespace Text_Result_Analysis
{
    partial class Text_Analysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Text_Analysis));
            this.lblStatus_Text_Analysis = new System.Windows.Forms.Label();
            this.linkText_Analysis = new System.Windows.Forms.LinkLabel();
            this.dgvText_Analysis = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFile2_Content = new System.Windows.Forms.TextBox();
            this.txtFile1_Content = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFile2_Path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFile1_Path = new System.Windows.Forms.TextBox();
            this.link_Browse_File = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvText_Analysis)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus_Text_Analysis
            // 
            this.lblStatus_Text_Analysis.AutoSize = true;
            this.lblStatus_Text_Analysis.Location = new System.Drawing.Point(939, 40);
            this.lblStatus_Text_Analysis.Name = "lblStatus_Text_Analysis";
            this.lblStatus_Text_Analysis.Size = new System.Drawing.Size(48, 19);
            this.lblStatus_Text_Analysis.TabIndex = 31;
            this.lblStatus_Text_Analysis.Text = "Status";
            // 
            // linkText_Analysis
            // 
            this.linkText_Analysis.AutoSize = true;
            this.linkText_Analysis.Location = new System.Drawing.Point(826, 40);
            this.linkText_Analysis.Name = "linkText_Analysis";
            this.linkText_Analysis.Size = new System.Drawing.Size(96, 19);
            this.linkText_Analysis.TabIndex = 30;
            this.linkText_Analysis.TabStop = true;
            this.linkText_Analysis.Text = "Start Analysis";
            this.linkText_Analysis.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkText_Analysis_LinkClicked_1);
            // 
            // dgvText_Analysis
            // 
            this.dgvText_Analysis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvText_Analysis.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvText_Analysis.BackgroundColor = System.Drawing.Color.White;
            this.dgvText_Analysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvText_Analysis.Location = new System.Drawing.Point(11, 444);
            this.dgvText_Analysis.Name = "dgvText_Analysis";
            this.dgvText_Analysis.Size = new System.Drawing.Size(1348, 294);
            this.dgvText_Analysis.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(660, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 28;
            this.label4.Text = "File2 Content";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 19);
            this.label3.TabIndex = 27;
            this.label3.Text = "File1 Content";
            // 
            // txtFile2_Content
            // 
            this.txtFile2_Content.BackColor = System.Drawing.Color.White;
            this.txtFile2_Content.Location = new System.Drawing.Point(652, 166);
            this.txtFile2_Content.Multiline = true;
            this.txtFile2_Content.Name = "txtFile2_Content";
            this.txtFile2_Content.ReadOnly = true;
            this.txtFile2_Content.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFile2_Content.Size = new System.Drawing.Size(707, 258);
            this.txtFile2_Content.TabIndex = 26;
            // 
            // txtFile1_Content
            // 
            this.txtFile1_Content.BackColor = System.Drawing.Color.White;
            this.txtFile1_Content.Location = new System.Drawing.Point(11, 166);
            this.txtFile1_Content.Multiline = true;
            this.txtFile1_Content.Name = "txtFile1_Content";
            this.txtFile1_Content.ReadOnly = true;
            this.txtFile1_Content.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFile1_Content.Size = new System.Drawing.Size(635, 258);
            this.txtFile1_Content.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 24;
            this.label2.Text = "File2 Path";
            // 
            // txtFile2_Path
            // 
            this.txtFile2_Path.BackColor = System.Drawing.Color.White;
            this.txtFile2_Path.Location = new System.Drawing.Point(11, 104);
            this.txtFile2_Path.Name = "txtFile2_Path";
            this.txtFile2_Path.ReadOnly = true;
            this.txtFile2_Path.Size = new System.Drawing.Size(707, 27);
            this.txtFile2_Path.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "File1 Path";
            // 
            // txtFile1_Path
            // 
            this.txtFile1_Path.BackColor = System.Drawing.Color.White;
            this.txtFile1_Path.Location = new System.Drawing.Point(11, 40);
            this.txtFile1_Path.Name = "txtFile1_Path";
            this.txtFile1_Path.ReadOnly = true;
            this.txtFile1_Path.Size = new System.Drawing.Size(707, 27);
            this.txtFile1_Path.TabIndex = 21;
            // 
            // link_Browse_File
            // 
            this.link_Browse_File.AutoSize = true;
            this.link_Browse_File.Location = new System.Drawing.Point(736, 40);
            this.link_Browse_File.Name = "link_Browse_File";
            this.link_Browse_File.Size = new System.Drawing.Size(84, 19);
            this.link_Browse_File.TabIndex = 20;
            this.link_Browse_File.TabStop = true;
            this.link_Browse_File.Text = "Browse File";
            this.link_Browse_File.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Browse_File_LinkClicked);
            // 
            // Text_Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.lblStatus_Text_Analysis);
            this.Controls.Add(this.linkText_Analysis);
            this.Controls.Add(this.dgvText_Analysis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFile2_Content);
            this.Controls.Add(this.txtFile1_Content);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFile2_Path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFile1_Path);
            this.Controls.Add(this.link_Browse_File);
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1386, 788);
            this.MinimumSize = new System.Drawing.Size(1364, 726);
            this.Name = "Text_Analysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text_Result_Analysis";
            this.Load += new System.EventHandler(this.Text_Analysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvText_Analysis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus_Text_Analysis;
        private System.Windows.Forms.LinkLabel linkText_Analysis;
        private System.Windows.Forms.DataGridView dgvText_Analysis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFile2_Content;
        private System.Windows.Forms.TextBox txtFile1_Content;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFile2_Path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile1_Path;
        private System.Windows.Forms.LinkLabel link_Browse_File;
    }
}

