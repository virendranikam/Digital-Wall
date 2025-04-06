using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Data.OleDb;
namespace Virendra
{
    public partial class Virendra_Hiding : Form
    {
       public static Bitmap bmp = null;
       public Virendra_Hiding()
        {
            InitializeComponent();
        }

        private void linkBrowsecarrier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblLog_User_Name.Text == string.Empty)
            {
                MessageBox.Show("Loging First");
                return;
            }
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
                            lblStatus_Region_of_interest.Text = Math.Round(((double)Status_progress / ((double)((x2 - x1)+1) * (double)((y2 - y1)+1))) * 100, 2).ToString() + " % Completed.";
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
            lblcapacity.Text = (((drvPixels.Rows.Count -1) * 3 )/8).ToString()  + " Charecters";
        }
        
        private void linkCluster_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblLog_User_Name.Text == string.Empty)
            {
                MessageBox.Show("Loging First");
                return;
            }
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
                    status_count=status_count+1;
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

        private void linkBrowseSecreteData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblLog_User_Name.Text == string.Empty)
            {
                MessageBox.Show("Loging First");
                return;
            }
            BrowseSecreteData();
            Convert_Secrete_Data_to_Binary();
        }
        private void BrowseSecreteData()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "*.* | *.*";
                dlg.InitialDirectory = @"C:\Virendra Nikam\DOC";
                if (dlg.ShowDialog() != DialogResult.Cancel)
                {
                    txtBrowse_Data_Path.Text = dlg.FileName;
                    StreamReader reader = new StreamReader(dlg.FileName);
                    txtSecreteData.Text = reader.ReadToEnd();
                    reader.Close();
                    File.Copy(txtBrowse_Data_Path.Text, @"C:\Virendra Nikam\Collection\Embed_File.txt");
                }
            }
            catch (Exception er)
            {
            }
        }

        private void txtSecreteData_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Convert_Secrete_Data_to_Binary()
        {
            try
            {
                txtSecreteBinary.Text = string.Empty;
                int status_count = 0;
                if ((((drvPixels.Rows.Count - 1) * 3) / 8) < txtSecreteData.Text.Length)
                {
                    return;
                }
                lblCharecterCount.Text = txtSecreteData.Text.Length.ToString();
                foreach (char ch in txtSecreteData.Text)
                {
                    txtSecreteBinary.AppendText(Convert.ToString((int)ch, 2).PadLeft(8, '0'));
                    status_count = status_count + 1;
                    lblStatus_Browse_Data.Text = Math.Round(((double)status_count / (double)txtSecreteData.Text.Length) * 100, 2).ToString() + " % Completed.";
                    lblStatus_Browse_Data.Refresh();
                }
            }
            catch (Exception er)
            {
            }
        }

        private void linkEmbed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblLog_User_Name.Text == string.Empty)
            {
                MessageBox.Show("Loging First");
                return;
            }
            EmbedData();
            Result r = new Result();
            r.Show();
        }
        private void EmbedData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Index", typeof(string));
            dt.Columns.Add("Red_Original", typeof(int));
            dt.Columns.Add("Red_Original_Binary", typeof(string));            
            dt.Columns.Add("Red_Resultant", typeof(int));
            dt.Columns.Add("Red_Resultant_Binary", typeof(string));
            dt.Columns.Add("Red_Error", typeof(int));
            dt.Columns.Add("Red_Bit", typeof(string));

            dt.Columns.Add("Green_Original", typeof(int));
            dt.Columns.Add("Green_Original_Binary", typeof(string));
            dt.Columns.Add("Green_Resultant", typeof(int));
            dt.Columns.Add("Green_Resultant_Binary", typeof(string));
            dt.Columns.Add("Green_Error", typeof(int));
            dt.Columns.Add("Green_Bit", typeof(string));

            dt.Columns.Add("Blue_Original", typeof(int));
            dt.Columns.Add("Blue_Original_Binary", typeof(string));
            dt.Columns.Add("Blue_Resultant", typeof(int));
            dt.Columns.Add("Blue_Resultant_Binary", typeof(string));
            dt.Columns.Add("Blue_Error", typeof(int));
            dt.Columns.Add("Blue_Bit", typeof(string));

            char[] ch = txtSecreteBinary.Text.ToCharArray();
            int count = 0;
            int cr = 1;
            string result = string.Empty;
            int resultcomponant = 0;
            int componant = 0;
            string index = string.Empty;
            char[] binary = null;
            int status_count = 0;
            try
            {                
                for (int i = 0; i < drvPixels.Rows.Count; i++)
                {
                    result=string.Empty;
                    result= drvPixels.Rows[i].Cells[0].Value.ToString();
                    cr = 1;
                    for (int j = 2; j <= 6; j = j + 2)
                    {                        
                        componant =int.Parse(drvPixels.Rows[i].Cells[cr].Value.ToString());
                        binary = Convert.ToString(componant, 2).PadLeft(8, '0').ToCharArray();
                        Array.Reverse(binary);
                        if (binary[int.Parse(cmbPosition.Text)] != ch[count])
                        {
                            resultcomponant = SearchComponant(componant, ch[count]);
                        }
                        else
                        {
                            resultcomponant = componant;
                        }                        
                        result = result + "," + componant + "," + Convert.ToString(componant, 2).PadLeft(8, '0') + "," + resultcomponant + "," + Convert.ToString(resultcomponant, 2).PadLeft(8, '0') + "," + Math.Abs(componant - resultcomponant) + "," + ch[count].ToString();
                        count++;
                        cr = cr + 2;
                    }
                    string[] c= result.Split(new char[] { ',' });
                    SetImagePixel(c);
                    dt.Rows.Add(c[0], c[1], c[2], c[3], c[4], c[5], c[6], c[7], c[8], c[9], c[10], c[11], c[12], c[13], c[14], c[15],c[16],c[17],c[18]);
                    status_count = status_count + 1;
                    lblStatus_Embed_Data.Text = Math.Round(((double)status_count / (double)drvPixels.Rows.Count) * 100, 2).ToString() + " % Completed.";
                    lblStatus_Embed_Data.Refresh();
                }               
            }
            catch (Exception er)
            {
                resultcomponant = componant;
                string[] c = result.Split(new char[] { ',' });
                SetImagePixel(c);
                try
                {
                    dt.Rows.Add(c[0], c[1], c[2], c[3], c[4], c[5], c[6], c[7], c[8], c[9], c[10], c[11], c[12], c[13], c[14], c[15], c[16], c[17], c[18]);
                }
                catch (Exception e)
                {
                    try
                    {
                        dt.Rows.Add(c[0], c[1], c[2], c[3], c[4], c[5], c[6], c[7], c[8], c[9], c[10], c[11], c[12], 0, string.Empty, 0, string.Empty, 0, string.Empty);
                    }
                    catch (Exception r)
                    {
                        try
                        {
                            dt.Rows.Add(c[0], c[1], c[2], c[3], c[4], c[5], c[6], 0, string.Empty, 0, string.Empty, 0, string.Empty, 0, string.Empty, 0, string.Empty, 0, string.Empty);
                        }
                        catch (Exception err)
                        {
                        }
                    }
                }
            }
            lblStatus_Embed_Data.Text = " 100% Completed.";
            lblStatus_Embed_Data.Refresh();
            dgvEmbed.DataSource = dt;
        }

        private void SetImagePixel(string[] c)
        {
            string[] pos = null;
            Color col;
            try
            {
               col = Color.FromArgb(int.Parse(c[3]), int.Parse(c[9]), int.Parse(c[15]));
               pos = c[0].Split('-');
               bmp.SetPixel(int.Parse(pos[0]), int.Parse(pos[1]), col);
            }
            catch (Exception er)
            {
                try
                {
                    col = Color.FromArgb(int.Parse(c[3]), int.Parse(c[9]), 0);
                    pos = c[0].Split('-');
                    bmp.SetPixel(int.Parse(pos[0]), int.Parse(pos[1]), col);
                }
                catch (Exception r)
                {
                    try
                    {
                        col = Color.FromArgb(int.Parse(c[3]), 0, 0);
                        pos = c[0].Split('-');
                        bmp.SetPixel(int.Parse(pos[0]), int.Parse(pos[1]), col);
                    }
                    catch (Exception et)
                    {
                    }
                }
            }
            
        }
        private int SearchComponant(int componant, char ch)
        {
                    int i = 0;
                    int[] diff = null;
                    if (ch == '0')
                    {
                       diff = new int[drvClass0.Rows.Count-1];
                    }
                    else if(ch=='1')
                    {
                       diff = new int[drvClass1.Rows.Count-1];
                    }

                    try
                    {               
                        if(ch=='0')
                        {                    
                            for (i = 0; i < drvClass0.Rows.Count; i++)
                            {                       
                               diff[i] =Math.Abs(int.Parse(drvClass0.Rows[i].Cells[0].Value.ToString())- componant);                        
                            }                            
                        }
                        if (ch == '1')
                        {
                            for (i = 0; i < drvClass1.Rows.Count; i++)
                            {
                                diff[i] = Math.Abs(int.Parse(drvClass1.Rows[i].Cells[0].Value.ToString()) - componant);
                            } 
                        }
                    }
                    catch (Exception er)
                    {
                    }
                    int min = diff.Min();
                    int mindiff = Array.IndexOf(diff, diff.Min());
                    if (ch == '0')
                    {
                        componant = int.Parse(drvClass0.Rows[mindiff].Cells[0].Value.ToString());
                    }
                    if (ch == '1')
                    {
                        componant = int.Parse(drvClass1.Rows[mindiff].Cells[0].Value.ToString());
                    }
                    return componant;
        }        

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblLog_User_Name.Text == string.Empty)
            {
                MessageBox.Show("Loging First");
                return;
            }
            ReadROI();
        }

        private void linkCalculate_Capacity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblLog_User_Name.Text == string.Empty)
            {
                MessageBox.Show("Loging First");
                return;
            }
            Calculate_Capacity();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void linkNext_Browse_Carrier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void linkNext_region_of_interest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 5;
            cmbPosition.SelectedIndex = 0;
        }

        private void linkNext_Cluster_Data_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 6;
        }

        private void linkNext_Browse_Data_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 7;
        }        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User_Login();
        }
        private void User_Login()
        {
            try
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Virendra Nikam\Login.accdb";
                conn.Open();
                string query = "select * from Login where User_Name='" + txtuserName.Text + "' and User_Password ='" + txtloginpassword.Text + "'";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Login Succesful");
                    lblLog_User_Name.Text = txtuserName.Text;                    
                    Clear_User_Login();                    
                    string User_Choice = Microsoft.VisualBasic.Interaction.InputBox(" Enter  your choice. 1:Data Hiding 2:Data Extraction 3:Image Analyss 4: Text Analysis");
                    if (int.Parse(User_Choice) == 1)
                    {
                        Delete_Previous_Files();
                        tabControl1.SelectedIndex =3;
                    }
                    if (int.Parse(User_Choice) == 2)
                    {
                        Virendra_Extraction ex = new Virendra_Extraction();
                        ex.Show();
                    }
                    if (int.Parse(User_Choice) == 3)
                    {
                        System.Diagnostics.Process.Start(@"C:\Virendra Nikam\Result Analysis\bin\Debug\Result_Analysis.exe");
                    }
                    if (int.Parse(User_Choice) == 4)
                    {
                        System.Diagnostics.Process.Start(@"C:\Virendra Nikam\Text_Result_Analysis\bin\Debug\Text_Result_Analysis.exe");
                    }
                }
                conn.Close();
                cmd.Dispose();
            }
            catch (Exception er)
            {
            }
        }

        private static void Delete_Previous_Files()
        {
            try
            {
                string[] files = System.IO.Directory.GetFiles(@"C:\Virendra Nikam\Collection","*.*",SearchOption.AllDirectories);
                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        File.Delete(files[i]);
                    }
                    catch (Exception er)
                    {
                    }
                }
            }
            catch (Exception er)
            {
            }
        }
        private void Clear_User_Login()
        {
            txtuserName.Text = string.Empty;
            txtloginpassword.Text = string.Empty;
        }

        private void Devika_Extraction_Load(object sender, EventArgs e)
        {

        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            New_User_Registration();
        }
        private int Check_For_User_Exist()
        {
            int stat = 0;
            try
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Virendra Nikam\Login.accdb";
                conn.Open();
                string query = "select * from Login where User_Name='" + txtUser_Name_Registration.Text + "'";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    stat = 1;
                    MessageBox.Show("User Name already exist ");
                    return stat;
                }
                conn.Close();
                cmd.Dispose();
                reader.Close();
            }
            catch (Exception er)
            {
            }
            return stat;
        }
        private void New_User_Registration()
        {
            try
            {
                int stat = Check_For_User_Exist();
                if (stat == 1)
                {
                    return;
                }
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Virendra Nikam\Login.accdb";
                conn.Open();
                string query = "insert into Login(User_Name,User_Email,User_Phone,User_Password,User_Confirm_Password,User_Address) values('" + txtUser_Name_Registration.Text + "','" + txtUser_Email_Registration.Text + "','" + txtUser_Phone_Registration.Text + "','" + txtUser_Password_Registration.Text + "','" + txtUser_Confirm_Password_Registration.Text + "','" + txtUser_Address_Registration.Text + "')";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("User Registard Succesfuly");
                    Clear_User_Registration();
                    tabControl1.SelectedIndex = 2;
                }
                conn.Close();
                cmd.Dispose();
            }
            catch (Exception er)
            {
            }
        }

        private void linkSign_out_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Clear_User_Registration()
        {
            txtUser_Name_Registration.Text = string.Empty;
            txtUser_Email_Registration.Text = string.Empty;
            txtUser_Password_Registration.Text = string.Empty;
            txtUser_Confirm_Password_Registration.Text = string.Empty;
            txtUser_Phone_Registration.Text = string.Empty;
            txtUser_Address_Registration.Text = string.Empty;
        }

        private void linGo_to_Login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void linknotreg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

    }
}
