using RestSharp;
using RestSharp.Authenticators.Digest;
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
    public partial class frmSetMinSimilarity : Form
    {
        public string _Similarity;
        public string _channel;
        public string _groupID;
        public frmSetMinSimilarity(string channel, string groupID, string Similarity)
        {
            InitializeComponent();
            this._Similarity = Similarity;
            this._channel = channel;
            this._groupID = groupID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSimilarity.Text != "" && txtSimilarity.Text != this._Similarity)
            {
                string API = $"http://192.168.20.236/cgi-bin/faceRecognitionServer.cgi?action=putDisposition&groupID=" + this._groupID + "&list[0].channel=" + this._channel + "&list[0].similary=" + txtSimilarity.Text;
                var client1 = new RestClient(API);
                client1.Authenticator = new DigestAuthenticator("admin", "admin123");
                client1.Timeout = 500;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client1.Execute(request);
                if (response.IsSuccessful)
                {
                    string s = response.Content;
                    this.DialogResult = DialogResult.OK;
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
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Edit Similarity Error");
                    }
                }
            }
            
        }

        private void frmSetMinSimilarity_Load(object sender, EventArgs e)
        {
            txtSimilarity.Text = this._Similarity;
        }
    }
}
