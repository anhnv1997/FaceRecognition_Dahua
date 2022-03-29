using FaceRecognition.DahuaFunction;
using FaceRecognition.Databases;
using FaceRecognition.Objects;
using LazZiya.ImageResize;
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

namespace FaceRecognition.Forms
{
    public partial class frmFacePerson : Form
    {
        public long _userID;
        public string _ID;
        public frmFacePerson()
        {
            InitializeComponent();
        }
        public frmFacePerson(string ID, long userID)
        {
            InitializeComponent();
            this._ID = ID;
            this._userID = userID;
        }
        private void frmFacePerson_Load(object sender, EventArgs e)
        {
            List<string> SexList = new List<string>();
            List<string> PositionList = new List<string>();
            List<string> CardTypeList = new List<string>();
            List<string> GroupIDList = new List<string>();
            SexList.Add(MultiLanguage.GetString("SexMale", StaticPool.Language));
            SexList.Add(MultiLanguage.GetString("SexFemale", StaticPool.Language));

            PositionList.Add(MultiLanguage.GetString("Position1", StaticPool.Language));
            PositionList.Add(MultiLanguage.GetString("Position2", StaticPool.Language));
            PositionList.Add(MultiLanguage.GetString("Position3", StaticPool.Language));

            CardTypeList.Add(MultiLanguage.GetString("CardTypeIC", StaticPool.Language));
            CardTypeList.Add(MultiLanguage.GetString("CardTypePassport", StaticPool.Language));
            CardTypeList.Add(MultiLanguage.GetString("CardTypeMilitary", StaticPool.Language));

            foreach(GroupFace group in StaticPool.groupFaces)
            {
                GroupIDList.Add(group.ID);
            }

            cbSex.DataSource = SexList;
            cbSex.SelectedIndex = 0;
            cbPosition.DataSource = PositionList;
            cbPosition.SelectedIndex = 0;
            cbCardType.DataSource = CardTypeList;
            cbCardType.SelectedIndex = 0;
            cbGroupID.DataSource = GroupIDList;
            if(cbGroupID.Items.Count>0)
                cbGroupID.SelectedIndex = 0;  
            if (this._ID != "")
            {
                PersonFace person = StaticPool.personFaces.GetPersonFaceById(this._ID);
                cbGroupID.SelectedIndex = Convert.ToInt32(person.GroupID) - 1;
                txtGroupName.Text = person.GroupName;
                txtName.Text = person.PersonName;
                switch (person.PersonSex)
                {
                    case "Male":
                        cbSex.SelectedIndex = 0;
                        break;
                    case "Female":
                        cbSex.SelectedIndex = 1;
                        break;
                    default:
                        cbSex.SelectedIndex = 0;
                        break;
                }
                switch (person.PersonCardType)
                {
                    case "IC":
                        cbCardType.SelectedIndex = 0;
                        break;
                    case "Passport":
                        cbCardType.SelectedIndex = 1;
                        break;
                    case "Military":
                        cbCardType.SelectedIndex = 2;
                        break;
                    default:
                        cbCardType.SelectedIndex = 0;
                        break;
                }
                txtCardID.Text = person.PersonCardID;
                try
                {
                    pictureBox1.Image = Image.FromFile(Path.GetFullPath(person.ImagePath));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                StaticPool.ImagePath = choofdlog.FileName;
                //string[] arrAllFiles = choofdlog.FileNames;
                FileStream fs = new FileStream(Path.GetFullPath(StaticPool.ImagePath), FileMode.Open, FileAccess.Read);
                pictureBox1.Image = Image.FromStream(fs);

                var scaleImg = ImageResize.Scale(Image.FromStream(fs), 1024, 575);
                string _fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".jpeg";
                scaleImg.SaveAs(Path.Combine(@".\InputData", _fileName), 85);
                StaticPool.ImagePath = Path.Combine(@".\InputData", _fileName);

                fs.Close();
                fs.Dispose();
            }
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            frmGetImageFromCamera frm = new frmGetImageFromCamera(this._userID);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(Path.GetFullPath(StaticPool.ImagePath), FileMode.Open, FileAccess.Read);
                    pictureBox1.Image = Image.FromStream(fs);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void btnWebcam_Click(object sender, EventArgs e)
        {
            frmGetImageFromWebcam frm = new frmGetImageFromWebcam();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(Path.GetFullPath(StaticPool.ImagePath), FileMode.Open, FileAccess.Read);
                    pictureBox1.Image = Image.FromStream(fs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (cbGroupID.Text == "")
            //{
            //    MessageBox.Show(MultiLanguage.GetString("PersonFaceGroupIDEmpty", StaticPool.Language));
            //    return;
            //}
            //if (txtName.Text == "")
            //{
            //    MessageBox.Show(MultiLanguage.GetString("PersonFaceNameEmpty", StaticPool.Language));
            //    return;
            //}
            //if (cbSex.Text == "")
            //{
            //    MessageBox.Show(MultiLanguage.GetString("PersonFaceSexEmpty", StaticPool.Language));
            //    return;
            //}
            //if (cbCardType.Text == "")
            //{
            //    MessageBox.Show(MultiLanguage.GetString("PersonFaceCardTypeEmpty", StaticPool.Language));
            //    return;
            //}
            //if (txtCardID.Text == "")
            //{
            //    MessageBox.Show(MultiLanguage.GetString("PersonFaceCardIDEmpty", StaticPool.Language));
            //    return;
            //}
            string Name = txtName.Text;
            string GroupName = txtGroupName.Text;
            string GroupId = "1";//cbGroupID.Text;
            string sex = "";
            switch (cbSex.SelectedIndex)
            {
                case 0:
                    sex = "Male";
                    break;
                case 1:
                    sex = "Female";
                    break;
            }            
            string birthday = dtBirthday.Text.ToString();
            string cardType = "";
            switch (cbCardType.SelectedIndex)
            {
                case 0:
                    cardType = "IC";
                    break;
                case 1:
                    cardType = "Passport";
                    break;
                case 2:
                    cardType = "Military";
                    break;
            }
            string Position = "";
            switch (cbPosition.SelectedIndex)
            {
                case 0:
                    Position = "HardWare";
                    break;
                case 1:
                    Position = "Software";
                    break;
                case 2:
                    Position = "Sale";
                    break;
            }
            string cardID = txtCardID.Text;
            //Modify
            if (this._ID != "")
            {
                if(DahuaAPI.ModifyPersonFace(StaticPool.ServerName, GroupId, this._ID, Name, birthday, sex, cardType, cardID, StaticPool.ImagePath))
                {
                    PersonFace person = StaticPool.personFaces.GetPersonFaceById(this._ID);
                    if (person != null)
                    {
                        string SQL_ID = tblPersonFace.GetIdFromPersonInfo(person);
                        if (SQL_ID!="") 
                        { 
                            if (!tblPersonFace.Modify(SQL_ID, GroupId, GroupName, Name, sex, birthday, cardType, cardID, StaticPool.ImagePath, Position))
                            {
                                MessageBox.Show(MultiLanguage.GetString("PersonFaceEditError", StaticPool.Language));
                            }
                        }
                        UpdatePersonInfo(Name, GroupName, GroupId, sex, birthday, cardType, cardID, this._ID, person);
                        StaticPool.ImagePath = "";
                    }
                    
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetString("PersonFaceEditError", StaticPool.Language));
                }
            }
            //Add
            else
            {
                //Kiem tra chon anh hay chua?
                if (StaticPool.ImagePath == "" || StaticPool.ImagePath == null)
                {
                    MessageBox.Show(MultiLanguage.GetString("PersonFaceImageEmpty", StaticPool.Language));
                    return;
                }
                string response = DahuaAPI.AddPersonFace(StaticPool.ServerName, GroupId, Name, sex, cardType, cardID, birthday, StaticPool.ImagePath);
                if (response != "") 
                { 
                    string[] result = response.Split("\r\n");
                    string personID = result[0].Substring(result[0].IndexOf("=") + 1);
                    if(!tblPersonFace.Insert(Convert.ToInt32(GroupId), GroupName, Name, sex, birthday, cardType, cardID, StaticPool.ImagePath, Position))
                    {
                        MessageBox.Show(MultiLanguage.GetString("PersonFaceAddError", StaticPool.Language));
                    }
                    else
                    {
                        PersonFace personFace = new PersonFace();
                        UpdatePersonInfo(Name, GroupName, GroupId, sex, birthday, cardType, cardID, personID, personFace);
                        StaticPool.personFaces.Add(personFace);
                    }
                    StaticPool.ImagePath = "";
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetString("PersonFaceAddError", StaticPool.Language));
                }
            }
        }

        private static void UpdatePersonInfo(string Name, string GroupName, string GroupId, string sex, string birthday, string cardType, string cardID, string personID, PersonFace personFace)
        {
            personFace.GroupID = GroupId;
            personFace.PersonID = personID;
            personFace.PersonName = Name;
            personFace.GroupName = GroupName;
            personFace.PersonBirthday = birthday;
            personFace.PersonSex = sex;
            personFace.Country = "";
            personFace.PersonCardType = cardType;
            personFace.PersonCardID = cardID;
            if (StaticPool.ImagePath != null && StaticPool.ImagePath != "")
            {
                personFace.ImagePath = StaticPool.ImagePath;
            }            
        }

        private void cbGroupID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGroupName.Text = StaticPool.groupFaces.GetGroupFaceById(cbGroupID.Text).GroupName;
        }
    }
}
