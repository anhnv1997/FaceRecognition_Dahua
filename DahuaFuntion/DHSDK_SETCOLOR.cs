using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DHSDK
{
    public class DHSDK_SETCOLOR
    {
        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern bool CLIENT_SetConfig(IntPtr lLoginID, DHSDK_ENUM.NET_EM_CFG_OPERATE_TYPE emCfgOpTypee, int nChannelID, IntPtr szInBuffer, uint dwInBufferSize, int waittime, IntPtr restart, IntPtr reserve);

        [DllImport(@".\DahuaSDK64\dhnetsdk.dll")]
        public static extern bool CLIENT_GetConfig(IntPtr lLoginID, DHSDK_ENUM.NET_EM_CFG_OPERATE_TYPE emCfgOpTypee, int nChannelID, IntPtr szInBuffer, uint dwInBufferSize, int waittime);

    }
}