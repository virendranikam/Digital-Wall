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
    public partial class Image_Comparitive_Analysis : Form
    {
        public Image_Comparitive_Analysis()
        {
            InitializeComponent();
        }

        private void Image_Comparitive_Analysis_Load(object sender, EventArgs e)
        {
            int non_zero_original_count;
            int non_zero_result_count;
            Image_Comparative_Analysis(out non_zero_original_count, out non_zero_result_count);
            Indivisual_Image_Analysis(non_zero_original_count, non_zero_result_count);
        }

        private void Image_Comparative_Analysis(out int non_zero_original_count, out int non_zero_result_count)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Average_Red", typeof(double));
            dt.Columns.Add("Average_Green", typeof(double));
            dt.Columns.Add("Average_Blue", typeof(double));
            dt.Columns.Add("Mean_Square_Error", typeof(double));
            dt.Columns.Add("PSNR", typeof(double));
            dt.Columns.Add("Max_Difference", typeof(double));
            dt.Columns.Add("Min_Difference", typeof(double));
            dt.Columns.Add("Average_Difference", typeof(double));
            dt.Columns.Add("Normalize_Absulute_Error", typeof(double));
            dt.Columns.Add("Cross_Corelation", typeof(double));
            dt.Columns.Add("Structural Content", typeof(double));
            picImage_Original.Image = Result_Analysis.Original_Image;
            picImage_Resultant.Image = Result_Analysis.Result_Image;

            int Stat_count = 0;
            double sum = 0.0;
            double Normalize_Cross_Corelation = 0.0;
            double Average_Difference = 0.0;
            double sum_NK1 = 0.0;
            double sum_NK2 = 0.0;
            int[] error_diff = new int[Result_Analysis.chart_red_original.Length];

            for (int i = 0; i < Result_Analysis.chart_red_original.Length; i++)
            {
                error_diff[i] = Math.Abs(Result_Analysis.chart_average_original[i] - Result_Analysis.chart_average_result[i]);
                sum = sum + (error_diff[i] * error_diff[i]);
                Stat_count = Stat_count + 1;
                lblStatus_Result_Analysis.Text = " Calculating parameters (MSE, PSNR)" + Math.Round(((double)Stat_count / (double)Result_Analysis.chart_average_original.Length) * 100, 2).ToString() + " % Completed.";
                lblStatus_Result_Analysis.Refresh();
            }

            double MSE = sum / (Result_Analysis.Original_Image.Width * Result_Analysis.Original_Image.Height);
            double PSNR = (10 * Math.Log(255 * 255 / MSE)) / Math.Log(10);

            // Code for Calculating Normalize Cross corelation
            sum = 0.0;
            for (int i = 0; i < Result_Analysis.chart_red_original.Length; i++)
            {
                sum_NK1 = sum_NK1 + Result_Analysis.chart_average_original[i] * Result_Analysis.chart_average_result[i];
            }
            for (int i = 0; i < Result_Analysis.chart_red_original.Length; i++)
            {
                sum_NK2 = sum_NK2 + Result_Analysis.chart_average_original[i] * Result_Analysis.chart_average_original[i];
            }
            Normalize_Cross_Corelation = sum_NK1 / sum_NK2;

            // code for calculating Average Diffrence
            sum = 0.0;
            Average_Difference = error_diff.Sum() / (Result_Analysis.Original_Image.Width * Result_Analysis.Original_Image.Height);

            // code for calculating structural content
            double SC = sum_NK2 / sum_NK1;

            // Maximun Difference
            int Max_Diff = error_diff.Max();
            int Min_Diff = error_diff.Min();
            //Normalize Absulute Error
            double NAE = error_diff.Sum() / Result_Analysis.chart_average_original.Sum();

            // Average Red, Green, Blue
            double sum_average_red = 0.0;
            double sum_average_green = 0.0;
            double sum_average_blue = 0.0;
            non_zero_original_count = 0;
            non_zero_result_count = 0;
            Stat_count = 0;
            for (int i = 0; i < Result_Analysis.chart_average_original.Length; i++)
            {
                sum_average_red = sum_average_red + Math.Abs(Result_Analysis.chart_red_original[i] - Result_Analysis.chart_red_result[i]);
                sum_average_green = sum_average_green + Math.Abs(Result_Analysis.chart_green_original[i] - Result_Analysis.chart_green_result[i]);
                sum_average_blue = sum_average_blue + Math.Abs(Result_Analysis.chart_blue_original[i] - Result_Analysis.chart_blue_result[i]);
                if (Result_Analysis.chart_average_original[i] > 0)
                {
                    non_zero_original_count++;
                }
                if (Result_Analysis.chart_average_result[i] > 0)
                {
                    non_zero_result_count++;
                }
                lblStatus_Result_Analysis.Text = " Calculating Average RGB Sum" + Math.Round(((double)Stat_count / (double)Result_Analysis.chart_average_original.Length) * 100, 2).ToString() + " % Completed.";
                lblStatus_Result_Analysis.Refresh();
            }
            sum_average_red = sum_average_red / (Result_Analysis.Original_Image.Width * Result_Analysis.Original_Image.Height);
            sum_average_green = sum_average_green / (Result_Analysis.Original_Image.Width * Result_Analysis.Original_Image.Height);
            sum_average_blue = sum_average_blue / (Result_Analysis.Original_Image.Width * Result_Analysis.Original_Image.Height);
            double Average_difference = (sum_average_red + sum_average_green + sum_average_blue) / 3;

            dt.Rows.Add(Math.Round(sum_average_red, 2),
                Math.Round(sum_average_green, 2),
                Math.Round(sum_average_blue, 2),
                Math.Round(MSE, 2),
                Math.Round(PSNR, 2),
                Max_Diff,
                Min_Diff,
                Math.Round(Average_difference, 2),
                Math.Round(NAE, 2),
                Math.Round(Normalize_Cross_Corelation, 2),
                Math.Round(SC, 2)
                );
            dgvImage_Comparitive_Analysis.DataSource = dt;
            lblStatus_Result_Analysis.Text = "Done";
            lblStatus_Result_Analysis.Refresh();
        }

        private void Indivisual_Image_Analysis(int non_zero_original_count, int non_zero_result_count)
        {
            // Indivisual Image Analysis
            DataTable dt_indivisual = new DataTable();
            dt_indivisual.Columns.Add("Image_Type", typeof(string));
            dt_indivisual.Columns.Add("Red_Mean", typeof(double));
            dt_indivisual.Columns.Add("Green_Mean", typeof(double));
            dt_indivisual.Columns.Add("Blue_Mean", typeof(double));
            dt_indivisual.Columns.Add("Mean", typeof(double));
            dt_indivisual.Columns.Add("Pure_Height", typeof(int));
            dt_indivisual.Columns.Add("Pure_Width", typeof(int));
            dt_indivisual.Columns.Add("Entropy", typeof(double));

            // Entrpoy Calculation            
            double Entropy_Original = (Result_Analysis.chart_average_original.Sum() / non_zero_original_count) *
                Math.Log(Result_Analysis.chart_average_original.Sum() / non_zero_original_count);

            double Entropy_Result = (Result_Analysis.chart_average_result.Sum() / non_zero_result_count) *
                Math.Log(Result_Analysis.chart_average_result.Sum() / non_zero_result_count);

            dt_indivisual.Rows.Add(
                "Original_Image",
                Result_Analysis.chart_red_original.Sum() / Result_Analysis.chart_red_original.Length,
                Result_Analysis.chart_green_original.Sum() / Result_Analysis.chart_green_original.Length,
                Result_Analysis.chart_blue_original.Sum() / Result_Analysis.chart_blue_original.Length,
                (Result_Analysis.chart_red_original.Sum() + Result_Analysis.chart_green_original.Sum() + Result_Analysis.chart_blue_original.Sum()) / 3,

                Result_Analysis.Original_Image.Height,
                Result_Analysis.Original_Image.Width,
                Math.Round(Entropy_Original, 2));


            dt_indivisual.Rows.Add(
                "Result_Image",
                Result_Analysis.chart_red_result.Sum() / Result_Analysis.chart_red_result.Length,
                Result_Analysis.chart_green_result.Sum() / Result_Analysis.chart_green_result.Length,
                Result_Analysis.chart_blue_result.Sum() / Result_Analysis.chart_blue_result.Length,
                (Result_Analysis.chart_red_result.Sum() + Result_Analysis.chart_green_result.Sum() + Result_Analysis.chart_blue_result.Sum()) / 3,
                Result_Analysis.Result_Image.Height,
                Result_Analysis.Result_Image.Width,
                Math.Round(Entropy_Result, 2));
            dgvIndivisual_Image_Analysis.DataSource = dt_indivisual;
        }
    }
}
