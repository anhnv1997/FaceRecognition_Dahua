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
    public partial class ucEventWithCandidate : UserControl
    {
        private string personID;
        public ucEventWithCandidate()
        {
            InitializeComponent();
        }
        public Image FaceImage
        {           
            set
            {
                picFaceImage.Image = value;
            }
        }
        public Image CandidateImage
        {
            
            set
            {
                picCandidateImage.Image = value;
            }
        }
        public string PersonName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }
        public string GroupName
        {
            get
            {
                return txtGroupName.Text;
            }
            set
            {
                txtGroupName.Text = value;
            }
        }
        public string Position
        {
            get
            {
                return txtPosition.Text;
            }
            set
            {
                txtPosition.Text = value;
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
        private string birthday;
        private string cardType;
        private string cardID;
    
        public string Beard
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

        public string Mask
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

        public string Birthday { get => birthday; set => birthday = value; }
        public string CardType { get => cardType; set => cardType = value; }
        public string CardID { get => cardID; set => cardID = value; }
        public string PersonID { get => this.Name; set => this.Name = value; }

        private void ucEventWithCandidate_Load(object sender, EventArgs e)
        {

        }
    }
}
