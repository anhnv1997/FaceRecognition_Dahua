using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceRecognition.UserControls;

namespace FaceRecognition.Objects
{
    public delegate void FaceCandidateHandler(object sender, FaceCandidateEventArgs e);
    public class FaceCandidateEventArgs : EventArgs
    {
        private const string CANDIDATE_SEX = "Events[0].Object.Candidates[0].Person.Sex";
        private const string RECOGNIZE_BEARD = "Events[0].Object.Beard";
        private const string RECODNIZE_MASK = "Events[0].Object.Mask";
        private const string CANDIDATE_NAME = "Events[0].Face.Candidates[0].Person.Name";
        private const string CANDIDATE_GROUPNAME = "Events[0].Face.Candidates[0].Person.GroupName=";
        private const string CANDIDATE_BIRTHDAY = "Events[0].Face.Candidates[0].Person.Birthday";
        private const string CANDIDATE_CARDTYPE = "Events[0].Face.Candidates[0].Person.CertificateType";
        private const string CANDIDATE_CARDID = "Events[0].Face.Candidates[0].Person.ID";
        private const string CANDIDATE_PERSONID = "Events[0].Face.Candidates[0].Person.UID";
        public string Beard { get; set; }
        public string Mask { get; set; }
        public string PersonName { get; set; }
        public string PersonID { get; set; }
        public string GroupName { get; set; }

        public string Sex { get; set; }
        public string Birthday { get; set; }

        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string Position { get; set; }
        public Image FaceImage { get; set; }
        public Image CandidateImage { get; set; }
        public Image GlobalImage { get; set; }
        public void GetPersonInfor(string personInfor)
        {
            string[] result = personInfor.Split("\r\n");
            foreach (string str in result)
            {
                if (str.Contains(CANDIDATE_SEX))
                {
                    this.Sex = GetSex(GetData(str), StaticPool.Language);
                }
                if (str.Contains(RECOGNIZE_BEARD))
                {
                    this.Beard = GetBeard(GetData(str), StaticPool.Language);
                }
                if (str.Contains(RECODNIZE_MASK))
                {
                    this.Mask = GetMask(GetData(str), StaticPool.Language);
                }
                if (str.Contains(CANDIDATE_NAME))
                {
                    this.PersonName = GetData(str);
                }
                if (str.Contains(CANDIDATE_GROUPNAME))
                {
                    this.GroupName = GetData(str);
                }
                if (str.Contains(CANDIDATE_BIRTHDAY))
                {
                    this.Birthday = GetData(str);
                }
                if (str.Contains(CANDIDATE_CARDTYPE))
                {
                    this.CardType = GetData(str);
                }
                if (str.Contains(CANDIDATE_CARDID))
                {
                    this.CardNumber = GetData(str);
                }

                if (str.Contains(CANDIDATE_PERSONID))
                {
                    this.PersonID = GetData(str);
                    PersonFace personFace = StaticPool.personFaces.GetPersonFaceById(this.PersonID);
                    if (personFace != null)
                    {
                        this.Position = personFace.Position;

                    }
                    else
                    {
                        this.Position = "";
                    }
                }

            }
        }
        #region: Face Event
        private static string GetBeard(string FaceImageBeard, string language)
        {
            string Beard = FaceImageBeard.Substring(FaceImageBeard.IndexOf("=") + 1);
            switch (Beard)
            {
                case "0":
                    return MultiLanguage.GetString("PersonBeard0", language);
                case "1":
                    return MultiLanguage.GetString("PersonBeard1", language);
                case "2":
                    return MultiLanguage.GetString("PersonBeard2", language);
                default:
                    return "";
            }
        }

        private static string GetSex(string FaceImageSex, string language)
        {
            string Sex = FaceImageSex.Substring(FaceImageSex.IndexOf("=") + 1);
            switch (Sex)
            {
                case "Male":
                    return MultiLanguage.GetString("Sex0", language);
                case "Female":
                    return MultiLanguage.GetString("Sex1", language);
                default:
                    return MultiLanguage.GetString("Sex2", language);
            }
        }

        private static string GetMask(string FaceImageMask, string language)
        {
            string Mask = FaceImageMask.Substring(FaceImageMask.IndexOf("=") + 1);
            switch (Mask)
            {
                case "0":
                    return MultiLanguage.GetString("PersonMask0", language);
                case "1":
                    //UpdateNoMaskCount();
                    return MultiLanguage.GetString("PersonMask1", language);
                case "2":
                    //UpdateMaskCount();
                    return MultiLanguage.GetString("PersonMask2", language);
                default:
                    return "";
            }
        }
        private static void UpdateMaskCount()
        {
            StaticPool.personWithMask++;
        }
        private static void UpdateNoMaskCount()
        {
            StaticPool.personWithNoMask++;
        }
        #endregion
        private static string GetData(string data)
        {
            return data.Substring(data.IndexOf("=") + 1);
        }
    }

    public delegate void FaceStrangerHandler(object sender, FaceStrangerEventArgs e);
    public class FaceStrangerEventArgs
    {
        public Image FaceStrangerImage { get; set; }
        public string CameraChannel { get; set; }
    }

    public delegate void VehicleMotorHandler(object sender, VehicleMotorEventArgs e);
    public class VehicleMotorEventArgs:EventArgs
    {
        public string VehicleColor { get; set; }
        public string VehicleType { get; set; }
        public string PlateColor { get; set; }
        public string PlateNo { get; set; }
        public string SeatBelt { get; set; }
        public string Calling { get; set; }
        public string Smoking { get; set; }
        public Image GlobalImage { get; set; }
        public Image VehicleImage { get; set; }
    }

    public delegate void VehicleNonMotorHandler(object sender, VehicleNonMotorEventArgs e);
    public class VehicleNonMotorEventArgs : EventArgs
    {
        public string VehicleColor { get; set; }
        public Image GlobalImage { get; set; }
        public Image VehicleImage { get; set; }
    }
    public delegate void FaceStrangerUIDEventHandler(object sender, FaceStrangerUIDEventArgs e);
    public class FaceStrangerUIDEventArgs : EventArgs
    {
        public string _UID { get; set; }
        public DateTime _DateTime { get; set; }
        public Image StrangerImage { get; set; }
    }

    public delegate void FaceSHistoryEventHandler(object sender, FaceSHistoryEventArgs e);
    public class FaceSHistoryEventArgs : EventArgs
    {
        public string _UID { get; set; }
        public string _DateTime { get; set; }
        public Image StrangerImage { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
    }
}
