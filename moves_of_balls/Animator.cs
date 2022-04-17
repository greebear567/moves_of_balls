﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace moves_of_balls
{
    public class Animator
    {
        //public Animator()
         private Size cSize;
        private BufferedGraphics bg;
        private Graphics _g;
        private Graphics g
        {
            get => _g;
            set
            {
                _g = value;
                bg = BufferedGraphicsManager.Current.Allocate(
                    g, Rectangle.Ceiling(g.VisibleClipBounds)
                );
                bg.Graphics.Clear(Color.White);
            }
        }

        private List<Circle> circs = new();
        public Animator(Size containerSize, Graphics g)
        {
            cSize = containerSize;
            this.g = g;
        }

        public void AddCircle(Point pos)
        {
            var c = new Circle(cSize, pos);
            c.Animate(_g);
            circs.Add(c);
        }
        public void Start()
        {
            Thread t = new Thread(() =>
            {
                Graphics tg;
                lock (bg)
                {
                    tg = bg.Graphics;
                }
                do
                {
                    tg.Clear(Color.White);
                    for (int i = 0; i < circs.Count; i++)
                    {
                        circs[i].Paint(tg);
                        if (circs[i].num == 0)
                        {
                            circs[i].Clear(tg);
                        }
                    }
                    bg.Render(g);
                    Thread.Sleep(30);
                } while (true);

            });
            t.Start();
        }
    }
}
