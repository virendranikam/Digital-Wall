using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Virendra
{
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            Show_Result();
        }

        private void Show_Result()
        {
            try
            {
                picResult_Image.Image = Virendra_Hiding.bmp;
                picOriginal_Image.Image = Image.FromFile(@"C:\Virendra Nikam\Collection\Input.bmp");
                picResult_Image.Image.Save(@"C:\Virendra Nikam\Collection\Result.bmp");
            }
            catch (Exception er)
            {
            }
        }        
    }
}
