using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognition
{
    public partial class frmSetting : Form
    {
        private long _userID;
        public frmSetting(long userID)
        {
            InitializeComponent();
            this._userID = userID;
        }
        private void frmSetting_Load(object sender, EventArgs e)
        {
            txtServerName.Text = StaticPool.ServerName;

            ucUser1.LoadDataGridView();

            ucCamera1.LoadDataGridView();

            ucGroupFace1.LoadDataGridView();

            ucFacePerson2.LoadDataGridView();
            ucFacePerson2.getUserID(this._userID);

            ucFaceRecognize1.loadCameraChannel();
            ucFaceRecognize1.loadDataGridView();
            Ping pingSender = new Ping();
            PingReply reply = null;
            reply = pingSender.Send(StaticPool.ServerName, 1000);
            if (reply != null && reply.Status == IPStatus.Success)
            {
                ucGroupFace1.setToostipEnable(true);
                ucFacePerson2.setToostipEnable(true);
            }
            else
            {
                ucGroupFace1.setToostipEnable(false);
                ucFacePerson2.setToostipEnable(false);
            }
        }
    }
}
