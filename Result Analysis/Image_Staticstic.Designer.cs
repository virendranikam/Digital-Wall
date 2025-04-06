namespace Result_Analysis
{
    partial class Image_Staticstic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Image_Staticstic));
            this.lblStatus_Result_Analysis = new System.Windows.Forms.Label();
            this.picImage_Resultant = new System.Windows.Forms.PictureBox();
            this.picImage_Original = new System.Windows.Forms.PictureBox();
            this.dgvImage_Statistics = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.picImage_Resultant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage_Original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImage_Statistics)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus_Result_Analysis
            // 
            this.lblStatus_Result_Analysis.AutoSize = true;
            this.lblStatus_Result_Analysis.Location = new System.Drawing.Point(732, 12);
            this.lblStatus_Result_Analysis.Name = "lblStatus_Result_Analysis";
            this.lblStatus_Result_Analysis.Size = new System.Drawing.Size(48, 19);
            this.lblStatus_Result_Analysis.TabIndex = 11;
            this.lblStatus_Result_Analysis.Text = "Status";
            // 
            // picImage_Resultant
            // 
            this.picImage_Resultant.Location = new System.Drawing.Point(266, 12);
            this.picImage_Resultant.Name = "picImage_Resultant";
            this.picImage_Resultant.Size = new System.Drawing.Size(189, 184);
            this.picImage_Resultant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage_Resultant.TabIndex = 10;
            this.picImage_Resultant.TabStop = false;
            // 
            // picImage_Original
            // 
            this.picImage_Original.Location = new System.Drawing.Point(20, 12);
            this.picImage_Original.Name = "picImage_Original";
            this.picImage_Original.Size = new System.Drawing.Size(189, 184);
            this.picImage_Original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage_Original.TabIndex = 9;
            this.picImage_Original.TabStop = false;
            // 
            // dgvImage_Statistics
            // 
            this.dgvImage_Statistics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvImage_Statistics.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvImage_Statistics.BackgroundColor = System.Drawing.Color.White;
            this.dgvImage_Statistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImage_Statistics.Location = new System.Drawing.Point(5, 218);
            this.dgvImage_Statistics.Name = "dgvImage_Statistics";
            this.dgvImage_Statistics.Size = new System.Drawing.Size(1361, 519);
            this.dgvImage_Statistics.TabIndex = 12;
            // 
            // Image_Staticstic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.dgvImage_Statistics);
            this.Controls.Add(this.lblStatus_Result_Analysis);
            this.Controls.Add(this.picImage_Resultant);
            this.Controls.Add(this.picImage_Original);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1386, 788);
            this.MinimumSize = new System.Drawing.Size(1364, 726);
            this.Name = "Image_Staticstic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image_Staticstic";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Image_Staticstic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage_Resultant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage_Original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImage_Statistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus_Result_Analysis;
        private System.Windows.Forms.PictureBox picImage_Resultant;
        private System.Windows.Forms.PictureBox picImage_Original;
        private System.Windows.Forms.DataGridView dgvImage_Statistics;
    }
}