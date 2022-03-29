using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DHSDK
{
    public class DHSDK_Init
    {
        public delegate void DISCONNECT_CALLBACK(IntPtr lLoginID, IntPtr pchDVRIP, Int32 nDVRPort, IntPtr dwUser);
        /// <summary>
        /// SDK Init
        /// </summary>
        /// <param name="cbDisConnect"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern bool CLIENT_Init(DISCONNECT_CALLBACK cbDisConnect, IntPtr dwUser);

        /// <summary>
        /// SDK Get Version
        /// </summary>
        /// <returns></returns>
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern uint CLIENT_GetSDKVersion();

        /// <summary>
        /// Empty SDK, release occupied resource,call after all SDK functions
        /// </summary>
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern void CLIENT_Cleanup();

        /// <summary>
        /// Get Error function
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern Int64 CLIENT_GetLastError();        

        /// <summary>
        /// Delegate to Reconnect Function
        /// </summary>
        /// <param name="lLoginID"></param>
        /// <param name="pchDVRIP"></param>
        /// <param name="nDVRPort"></param>
        /// <param name="dwUser"></param>
        public delegate void RECONNECT_CALLBACK(IntPtr lLoginID, IntPtr pchDVRIP, Int32 nDVRPort, IntPtr dwUser);
        /// <summary>
        /// Set Reconnect to device when disconnect 
        /// </summary>
        /// <param name="cbAutoConnect"></param>
        /// <param name="dwUser"></param>
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern void CLIENT_SetAutoReconnect(RECONNECT_CALLBACK cbAutoConnect, IntPtr dwUser);

        /// <summary>
        /// Set connect time 
        /// </summary>
        /// <param name="nWaitTime"></param>
        /// <param name="nTryTimes"></param>
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern void CLIENT_SetConnectTime(int nWaitTime, int nTryTimes);

        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern void CLIENT_SetNetworkParam(ref DHSDK_STRUCT.BURNNG_PARM pNetParam);

    }
}
