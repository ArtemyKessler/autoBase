using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBase
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void RidersBtn_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
           // this.e
        }

        private void CarsBtn_Click(object sender, EventArgs e)
        {
            CarsFrm cf = new CarsFrm();
            cf.ShowDialog();

        }

        private void VoyageBtn_Click(object sender, EventArgs e)
        {
            VoyageFrm vfr = new VoyageFrm();
            vfr.ShowDialog();
        }

        private void ListBtn_Click(object sender, EventArgs e)
        {
            ListForm lf = new ListForm();
            lf.ShowDialog();
        }
    }
}
