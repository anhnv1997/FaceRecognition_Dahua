using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognition.Forms
{
    public partial class frmCheckInDialog : Form
    {
        public frmCheckInDialog()
        {
            InitializeComponent();

        }
        public void SetPersonName(string personName)
        {
            txtName.Text = personName;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmCheckInDialog_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
