using RestSharp;
using RestSharp.Authenticators.Digest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LazZiya.ImageResize;
using System.Threading;

namespace FaceRecognition.Forms
{
    public partial class frmSearchPerson : Form
    {
        string filePath = "";
        public frmSearchPerson()
        {
            UISync.Init(this);
            InitializeComponent();
            cbChannel.SelectedIndex = 0;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                filePath = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true
                FileStream fs = new FileStream(Path.GetFullPath(choofdlog.FileName), FileMode.Open, FileAccess.Read);
                picSelect.Image = Image.FromStream(fs);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (picSelect.Image != null)
            {
                string StartTime = dTPStart.Value.ToString("yyyy-MM-dd"+"T"+"HH:mm:ss"+"Z");
                string EndTime = dTPEnd.Value.ToString("yyyy-MM-dd" + "T" + "HH:mm:ss" + "Z");
                string channel = cbChannel.SelectedIndex.ToString();

                string API = $"http://{StaticPool.ServerName}/cgi-bin/faceRecognitionServer.cgi?action=startFindHistoryByPic&Channel={channel}&StartTime={StartTime}&EndTime={EndTime}&Type=All&Similarity=80&MaxCandidate=900";
                var client = new RestClient(API);
                client.Authenticator = new DigestAuthenticator(StaticPool.ServerUsername, StaticPool.ServerPassword);
                client.Timeout = 500;
                var request = new RestRequest(Method.POST);

                var scaleImg = ImageResize.Scale(picSelect.Image, 1000, 1000);
                string imageName = "faceSearch.jpg";
                System.IO.Directory.CreateDirectory(@".\SearchData\" + DateTime.Now.ToString("yyyy_MM_dd"));
                string savePath = @".\SearchData\" + DateTime.Now.ToString("yyyy_MM_dd") + @"\" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff") + imageName;
                scaleImg.SaveAs(savePath);


                request.AddFile("Image", savePath, "image/jpeg");
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    string result = response.Content.Split("Content-Type:application/json")[response.Content.Split("Content-Type:application/json").Length - 1];
                    if (result.Contains("\"progress\" : 100,"))
                    {
                        string _Token = result.Substring(result.IndexOf("\"token\" : "), result.IndexOf("\"progress\" : 100,") - result.IndexOf("\"token\" : "));
                        int token = Convert.ToInt32(_Token.Substring(_Token.IndexOf(":") + 2, _Token.IndexOf(",") - _Token.IndexOf(":") - 2));
                        string _maxCount = result.Substring(result.IndexOf("\"totalCount\""), result.IndexOf("}") - result.IndexOf("\"totalCount\" :"));
                        int maxCount = Convert.ToInt32(_maxCount.Substring(_maxCount.IndexOf(":") + 2, _maxCount.IndexOf("\n") - _maxCount.IndexOf(":") - 2));
                        if (maxCount > 0)
                        {
                            txtCount.Text = maxCount.ToString();
                            for (int i = 0; i < maxCount; i++)
                            {
                                API = $"http://{StaticPool.ServerName}/cgi-bin/faceRecognitionServer.cgi?action=doFindHistoryByPic&token=" + token + "&index=" + i + "&count=1";
                                MJpegStreamReader.StartAsync(API);
                                Thread.Sleep(300);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cant find any");
                        }


                    }
                }
            }
            else
            {
                MessageBox.Show("Select a picture first");
            }
        }
        private class UISync
        {
            private static ISynchronizeInvoke Sync;

            public static void Init(ISynchronizeInvoke sync)
            {
                Sync = sync;
            }
            public static void Execute(Action action)
            {
                Sync.BeginInvoke(action, null);
            }
        }

        private void frmSearchPerson_Load(object sender, EventArgs e)
        {
            MJpegStreamReader.FaceHistoryEvent += MJpegStreamReader_FaceHistoryEvent;
        }

        private void MJpegStreamReader_FaceHistoryEvent(object sender, Objects.FaceSHistoryEventArgs e)
        {
            /*string _UID = text.Substring(text.IndexOf("\"UID\""), text.IndexOf("\"Sex\"") - text.IndexOf("\"UID\""));
            string UID = _UID.Substring(_UID.IndexOf(":") + 3, _UID.IndexOf(",") - _UID.IndexOf(":") - 4);
            DataTable dtbDateTime = StaticPool.mdb.FillData($"Select Datetime from tblFaceStranger where UserID ='{UID}'");
            string dateTime = "";
            if (dtbDateTime != null && dtbDateTime.Rows.Count > 0)
            {
                dateTime = dtbDateTime.Rows[0]["Datetime"].ToString();
            }
            string _Sex = text.Substring(text.IndexOf("\"Sex\""), text.IndexOf("\"Age\"") - text.IndexOf("\"Sex\""));
            string Sex = _Sex.Substring(_Sex.IndexOf(":") + 3, _Sex.IndexOf(",") - _Sex.IndexOf(":") - 4);

            string _Age = text.Substring(text.IndexOf("\"Age\""), text.IndexOf("\"Glasses\"") - text.IndexOf("\"Age\""));
            string Age = _Age.Substring(_Age.IndexOf(":") + 2, _Age.IndexOf(",") - _Age.IndexOf(":") - 2);

            Bitmap _bitmap = new Bitmap(image);
            Image image1 = _bitmap;
            Image imageResize = ImageResize.Scale(image, 150, 150);*/
            UISync.Execute(() =>
            {
                dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, e._DateTime, e.Sex, e.Age, e.StrangerImage);
            });
        }
    }
}
