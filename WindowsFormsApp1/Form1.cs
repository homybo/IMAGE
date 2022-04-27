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
            //pictureBox1.Image = Image.FromFile(@"../../cyber.jpg");
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
        }
    }
}
