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
    public partial class Quantizition_Error : Form
    {
        public Quantizition_Error()
        {
            InitializeComponent();
        }

        private void Quantizition_Error_Load(object sender, EventArgs e)
        {
            Generate_Quantizition_Image();
            Plot_Quantizition_Error_Image_Graph();
        }

        private void Generate_Quantizition_Image()
        {
            Bitmap bmp = new Bitmap(Result_Analysis.Original_Image.Width, Result_Analysis.Original_Image.Height);
            Color col_Original;
            Color col_Result;
            int Stat_count = 0;
            try
            {
                for (int i = 0; i < Result_Analysis.Original_Image.Width; i++)
                {
                    for (int j = 0; j < Result_Analysis.Original_Image.Height; j++)
                    {
                        try
                        {
                            col_Original = Result_Analysis.Original_Image.GetPixel(i, j);
                            col_Result = Result_Analysis.Result_Image.GetPixel(i, j);
                            bmp.SetPixel(i, j,
                                Color.FromArgb(Math.Abs(col_Original.R - col_Result.R),
                                Math.Abs(col_Original.G - col_Result.G),
                                Math.Abs(col_Original.B - col_Result.B)));
                            Stat_count = Stat_count +1;
                            lblStatus_Result_Analysis.Text ="Generating Quantizition Image " +  Math.Round(((double)Stat_count / ((double)(Result_Analysis.Original_Image.Width) * (double)
                                (Result_Analysis.Original_Image.Height))) * 100, 2).ToString() + " % Completed.";
                            lblStatus_Result_Analysis.Refresh();
                        }
                        catch (Exception er)
                        {
                        }
                    }
                }
            }
            catch (Exception er)
            {
            }
            picQuanizition_Error_Image.Image = bmp;
        }
        private void Plot_Quantizition_Error_Image_Graph()
        {
            try
            {
                chart_Red.Series["Red_Quantizition_Error"].Color = Color.Red;
                chart_green.Series["Green_Quantizition_Error"].Color = Color.Green;
                chart_blue.Series["Blue_Quantizition_Error"].Color = Color.Blue;
                chart_average.Series["Gray_Quantizition_Error"].Color = Color.Gray;
                for (long i = 0; i < Result_Analysis.chart_red_original.Length; i++)
                {
                    chart_Red.Series["Red_Quantizition_Error"].Points.AddXY(i, Math.Abs(Result_Analysis.chart_red_result[i] - Result_Analysis.chart_red_original[i]));
                    chart_green.Series["Green_Quantizition_Error"].Points.AddXY(i, Math.Abs(Result_Analysis.chart_green_result[i] - Result_Analysis.chart_green_original[i]));
                    chart_blue.Series["Blue_Quantizition_Error"].Points.AddXY(i, Math.Abs(Result_Analysis.chart_blue_result[i] - Result_Analysis.chart_blue_original[i]));
                    chart_average.Series["Gray_Quantizition_Error"].Points.AddXY(i, Math.Abs(Result_Analysis.chart_average_result[i] - Result_Analysis.chart_average_original[i]));
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
