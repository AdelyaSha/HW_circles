using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace HW_circles
{
    public class Animator
    {
        private Random r = new();
        private static List<Circle> circles = new List<Circle>();
        private Circle c;
        private Thread t;
        private int dirX;
        private int dirY;
        private bool isAlive;
        
        public Size ContainerSize { get; set; }

        public Animator(Size containerSize)
        {
            ContainerSize = containerSize;
            c = new Circle(50, r.Next(containerSize.Width - 50), r.Next(containerSize.Height - 50));
            circles.Add(c);
        }

        public int genDir(int range)
        {
            int res;
            while (true)
            {
                res = r.Next(-range, range);
                if (res != 0) break;
            }
            return res;
        }

        public void Start()
        {
            isAlive = true;
            dirX = genDir(5);
            dirY = genDir(5);
            t = new Thread(() =>
            {
                while (isAlive)
                {
                    for (int i = 0; i < circles.Count; i++)
                    {
                        for (int j = 0; j < circles.Count; j++)
                        {
                            if (c.X <= 0 || c.X + c.Diam >= ContainerSize.Width) dirX = -dirX;
                            if (c.Y <= 0 || c.Y + c.Diam >= ContainerSize.Height) dirY = -dirY;
                            Thread.Sleep(30);
                            c.Move(dirX, dirY);
                            /*if (i != j &&  2500 >= Math.Pow((circles[i].Center_X - circles[j].Center_X), 2) + Math.Pow((circles[i].Center_Y - circles[j].Center_Y), 2))
                            {
                                
                                
                            }*/
                            
                        }

                    }
                }

            });
            t.IsBackground = true;
            t.Start();
        }

        public void PaintCircle(Graphics g)
        {
            c.Paint(g);
        }

    }
}
