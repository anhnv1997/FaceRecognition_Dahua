using FaceRecognition.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecognition.Objects;
using RestSharp;
using RestSharp.Authenticators.Digest;

namespace FaceRecognition.UserControls
{
    public partial class ucFaceRecognize : UserControl
    {
        int SelectedRowIndex = 0;
        public ucFaceRecognize()
        {
            InitializeComponent();
            dataGridView1.ToggleDoubleBuffered(true);
        }

        public void loadCameraChannel()
        {
            List<int> channelList = new List<int>();
            foreach (Camera camera in StaticPool.cams)
            {
                if (camera.Type == 1)
                {
                    channelList.Add(camera.Channel);
                }
            }
            cbChannel.DataSource = channelList;
            cbChannel.SelectedIndex = 0;
        }

        public void loadDataGridView()
        {
            dataGridView1.Rows.Clear();
            string API = $"http://{StaticPool.ServerName}/cgi-bin/faceRecognitionServer.cgi?action=getGroup&channel=" + cbChannel.Text;
            var client1 = new RestClient(API);
            client1.Authenticator = new DigestAuthenticator("admin", "admin123");
            client1.Timeout = 500;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client1.Execute(request);
            if (response.IsSuccessful)
            {
                ExcecuteResponse(response.Content);
            }
            else
            {
                client1 = new RestClient(API);
                client1.Authenticator = new DigestAuthenticator("admin", "admin123");
                client1.Timeout = 500;
                request = new RestRequest(Method.GET);
                response = client1.Execute(request);
                if (response.IsSuccessful)
                {
                    ExcecuteResponse(response.Content);
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
        public void ExcecuteResponse(string response)
        {
            string[] splitResponse = response.Split("\r\n");
            int GroupCount = splitResponse.Length / 2;
            for (int i = 0; i < GroupCount - 1; i++)
            {
                string groupID = splitResponse[i + 1].Substring(splitResponse[i + 1].IndexOf("=") + 1);
                string Similarity = splitResponse[i + GroupCount].Substring(splitResponse[i + GroupCount].IndexOf("=") + 1);
                GroupFace groupFace = StaticPool.groupFaces.GetGroupFaceById(groupID);
                if (groupFace != null)
                {
                    dataGridView1.Rows.Add(i + 1, groupID, groupFace.GroupName, Similarity);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRowIndex = e.RowIndex;
            
        }

        private void cbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            List<string> groupIDLIst = new List<string>();
            List<string> similarityList = new List<string>();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                groupIDLIst.Add((string)dataGridView1.Rows[i].Cells[1].Value);
                similarityList.Add((string)dataGridView1.Rows[i].Cells[3].Value);
            }
            frmSelectGroupFace frm = new frmSelectGroupFace(cbChannel.Text, groupIDLIst, similarityList);
            frm.Text = MultiLanguage.GetString("frmSelectDatabase", StaticPool.Language);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                loadDataGridView();
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            List<string> groupIDLIst = new List<string>();
            List<string> similarityList = new List<string>();
            
            frmSelectGroupFace frm = new frmSelectGroupFace(cbChannel.Text, groupIDLIst, similarityList);
            frm.Text = MultiLanguage.GetString("frmSelectDatabase", StaticPool.Language);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                loadDataGridView();
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (this.Id() == "")
            {
                MessageBox.Show(MultiLanguage.GetString("RecordSelectRequest", StaticPool.Language));
                return;
            }

            if (MessageBox.Show(MultiLanguage.GetString("DeleteConfirm", StaticPool.Language), "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string API = $"http://{StaticPool.ServerName}/cgi-bin/faceRecognitionServer.cgi?action=deleteDisposition&groupID=" + (string)dataGridView1.Rows[SelectedRowIndex].Cells[1].Value + "&channel[0]=" + cbChannel.Text;
                var client1 = new RestClient(API);
                client1.Authenticator = new DigestAuthenticator(StaticPool.ServerUsername, StaticPool.ServerPassword);
                client1.Timeout = 500;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client1.Execute(request);
                if (response.IsSuccessful)
                {
                    dataGridView1.Rows.RemoveAt(SelectedRowIndex);
                }
                else
                {
                    client1 = new RestClient(API);
                    client1.Authenticator = new DigestAuthenticator(StaticPool.ServerUsername, StaticPool.ServerPassword);
                    client1.Timeout = 500;
                    request = new RestRequest(Method.GET);
                    response = client1.Execute(request);
                    if (response.IsSuccessful)
                    {
                        dataGridView1.Rows.RemoveAt(SelectedRowIndex);
                    }
                    else
                    {
                        MessageBox.Show("Delete Error");
                    }
                }

            }



        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            loadDataGridView();
        }
        public string Id()
        {
            string _lcma = "";
            DataGridViewRow _drv = dataGridView1.CurrentRow;
            try
            {
                _lcma = _drv.Cells[0].Value.ToString();
            }
            catch
            {
                _lcma = "";
            }
            return _lcma;
        }
    }
}
