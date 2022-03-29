 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DHSDK
{
    public class DHSDK_LIVEVIEW
    {
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern IntPtr CLIENT_RealPlay(Int64 lLoginID, int nChannelID, IntPtr hWnd);

        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern bool CLIENT_StopRealPlay(Int64 lRealHandle);

        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern bool CLIENT_SaveRealData(IntPtr lRealHandle,  string pchFileName);

        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern bool CLIENT_RenderPrivateData(IntPtr lPlayHandle, bool bTrue);
    }
}
