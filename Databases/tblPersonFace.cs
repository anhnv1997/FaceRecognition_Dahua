using FaceRecognition.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Databases
{
    public class tblPersonFace
    {
        private const string TBL_PERSONFACE_NAME = "tblPersonFace";
        private const string TBL_PERSONFACE_COL_ID = "ID";
        private const string TBL_PERSONFACE_COL_GROUPID = "GroupID";
        private const string TBL_PERSONFACE_COL_GROUPNAME = "GroupName";
        private const string TBL_PERSONFACE_COL_NAME = "Name";
        private const string TBL_PERSONFACE_COL_SEX = "Sex";
        private const string TBL_PERSONFACE_COL_BIRTHDAY = "Birthday";
        private const string TBL_PERSONFACE_COL_CARDTYE = "CardType";
        private const string TBL_PERSONFACE_COL_CARDID = "CardID";
        private const string TBL_PERSONFACE_COL_IMAGEPATH = "ImagePath";
        private const string TBL_PERSONFACE_COL_POSITION = "Position";
        //Get
        public static string GetIdFromPersonInfo(PersonFace person)
        {
            DataTable dtb = StaticPool.mdb.FillData($"Select ID from {TBL_PERSONFACE_NAME} Where {TBL_PERSONFACE_COL_GROUPID} = {person.GroupID} And {TBL_PERSONFACE_COL_NAME} LIKE '%{person.PersonName}%' And {TBL_PERSONFACE_COL_SEX} Like '%{person.PersonSex}%' " +
                        $"And {TBL_PERSONFACE_COL_BIRTHDAY} Like '%{person.PersonBirthday}%' And {TBL_PERSONFACE_COL_CARDTYE} Like '%{person.PersonCardType}%' And {TBL_PERSONFACE_COL_CARDID} Like '%{person.PersonCardID}%' AND {TBL_PERSONFACE_COL_IMAGEPATH} Like '%{person.ImagePath}%'");
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0][TBL_PERSONFACE_COL_ID].ToString();
            }
            return "";
        }
        //Add
        public static bool Insert(int groupId, string groupName, string name, string sex, string birthday, string cardType, string cardID, string imagePath, string position)
        {
            if (!StaticPool.mdb.ExecuteCommand($"Insert into {TBL_PERSONFACE_NAME}({TBL_PERSONFACE_COL_GROUPID},{TBL_PERSONFACE_COL_GROUPNAME},{TBL_PERSONFACE_COL_NAME},{TBL_PERSONFACE_COL_SEX}," +
                $"{TBL_PERSONFACE_COL_BIRTHDAY},{TBL_PERSONFACE_COL_CARDTYE},{TBL_PERSONFACE_COL_CARDID},{TBL_PERSONFACE_COL_IMAGEPATH},{TBL_PERSONFACE_COL_POSITION}) "
                + $"values({groupId},N'{groupName}',N'{name}',N'{sex}',N'{birthday}',N'{cardType}','{cardID}','{imagePath}',N'{position}')"))
            {
                if (!StaticPool.mdb.ExecuteCommand($"Insert into {TBL_PERSONFACE_NAME}({TBL_PERSONFACE_COL_GROUPID},{TBL_PERSONFACE_COL_GROUPNAME},{TBL_PERSONFACE_COL_NAME},{TBL_PERSONFACE_COL_SEX}," +
                 $"{TBL_PERSONFACE_COL_BIRTHDAY},{TBL_PERSONFACE_COL_CARDTYE},{TBL_PERSONFACE_COL_CARDID},{TBL_PERSONFACE_COL_IMAGEPATH},{TBL_PERSONFACE_COL_POSITION}) "
                 + $"values({groupId},N'{groupName}',N'{name}',N'{sex}',N'{birthday}',N'{cardType}','{cardID}','{imagePath}',N'{position}')"))
                {
                    return false;
                }
            }
            return true;
        }
        //Modify
        public static bool Modify(string id, string groupId, string groupName, string name, string sex, string birthday, string cardType, string cardID, string imagePath, string position)
        {
            imagePath = imagePath == null && imagePath == "" ? "" : imagePath;
            if (imagePath != "")
            {
                if (!StaticPool.mdb.ExecuteCommand(GetUpdateWithImageCmd(id, groupId, groupName, name, sex, birthday, cardType, cardID, imagePath, position)))
                {
                    if (!StaticPool.mdb.ExecuteCommand(GetUpdateWithImageCmd(id, groupId, groupName, name, sex, birthday, cardType, cardID, imagePath, position)))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                if (!StaticPool.mdb.ExecuteCommand(GetUpdateNoImageCmd(id, groupId, groupName, name, sex, birthday, cardType, cardID, position)))
                {
                    if (!StaticPool.mdb.ExecuteCommand(GetUpdateNoImageCmd(id, groupId, groupName, name, sex, birthday, cardType, cardID, position)))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        private static string GetUpdateNoImageCmd(string id, string groupId, string groupName, string name, string sex, string birthday, string cardType, string cardID, string position)
        {
            return $"update {TBL_PERSONFACE_NAME} set {TBL_PERSONFACE_COL_GROUPID} = {groupId},{TBL_PERSONFACE_COL_GROUPNAME} = N'{groupName}',Name=N'{name}',Sex=N'{sex}'," +
                                    $"Birthday=N'{birthday}',CardType=N'{cardType}',CardId='{cardID}',Position=N'{position}' Where ID = {id}";
        }
        private static string GetUpdateWithImageCmd(string id, string groupId, string groupName, string name, string sex, string birthday, string cardType, string cardID, string imagePath, string position)
        {
            return $"update {TBL_PERSONFACE_NAME} set {TBL_PERSONFACE_COL_GROUPID} = {groupId},{TBL_PERSONFACE_COL_GROUPNAME} = N'{groupName}',Name=N'{name}',Sex=N'{sex}'," +
                                    $"Birthday=N'{birthday}',CardType=N'{cardType}',CardId='{cardID}',ImagePath='{imagePath}',Position=N'{position}' Where ID = {id}";

        }
        //Delete
        public static bool DeletePersonFace(string personID)
        {
            if (!StaticPool.mdb.ExecuteCommand($"Delete {TBL_PERSONFACE_COL_NAME} Where {TBL_PERSONFACE_COL_ID}={personID}"))
            {
                if (!StaticPool.mdb.ExecuteCommand($"Delete {TBL_PERSONFACE_COL_NAME} Where {TBL_PERSONFACE_COL_ID}={personID}"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
