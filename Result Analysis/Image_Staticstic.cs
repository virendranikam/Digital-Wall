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
    public partial class Image_Staticstic : Form
    {
        public Image_Staticstic()
        {
            InitializeComponent();
        }

        private void Image_Staticstic_Load(object sender, EventArgs e)
        {
            Image_Statistics_Analysis();
        }

        private void Image_Statistics_Analysis()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("X_Position", typeof(int));
            dt.Columns.Add("Y_Position", typeof(int));
            dt.Columns.Add("Red_Original", typeof(int));
            dt.Columns.Add("Red_Original_Binary", typeof(string));
            dt.Columns.Add("Red_Resultant", typeof(int));
            dt.Columns.Add("Red_Resultnat_Binary", typeof(string));
            dt.Columns.Add("Red_Quantizition_Error", typeof(int));
            dt.Columns.Add("Red_Quantizition_Error_Binary", typeof(string));

            dt.Columns.Add("Green_Original", typeof(int));
            dt.Columns.Add("Green_Original_Binary", typeof(string));
            dt.Columns.Add("Green_Resultant", typeof(int));
            dt.Columns.Add("Green_Resultnat_Binary", typeof(string));
            dt.Columns.Add("Green_Quantizition_Error", typeof(int));
            dt.Columns.Add("Green_Quantizition_Error_Binary", typeof(string));

            dt.Columns.Add("Blue_Original", typeof(int));
            dt.Columns.Add("Blue_Original_Binary", typeof(string));
            dt.Columns.Add("Blue_Resultant", typeof(int));
            dt.Columns.Add("Blue_Resultnat_Binary", typeof(string));
            dt.Columns.Add("Blue_Quantizition_Error", typeof(int));
            dt.Columns.Add("Blue_Quantizition_Error_Binary", typeof(string));

            Color col_Original;
            Color col_Result;
            int Stat_count = 0;
            try
            {
                picImage_Original.Image = Result_Analysis.Original_Image;
                picImage_Resultant.Image = Result_Analysis.Result_Image;
                for (int i = 0; i < Result_Analysis.Original_Image.Width; i++)
                {
                    for (int j = 0; j < Result_Analysis.Original_Image.Height; j++)
                    {
                        try
                        {
                            col_Original = Result_Analysis.Original_Image.GetPixel(i, j);
                            col_Result = Result_Analysis.Result_Image.GetPixel(i, j);

                            dt.Rows.Add(i, j,
                                col_Original.R, Convert.ToString(col_Original.R, 2).PadLeft(8, '0'),
                                col_Result.R, Convert.ToString(col_Result.R, 2).PadLeft(8, '0'),
                                Math.Abs(col_Original.R - col_Result.R),
                                Convert.ToString(Math.Abs(col_Original.R - col_Result.R), 2),

                                col_Original.G, Convert.ToString(col_Original.G, 2).PadLeft(8, '0'),
                                col_Result.G, Convert.ToString(col_Result.G, 2).PadLeft(8, '0'),
                                Math.Abs(col_Original.G - col_Result.G),
                                Convert.ToString(Math.Abs(col_Original.G - col_Result.G), 2),

                                col_Original.B, Convert.ToString(col_Original.B, 2).PadLeft(8, '0'),
                                col_Result.B, Convert.ToString(col_Result.B, 2).PadLeft(8, '0'),
                                Math.Abs(col_Original.B - col_Result.B),
                                Convert.ToString(Math.Abs(col_Original.B - col_Result.B), 2)
                                );
                            Stat_count = Stat_count + 1;
                            lblStatus_Result_Analysis.Text = "Generating Quantizition Image " + Math.Round(((double)Stat_count / ((double)(Result_Analysis.Original_Image.Width) * (double)
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
            lblStatus_Result_Analysis.Text = "100% Completed..";
            lblStatus_Result_Analysis.Refresh();
            dgvImage_Statistics.DataSource = dt;
        }
    }
}
