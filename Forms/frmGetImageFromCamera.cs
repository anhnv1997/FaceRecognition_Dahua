using DHSDK;
using FaceRecognition.Objects;
using LazZiya.ImageResize;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognition.Forms
{
    public partial class frmGetImageFromCamera : Form
    {
        IntPtr pUser = new IntPtr();
        Int64 _userID, m_lRealHandle;
        Int64 lastError = 0;
        string FilePath="";
        string ID;
        public frmGetImageFromCamera(long userID)
        {
            InitializeComponent();
            this._userID = userID;
        }

        private void frmGetImageFromCamera_Load(object sender, EventArgs e)
        {
            TreeNode root = new TreeNode();
            root.Text = "Camera";
            CamTreeview.Nodes.Add(root);
            TreeNode CameraNode = new TreeNode();
            foreach (Camera camera in StaticPool.cams)
            {
                if (camera.Type == 1)
                {
                    TreeNode DeviceCameraNode = new TreeNode();
                    DeviceCameraNode.Text = camera.Name;
                    DeviceCameraNode.Name = "CameraIP:" + camera.Id;
                    root.Nodes.Add(DeviceCameraNode);
                }
            }
            LiveviewCameraDahua(ref this._userID, 3, CamLiveview.Handle, ref m_lRealHandle);
            CamTreeview.ExpandAll();
        }
        
        private void CamTreeview_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name.Contains("CameraIP:"))
            {
                Camera camera = StaticPool.cams.GetCameraById(e.Node.Name.Substring(e.Node.Name.IndexOf(":") + 1));
                StopLiveviewCameraDahua(ref m_lRealHandle);
                LiveviewCameraDahua(ref _userID, camera.Channel-1, CamLiveview.Handle, ref m_lRealHandle);
            }
        }

        public bool LiveviewCameraDahua(ref long userID, int channel, IntPtr handle, ref long m_lRealHandle)
        {
            m_lRealHandle = (long)DHSDK_LIVEVIEW.CLIENT_RealPlay(userID, channel, handle);
            if (m_lRealHandle <= 0)
            {
                return false;
            }
            return true;
        }
        public bool StopLiveviewCameraDahua(ref long m_lRealHandle)
        {
            if (!DHSDK_LIVEVIEW.CLIENT_StopRealPlay(m_lRealHandle))
            {
                return false;
            }
            else
            {
                m_lRealHandle = 0;
                return true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FilePath != "")
            {
                FileStream mStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                var scaleImg = ImageResize.Scale(Image.FromStream(mStream), 1024, 575);
                string _fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".jpeg";
                scaleImg.SaveAs(Path.Combine(@".\InputData", _fileName), 85);
                StaticPool.ImagePath = Path.Combine(@".\InputData", _fileName);
                mStream.Close();
                StopLiveviewCameraDahua(ref m_lRealHandle);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(MultiLanguage.GetString("TakePictureRequest", StaticPool.Language));
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            StopLiveviewCameraDahua(ref m_lRealHandle);
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            if (m_lRealHandle == 0)
            {
                MessageBox.Show(MultiLanguage.GetString("LiveviewRequest",StaticPool.Language));
                return;
            }
            else
            {
                string fileName = "TempData.jpeg";
                string pathFile = Path.GetFullPath(Path.Combine(@".\TempData", fileName));
                if (!DHSDK_SNAPSHOT.CLIENT_CapturePicture((IntPtr)m_lRealHandle, pathFile, DHSDK_ENUM.NET_CAPTURE_FORMATS.NET_CAPTURE_JPEG))
                {
                    lastError = DHSDK_Init.CLIENT_GetLastError() & 0x7FFFFFFF;
                    MessageBox.Show("Snap Error" + lastError);
                }
                else
                {
                    FilePath = pathFile;
                    FileStream mStream = new FileStream(pathFile, FileMode.Open, FileAccess.Read);
                    CamPicture.Image = Image.FromStream(mStream);
                    mStream.Close();
                    mStream.Dispose();                    
                }
            }
        }
    }
}
