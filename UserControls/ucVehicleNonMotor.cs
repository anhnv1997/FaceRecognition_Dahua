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
    public partial class ucVehicleNonMotor : UserControl
    {
        public ucVehicleNonMotor()
        {
            InitializeComponent();
        }
        public string Color
        {
            get { return txtColor.Text; }
            set { txtColor.Text = value; }
        }
        public Image GlobalImage
        {
            get { return PicGlobal.Image; }
            set { PicGlobal.Image = value; }
        }
        public Image VehicleImage
        {
            get { return PicVehicle.Image; }
            set { PicVehicle.Image = value; }
        }
    }
}
