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
    public partial class Form1 : Form
    {
        int cannyThresHold = 50;
        int sobelThreshold = 50;
        int prewittThreshold = 50;
        int laplaceThreshold = 20;
        public Form1()
        {
            InitializeComponent();
            txtCannyThreshold.Text = cannyThresHold.ToString();
            txtSobelThreshold.Text = sobelThreshold.ToString();
            txtPrewittThreshold.Text = prewittThreshold.ToString();
            txtLaplaceThreshold.Text = laplaceThreshold.ToString();
        }

        private void btnCanny_Click(object sender, EventArgs e)
        {
            if (pictInput.Image == null)
            {
                MessageBox.Show("First enter an image");
                return;
            }

        }
        private void LoadConstants()
        {
            int.TryParse(txtCannyThreshold.Text, out cannyThresHold);
            int.TryParse(txtSobelThreshold.Text, out sobelThreshold);
            int.TryParse(txtPrewittThreshold.Text, out prewittThreshold);
            int.TryParse(txtLaplaceThreshold.Text, out laplaceThreshold);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Open Image";
                    dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png" + "|All files (*.*)|*.*";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        pictInput.Image = new Bitmap(dlg.FileName);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Error! Couldn't load image.");
            }
        }

        private async void btnLaplace_Click(object sender, EventArgs e)
        {
            if (pictInput.Image == null)
            {
                MessageBox.Show("First enter an image");
                return;
            }
            LoadConstants();
            prgLoader.Maximum = 100;
            prgLoader.Step = 1;
            prgLoader.Value = 0;
            System.IProgress<int> progress = new Progress<int>(v =>
            {
                prgLoader.Value = v;
            });

            Bitmap greyScale = GreyScale(new Bitmap(pictInput.Image));


            var sobleBitMap = new Bitmap(greyScale.Width, greyScale.Height);
            await Task.Run(() =>
            {
                for (int i = 3; i < greyScale.Width - 3; i++)
                {
                    for (int j = 3; j < greyScale.Height - 3; j++)
                    {
                        int p1 = greyScale.GetPixel(i - 1, j - 1).R;
                        int p2 = greyScale.GetPixel(i - 1, j).R;
                        int p3 = greyScale.GetPixel(i - 1, j + 1).R;
                        int p4 = greyScale.GetPixel(i, j - 1).R;
                        int p5 = greyScale.GetPixel(i, j).R;
                        int p6 = greyScale.GetPixel(i, j + 1).R;
                        int p7 = greyScale.GetPixel(i + 1, j - 1).R;
                        int p8 = greyScale.GetPixel(i + 1, j).R;
                        int p9 = greyScale.GetPixel(i + 1, j + 1).R;
                        var Gx = Math.Abs(p2 + p4 + p6 + p8 + (-4 * p5));

                        if (Gx > laplaceThreshold)
                            sobleBitMap.SetPixel(i, j, Color.White);
                        else
                            sobleBitMap.SetPixel(i, j, Color.Black);
                    }
                    if (progress != null)
                        progress.Report((i) * 100 / greyScale.Width);
                }
                progress.Report(100);
            });

            OutputFormcs outputForm = new OutputFormcs();
            outputForm.LoadPicture(sobleBitMap);
            outputForm.Height = sobleBitMap.Height + 50;
            outputForm.Width = sobleBitMap.Width + 50;
            outputForm.Show();

        }
        private async void btnPrewitt_Click(object sender, EventArgs e)
        {
            if (pictInput.Image == null)
            {
                MessageBox.Show("First enter an image");
                return;
            }
            LoadConstants();
            prgLoader.Maximum = 100;
            prgLoader.Step = 1;
            prgLoader.Value = 0;
            System.IProgress<int> progress = new Progress<int>(v =>
            {
                prgLoader.Value = v;
            });

            Bitmap greyScale = GreyScale(new Bitmap(pictInput.Image));



            var sobleBitMap = new Bitmap(greyScale.Width, greyScale.Height);
            await Task.Run(() =>
            {
                for (int i = 3; i < greyScale.Width - 3; i++)
                {
                    for (int j = 3; j < greyScale.Height - 3; j++)
                    {
                        int p1 = greyScale.GetPixel(i - 1, j - 1).R;
                        int p2 = greyScale.GetPixel(i - 1, j).R;
                        int p3 = greyScale.GetPixel(i - 1, j + 1).R;
                        int p4 = greyScale.GetPixel(i, j - 1).R;
                        int p5 = greyScale.GetPixel(i, j).R;
                        int p6 = greyScale.GetPixel(i, j + 1).R;
                        int p7 = greyScale.GetPixel(i + 1, j - 1).R;
                        int p8 = greyScale.GetPixel(i + 1, j).R;
                        int p9 = greyScale.GetPixel(i + 1, j + 1).R;
                        var Gx = Math.Abs(p6 + p7 + p8 - p1 - p2 - p3);
                        var Gy = Math.Abs(p3 + p6 + p9 - p1 - p4 - p7);
                        var Gdl = Math.Abs(p4 + p7 + p8 - p2 - p3 - p6);
                        var Gdr = Math.Abs(p6 + p8 + p9 - p1 - p2 - p4);
                        if (Gx + Gy + Gdl + Gdr > prewittThreshold)
                            sobleBitMap.SetPixel(i, j, Color.White);
                        else
                            sobleBitMap.SetPixel(i, j, Color.Black);
                    }
                    if (progress != null)
                        progress.Report((i) * 100 / greyScale.Width);
                }
                progress.Report(100);
            });

            OutputFormcs outputForm = new OutputFormcs();
            outputForm.LoadPicture(sobleBitMap);
            outputForm.Height = sobleBitMap.Height + 50;
            outputForm.Width = sobleBitMap.Width + 50;
            outputForm.Show();
        }
        private async void btnSobel_Click(object sender, EventArgs e)
        {
            if (pictInput.Image == null)
            {
                MessageBox.Show("First enter an image");
                return;
            }
            LoadConstants();
            prgLoader.Maximum = 100;
            prgLoader.Step = 1;
            prgLoader.Value = 0;
            System.IProgress<int> progress = new Progress<int>(v =>
            {
                prgLoader.Value = v;
            });

            Bitmap greyScale = GreyScale(new Bitmap(pictInput.Image));
            //apply sobel filter
            //Gx            Gy
            //- 1  0  + 1     + 1 + 2 + 1
            //- 2  0  + 2       0   0   0
            //- 1  0  + 1     - 1 - 2 - 1

            var sobleBitMap = new Bitmap(greyScale.Width, greyScale.Height);
            await Task.Run(() =>
            {
                for (int i = 3; i < greyScale.Width - 3; i++)
                {
                    for (int j = 3; j < greyScale.Height - 3; j++)
                    {
                        int p1 = greyScale.GetPixel(i - 1, j - 1).R;
                        int p2 = greyScale.GetPixel(i - 1, j).R;
                        int p3 = greyScale.GetPixel(i - 1, j + 1).R;
                        int p4 = greyScale.GetPixel(i, j - 1).R;
                        int p5 = greyScale.GetPixel(i, j).R;
                        int p6 = greyScale.GetPixel(i, j + 1).R;
                        int p7 = greyScale.GetPixel(i + 1, j - 1).R;
                        int p8 = greyScale.GetPixel(i + 1, j).R;
                        int p9 = greyScale.GetPixel(i + 1, j + 1).R;
                        var Gx = Math.Abs(p1 + (2 * p2) + p3 - p7 - (2 * p6) - p5);
                        var Gy = Math.Abs(p3 + (2 * p4) + p5 - p1 - (2 * p8) - p7);
                        if (Gx + Gy > sobelThreshold)
                            sobleBitMap.SetPixel(i, j, Color.White);
                        else
                            sobleBitMap.SetPixel(i, j, Color.Black);
                    }
                    if (progress != null)
                        progress.Report((i) * 100 / greyScale.Width);
                }
                progress.Report(100);
            });

            OutputFormcs outputForm = new OutputFormcs();
            outputForm.LoadPicture(sobleBitMap);
            outputForm.Height = sobleBitMap.Height + 50;
            outputForm.Width = sobleBitMap.Width + 50;
            outputForm.Show();
        }

        private Bitmap GreyScale(Bitmap image)
        {
            var returnedBitMap = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    var pixel = image.GetPixel(i, j);
                    var newPixel = Color.FromArgb(pixel.R, pixel.R, pixel.R);
                    returnedBitMap.SetPixel(i, j, newPixel);
                }
            return returnedBitMap;
        }


    }
}
