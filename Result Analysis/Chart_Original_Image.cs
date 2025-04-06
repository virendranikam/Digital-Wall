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
    public partial class Chart_Original_Image : Form
    {
        public Chart_Original_Image()
        {
            InitializeComponent();
        }

        private void Chart_Original_Image_Load(object sender, EventArgs e)
        {
            Plot_Original_Image_Graph();
        }

        private void Plot_Original_Image_Graph()
        {
            try
            {
                picImage_Original.Image = Result_Analysis.Original_Image;
                chart_Red.Series["Red_Original"].Color = Color.Red;
                chart_green.Series["Green_Original"].Color = Color.Green;
                chart_blue.Series["Blue_Original"].Color = Color.Blue;
                chart_average.Series["Gray_Original"].Color = Color.Gray;
                for (long i = 0; i < Result_Analysis.chart_red_original.Length; i++)
                {
                    chart_Red.Series["Red_Original"].Points.AddXY(i, Result_Analysis.chart_red_original[i]);
                    chart_green.Series["Green_Original"].Points.AddXY(i, Result_Analysis.chart_green_original[i]);
                    chart_blue.Series["Blue_Original"].Points.AddXY(i, Result_Analysis.chart_blue_original[i]);
                    chart_average.Series["Gray_Original"].Points.AddXY(i, Result_Analysis.chart_average_original[i]);
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
