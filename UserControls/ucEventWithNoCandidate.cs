using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognition.UserControls
{
    public partial class ucEventWithNoCandidate : UserControl
    {
        public ucEventWithNoCandidate()
        {
            InitializeComponent();
        }
        public string Time
        {
            get
            {
                return txtTime.Text;
            }
            set
            {
                txtTime.Text = value;
            }
        }
        public string Sex
        {
            get
            {
                return txtSex.Text;
            }
            set
            {
                txtSex.Text = value;
            }
        }
        public string Age
        {
            get
            {
                return txtAge.Text;
            }
            set
            {
                txtAge.Text = value;
            }
        }        
        public string mask
        {
            get
            {
                return txtMask.Text;
            }
            set
            {
                txtMask.Text = value;
            }
        }
        public string beard
        {
            get
            {
                return txtBeard.Text;
            }
            set
            {
                txtBeard.Text = value;
            }
        }
        public Image Image
        {
            set
            {
                pictureBox1.Image = value;
            }
        }

    }
}
