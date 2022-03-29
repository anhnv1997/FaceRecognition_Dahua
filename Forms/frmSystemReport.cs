using LazZiya.ImageResize;
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
    public partial class frmSystemReport : Form
    {
        static int personCount = 0;
        static int personWithMask = 0;
        static int personWithNoMask = 0;
        static int stranger = 0;
        static int assign = 0;
        public frmSystemReport()
        {
            InitializeComponent();
            cbType.SelectedIndex = 2;
        }

        private void frmSystemReport_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataTable dtb;
            switch (cbType.Text)
            {
                case "All":
                    dtb = StaticPool.mdb.FillData($"Select * from tblFaceEvent where cast(tblFaceEvent.Time as datetime) between '{dateTimePicker1.Value.ToString("yyyyMMdd HH:mm:ss") }' AND '{dateTimePicker2.Value.ToString("yyyyMMdd HH:mm:ss") }'");
                    break;
                case "Stranger":
                    dtb = StaticPool.mdb.FillData($"Select * from tblFaceEvent where cast(tblFaceEvent.Time as datetime) between '{dateTimePicker1.Value.ToString("yyyyMMdd HH:mm:ss") }' AND '{dateTimePicker2.Value.ToString("yyyyMMdd HH:mm:ss") }' AND tblFaceEvent.Type = 0");
                    break;
                case "Assign":
                    dtb = StaticPool.mdb.FillData($"Select * from tblFaceEvent where cast(tblFaceEvent.Time as datetime) between '{dateTimePicker1.Value.ToString("yyyyMMdd HH:mm:ss") }' AND '{dateTimePicker2.Value.ToString("yyyyMMdd HH:mm:ss") }' AND tblFaceEvent.Type = 1");
                    break;
                default:
                    dtb = StaticPool.mdb.FillData($"Select * from tblFaceEvent where cast(tblFaceEvent.Time as datetime) between '{dateTimePicker1.Value.ToString("yyyyMMdd HH:mm:ss") }' AND '{dateTimePicker2.Value.ToString("yyyyMMdd HH:mm:ss") }'");
                    break;
            }
            foreach (DataRow row in dtb.Rows)
            {
                personCount++;
                string ID = row["ID"].ToString();
                string Type = row["Type"].ToString();
                if(Type == "0")
                {
                    stranger++;
                }
                else
                {
                    assign++;
                }
                string Datetime = row["Time"].ToString();
                string AssignName = row["CandidateName"].ToString();
                string AssignSex = row["CandidateSex"].ToString();
                switch (AssignSex)
                {
                    case "Man":
                        AssignSex = MultiLanguage.GetString("Sex0", StaticPool.Language);
                        break;
                    case "Woman":
                        AssignSex = MultiLanguage.GetString("Sex1", StaticPool.Language);
                        break;
                }
                string AssignBirthday = row["CandidateBirthday"].ToString();
                string AssignCardType = row["CandidateCardType"].ToString(); 
                string AssignCardID = row["CandidateCardID"].ToString();
                string FaceMask = row["RecognizeMask"].ToString(); 
                if(FaceMask=="Not wearing mask")
                {
                    personWithNoMask++;
                }
                else
                {
                    personWithMask++;
                }
                switch (FaceMask)
                {
                    case "Not wearing mask":
                        FaceMask = MultiLanguage.GetString("PersonMask1", StaticPool.Language);
                        break;
                    case "Wearing mask":
                        FaceMask = MultiLanguage.GetString("PersonMask2", StaticPool.Language);
                        break;
                }

                string FaceBeard = row["RecognizeBeard"].ToString();
                switch (FaceBeard)
                {
                    case "No Beard":
                        FaceBeard = MultiLanguage.GetString("PersonBeard1", StaticPool.Language);
                        break;
                    case "Has Beard":
                        FaceBeard = MultiLanguage.GetString("PersonBeard2", StaticPool.Language);
                        break;
                }
                string AssignImagestr;
                try
                {
                    AssignImagestr = Path.GetFullPath(row["CandidateImage"].ToString());
                }
                catch
                {
                    AssignImagestr = "";
                }
                string FaceImagestr =Path.GetFullPath(row["RecognizeImage"].ToString());
                Image AssignImage=null, FaceImage=null;
                try
                {
                    if(AssignImagestr!= "")
                        AssignImage = ImageResize.Scale(Image.FromFile(AssignImagestr), 150, 150);
                }
                catch
                {
                    AssignImage = null;
                }
                try
                {
                     FaceImage = ImageResize.Scale(Image.FromFile(FaceImagestr), 150, 150);
                }
                catch
                {
                    FaceImage = null;
                }
                
                dataGridView1.Rows.Add(ID, Type, Datetime, AssignName, AssignSex, AssignBirthday, AssignCardType, AssignCardID, FaceMask, FaceBeard, AssignImage, FaceImage);
            }
            txtPersonCount.Text = personCount.ToString();
            txtPersonWithMask.Text = personWithMask.ToString();
            txtPersonWithNoMask.Text = personWithNoMask.ToString();
            txtStranger.Text = stranger.ToString();
            txtAssign.Text = assign.ToString();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
