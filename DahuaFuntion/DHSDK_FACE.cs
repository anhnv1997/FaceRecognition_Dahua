using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DHSDK
{
    public class DHSDK_FACE
    {
        #region:Interfaces of adding/deleting/modifying/searching the face library
        /// <summary>
        /// Add, delete and modify the face library
        /// </summary>
        /// <param name="lLoginID">Login handle</param>
        /// <param name="pstInParam">Input parameter</param>
        /// <param name="pstOutParam">Output parameter.</param>
        /// <param name="nWaitTime">Timeout</param>
        /// <returns>Success: TRUE. Failure: FALSE</returns>
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern bool CLIENT_OperateFaceRecognitionGroup(IntPtr lLoginID, ref DHSDK_STRUCT.NET_IN_OPERATE_FACERECONGNITION_GROUP pstInParam, ref DHSDK_STRUCT.NET_OUT_OPERATE_FACERECONGNITION_GROUP pstOutParam, int nWaitTime);
       
        
        /// <summary>
        /// Searching the of face library.
        /// </summary>
        /// <param name="lLoginID">Login handle</param>
        /// <param name="pstInParam">Input parameter</param>
        /// <param name="pstOutParam">Output parameter.</param>
        /// <param name="nWaitTime">Timeout</param>
        /// <returns>Success: TRUE. Failure: FALSE</returns>
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern bool CLIENT_FindGroupInfo(IntPtr lLoginID, ref DHSDK_STRUCT.NET_IN_FIND_GROUP_INFO pstInParam, ref DHSDK_STRUCT.NET_OUT_FIND_GROUP_INFO pstOutParam, int nWaitTime);

        #endregion
        #region: Interfaces of adding/deleting/modifying/searching people face
        // <summary>
        /// Add, delete and modify the people face
        /// </summary>
        /// <param name="lLoginID">Login handle</param>
        /// <param name="pstInParam">Input parameter</param>
        /// <param name="pstOutParam">Output parameter.</param>
        /// <param name="nWaitTime">Timeout</param>
        /// <returns>Success: TRUE. Failure: FALSE</returns>
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern bool CLIENT_OperateFaceRecognitionDB(IntPtr lLoginID, ref DHSDK_STRUCT.NET_IN_OPERATE_FACERECONGNITIONDB pstInParam, ref DHSDK_STRUCT.NET_OUT_OPERATE_FACERECONGNITIONDB pstOutParam, Int32 nWaitTime);
        /// <summary>
        /// Set the searching conditions of people face
        /// </summary>
        /// <param name="lLoginID">Login handle</param>
        /// <param name="pstInParam">Input parameter</param>
        /// <param name="pstOutParam">Output parameter.</param>
        /// <param name="nWaitTime">Timeout</param>
        /// <returns>Success: TRUE. Failure: FALSE</returns>
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern bool CLIENT_StartFindFaceRecognition(IntPtr lLoginID, ref DHSDK_STRUCT.NET_IN_STARTFIND_FACERECONGNITION pstInParam, ref DHSDK_STRUCT.NET_OUT_STARTFIND_FACERECONGNITION pstOutParam, int waittime);

        #endregion
    }
}
