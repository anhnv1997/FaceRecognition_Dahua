using FaceRecognition.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Databases
{
    public class tblCamera
    {
        private const string TBL_CAMERA_NAME = "tblCamera";
        private const string TBL_CAMERA_COL_ID= "ID";
        private const string TBL_CAMERA_COL_NAME = "Name";
        private const string TBL_CAMERA_COL_CODE = "Code";
        private const string TBL_CAMERA_COL_TYPE = "Type";
        private const string TBL_CAMERA_COL_COM = "Com";
        private const string TBL_CAMERA_COL_IP = "IP";
        private const string TBL_CAMERA_COL_PORT = "Port";
        private const string TBL_CAMERA_COL_USERNAME = "Username";
        private const string TBL_CAMERA_COL_PASSWORD = "Password";
        private const string TBL_CAMERA_COL_CHANNEL = "Channel";

        //Get
        public static CameraCollection LoadDataCamera(CameraCollection cameraCollection)
        {
            DataTable dtCamera = StaticPool.mdb.FillData($"Select * from {TBL_CAMERA_NAME} order by {TBL_CAMERA_COL_ID}");
            cameraCollection.Clear();
            if (dtCamera != null && dtCamera.Rows.Count > 0)
            {
                foreach (DataRow row in dtCamera.Rows)
                {
                    Camera cam = new Camera();
                    cam.Id = row[TBL_CAMERA_COL_ID].ToString();
                    cam.Name = row[TBL_CAMERA_COL_NAME].ToString();
                    cam.Code = row[TBL_CAMERA_COL_CODE].ToString();
                    cam.Type = Convert.ToInt32(row[TBL_CAMERA_COL_TYPE].ToString());
                    cam.Com = Convert.ToInt32(row[TBL_CAMERA_COL_COM].ToString());
                    cam.IP = row[TBL_CAMERA_COL_IP].ToString();
                    cam.Port = Convert.ToInt32(row[TBL_CAMERA_COL_PORT].ToString());
                    cam.Username = row[TBL_CAMERA_COL_USERNAME].ToString();
                    cam.Password = row[TBL_CAMERA_COL_PASSWORD].ToString();
                    cam.Channel = Convert.ToInt32(row[TBL_CAMERA_COL_CHANNEL].ToString());
                    cameraCollection.Add(cam);
                }
                dtCamera.Dispose();
                return cameraCollection;
                
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(string name,string code,int type,int com,string ip,int port,string username,string password,int channel)
        {
            DataTable dtbLastID = StaticPool.mdb.FillData($"Insert into {TBL_CAMERA_NAME}({TBL_CAMERA_COL_NAME},{TBL_CAMERA_COL_CODE},{TBL_CAMERA_COL_TYPE},{TBL_CAMERA_COL_COM},{TBL_CAMERA_COL_IP},{TBL_CAMERA_COL_PORT},{TBL_CAMERA_COL_USERNAME},{TBL_CAMERA_COL_PASSWORD},{TBL_CAMERA_COL_CHANNEL}) " +
                $"values(N'{name}',N'{code}',{type},{com},'{ip}',{port},'{username}','{password}',{channel}) select SCOPE_IDENTITY() as {TBL_CAMERA_COL_ID}");

            if ((dtbLastID == null))
            {
                dtbLastID = StaticPool.mdb.FillData($"Insert into {TBL_CAMERA_NAME}({TBL_CAMERA_COL_NAME},{TBL_CAMERA_COL_CODE},{TBL_CAMERA_COL_TYPE},{TBL_CAMERA_COL_COM},{TBL_CAMERA_COL_IP},{TBL_CAMERA_COL_PORT},{TBL_CAMERA_COL_USERNAME},{TBL_CAMERA_COL_PASSWORD},{TBL_CAMERA_COL_CHANNEL}) " +
                $"values(N'{name}',N'{code}',{type},{com},'{ip}',{port},'{username}','{password}',{channel}) select SCOPE_IDENTITY() as {TBL_CAMERA_COL_ID}");
                if ((dtbLastID == null))
                {
                    return "";
                }
            }
            return dtbLastID.Rows[0]["ID"].ToString();
        }
        //Modify
        public static bool Modify(int id, string name, string code, int type, int com, string ip, int port, string username, string password, int channel)
        {
            if (!StaticPool.mdb.ExecuteCommand($"update {TBL_CAMERA_NAME} set {TBL_CAMERA_COL_NAME} =N'{name}',{TBL_CAMERA_COL_CODE}=N'{code}',{TBL_CAMERA_COL_TYPE}={type},{TBL_CAMERA_COL_COM}={com},{TBL_CAMERA_COL_IP}='{ip}'," +
                $"{TBL_CAMERA_COL_PORT}={port},{TBL_CAMERA_COL_USERNAME}='{username}',{TBL_CAMERA_COL_PASSWORD}='{password}',{TBL_CAMERA_COL_CHANNEL}={channel} Where {TBL_CAMERA_COL_ID} = {id}"))
            {
                if (!StaticPool.mdb.ExecuteCommand($"update {TBL_CAMERA_NAME} set {TBL_CAMERA_COL_NAME} =N'{name}',{TBL_CAMERA_COL_CODE}=N'{code}',{TBL_CAMERA_COL_TYPE}={type},{TBL_CAMERA_COL_COM}={com},{TBL_CAMERA_COL_IP}='{ip}'," +
               $"{TBL_CAMERA_COL_PORT}={port},{TBL_CAMERA_COL_USERNAME}='{username}',{TBL_CAMERA_COL_PASSWORD}='{password}',{TBL_CAMERA_COL_CHANNEL}={channel} Where {TBL_CAMERA_COL_ID} = {id}"))
                {
                    return false;
                }
            }
            return true;
        }
        //Delete
        public static bool Delete(string cameraID)
        {
            if(!StaticPool.mdb.ExecuteCommand($"Delete {TBL_CAMERA_NAME} where {TBL_CAMERA_COL_ID}={cameraID}"))
            {
                if (!StaticPool.mdb.ExecuteCommand($"Delete {TBL_CAMERA_NAME} where {TBL_CAMERA_COL_ID}={cameraID}"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
