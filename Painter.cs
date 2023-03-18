using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_circles
{
    public class Painter
    {
        private List<Animator> animators = new();
        private Size containerSize;
        private Thread t;
        private Graphics mainGraphics;
        private BufferedGraphics bg;

        private bool isAlive;

        public Graphics MainGraphics
        {
            get => mainGraphics;
            set
            {
                mainGraphics = value;
                ContainerSize = mainGraphics.VisibleClipBounds.Size.ToSize();
                bg = BufferedGraphicsManager.Current.Allocate(
                    mainGraphics, new Rectangle(new Point(0, 0), ContainerSize)
                );
            }
        }

        public Size ContainerSize
        {
            get => containerSize;
            set
            {
                containerSize = value;
                foreach (var a in animators)
                {
                    a.ContainerSize = containerSize;
                }
            }
        }

        public Painter(Graphics mainGraphics)
        {
            MainGraphics = mainGraphics;
        }

        public void AddNew()
        {
            var a = new Animator(ContainerSize);
            animators.Add(a);
            a.Start();
        }

        public void Start()
        {
            isAlive = true;
            t = new Thread(() =>
            {
                try
                {
                    while (isAlive)
                    {
                        bg.Graphics.Clear(Color.White);
                        foreach (var animator in animators)
                        {
                            animator.PaintCircle(bg.Graphics);
                            /*foreach (var a in animators)
                            {
                                if (a != animator){

                                }
                            }*/
                        }

                        bg.Render(MainGraphics);
                        try
                        {
                            if (isAlive) Thread.Sleep(30);
                        }
                        catch { }
                    }
                }
                catch { };


            });
            t.IsBackground = true;
            t.Start();
        }

        public void Stop()
        {
            isAlive = false;
            t.Interrupt();
        }

    }
}
