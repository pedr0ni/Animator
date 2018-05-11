using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animator
{
    public partial class Example : Form
    {
        public Example()
        {
            InitializeComponent();

        }

        private void btn_animate_Click(object sender, EventArgs e)
        {
            Animator anim = new Animator(this.btn_animate);
            anim.setAnimationType(AnimationType.SCROLL);
            anim.setVelocity(1000);
            anim.setToCoordinates(597, 12);
            anim.start();
        }
    }
}
