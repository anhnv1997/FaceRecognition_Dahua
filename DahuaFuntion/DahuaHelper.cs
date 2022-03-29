using DHSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.DahuaFuntion
{
    public class DahuaHelper
    {
        //Login
        public static bool LoginCameraDahua(string IP, int Port, string Username, string Password, ref long userID, ref string errorMessage)
        {
            DHSDK_STRUCT.NET_IN_LOGIN_WITH_HIGHLEVEL_SECURITY paramIn = new DHSDK_STRUCT.NET_IN_LOGIN_WITH_HIGHLEVEL_SECURITY();
            paramIn.dwSize = (uint)Marshal.SizeOf(paramIn);
            paramIn.szUserName = Username;
            paramIn.szPassword = Password;
            paramIn.nPort = Port;
            paramIn.szIP = IP;
            paramIn.emSpecCap = DHSDK_ENUM.EM_LOGIN_SPAC_CAP_TYPE.EM_LOGIN_SPEC_CAP_TCP;
            DHSDK_STRUCT.NET_OUT_LOGIN_WITH_HIGHLEVEL_SECURITY paramOut = new DHSDK_STRUCT.NET_OUT_LOGIN_WITH_HIGHLEVEL_SECURITY();
            paramOut.dwSize = (uint)Marshal.SizeOf(paramOut);
            paramOut.stuDeviceInfo = new DHSDK_STRUCT.NET_DEVICEINFO_Ex();
            userID = (long)DHSDK_LOGIN.CLIENT_LoginWithHighLevelSecurity(ref paramIn, ref paramOut);
            if (userID == 0)
            {
                Int64 lastError = DHSDK_Init.CLIENT_GetLastError() & 0x7FFFFFFF;
                errorMessage = "Start Real Play Error: " + lastError;
                return false;
            }
            return true;
        }
        public static bool LiveviewCameraDahua(ref long userID, int channel, IntPtr handle, ref long m_lRealHandle, ref string errorMessage)
        {
            m_lRealHandle = (long)DHSDK_LIVEVIEW.CLIENT_RealPlay(userID, channel, handle);
            if (m_lRealHandle <= 0)
            {
                m_lRealHandle = (long)DHSDK_LIVEVIEW.CLIENT_RealPlay(userID, channel, handle);
                if (m_lRealHandle <= 0)
                {
                    Int64 lastError = DHSDK_Init.CLIENT_GetLastError() & 0x7FFFFFFF;
                    errorMessage = "Start Real Play Error: " + lastError;
                    return false;
                }
            }
            DHSDK_LIVEVIEW.CLIENT_RenderPrivateData((IntPtr)m_lRealHandle, true);
            return true;
        }
        public static bool LogoutCameraDahua(ref long userID, ref string errorMessage)
        {
            if (!DHSDK_LOGIN.CLIENT_Logout(userID))
            {
                Int64 lastError = DHSDK_Init.CLIENT_GetLastError() & 0x7FFFFFFF;
                errorMessage = "Start Real Play Error: " + lastError;
                return false;
            }
            userID = 0;
            return true;
        }
        public static bool StopLiveviewCameraDahua(ref long m_lRealHandle, ref string errorMessage)
        {
            if (m_lRealHandle > 0)
            {
                if (!DHSDK_LIVEVIEW.CLIENT_StopRealPlay(m_lRealHandle))
                {
                    if (!DHSDK_LIVEVIEW.CLIENT_StopRealPlay(m_lRealHandle))
                    {
                        Int64 lastError = DHSDK_Init.CLIENT_GetLastError() & 0x7FFFFFFF;
                        errorMessage = "Start Real Play Error: " + lastError;
                        return false;
                    }
                }
                else
                {
                    m_lRealHandle = 0;
                    return true;
                }
            }
            return true;
        }
        /// <summary>
        /// SetDefaultCameraview
        /// </summary>
        /// <param name="userID">userId when login success</param>
        /// <param name="CameraLiveViewHandle">handle to show live view</param>
        /// <param name="m_lRealHandle"></param>
        /// <param name="errorMessage">return if error</param>
        /// <param name="channel">Default Channel to live view</param>
        public static void SetDefaultCameraview(Int64 userID, IntPtr CameraLiveViewHandle, ref Int64 m_lRealHandle, ref string errorMessage, int channel)
        {
            if (userID > 0)
            {
                if (!LiveviewCameraDahua(ref userID, channel, CameraLiveViewHandle, ref m_lRealHandle, ref errorMessage))
                {
                    Int64 lastError = DHSDK_Init.CLIENT_GetLastError() & 0x7FFFFFFF;
                    errorMessage = "Start Real Play Error: " + lastError;
                }
            }
        }
        
    }
}
