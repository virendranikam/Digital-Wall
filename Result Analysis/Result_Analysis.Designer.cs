namespace Result_Analysis
{
    partial class Result_Analysis
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Result_Analysis));
            this.chart_Red = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.picImage_Original = new System.Windows.Forms.PictureBox();
            this.linkBrowse_Image = new System.Windows.Forms.LinkLabel();
            this.picImage_Resultant = new System.Windows.Forms.PictureBox();
            this.linkPlot_Graph = new System.Windows.Forms.LinkLabel();
            this.chart_green = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_blue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_average = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblStatus_Result_Analysis = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage_Original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage_Resultant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_average)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_Red
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_Red.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Calibri Light", 12F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart_Red.Legends.Add(legend1);
            this.chart_Red.Location = new System.Drawing.Point(14, 228);
            this.chart_Red.Name = "chart_Red";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Lime;
            series1.Font = new System.Drawing.Font("Calibri Light", 12F);
            series1.Legend = "Legend1";
            series1.Name = "Red_Original";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Font = new System.Drawing.Font("Calibri Light", 12F);
            series2.Legend = "Legend1";
            series2.Name = "Red_Resultant";
            this.chart_Red.Series.Add(series1);
            this.chart_Red.Series.Add(series2);
            this.chart_Red.Size = new System.Drawing.Size(650, 213);
            this.chart_Red.TabIndex = 0;
            // 
            // picImage_Original
            // 
            this.picImage_Original.Location = new System.Drawing.Point(12, 12);
            this.picImage_Original.Name = "picImage_Original";
            this.picImage_Original.Size = new System.Drawing.Size(189, 184);
            this.picImage_Original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage_Original.TabIndex = 1;
            this.picImage_Original.TabStop = false;
            // 
            // linkBrowse_Image
            // 
            this.linkBrowse_Image.AutoSize = true;
            this.linkBrowse_Image.Location = new System.Drawing.Point(480, 9);
            this.linkBrowse_Image.Name = "linkBrowse_Image";
            this.linkBrowse_Image.Size = new System.Drawing.Size(102, 19);
            this.linkBrowse_Image.TabIndex = 2;
            this.linkBrowse_Image.TabStop = true;
            this.linkBrowse_Image.Text = "Browse Image";
            this.linkBrowse_Image.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBrowse_Image_LinkClicked);
            // 
            // picImage_Resultant
            // 
            this.picImage_Resultant.Location = new System.Drawing.Point(258, 12);
            this.picImage_Resultant.Name = "picImage_Resultant";
            this.picImage_Resultant.Size = new System.Drawing.Size(189, 184);
            this.picImage_Resultant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage_Resultant.TabIndex = 3;
            this.picImage_Resultant.TabStop = false;
            // 
            // linkPlot_Graph
            // 
            this.linkPlot_Graph.AutoSize = true;
            this.linkPlot_Graph.Location = new System.Drawing.Point(588, 9);
            this.linkPlot_Graph.Name = "linkPlot_Graph";
            this.linkPlot_Graph.Size = new System.Drawing.Size(78, 19);
            this.linkPlot_Graph.TabIndex = 4;
            this.linkPlot_Graph.TabStop = true;
            this.linkPlot_Graph.Text = "Plot Graph";
            this.linkPlot_Graph.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPlot_Graph_LinkClicked);
            // 
            // chart_green
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_green.ChartAreas.Add(chartArea2);
            legend2.Font = new System.Drawing.Font("Calibri Light", 12F);
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chart_green.Legends.Add(legend2);
            this.chart_green.Location = new System.Drawing.Point(708, 228);
            this.chart_green.Name = "chart_green";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Lime;
            series3.Font = new System.Drawing.Font("Calibri Light", 12F);
            series3.Legend = "Legend1";
            series3.Name = "Green_Original";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Font = new System.Drawing.Font("Calibri Light", 12F);
            series4.Legend = "Legend1";
            series4.Name = "Green_Resultant";
            this.chart_green.Series.Add(series3);
            this.chart_green.Series.Add(series4);
            this.chart_green.Size = new System.Drawing.Size(650, 213);
            this.chart_green.TabIndex = 5;           
            // 
            // chart_blue
            // 
            chartArea3.Name = "ChartArea1";
            this.chart_blue.ChartAreas.Add(chartArea3);
            legend3.Font = new System.Drawing.Font("Calibri Light", 12F);
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.chart_blue.Legends.Add(legend3);
            this.chart_blue.Location = new System.Drawing.Point(14, 468);
            this.chart_blue.Name = "chart_blue";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Color = System.Drawing.Color.Lime;
            series5.Font = new System.Drawing.Font("Calibri Light", 12F);
            series5.Legend = "Legend1";
            series5.Name = "Blue_Original";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Font = new System.Drawing.Font("Calibri Light", 12F);
            series6.Legend = "Legend1";
            series6.Name = "Blue_Resultant";
            this.chart_blue.Series.Add(series5);
            this.chart_blue.Series.Add(series6);
            this.chart_blue.Size = new System.Drawing.Size(650, 213);
            this.chart_blue.TabIndex = 6;
            // 
            // chart_average
            // 
            chartArea4.Name = "ChartArea1";
            this.chart_average.ChartAreas.Add(chartArea4);
            legend4.Font = new System.Drawing.Font("Calibri Light", 12F);
            legend4.IsTextAutoFit = false;
            legend4.Name = "Legend1";
            this.chart_average.Legends.Add(legend4);
            this.chart_average.Location = new System.Drawing.Point(708, 468);
            this.chart_average.Name = "chart_average";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Color = System.Drawing.Color.Lime;
            series7.Font = new System.Drawing.Font("Calibri Light", 12F);
            series7.Legend = "Legend1";
            series7.Name = "Gray_Original";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Font = new System.Drawing.Font("Calibri Light", 12F);
            series8.Legend = "Legend1";
            series8.Name = "Gray_Resultant";
            this.chart_average.Series.Add(series7);
            this.chart_average.Series.Add(series8);
            this.chart_average.Size = new System.Drawing.Size(650, 213);
            this.chart_average.TabIndex = 7;
            // 
            // lblStatus_Result_Analysis
            // 
            this.lblStatus_Result_Analysis.AutoSize = true;
            this.lblStatus_Result_Analysis.Location = new System.Drawing.Point(724, 12);
            this.lblStatus_Result_Analysis.Name = "lblStatus_Result_Analysis";
            this.lblStatus_Result_Analysis.Size = new System.Drawing.Size(48, 19);
            this.lblStatus_Result_Analysis.TabIndex = 8;
            this.lblStatus_Result_Analysis.Text = "Status";
            // 
            // Result_Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.lblStatus_Result_Analysis);
            this.Controls.Add(this.chart_average);
            this.Controls.Add(this.chart_blue);
            this.Controls.Add(this.chart_green);
            this.Controls.Add(this.linkPlot_Graph);
            this.Controls.Add(this.picImage_Resultant);
            this.Controls.Add(this.linkBrowse_Image);
            this.Controls.Add(this.picImage_Original);
            this.Controls.Add(this.chart_Red);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1386, 788);
            this.MinimumSize = new System.Drawing.Size(1364, 726);
            this.Name = "Result_Analysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Result Analysis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;           
            ((System.ComponentModel.ISupportInitialize)(this.chart_Red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage_Original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage_Resultant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_average)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Red;
        private System.Windows.Forms.PictureBox picImage_Original;
        private System.Windows.Forms.LinkLabel linkBrowse_Image;
        private System.Windows.Forms.PictureBox picImage_Resultant;
        private System.Windows.Forms.LinkLabel linkPlot_Graph;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_green;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_blue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_average;
        private System.Windows.Forms.Label lblStatus_Result_Analysis;
    }
}

