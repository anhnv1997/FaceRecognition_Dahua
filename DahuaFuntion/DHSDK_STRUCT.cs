using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DHSDK
{
    public class DHSDK_STRUCT
    {
        public struct BURNNG_PARM
        {
            public int nWaittime;
            public int nConnectTime;
            public int nConnectTryNum;
            public int nSubConnectSpaceTime;
            public int nGetDevInfoTime;
            public int nConnectBufSize;
            public int nGetConnInfoTime;
            public int nSearchRecordTime;
            public int nsubDisconnetTime;
            public byte byNetType;
            public byte byPlaybackBufSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byReserved1;
            public int nPicBufSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] bReserved;
        }
        public struct NET_IN_LOGIN_WITH_HIGHLEVEL_SECURITY
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szIP;
            public int nPort;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szUserName;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szPassword;
            public DHSDK_ENUM.EM_LOGIN_SPAC_CAP_TYPE emSpecCap;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] byReserved;
            public IntPtr pCapParam;
        }

        public struct NET_OUT_LOGIN_WITH_HIGHLEVEL_SECURITY
        {
            public uint dwSize;
            public NET_DEVICEINFO_Ex stuDeviceInfo;
            public int nError;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 132, ArraySubType = UnmanagedType.I1)]
            public byte[] byReserved;
        }

        public struct NET_DEVICEINFO_Ex
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 48, ArraySubType = UnmanagedType.I1)]
            public byte[] sSerialNumber;
            public int nAlarmInPortNum;
            public int nAlarmOutPortNum;
            public int nDiskNum;
            public int nDVRType;
            public int nChanNum;
            public byte byLimitLoginTime;
            public byte byLeftLogTimes;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] bReserved;
            public int nLockLeftTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] Reserved;
        }

        //*******************************************************************
        //XU LY SKIEN NHAN BIEN SO XE****************************************
        public struct DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] szPlateNumber;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szPlateType;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szPlateColor;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szVehicleColor; 
            public int nSpeed;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] szEvent;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] szViolationCode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] szViolationDesc;
            public int nLowerSpeedLimit;
            public int nUpperSpeedLimit;
            public int nOverSpeedMargin;
            public int nUnderSpeedMargin;
            public int nLane;
            public int nVehicleSize;
            public float fVehicleLength;
            public int nSnapshotMode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] szChannelName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] szMachineName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] szMachineGroup;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] szRoadwayNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 256)]
            public byte[] szDrivingDirection;
            public IntPtr szDeviceAddress;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] byReserved;
        }

        public struct DH_RESOLUTION_INFO
        {
            public ushort snWidth;
            public ushort snHight; }
        public struct DH_RECT { 
            public long left; 
            public long top; 
            public long right; 
            public long bottom; }

        public struct DH_POINT { 
            public int nx; 
            public int ny; }
        public struct DH_PIC_INFO
        {
            public uint dwOffSet; 
            public uint dwFileLenth; 
            public uint wWidth;
            public uint wHeight;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            byte[] bReserved;
        };
        public struct DH_MSG_OBJECT
        {
            public int nObjectID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public byte[] szObjectType;
            public int nConfidence;
            public int nAction; 
            public DH_RECT BoundingBox;
            public DH_POINT Center;
            public int nPolygonNum;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public DH_POINT[] Contour;
            public uint rgbaMainColor;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szText;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] szObjectSubType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]            
            public byte[] byReserved1;
            public bool bPicEnble;
            public DH_PIC_INFO stPicInfo;
            public bool bShotFrame;
            public bool bColor;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] byReserved2;
            public NET_TIME_EX stuCurrentTime;
            public NET_TIME_EX stuStartTime;
            public NET_TIME_EX stuEndTime;
            public DH_RECT stuOriginalBoundingBox;
            public DH_RECT stuSignBoundingBox;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 78)]
            public byte[] byReserved;
        };

        public struct DH_EVENT_FILE_INFO
        {
            public byte bCount; 
            public byte bIndex;
            public byte bFileTag; 
            public byte bReserved_Byte;
            public NET_TIME_EX stuFileTime; 
            public int nGroupId;
        };

        public struct NET_TIME_EX
        {
            public uint dwYear; 
            public uint dwMonth; 
            public uint dwDay; 
            public uint dwHour;
            public uint dwMinute;
            public uint dwSecond; 
            public uint dwMillisecond;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public uint[] dwReserved;
        };
        public struct DEV_EVENT_TRAFFICJUNCTION_INFO
        {
            public int nChannelID;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] bReserved1;
            public double PTS;
            public NET_TIME_EX UTC;
            public int nEventID;
            public DH_MSG_OBJECT stuObject;
            public int nLane; 
            public uint dwBreakingRule;
            public NET_TIME_EX RedLightUTC;
            public DH_EVENT_FILE_INFO stuFileInfo;
            public int nSequence;
            public int nSpeed;
            public byte bEventAction;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] byReserved;
            public DH_MSG_OBJECT stuVehicle; 
            public uint dwSnapFlagMask;
            public DH_RESOLUTION_INFO stuResolution;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 472)]
            public byte[] bReserved;
            public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;
        }

        /// //////////////////////////////////////////////////////////////////////////

        public struct DEV_EVENT_FACEDETECT_INFO
        {
            /// <summary>
            /// channel ID
            /// 通道号
            /// </summary>
            public int nChannelID;

            public byte byAge;
            /// <summary>
            /// event name
            /// 事件名称
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szName;
            /// <summary>
            /// byte alignment
            /// 字节对齐
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] bReserved1;
            /// <summary>
            /// PTS(ms)
            /// 时间戳(单位是毫秒)
            /// </summary>
            public double PTS;
            /// <summary>
            /// the event happen time
            /// 事件发生的时间
            /// </summary>
            public NET_TIME_EX UTC;
            /// <summary>
            /// event ID
            /// 事件ID
            /// </summary>
            public int nEventID;
            /// <summary>
            /// have being detected object
            /// 检测到的物体
            /// </summary>
            public DH_MSG_OBJECT stuObject;
            /// <summary>
            /// event file info
            /// 事件对应文件信息
            /// </summary>
            public DH_EVENT_FILE_INFO stuFileInfo;
            /// <summary>
            /// Event action: 0 means pulse event,1 means continuous event's begin,2means continuous event's end
            /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
            /// </summary>
            public byte bEventAction;
            /// <summary>
            /// reserved
            /// 保留字节
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] reserved;
            /// <summary>
            /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
            /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
            /// </summary>
            public byte byImageIndex;
            /// <summary>
            /// detect region point number
            /// 规则检测区域顶点数
            /// </summary>
            public int nDetectRegionNum;
            /// <summary>
            /// detect region
            /// 规则检测区域
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public DH_POINT[] DetectRegion;
            /// <summary>
            /// flag(by bit),see NET_RESERVED_COMMON
            /// 抓图标志(按位),具体见NET_RESERVED_COMMON  
            /// </summary>
            public uint dwSnapFlagMask;
            /// <summary>
            /// snapshot current face device address
            /// 抓拍当前人脸的设备地址
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szSnapDevAddress;
            /// <summary>
            /// event trigger accumilated times 
            /// 事件触发累计次数
            /// </summary>
            public uint nOccurrenceCount;
            /// <summary>
            /// sex type
            /// 性别
            /// </summary>
            public EM_DEV_EVENT_FACEDETECT_SEX_TYPE emSex;
            /// <summary>
            
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szCameraID;
            /// <summary>
            /// Reserved
            /// 保留字节
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 416)]
            public byte[] bReserved;
        }
        public enum EM_DEV_EVENT_FACEDETECT_SEX_TYPE
        {
            /// <summary>
            /// unknown
            /// 未知
            /// </summary>
            MAN,
            /// <summary>
            /// male
            /// 男性
            /// </summary>
            UNKNOWN,
            /// <summary>
            /// female
            /// 女性
            /// </summary>
            WOMAN,
        }
        #region: Face Library
        #region: Create Database


        public struct FACERECOGNITION_PERSON_INFO
        {
            /// <summary>
            /// name
            /// 姓名
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string szPersonName;
            
            /// <summary>
            /// birth year
            /// 出生年,作为查询条件时,此参数填0,则表示此参数无效
            /// </summary>
            public ushort wYear;
            /// <summary>
            /// birth month
            /// 出生月,作为查询条件时,此参数填0,则表示此参数无效
            /// </summary>
            public byte byMonth;
            /// <summary>
            /// birth day
            /// 出生日,作为查询条件时,此参数填0,则表示此参数无效
            /// </summary>
            public byte byDay;
            /// <summary>
            /// the unicle ID for the person
            /// 人员唯一标示(身份证号码,工号,或其他编号)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szID;
            /// <summary>
            /// importance level,1~10,the higher value the higher level
            /// 人员重要等级,1~10,数值越高越重要,作为查询条件时,此参数填0,则表示此参数无效
            /// </summary>
            public byte bImportantRank;
            /// <summary>
            /// sex, 1-man, 2-female
            /// 性别,1-男,2-女,作为查询条件时,此参数填0,则表示此参数无效
            /// </summary>
            public byte bySex;
            /// <summary>
            /// picture number
            /// 图片张数
            /// </summary>
            public ushort wFacePicNum;
            /// <summary>
            /// picture info
            /// 当前人员对应的图片信息
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
            public DH_PIC_INFO[] szFacePicInfo;
            /// <summary>
            /// Personnel types, see EM_PERSON_TYPE
            /// 人员类型,详见 EM_PERSON_TYPE
            /// </summary>
            public byte byType;
            /// <summary>
            /// Document types, see EM_CERTIFICATE_TYPE
            /// 证件类型,详见 EM_CERTIFICATE_TYPE
            /// </summary>
            public byte byIDType;
            /// <summary>
            /// Whether wear glasses or not,0-unknown,1-not wear glasses,2-wear glasses
            /// 是否戴眼镜，0-未知 1-不戴 2-戴
            /// </summary>
            public byte byGlasses;
            /// <summary>
            /// Age,0 means unknown
            /// 年龄,0表示未知
            /// </summary>
            public byte byAge;
            /// <summary>
            /// province
            /// 省份
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szProvince;
            /// <summary>
            /// city
            /// 城市
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szCity;
            /// <summary>
            /// Name, the name is too long due to the presence of 16 bytes can not be Storage problems, the increase in this parameter
            /// 姓名,因存在姓名过长,16字节无法存放问题,故增加此参数
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szPersonNameEx;
            /// <summary>
            /// person unique ID
            /// 人员唯一标识符,首次由服务端生成,区别于ID字段,修改,删除操作时必填
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szUID;
            /// <summary>
            /// country
            /// 国籍
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
            public string szCountry;
            /// <summary>
            /// using person type: 0 using byType, 1 using szPersonName
            /// 人员类型是否为自定义
            /// </summary>
            public byte byIsCustomType;
            /// <summary>
            /// comment info
            /// 备注信息
            /// </summary>
            public IntPtr pszComment;
            /// <summary>
            /// Group ID
            /// 人员所属组ID
            /// </summary>
            public IntPtr pszGroupID;
            /// <summary>
            /// Group Name
            /// 人员所属组名
            /// </summary>
            public IntPtr pszGroupName;
            /// <summary>
            /// the face feature 
            /// 人脸特征 
            /// </summary>
            public IntPtr pszFeatureValue;
            /// <summary>
            /// len of pszGroupID
            /// pszGroupID的长度
            /// </summary>
            public byte bGroupIdLen;
            /// <summary>
            /// len of pszGroupName
            /// pszGroupName的长度
            /// </summary>
            public byte bGroupNameLen;
            /// <summary>
            /// len of pszFeatureValue
            /// pszFeatureValue的长度 128
            /// </summary>
            public byte bFeatureValueLen;
            /// <summary>
            /// len of pszComment
            /// pszComment的长度
            /// </summary>
            public byte bCommentLen;
            /// <summary>
            /// Emotion
            /// 表情
            /// </summary>			
            public DHSDK_ENUM.EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE emEmotion;
        }
        public struct NET_CUSTOM_PERSON_INFO
        {
            /// <summary>
            /// 人员扩展信息
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szPersonInfo;
            /// <summary>
            /// 保留字节
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
            public byte[] byReserved;
        }
        public struct NET_FACE_PIC_INFO
        {
            /// <summary>
            /// 文件在二进制数据块中的偏移位置, 单位:字节
            /// </summary>
            public uint dwOffSet;
            /// <summary>
            /// 文件大小, 单位:字节
            /// </summary>
            public uint dwFileLenth;
            /// <summary>
            /// 图片宽度, 单位:像素
            /// </summary>
            public uint dwWidth;
            /// <summary>
            /// 图片高度, 单位:像素
            /// </summary>
            public uint dwHeight;
            /// <summary>
            /// 图片是否算法检测出来的检测过的提交识别服务器时
            /// 则不需要再时检测定位抠图,1:检测过的,0:没有检测过
            /// </summary>
            public bool bIsDetected;
            /// <summary>
            /// 文件路径长度 既 pszFilePath 的大小
            /// </summary>
            public int nFilePathLen;
            /// <summary>
            /// 文件路径,  由用户申请空间, 作为输入条件时不需要
            /// </summary>
            public IntPtr pszFilePath;
            /// <summary>
            /// 图片ID, 针对一人多人脸的情况, 用于区分不同人脸
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szPictureID;
            /// <summary>
            /// 图片建模状态
            /// </summary>
            public DHSDK_ENUM.EM_PERSON_FEATURE_STATE emFeatureState;
            /// <summary>
            /// 建模失败原因
            /// </summary>
            public DHSDK_ENUM.EM_PERSON_FEATURE_ERRCODE emFeatureErrCode;
            /// <summary>
            /// 图片操作类型
            /// </summary>
            public DHSDK_ENUM.EM_PIC_OPERATE_TYPE emPicOperate;
            /// <summary>
            /// 预留字节
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] bReserved;
        }
        //2111111111111111111111111111111111111111111111111111
        public struct NET_FACERECOGNITION_PERSON_INFOEX
        {
            /// <summary>
            /// person name
            /// 姓名
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szPersonName;
            /// <summary>
            /// birth year, fill 0 is invalid, when is as a query condition
            /// 出生年,作为查询条件时,此参数填0,则表示此参数无效
            /// </summary>
            public ushort wYear;
            /// <summary>
            /// birth month, fill 0 is invalid, when is as a query condition
            /// 出生月,作为查询条件时,此参数填0,则表示此参数无效
            /// </summary>
            public byte byMonth;
            /// <summary>
            /// birth day, fill 0 is invalid, when is as a query condition
            /// 出生日,作为查询条件时,此参数填0,则表示此参数无效
            /// </summary>
            public byte byDay;
            /// <summary>
            /// sex, 0-man, 1-female. fill 0 is invalid, when is as a query condition
            /// 人员重要等级,1~10,数值越高越重要,作为查询条件时,此参数填0,则表示此参数无效
            /// </summary>
            public byte bImportantRank;
            /// <summary>
            /// the unicle ID for the person
            /// 性别,1-男,2-女,作为查询条件时,此参数填0,则表示此参数无效
            /// </summary>
            public byte bySex;
            /// <summary>
            /// importance level,1~10,the higher value the higher level. fill 0 is invalid, when is as a query condition
            /// 人员唯一标示(身份证号码,工号,或其他编号)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szID;
            /// <summary>
            /// picture number
            /// 图片张数
            /// </summary>
            public ushort wFacePicNum;
            /// <summary>
            /// picture info
            /// 当前人员对应的图片信息
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
            public DH_PIC_INFO[] szFacePicInfo;
            /// <summary>
            /// Personnel types, see EM_PERSON_TYPE
            /// 人员类型,详见 EM_PERSON_TYPE
            /// </summary>
            public byte byType;
            /// <summary>
            /// Document types, see EM_CERTIFICATE_TYPE
            /// 证件类型,详见 EM_CERTIFICATE_TYPE
            /// </summary>
            public byte byIDType;
            /// <summary>
            /// Whether wear glasses or not,0-unknown,1-not wear glasses,2-wear glasses	
            /// 是否戴眼镜，0-未知 1-不戴 2-戴
            /// </summary>
            public byte byGlasses;
            /// <summary>
            /// Age,0 means unknown
            /// 年龄,0表示未知 
            /// </summary>	
            public byte byAge;
            /// <summary>
            /// province
            /// 省份
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szProvince;
            /// <summary>
            /// city
            /// 城市
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szCity;
            /// <summary>
            /// person unique ID
            /// 人员唯一标识符,首次由服务端生成,区别于ID字段,修改,删除操作时必填
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szUID;
            /// <summary>
            /// country
            ///  国籍,符合ISO3166规范
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
            public string szCountry;
            /// <summary>
            /// using person type: 0 using byType, 1 using CustomType
            /// 人员类型是否为自定义: 0 使用Type规定的类型 1 自定义,使用szPersonName字段
            /// </summary>
            public byte byIsCustomType;
            /// <summary>
            /// custom type of person	
            /// 人员自定义类型
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string szCustomType;
            /// <summary>
            /// comment info
            /// 备注信息
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
            public string szComment;
            /// <summary>
            /// group ID
            /// 人员所属组ID
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szGroupID;
            /// <summary>
            /// group name
            /// 人员所属组名, 用户自己申请内存的情况时
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szGroupName;
            /// <summary>
            /// Emotion
            /// 表情
            /// </summary>
            public DHSDK_ENUM.EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE emEmotion;
            /// <summary>
            ///  home address of the person
            /// 注册人员家庭地址
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szHomeAddress;
            /// <summary>
            /// glasses type
            /// 眼镜类型
            /// </summary>
            public DHSDK_ENUM.EM_GLASSES_TYPE emGlassesType;
            public DHSDK_ENUM.EM_RACE_TYPE emRace;
            /// <summary>
            /// eye state
            /// 眼睛状态
            /// </summary>
            public DHSDK_ENUM.EM_EYE_STATE_TYPE emEye;
            /// <summary>
            /// mouth state
            /// 嘴巴状态
            /// </summary>
            public DHSDK_ENUM.EM_MOUTH_STATE_TYPE emMouth;
            /// <summary>
            /// mask state
            /// 口罩状态
            /// </summary>
            public DHSDK_ENUM.EM_MASK_STATE_TYPE emMask;
            /// <summary>
            /// beard state
            /// 胡子状态
            /// </summary>
            public DHSDK_ENUM.EM_BEARD_STATE_TYPE emBeard;
            /// <summary>
            /// attractive, -1:invalid, 0:unknown，1-100
            /// 魅力值, -1表示无效, 0未识别，识别时范围1-100,得分高魅力高
            /// </summary>
            public int nAttractive;
            /// <summary>
            /// 人员建模状态
            /// </summary>
            public DHSDK_ENUM.EM_PERSON_FEATURE_STATE emFeatureState;
            /// <summary>
            /// 是否指定年龄段
            /// </summary>
            public bool bAgeEnable;
            /// <summary>
            /// 年龄范围
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public int[] nAgeRange;
            /// <summary>
            /// 人脸特征数组有效个数,与 emFeature 结合使用, 如果为0则表示查询所有表情
            /// </summary>
            public int nEmotionValidNum;
            /// <summary>
            /// 人脸特征数组,与 byFeatureValidNum 结合使用  设置查询条件的时候使用
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public DHSDK_ENUM.EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE[] emEmotions;
            /// <summary>
            /// 注册人员信息扩展个数
            /// </summary>
            public int nCustomPersonInfoNum;
            /// <summary>
            /// 注册人员信息扩展
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public NET_CUSTOM_PERSON_INFO[] szCustomPersonInfo;
            /// <summary>
            /// 注册库类型
            /// </summary>
            public DHSDK_ENUM.EM_REGISTER_DB_TYPE emRegisterDbType;
            /// <summary>
            /// 有效期时间
            /// </summary>
            public NET_TIME_EX stuEffectiveTime;
            /// <summary>
            /// 建模失败原因
            /// </summary>
            public DHSDK_ENUM.EM_PERSON_FEATURE_ERRCODE emFeatureErrCode;
            /// <summary>
            /// 人脸图片张数
            /// </summary>
            public uint wFacePicNumEx;
            /// <summary>
            /// 当前人员对应的图片信息
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public NET_FACE_PIC_INFO[] szFacePicInfoEx;
            /// <summary>
            /// Reserved bytes
            /// 保留字节
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 532)]
            public byte[] byReserved;
        }

      //  1222222222222222222222222222222222222222222222
        public struct NET_IN_OPERATE_FACERECONGNITIONDB
        {
            public uint dwSize;
            /// <summary>
            /// Type of operation
            /// 操作类型
            /// </summary>
            public DHSDK_ENUM.EM_OPERATE_FACERECONGNITIONDB_TYPE emOperateType;
            /// <summary>
            /// Personal information
            /// 人员信息
            /// </summary>
            public FACERECOGNITION_PERSON_INFO stPersonInfo;



            /// <summary>
            /// UID amount(be used when emOperateType is DELETE_BY_UID, stPeronInfo is invalid)
            /// UID个数(emOperateType操作类型为DELETE_BY_UID时使用,stPeronInfo字段无效)
            /// </summary>
            public uint nUIDNum;
            /// <summary>
            /// Person unique mark. Generated by the server at first. Different from the ID. Alloc by user, sizeof(NET_UID_CHAR)*nUIDNum
            /// </summary>
            public IntPtr stuUIDs;



            /// <summary>
            /// Buffer address(Picture binary data)
            /// 缓冲地址(图片二进制数据)
            /// </summary>
            public IntPtr pBuffer;
            /// <summary>
            /// 缓冲数据长度
            /// </summary>
            public int nBufferLen;
            /// <summary>
            /// use stPersonInfoEx when bUsePersonInfoEx is true, otherwise use stPersonInfo
            /// 使用人员扩展信息
            /// </summary>
            public bool bUsePersonInfoEx;
            /// <summary>
            /// expansion of person information
            /// 人员信息扩展
            /// </summary>
            public NET_FACERECOGNITION_PERSON_INFOEX stPersonInfoEx;
        }

        public struct NET_OUT_OPERATE_FACERECONGNITIONDB
        {
            public UInt32 dwSize;
            /// <summary>
            /// 人员唯一标识符, 只有在操作类型为NET_FACERECONGNITIONDB_ADD时有效
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szUID;

            //emOperateType操作类型为ET_FACERECONGNITIONDB_DELETE_BY_UID时使用
            public int nErrorCodeNum; // 错误码个数
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
            public DHSDK_ENUM.EM_ERRORCODE_TYPE[] emErrorCodes;
        }
        public struct NET_UID_CHAR
        {
            /// <summary>
            /// UID contents
            /// UID内容
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szUID;
        }


        #endregion


        #region: Search Database


        public struct NET_FACE_MATCH_OPTIONS
        {
            public UInt32 dwSize;
            /// <summary>
            /// Important level 1 to 10 staff, the higher the number the more important (check important level greater than or equal to this level of staff)
            /// 人员重要等级    1~10,数值越高越重要,(查询重要等级大于等于此等级的人员)
            /// </summary>
            public UInt32 nMatchImportant;
            /// <summary>
            /// Face comparison mode, see EM_FACE_COMPARE_MODE
            /// 人脸比对模式,详见EM_FACE_COMPARE_MODE
            /// </summary>
            public DHSDK_ENUM.EM_FACE_COMPARE_MODE emMode;
            /// <summary>
            /// Face the number of regional
            /// 人脸区域个数
            /// </summary>
            public Int32 nAreaNum;
            /// <summary>
            /// Regional groupings of people face is NET_FACE_COMPARE_MODE_AREA effective when emMode
            /// 人脸区域组合,emMode为NET_FACE_COMPARE_MODE.AREA时有效
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public DHSDK_ENUM.EM_FACE_AREA_TYPE[] szAreas;
            /// <summary>
            /// Recognition accuracy (ranging from 1 to 10, with the value increases, the detection accuracy is improved, the detection rate of decline. Minimum value of 1 indicates the detection speed priority, the maximum is 10, said detection accuracy preferred. Temporarily valid only for face detection)
            /// 识别精度(取值1~10,随着值增大,检测精度提高,检测速度下降。最小值为1 表示检测速度优先,最大值为10表示检测精度优先。 暂时只对人脸检测有效)
            /// </summary>
            public Int32 nAccuracy;
            /// <summary>
            /// Similarity (must be greater than the degree of acquaintance before the report; expressed as a percentage, from 1 to 100)
            /// 相似度(必须大于该相识度才报告;百分比表示,1~100)
            /// </summary>
            public Int32 nSimilarity;
            /// <summary>
            /// Reported the largest number of candidate (based on similarity to sort candidates to take the maximum number of similarity report)
            /// 报告的最大候选个数(根据相似度进行排序,取相似度最大的候选人数报告)
            /// </summary>
            public Int32 nMaxCandidate;

            public DHSDK_ENUM.EM_FINDPIC_QUERY_MODE emQueryMode;                 // 以图搜图查询模式
            public DHSDK_ENUM.EM_FINDPIC_QUERY_ORDERED emOrdered;                 // 以图搜图结果上报排序方式
        }
        public struct NET_FACE_FILTER_CONDTION_GROUPID
        {
            /// <summary>
            /// single GroupId
            /// 单个GroupId
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szGroupId;
        }
        public struct NET_FACE_FILTER_CONDTION
        {
            public UInt32 dwSize;
            /// <summary>
            /// Start time
            /// 开始时间
            /// </summary>
            public NET_TIME_EX stStartTime;
            /// <summary>
            /// End Time
            /// 结束时间
            /// </summary>
            public NET_TIME_EX stEndTime;
            /// <summary>
            /// Place to support fuzzy matching
            /// 地点,支持模糊匹配 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szMachineAddress;
            /// <summary>
            /// The actual number of database
            /// 实际数据库个数
            /// </summary>
            public Int32 nRangeNum;
            /// <summary>
            /// To query the database type, see EM_FACE_DB_TYPE
            /// 待查询数据库类型,详见EM_FACE_DB_TYPE
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] szRange;
            /// <summary>
            /// Face to query types, see EM_FACERECOGNITION_FACE_TYPE
            /// 待查询人脸类型,详见 EM_FACERECOGNITION_FACE_TYPE
            /// </summary>
            public DHSDK_ENUM.EM_FACERECOGNITION_FACE_TYPE emFaceType;
            /// <summary>
            /// staff group  
            /// 人员组数   
            /// </summary>
            public Int32 nGroupIdNum;
            /// <summary>
            /// staff group ID 
            /// 人员组ID 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public NET_FACE_FILTER_CONDTION_GROUPID[] szGroupId;
            /// <summary>
            /// start birthday time
            /// 生日起始时间
            /// </summary>
            public NET_TIME_EX stBirthdayRangeStart;
            /// <summary>
            /// end birthday time
            /// 生日结束时间
            /// </summary>
            public NET_TIME_EX stBirthdayRangeEnd;
            /// <summary>
            /// Age range, When byAge[0] is 0 and byAge[1] is 0, it means query all age
            /// 年龄区间，当byAge[0]=0与byAge[1]=0时，表示查询全年龄
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] byAge;
            /// <summary>
            /// Reserved
            /// 保留字节对齐
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] byReserved;
            /// <summary>
            /// Emotion
            /// 表情条件
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public DHSDK_ENUM.EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE[] emEmotion;
            /// <summary>
            /// Emotion num
            /// 表情条件的个数
            /// </summary>
            public int nEmotionNum;
            public int nUIDNum;                       // 人员唯一标识数
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64 * 32)]
            public byte[] szUIDs;// 人员唯一标识列表
        }
        public struct NET_IN_STARTFIND_FACERECONGNITION
        {
            public UInt32 dwSize;
            /// <summary>
            /// is personal information valid
            /// 人员信息查询条件是否有效
            /// </summary>
            public bool bPersonEnable;
            /// <summary>
            /// personal information
            /// 人员信息查询条件
            /// </summary>
            public FACERECOGNITION_PERSON_INFO stPerson;
            /// <summary>
            /// Face Matching Options
            /// 人脸匹配选项
            /// </summary>
            public NET_FACE_MATCH_OPTIONS stMatchOptions;
            /// <summary>
            /// Query filters
            /// 查询过滤条件
            /// </summary>
            public NET_FACE_FILTER_CONDTION stFilterInfo;
            /// <summary>
            /// Buffer address(Picture binary data)
            /// 缓冲地址(图像二进制数据)
            /// </summary>
            public IntPtr pBuffer;
            /// <summary>
            /// Buffer data length
            /// 缓冲数据长度
            /// </summary>
            public Int32 nBufferLen;
            /// <summary>
            /// Channel ID 
            /// 通道号
            /// </summary>
            public Int32 nChannelID;
            /// <summary>
            /// use stPersonInfoEx when bUsePersonInfoEx is true, otherwise use stPersonInfo
            /// 人员信息查询条件是否有效, 并使用扩展结构体
            /// </summary>
            public bool bPersonExEnable;
            /// <summary>
            /// expansion of person information
            /// 人员信息扩展
            /// </summary>
            public NET_FACERECOGNITION_PERSON_INFOEX stPersonInfoEx;

            public int nSmallPicIDNum;                 // 小图ID数量
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] nSmallPicID;// 小图ID
            public DHSDK_ENUM.EM_OBJECT_TYPE emObjectType;                   // 搜索的目标类型 
        }

        public struct NET_OUT_STARTFIND_FACERECONGNITION
        {
            public UInt32 dwSize;
            /// <summary>
            /// Record number of returns that match the query criteria;-1 means device is querying,will get lately. use CLIENT_AttachFaceFindState to get status
            /// 返回的符合查询条件的记录个数;-1表示总条数未生成,要推迟获取;使用CLIENT_AttachFaceFindState接口获取状态
            /// </summary>
            public Int32 nTotalCount;
            /// <summary>
            /// Query handle
            /// 查询句柄
            /// </summary>
            public IntPtr lFindHandle;
            /// <summary>
            /// The search token received 
            /// 获取到的查询令牌
            /// </summary>
            public Int32 nToken;
        }
        #endregion
        #endregion






        #region:Interfaces of adding/deleting/modifying/searching the face library
        #region:adding/deleting/modifying
        public struct NET_FACERECONGNITION_GROUP_INFO
        {
            public uint dwSize;
            /// <summary>
            /// staff group type ,  see  EM_FACE_DB_TYPE
            /// </summary>
            public DHSDK_ENUM.EM_FACE_DB_TYPE emFaceDBType;
            /// <summary>
            /// staff group ID, SN(cannot modify, invalid when adding operation)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szGroupId;
            /// <summary>
            /// staff group name 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szGroupName;
            /// <summary>
            /// staff group remark info 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szGroupRemarks;
            /// <summary>
            /// current group staff number
            /// </summary>
            public int nGroupSize;
            /// <summary>
            /// returned similarity count
            /// </summary>
            public int nRetSimilarityCount;
            /// <summary>
            /// library similarity threshold
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
            public int[] nSimilarity;
            /// <summary>
            /// returned channel count
            /// </summary>
            public int nRetChnCount;
            /// <summary>
            /// the list of channels
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
            public int[] nChannel;
            /// <summary>
             /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public uint[] nFeatureState;
            /// <summary>
            /// </summary>
            public DHSDK_ENUM.EM_REGISTER_DB_TYPE emRegisterDbType;
            /// <summary>
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] byReserved1;
            /// <summary>
            /// </summary>
            public NET_PASSERBY_DB_CONFIG_INFO stuPasserbyDBConfig;

            public override string ToString()
            {
                return szGroupId;
            }
        }
        public struct NET_PASSERBY_DB_CONFIG_INFO
        {
            public uint dwCapacity;                     // 路人库最大注册数目
            public DHSDK_ENUM.EM_PASSERBY_DB_OVERWRITE_TYPE emOverWriteType;               // 路人库满时覆盖策略
            public NET_PASSERBY_DB_DUPLICATE_REMOVE_CONFIG_INFO stuDuplicateRemoveConfigInfo;   // 路人库去重策略配置(选填)
            public uint dwFileHoldTime;                 // 设置文件保留天数【范围：0~31】单位：天，超过时间将被删除 0：永不过期			
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] byReserved1;                  // 字节对齐
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] byReserved;                       // 字节保留
        }
        public struct NET_PASSERBY_DB_DUPLICATE_REMOVE_CONFIG_INFO
        {
            public bool bEnable;                        // 使能开关，TRUE：开 FALSE：关
            public DHSDK_ENUM.EM_PASSERBY_DB_DUPLICATE_REMOVE_TYPE emDuplicateRemoveType;  // 路人库去重策略类型	
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public NET_TSECT_ARRAY[] stuTimeSections;       // 时间段间隔(EM_DUPLICATE_REMOVE_TYPE 为 EM_DUPLICATE_REMOVE_TYPE_TIME_SLOT有效)
            public uint dwInterval;                     // 时间间隔，单位分钟（EM_DUPLICATE_REMOVE_TYPE 为 EM_DUPLICATE_REMOVE_TYPE_TIME有效）
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] byReserved1;                  // 字节保留
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] byReserved;               // 字节保留
        }
        public struct NET_TSECT_ARRAY
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public NET_TSECT[] stuTimeSection;
        }
        public struct NET_TSECT
        {
            /// <summary>
            /// Current record period . Bit means the four Enable functions. From the low bit to the high bit:Motion detection record, alarm record and general record, when Motion detection and alarm happened at the same time can record.used in NET_POS_EVENT_LINK, it means enable;
            /// </summary>
            public int bEnable;
            /// <summary>
            /// BeginHour
            /// </summary>
            public int iBeginHour;
            /// <summary>
            /// BeginMin
            /// </summary>
            public int iBeginMin;
            /// <summary>
            /// BeginSec
            /// </summary>
            public int iBeginSec;
            /// <summary>
            /// EndHour
            /// </summary>
            public int iEndHour;
            /// <summary>
            /// EndMin
            /// </summary>
            public int iEndMin;
            /// <summary>
            /// EndSec
            /// </summary>
            public int iEndSec;
        }
        public struct NET_ADD_FACERECONGNITION_GROUP_INFO
        {
            /// <summary>
            /// struct size
            /// </summary>
            public uint dwSize;
            /// <summary>
            /// staff group info
            /// </summary>
            public NET_FACERECONGNITION_GROUP_INFO stuGroupInfo;
        }
        public struct NET_MODIFY_FACERECONGNITION_GROUP_INFO
        {
            /// <summary>
            /// struct size
            /// </summary>
            public uint dwSize;
            /// <summary>
            /// staff group info
            /// </summary>
            public NET_FACERECONGNITION_GROUP_INFO stuGroupInfo;
        }

        public struct NET_DELETE_FACERECONGNITION_GROUP_INFO
        {
            /// <summary>
            /// struct size
            /// </summary>
            public uint dwSize;
            /// <summary>
            /// staff group ID, SN staff
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szGroupId;
        }
        public struct NET_IN_OPERATE_FACERECONGNITION_GROUP
        {
            /// <summary>
            /// struct size
            /// </summary>
            public uint dwSize;
            /// <summary>
            /// operate group type
            /// </summary>
            public DHSDK_ENUM.EM_OPERATE_FACERECONGNITION_GROUP_TYPE emOperateType;
            /// <summary>
            /// ADD corresponding to NET_ADD_FACERECONGNITION_GROUP_INFO,MODIFY corresponding to NET_MODIFY_FACERECONGNITION_GROUP_INFO,DELETE corresponding to NET_DELETE_FACERECONGNITION_GROUP_INFO
            /// </summary>
            public IntPtr pOPerateInfo;
        }
        public struct NET_OUT_OPERATE_FACERECONGNITION_GROUP
        {
            /// <summary>
            /// struct size
            /// </summary>
            public uint dwSize;
            /// <summary>
            /// new record staff group ID, SN staff
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szGroupId; 
        }
        #endregion
        #region: Searching
        public struct NET_IN_FIND_GROUP_INFO
        {
            public uint dwSize;
            /// <summary>
            /// Group ID, SN staff, as null means search all staff group info 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szGroupId;
        }
        public struct NET_OUT_FIND_GROUP_INFO
        {
            public uint dwSize;
            /// <summary>
            /// staff group info , apply space by user, apply to sizeof(NET_FACERECONGNITION_GROUP_INFO)*nMaxGroupNum
            /// </summary>
            public IntPtr pGroupInfos;
            /// <summary>
            /// current applied group size
            /// </summary>
            public int nMaxGroupNum;
            /// <summary>
            /// device returned staff group number 
            /// </summary>
            public int nRetGroupNum;
        }
        #endregion
        #endregion

        //////////////////////////////////////////////////////////////////////////

        ////////////////////////////SET COLOR//////////////////////////////////////////
        public struct NET_PARKINGSPACELIGHT_STATE_INFO
        {
            public uint dwSize;
            public NET_PARKINGSPACELIGHT_INFO stuSpaceFreeInfo;            // Parking space idle state lamp color
            public NET_PARKINGSPACELIGHT_INFO stuSpaceFullInfo;            // Light color of parking space occupying full state
            public NET_PARKINGSPACELIGHT_INFO stuSpaceOverLineInfo;        // Light color of pressure line in parking space
            public NET_PARKINGSPACELIGHT_INFO stuSpaceOrderInfo;           // Seat reservation state lamp color
            public NET_NETWORK_EXCEPTION_INFO stuNetWorkExceptionInfo; // Network abnormal state lamp color
        }

        public struct NET_PARKINGSPACELIGHT_INFO
        {
            public int nRed;                   // Red:		-1:invalid, 0/destory, 1/bright, 2/twinkle	
            public int nYellow;                // Yellow:  -1:invalid, 0/destory, 1/bright, 2/twinkle	
            public int nBlue;                  // Blue:	-1:invalid, 0/destory, 1/bright, 2/twinkle	
            public int nGreen;                 // Green:	-1:invalid, 0/destory, 1/bright, 2/twinkle	
            public int nPurple;                // Purple:	-1:invalid, 0/destory, 1/bright, 2/twinkle	
            public int nWhite;                 // White:	-1:invalid, 0/destory, 1/bright, 2/twinkle
            public int nPink;                  // Pink:	-1:invalid, 0/destory, 1/bright, 2/twinkle
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] byReserved;            // Reserved
        }

        public struct NET_NETWORK_EXCEPTION_INFO
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public NET_PARKINGSPACELIGHT_INFO[] stNetPortAbortInfo; // Light color of opening state of net mouth
            public int nRetNetPortAbortNum;                    // Actual return number
            public NET_PARKINGSPACELIGHT_INFO stuSpaceSpecialInfo;                 // Special state lamp color of parking space						
            public NET_PARKINGSPACELIGHT_INFO stuSpaceChargingInfo;                    // State lamp color of rechargeable car
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] byReserved;                       // Reserved
        }

    }
}
