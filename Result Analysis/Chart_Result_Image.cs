using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Result_Analysis
{
    public partial class Chart_Result_Image : Form
    {
        public Chart_Result_Image()
        {
            InitializeComponent();
        }

        private void Chart_Result_Image_Load(object sender, EventArgs e)
        {
            Plot_Resultant_Image_Graph();
        }
        private void Plot_Resultant_Image_Graph()
        {
            try
            {
                picImage_Resultant.Image = Result_Analysis.Original_Image;
                chart_Red.Series["Red_Resultant"].Color = Color.Red;
                chart_green.Series["Green_Resultant"].Color = Color.Green;
                chart_blue.Series["Blue_Resultant"].Color = Color.Blue;
                chart_average.Series["Gray_Resultant"].Color = Color.Gray;
                for (long i = 0; i < Result_Analysis.chart_red_original.Length; i++)
                {
                    chart_Red.Series["Red_Resultant"].Points.AddXY(i, Result_Analysis.chart_red_result[i]);
                    chart_green.Series["Green_Resultant"].Points.AddXY(i, Result_Analysis.chart_green_result[i]);
                    chart_blue.Series["Blue_Resultant"].Points.AddXY(i, Result_Analysis.chart_blue_result[i]);
                    chart_average.Series["Gray_Resultant"].Points.AddXY(i, Result_Analysis.chart_average_result[i]);
                    lblStatus_Result_Analysis.Text = Math.Round(((double)(i + 1) / (double)Result_Analysis.chart_red_original.Length) * 100, 2).ToString() + " % Completed";
                    lblStatus_Result_Analysis.Refresh();
                }
            }
            catch (Exception er)
            {
            }
        }
    }
}
