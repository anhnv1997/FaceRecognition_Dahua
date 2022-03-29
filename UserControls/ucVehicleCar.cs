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
    public partial class ucVehicleCar : UserControl
    {
        public ucVehicleCar()
        {
            InitializeComponent();
        }
        public Image GLobalImage
        {
            get { return picGlobal.Image; }
            set { picGlobal.Image = value; }
        }
        public Image VehicleImage
        {
            get { return picVehicle.Image; }
            set { picVehicle.Image = value; }
        }

        public string VehicleColor
        {
            get { return txtVehicleColor.Text; }
            set { txtVehicleColor.Text = value; }
        }
        public string VehicleType
        {
            get { return txtVehicleType.Text; }
            set { txtVehicleType.Text = value; }
        }
        public string PlateColor
        {
            get { return txtPlateColor.Text; }
            set { txtPlateColor.Text = value; }
        }

        public string PlateNo
        {
            get { return txtPlateNo.Text; }
            set { txtPlateNo.Text = value; }
        }

        public string SeatBelt
        {
            get { return txtSeatBelt.Text; }
            set { txtSeatBelt.Text = value; }
        }

        public string Calling
        {
            get { return txtCalling.Text; }
            set { txtCalling.Text = value; }
        }

        public string Smoking
        {
            get { return txtSmoking.Text; }
            set { txtSmoking.Text = value; }
        }
    }
}
