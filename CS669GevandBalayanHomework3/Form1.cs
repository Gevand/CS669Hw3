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
        int robertsThreshold = 50;
        int kirshThreshold = 50;
        int robinsonThreshold = 20;
        public Form1()
        {
            InitializeComponent();
            txtCannyThreshold.Text = cannyThresHold.ToString();
            txtSobelThreshold.Text = sobelThreshold.ToString();
            txtPrewittThreshold.Text = prewittThreshold.ToString();
            txtLaplaceThreshold.Text = laplaceThreshold.ToString();
            txtRobertsThreshold.Text = robertsThreshold.ToString();
            txtRobinsonThreshold.Text = robinsonThreshold.ToString();
            txtKirshThreshold.Text = kirshThreshold.ToString();
        }


        #region Helpers
        private void LoadConstants()
        {
            int.TryParse(txtCannyThreshold.Text, out cannyThresHold);
            int.TryParse(txtSobelThreshold.Text, out sobelThreshold);
            int.TryParse(txtPrewittThreshold.Text, out prewittThreshold);
            int.TryParse(txtLaplaceThreshold.Text, out laplaceThreshold);
            int.TryParse(txtRobertsThreshold.Text, out robertsThreshold);
            int.TryParse(txtRobinsonThreshold.Text, out robinsonThreshold);
            int.TryParse(txtKirshThreshold.Text, out kirshThreshold);
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
        private int[,] GreyScaleArray(Bitmap image)
        {
            var returneRay = new int[image.Width, image.Height];

            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    var pixel = image.GetPixel(i, j);
                    returneRay[i, j] = pixel.R;
                }
            return returneRay;
        }

        private int[,] Digitize(int[,] input)
        {
            var returnedArray = new int[input.GetLength(0), input.GetLength(1)];
            for (int i = 2; i < input.GetLength(0); i++)
                for (int j = 2; j < input.GetLength(1); j++)
                {
                    returnedArray[i, j] = (-1 * input[i, j]) + (-4 * input[i, j]) + (-7 * input[i, j]) + (-4 * input[i, j]) + (-1 * input[i, j])
                                        + (-4 * input[i, j]) + (-16 * input[i, j]) + (-26 * input[i, j]) + (-16 * input[i, j]) + (-4 * input[i, j])
                                        + (-7 * input[i, j]) + (-26 * input[i, j]) + (41 * input[i, j]) + (-26 * input[i, j]) + (-7 * input[i, j])
                                        + (-4 * input[i, j]) + (-16 * input[i, j]) + (-26 * input[i, j]) + (-16 * input[i, j]) + (-4 * input[i, j])
                                        + (-1 * input[i, j]) + (-4 * input[i, j]) + (-7 * input[i, j]) + (-4 * input[i, j]) + (-1 * input[i, j])
                                                             ;
                    returnedArray[i, j] = Math.Abs((returnedArray[i, j] + 137) / 273);
                }
            return input;
        }
        private int[,] Canny(int[,] input, IProgress<int> progress)
        {
            var returnedArray = new int[input.GetLength(0), input.GetLength(1)];
            var grads = new int[input.GetLength(0), input.GetLength(1)];
            var visited = new int[input.GetLength(0), input.GetLength(1)];
            var theta = new double[input.GetLength(0), input.GetLength(1)];
            for (int i = 2; i < input.GetLength(0) - 1; i++)
                for (int j = 2; j < input.GetLength(1) - 1; j++)
                {
                    int p1 = input[i - 1, j - 1];
                    int p2 = input[i - 1, j];
                    int p3 = input[i - 1, j + 1];
                    int p4 = input[i, j - 1];
                    int p5 = input[i, j];
                    int p6 = input[i, j + 1];
                    int p7 = input[i + 1, j - 1];
                    int p8 = input[i + 1, j];
                    int p9 = input[i + 1, j + 1];
                    var x = Math.Abs(p1 + (2 * p2) + p3 - p7 - (2 * p6) - p5);
                    var y = Math.Abs(p3 + (2 * p4) + p5 - p1 - (2 * p8) - p7);
                    theta[i, j] = Math.Round(((Math.Atan2(y, x) * (5.0 / Math.PI)) + 5) % 5);
                    grads[i, j] = (int)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                }
            var definitely = new List<Tuple<int, int, double>>();
            var maybe = new List<Tuple<int, int, double>>();
            var nots = new List<Tuple<int, int, double>>();
            for (int i = 2; i < input.GetLength(0) - 1; i++)
                for (int j = 2; j < input.GetLength(1) - 1; j++)
                {
                    var qtr = theta[i, j] % 4;
                    switch (qtr)
                    {
                        case 0:
                            if (theta[i, j] <= theta[i, j - 1] || theta[i, j] <= theta[i, j + 1])
                                grads[i, j] = 0;
                            break;
                        case 1:
                            if (theta[i, j] <= theta[i - 1, j + 1] || theta[i, j] <= theta[i + 1, j - 1])
                                grads[i, j] = 0;
                            break;
                        case 2:
                            if (theta[i, j] <= theta[i - 1, j] || theta[i, j] <= theta[i + 1, j])
                                grads[i, j] = 0;
                            break;
                        case 3:
                            if (theta[i, j] <= theta[i - 1, j - 1] || theta[i, j] <= theta[i + 1, j + 1])
                                grads[i, j] = 0;
                            break;
                        default:
                            break;
                    }

                    if (grads[i, j] != 0)
                        maybe.Add(new Tuple<int, int, double>(i, j, grads[i, j]));
                }
            maybe = maybe.OrderByDescending(t => t.Item3).ToList();
            int threshold = (int)(maybe.Count * .1);
            definitely = maybe.Where(t => t.Item3 >= cannyThresHold).Select(t => new Tuple<int, int, double>(t.Item1, t.Item2, t.Item3)).ToList();
           // definitely = maybe.Take(threshold).Select(t => new Tuple<int, int, double>(t.Item1, t.Item2, t.Item3)).ToList();
            nots = maybe.Skip(Math.Max(0, maybe.Count() - threshold)).ToList();
            maybe = maybe.Except(definitely).Except(nots).ToList();

            foreach (var def in definitely)
            {
                returnedArray[def.Item1, def.Item2] = 1;
                //visited[def.Item1, def.Item2] = 1;
            }

            foreach (var may in maybe)
                returnedArray[may.Item1, may.Item2] = 2;

            var count = 0;
            bool start = true;
            while (start)
            {
                start = false;
                for (int i = 0; i < input.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < input.GetLength(1) - 1; j++)
                    {
                        count++;
                        if (returnedArray[i, j] == 1 && visited[i, j] != 1)
                        {
                            returnedArray[i, j] = 1;
                            Traverse(ref returnedArray, ref visited, i, j);
                            visited[i, j] = 1;
                        }
                        if (progress != null)

                            progress.Report((count) * 100 / input.GetLength(0) * input.GetLength(1));
                    }
                    if (start)
                        break;
                }
            }


            progress.Report(100);

            return returnedArray;
        }

        void Traverse(ref int[,] returnedArray, ref int[,] visited, int i, int j)
        {
            if (returnedArray[i, j] == 1 && visited[i, j] != 1)
            {
                visited[i, j] = 1;
                if (returnedArray[i - 1, j - 1] == 2)
                {
                    visited[i - 1, j - 1] = 1;
                    returnedArray[i - 1, j - 1] = 1;
                    Traverse(ref returnedArray, ref visited, i - 1, j - 1);
                    return;

                }
                if (returnedArray[i - 1, j] == 2)
                {
                    visited[i - 1, j] = 1;
                    returnedArray[i - 1, j] = 1;
                    Traverse(ref returnedArray, ref visited, i - 1, j);
                    return;
                }
                if (returnedArray[i - 1, j + 1] == 2)
                {
                    visited[i - 1, j + 1] = 1;
                    returnedArray[i - 1, j + 1] = 1;
                    Traverse(ref returnedArray, ref visited, i - 1, j + 1);
                    return;

                }

                if (returnedArray[i + 1, j - 1] == 2)
                {
                    visited[i + 1, j - 1] = 1;
                    returnedArray[i + 1, j - 1] = 1;
                    Traverse(ref returnedArray, ref visited, i + 1, j - 1);
                    return;

                }
                if (returnedArray[i + 1, j] == 2)
                {
                    visited[i + 1, j] = 1;
                    returnedArray[i + 1, j] = 1;
                    Traverse(ref returnedArray, ref visited, i + 1, j);
                    return;

                }
                if (returnedArray[i + 1, j + 1] == 2)
                {
                    visited[i - 1, j + 1] = 1;
                    returnedArray[i + 1, j + 1] = 1;
                    Traverse(ref returnedArray, ref visited, i + 1, j + 1);
                    return;


                }
                if (returnedArray[i, j - 1] == 2)
                {
                    visited[i, j - 1] = 1;
                    returnedArray[i, j - 1] = 1;
                    Traverse(ref returnedArray, ref visited, i, j - 1);
                    return;

                }
                if (returnedArray[i, j + 1] == 2)
                {
                    visited[i, j + 1] = 1;
                    returnedArray[i, j + 1] = 1;
                    Traverse(ref returnedArray, ref visited, i, j + 1);
                    return;

                }



            }
        }
        #endregion

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
        #region Canny
        private async void btnCanny_Click(object sender, EventArgs e)
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


            int[,] tempArray = GreyScaleArray(new Bitmap(pictInput.Image));
            //step 1 digitize
            tempArray = Digitize(tempArray);

            System.IProgress<int> progress = new Progress<int>(v =>
            {
                if (v <= 100)
                    prgLoader.Value = v;
            });

            var cannyBitMap = new Bitmap(pictInput.Image.Width, pictInput.Image.Height);

            await Task.Run(() =>
            {
                tempArray = Canny(tempArray, progress);

                for (int i = 3; i < cannyBitMap.Width - 3; i++)
                {
                    for (int j = 3; j < cannyBitMap.Height - 3; j++)
                    {
                        if (tempArray[i, j] == 1)
                            cannyBitMap.SetPixel(i, j, Color.White);
                        else
                            cannyBitMap.SetPixel(i, j, Color.Black);
                    }

                }
            });
            OutputFormcs outputForm = new OutputFormcs();
            outputForm.LoadPicture(cannyBitMap);
            outputForm.Height = cannyBitMap.Height + 50;
            outputForm.Width = cannyBitMap.Width + 50;
            outputForm.Show();
        }


        #endregion
        #region Basic Edge Detection Algorithms
        private async void btnKirsh_Click(object sender, EventArgs e)
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
                        var Gx = Math.Abs((-5 * (p1 + p3 + p5)) + (3 * (p2 + p3 + p6 + p7 + p8)));
                        if (Gx > kirshThreshold)
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
        private async void btnRobinson_Click(object sender, EventArgs e)
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
                        var Gx = Math.Abs(p1 + p2 + p3 + p4 + p6 - p7 - p8 - p9 + (-2 * p5));
                        if (Gx > robinsonThreshold)
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

        private async void btnRoberts_Click(object sender, EventArgs e)
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
                        int p3 = greyScale.GetPixel(i, j - 1).R;
                        int p4 = greyScale.GetPixel(i, j).R;

                        var Gx = Math.Abs(p1 - p4);
                        var Gy = Math.Abs(p2 - p3);

                        if (Gx + Gy > robertsThreshold)
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
        #endregion



    }
}
