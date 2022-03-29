using FaceRecognition.Objects;
using LazZiya.ImageResize;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Databases
{
    public class tblFaceEvent
    {
        private const string TBL_FACEEVENT_NAME = "tblFaceEvent";
        private const string TBL_FACEEVENT_COL_ID = "ID";
        private const string TBL_FACEEVENT_COL_TIME = "ID";
        private const string TBL_FACEEVENT_COL_TYPE = "ID";
        private const string TBL_FACEEVENT_COL_CANDIDATE_NAME = "ID";
        private const string TBL_FACEEVENT_COL_CANDIDATE_SEX = "ID";
        private const string TBL_FACEEVENT_COL_CANDIDATE_BIRTHDAY = "ID";
        private const string TBL_FACEEVENT_COL_CANDIDATE_CARDTYPE = "ID";
        private const string TBL_FACEEVENT_COL_CANDIDATE_CARDID = "ID";
        private const string TBL_FACEEVENT_COL_CANDIDATE_IMAGE = "ID";
        private const string TBL_FACEEVENT_COL_RECOGNIZE_SEX = "ID";
        private const string TBL_FACEEVENT_COL_RECOGNIZE_BEARD = "ID";
        private const string TBL_FACEEVENT_COL_RECOGNIZE_MASK = "ID";
        private const string TBL_FACEEVENT_COL_RECOGNIZE_IMAGE = "ID";
        private const int TYPE_CANDIDATE = 1;
        private const int TYPE_STRANGER = 0;
        
        public static bool InsertCandidateFace(FaceCandidateEventArgs e)
        {
            if (!StaticPool.mdb.ExecuteCommand(getInsertCandidateFaceCommand(e)))
            {
                if (!StaticPool.mdb.ExecuteCommand(getInsertCandidateFaceCommand(e)))
                {
                    return false;
                }
            }
            return true;
        }   
        
        private static void SaveImage(Image image, string imageName, out string savePath)
        {
            var scaleImg = ImageResize.Scale(image, 1000, 1000);
            System.IO.Directory.CreateDirectory(@".\Eventdata\" + DateTime.Now.ToString("yyyy_MM_dd"));
            savePath = @".\Eventdata\" + DateTime.Now.ToString("yyyy_MM_dd") + @"\" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff") + imageName;
            scaleImg.SaveAs(savePath);
        }
        private static string getInsertCandidateFaceCommand(FaceCandidateEventArgs e)
        {
            string filenameFaceImage = "";
            SaveImage(e.FaceImage, "FaceImage.jpg", out filenameFaceImage);

            string filenameCandidateImage = "";
            SaveImage(e.CandidateImage, "CandidateImage.jpg", out filenameCandidateImage);

            string CandidateImage = filenameFaceImage;
            string RecognizeImage = filenameCandidateImage;
            return $"Insert into tblFaceEvent(Type,CandidateName,CandidateSex,CandidateBirthday,CandidateCardType,CandidateCardID,RecognizeBeard,RecognizeMask,CandidateImage,RecognizeImage,Time) " +
                $"values({TYPE_CANDIDATE},N'{e.PersonName}',N'{e.Sex}',N'{e.Birthday}',N'{e.CardType}',N'{e.CardNumber}',N'{e.Beard}',N'{e.Mask}','{Path.GetFullPath(filenameCandidateImage)}','{Path.GetFullPath(filenameFaceImage)}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
        }
    }
}
