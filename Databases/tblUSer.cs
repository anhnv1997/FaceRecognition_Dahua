using FaceRecognition.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Databases
{
    public class tblUSer
    {
        private const string TBL_USER_NAME = "tblUser";
        private const string TBL_USER_COL_ID = "ID";
        private const string TBL_USER_COL_FULLNAME = "Fullname";
        private const string TBL_USER_COL_CODE = "Code";
        private const string TBL_USER_COL_USERNAME = "Username";
        private const string TBL_USER_COL_PASSWORD = "Password";
        private const string TBL_USER_COL_RIGHT = "Right1";
        private const string TBL_USER_COL_ISLOCKUSER = "isLockUser";
        public static UserCollection LoadDataUser(UserCollection userCollection)
        {
            userCollection.Clear();
            DataTable dtUser = StaticPool.mdb.FillData($"Select * from {TBL_USER_NAME} order by {TBL_USER_COL_ID}");
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    User user = new User();
                    user.ID = row[TBL_USER_COL_ID].ToString();
                    user.Fullname = row[TBL_USER_COL_FULLNAME].ToString();
                    user.Code = row[TBL_USER_COL_CODE].ToString();
                    user.Username = row[TBL_USER_COL_USERNAME].ToString();
                    user.Password = row[TBL_USER_COL_PASSWORD].ToString();
                    switch (row[TBL_USER_COL_RIGHT].ToString())
                    {
                        case "1":
                            user.Right = true;
                            break;
                        case "0":
                            user.Right = false;
                            break;
                    }
                    userCollection.Add(user);
                }
                dtUser.Dispose();
                return userCollection;
            }
            return null;
        }
    }
}
