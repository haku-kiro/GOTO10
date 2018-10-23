using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// If you just comment out one of the lines, it draws rain :P
/// </summary>
namespace thatThingForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Setting window size
            int width = 1920;
            int height = 1080;
            this.Size = new Size(width, height);

            //To Start fullscreen
            WindowState = FormWindowState.Maximized;

            System.Drawing.Graphics graphics;
            graphics = this.CreateGraphics();

            int lineSize = 20;
            int level = 0;
            int count = 0;
            int levelCount = 0;
            Random rand = new Random(42);


            Pen pen = new Pen(System.Drawing.Color.Black, 2);

            //Half screen for testing (levelCount < ((height/lineSize) /2))

            while (levelCount <= (height/lineSize))
            {
                //You were last checking why there are straight lines and if you should div/ or mod (Check how to make sure you return the right value)
                if (!((count + 1) < (width / lineSize)))
                {
                    levelCount = ((lineSize + count * lineSize) / lineSize) / (width / lineSize);
                    level = lineSize * levelCount;
                }

                //Create the line
                if (rand.Next(0, 2) == 1)
                {
                    //Would be better if you just had an x, y and reset it at parts
                    graphics.DrawLine(pen, ((count * lineSize) - width * levelCount), lineSize + level, lineSize + ((count * lineSize) - width * levelCount), level); // /
                }
                else
                {
                    graphics.DrawLine(pen, (count * lineSize) - width * levelCount, level, (lineSize + count * lineSize) - width * levelCount, lineSize + level); // \
                }
                count++;
                //System.Threading.Thread.Sleep(10); //Can remove, just for buildup
            }

            //graphics.DrawLine(pen, 0, 20, 20, 0); // draws / (start here)
            //graphics.DrawLine(pen, 20, 20, 40, 0); // draws / (one right)
            //graphics.DrawLine(pen, 0, 40, 20, 20); // draws / (one down)


            //graphics.DrawLine(pen, 0, 0, 20, 20); // draws \ (or here)
            //graphics.DrawLine(pen, 20, 0, 40, 20); // draws \ (one right)
            //graphics.DrawLine(pen, 0, 20, 20, 40); // draws \ (one down)
        }
    }
}
