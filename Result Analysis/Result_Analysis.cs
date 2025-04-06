using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace Result_Analysis
{
    public partial class Result_Analysis : Form
    {
        public Result_Analysis()
        {
            InitializeComponent();
        }        

        private void Browse_Image(int stat,string title)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = title;
                dlg.InitialDirectory = @"C:\Devika Gawande\Collection";
                if (dlg.ShowDialog() != DialogResult.Cancel)
                {
                    if (stat == 1)
                    {
                        picImage_Original.Image = Image.FromFile(dlg.FileName);
                    }
                    if (stat == 2)
                    {
                        picImage_Resultant.Image = Image.FromFile(dlg.FileName);
                    }
                }
                dlg.Dispose();
            }
            catch (Exception er)
            {
            }
        }

        private void linkBrowse_Image_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Browse_Image(1,"Input Original Image");
            Browse_Image(2,"Input Resultant Image");
        }
        public static Bitmap Original_Image;
        public static Bitmap Result_Image;
        public static int[] chart_red_original;
        public static int[] chart_red_result;
        public static int[] chart_green_original;
        public static int[] chart_green_result;
        public static int[] chart_blue_original;
        public static int[] chart_blue_result;
        public static int[] chart_average_original;
        public static int[] chart_average_result;
        private void linkPlot_Graph_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
            Read_Image_Parameters(out chart_red_original, out chart_red_result, out chart_green_original, out chart_green_result, out chart_blue_original, out chart_blue_result, out chart_average_original, out chart_average_result);
            Plot_Chart(chart_red_original, chart_red_result, chart_green_original, chart_green_result, chart_blue_original, chart_blue_result, chart_average_original, chart_average_result);
        }
         
        private void Read_Image_Parameters(out int[] chart_red_original, out int[] chart_red_result, out int[] chart_green_original, out int[] chart_green_result, out int[] chart_blue_original, out int[] chart_blue_result, out int[] chart_average_original, out int[] chart_average_result)
        {
            Original_Image = (Bitmap)picImage_Original.Image;
            Result_Image = (Bitmap)picImage_Resultant.Image;
            Result_Image = new Bitmap(Result_Image, new Size(Original_Image.Width, Original_Image.Height));
            chart_red_original = new int[Original_Image.Width * Original_Image.Height];
            chart_red_result = new int[Original_Image.Width * Original_Image.Height];

            chart_green_original = new int[Original_Image.Width * Original_Image.Height];
            chart_green_result = new int[Original_Image.Width * Original_Image.Height];

            chart_blue_original = new int[Original_Image.Width * Original_Image.Height];
            chart_blue_result = new int[Original_Image.Width * Original_Image.Height];

            chart_average_original = new int[Original_Image.Width * Original_Image.Height];
            chart_average_result = new int[Original_Image.Width * Original_Image.Height];

            Color col_original;
            Color col_result;
            int count = 0;
            try
            {
                for (int i = 0; i < Original_Image.Width; i++)
                {
                    for (int j = 0; j < Original_Image.Height; j++)
                    {
                        try
                        {
                            col_original = Original_Image.GetPixel(i, j);
                            col_result = Result_Image.GetPixel(i, j);
                            chart_red_original[count] = col_original.R;
                            chart_red_result[count] = col_result.R;

                            chart_green_original[count] = col_original.G;
                            chart_green_result[count] = col_result.G;

                            chart_blue_original[count] = col_original.B;
                            chart_blue_result[count] = col_result.B;

                            chart_average_original[count] = (int)(col_original.R + col_original.G + col_original.B) / 3;
                            chart_average_result[count] = (int)(col_result.R + col_result.G + col_result.B) / 3;

                            count++;
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
        }

        private void Plot_Chart(int[] chart_red_original, int[] chart_red_result, int[] chart_green_original, int[] chart_green_result, int[] chart_blue_original, int[] chart_blue_result, int[] chart_average_original, int[] chart_average_result)
        {
            try
            {
                chart_Red.Series["Red_Original"].Color = Color.Red;
                chart_Red.Series["Red_Resultant"].Color = Color.Blue;

                chart_green.Series["Green_Original"].Color = Color.Pink;
                chart_green.Series["Green_Resultant"].Color = Color.Brown;

                chart_blue.Series["Blue_Original"].Color = Color.Chocolate;
                chart_blue.Series["Blue_Resultant"].Color = Color.DarkGreen;

                chart_average.Series["Gray_Original"].Color = Color.DarkBlue;
                chart_average.Series["Gray_Resultant"].Color = Color.DarkGoldenrod;

                for (long i = 0; i < chart_red_original.Length; i++)
                {
                    chart_Red.Series["Red_Original"].Points.AddXY(i, chart_red_original[i]);
                    chart_Red.Series["Red_Resultant"].Points.AddXY(i, chart_red_result[i]);

                    chart_green.Series["Green_Original"].Points.AddXY(i, chart_green_original[i]);
                    chart_green.Series["Green_Resultant"].Points.AddXY(i, chart_green_result[i]);

                    chart_blue.Series["Blue_Original"].Points.AddXY(i, chart_blue_original[i]);
                    chart_blue.Series["Blue_Resultant"].Points.AddXY(i, chart_blue_result[i]);

                    chart_average.Series["Gray_Original"].Points.AddXY(i, chart_average_original[i]);
                    chart_average.Series["Gray_Resultant"].Points.AddXY(i, chart_average_result[i]);

                    lblStatus_Result_Analysis.Text = Math.Round(((double)(i+1) / (double)chart_red_original.Length) * 100, 2).ToString() + " % Completed";
                    lblStatus_Result_Analysis.Refresh();
                }
            }
            catch (Exception er)
            {
            }
            Chart_Original_Image original = new Chart_Original_Image();
            original.Show();
            Chart_Result_Image result = new Chart_Result_Image();
            result.Show();
            Quantizition_Error err = new Quantizition_Error();
            err.Show();
            Image_Staticstic st = new Image_Staticstic();
            st.Show();
            Image_Comparitive_Analysis ICA = new Image_Comparitive_Analysis();
            ICA.Show();
        }    
    }
}
