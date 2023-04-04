using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DrawingLightning
{
    public partial class Form1 : Form
    {
        LinkedList<Point> points;
        LightLine Main;
        int x = 0;
        Random rnd;
        public Form1()
        {
            InitializeComponent();
            initilization();
        }

        public void initilization()
        {
            points = new LinkedList<Point>();
            
            Thread t = new Thread(new ThreadStart(gameLoop));
            t.Start();
            rnd = new Random((int)DateTime.Now.Ticks);

        }

        private void gameLoop()
        {


           
            while (true)
            {
                GameLogic();
                Thread.Sleep(100);
                this.Invalidate();
            }
        }


        int tick = 0;
        private void GameLogic()
        {
           // rnd = new Random(DateTime.Now.Millisecond);
            Random rand = new Random((int)DateTime.Now.Ticks);
            LightLine current = new LightLine(new Point(100, 100));
           // dis += dis * 10/ rand.Next(-3, 3);
            current.Next = new LightLine(new Point(100, 200));
            
            
            //MessageBox.Show(rand.Next(-50, 50).ToString());
            Main = current;

            for (int i = 1; i <= 6; i++)
            {

                current = Main;
                while (current != null)
                {
                    if (current.Next == null)
                    {
                        current = current.Next;

                    }
                    else
                    {
                        int avgx, avgy;
                        avgx = current.value.X + current.Next.value.X;
                        avgx /= 2;
                        avgy = current.value.Y + current.Next.value.Y;
                        avgy /= 2;
                        LightLine temp = current.Next;
                        int displacement = rand.Next(-3 * (6 - i) + (3 * (6 - i) / i), 3 * (6 - i) - (3 * (6 - i) / i));
                        LightLine Insert = new LightLine(new Point(avgx + displacement, avgy));
                        current.Next = Insert;
                        Insert.Next = temp;
                        current = temp;
                    }
                }
            }
        }



        private void DivideLines()
        {
            Point Start = new Point(100, 100);
            Point End = new Point(100, 200);
            Point current;

            int depth = 5;
            while (depth > 0)
            {
                foreach (Point p in points)
                {

                }
            }
        }

        private void PaintLogic(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //Color c = Color.FromArgb(255, 255, 255, 255);
            //Brush b = new SolidBrush(c);
           // Pen p = new Pen(b);
            x += (int)1;
            rnd = new Random((int)DateTime.Now.Ticks);
            //g.DrawLine(new Pen(b), 100 + rnd.Next(-50, 50), 100, 100, 200);

            tick++;

            if (tick > 2)
            {
                tick = 0;
                return;
            }

            LightLine current = Main;
            while (current != null)
            {
                if (current.Next != null)
                {

                  //  for (int i = 1; i <= 3; i++)
                  //  {
                        Color c = Color.FromArgb(75, 255, 255, 255);
                       
                        Pen d = new Pen(c, 2.5F);
                        
                        g.DrawLine(d, current.value, current.Next.value);
                    /////////////////////////////////////////////////////

                        /////////////////////////////////////////////////////
                        c = Color.FromArgb(125, 255, 255, 255);

                        d = new Pen(c, 1);

                        g.DrawLine(d, current.value, current.Next.value);
                  //  }
                }
                current = current.Next;
            }

            foreach (Point p in points)
            {
            
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            PaintLogic(e);
        }
    }
}
