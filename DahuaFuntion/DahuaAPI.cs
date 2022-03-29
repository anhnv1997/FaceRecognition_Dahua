using FaceRecognition.Objects;
using RestSharp;
using RestSharp.Authenticators.Digest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FaceRecognition.DahuaFunction
{
    public class DahuaAPI
    {
        #region: TestConnect
        public static bool TestConnect()
        {

            if (CallAPI(Method.GET, GetTestConnectUrl(), 500) == null)
            {
                if (CallAPI(Method.GET, GetTestConnectUrl(), 500) == null)
                {
                    return false;
                }
            }
            return true;
        }
        public static string GetTestConnectUrl()
        {
            return $"http://{StaticPool.ServerName}/cgi-bin/devAudioInput.cgi?action=getCollect";
        }
        #endregion

        #region: GroupFace
        #region: Get GroupFace
        public static GroupFaceCollection GetGroupFace(GroupFaceCollection groupFaceCollection)
        {
            var response = CallAPI(Method.GET, GetSearchGroupFaceAllUrl(StaticPool.ServerName), 500);
            if (response == null)
            {
                response = CallAPI(Method.GET, GetSearchGroupFaceAllUrl(StaticPool.ServerName), 500);
                if (response == null)
                {
                    return null;
                }
            }
            groupFaceCollection.Clear();
            string[] ContentArray = response.Content.Split("\r\n");
            for (int i = 0; i < ContentArray.Length - 1; i++)
            {
                GroupFace groupFace = new GroupFace();
                foreach (string str in ContentArray)
                {
                    if (str == "")
                    {
                        continue;
                    }
                    if (str.Substring(10, 1) == i.ToString())
                    {
                        if (str.Contains("ID"))
                        {
                            groupFace.ID = str.Substring(str.IndexOf("=") + 1);
                        }
                        if (str.Contains("Name"))
                        {
                            groupFace.GroupName = str.Substring(str.IndexOf("=") + 1);
                        }
                        if (str.Contains("Detail"))
                        {
                            groupFace.GroupDetail = str.Substring(str.IndexOf("=") + 1);
                        }
                        if (str.Contains("Size"))
                        {
                            groupFace.GroupSize = Convert.ToInt32(str.Substring(str.IndexOf("=") + 1));
                        }
                    }
                }
                if (groupFace.ID != "" && groupFace.ID != null)
                {
                    groupFaceCollection.Add(groupFace);
                }
            }
            return groupFaceCollection;
        }
        public static string GetSearchGroupFaceWithIDUrl(string serverName, string groupID)
        {
            return $"http://{serverName}/cgi-bin/faceRecognitionServer.cgi?action=findGroup" + "&groupID=" + groupID;
        }
        public static string GetSearchGroupFaceAllUrl(string serverName)
        {
            return $"http://{serverName}/cgi-bin/faceRecognitionServer.cgi?action=findGroup";
        }
        #endregion

        #region: Add GroupFace
        public static string AddGroupFace(string serverName, string groupName, string groupDetail)
        {
            var response = CallAPI(Method.GET, GetAddGroupFaceUrl(serverName, groupName, groupDetail), 500);
            if (response == null)
            {
                return "";
            }
            return response.Content;
        }
        public static string GetAddGroupFaceUrl(string serverName, string groupName, string groupDetail)
        {
            string apiUrl = $"http://{serverName}/cgi-bin/faceRecognitionServer.cgi?action=createGroup" + "&groupName=" + groupName + "&groupDetail=" + groupDetail;
            return apiUrl;
        }
        #endregion

        #region: Modify GroupFace
        public static bool ModifyGroupFace(string serverName, string groupID, string groupName, string groupDetail)
        {

            if (CallAPI(Method.GET, GetModifyFroupFaceUrl(serverName, groupID, groupName, groupDetail), 500) != null)
            {
                return true;
            }
            return false;
        }

        public static string GetModifyFroupFaceUrl(string serverName, string groupID, string groupName, string groupDetail)
        {
            return $"http://{serverName}/cgi-bin/faceRecognitionServer.cgi?action=modifyGroup" + "&groupID=" + groupID + "&groupName=" + groupName + "&groupDetail=" + groupDetail;
        }
        #endregion

        #region: Delete GroupFace
        public static bool DeleteGroupFace(string serverName, string groupID)
        {
            if (CallAPI(Method.GET, GetDeleteGroupFaceUrl(serverName, groupID), 500) != null)
            {
                return true;
            }
            return false;
        }
        public static string GetDeleteGroupFaceUrl(string serverName, string groupID)
        {
            return $"http://{serverName}/cgi-bin/faceRecognitionServer.cgi?action=deleteGroup" + "&groupID=" + groupID;
        }
        #endregion
        #endregion

        #region: face Person
        #region: Get Person Face
        public static PersonFaceCollection GetPersonFace(GroupFaceCollection groupFaceCollection, PersonFaceCollection personFaceCollection)
        {
            personFaceCollection.Clear();
            foreach (GroupFace groupFace in groupFaceCollection)
            {
                var response = StartFindPersonFace(groupFace);
                if (response == null)
                {
                    return null;
                }
                string[] content = response.Content.Split("\r\n");
                string token = content[0].Substring(content[0].IndexOf("=") + 1);
                string maxIndex = content[1].Substring(content[1].IndexOf("=") + 1);
                for (int index = 0; index < Convert.ToInt32(maxIndex); index++)
                {
                    if (DoFindPersonFace(token, index, out response) == null)
                    {
                        continue;
                        //return null;
                    }
                    personFaceCollection.Add(GetPersonFaceData(response.Content));
                }
            }
            return personFaceCollection;
        }
        private static IRestResponse StartFindPersonFace(GroupFace groupFace)
        {
            return CallAPI(Method.GET, GetStartFindPersonFaceUrl(StaticPool.ServerName, groupFace.ID), 500);
        }
        private static IRestResponse DoFindPersonFace(string token, int locationInGroup, out IRestResponse response)
        {
            response = CallAPI(Method.GET, GetDoFindPersonFaceUrl(StaticPool.ServerName, token, locationInGroup.ToString()), 1000);
            return response;
        }
        private static PersonFace GetPersonFaceData(string response)
        {
            string[] personContent = response.Split("\r\n");
            PersonFace personFace = new PersonFace();
            personFace.GroupID = GetData(personContent[6]);
            personFace.GroupName = StaticPool.groupFaces.GetGroupFaceById(personFace.GroupID).GroupName;
            personFace.PersonID = GetData(personContent[5]);
            personFace.PersonName = GetData(personContent[9]);
            personFace.PersonBirthday = GetData(personContent[10]);
            personFace.PersonSex = GetData(personContent[7]);
            personFace.Country = GetData(personContent[11]);
            personFace.PersonCardType = GetData(personContent[14]);
            personFace.PersonCardID = GetData(personContent[15]);
            string[] imagePathArray = personContent[22].Split(";");
            personFace.ImagePath = @".\InputData\" + imagePathArray[2].Substring(11, imagePathArray[2].Length - 12);

            DataTable dtb = StaticPool.mdb.FillData($"Select Position from tblPersonFace Where GroupID = {personFace.GroupID} And CardID Like '%{personFace.PersonCardID}%'");
            if (dtb != null && dtb.Rows.Count > 0)
            {
                DataRow dataRow = dtb.Rows[0];
                personFace.Position = dataRow["Position"].ToString();
            }
            return personFace;
        }
        public static string GetStartFindPersonFaceUrl(string severName, string groupId)
        {
            return $"http://{severName}/cgi-bin/faceRecognitionServer.cgi?action=startFind&condition.GroupID[0]={groupId}";
        }
        public static string GetDoFindPersonFaceUrl(string serverName, string token, string index)
        {
            return $"http://{serverName}/cgi-bin/faceRecognitionServer.cgi?action=doFind&token={token}&index={index}";
        }
        public static string GetStopFindPersonFaceUrl(string serverName, string token)
        {
            return $"http://{serverName}/cgi-bin/faceRecognitionServer.cgi?action=stopFind&token={token}";
        }
        #endregion

        #region: Add Person Face
        public static string AddPersonFace(string serverName, string groupID, string personName, string sex, string cardType, string cardID, string birthday, string imagePath)
        {
            var response = CallAPIWithImage(Method.POST, GetAddPersonFaceUrl(serverName, groupID, personName, sex, cardType, cardID, birthday), 500, imagePath);
            if (response == null)
            {
                return "";
            }
            return response.Content;
        }

        public static string GetAddPersonFaceUrl(string serverName, string groupID, string personName, string sex, string cardType, string cardID, string birthday)
        {
            return $"http://{serverName}/cgi-bin/faceRecognitionServer.cgi?action=addPerson&groupID={groupID}&name={personName}&birthday={birthday}&sex={sex}&certificateType={cardType}&id={cardID}";
        }
        #endregion

        #region: Modify Person Face
        public static bool ModifyPersonFace(string serverName, string groupID, string uID, string personName, string personBirthday, string personSex, string personCardType, string personCardId, string imagePath)
        {
            if (imagePath == "")
            {
                if (CallAPI(Method.POST, GetModifyPersonUrl(serverName, groupID, uID, personName, personBirthday, personSex, personCardType, personCardId), 500) != null)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (CallAPIWithImage(Method.POST, GetModifyPersonUrl(serverName, groupID, uID, personName, personBirthday, personSex, personCardType, personCardId), 500, imagePath) != null)
                {
                    return true;
                }
                return false;
            }
        }
        public static string GetModifyPersonUrl(string serverName, string groupID, string uID, string personName, string personBirthday, string personSex, string personCardType, string personCardId)
        {
            return $"http://{serverName}/cgi-bin/faceRecognitionServer.cgi?action=modifyPerson&uid={uID}&groupID={groupID}&name={personName}&birthday={personBirthday}&sex={personSex}&certificateType={personCardType}&id={personCardId}";
        }
        #endregion

        #region: Delete Person Face
        public static bool DeletePersonFace(string serverName, string groupID, string uID)
        {
            if(CallAPI(Method.GET, GetDeletePersonUrl(serverName, groupID, uID), 500) != null){
                return true;
            }
            return false;
        }
        public static string GetDeletePersonUrl(string serverName, string groupID, string uID)
        {
            return $"http://{serverName}/cgi-bin/faceRecognitionServer.cgi?action=deletePerson&uid={uID}&groupID={groupID}";
        }
        #endregion

        #region: FaceEvent
        public static string GetFaceEventCommand(string serverName, Camera camera)
        {
            return $"http://{serverName}/cgi-bin/snapManager.cgi?action=attachFileProc&Flags[0]=Event&Events=[All]&channel={camera.Channel}&heartbeat=50";
            //return $"http://{serverName}/cgi-bin/snapManager.cgi?action=attachFileProc&Flags[0]=Event&Events=[FaceRecognition]&channel={camera.Channel}&heartbeat=50";
        }
        #endregion
        #endregion

        #region: Vehicle
        public static string GetVehicleEventCommand(string serverName, Camera camera)
        {
            return $"http://{serverName}/cgi-bin/snapManager.cgi?action=attachFileProc&Flags[0]=Event&Events=[TrafficJunction]&channel={camera.Channel}&heartbeat=20";
        }
        #endregion

        #region: Find History by Face
        public static string GetFaceHistoryUId(string startTime, string endTime, string cameraChannel, int similarity, int maxCandidate, string imagePath)
        {
            var response = StartFindFaceHistory(startTime, endTime, cameraChannel, similarity, maxCandidate, imagePath);
            if (response == null)
            {
                return null;
            }
            string result = response.Content.Split("Content-Type:application/json")[response.Content.Split("Content-Type:application/json").Length - 1];
            if (result.Contains("\"progress\" : 100,"))
            {
                string _Token = result.Substring(result.IndexOf("\"token\" : "), result.IndexOf("\"progress\" : 100,") - result.IndexOf("\"token\" : "));
                int token = Convert.ToInt32(_Token.Substring(_Token.IndexOf(":") + 2, _Token.IndexOf(",") - _Token.IndexOf(":") - 2));
                string _maxCount = result.Substring(result.IndexOf("\"totalCount\""), result.IndexOf("}") - result.IndexOf("\"totalCount\" :"));
                int maxCount = Convert.ToInt32(_maxCount.Substring(_maxCount.IndexOf(":") + 2, _maxCount.IndexOf("\n") - _maxCount.IndexOf(":") - 2));
                if (maxCount > 0)
                {
                    for (int i = 0; i < maxCount; i++)
                    {
                        MJpegStreamReader.StartAsync(GetDoFindFaceHistoryUrl(token, i)).ConfigureAwait(false);
                        Thread.Sleep(300);
                    }
                }
                else
                {
                    return null;
                }
            }
            return "";
        }
        private static IRestResponse StartFindFaceHistory(string startTime, string endTime, string cameraChannel, int similarity, int maxCandidate, string imagePath)
        {
            return CallAPIWithImage(Method.POST, GetStartFindFaceHistoryUrl(startTime, endTime, cameraChannel, similarity, maxCandidate), 1000, imagePath);
        }
        private static string GetStartFindFaceHistoryUrl(string startTime, string endTime, string cameraChannel, int similarity, int maxCandidate)
        {
            return $"http://{StaticPool.ServerName}/cgi-bin/faceRecognitionServer.cgi?action=startFindHistoryByPic&Channel={cameraChannel}&StartTime={startTime}&EndTime={endTime}&Type=All&Similarity={similarity}&MaxCandidate={maxCandidate}";
        }
        private static string GetDoFindFaceHistoryUrl(int token, int index)
        {
            return $"http://{StaticPool.ServerName}/cgi-bin/faceRecognitionServer.cgi?action=doFindHistoryByPic&token=" + token + "&index=" + index + "&count=1";
        }
        #endregion

        public static IRestResponse CallAPI(Method method, string API, int TimeOut)
        {
            var client = new RestClient(API);
            client.Authenticator = new DigestAuthenticator(StaticPool.ServerUsername, StaticPool.ServerPassword);
            client.Timeout = TimeOut;
            var request = new RestRequest(method);
            var response = client.Execute(request);
            if (!response.IsSuccessful)
            {
                client = new RestClient(API);
                client.Authenticator = new DigestAuthenticator(StaticPool.ServerUsername, StaticPool.ServerPassword);
                client.Timeout = TimeOut;
                request = new RestRequest(method);
                response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    return null;
                }
            }
            return response;
        }

        public static IRestResponse CallAPIWithImage(Method method, string API, int timeOut, string imagePath)
        {
            var client = new RestClient(API);
            client.Authenticator = new DigestAuthenticator(StaticPool.ServerUsername, StaticPool.ServerPassword);
            client.Timeout = timeOut;
            var request = new RestRequest(method);
            request.AddFile("Image", Path.GetFullPath(imagePath), "image/jpeg");
            var response = client.Execute(request);
            if (!response.IsSuccessful)
            {
                client = new RestClient(API);
                client.Authenticator = new DigestAuthenticator(StaticPool.ServerUsername, StaticPool.ServerPassword);
                client.Timeout = timeOut;
                request = new RestRequest(method);
                request.AddFile("Image", Path.GetFullPath(imagePath), "image/jpeg");
                response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    return null;
                }
            }
            return response;
        }
        private static string GetData(string data)
        {
            return data.Substring(data.IndexOf("=") + 1);
        }

    }
}
