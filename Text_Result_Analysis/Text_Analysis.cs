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
namespace Text_Result_Analysis
{
    public partial class Text_Analysis : Form
    {
        public Text_Analysis()
        {
            InitializeComponent();
        }

        private void link_Browse_File_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Browse_Text_File(1);
            Browse_Text_File(2);
        }
        private void Browse_Text_File(int stat)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = @"C:\Devika Gawande\Collection";
                if (dlg.ShowDialog() != DialogResult.Cancel)
                {
                    StreamReader reader = new StreamReader(dlg.FileName);
                    if (stat == 1)
                    {
                        txtFile1_Path.Text = dlg.FileName;
                        txtFile1_Content.Text = reader.ReadToEnd().Trim();
                    }
                    if (stat == 2)
                    {
                        txtFile2_Path.Text = dlg.FileName;
                        txtFile2_Content.Text = reader.ReadToEnd().Trim();
                    }
                    reader.Close();
                }
            }
            catch (Exception er)
            {
            }
        }       

        private void linkText_Analysis_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtFile1_Content.Text.Length != txtFile2_Content.Text.Length)
            {
                MessageBox.Show("Files are not same");
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("Char_No", typeof(int));
            dt.Columns.Add("Char_File1", typeof(char));
            dt.Columns.Add("Char_ASCII_File1", typeof(int));
            dt.Columns.Add("Char_ASCII_File1_Binary", typeof(string));
            dt.Columns.Add("Char_File2", typeof(char));
            dt.Columns.Add("Char_ASCII_File2", typeof(int));
            dt.Columns.Add("Char_ASCII_File2_Binary", typeof(string));
            dt.Columns.Add("Difference_Count", typeof(int));
            dt.Columns.Add("Match_Count", typeof(int));
            int diff_count = 0;
            int math_count = 0;
            int stat_count = 0;
            try
            {
                for (int i = 0; i < txtFile1_Content.Text.Length; i++)
                {
                    try
                    {
                        if (txtFile1_Content.Text[i] == txtFile2_Content.Text[i])
                        {
                            math_count++;
                        }
                        else
                        {
                            diff_count++;
                        }
                        dt.Rows.Add(i,
                            txtFile1_Content.Text[i],
                            (int)txtFile1_Content.Text[i],
                            Convert.ToString((int)txtFile1_Content.Text[i], 2),
                            txtFile2_Content.Text[i],
                            (int)txtFile2_Content.Text[i],
                            Convert.ToString((int)txtFile2_Content.Text[i], 2),
                            diff_count,
                            math_count
                            );
                        stat_count = stat_count + 1;
                        lblStatus_Text_Analysis.Text = Math.Round(((double)stat_count / (double)txtFile1_Content.Text.Length) * 100, 2).ToString() + "%completed.";
                        lblStatus_Text_Analysis.Refresh();
                    }
                    catch (Exception er)
                    {
                    }
                }
            }
            catch (Exception er)
            {
            }
            lblStatus_Text_Analysis.Text = "100% completed.";
            lblStatus_Text_Analysis.Refresh();
            dgvText_Analysis.DataSource = dt;
        }

        private void Text_Analysis_Load(object sender, EventArgs e)
        {

        }   
    }
}
