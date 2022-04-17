using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace moves_of_balls
{
    public partial class Form1 : Form
    {
        private Animator a;
        public Form1()
        {
            InitializeComponent();
            a = new Animator(panel1.Size, panel1.CreateGraphics());
            a.Start();
        }



        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Point some = new Point();
            some.X = e.X;
            some.Y = e.Y;
            if (e.X < 100 )
            {
                some.X = 100;
            } 
            if ( e.Y < 100)
            {
                some.Y = 100;
            }
            if(e.X > panel1.Size.Width - 100)
            {
                some.X = panel1.Size.Width - 100;
            }
            if (e.Y > panel1.Size.Height - 100)
            {
                some.Y = panel1.Size.Height - 100;
            }
            a.AddCircle(some);
        }
    }
}
