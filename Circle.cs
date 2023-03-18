using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_circles
{
    public class Circle
    {
        private Random r = new();
        private int diam;
        const double G = 9.8;
        private int x, y;
        private int rad;
        private int center_x;
        private int center_y;
        public int Center_X => center_x;
        public int Center_Y => center_y;
        public int Rad => rad;
        public int X { get; set; }
        public int Y { get; set; }
        public int Diam => diam;
        public Color Color { get; set; }

        private int v_x;

        public int V_x => v_x;

        private int v_y;

        public int V_y => v_y;

        public Circle(int diam, int x, int y, Color color)
        {
            this.diam = diam;
            this.x = x;
            this.y = y;
            this.Color = color;
            rad = diam / 2;
            center_x = x + rad;
            center_y = y - rad;
            v_x = (int)Math.Sqrt(2 * G * x);
            v_y = (int)Math.Sqrt(2 * G * y);
        }

        public Circle(int diam, int x, int y)
        {
            this.diam = diam;
            this.x = x;
            this.y = y;
            this.Color = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            rad = diam / 2;
            center_x = x + rad;
            center_y = y - rad;
            v_x = (int)Math.Sqrt(x);
            v_y = (int)Math.Sqrt(y);
        }

        public void Move(int dx, int dy)
        {
            x += dx;
            y += dy;
        }

        public void Paint(Graphics g)
        {
            var brush = new SolidBrush(Color);
            g.FillEllipse(brush, X, Y, Diam, Diam);
        }

    }
}
