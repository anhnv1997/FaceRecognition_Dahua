using FaceRecognition.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Databases
{
    public class tblGroupFace
    {
        private const string TBL_GROUPFACE_NAME = "tblGroup";
        private const string TBL_GROUPFACE_COL_ID = "ID";
        private const string TBL_GROUPFACE_COL_NAME = "Name";
        private const string TBL_GROUPFACE_COL_SIZE = "Size";
        private const string TBL_GROUPFACE_COL_DESCRIPTION = "Description";

        //Get
        public static string GetIdFromGroupInfo(GroupFace groupFace)
        {
            DataTable dtb = StaticPool.mdb.FillData($"Select {TBL_GROUPFACE_COL_ID} from {TBL_GROUPFACE_NAME} Where {TBL_GROUPFACE_COL_NAME} LIKE '%{groupFace.GroupName}%' And {TBL_GROUPFACE_COL_DESCRIPTION} LIKE '%{groupFace.GroupDetail}%'");
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return dtb.Rows[0][TBL_GROUPFACE_COL_ID].ToString();
            }
            return "";
        }
        //Add
        public static bool AddGroupFace(string Name, string Detail)
        {
            if (!StaticPool.mdb.ExecuteCommand(GetAddGroupFaceCmd(Name,Detail)))
            {
                if (!StaticPool.mdb.ExecuteCommand(GetAddGroupFaceCmd(Name, Detail)))
                {
                    return false;
                }
            }
            return true;
        }
        private static string GetAddGroupFaceCmd(string Name, string Detail)
        {
            return $"insert into {TBL_GROUPFACE_NAME}({TBL_GROUPFACE_COL_NAME},{TBL_GROUPFACE_COL_DESCRIPTION},{TBL_GROUPFACE_COL_SIZE}) values(N'{Name}',N'{Detail}','0')";
        }
        //Modify
        public static bool ModifyGroupFace(string groupID,string Name, string Detail, int groupSize)
        {
            if (!StaticPool.mdb.ExecuteCommand(GetModifyGroupFaceCmd(groupID,Name,Detail,groupSize)))
            {
                if (!StaticPool.mdb.ExecuteCommand(GetModifyGroupFaceCmd(groupID, Name, Detail, groupSize)))
                {
                    return false;
                }
            }
            return true;
        }
        public static string GetModifyGroupFaceCmd(string groupID, string Name, string Detail, int groupSize)
        {
            return $"update {TBL_GROUPFACE_NAME} set {TBL_GROUPFACE_COL_NAME} =N'{Name}',{TBL_GROUPFACE_COL_DESCRIPTION}=N'{Detail}',{TBL_GROUPFACE_COL_SIZE}='{groupSize}'where {TBL_GROUPFACE_COL_ID} = {groupID}";
        }
        //Delete
        public static bool DeleteGroupFace(string groupID)
        {
            if(!StaticPool.mdb.ExecuteCommand($"Delete {TBL_GROUPFACE_NAME} Where {TBL_GROUPFACE_COL_ID}={groupID}"))
            {
                if (!StaticPool.mdb.ExecuteCommand($"Delete {TBL_GROUPFACE_NAME} Where {TBL_GROUPFACE_COL_ID}={groupID}"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
