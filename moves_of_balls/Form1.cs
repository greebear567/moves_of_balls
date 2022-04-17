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
            a.AddCircle(e.Location);
        }
    }
}
