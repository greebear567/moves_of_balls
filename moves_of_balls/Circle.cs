using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace moves_of_balls
{
    public class Circle
    {
        private Point _pos;
        private int _diameter;
        private int _dx;
        private int _dy;
        private int num;
        private Size _containerSize;
        private Thread? t;
        private Vector direction;
        private Point startPos;
 
        public bool IsAlive => t?.IsAlive == true;
        public Color Color { get; set; }



        public Circle(Size containerSize, Point pos)
        {
            Random some = new Random();
            num = some.Next(3, 10);
            startPos = pos;
            _pos = new Point(pos.X,pos.Y);
            Color = Color.Blue;
            direction = new Vector(pos);
            _diameter = some.Next(20,100);
            _dx = (int)(direction.x/100)+2;
            _dy = (int)(direction.y/100)+2;
            _containerSize = containerSize;
        }

        public void Paint(Graphics g)
        {
            var b = new SolidBrush(Color);
            g.FillEllipse(b, _pos.X, _pos.Y, _diameter, _diameter);
        }

        public bool Move()
        {
            //if ((_pos.X < _containerSize.Width - _diameter && _pos.Y < _containerSize.Height - _diameter) ||
            //    (_pos.X-_diameter < 0) ||
            //    (_pos.X < _containerSize.Width - _diameter && _pos.Y - _diameter < 0) ||
            //    (_pos.X - _diameter< 0 && _pos.Y - _diameter < 0) 
            //    )
            if ((_pos.X<startPos.X % Math.Abs(_dx)) || _pos.X>_containerSize.Width-_diameter || _pos.Y< Math.Abs(_dy) || _pos.Y>_containerSize.Height-_diameter)
            {
                if (num == 0)
                return false;
                num -= 1;
                if (_pos.X < startPos.X % Math.Abs(_dx) || _pos.X > _containerSize.Width - _diameter)
                _dx = -_dx;
                if (_pos.Y < Math.Abs(_dy) || _pos.Y > _containerSize.Height - _diameter)
                _dy = -_dy;
                _pos.X += _dx;
                _pos.Y += _dy;
                return true;
            }
            else
            {
                _pos.X += _dx;
                _pos.Y += _dy;
                return true;
            }

        }

        public void Animate()
        {
            if (!t?.IsAlive ?? true)
            {
                t = new Thread(() =>
                {
                    do
                    {
                        Thread.Sleep(30);
                    } while (Move());
                });
                t.IsBackground = true;
                t.Start();
            }
        }

        public void Clear(Graphics g)
        {
            var b = new SolidBrush(Color.White);
            g.FillEllipse(b, _pos.X, _pos.Y, _diameter, _diameter);
        }
    }
}
