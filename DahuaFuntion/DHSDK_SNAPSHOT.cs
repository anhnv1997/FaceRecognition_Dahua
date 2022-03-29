
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DHSDK
{
    public class DHSDK_SNAPSHOT
    {
        //[DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        //public static extern bool CLIENT_SnapPictureEx(IntPtr lLoginID, ref DHSDK_STRUCT.NET_SNAP_PARAMS par);
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern bool CLIENT_CapturePicture(IntPtr hPlayHandle, string pchPicFileName, DHSDK_ENUM.NET_CAPTURE_FORMATS eFormat);


    }
}
