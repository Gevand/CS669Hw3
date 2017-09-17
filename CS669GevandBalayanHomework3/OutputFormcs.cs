using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS669GevandBalayanHomework3
{
    public partial class OutputFormcs : Form
    {
        public OutputFormcs()
        {
            InitializeComponent();
        }

        private void OutputFormcs_Load(object sender, EventArgs e)
        {

        }
        public void LoadPicture(Bitmap input)
        {
            pictureBox1.Image = input;
            pictureBox1.Height = input.Height;
            pictureBox1.Width = input.Width;
        }
    }
}
