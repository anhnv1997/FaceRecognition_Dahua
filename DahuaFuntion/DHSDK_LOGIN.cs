using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DHSDK
{
    public class DHSDK_LOGIN
    {
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern IntPtr CLIENT_LoginWithHighLevelSecurity(ref DHSDK_STRUCT.NET_IN_LOGIN_WITH_HIGHLEVEL_SECURITY pstInParam,ref DHSDK_STRUCT.NET_OUT_LOGIN_WITH_HIGHLEVEL_SECURITY pstOutParam);
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern bool CLIENT_Logout(Int64 lLoginID);
    }
}
