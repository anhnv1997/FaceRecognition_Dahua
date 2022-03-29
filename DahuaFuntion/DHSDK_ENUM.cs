using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHSDK
{
    public class DHSDK_ENUM
    {
        public enum EM_LOGIN_SPAC_CAP_TYPE
        {
            EM_LOGIN_SPEC_CAP_TCP = 0,     // TCPlogin, default type
            EM_LOGIN_SPEC_CAP_ANY = 1,     // unconditional login
            EM_LOGIN_SPEC_CAP_SERVER_CONN = 2,    // auto sign up login
            EM_LOGIN_SPEC_CAP_MULTICAST = 3,    // multicast login, default
            EM_LOGIN_SPEC_CAP_UDP = 4,    // UDP method login 
            EM_LOGIN_SPEC_CAP_MAIN_CONN_ONLY = 6,    // only main connection login
            EM_LOGIN_SPEC_CAP_SSL = 7,    //  SSL encryption login
            EM_LOGIN_SPEC_CAP_INTELLIGENT_BOX = 9,    // login IVS box remote device
            EM_LOGIN_SPEC_CAP_NO_CONFIG = 10,   // login device do not config
            EM_LOGIN_SPEC_CAP_U_LOGIN = 11,   // USB key device login
            EM_LOGIN_SPEC_CAP_LDAP = 12,   // LDAP login
            EM_LOGIN_SPEC_CAP_AD = 13,   // AD(ActiveDirectory)login
            EM_LOGIN_SPEC_CAP_RADIUS = 14,   // Radius  login
            EM_LOGIN_SPEC_CAP_SOCKET_5 = 15,    // Socks5 login
            EM_LOGIN_SPEC_CAP_CLOUD = 16,   // cloud login
            EM_LOGIN_SPEC_CAP_AUTH_TWICE = 17,   // dual authentication loin
            EM_LOGIN_SPEC_CAP_TS = 18,   // TS stream client login
            EM_LOGIN_SPEC_CAP_P2P = 19,   // web p2p login
            EM_LOGIN_SPEC_CAP_MOBILE = 20,   // mobile client login
            EM_LOGIN_SPEC_CAP_INVALID                   // invalid login
        }

        public enum NET_CAPTURE_FORMATS
        {
            NET_CAPTURE_BMP,
            NET_CAPTURE_JPEG,
            NET_CAPTURE_JPEG_70,
            NET_CAPTURE_JPEG_50,
            NET_CAPTURE_JPEG_30,
        };
        //*******************************************************************
        //XU LY SKIEN NHAN BIEN SO XE****************************************
        public enum EM_EVENT_IVS_TYPE
        {
            /// <summary>
            /// subscription all event
            /// </summary>
            ALL = 0x00000001,
            /// <summary>
            /// cross line event(Corresponding to NET_DEV_EVENT_CROSSLINE_INFO)
            /// </summary>
            CROSSLINEDETECTION = 0x00000002,
            /// <summary>
            /// cross region event(Corresponding to NET_DEV_EVENT_CROSSREGION_INFO)
            /// </summary>
            CROSSREGIONDETECTION = 0x00000003,
            /// <summary>
            /// past event(Corresponding to NET_DEV_EVENT_PASTE_INFO)
            /// </summary>
            PASTEDETECTION = 0x00000004,
            /// <summary>
            /// left event(Corresponding to NET_DEV_EVENT_LEFT_INFO)
            /// </summary>
            LEFTDETECTION = 0x00000005,
            /// <summary>
            /// stay event(Corresponding to NET_DEV_EVENT_STAY_INFO)
            /// </summary>
            STAYDETECTION = 0x00000006,
            /// <summary>
            /// wander event(Corresponding to NET_DEV_EVENT_WANDER_INFO)
            /// </summary>
            WANDERDETECTION = 0x00000007,
            /// <summary>
            /// reservation event(Corresponding to NET_DEV_EVENT_PRESERVATION_INFO)
            /// </summary>
            PRESERVATION = 0x00000008,
            /// <summary>
            /// move event(Corresponding to NET_DEV_EVENT_MOVE_INFO)
            /// </summary>
            MOVEDETECTION = 0x00000009,
            /// <summary>
            /// tail event(Corresponding to NET_DEV_EVENT_TAIL_INFO)
            /// </summary>
            TAILDETECTION = 0x0000000A,
            /// <summary>
            /// rioter event(Corresponding to NET_DEV_EVENT_RIOTERL_INFO)
            /// </summary>
            RIOTERDETECTION = 0x0000000B,
            /// <summary>
            /// fire event(Corresponding to NET_DEV_EVENT_FIRE_INFO)
            /// </summary>
            FIREDETECTION = 0x0000000C,
            /// <summary>
            /// smoke event(Corresponding to NET_DEV_EVENT_SMOKE_INFO)
            /// </summary>
            SMOKEDETECTION = 0x0000000D,
            /// <summary>
            /// fight event(Corresponding to NET_DEV_EVENT_FLOWSTAT_INFO)
            /// </summary>
            FIGHTDETECTION = 0x0000000E,
            /// <summary>
            /// flow stat event(Corresponding to NET_DEV_EVENT_FLOWSTAT_INFO)
            /// </summary>
            FLOWSTAT = 0x0000000F,
            /// <summary>
            /// number stat event(Corresponding to NET_DEV_EVENT_NUMBERSTAT_INFO)
            /// </summary>
            NUMBERSTAT = 0x00000010,
            /// <summary>
            /// camera cover event
            /// </summary>
            CAMERACOVERDDETECTION = 0x00000011,
            /// <summary>
            /// camera move event
            /// </summary>
            CAMERAMOVEDDETECTION = 0x00000012,
            /// <summary>
            /// video abnormal event(Corresponding to NET_DEV_EVENT_VIDEOABNORMALDETECTION_INFO)
            /// </summary>
            VIDEOABNORMALDETECTION = 0x00000013,
            /// <summary>
            /// video bad event
            /// </summary>
            VIDEOBADDETECTION = 0x00000014,
            /// <summary>
            /// traffic control event(Corresponding to NET_DEV_EVENT_TRAFFICCONTROL_INFO)
            /// </summary>
            TRAFFICCONTROL = 0x00000015,
            /// <summary>
            /// traffic accident event(Corresponding to NET_DEV_EVENT_TRAFFICACCIDENT_INFO)
            /// </summary>
            TRAFFICACCIDENT = 0x00000016,
            /// <summary>
            /// traffic junction event(Corresponding to NET_DEV_EVENT_TRAFFICJUNCTION_INFO)
            /// </summary>
            TRAFFICJUNCTION = 0x00000017,
            /// <summary>
            /// traffic gate event(Corresponding to NET_DEV_EVENT_TRAFFICGATE_INFO)
            /// </summary>
            TRAFFICGATE = 0x00000018,
            /// <summary>
            /// traffic snapshot(Corresponding to NET_DEV_EVENT_TRAFFICSNAPSHOT_INFO)
            /// </summary>
            TRAFFICSNAPSHOT = 0x00000019,
            /// <summary>
            /// face detection(Corresponding to NET_DEV_EVENT_FACEDETECT_INFO)
            /// </summary>
            FACEDETECT = 0x0000001A,
            /// <summary>
            /// traffic-Jam(Corresponding to NET_DEV_EVENT_TRAFFICJAM_INFO)
            /// </summary>
            TRAFFICJAM = 0x0000001B,
            /// <summary>
            /// traffic-RunRedLight(Corresponding to NET_DEV_EVENT_TRAFFIC_RUNREDLIGHT_INFO)
            /// </summary>
            TRAFFIC_RUNREDLIGHT = 0x00000100,
            /// <summary>
            /// traffic-Overline(Corresponding to NET_DEV_EVENT_TRAFFIC_OVERLINE_INFO)
            /// </summary>
            TRAFFIC_OVERLINE = 0x00000101,
            /// <summary>
            /// traffic-Retrograde(Corresponding to NET_DEV_EVENT_TRAFFIC_RETROGRADE_INFO)
            /// </summary>
            TRAFFIC_RETROGRADE = 0x00000102,
            /// <summary>
            /// traffic-TurnLeft(Corresponding to NET_DEV_EVENT_TRAFFIC_TURNLEFT_INFO)
            /// </summary>
            TRAFFIC_TURNLEFT = 0x00000103,
            /// <summary>
            /// traffic-TurnRight(Corresponding to NET_DEV_EVENT_TRAFFIC_TURNRIGHT_INFO)	
            /// </summary>
            TRAFFIC_TURNRIGHT = 0x00000104,
            /// <summary>
            /// traffic-Uturn(Corresponding to NET_DEV_EVENT_TRAFFIC_UTURN_INFO)
            /// </summary>
            TRAFFIC_UTURN = 0x00000105,
            /// <summary>
            /// traffic-Overspeed(Corresponding to NET_DEV_EVENT_TRAFFIC_OVERSPEED_INFO)
            /// </summary>
            TRAFFIC_OVERSPEED = 0x00000106,
            /// <summary>
            /// traffic-Underspeed(Corresponding to NET_DEV_EVENT_TRAFFIC_UNDERSPEED_INFO)
            /// 交通违章-低速(对应 NET_DEV_EVENT_TRAFFIC_UNDERSPEED_INFO)
            /// </summary>
            TRAFFIC_UNDERSPEED = 0x00000107,
            /// <summary>
            /// traffic-Parking(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKING_INFO)
            /// 交通违章-违章停车(对应 NET_DEV_EVENT_TRAFFIC_PARKING_INFO)
            /// </summary>
            TRAFFIC_PARKING = 0x00000108,
            /// <summary>
            /// traffic-WrongRoute(Corresponding to NET_DEV_EVENT_TRAFFIC_WRONGROUTE_INFO)
            /// 交通违章-不按车道行驶(对应 NET_DEV_EVENT_TRAFFIC_WRONGROUTE_INFO)
            /// </summary>
            TRAFFIC_WRONGROUTE = 0x00000109,
            /// <summary>
            /// traffic-CrossLane(Corresponding to NET_DEV_EVENT_TRAFFIC_CROSSLANE_INFO)
            /// 交通违章-违章变道(对应 NET_DEV_EVENT_TRAFFIC_CROSSLANE_INFO)
            /// </summary>
            TRAFFIC_CROSSLANE = 0x0000010A,
            /// <summary>
            /// traffic-OverYellowLine(Corresponding to NET_DEV_EVENT_TRAFFIC_OVERYELLOWLINE_INFO)
            /// 交通违章-压黄线 (对应 NET_DEV_EVENT_TRAFFIC_OVERYELLOWLINE_INFO)
            /// </summary>
            TRAFFIC_OVERYELLOWLINE = 0x0000010B,
            /// <summary>
            /// traffic-DrivingOnShoulder(Corresponding to NET_DEV_EVENT_TRAFFIC_DRIVINGONSHOULDER_INFO)
            /// 交通违章-路肩行驶事件(对应 NET_DEV_EVENT_TRAFFIC_DRIVINGONSHOULDER_INFO)  
            /// </summary>
            TRAFFIC_DRIVINGONSHOULDER = 0x0000010C,
            /// <summary>
            /// traffic-YellowPlateInLane(Corresponding to NET_DEV_EVENT_TRAFFIC_YELLOWPLATEINLANE_INFO)
            /// 交通违章-黄牌车占道事件(对应 NET_DEV_EVENT_TRAFFIC_YELLOWPLATEINLANE_INFO)
            /// </summary>
            TRAFFIC_YELLOWPLATEINLANE = 0x0000010E,
            /// <summary>
            /// Traffic offense-Pedestral has higher priority at the  crosswalk(Corresponding to NET_DEV_EVENT_TRAFFIC_PEDESTRAINPRIORITY_INFO)
            /// 交通违章-斑马线行人优先事件(对应 NET_DEV_EVENT_TRAFFIC_PEDESTRAINPRIORITY_INFO)
            /// </summary>
            TRAFFIC_PEDESTRAINPRIORITY = 0x0000010F,
            /// <summary>
            /// cross fence(Corresponding to NET_DEV_EVENT_CROSSFENCEDETECTION_INFO)
            /// 翻越围栏事件(对应 NET_DEV_EVENT_CROSSFENCEDETECTION_INFO)
            /// </summary>
            CROSSFENCEDETECTION = 0x0000011F,
            /// <summary>
            /// ElectroSpark event(Corresponding to NET_DEV_EVENT_ELECTROSPARK_INFO) 
            /// 电火花事件(对应 NET_DEV_EVENT_ELECTROSPARK_INFO)
            /// </summary>
            ELECTROSPARKDETECTION = 0X00000110,
            /// <summary>
            /// no passing(Corresponding to NET_DEV_EVENT_TRAFFIC_NOPASSING_INFO)
            /// 交通违章-禁止通行事件(对应 NET_DEV_EVENT_TRAFFIC_NOPASSING_INFO)
            /// </summary>
            TRAFFIC_NOPASSING = 0x00000111,
            /// <summary>
            /// abnormal run(Corresponding to NET_DEV_EVENT_ABNORMALRUNDETECTION_INFO)
            /// 异常奔跑事件(对应 NET_DEV_EVENT_ABNORMALRUNDETECTION_INFO)
            /// </summary>
            ABNORMALRUNDETECTION = 0x00000112,
            /// <summary>
            /// retrograde(Corresponding to NET_DEV_EVENT_RETROGRADEDETECTION_INFO)
            /// 人员逆行事件(对应 NET_DEV_EVENT_RETROGRADEDETECTION_INFO)
            /// </summary>
            RETROGRADEDETECTION = 0x00000113,
            /// <summary>
            /// in region detection(Corresponding to NET_DEV_EVENT_INREGIONDETECTION_INFO)
            /// 区域内检测事件(对应 NET_DEV_EVENT_INREGIONDETECTION_INFO)
            /// </summary>
            INREGIONDETECTION = 0x00000114,
            /// <summary>
            /// taking away things(Corresponding to NET_DEV_EVENT_TAKENAWAYDETECTION_INFO)
            /// 物品搬移事件(对应 NET_DEV_EVENT_TAKENAWAYDETECTION_INFO)
            /// </summary>
            TAKENAWAYDETECTION = 0x00000115,
            /// <summary>
            /// parking(Corresponding to NET_DEV_EVENT_PARKINGDETECTION_INFO)
            /// 非法停车事件(对应 NET_DEV_EVENT_PARKINGDETECTION_INFO)
            /// </summary>
            PARKINGDETECTION = 0x00000116,
            /// <summary>
            /// face recognition(Corresponding to NET_DEV_EVENT_FACERECOGNITION_INFO)
            /// 人脸识别事件(对应 NET_DEV_EVENT_FACERECOGNITION_INFO)
            /// </summary>
            FACERECOGNITION = 0x00000117,
            /// <summary>
            /// manual snap(Corresponding to NET_DEV_EVENT_TRAFFIC_MANUALSNAP_INFO)
            /// 交通手动抓拍事件(对应 NET_DEV_EVENT_TRAFFIC_MANUALSNAP_INFO)
            /// </summary>
            TRAFFIC_MANUALSNAP = 0x00000118,
            /// <summary>
            /// traffic flow state(Corresponding to NET_DEV_EVENT_TRAFFIC_FLOW_STATE)
            /// 交通流量统计事件(对应 NET_DEV_EVENT_TRAFFIC_FLOW_STATE)
            /// </summary>
            TRAFFIC_FLOWSTATE = 0x00000119,
            /// <summary>
            /// traffic stay(Corresponding to NET_DEV_EVENT_TRAFFIC_STAY_INFO)
            /// 交通滞留事件(对应 NET_DEV_EVENT_TRAFFIC_STAY_INFO)
            /// </summary>
            TRAFFIC_STAY = 0x0000011A,
            /// <summary>
            /// traffic vehicle route(Corresponding to NET_DEV_EVENT_TRAFFIC_VEHICLEINROUTE_INFO)
            /// 有车占道事件(对应 NET_DEV_EVENT_TRAFFIC_VEHICLEINROUTE_INFO)
            /// </summary>
            TRAFFIC_VEHICLEINROUTE = 0x0000011B,
            /// <summary>
            /// motion detect(Corresponding to NET_DEV_EVENT_ALARM_INFO)
            /// 视频移动侦测事件(对应 NET_DEV_EVENT_ALARM_INFO)
            /// </summary>
            ALARM_MOTIONDETECT = 0x0000011C,
            /// <summary>
            /// local alarm(Corresponding to NET_DEV_EVENT_ALARM_INFO)
            /// 外部报警事件(对应 NET_DEV_EVENT_ALARM_INFO)
            /// </summary>
            ALARM_LOCALALARM = 0x0000011D,
            /// <summary>
            /// prisoner rise detect(Corresponding to NET_DEV_EVENT_PRISONERRISEDETECTION_INFO)
            /// 看守所囚犯起身事件(对应 NET_DEV_EVENT_PRISONERRISEDETECTION_INFO)
            /// </summary>
            PRISONERRISEDETECTION = 0x0000011E,
            /// <summary>
            /// traffic tollgate(Corresponding to NET_DEV_EVENT_TRAFFICJUNCTION_INFO)
            /// 交通违章-卡口事件----新规则(对应 NET_DEV_EVENT_TRAFFICJUNCTION_INFO)
            /// </summary>
            TRAFFIC_TOLLGATE = 0x00000120,
            /// <summary>
            /// density detection of persons(Corresponding to NET_DEV_EVENT_DENSITYDETECTION_INFO)
            /// 人员密集度检测(对应 NET_DEV_EVENT_DENSITYDETECTION_INFO)
            /// </summary>
            DENSITYDETECTION = 0x00000121,
            /// <summary>
            /// video diagnosis result(Corresponding to NET_VIDEODIAGNOSIS_COMMON_INFO and NET_REAL_DIAGNOSIS_RESULT)
            /// 视频诊断结果事件(对应 NET_VIDEODIAGNOSIS_COMMON_INFO 和 NET_REAL_DIAGNOSIS_RESULT)
            /// </summary>
            VIDEODIAGNOSIS = 0x00000122,
            /// <summary>
            /// queue detection(Corresponding to NET_DEV_EVENT_QUEUEDETECTION_INFO)
            /// 排队检测报警事件(对应 NET_DEV_EVENT_QUEUEDETECTION_INFO)
            /// </summary>
            QUEUEDETECTION = 0x00000123,
            /// <summary>
            /// take up in bus route(Corresponding to NET_DEV_EVENT_TRAFFIC_VEHICLEINBUSROUTE_INFO)
            /// 占用公交车道事件(对应 NET_DEV_EVENT_TRAFFIC_VEHICLEINBUSROUTE_INFO)
            /// </summary>
            TRAFFIC_VEHICLEINBUSROUTE = 0x00000124,
            /// <summary>
            /// illegal astern(Corresponding to NET_DEV_EVENT_IVS_TRAFFIC_BACKING_INFO) 
            /// 违章倒车事件(对应 NET_DEV_EVENT_IVS_TRAFFIC_BACKING_INFO)
            /// </summary>
            TRAFFIC_BACKING = 0x00000125,
            /// <summary>
            /// audio abnormity(Corresponding to NET_DEV_EVENT_IVS_AUDIO_ABNORMALDETECTION_INFO)
            /// 声音异常检测(对应 NET_DEV_EVENT_IVS_AUDIO_ABNORMALDETECTION_INFO)
            /// </summary>
            AUDIO_ABNORMALDETECTION = 0x00000126,
            /// <summary>
            /// run yellow light(Corresponding to NET_DEV_EVENT_TRAFFIC_RUNYELLOWLIGHT_INFO)
            /// 交通违章-闯黄灯事件(对应 NET_DEV_EVENT_TRAFFIC_RUNYELLOWLIGHT_INFO)
            /// </summary>
            TRAFFIC_RUNYELLOWLIGHT = 0x00000127,
            /// <summary>
            /// climb detection(Corresponding to NET_DEV_EVENT_IVS_CLIMB_INFO) 
            /// 攀高检测事件(对应 NET_DEV_EVENT_IVS_CLIMB_INFO)
            /// </summary>
            CLIMBDETECTION = 0x00000128,
            /// <summary>
            /// leave detection(Corresponding to NET_DEV_EVENT_IVS_LEAVE_INFO)
            /// 离岗检测事件(对应 NET_DEV_EVENT_IVS_LEAVE_INFO)
            /// </summary>
            LEAVEDETECTION = 0x00000129,
            /// <summary>
            /// parking on yellow box(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKINGONYELLOWBOX_INFO)
            /// 黄网格线抓拍事件(对应 NET_DEV_EVENT_TRAFFIC_PARKINGONYELLOWBOX_INFO)
            /// </summary>
            TRAFFIC_PARKINGONYELLOWBOX = 0x0000012A,
            /// <summary>
            /// parking space parking(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKINGSPACEPARKING_INFO)
            /// 车位有车事件(对应 NET_DEV_EVENT_TRAFFIC_PARKINGSPACEPARKING_INFO)
            /// </summary>
            TRAFFIC_PARKINGSPACEPARKING = 0x0000012B,
            /// <summary>
            /// parking space no parking(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKINGSPACENOPARKING_INFO)
            /// 车位无车事件(对应 NET_DEV_EVENT_TRAFFIC_PARKINGSPACENOPARKING_INFO)   
            /// </summary>
            TRAFFIC_PARKINGSPACENOPARKING = 0x0000012C,
            /// <summary>
            /// passerby(Corresponding to NET_DEV_EVENT_TRAFFIC_PEDESTRAIN_INFO)
            /// 交通行人事件(对应 NET_DEV_EVENT_TRAFFIC_PEDESTRAIN_INFO)
            /// </summary>
            TRAFFIC_PEDESTRAIN = 0x0000012D,
            /// <summary>
            /// throw(Corresponding to NET_DEV_EVENT_TRAFFIC_THROW_INFO)
            /// 交通抛洒物品事件(对应 NET_DEV_EVENT_TRAFFIC_THROW_INFO)
            /// </summary>
            TRAFFIC_THROW = 0x0000012E,
            /// <summary>
            /// idle(Corresponding to NET_DEV_EVENT_TRAFFIC_IDLE_INFO)
            /// 交通空闲事件(对应 NET_DEV_EVENT_TRAFFIC_IDLE_INFO)
            /// </summary>
            TRAFFIC_IDLE = 0x0000012F,
            /// <summary>
            /// Vehicle ACC power outage alarm events(Corresponding to NET_DEV_EVENT_ALARM_VEHICLEACC_INFO)
            /// 车载ACC断电报警事件(对应 NET_DEV_EVENT_ALARM_VEHICLEACC_INFO)
            /// </summary>
            ALARM_VEHICLEACC = 0x00000130,
            /// <summary>
            /// Vehicle rollover alarm events(Corresponding to NET_DEV_EVENT_VEHICEL_ALARM_INFO)
            /// 车辆侧翻报警事件(对应 NET_DEV_EVENT_VEHICEL_ALARM_INFO)
            /// </summary>
            ALARM_VEHICLE_TURNOVER = 0x00000131,
            /// <summary>
            /// Vehicle crash alarm events(Corresponding to NET_DEV_EVENT_VEHICEL_ALARM_INFO)
            /// 车辆撞车报警事件(对应 NET_DEV_EVENT_VEHICEL_ALARM_INFO)
            /// </summary>
            ALARM_VEHICLE_COLLISION = 0x00000132,
            /// <summary>
            /// On-board camera large Angle turn events
            /// 车载摄像头大角度扭转事件
            /// </summary>
            ALARM_VEHICLE_LARGE_ANGLE = 0x00000133,
            /// <summary>
            /// Parking line pressing events(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKINGSPACEOVERLINE_INFO)
            /// 车位压线事件(对应 NET_DEV_EVENT_TRAFFIC_PARKINGSPACEOVERLINE_INFO)
            /// </summary>
            TRAFFIC_PARKINGSPACEOVERLINE = 0x00000134,
            /// <summary>
            /// Many scenes switching events(Corresponding to NET_DEV_EVENT_IVS_MULTI_SCENE_SWICH_INFO)
            /// 多场景切换事件(对应 NET_DEV_EVENT_IVS_MULTI_SCENE_SWICH_INFO)
            /// </summary>
            MULTISCENESWITCH = 0x00000135,
            /// <summary>
            /// Limited license plate event(Corresponding to NET_DEV_EVENT_TRAFFIC_RESTRICTED_PLATE)
            /// 受限车牌事件(对应 NET_DEV_EVENT_TRAFFIC_RESTRICTED_PLATE)
            /// </summary>
            TRAFFIC_RESTRICTED_PLATE = 0X00000136,
            /// <summary>
            /// Cross stop line event(Corresponding to NET_DEV_EVENT_TRAFFIC_OVERSTOPLINE)
            /// 压停止线事件(对应 NET_DEV_EVENT_TRAFFIC_OVERSTOPLINE)
            /// </summary>
            TRAFFIC_OVERSTOPLINE = 0X00000137,
            /// <summary>
            /// Traffic unfasten seat belt event(Corresponding to NET_DEV_EVENT_TRAFFIC_WITHOUT_SAFEBELT) 
            /// 交通未系安全带事件(对应 NET_DEV_EVENT_TRAFFIC_WITHOUT_SAFEBELT)
            /// </summary>
            TRAFFIC_WITHOUT_SAFEBELT = 0x00000138,
            /// <summary>
            /// Driver smoking event(Corresponding to NET_DEV_EVENT_TRAFFIC_DRIVER_SMOKING) 
            /// 驾驶员抽烟事件(对应 NET_DEV_EVENT_TRAFFIC_DRIVER_SMOKING)
            /// </summary>
            TRAFFIC_DRIVER_SMOKING = 0x00000139,
            /// <summary>
            /// Driver call event(Corresponding to NET_DEV_EVENT_TRAFFIC_DRIVER_CALLING) 
            /// 驾驶员打电话事件(对应 NET_DEV_EVENT_TRAFFIC_DRIVER_CALLING)
            /// </summary>
            TRAFFIC_DRIVER_CALLING = 0x0000013A,
            /// <summary>
            /// Pedestrain red light(Corresponding to NET_DEV_EVENT_TRAFFIC_PEDESTRAINRUNREDLIGHT_INFO)
            /// 行人闯红灯事件(对应 NET_DEV_EVENT_TRAFFIC_PEDESTRAINRUNREDLIGHT_INFO)
            /// </summary>
            TRAFFIC_PEDESTRAINRUNREDLIGHT = 0x0000013B,
            /// <summary>
            /// Pass not in order(corresponding NET_DEV_EVENT_TRAFFIC_PASSNOTINORDER_INFO)
            /// 未按规定依次通行(对应 NET_DEV_EVENT_TRAFFIC_PASSNOTINORDER_INFO)
            /// </summary>
            TRAFFIC_PASSNOTINORDER = 0x0000013C,
            /// <summary>
            /// Object feature detection event(Corresponding to NET_DEV_EVENT_TRAFFIC_OBJECT_DETECTION) 
            /// 物体特征检测事件 NET_DEV_EVENT_TRAFFIC_OBJECT_DETECTION
            /// </summary>
            OBJECT_DETECTION = 0x00000141,
            /// <summary>
            /// Analog alarm channel?ˉs alarm event(corresponding NET_DEV_EVENT_ALARM_ANALOGALRM_INFO)
            /// 模拟量报警通道的报警事件(对应NET_DEV_EVENT_ALARM_ANALOGALRM_INFO)
            /// </summary>
            ALARM_ANALOGALARM = 0x00000150,
            /// <summary>
            /// Warning lineexpansion event(Corresponding to NET_DEV_EVENT_CROSSLINE_INFO_EX) 
            /// 警戒线扩展事件 NET_DEV_EVENT_CROSSLINE_INFO_EX
            /// </summary>
            CROSSLINEDETECTION_EX = 0x00000151,
            /// <summary>
            /// Normal Record
            /// 普通录像
            /// </summary>
            ALARM_COMMON = 0x00000152,
            /// <summary>
            /// Video tampering event(Corresponding to NET_DEV_EVENT_ALARM_VIDEOBLIND)
            /// 视频遮挡事件(对应 NET_DEV_EVENT_ALARM_VIDEOBLIND)
            /// </summary>
            ALARM_VIDEOBLIND = 0x00000153,
            /// <summary>
            /// Video loss event
            /// 视频丢失事件
            /// </summary>
            ALARM_VIDEOLOSS = 0x00000154,
            /// <summary>
            /// Event of getting out bed detection(Corresponding to NET_DEV_EVENT_GETOUTBED_INFO)
            /// 看守所下床事件(对应 NET_DEV_EVENT_GETOUTBED_INFO)
            /// </summary>
            GETOUTBEDDETECTION = 0x00000155,
            /// <summary>
            /// Event of patrol detection(Corresponding to NET_DEV_EVENT_PATROL_INFO)
            /// 巡逻检测事件(对应 NET_DEV_EVENT_PATROL_INFO)
            /// </summary>
            PATROLDETECTION = 0x00000156,
            /// <summary>
            /// Event of on duty detection(Corresponding to NET_DEV_EVENT_ONDUTY_INFO)
            /// 站岗检测事件(对应 NET_DEV_EVENT_ONDUTY_INFO)
            /// </summary>
            ONDUTYDETECTION = 0x00000157,
            /// <summary>
            /// Event of VTO do not answer calling request
            /// 门口机呼叫未响应事件
            /// </summary>
            NOANSWERCALL = 0x00000158,
            /// <summary>
            /// Event of storage do not exist
            /// 存储组不存在事件
            /// </summary>
            STORAGENOTEXIST = 0x00000159,
            /// <summary>
            /// Event of storage space low
            /// 硬盘空间低报警事件
            /// </summary>
            STORAGELOWSPACE = 0x0000015A,
            /// <summary>
            /// Event of storage failure
            /// 存储错误事件
            /// </summary>
            STORAGEFAILURE = 0x0000015B,
            /// <summary>
            /// Event of profile alarm transmit
            /// 报警传输事件
            /// </summary>
            PROFILEALARMTRANSMIT = 0x0000015C,
            /// <summary>
            /// Event of static video detect(corresponding NET_DEV_EVENT_ALARM_VIDEOSTATIC_INFO)
            /// 视频静态检测事件(对应 NET_DEV_EVENT_ALARM_VIDEOSTATIC_INFO)
            /// </summary>
            VIDEOSTATIC = 0x0000015D,
            /// <summary>
            /// Event of video timing detect(corresponding NET_DEV_EVENT_ALARM_VIDEOTIMING_INFO)
            /// 视频定时检测事件(对应 NET_DEV_EVENT_ALARM_VIDEOTIMING_INFO)
            /// </summary>
            VIDEOTIMING = 0x0000015E,
            /// <summary>
            /// Heat map 
            /// 热度图
            /// </summary>
            HEATMAP = 0x0000015F,
            /// <summary>
            /// ID info reading event (Corresponding to NET_DEV_EVENT_ALARM_CITIZENIDCARD_INFO)
            /// 身份证信息读取事件(对应 NET_DEV_EVENT_ALARM_CITIZENIDCARD_INFO)
            /// </summary>
            CITIZENIDCARD = 0x00000160,
            /// <summary>
            /// Image info event(Corresponding to NET_DEV_EVENT_ALARM_PIC_INFO)
            /// 图片信息事件(对应 NET_DEV_EVENT_ALARM_PIC_INFO)
            /// </summary>
            PICINFO = 0x00000161,
            /// <summary>
            /// NetPlayCheck event(corresponding NET_DEV_EVENT_ALARM_NETPLAYCHECK_INFO)
            /// 上网登记事件(对应 NET_DEV_EVENT_ALARM_NETPLAYCHECK_INFO)
            /// </summary>
            NETPLAYCHECK = 0x00000162,
            /// <summary>
            /// Jam Forbid into  event(corresponding NET_DEV_EVENT_ALARM_JAMFORBIDINTO_INFO)
            /// 车辆拥堵禁入事件(对应 NET_DEV_EVENT_ALARM_JAMFORBIDINTO_INFO)
            /// </summary>
            TRAFFIC_JAM_FORBID_INTO = 0x00000163,
            /// <summary>
            /// Snap by time event(corresponding NET_DEV_EVENT_SNAPBYTIME)
            /// 定时抓图事件(对应NET_DEV_EVENT_SNAPBYTIME)
            /// </summary>
            SNAPBYTIME = 0x00000164,
            /// <summary>
            /// PTZ turn to preset event(corresponding to NET_DEV_EVENT_ALARM_PTZ_PRESET_INFO)
            /// 云台转动到预置点事件(对应 NET_DEV_EVENT_ALARM_PTZ_PRESET_INFO)
            /// </summary>
            PTZ_PRESET = 0x00000165,
            /// <summary>
            /// Event of infrared detect info(corresponding to NET_DEV_EVENT_ALARM_RFID_INFO)
            /// 红外线检测信息事件(对应 NET_DEV_EVENT_ALARM_RFID_INFO)
            /// </summary>
            RFID_INFO = 0x00000166,
            /// <summary>
            /// Event of standing up detection
            /// 人起立检测事件
            /// </summary>
            STANDUPDETECTION = 0X00000167,
            /// <summary>
            /// Event of QSYTrafficCarWeight (corresponding to NET_DEV_EVENT_QSYTRAFFICCARWEIGHT_INFO)
            /// 交通卡口称重事件(对应 NET_DEV_EVENT_QSYTRAFFICCARWEIGHT_INFO)
            /// </summary>
            QSYTRAFFICCARWEIGHT = 0x00000168,
            /// <summary>
            /// Event of compare plate(corresponding to NET_DEV_EVENT_TRAFFIC_COMPAREPLATE_INFO)
            /// 卡口前后车牌合成事件(对应NET_DEV_EVENT_TRAFFIC_COMPAREPLATE_INFO)
            /// </summary>
            TRAFFIC_COMPAREPLATE = 0x00000169,
            /// <summary>
            /// Event of shooting score recognition(corresponding to NET_CFG_IVS_SHOOTINGSCORERECOGNITION_INFO)
            /// 打靶像机事件(对应 NET_CFG_IVS_SHOOTINGSCORERECOGNITION_INFO)
            /// </summary>
            SHOOTINGSCORERECOGNITION = 0x0000016A,
            /// <summary>
            /// 场景变更事件(对应 NET_DEV_ALRAM_SCENECHANGE_INFO,CFG_VIDEOABNORMALDETECTION_INFO)
            /// </summary>
            SCENE_CHANGE = 0x0000016D,
            /// <summary>
            /// Event of presnap analyse(corresponding to NET_DEV_EVENT_TRAFFIC_ANALYSE_PRESNAP_INFO)
            /// 预分析抓拍图片事件(对应 NET_DEV_EVENT_TRAFFIC_ANALYSE_PRESNAP_INFO)
            /// </summary>
            TRAFFIC_ANALYSE_PRESNAP = 0x00000170,
            /// <summary>
            /// 倒地报警事件(对应 DEV_EVENT_TUMBLE_DETECTION_INFO)
            /// </summary>
            TUMBLE_DETECTION = 0x00000177,
            /// <summary>
            /// All event start with [TRAFFIC](EVENT_IVS_TRAFFICCONTROL to EVENT_TRAFFICSNAPSHOT,EVENT_IVS_TRAFFIC_RUNREDLIGHT to EVENT_IVS_TRAFFIC_UNDERSPEED)
            /// 所有以traffic开头的事件目前指的是EVENT_IVS_TRAFFICCONTROL 到 EVENT_TRAFFICSNAPSHOT,EVENT_IVS_TRAFFIC_RUNREDLIGHT 到 EVENT_IVS_TRAFFIC_UNDERSPEED
            /// </summary>                    
            TRAFFIC_ALL = 0x000001FF,
            /// <summary>
            /// All IVS events 
            /// 所有智能分析事件
            /// </summary>
            VIDEOANALYSE = 0x00000200,
            /// <summary>
            /// LinkSD events(Corresponding to NET_DEV_EVENT_LINK_SD)
            /// LinkSD事件(对应 NET_DEV_EVENT_LINK_SD)
            /// </summary>
            LINKSD = 0x00000201,
            /// <summary>
            /// Vehicle Analyse (Corresponding to NET_DEV_EVENT_VEHICLEANALYSE)
            /// 车辆特征检测分析(对应NET_DEV_EVENT_VEHICLEANALYSE)
            /// </summary>
            VEHICLEANALYSE = 0x00000202,
            /// <summary>
            /// Flow rate events(Corresponding to NET_DEV_EVENT_FLOWRATE_INFO)
            /// 流量使用情况事件(对应 NET_DEV_EVENT_FLOWRATE_INFO)
            /// </summary>
            FLOWRATE = 0x00000203,
            /// <summary>
            /// 门禁事件 (对应 NET_DEV_EVENT_ACCESS_CTL_INFO)
            /// </summary>
            ACCESS_CTL = 0x00000204,
            /// <summary>
            /// SnapManual事件(对应 NET_DEV_EVENT_SNAPMANUAL)
            /// </summary>
            SNAPMANUAL = 0x00000205,
            /// <summary>
            /// RFID电子车牌标签事件(对应 NET_DEV_EVENT_TRAFFIC_ELETAGINFO_INFO)
            /// </summary>
            TRAFFIC_ELETAGINFO = 0x00000206,
            /// <summary>
            /// 生理疲劳驾驶事件(对应 NET_DEV_EVENT_TIREDPHYSIOLOGICAL_INFO)
            /// </summary>
            TRAFFIC_TIREDPHYSIOLOGICAL = 0x00000207,
            /// <summary>
            /// 车辆急转报警事件(对应 NET_DEV_EVENT_BUSSHARPTURN_INFO)
            /// </summary>
            TRAFFIC_BUSSHARPTURN = 0x00000208,
            /// <summary>
            /// 人证比对事件(对应 NET_DEV_EVENT_CITIZEN_PICTURE_COMPARE_INFO)
            /// </summary>
            CITIZEN_PICTURE_COMPARE = 0x00000209,
            /// <summary>
            /// 立体视觉站立事件(对应DEV_EVENT_MANSTAND_DETECTION_INFO)
            /// </summary>
            MAN_STAND_DETECTION = 0x0000020D,
            /// <summary>
            /// 立体视觉区域内人数统计事件(对应DEV_EVENT_MANNUM_DETECTION_INFO)
            /// </summary>
            MAN_NUM_DETECTION = 0x0000020E,
            /// <summary>
            /// 人体特征事件(对应 NET_DEV_EVENT_HUMANTRAIT_INFO)
            /// </summary>
            HUMANTRAIT = 0x00000215,
            /// <summary>
            /// 人脸分析事件 (暂未有具体事件)
            /// </summary>
            FACEANALYSIS = 0x00000217,
            /// <summary>
            /// 左转不礼让直行事件
            /// </summary>
            TRAFFIC_TURNLEFTAFTERSTRAIGHT = 0x00000218,
            /// <summary>
            /// 大弯小转事件
            /// </summary>
            TRAFFIC_BIGBENDSMALLTURN = 0x00000219,
            /// <summary>
            /// 车辆加塞事件
            /// </summary>
            TRAFFIC_QUEUEJUMP = 0x0000021C,
            /// <summary>
            /// 右转不礼让直行事件
            /// </summary>
            TRAFFIC_TURNRIGHTAFTERSTRAIGHT = 0x0000021E,
            /// <summary>
            /// 右转不礼让直行行人
            /// </summary>
            TRAFFIC_TURNRIGHTAFTERPEOPLE = 0x0000021F,
            /// <summary>
            /// X光检测事件 (对应 NET_DEV_EVENT_XRAY_DETECTION_INFO)
            /// </summary>
            XRAY_DETECTION = 0x00000223,
            /// <summary>
            /// 远光灯违章事件
            /// </summary>
            TRAFFIC_HIGH_BEAM = 0x00000228,
            /// <summary>
            /// 人群密度检测事件,对应结构体 DEV_EVENT_CROWD_DETECTION_INFO
            /// </summary>
            CROWDDETECTION = 0x0000022C,
            /// <summary>
            /// 车牌对比事件(中石化智慧加油站项目)(对应 DEV_EVENT_VEHICLE_RECOGNITION_INFO)
            /// </summary>
            VEHICLE_RECOGNITION = 0x00000231,
            /// <summary>
            /// 违章进入待行区
            /// </summary>
            TRAFFIC_WAITINGAREA = 0x00000234,
            /// <summary>
            /// IVSS人脸检测事件 (暂未有具体事件)
            /// </summary>
            FACEATTRIBUTE = 0x00000243,
            /// <summary>
            /// IVSS人脸识别事件 (暂未有具体事件)
            /// </summary>
            FACECOMPARE = 0x00000244,
            /// <summary>
            /// 火警事件(对应 NET_DEV_EVENT_FIREWARNING_INFO)
            /// </summary>
            FIREWARNING = 0x00000245,
            /// <summary>
            /// 异常间距事件 (对应 DEV_EVENT_DISTANCE_DETECTION_INFO)
            /// </summary>
            DISTANCE_DETECTION = 0x0000024A,
            /// <summary>
            /// 课堂行为分析事件(对应 DEV_EVENT_CLASSROOM_BEHAVIOR_INFO)
            /// </summary>
            CLASSROOM_BEHAVIOR = 0x0000026A,
            /// <summary>
            /// 工装(安全帽/工作服等)检测事件(对应 DEV_EVENT_WORKCLOTHES_DETECT_INFO)
            /// </summary>
            WORKCLOTHES_DETECT = 0x0000026E,
            /// <summary>
            /// X光按物体检测规则配置, 对应事件 XRAY_DETECTION
            /// </summary>
            XRAY_DETECT_BYOBJECT = 0x00000273,
            /// <summary>
            /// 人体温智能检测事件(对应 DEV_EVENT_ANATOMY_TEMP_DETECT_INFO)
            /// </summary>
            ANATOMY_TEMP_DETECT = 0x00000303,
        }
        //control color
        public enum NET_EM_CFG_OPERATE_TYPE
        {
            NET_EM_CFG_SNAP_MODE,                   // Snap Mode Config
            NET_EM_CFG_DEV_CAR_COACH,               // Railway record config,corresponding to struct NET_DEV_CAR_COACH_INFO
            NET_EM_CFG_YUEQING_SUPPLYLIGHTING,      // YueQing External lighting configuration, corresponding to struct NET_YUEQING_SUPPLYLIGHTING_INFO
            NET_EM_CFG_MEDIA_GLOBAL,                // media global config,corresponding to struct NET_MEDIA_GLOBAL_INFO
            NET_EM_CFG_PARKINGSPACECELL_STATUS,     // parking space(The setting of special parking spaces and ordinary parking spaces), corresponding NET_PARKINGSPACECELL_STATUS_INFO
            NET_EM_CFG_PARKINGSPACELIGHT_STATE,     // parking space light state, corresponding NET_PARKINGSPACELIGHT_STATE_INFO
            NET_EM_CFG_COAXIAL_LIGHT,               // Coaxial Light Config, corresponding to struct NET_CFG_COAXIAL_LIGHT_INFO
            NET_EM_CFG_VIDEO_OUT,                   // VideoOut config, corresponding to NET_CFG_VIDEO_OUT_INFO

            NET_EM_CFG_MEDIA_ENCRYPT = 9,               // media encrypt config,corresponding to NET_MEDIA_ENCRYPT_INFO,not related to channels,ChannelID must be fill in -1
            NET_EM_CFG_COUNTRY,                     // Country/area config,corresponding to NET_CFG_COUNTRY_INFO, not related to channels,ChannelID must be fill in -1
            NET_EM_CFG_VIDEOSTANDARD,               // Video standard config,corresponding to NET_CFG_VIDEOSTANDARD_INFO, not related to channels,ChannelID must be fill in -1, device currently not support SECAM 
            NET_EM_CFG_SERIAL_PUSH_LOG,             // Serial push log£¬ corresponding to NET_CFG_SERIALPUSHLOG_INFO,not related to channels,ChannelID must be fill in -1
            NET_EM_CFG_PRESET_SNAP_PICTURE_NUM,     // snap picture num of preset point,related to NET_CFG_PRESET_SNAP_PICTURE_NUM
            NET_EM_CFG_DOWNLOAD_ENCRYPT,            // download file encrypt config,corresponding to NET_DOWNLOAD_ENCRYPT_INFO,not related to channels,ChannelID must be fill in -1
            NET_EM_CFG_LIFT_CONTROL_OPTION,         // lift controller option, corresponding to NET_CFG_LIFTCONTROL_OPTION,not related to channels,ChannelID must be fill in -1
            NET_EM_CFG_HEALTH_CODE,                 // health code config, corresponding to NET_CFG_HEALTH_CODE_INFO,not related to channels,ChannelID must be fill in -1
            NET_EM_CFG_RTMP,                        // RTMP config, corresponding to NET_CFG_RTMP_INFO,not related to channels,ChannelID must be fill in -1

            /*********the configuration about OSD*************************************************************************************/
            NET_EM_CFG_CHANNELTITLE = 1000,         // Encode widget-channel title config, corresponding to struct NET_OSD_CHANNEL_TITLE, emOsdBlendType in struct must be set
            NET_EM_CFG_TIMETITLE,                   // Encode widget-Time title config, corresponding to NET_OSD_TIME_TITLE, emOsdBlendType in struct must be set
            NET_EM_CFG_CUSTOMTITLE,                 // Encode widget-Self-defined title config, corresponding to NET_OSD_CUSTOM_TITLE, emOsdBlendType  in struct must be set
            NET_EM_CFG_CUSTOMTITLETEXTALIGN,        // Encode widget-Self-defined title alignment config, corresponding to NET_OSD_CUSTOM_TITLE_TEXT_ALIGN
            NET_EM_CFG_OSDCOMMINFO,                 // Encode widget-common info config, corresponding to NET_OSD_COMM_INFO
            NET_EM_CFG_OSD_PTZZOOM,                 // Encode widget-PTZ zoom config, corresponding to NET_OSD_PTZZOOM_INFO
            NET_EM_CFG_GPSTITLE,                    // Encode widget-GPS title,corresponding to NET_OSD_GPS_TITLE
            NET_EM_CFG_OSD_NUMBERSTATPLAN,          // Configuration of the statistical plane,which about number of people,  use this config when Class type is NumberStatPlan, correspinding to NET_OSD_NUMBER_PLAN
            NET_EM_CFG_GPSSTARNUM_OSD,              // GPS Start number OSD config, used by vehicle equipment , corresponding to NET_CFG_GPSSTARNUM_OSD_INFO
            NET_EM_CFG_PICTURETITLE,                // Picture title,corresponding to NET_OSD_PICTURE_TITLE
            NET_EM_CFG_OSD_FACEFLOWSTAT,            // face flow stat,corresponding to NET_OSD_FACEFLOWSTAT_INFO

            NET_EM_CFG_PTZ_PRESET,                  // Preset Point Information Overlay,corresponding to NET_OSD_CFG_PTZ_PRESET
            NET_EM_CFG_PTZ_PATTERN,                 // Display Path Percentage Overlay Configuration,corresponding to NET_OSD_CFG_PTZ_PATTERN
            NET_EM_CFG_PTZ_RS485_DETECT,            // Overlay Configuration of Displaying RS485 Test Results,corresponding to NET_OSD_CFG_PTZ_RS485_DETECT
            NET_EM_CFG_PTZ_COORDINATES,             // Overlay configuration of display platform coordinates,corresponding to NET_OSD_CFG_PTZ_COORDINATES
            NET_EM_CFG_PTZ_DIRECTION,               // 	Overlay configuration for displaying the direction of the platform,corresponding to NET_OSD_CFG_PTZ_DIRECTION
            NET_EM_CFG_TEMPERATURE,                 // Overlay Configuration of Displaying Ambient Temperature,corresponding to NET_OSD_CFG_TEMPERATURE
            NET_EM_CFG_COVERS,                      // Cover Configuration ,corresponding to NET_OSD_CFG_COVERS
            NET_EM_CFG_USER_DEF_TITLE,              // User defined OSD title, corresponding to NET_OSD_USER_DEF_TITLE    special use by DHOP
            /*********the configuration about Encode**********************************************************************************/
            NET_EM_CFG_ENCODE_VIDEO = 1100,         // Encode-video options config, corresponding to NET_ENCODE_VIDEO_INFO
            NET_EM_CFG_ENCODE_VIDEO_PACK,           // Encode-video pack options config, corresponding to NET_ENCODE_VIDEO_PACK_INFO
            NET_EM_CFG_ENCODE_VIDEO_SVC,            // Encode-video SVC options config, corresponding to NET_ENCODE_VIDEO_SVC_INFO
            NET_EM_CFG_ENCODE_VIDEO_PROFILE,        // Encode-video profile options config, corresponding to NET_ENCODE_VIDEO_PROFILE_INFO
            NET_EM_CFG_ENCODE_AUDIO_COMPRESSION,    // Encode-video audio compression options config, corresponding to NET_ENCODE_AUDIO_COMPRESSION_INFO
            NET_EM_CFG_ENCODE_AUDIO_INFO,           // Encode-video audio options config, corresponding to NET_ENCODE_AUDIO_INFO
            NET_EM_CFG_ENCODE_SNAP_INFO,            // Encode-video snap options config, corresponding to NET_ENCODE_SNAP_INFO
            NET_EM_CFG_ENCODE_SNAPTIME,             // Encode-video snap time options config, corresponding to NET_ENCODE_SNAP_TIME_INFO
            NET_EM_CFG_ENCODE_CHANNELTITLE,         // Encode-video channel title options config, corresponding to NET_ENCODE_CHANNELTITLE_INFO

            /**********the configuration about audio**********************************************************************************/
            NET_EM_CFG_AUDIOIN_SOURCE = 1200,       // Audio-input audio source config, corresponding to NET_ENCODE_AUDIO_SOURCE_INFO
            NET_EM_CFG_AUDIOIN_DENOISE,             // Audio-denoise config, corresponding to NET_AUDIOIN_DENOISE_INFO
            NET_EM_CFG_AUDIOIN_VOLUME,              // Audio-volume of audio input, corresponding to NET_AUDIOIN_VOLUME_INFO
            NET_EM_CFG_AUDIOOUT_VOLUME,             // Audio-volume of audio output, corresponding to NET_AUDIOOUT_VOLUME_INFO
            NET_EM_CFG_AUDIOOUT_MODE,               // Audio out mode, corresponding to NET_AUDIOOUT_MODE_INFO

            /**********the configuration about video**********************************************************************************/
            NET_EM_CFG_VIDEOIN_SWITCHMODE = 1300,   // VideoIn-switch mode config, corresponding to NET_VIDEOIN_SWITCH_MODE_INFO
            NET_EM_CFG_VIDEOIN_COLOR,               // VideoIn-color options config, corresponding to NET_VIDEOIN_COLOR_INFO			
            NET_EM_CFG_VIDEOIN_IMAGE_OPT,           // VideoIn-image options config, corresponding to NET_VIDEOIN_IMAGE_INFO
            NET_EM_CFG_VIDEOIN_STABLE,              // VideoIn-stable config, corresponding to NET_VIDEOIN_STABLE_INFO
            NET_EM_CFG_VIDEOIN_IRISAUTO,            // VideoIn-auto iris config-, corresponding to NET_VIDEOIN_IRISAUTO_INFO
            NET_EM_CFG_VIDEOIN_IMAGEENHANCEMENT,    // VideoIn-image enhancement config, corresponding to NET_VIDEOIN_IMAGEENHANCEMENT_INFO
            NET_EM_CFG_VIDEOIN_EXPOSURE_NORMAL,     // VideoIn-normal exposure config, corresponding to NET_VIDEOIN_EXPOSURE_NORMAL_INFO
            NET_EM_CFG_VIDEOIN_EXPOSURE_OTHER,      // VideoIn-other exposure config, corresponding to NET_VIDEOIN_EXPOSURE_OTHER_INFO
            NET_EM_CFG_VIDEOIN_EXPOSURE_SHUTTER,    // VideoIn-exposure shutter config, corresponding to NET_VIDEOIN_EXPOSURE_SHUTTER_INFO
            NET_EM_CFG_VIDEOIN_BACKLIGHT,           // VideoIn-back light config, corresponding to NET_VIDEOIN_BACKLIGHT_INFO
            NET_EM_CFG_VIDEOIN_INTENSITY,           // VideoIn-Intensity config, corresponding to NET_VIDEOIN_INTENSITY_INFO
            NET_EM_CFG_VIDEOIN_LIGHTING,            // VideoIn-lighting config, corresponding to NET_VIDEOIN_LIGHTING_INFO
            NET_EM_CFG_VIDEOIN_DEFOG,               // VideoIn-defog config, corresponding to NET_VIDEOIN_DEFOG_INFO
            NET_EM_CFG_VIDEOIN_FOCUSMODE,           // VideoIn-focus mode config, corresponding to NET_VIDEOIN_FOCUSMODE_INFO
            NET_EM_CFG_VIDEOIN_FOCUSVALUE,          // VideoIn-focus options config, corresponding to NET_VIDEOIN_FOCUSVALUE_INFO
            NET_EM_CFG_VIDEOIN_WHITEBALANCE,        // VideoIn-white balance config, corresponding to NET_VIDEOIN_WHITEBALANCE_INFO
            NET_EM_CFG_VIDEOIN_DAYNIGHT,            // VideoIn-day night config, corresponding to NET_VIDEOIN_DAYNIGHT_INFO
            NET_EM_CFG_VIDEOIN_DAYNIGHT_ICR,        // VideoIn-ICR config, corresponding to NET_VIDEOIN_DAYNIGHT_ICR_INFO
            NET_EM_CFG_VIDEOIN_SHARPNESS,           // VideoIn-shrpness config, corresponding to NET_VIDEOIN_SHARPNESS_INFO
            NET_EM_CFG_VIDEOIN_COMM_DENOISE,        // VideoIn-comm denoise config, corresponding to NET_VIDEOIN_DENOISE_INFO
            NET_EM_CFG_VIDEOIN_3D_DENOISE,          // VideoIn-3D denoise config, corresponding to NET_VIDEOIN_3D_DENOISE_INFO
            NET_EM_CFG_VIDEOIN_FOCUSEX,             // VideoIn-foucus on extended configuratio corresponding to NET_VIDEOIN_FOCUS_INFO_EX
            NET_EM_CFG_VIDEOIN_LIGHTINGEX,          // Extension of supplementary lamp configuration,corresponding to NET_VIDEOIN_LIGHTINGEX_INFO
            NET_EM_CFG_VIDEOIN_VIEWRANGESTATUS,     // VideoIn-ViewRangeStatus config,corresponding to NET_CFG_VIDEOIN_VIEWRANGESTATUS_INFO
            /***********the configuration about case**********************************************************************************/
            NET_EM_CFG_ENCODE_PLAN = 1400,          // Case-the plan config of encode, corresponding to NET_ENCODE_PLAN_INFO
            NET_EM_CFG_COMPOSE_CHANNEL,             // Compose channel config, corresponding to NET_COMPOSE_CHANNEL_INFO

            /***********the configuration about alarm gateway ************************************************************************/
            NET_EM_CFG_ALARM_SOUND = 1500,      // alarm sound config of alarm gateway, corresponding to NET_ALARM_SOUND_INFO 
            NET_EM_CFG_LOCAL_EXT_ALARM = 1501,      // Local ext alarm config,corresponding to NET_LOCAL_EXT_ALARM_INFO,ChannelID is invalid
            NET_EM_CFG_REMOTE_ALARM_BELL = 1502,        // Remote Alarm Bell Config, corresponding to NET_CFG_REMOTE_ALARM_BELL_INFO
            NET_EM_CFG_FIRE_WARNINGMODE = 1503,      // Fire Warning Mode, corresponding to NET_FIREWARNING_MODE_INFO
            NET_EM_CFG_FIRE_WARNING = 1504,          // Fire Warning Config, corresponding to NET_FIRE_WARNING_INFO
            NET_EM_CFG_HOT_COLD_SPOT_WARNING = 1505, // hot cold spot warning config, corresponding to NET_HOT_COLD_SPOT_WARNING_INFO
            NET_EM_CFG_COAXIAL_ALARMLOCAL,           // coaxial local alarm config, corresponding to NET_COAXIAL_ALARMLOCAL_INFO

            /**********network application configuration***********************************************************************************************/
            NET_EM_CFG_ACCESS_POINT = 1600,     // WIFI server configuration(access point),corresponding to NET_NETAPP_ACCESSPOINT
            NET_EM_CFG_LDAP,                        // LDAP configuration, corresponding to NET_NETAPP_LDAP
            NET_EM_CFG_SYSLOG,                      // Syslog configuration, corresponding to NET_NETAPP_SYSLOG	
            NET_EM_CFG_NETAUTOADAPTTRANSIT,         // net auto adapt transit configuration,corresponding to NET_NETAUTOADAPTTRANSIT
            NET_EM_CFG_WIRELESS,                    // Cellular NetWork, corresponding to NET_NETAPP_WIRELESS

            NET_EM_CFG_NAS = 1700,      // NAS config, corresponding to NET_NAS_INFO 
            NET_EM_CFG_PPPOE,                       // PPPOE config£¬corresponding to  NET_PPPOE_INFO  
            NET_EM_CFG_EMAIL,                       // Email config£¬corresponding to  NET_EMAIL_INFO  
            NET_EM_CFG_DDNS,                        // DDNS config£¬corresponding to  NET_DDNS_INFO 

            /**************SCADA configuration****************************************************************************************/
            NET_EM_CFG_SCADA_PROTOCOLS_MANAGER = 1800,      // Protocol manager config,corresponding to NET_SCADA_PROTOCOLS_MANAGER
            NET_EM_CFG_SCADA_DEVICEINFO_CFG,                // Device info config, corresponding to NET_SCADA_DEVICEINFO_CFG
            NET_EM_CFG_SCADA_CONTROLLER_SITE,               // Controller config £¬corresponding to NET_CFG_SCADA_CONTROLLER_SITE_INFO

            /**************NetApp configuration****************************************************************************************/
            NET_EM_CFG_NETAPP_LINK_LAYER_VPN = 1900,        // Link layer VPN config,correspongindg to NET_NETAPP_LINK_LAYER_VPN_CFG
            NET_EM_CFG_NETAPP_SSHD,                         // SSHD config, correspongindg to NET_NETAPP_SSHD_CFG
            NET_EM_CFG_NETAPP_COMMUNICATION_LIST,           // Communication list config, corresponding NET_NETAPP_COMMUNICATION_LIST_CFG, not related to channels,ChannelID must be fill in -1 

            /**************Tripartite platform access configuration****************************************************************************************/
            NET_EM_CFG_VSP_CHINA_TOWER = 2000,              // (China tower)VSP china tower config,corresponding to NET_VSP_CHINA_TOWER 
            NET_EM_CFG_VSP_SHDXJT = 2001,                   // Access Configuration of China Telecom Mobile Shopping ,corresponding to NET_VSP_SHDXJT 
            NET_EM_CFG_VSP_CONSUME,                         // consume config, corresponding to NET_CFG_VSP_CONSUME,ChannelID must be fill in -1 

            /**************intelligent configuration****************************************************************************************/
            NET_EM_CFG_STEREO_CALIBRATE = 2100,             // stero calibrate config, corresponding to NET_STEREO_CALIBRATE_INFO
            NET_EM_CFG_STEREO_CALIBRATEMATRIX_MULTISENSOR,  // Multi Sensor configuration, corresponding to NET_MULTI_SENSOR_INFO
            NET_EM_CFG_CROWDDISTRIMAP_CALIBRATE,            // config of the calibrate of crowddistri map, corresponding to NET_CROWDDISTRIMAP_CALIBRATE_INFO
            NET_EM_CFG_TRAFFIC_NOPASSING,                   // Traffic No Passing config, corresponding to NET_TRAFFIC_NOPASSING_INFO
            NET_EM_CFG_FIGHT_CALIBRATE,                     // fight calibrate config, corresponding to NET_FIGHT_CALIBRATE_INFO
            NET_EM_CFG_FACE_RECOGNITION_ALARM,              // config of linkage alarm chanel for face recognition, corresponding to NET_FACE_RECOGNITION_ALARM_INFO
            NET_EM_CFG_STEREO_CALIBRATEMATRIX_MULTIMODE,    // Multi Mode configuration, corresponding to NET_CALIBRATEMATRIX_MULTIMODE_INFO
            NET_EM_CFG_AUTO_SNAP_SCHEDULE,                  // Timing snap configuration of intelligent aquaculture, corresponding to NET_CFG_AUTO_SNAP_SCHEDULE_INFO

            /**************radar configuration****************************************************************************************/
            NET_EM_CFG_RADAR = 2200,                // radar configuration, corresponding to DEV_RADAR_CONFIG
            /**************VTH password configuration**************************************************************************************/
            NET_EM_CFG_VTH_PASSWORD = 2300,             // VTH password configuration,corresponding to NET_CFG_VTH_PASSWORD_INFO
            NET_EM_CFG_REGISTAR = 2301,             // registar server configuration,corresponding NET_CFG_REGISTAR_INFO
            NET_EM_CFG_SIP = 2302,             // sip configuration, corresponding NET_CFG_SIPSERVER_INFO
            NET_EM_CFG_DEVICE_LOGIN_INFO = 2303,            // Device Login Info configuration, corresponding to NET_CFG_DEVICE_LOGIN_INFO
            /**********Front shield cover configuration***********************************************************************************************/
            NET_EM_CFG_AELENSMASK = 2400,             // Front shield cover configuration,corresponding to NET_CFG_AELENSMASK_INFO
            NET_EM_CFG_ULTRASONIC = 2500,           // ultrasonic configuration,corresponding to NET_CFG_ULTRASONIC_INFO 
            /**********ARC Configuration***********************************************************************************************/
            NET_EM_CFG_ARMSCHEDULE = 2600,          // arming plan configuration,corresponding to NET_CFG_ARMSCHEDULE_INFO
            NET_EM_CFG_CID_REPORT = 2601,             // configuration of CID report,corresponding to NET_CFG_CID_REPORT_INFO
            NET_EM_CFG_VSP_HONEYWELL = 2602,            // Configuration of HoneyWell server£¬ corresponding to NET_CFG_VSP_HONEYWELL_INFO
            NET_EM_CFG_KBUSER_PASSWORD = 2603,              // Configuration of keyboard password£¬corresponding to NET_CFG_KBUSER_PASSWORD	
            /**********record snap configuration*******************************************************************************************/
            NET_EM_CFG_RECORDEXTRA = 3610,              // RecodeExtra config, corresponding to NET_CFG_RECORDEXTRA_INFO
            NET_EM_CFG_AUTO_RECORDBACKUP_RESTORE = 3611,    // Auto record backup restore, corresponding to NET_CFG_AUTORECORDBACKUPRESTORE_INFO
            NET_EM_CFG_FACESNAPSHOT = 3612,         // face snap shot, corresponding to NET_CFG_FACESNAPSHOT_INFO

            /**********video diagnosis configuration*******************************************************************************************/
            NET_EM_VIDEODIAGNOSIS_PROJECT = 3700,           // video diagnosis plan config, corresponding to NET_VIDEODIAGNOSIS_PROJECT_INFO
            NET_EM_CFG_VIDEO_DIAGNOSIS_PROJECT_MONTH = 3701,// video diagnosis plan config, corresponding to NET_CFG_VIDEODIAGNOSIS_PROJECT_MONTH_INFO,ChannelID must be -1
            /**********Position report policy configuration***********************************************************************************/
            NET_EM_CFG_POSITIONREPORTPOLICY = 3800,         // GPS postion report policy config, corresponding to NET_CFG_POSITIONREPORTPOLICY_INFO
            NET_EM_CFG_VEHICLE_WORKTIMESCHEDULE,            // Vehicle Work time schedule£¬corresponding to NET_CFG_VEHICLE_WORKTIMESCHEDULE_INFO
            NET_EM_CFG_VEHICLE_LOAD,                        // Vehicle Load Number, corresponding to NET_CFG_VEHICLE_LOAD_INFO
            NET_EM_CFG_TICKETPRINT,                         // Bus print ticket price, corresponding to NET_CFG_TICKETPRINT_INFO
            NET_EM_CFG_VEHICLEAUTOMAIN,                     // The delay time to shutdown, corresponding to NET_CFG_VEHICLEAUTOMAIN_INFO
            NET_EM_CFG_VEHICLENETSERVER,                    // Vehicle NetServer Configuration(India BRT), corresponding to NET_CFG_VEHICLENETSERVER_INFO
            NET_EM_CFG_IMSIBIND,                            // IMSI bind configuration, corresponding to NET_CFG_IMSIBIND_INFO
            NET_EM_CFG_VEHICLE_MAINTAINCE,                  // vehicle maintaince configuration,corresponding to NET_CFG_VEHICLE_MAINTAINCE_INFO
            /***********AccessControl configuration******************************************************************************************/
            NET_EM_CFG_ACCESSCTL_BLACKLIST = 3900,  // blacklist of accesscontrol config, corresponding to NET_CFG_ACCESSCTL_BLACKLIST
            NET_EM_CFG_ACCESSCTL_BLACKLIST_LINK = 3901, // blacklist of accesscontrol link config,corresponding to NET_CFG_ALARM_MSG_HANDLE
            NET_EM_CFG_ACCESSCTL_SPECIALDAY_GROUP = 3902,   // holiday of accesscontrol config, corresponding to NET_CFG_ACCESSCTL_SPECIALDAY_GROUP_INFO
            NET_EM_CFG_ACCESSCTL_SPECIALDAYS_SCHEDULE = 3903,   // holiday schdule of accesscontrol config, corresponding to NET_CFG_ACCESSCTL_SPECIALDAYS_SCHEDULE_INFO
            NET_EM_CFG_ACCESSCTL_AUTH_MODE = 3904,  // online and offline open door auth mode of accesscontrol config,corresponding to NET_CFG_ACCESSCTL_AUTH_MODE
            NET_EM_CFG_ACS_FACE_RECOGNITION_SCHEME = 3905, // Entrance guard face recognition configuration, corresponding to NET_CFG_ACS_FACE_RECOGNITION_SCHEME
            NET_EM_CFG_FORBIDDEN_ADVERT_PLAY = 3906, // Forbidden advert play configuration, corresponding to NET_CFG_FORBIDDEN_ADVERT_PLAY, not related to channels, ChannelID must be -1
            NET_EM_CFG_BGY_CUSTOMERCFG = 3907, // device current mode type configuration, corresponding to NET_CFG_BGY_CUSTOMERCFG, not related to channels, ChannelID must be -1
            NET_EM_CFG_ACCESSCTL_KEYBINDINGINFOCFG = 3908, // information of different digital buttons configuration, corresponding to NET_CFG_ACCESSCTL_KEYBINDINGINFOCFG, not related to channels, ChannelID must be -1

            /*********** Custom configuration ************************************************************************************************/
            NET_EM_CFG_SERIALNOWHITETABLE = 4000,     // send serial whith list to NVR , corresponding to NET_CFG_SERIALNOWHITETABLE_INFO
            NET_EM_CFG_LXSJ_WXJJ = 4001,        // wuxijiaojing , corresponding to NET_CFG_LXSJ_WXJJ_INFO
            NET_EM_CFG_SENSOR_ALARM_GLOBAL = 4002,      // Sensor alarm global config corresponding to NET_CFG_SENSOR_ALARM_GLOBAL_INFO
            NET_EM_CFG_SENSOR_ALARM = 4003,     // Sensor alarm config corresponding to NET_CFG_SENSOR_ALARM_INFO
            NET_EM_CFG_VSP_LXSJ = 4004,     // VSP_LXSJ configuration corresponding to NET_CFG_VSP_LXSJ_INFO
            NET_EM_CFG_TIMINGCAPTURE = 4005,        // TimingCapture configuration corresponding to NET_CFG_TIMINGCAPTURE_INFO
            NET_EM_CFG_WATER_MONITOR_TITLE = 4006,      // Water monitor title configuration corresponding to NET_CFG_WATER_MONITOR_TITLE_INFO
            NET_EM_CFG_ATTENDANCE_MODEL_INFO = 4007,        // attendance model info corresponding to  NET_CFG_ATTENDANCE_MODEL_INFO
            NET_EM_CFG_KT_RTSP_FLAG = 4008,     // KT's customized RTSP enabling configuration, corresponding to NET_CFG_KT_RTSP_FLAG_INFO ,ChannelID must be -1
            NET_EM_CFG_RTSP_ABORT_LIST = 4009,      // Get a list of videos stored locally on the device after RTSP disconnection (only access, no settings), corresponding to NET_CFG_RTSP_ABORT_LIST_INFO ,ChannelID must be -1
            NET_EM_CFG_FILE_HOLD_DAYS = 4010,       // Recording saving days configuration,corresponding to NET_CFG_FILE_HOLD_DAYS_INFO
            NET_EM_CFG_ACCESS_FUNCTION = 4011,     // Access function config corresponding to NET_CFG_ACCESS_FUNCTION_INFO, not related to channels, ChannelID must be fill in -1
            NET_EM_CFG_RELAY_STATE = 4012,      // Relay state config£¬corresponding to struct NET_CFG_RELAY_STATE_INFO
            /***********Ptz configuration************************************************************************************************/

            /***********cloud operation configuration************************************************************************************************/
            NET_EM_CFG_CLOUDUPLOADTIME = 5000,           // cloud upload time configuration , corresponding to NET_CFG_CLOUDUPLOADTIME_INFO

            /***********radar adaptor configuration************************************************************************************************/
            //when call CLIENT_SetConfig, restart is invalid
            NET_EM_CFG_RADAR_MAPPARA = 6000,         // radar map param configuration, corresponding to NET_CFG_RADAR_MAPPARA_INFO
            NET_EM_CFG_RADAR_CALIBRATION = 6001,         // radar calibration configuration, corresponding to NET_CFG_RADAR_CALIBRATION_INFO
            NET_EM_CFG_RADAR_LINKSD = 6002,         // radar link SD enable configuration, corresponding to NET_CFG_RADAR_LINKSD_INFO
            NET_EM_CFG_RADAR_RULELINE = 6003,         // radar guard line configuration, corresponding to NET_CFG_RADAR_RULELINE_INFO
            NET_EM_CFG_RADAR_ANALYSERULE = 6004,         // radar link analyse rule configuration, corresponding to NET_CFG_RADAR_ANALYSERULE_INFO
            NET_EM_CFG_RADAR_TRACKGLOBALCONFIG = 6005,      // radar track global configuration, corresponding to NET_CFG_RADAR_TRACKGLOBALCONFIG_INFO
            NET_EM_CFG_RADAR_RADARPARA = 6006,          // radar param configuration, corresponding to NET_CFG_RADAR_RADARPARA_INFO
            NET_EM_CFG_RADAR_REMOTESDLINK = 6007,           // radar link remote SD enable configuration, corresponding to NET_CFG_RADAR_REMOTESDLINK_INFO
            NET_EM_CFG_RADAR_RADARLINKDEVICE = 6008,            // radar link device configuration, corresponding to NET_CFG_RADAR_RADARLINKDEVICE_INFO
            NET_EM_CFG_RADAR_MAPOSDPARA = 6009,         // radar map OSD configuration, corresponding to NET_CFG_RADAR_MAPOSDPARA_INFO

            /***********Ptz configuration************************************************************************************************/
            NET_EM_CFG_PTZ_SPEED = 7000,            // PtzSpeed config, corresponding to NET_CFG_PTZ_SPEED
            NET_EM_CFG_PTZ_HORIZONTAL_ROTATION_GROUP_SCAN = 7001,       // PTZ horizontal rotation group scanning, corresponding to NET_CFG_HORIZONTAL_ROTATION_GROUP_SCAN_INFO 
            NET_EM_CFG_AUTOSCAN = 7002,                     // AutoScan configuration, corresponding to NET_CFG_AUTOSCAN_INFO 

            /***********Lecheng Camera custom configuration************************************************************************************************/
            NET_EM_CFG_CASCADE_LIGHT = 8000,            // cascade light configuration, corresponding to NET_CFG_CASCADE_LIGHT_INFO
            NET_EM_CFG_LE_SMARTTRACK = 8001,         // LeChange simple smart track, corresponding to NET_CFG_LE_SMARTTRACK_INFO
            NET_EM_CFG_LE_LENS_MASK = 8002,         // LeChange lens mask configuration, corresponding to NET_CFG_LE_LENS_MASK_INFO

            /***********cloud operation configuration************************************************************************************************/
            NET_EM_CFG_VSP_PAAS = 9000,           // lecheng cloud register config configuration , corresponding to NET_CFG_CLOUDUPLOADTIME_INFO
            NET_EM_CFG_VSP_GAYS_SERVER = 9001,          // Public security 1 platform input config(GB server),corresponding to NET_CFG_VSP_GAYS_SERVER_INFO,ChannelID must be -1
            NET_EM_CFG_VSP_CO_SIGN_SERVER = 9002,           // Co-signing server configuration,corresponding to NET_CFG_VSP_CO_SIGN_SERVER_INFO,ChannelID must be -1
            NET_EM_CFG_VSP_GAVI = 9003,         // Access configuration of public security video and image information application system. Corresponding to NET_EM_CFG_VSP_GAVI.ChannelID must be -1

            /***********gateway configuration**************************************************************************************************/
            NET_EM_CFG_TRAFFICSTROBE = 9100,            // gateway configuration, corresponding to NET_CFG_TRAFFICSTROBE_INFO

            /***********LED screen configuration************************************************************************************************/
            NET_EM_CFG_LED_TEXT = 9200,           // LED screen display configuration,corresponding to NET_CFG_LED_TEXT
            NET_EM_CFG_LED_TEXT_ARRAY = 9201,           // LED screen display array configuration,corresponding to NET_CFG_LED_TEXT_ARRAY

            /***********Disable linkage configuration*******************************************************************************************/
            NET_EM_CFG_DISABLE_LINKAGE = 9300,          // Disable linkage configuration,corresponding to NET_CFG_DISABLE_LINKAGE,not related to channels,ChannelID must be fill in -1
            NET_EM_CFG_DISABLE_LINKAGE_TIME_SECTION = 9301,  // Disable linkage time section configuration, corresponding to NET_CFG_DISABLE_LINKAGE_TIME_SECTION, not related to channels,ChannelID must be fill in -1

            /***********Matrix configuration************************************************************************************************/
            NET_EM_CFG_MATRIX_NETKBDFASTCTRL = 9400,        // Fast control configuration of network beyboard, corresponding to NET_CFG_MATRIX_NETKBDFASTCTRL_INFO

            /***********Vedio configuration************************************************************************************************/
            NET_EM_CFG_VIDEO_CHANNEL_LABEL = 9600,  // configuration of channel laber, corresponding to NET_CFG_VIDEO_CHANNEL_LABEL_INFO
            NET_EM_CFG_VIDEO_IMAGE_CTRL = 9601,     // Image Rotation Setting Capability Configuration ,corresponding to NET_EM_CFG_VIDEO_IMAGE_CTRL_INFO

            /***********Traffic configuration***************************************************************************************************/
            NET_EM_CFG_TRAFFIC_LATTICE_SCREEN = 10000,  // The configuration of traffic lattice screen, corresponding to NET_CFG_TRAFFIC_LATTICE_SCREEN_INFO
            NET_EM_CFG_TRAFFIC_VOICE_BROADCAST = 10001, // The configuration of traffic voice broadcast, corresponding to NET_CFG_TRAFFIC_VOICE_BROADCAST_INFO
            NET_EM_CFG_SCENE_SNAP_SHOT_WITH_RULE2 = 10002, // The configuration of scene snap shot with rule2, corresponding to NET_CFG_SCENE_SNAP_SHOT_WITH_RULE2_INFO

            /***********DoorBell configuration******************************************************************************************/
            NET_EM_CFG_DOORBELL_EXTERNALDOORBELL = 11000,       // External door bell configuration, corresponding to NET_CFG_DOORBELL_EXTERNALDOORBELL, not related to channels,ChannelID must be fill in -1


            /***********Thermal imaging related configuration******************************************************************************************/
            NET_EM_CFG_SENSOR_MAINTAIN = 11100,     //Maintenance configuration of thermal imaging machine core,corresponding to NET_CFG_SENSOR_MAINTAIN
            NET_EM_CFG_TILT_LIMIT = 11101,          // Limitation of Pitch Angle in Laser Ranging,corresponding to NET_CFG_TILT_LIMIT
            NET_EM_CFG_RADIO_REGULATOR = 11102,     // Standard blackbody configuration of human body temperature measurement, corresponding to NET_CFG_RADIO_REGULATOR, ChannelID can not be -1

            /***********KVM configuration******************************************************************************************/
            NET_EM_CFG_KVM_MAIN_NODE = 12000,                    // main node configuration of key, video and mouse, corresponding to NET_CFG_KVM_MAIN_NODE, not related to channels, ChannelID must be fill in -1
            NET_EM_CFG_KVM_HOT_KEY = 12001,                      // hot key configuration of key, video and mouse, corresponding to NET_CFG_KVM_HOT_KEY, not related to channels, ChannelID must be fill in -1
            NET_EM_CFG_KM_TRANS_ENCRYPT = 12002,                 // transmission, encrypt configuration of key and mouse, corresponding to NET_CFG_KM_TRANS_ENCRYPT, not related to channels, ChannelID must be fill in -1
            NET_EM_CFG_NET_TV_DEVICE = 12003,                    // The config of Net decoding device, corresponding to NET_CFG_NET_TV_DEVICE

            /***********Record default config******************************************************************************************/
            NET_EM_CFG_COURSE_RECORD_DEFAULT_CONFIG = 12100,     // Record default config, corresponding to NET_CFG_COURSE_RECORD_DEFAULT_CONFIG

            /***********AroundWifi configuration*****************************************************************************************/
            NET_EM_CFG_WIFI_INSTALL_PARAM = 12200,              // Wifi device install config, corresponding to NET_CFG_WIFI_INSTALL_PARAM, not related to channels,ChannelID must be fill in -1

            /***********storage configuration******************************************************************************************/
            NET_EM_CFG_STORAGE_HEALTH_ABNORMAL = 12300,         // storage health abnormal config, corresponding to NET_CFG_STORAGE_HEALTH_ABNORMAL, not related to channels,ChannelID must be fill in -1

            /***********lora gateway configuration***************************************************************************************/
            NET_EM_CFG_LORA_GATEWAY_BASIC = 12400,              // lora gateway basic configuration, corresponding to NET_CFG_LORA_GATEWAY_BASIC
            NET_EM_CFG_LORA_GATEWAY_ACCESS = 12401,             // lora gateway access configuration, corresponding to NET_CFG_LORA_GATEWAY_ACCESS
            NET_EM_CFG_LORA_GATEWAY_RADIO = 12402,              // lora gateway radio configuration, corresponding to NET_CFG_LORA_GATEWAY_RADIO

            /***********door machine configuration***************************************************************************************/
            NET_EM_CFG_VTS_INFO = 12500,                        // VTS info configuration, corresponding to NET_CFG_VTS_INFO, not related to channels,ChannelID must be fill in -1

            /***********sound configuration******************************************************************************************/
            NET_EM_CFG_SOUND = 12600,                        // sound configuration, corresponding to NET_CFG_SOUND
        }

        #region: Face
        
        public enum EM_OPERATE_FACERECONGNITIONDB_TYPE
        {
            UNKOWN,
            /// <summary>
            /// Add personnel information and face samples, if researchers already exists, image data and the original data
            /// 添加人员信息和人脸样本,如果人员已经存在,图片数据和原来的数据合并
            /// </summary>
            ADD,
            /// <summary>
            /// Delete the personnel information and face samples
            /// 删除人员信息和人脸样本
            /// </summary>
            DELETE,
            /// <summary>
            /// Modify person info and human face sample, must input person UID
            /// 修改人员信息和人脸样本,人员的UID标识必填
            /// </summary>
            MODIFY,
            /// <summary>
            /// Delete person info and human face via UID
            /// 通过UID删除人员信息和人脸样本
            /// </summary>
            DELETE_BY_UID,
        }
        public enum EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE
        {
            /// <summary>
            /// unknown
            /// 未知
            /// </summary>
            UNKNOWN,
            /// <summary>
            /// wearing glasses
            /// 戴眼镜
            /// </summary>
            WEAR_GLASSES,
            /// <summary>
            /// smile
            /// 微笑
            /// </summary>
            SMILE,
            /// <summary>
            /// anger
            /// 愤怒
            /// </summary>
            ANGER,
            /// <summary>
            /// sadness
            /// 悲伤
            /// </summary>
            SADNESS,
            /// <summary>
            /// disgust
            /// 厌恶
            /// </summary>
            DISGUST,
            /// <summary>
            /// fear
            /// 害怕
            /// </summary>
            FEAR,
            /// <summary>
            /// surprise
            /// 惊讶
            /// </summary>
            SURPRISE,
            /// <summary>
            /// neutral
            /// 正常
            /// </summary>
            NEUTRAL,
            /// <summary>
            /// laugh
            /// 大笑
            /// </summary>
            LAUGH,
            /// <summary>
            /// not wear glasses
            /// 没戴眼镜
            /// </summary>
            NOGLASSES,
            /// <summary>
            /// happy
            /// 高兴
            /// </summary>
            HAPPY,
            /// <summary>
            /// confused
            /// 困惑
            /// </summary>
            CONFUSED,
            /// <summary>
            /// scream
            /// 尖叫
            /// </summary>
            SCREAM,
            /// <summary>
            /// wearing sun glasses
            /// 戴太阳眼镜
            /// </summary>
            WEAR_SUNGLASSES,
        }
        public enum EM_GLASSES_TYPE
        {
            /// <summary>
            /// unknown
            /// 未知
            /// </summary>
            UNKNOWN,
            /// <summary>
            /// sun glasses
            /// 太阳眼镜
            /// </summary>
            SUNGLASS,
            /// <summary>
            /// normal galsses
            /// 普通眼镜
            /// </summary>
            GLASS,
        }
        public enum EM_RACE_TYPE
        {
            UNKNOWN,
            NODISTI,
            YELLOW,
            BLACK,
            WHITE,
        }
        public enum EM_EYE_STATE_TYPE
        {
            /// <summary>
            /// unknown
            /// 未知
            /// </summary>
            UNKNOWN,
            /// <summary>
            /// no disringuish
            /// 未识别
            /// </summary>
            NODISTI,
            /// <summary>
            /// close eyes
            /// 闭眼
            /// </summary>
            CLOSE,
            /// <summary>
            ///open eyes 
            /// 睁眼
            /// </summary>
            OPEN,
        }
        public enum EM_MOUTH_STATE_TYPE
        {
            /// <summary>
            /// unknown
            /// 未知
            /// </summary>
            UNKNOWN,
            /// <summary>
            /// no disringuish
            /// 未识别
            /// </summary>
            NODISTI,
            /// <summary>
            /// close mouth
            /// 闭嘴
            /// </summary>
            CLOSE,
            /// <summary>
            /// open nouth
            /// 张嘴
            /// </summary>
            OPEN,
        }
        public enum EM_MASK_STATE_TYPE
        {
            /// <summary>
            /// unknown
            /// 未知
            /// </summary>
            UNKNOWN,
            /// <summary>
            /// no disringuish
            /// 未识别
            /// </summary>
            NODISTI,
            /// <summary>
            /// no mask
            /// 没戴口罩
            /// </summary>
            NOMASK,
            /// <summary>
            /// wearing mask
            /// 戴口罩
            /// </summary>
            WEAR,
        }
        public enum EM_BEARD_STATE_TYPE
        {
            /// <summary>
            /// unknown
            /// 未知
            /// </summary>
            UNKNOWN,
            /// <summary>
            /// no disringuish
            /// 未识别
            /// </summary>
            NODISTI,
            /// <summary>
            /// no beard
            /// 没胡子
            /// </summary>
            NOBEARD,
            /// <summary>
            /// have beard
            /// 有胡子
            /// </summary>
            HAVEBEARD,
        }
        public enum EM_PERSON_FEATURE_STATE
        {
            UNKNOWN,            // 未知
            FAIL,               // 建模失败,可能是图片不符合要求,需要换图片
            USEFUL,             // 有可用的特征值
            CALCULATING,        // 正在计算特征值
            UNUSEFUL            // 已建模，但算法升级导致数据不可用，需要重新建模
        }
        public enum EM_REGISTER_DB_TYPE
        {
            UNKNOWN,        // 未知
            NORMAL,         // 普通库
            BLACKLIST,      // 黑名单
            WHITELIST,      // 白名单
            VIP,            // VIP库
            STAFF,          // 员工库
            LEADER,         // 领导库
        }
        public enum EM_PERSON_FEATURE_ERRCODE
        {
            UNKNOWN,          // 未知
            PIC_FORMAT,       // 图片格式问题
            NO_FACE,          // 无人脸或不清晰
            MULTI_FACE,       // 多个人脸
            PIC_DECODE_FAIL,  // 图片解码失败
            NOT_RECOMMEND,    // 不推荐入库
            FACEDB_FAIL,      // 数据库操作失败
            GET_PICTURE,      // 获取图片失败
            SYSTEM_ERROR,     // 系统异常
        }
        public enum EM_ERRORCODE_TYPE
        {
            UNKNOWN = -1,               // 未知错误
            SUCCESS,               // 成功
            PERSON_NOT_EXIST,            // 人员不存在
            DATABASE_ERROR,             //  数据库操作失败
        }
        public enum EM_PIC_OPERATE_TYPE
        {
            UNKNOWN,         // 未知
            MODIFY,          // 修改
            ADD,             // 新增
            DEL              // 删除
        }
        public enum EM_OBJECT_TYPE
        {
            UNKNOWN = -1,         // 未知
            FACE,                    // 人脸
            HUMAN,                   // 人体
            VECHILE,                 // 机动车
            NOMOTOR,                 // 非机动车
            ALL,                     // 所有类型
        }
        public enum EM_FACERECOGNITION_FACE_TYPE
        {
            UNKOWN,
            /// <summary>
            /// All the faces 
            /// 所有人脸  
            /// </summary>
            ALL,
            /// <summary>
            /// recognition success
            /// 识别成功
            /// </summary>
            REC_SUCCESS,
            /// <summary>
            /// recognition fail
            /// 识别失败
            /// </summary>
            REC_FAIL,
        }
        public enum EM_FINDPIC_QUERY_MODE
        {
            UNKNOWN,               // 未知
            PASSIVE,               // 被动查询
            ACTIVE,                // 主动推送
        }

        // 以图搜图结果上报排序方式
        public enum EM_FINDPIC_QUERY_ORDERED
        {
            SIMILARITY,         // 按相似度从高到底
            TIME_FORWARD,       // 按时间正序
            TIME_REVERSE,       // 按时间倒序
        }
        public enum EM_FACE_AREA_TYPE
        {
            UNKOWN,
            /// <summary>
            /// eyebrow
            /// 眉毛
            /// </summary>
            EYEBROW,
            /// <summary>
            /// eye
            /// 眼睛
            /// </summary>
            EYE,
            /// <summary>
            /// nose
            /// 鼻子
            /// </summary>
            NOSE,
            /// <summary>
            /// mouth
            /// 嘴巴
            /// </summary>
            MOUTH,
            /// <summary>
            /// face
            /// 脸颊
            /// </summary>
            CHEEK,
        }
        public enum EM_FACE_COMPARE_MODE
        {
            UNKOWN,
            /// <summary>
            /// normal
            /// 正常
            /// </summary>
            NORMAL,
            /// <summary>
            /// Specify the face region combination area
            /// 指定人脸区域组合区域
            /// </summary>
            AREA,
            /// <summary>
            /// Intelligent model, the algorithm according to the situation of facial regions automatically select combination
            /// 智能模式,算法根据人脸各个区域情况自动选取组合 
            /// </summary>
            AUTO,
        }

        #region:Interfaces of adding/deleting/modifying/searching the face library
        #region:adding/deleting/modifying
        public enum EM_OPERATE_FACERECONGNITION_GROUP_TYPE
        {
            /// <summary>
            /// unknow
            /// </summary>
            UNKNOWN,
            /// <summary>
            /// add staff group info
            /// 添加人员组信息
            /// </summary>
            ADD,
            /// <summary>
            /// modify staff group info 
            /// </summary>
            MODIFY,
            /// <summary>
            /// delete staff group info
            /// </summary>
            DELETE,
        }
        public enum EM_PASSERBY_DB_OVERWRITE_TYPE
        {
            UNKNOWN = -1,       // 未知
            FULL_STOP,      // 满停止
            FULL_COVERAGE,  // 满覆盖
        }
        public enum EM_PASSERBY_DB_DUPLICATE_REMOVE_TYPE
        {
            UNKNOWN = -1,   // 未知
            ALL,            // 无条件去重
            TIME,           // 按时间间隔去重
            TIME_SLOT,      // 按时间段间隔去重
        }
        public enum EM_FACE_DB_TYPE
        {
            UNKOWN,
            /// <summary>
            /// History database, storage is to detect the human face information, usually does not contain face corresponding personnel information
            /// 历史数据库,存放的是检测出的人脸信息,一般没有包含人脸对应人员信息
            /// </summary>
            HISTORY,
            /// <summary>
            /// The blacklist database
            /// 黑名单数据库
            /// </summary>
            BLACKLIST,
            /// <summary>
            /// The whitelist database
            /// 白名单数据库,废弃
            /// </summary>
            WHITELIST,
            /// <summary>
            /// Alarm library
            /// 报警库
            /// </summary>
            ALARM,
        }
        #endregion
        #region: Searching
        #endregion
        #endregion
        public enum EM_CERTIFICATE_TYPE
        {
            UNKNOWN,
            /// <summary>
            /// IC
            /// 身份证
            /// </summary>
            IC,
            /// <summary>
            /// passport
            /// 护照
            /// </summary>
            PASSPORT,
            /// <summary>
            /// Officer Card
            /// 军官证
            /// </summary>
            OffICER_CARD
        }

        #endregion
    }
}
