using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecognition.DahuaFunction;
using FaceRecognition.Objects;
using RestSharp;
using RestSharp.Authenticators.Digest;

namespace FaceRecognition.Forms
{
    public partial class frmSelectGroupFace : Form
    {
        private string _channel;
        private List<string> _groupIDList;
        private List<string> _similarityList;
        private CheckBox checkBoxHeader;
        DataTable dt;
        public frmSelectGroupFace(string channel, List<string> groupIDList, List<string> similarityList)
        {
            InitializeComponent();
            this._channel = channel;
            this._groupIDList = groupIDList;
            this._similarityList = similarityList;
            txtChannelName.Text = "Channel" + this._channel;
        }

        private void frmSelectGroupFace_Load(object sender, EventArgs e)
        {
            CreateCheckboxCollumn();

            dataGridView1.DataSource = dt;
            foreach (GroupFace groupFace in StaticPool.groupFaces)
            {
                bool checkIsvalid = false;
                for (int i = 0; i < this._groupIDList.Count; i++)
                {
                    if (groupFace.ID == _groupIDList[i])
                    {
                        checkIsvalid = true;
                        break;
                    }
                }
                if (checkIsvalid == true)
                {
                    checkIsvalid = false;
                    continue;
                }
                else
                {
                    dataGridView1.Rows.Add(false, groupFace.ID, groupFace.GroupName, groupFace.GroupSize, "80");
                }
            }
        }

        private void CreateCheckboxCollumn()
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            checkBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(0, checkBoxColumn);
            //add checkbox header
            Rectangle rect = dataGridView1.GetCellDisplayRectangle(0, -1, false);
            rect.X = rect.Location.X + (rect.Width / 2);
            rect.Y = rect.Location.Y;
            checkBoxHeader = new CheckBox();
            checkBoxHeader.BackColor = Color.FromArgb(255, 255, 255);
            checkBoxHeader.Name = "checkboxheader";            
            checkBoxHeader.Size = new Size(19, 20);
            checkBoxHeader.Location = new Point(2, 10);
            checkBoxColumn.ReadOnly = false;
            checkBoxHeader.CheckedChanged += CheckBoxHeader_CheckedChanged;
            dataGridView1.Controls.Add(checkBoxHeader);
        }

        private void CheckBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHeader.Checked)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = true;
                }
                dataGridView1.RefreshEdit();
            }
            else
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1[0, i].Value = false;
                }
                dataGridView1.RefreshEdit();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string API = "http://192.168.20.236/cgi-bin/faceRecognitionServer.cgi?action=setGroup&channel=" + this._channel;
            int index = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if ((bool)dataGridView1[0, i].Value == true)
                {
                    API += $"&list[" + index + "].groupID=" + (string)dataGridView1.Rows[i].Cells[1].Value + "&list[" + index + "].similary=" + (string)dataGridView1.Rows[i].Cells[4].Value;
                    index++;
                }
            }
            for (int i = 0; i < this._groupIDList.Count; i++)
            {

                API += $"&list[" + index + "].groupID=" + this._groupIDList[i] + "&list[" + index + "].similary=" + this._similarityList[i];
                index++;

            }
            if (DahuaAPI.CallAPI(Method.GET, API, 500) == null)
            {
                MessageBox.Show("Set Database unsuccess, please try again");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
            /*
            var client1 = new RestClient(API);
            client1.Authenticator = new DigestAuthenticator(StaticPool.ServerUsername, StaticPool.ServerPassword);
            client1.Timeout = 500;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client1.Execute(request);
            if (response.IsSuccessful)
            {
                this.DialogResult = DialogResult.OK;
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
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Set Database unsuccess, please try again");
                }
            }*/
        }
    }
}
