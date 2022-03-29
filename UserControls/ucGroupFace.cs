using FaceRecognition.DahuaFunction;
using FaceRecognition.Databases;
using FaceRecognition.Forms;
using FaceRecognition.Objects;
using RestSharp;
using RestSharp.Authenticators.Digest;
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

namespace FaceRecognition.UserControls
{
    public partial class ucGroupFace : UserControl
    {
        public ucGroupFace()
        {
            InitializeComponent();
            dgvGroupFace.ToggleDoubleBuffered(true);
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            frmGroupFace frm = new frmGroupFace("");
            frm.Text = MultiLanguage.GetString("frmGroupFaceAdd", StaticPool.Language);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadDataGridView();
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.Id() != "")
            {
                frmGroupFace frm = new frmGroupFace(this.Id());
                frm.Text = MultiLanguage.GetString("frmGroupFaceEdit", StaticPool.Language);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    LoadDataGridView();
                }
            }
            else
            {
                MessageBox.Show(MultiLanguage.GetString("RecordSelectRequest", StaticPool.Language));
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (this.Id() == "")
            {
                MessageBox.Show(MultiLanguage.GetString("RecordSelectRequest", StaticPool.Language));
                return;
            }

            if (MessageBox.Show("deleteconfirm", "deletetitle", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (DahuaAPI.DeleteGroupFace(StaticPool.ServerName, this.Id()))
                { 
                    GroupFace group = StaticPool.groupFaces.GetGroupFaceById(this.Id());
                    string SQL_ID = tblGroupFace.GetIdFromGroupInfo(group);
                    if (SQL_ID != "")
                    {
                        if (!tblGroupFace.DeleteGroupFace(SQL_ID))
                        {
                            StaticPool.Logger_Error($"Delete GroupFace SQL_ID ={SQL_ID} in database error");
                        }
                    }
                    StaticPool.groupFaces.Remove(group);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetString("GroupDeleteError", StaticPool.Language));
                }
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            GetGroupFaceData();
            LoadDataGridView();
        }

        public string Id()
        {
            string _lcma = "";
            DataGridViewRow _drv = dgvGroupFace.CurrentRow;
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
        public void GetGroupFaceData()
        {
            DahuaAPI.GetGroupFace(StaticPool.groupFaces);
        }
        public void LoadDataGridView()
        {
            dgvGroupFace.Rows.Clear();
            foreach (GroupFace groupFace in StaticPool.groupFaces)
            {
                dgvGroupFace.Rows.Add(groupFace.ID, groupFace.GroupName, groupFace.GroupDetail);
            }
        }
        public void setToostipEnable(bool enable)
        {
            toolStrip1.Enabled = enable;
        }
    }
}
