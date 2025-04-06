using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
namespace Virendra
{
    public partial class Virendra_Extraction : Form
    {
        public static Bitmap bmp = null;
        public Virendra_Extraction()
        {
            InitializeComponent();
        }

        private void linkBrowsecarrier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BrowseCarrier();
        }
        private void BrowseCarrier()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "*.bmp|*.bmp";
                dlg.InitialDirectory = @"C:\Virendra Nikam\Images";
                if (dlg.ShowDialog() != DialogResult.Cancel)
                {
                    picInput.Image = Image.FromFile(dlg.FileName);
                    bmp = (Bitmap)picInput.Image;
                    bmp.Save(@"C:\Virendra Nikam\Collection\Input.bmp");
                }
            }
            catch (Exception er)
            {
            }
        }
        int corcount = 0;
        int x1, y1, x2, y2;
        private void picInput_Click(object sender, EventArgs e)
        {
            Get_Pixel_Cordinates(e);
        }

        private void Get_Pixel_Cordinates(EventArgs e)
        {
            try
            {
                MouseEventArgs ar = (MouseEventArgs)e;
                Point cor = ar.Location;
                if (corcount == 0)
                {
                    txtStart.Text = cor.X + "-" + cor.Y;
                    corcount++;
                    x1 = cor.X;
                    y1 = cor.Y;
                    CheckStatus();
                    return;
                }
                if (corcount == 1)
                {
                    txtEnd.Text = cor.X + "-" + cor.Y;
                    corcount = 0;
                    x2 = cor.X;
                    y2 = cor.Y;
                    CheckStatus();
                    return;
                }
            }
            catch (Exception er)
            {
            }
        }

        private void Calculate_Capacity()
        {
            int i = 0;
            int j = 0;
            int Status_progress = 0;
            try
            {
                for (i = x1; i <= x2; i++)
                {
                    for (j = y1; j <= y2; j++)
                    {
                        try
                        {
                            Status_progress = Status_progress + 1;
                            lblStatus_Progress.Text = Math.Round(((double)Status_progress / ((double)((x2 - x1) + 1) * (double)((y2 - y1) + 1))) * 100, 2).ToString() + " % Completed.";
                            lblStatus_Progress.Refresh();
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
            lblcapacity.Text = (((double)(Status_progress) * 3.0) / 8.0).ToString() + " Charecters";
        }

        private void CheckStatus()
        {
            try
            {
                if (x2 < x1)
                {
                    lblStatus.Text = "Invalid Selection";
                }
                if (y2 < y1)
                {
                    lblStatus.Text = "Invalid Selection";
                }
                if (x1 < x2 && y1 < y2)
                {
                    lblStatus.Text = "Valid Selection";
                }
            }
            catch (Exception er)
            {
            }
        }

        private void linkCalculate_Capacity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Get_Cordinate_Position();
            Calculate_Capacity();
        }

        private void Get_Cordinate_Position()
        {
            string[] pos_Start = txtStart.Text.Split('-');
            x1 = int.Parse(pos_Start[0]);
            y1 = int.Parse(pos_Start[1]);
            string[] pos_End = txtEnd.Text.Split('-');
            x2 = int.Parse(pos_End[0]);
            y2 = int.Parse(pos_End[1]);
        }

        private void picInput_Click_1(object sender, EventArgs e)
        {
            Get_Pixel_Cordinates(e);
        }

        private void linkNext_Browse_Carrier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void linkGet_ROI_Pixels_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ReadROI();
        }
        private void ReadROI()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Index", typeof(string));
            dt.Columns.Add("Red", typeof(int));
            dt.Columns.Add("Binary(Red)", typeof(string));
            dt.Columns.Add("Green", typeof(int));
            dt.Columns.Add("Binary(Green)", typeof(string));
            dt.Columns.Add("Blue", typeof(int));
            dt.Columns.Add("Binary(Blue)", typeof(string));
            drvPixels.DataSource = null;
            int i = 0;
            int j = 0;
            Color col;
            int Status_progress = 0;
            try
            {
                for (i = x1; i <= x2; i++)
                {
                    for (j = y1; j <= y2; j++)
                    {
                        try
                        {
                            col = bmp.GetPixel(i, j);
                            dt.Rows.Add(i.ToString() + "-" + j.ToString(), col.R, Convert.ToString(col.R, 2).PadLeft(8, '0'), col.G, Convert.ToString(col.G, 2).PadLeft(8, '0'), col.B, Convert.ToString(col.B, 2).PadLeft(8, '0'));
                            Status_progress = Status_progress + 1;
                            lblStatus_Region_of_interest.Text = Math.Round(((double)Status_progress / ((double)((x2 - x1) + 1) * (double)((y2 - y1) + 1))) * 100, 2).ToString() + " % Completed.";
                            lblStatus_Region_of_interest.Refresh();
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
            drvPixels.DataSource = dt;
            lblcapacity.Text = (((drvPixels.Rows.Count - 1) * 3) / 8).ToString() + " Charecters";
        }

        private void linkNext_region_of_interest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void linkCluster_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CluserData();
        }
        private void CluserData()
        {
            DataTable cluster0 = new DataTable();
            DataTable cluster1 = new DataTable();
            drvClass0.DataSource = drvClass1.DataSource = null;
            cluster0.Columns.Add("Value", typeof(int));
            cluster0.Columns.Add("Class[0]", typeof(string));
            cluster1.Columns.Add("Value", typeof(int));
            cluster1.Columns.Add("Class[1]", typeof(string));
            int status_count = 0;
            try
            {
                for (int i = 0; i < 256; i++)
                {
                    char[] ch = Convert.ToString(i, 2).PadLeft(8, '0').ToCharArray();
                    Array.Reverse(ch);
                    if (ch[int.Parse(cmbPosition.Text)] == '0')
                    {
                        cluster0.Rows.Add(i, Convert.ToString(i, 2).PadLeft(8, '0').ToString());
                    }
                    else
                    {
                        cluster1.Rows.Add(i, Convert.ToString(i, 2).PadLeft(8, '0').ToString());
                    }
                    status_count = status_count + 1;
                    lblStatus_Cluster_Data.Text = Math.Round(((double)status_count / (double)256) * 100, 2).ToString() + " % Completed.";
                    lblStatus_Cluster_Data.Refresh();
                }
            }
            catch (Exception er)
            {
            }
            drvClass0.DataSource = cluster0;
            drvClass1.DataSource = cluster1;
            cluster0.Dispose();
            cluster1.Dispose();
        }

        private void linkNext_Cluster_Data_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void linkExtractData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                int input_Extract_Bits = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter No. of Extraction Bits"));
                lblCharecterCount.Text = input_Extract_Bits.ToString();
            }
            catch (Exception er)
            {
                MessageBox.Show("Wrong Input");
                return;
            }

            ExtractData();
            ConverttoASCII();
        }
        private void ExtractData()
        {
            Color col;
            int status_count = 0;
            txtExtract.Text = string.Empty;
            try
            {
                bmp = new Bitmap(@"C:\Virendra Nikam\Collection\Result.bmp");
                for (int i = 0; i < drvPixels.Rows.Count; i++)
                {
                    string[] pos = drvPixels.Rows[i].Cells[0].Value.ToString().Split(new char[] { '-' });
                    col = bmp.GetPixel(int.Parse(pos[0]), int.Parse(pos[1]));
                    if (int.Parse(lblCharecterCount.Text) * 8 > txtExtract.Text.Length)
                    {
                        char[] r = Convert.ToString(col.R, 2).PadLeft(8, '0').ToCharArray();
                        Array.Reverse(r);
                        txtExtract.AppendText(r[int.Parse(cmbPosition.Text)].ToString());
                    }
                    if (int.Parse(lblCharecterCount.Text) * 8 > txtExtract.Text.Length)
                    {
                        char[] g = Convert.ToString(col.G, 2).PadLeft(8, '0').ToCharArray();
                        Array.Reverse(g);
                        txtExtract.AppendText(g[int.Parse(cmbPosition.Text)].ToString());
                    }
                    if (int.Parse(lblCharecterCount.Text) * 8 > txtExtract.Text.Length)
                    {
                        char[] b = Convert.ToString(col.B, 2).PadLeft(8, '0').ToCharArray();
                        Array.Reverse(b);
                        txtExtract.AppendText(b[int.Parse(cmbPosition.Text)].ToString());
                    }
                    if (int.Parse(lblCharecterCount.Text) * 8 == txtExtract.Text.Length)
                    {
                        break;
                    }
                    status_count = status_count + 1;
                    lblStatus_Extract_Data.Text = "Extracting data... " + Math.Round(((double)status_count / (double)drvPixels.Rows.Count) * 100, 2).ToString() + " % Completed.";
                    lblStatus_Extract_Data.Refresh();
                }
            }
            catch (Exception er)
            {
            }
            status_count = status_count + 1;
            lblStatus_Extract_Data.Text = "Extracting data. 100% Completed.";
            lblStatus_Extract_Data.Refresh();
        }

        private void ConverttoASCII()
        {
            try
            {
                txtExtractASCII.Text = string.Empty;
                for (int i = 0; i < txtExtract.Text.Length; i = i + 8)
                {
                    txtExtractASCII.AppendText(((char)Convert.ToInt32(txtExtract.Text.Substring(i, 8), 2)).ToString());
                    lblStatus_Extract_Data.Text = "Converting to ASCII... " + Math.Round(((double)i / (double)txtExtract.Text.Length), 2).ToString() + " % Completed.";
                    lblStatus_Extract_Data.Refresh();
                }
            }
            catch (Exception er)
            {
            }
            Save_Extracted_Data();
            lblStatus_Extract_Data.Text = "Converting to ASCII. 100% Completed.";
            lblStatus_Extract_Data.Refresh();
        }

        private void Save_Extracted_Data()
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"C:\Virendra Nikam\Collection\Extracted_Data.txt");
                sw.WriteLine(txtExtractASCII.Text);
                sw.Close();
            }
            catch (Exception er)
            {
            }
        }
        
    }
}
