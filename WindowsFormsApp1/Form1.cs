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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            pictureBox1.Load(@"../../cyber.jpg");
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            Bitmap bmp = null;
            int w, h;

            bmp = new Bitmap(pictureBox1.Image);
            w = bmp.Width;
            h = bmp.Height;
            for(int y=0;y<h;y++)
            {
                for(int x=0;x<w;x++)
                {
                    var p = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(p.A, 255-p.R,255- p.G, 255-p.B));
                }
            }
            pictureBox2.Image = bmp;
            
        }

        private void BtnLoad2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.Title = "Choose";
            dia.Filter = "JPEG files|*.jpg";
            dia.InitialDirectory = "C:\\Users\\user\\source\repos\\WindowsFormsApp1\\WindowsFormsApp1";
            if (dia.ShowDialog()==DialogResult.OK)
            {
                MessageBox.Show(dia.FileName);
                pictureBox1.Load(dia.FileName);
            }
        }

        private void BtnChange2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = null;
            int w, h;
            bmp = new Bitmap(pictureBox1.Image);
            w = bmp.Width;
            h = bmp.Height;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Color p = bmp.GetPixel(x, y);
                    int avg = (int)(p.R *0.3+ p.G *0.6+ p.B*0.1);
                    bmp.SetPixel(x, y, Color.FromArgb(p.A,avg,avg,avg));
                }
            }
            pictureBox2.Image = bmp;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = null;
            int w, h;
            bmp = new Bitmap(pictureBox1.Image);
            w = bmp.Width;
            h = bmp.Height;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Color p = bmp.GetPixel(x, y);
                    int R = (int)(p.R * 1.2) >= 255 ? 255 : (int)(p.R * 1.2);
                    int G = (int)(p.G * 1.2) >= 255 ? 255 : (int)(p.G * 1.2);
                    int B = (int)(p.B * 1.2) >= 255 ? 255 : (int)(p.B * 1.2);
                    bmp.SetPixel(x, y, Color.FromArgb(p.A,R,G,B));
                }
            }

            pictureBox2.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Bitmap bmp = null;
            int w, h;
            bmp = new Bitmap(pictureBox1.Image);
            w = bmp.Width;
            h = bmp.Height;
            for (int y = 0; y < h-10; y+=10)
            {
                for (int x = 0; x < w-10; x+=10)
                {
                    Color p = bmp.GetPixel(x, y);
                    for (int i =0;i<10;i++)
                    {
                        for(int j=0;j<10;j++)
                        {
                            bmp.SetPixel(x + i, y + j, p);
                        }
                    }
                }
            }
            pictureBox2.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = null;
            int w, h;
            bmp = new Bitmap(pictureBox1.Image);
            w = bmp.Width;
            h = bmp.Height;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Color p = bmp.GetPixel(x, y);
                    int avg = (int)(p.R * 0.3 + p.G * 0.6 + p.B * 0.1);
                    bmp.SetPixel(x, y, Color.FromArgb(p.A, avg, avg, avg));
                }
            }
            
            pictureBox2.Image = bmp;
            Bitmap bmp1 = new Bitmap(pictureBox2.Image);
            for (int y = 10; y < h - 10; y++)
            {
                for (int x = 10; x < w - 10; x++)
                {
                    int total = 0;
                    int avg = 0;
                    int a = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            Color p = bmp1.GetPixel(x + i, y + j);
                            a = p.A;
                            total += p.R;
                        }
                        avg = (int)(total / 100);
                    }
                    bmp1.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            }
            pictureBox3.Image = bmp1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox2.Image = bmp;
            Bitmap bmp1 = new Bitmap(pictureBox1.Image);
            bmp1.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox3.Image = bmp1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bmp = null;
            int w, h;
            bmp = new Bitmap(pictureBox1.Image);
            w = bmp.Width;
            h = bmp.Height;
            for (int y = 0; y < h-1; y++)
            {
                for (int x = 0; x < w-1; x++)
                {
                    Color p = bmp.GetPixel(x, y);
                    Color p2 = bmp.GetPixel(x + 1, y + 1);
                    int r = (p.R - p2.R + 128) >= 255 ? 255 : (p.R - p2.R + 128);
                    if (r < 0) r = 0;
                    int g = (p.G - p2.G + 128) >= 255 ? 255 : (p.G - p2.G + 128);
                    if (g < 0) g = 0;
                    int b = (p.B - p2.B + 128) >= 255 ? 255 : (p.B - p2.B + 128);
                    if (b < 0) b = 0;

                    bmp.SetPixel(x, y, Color.FromArgb(r,g,b));
                }
            }
            pictureBox2.Image = bmp;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bmp = null;
            int w, h;
            bmp = new Bitmap(pictureBox1.Image);
            w = bmp.Width;
            h = bmp.Height;
            for (int y = 0; y < h - 1; y++)
            {
                for (int x = 0; x < w - 1; x++)
                {
                    Color p = bmp.GetPixel(x, y);
                    int r = p.R >= 128 ? 255 : 0;
                    int g = p.R >= 128 ? 255 : 0;
                    int b = p.R >= 128 ? 255 : 0;
                    bmp.SetPixel(x, y, Color.FromArgb(r,g,b));
                }
            }
            pictureBox2.Image = bmp;


        }
    }
}
