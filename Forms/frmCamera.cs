using FaceRecognition.Databases;
using FaceRecognition.Objects;
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
    public partial class frmCamera : Form
    {
        private string _ID;
        public frmCamera()
        {
            InitializeComponent();
        }
        public frmCamera(string ID)
        {
            InitializeComponent();
            cbCameraType.SelectedIndex = 0;
            cbCom.SelectedIndex = 0;
            cbChannel.SelectedIndex = 0;

            this._ID = ID;
            if (this._ID != "")
            {
                //Edit
                Camera camera = StaticPool.cams.GetCameraById(this._ID);
                txtID.Text = camera.Id;
                txtCameraCode.Text = camera.Code;
                txtCameraName.Text = camera.Name;
                cbCameraType.SelectedIndex = Convert.ToInt32(camera.Type.ToString());
                txtIP.Text = camera.IP;
                txtPort.Text = camera.Port.ToString();
                txtUsername.Text = camera.Username;
                txtPassword.Text = camera.Password;
                cbCom.SelectedIndex = Convert.ToInt32(camera.Com.ToString()) - 1;
                cbChannel.SelectedIndex = Convert.ToInt32(camera.Channel.ToString()) - 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCameraName.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("CameraNameEmpty", StaticPool.Language));
                return;
            }
            if (txtCameraCode.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("CameraCodeEmpty", StaticPool.Language));
                return;
            }
            if (cbCameraType.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("CameraTypeEmpty", StaticPool.Language));
                return;
            }
            if (txtIP.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("CameraIPEmpty", StaticPool.Language));
                return;
            }
            if (txtPort.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("CameraPortEmpty", StaticPool.Language));
                return;
            }
            if (txtUsername.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("CameraUsernameEmpty", StaticPool.Language));
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("CameraPasswordEmpty", StaticPool.Language));
                return;
            }
            if (cbCom.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("CameraComEmpty", StaticPool.Language));
                return;
            }
            if (cbChannel.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("CameraChannelEmpty", StaticPool.Language));
                return;
            }

            string Name = txtCameraName.Text;
            string Code = txtCameraCode.Text;
            int Type = cbCameraType.SelectedIndex;
            int Com = cbCom.SelectedIndex + 1;
            string IP = txtIP.Text;
            string Port = txtPort.Text;
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;
            int Channel = cbChannel.SelectedIndex + 1;

            if (this._ID != "")
            {
                if (!tblCamera.Modify(Convert.ToInt32(this._ID), Name, Code, Type, Com, IP, Convert.ToInt32(Port), Username, Password, Channel)){
                    MessageBox.Show(MultiLanguage.GetString("CameraEditError", StaticPool.Language));
                }
                else
                {
                    Camera camera = StaticPool.cams.GetCameraById(this._ID);
                    UpdateCameraInfo(this._ID, Name, Code, Type, Com, IP, Port, Username, Password, Channel, camera);
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                string LastID = tblCamera.InsertAndGetLastID(Name, Code, Type, Com, IP, Convert.ToInt32(Port), Username, Password, Channel);
                if (LastID == "")
                {
                    MessageBox.Show(MultiLanguage.GetString("CameraAddError", StaticPool.Language));
                }
                else
                {
                    Camera camera = new Camera();
                    UpdateCameraInfo(LastID,Name, Code, Type, Com, IP, Port, Username, Password, Channel, camera);
                    StaticPool.cams.Add(camera);
                    this.DialogResult = DialogResult.OK;
                }
            }
            
        }

        private static void UpdateCameraInfo(string ID,string Name, string Code, int Type, int Com, string IP, string Port, string Username, string Password, int Channel, Camera camera)
        {
            camera.Id = ID;
            camera.Name = Name;
            camera.Code = Code;
            camera.Type = Type;
            camera.Com = Com;
            camera.IP = IP;
            camera.Port = Convert.ToInt32(Port);
            camera.Username = Username;
            camera.Password = Password;
            camera.Channel = Channel;
        }
    }
}