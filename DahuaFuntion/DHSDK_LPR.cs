using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DHSDK
{
    public class DHSDK_LPR
    {
        public delegate int fAnalyzerDataCallBack(IntPtr lAnalyzerHandle, uint dwEventType, IntPtr pEventInfo, IntPtr pBuffer, uint dwBufSize, IntPtr dwUser, int nSequence, IntPtr reserved);
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern IntPtr CLIENT_RealLoadPictureEx(Int64 lLoginID, int nChannelID, uint dwAlarmType, bool bNeedPicFile, fAnalyzerDataCallBack cbAnalyzerData, IntPtr dwUser);

        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern Int64 CLIENT_RealLoadPicture(Int64 lLoginID, int nChannelID, uint dwAlarmType, fAnalyzerDataCallBack cbAnalyzerData, IntPtr dwUser);

        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern bool CLIENT_StopLoadPic(Int64 lAnalyzerHandle);
    }
}
