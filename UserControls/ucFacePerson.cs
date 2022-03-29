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
    public partial class ucFacePerson : UserControl
    {
        private long _userID;
        public ucFacePerson()
        {
            InitializeComponent();
            dgvFacePerson.ToggleDoubleBuffered(true);
        }
        public void getUserID(long userID)
        {
            this._userID = userID;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            //if (StaticPool.groupFaces.Count == 0)
            //{
            //    MessageBox.Show(MultiLanguage.GetString("GroupCreateRequest", StaticPool.Language));
            //    return;
            //}
            frmFacePerson frm = new frmFacePerson("", this._userID);
            frm.Text = MultiLanguage.GetString("frmPersonFaceAdd", StaticPool.Language);
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
                frmFacePerson frm = new frmFacePerson(this.Id(), this._userID);
                frm.Text = MultiLanguage.GetString("frmPersonFaceEdit", StaticPool.Language);
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

            if (MessageBox.Show(MultiLanguage.GetString("DeleteConfirm", StaticPool.Language), MultiLanguage.GetString("DeleteTittleFacePerson", StaticPool.Language), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                PersonFace person = StaticPool.personFaces.GetPersonFaceById(this.Id());
                if (DahuaAPI.DeletePersonFace(StaticPool.ServerName, person.GroupID, this.Id())) 
                { 
                    string SQL_ID = tblPersonFace.GetIdFromPersonInfo(person);
                    if (SQL_ID != "")
                    {
                        if (!tblPersonFace.DeletePersonFace(SQL_ID))
                        {
                            StaticPool.Logger_Error($"Delete PersonFace SQLID = {SQL_ID} in Database error");
                        }
                    }                    
                    StaticPool.personFaces.Remove(person);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetString("PersonFaceDeleteError", StaticPool.Language));
                }
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            GetFaceData();
            LoadDataGridView();
        }
        //private delegate void SafeLoadDataGridview();
        public void LoadDataGridView()
        {
            dgvFacePerson.Rows.Clear();
            foreach (PersonFace person in StaticPool.personFaces)
            {
                dgvFacePerson.Rows.Add(person.PersonID, person.PersonName, person.GroupName, person.PersonSex, person.PersonBirthday, person.PersonCardType, person.PersonCardID, person.ImagePath);
            }
        }

        public void GetFaceData()
        {
            DahuaAPI.GetPersonFace(StaticPool.groupFaces, StaticPool.personFaces);           
        }

        public string Id()
        {
            string _lcma = "";
            DataGridViewRow _drv = dgvFacePerson.CurrentRow;
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
        public void setToostipEnable(bool enable)
        {
            toolStrip1.Enabled = enable;
        }
    }
}
