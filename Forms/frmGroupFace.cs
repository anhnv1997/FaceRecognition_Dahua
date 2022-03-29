using FaceRecognition.DahuaFunction;
using FaceRecognition.Databases;
using FaceRecognition.Objects;
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
    public partial class frmGroupFace : Form
    {
        public string _ID;
        public frmGroupFace()
        {
            InitializeComponent();
        }
        public frmGroupFace(string ID)
        {
            InitializeComponent();
            this._ID = ID; ;
            txtID.Text = ID;
            txtServerName.Text = StaticPool.ServerName;
        }

        private void frmGroupFace_Load(object sender, EventArgs e)
        {
            if (this._ID != "")
            {
                GroupFace group = StaticPool.groupFaces.GetGroupFaceById(this._ID);
                if (group != null)
                {
                    txtID.Text = group.ID;
                    txtGroupName.Text = group.GroupName;
                    txtGroupDescription.Text = group.GroupDetail;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("GroupNameEmpty", StaticPool.Language));
                return;
            }
            if (txtGroupDescription.Text == "")
            {
                MessageBox.Show(MultiLanguage.GetString("GroupDescriptionEmpty", StaticPool.Language));
                return;
            }
            string Name = txtGroupName.Text;
            string Detail = txtGroupDescription.Text;
            if (this._ID != "")
            {
                if (DahuaAPI.ModifyGroupFace(StaticPool.ServerName, this._ID, Name, Detail))
                {
                    GroupFace groupFace = StaticPool.groupFaces.GetGroupFaceById(this._ID);
                    UpdateGroupFaceInfo(Name, Detail, this._ID, groupFace);
                    if (!tblGroupFace.ModifyGroupFace(this._ID, Name, Detail, groupFace.GroupSize))
                    {
                        StaticPool.Logger_Error("Modify GroupFace in NVR Success\nModify GroupFace in Database Error");
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetString("GroupEditError", StaticPool.Language));
                }
            }
            else
            {
                string response = DahuaAPI.AddGroupFace(StaticPool.ServerName, Name, Detail);
                if (response != "")
                {
                    string[] result = response.Split("\r\n");
                    string groupID = result[0].Substring(result[0].IndexOf("=") + 1);

                    GroupFace groupFace = new GroupFace();
                    UpdateGroupFaceInfo(Name, Detail, groupID, groupFace);
                    StaticPool.groupFaces.Add(groupFace);

                    if (!tblGroupFace.AddGroupFace(Name, Detail))
                    {
                        StaticPool.Logger_Error("Insert GroupFace to NVR Success\n Insert GroupFace to Database Error");
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetString("GroupAddError", StaticPool.Language));
                }
            }
        }

        private static void UpdateGroupFaceInfo(string Name, string Detail, string groupID, GroupFace groupFace)
        {
            groupFace.ID = groupID;
            groupFace.GroupName = Name;
            groupFace.GroupDetail = Detail;
            groupFace.GroupSize = 0;
        }
    }
}
