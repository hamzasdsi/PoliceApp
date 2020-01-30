using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PoliceApp
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            progressBar1.Increment(1);
            if (progressBar1.Value == progressBar1.Maximum)
            {
                frmLogin frm = new frmLogin();
                timer1.Stop();
                this.Hide();
              frm.Show();

            }
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            progressBar1.Width = this.Width;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

    }
}
