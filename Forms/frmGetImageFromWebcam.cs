using FaceRecognition.Objects;
using RestSharp;
using RestSharp.Authenticators.Digest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using LazZiya.ImageResize;

namespace FaceRecognition.Forms
{
    public partial class frmGetImageFromWebcam : Form
    {
        string FileName = "";
        bool _streaming = false;
        VideoCapture videoCapture = new VideoCapture();
        public frmGetImageFromWebcam()
        {
            InitializeComponent();
        }

        private void frmGetImageFromWebcam_Load(object sender, EventArgs e)
        {
            /*TreeNode root = new TreeNode();
            root.Text = "Camera";
            WebcamTreeview.Nodes.Add(root);
            TreeNode CameraNode = new TreeNode();

            foreach (Camera camera in StaticPool.cams)
            {
                if (camera.Type == 0)
                {
                    TreeNode DeviceCameraNode = new TreeNode();
                    DeviceCameraNode.Text = camera.Name;
                    DeviceCameraNode.Name = "Webcam:" + camera.Id;
                    root.Nodes.Add(DeviceCameraNode);
                }
            }*/
            if (_streaming == false)
            {
                Application.Idle += Application_Idle; ;
            }

            _streaming = !_streaming;
        }

        private void WebcamTreeview_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
        }
        private void Application_Idle(object sender, EventArgs e)
        {
            var img = videoCapture.QueryFrame().ToImage<Rgb, byte>();
            byte[] bmp = img.ToJpegData();
            WebcamLiveview.Image = (Bitmap)((new ImageConverter()).ConvertFrom(bmp));
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            WebcamPic.Image = WebcamLiveview.Image;
            byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(WebcamLiveview.Image, typeof(byte[]));
            FileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".jpeg";
            File.WriteAllBytes(Path.Combine(@".\TempData", FileName), bytes);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FileName != "")
            {
                var scaleImg = ImageResize.Scale(WebcamPic.Image, 1024, 575);
                string fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".jpeg";
                scaleImg.SaveAs(Path.Combine(@".\InputData", fileName), 85);
                StaticPool.ImagePath = Path.GetFullPath(Path.Combine(@".\InputData", fileName));                
                if (_streaming == true)
                {
                    Application.Idle -= Application_Idle;
                }
                _streaming = !_streaming;
                videoCapture = null;
                this.DialogResult = DialogResult.OK;
            }

            else
            {
                MessageBox.Show(MultiLanguage.GetString("TakePictureRequest", StaticPool.Language));
            }
        }
    }
}
