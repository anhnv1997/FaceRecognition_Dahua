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
    public partial class frmSelectDisplayMode : Form
    {
        private int SelectionMode;
        private const int MODE_FACE = 0;
        private const int MODE_VEHICLE = 1;
        private const int MODE_FACEandVEHICLE = 2;
        private Color SelectionColor = Color.Green;
        private Color UnselectColor = Color.White;
        private bool isFaceMode = false;
        private bool isVehicleMode = false;
        public frmSelectDisplayMode()
        {
            InitializeComponent();            
        }

        private void frmSelectDisplayMode_Load(object sender, EventArgs e)
        {
            switch (StaticPool.CurrentDisplayMode)
            {
                case MODE_FACE:
                    boderFaceMode.BackColor = SelectionColor;
                    boderVehicleMode.BackColor = UnselectColor;
                    isFaceMode = true;
                    break;
                case MODE_VEHICLE:
                    boderFaceMode.BackColor = UnselectColor;
                    boderVehicleMode.BackColor = SelectionColor;
                    isVehicleMode = true;
                    break;
                case MODE_FACEandVEHICLE:
                    boderFaceMode.BackColor = SelectionColor;
                    boderVehicleMode.BackColor = SelectionColor;
                    isFaceMode = true;
                    isVehicleMode = true;
                    break;
            }
        }

        private void picFaceMode_Click(object sender, EventArgs e)
        {
            ChangeBoderColor(ref isFaceMode, boderFaceMode);
        }

        private void picVehicleMode_Click(object sender, EventArgs e)
        {
            ChangeBoderColor(ref isVehicleMode, boderVehicleMode);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isFaceMode == true && isVehicleMode == false)
            {
                Properties.Settings.Default.CurrentDisplayMode = MODE_FACE;
                Properties.Settings.Default.Save();
            }
            else if(isFaceMode == false && isVehicleMode == true)
            {
                Properties.Settings.Default.CurrentDisplayMode = MODE_VEHICLE;
                Properties.Settings.Default.Save();
            }
            else if (isFaceMode == true && isVehicleMode == true)
            {
                Properties.Settings.Default.CurrentDisplayMode = MODE_FACEandVEHICLE;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Please select 1 mode to display");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
        private void ChangeBoderColor(ref bool selectionMode,Panel panel)
        {
            if (selectionMode)
            {
                panel.BackColor = UnselectColor;
            }
            else
            {
                panel.BackColor = SelectionColor;
            }
            selectionMode = !selectionMode;
        }
    }
}
