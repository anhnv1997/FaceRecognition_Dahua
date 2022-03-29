using System;
using System.ComponentModel;
using System.Windows.Forms;
using FaceRecognition.Database;
using FaceRecognition.Objects;
using RestSharp;
using FaceRecognition.DahuaFunction;
using System.Net.NetworkInformation;
using FaceRecognition.UserControls;
using DHSDK;
using FaceRecognition.Forms;
using System.Threading;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using FaceRecognition.Databases;
using FaceRecognition.DahuaFuntion;

namespace FaceRecognition
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer speechSynthesizerObj;

        IntPtr pUser = new IntPtr();
        Int64 userID, m_lRealHandle;
        Int64 lastError = 0;
        const int DEFAULT_CHANNEL = 0;
        string errorMessage = "";

        Thread VehicleThread, HumanThread;
        ConcurrentQueue<UserControl> EventQueue = new ConcurrentQueue<UserControl>();

        List<FaceRepeatCheck> faceRecognizedList = new List<FaceRepeatCheck>();
        //ConcurrentBag<>

        private const int DEVICE_TYPE_CAMERA = 1;
        private const string CAMERA_IP = "CameraIP";
        private const string CAMERA_WEBCAM = "Webcam";

        private const int SERVER_STATUS_DISCONNECT = 0;
        private const int SERVER_STATUS_CONNECT = 1;
        private const int IMAGE_INDEX_CONNECT = 0;
        private const int IMAGE_INDEX_DISCONNECT = 1;

        private const int NWAIT_TIME = 5000;
        private const int NTRY_TIME = 3;

        private const int MODE_FACE = 0;
        private const int MODE_VEHICLE = 1;
        private const int MODE_FACEandVEHICLE = 2;
        private const string CHECK_IN_SERVER_URL = "http://erp.kztek.net/webservice/EasyERPService.asmx?op=CheckInByCardNumber";
        private event DHSDK_Init.DISCONNECT_CALLBACK disconnectCallback;
        private event DHSDK_Init.RECONNECT_CALLBACK reconnectCallback;
        public Form1()
        {
            InitializeComponent();
            UISync.Init(this);
            ConnectToSQLServer();
            speechSynthesizerObj = new SpeechSynthesizer();
            Dahua_InitSDK();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            #region: Load Language
            this.Text = MultiLanguage.GetString("App Name", StaticPool.Language);
            txtServerName.Text = StaticPool.ServerName;
            if (StaticPool.Language == "vi" || StaticPool.Language == "vi-VN")
            {
                MI_vi.Enabled = false;
                MI_en.Enabled = true;
            }
            else
            {
                MI_en.Enabled = false;
                MI_vi.Enabled = true;
            }
            #endregion

            tblUSer.LoadDataUser(StaticPool.users);

            tblCamera.LoadDataCamera(StaticPool.cams);

            await Task.Run(() =>
            {
                if (isPingSuccess())
                {
                    GetServerStatus(IMAGE_INDEX_CONNECT, SERVER_STATUS_CONNECT);
                    // tránh trường hợp thiết bị ping được nhưng đang trong quá trình khởi động=> try catch tránh exception
                    try
                    {
                        ConnectServer();
                    }
                    catch (Exception ex)
                    {
                        StaticPool.Logger_Error(ex.Message);
                        GetServerStatus(IMAGE_INDEX_DISCONNECT, SERVER_STATUS_DISCONNECT);
                    }
                }
                else
                {
                    StaticPool.server.ServerLastStatus = StaticPool.server.ServerCurrentStatus;
                    StaticPool.server.ServerCurrentStatus = SERVER_STATUS_DISCONNECT;
                    picStatus.Image = imageList1.Images[IMAGE_INDEX_DISCONNECT];
                }
            });

            LoadDevicetreeview();
            DahuaHelper.SetDefaultCameraview(userID, CameraLiveView.Handle, ref m_lRealHandle, ref errorMessage, 0);
            menuStrip1.Enabled = true;

            EventReader.FaceCandidateEvent += StreamReader_FaceCandidateEvent;
            EventReader.FaceStrangerEvent += StreamReader_FaceStrangerEvent;
            //EventReader.VehicleMotorEvent += StreamReader_VehicleMotorEvent;
            //EventReader.VehicleNonMotorEvent += StreamReader_VehicleNonMotorEvent;
            //MJpegStreamReader.FaceStrangerUIDEvent += MJpegStreamReader_FaceStrangerUIDEvent;

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }
        #region: Load
        private void LoadDevicetreeview()
        {
            TreeNode root = new TreeNode();
            root.Text = MultiLanguage.GetString("DeviceTreeViewName", StaticPool.Language);
            DeviceTreeview.Nodes.Add(root);

            AddTreeviewNode(root, "Camera", CAMERA_IP, 0);

            AddTreeviewNode(root, CAMERA_WEBCAM, CAMERA_WEBCAM, 0);

            foreach (TreeNode node in root.Nodes)
            {
                foreach (Camera camera in StaticPool.cams)
                {
                    if (camera.Type == 0 && node.Name == CAMERA_WEBCAM)
                    {
                        AddTreeviewNode(node, camera.Name, $"{CAMERA_WEBCAM}:" + camera.Id, 0);
                    }
                    else if (camera.Type == 1 && node.Name == CAMERA_IP)
                    {
                        AddTreeviewNode(node, camera.Name, $"{CAMERA_IP}:" + camera.Id, 0);
                    }
                }
            }
            DeviceTreeview.ExpandAll();
        }
        #endregion

        #region: Form
        #region: Set Language
        private void MI_en_Click(object sender, EventArgs e)
        {
            SetDefaultLanguage("en");
        }
        private void MI_vi_Click(object sender, EventArgs e)
        {
            SetDefaultLanguage("vi-VN");
        }
        #endregion

        #region: Setting
        private void tsmSetting_Click(object sender, EventArgs e)
        {
            frmSetting frm = new frmSetting(userID);

            DahuaHelper.StopLiveviewCameraDahua(ref m_lRealHandle, ref errorMessage);

            frm.Text = MultiLanguage.GetString("frmSetting", StaticPool.Language);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                DahuaHelper.LiveviewCameraDahua(ref userID, DEFAULT_CHANNEL, CameraLiveView.Handle, ref m_lRealHandle, ref errorMessage);
                MessageBox.Show(MultiLanguage.GetString("RestartRequest", StaticPool.Language));
            }
            else
            {
                DahuaHelper.LiveviewCameraDahua(ref userID, DEFAULT_CHANNEL, CameraLiveView.Handle, ref m_lRealHandle, ref errorMessage);
            }
        }
        #endregion

        #region: Choose Camera View
        private void DeviceTreeview_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name.Contains("CameraIP:"))
            {
                Camera camera = StaticPool.cams.GetCameraById(e.Node.Name.Substring(e.Node.Name.IndexOf(":") + 1));
                int channel = camera.Channel - 1;
                if (!DahuaHelper.StopLiveviewCameraDahua(ref m_lRealHandle, ref errorMessage))
                {
                    MessageBox.Show(MultiLanguage.GetString("StopLiveviewError", StaticPool.Language));
                    return;
                }
                if (!DahuaHelper.LiveviewCameraDahua(ref userID, channel, CameraLiveView.Handle, ref m_lRealHandle, ref errorMessage))
                {
                    MessageBox.Show(MultiLanguage.GetString("LiveviewError", StaticPool.Language));
                }
            }
        }
        #endregion

        #region: Tool

        #region: Face Report
        private void báoCáo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSystemReport frm = new frmSystemReport();
            frm.Text = MultiLanguage.GetString("frmSystemReport", StaticPool.Language);
            frm.ShowDialog();
        }
        #endregion

        #region: Vehicle Report
        private void vehicleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehicleReport frm = new frmVehicleReport();
            frm.ShowDialog();
        }
        #endregion

        #region: Search Person By Face
        private void timKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchPerson frmSearchPerson = new frmSearchPerson();
            frmSearchPerson.ShowDialog();
        }
        #endregion

        #endregion

        #region: Update server status
        private void timerServerStatusCheck_Tick(object sender, EventArgs e)
        {
            // Test Connect bang cah gui 1 lenh qua API,thời gian phản hồi nhanh, neu co response==> co ket noi
            try
            {
                if (isPingSuccess())
                {
                    bool isTestConnectSuccess = DahuaAPI.TestConnect() == true;
                    if (isTestConnectSuccess)
                    {
                        if (StaticPool.server.ServerCurrentStatus == SERVER_STATUS_DISCONNECT)
                        {
                            UpdateServerStatus(SERVER_STATUS_CONNECT);
                            ConnectServer();
                        }
                    }
                }
                else
                {
                    if (StaticPool.server.ServerCurrentStatus == SERVER_STATUS_CONNECT)
                    {
                        UpdateServerStatus(SERVER_STATUS_DISCONNECT);
                    }
                }
            }
            catch (Exception Ex)
            {
                StaticPool.Logger_Error(Ex.ToString());
                if (StaticPool.server.ServerCurrentStatus == SERVER_STATUS_CONNECT)
                {
                    UpdateServerStatus(SERVER_STATUS_DISCONNECT);
                }
            }
        }
        #endregion

        #region: Select Display Mode
        private void PicSellectDisplayMode_Click(object sender, EventArgs e)
        {
            frmSelectDisplayMode frm = new frmSelectDisplayMode();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show(MultiLanguage.GetString("RestartRequest", StaticPool.Language));
            }
        }
        #endregion

        #endregion

        #region: Event
        private void StreamReader_VehicleNonMotorEvent(object sender, VehicleNonMotorEventArgs vehicleNonMotorEventArgs)
        {
            string filenameGlobalImage = "";
            StaticPool.SaveImage(vehicleNonMotorEventArgs.GlobalImage, "GlobalVehicle.jpeg", out filenameGlobalImage);

            string filenameCandidateImage = "";
            StaticPool.SaveImage(vehicleNonMotorEventArgs.VehicleImage, "NonMotorImage.jpeg", out filenameCandidateImage);

            ucVehicleNonMotor vehicleNonMotor = GetVehicleNonMotorData(vehicleNonMotorEventArgs);

            VehicleThread = new Thread(() => EventQueue.Enqueue(vehicleNonMotor));
            VehicleThread.Start();

            tblVehicleEvent.InsertNonMotorVehicle(vehicleNonMotor, filenameGlobalImage, filenameCandidateImage);

            UISync.Execute(() =>
            {
                txtMotorCount.Text = StaticPool.VehicleNonMotor + "";
            });
        }
        private void StreamReader_VehicleMotorEvent(object sender, VehicleMotorEventArgs vehicleMotorEventArgs)
        {
            string filenameGlobalImage = "";
            StaticPool.SaveImage(vehicleMotorEventArgs.GlobalImage, "GlobalVehicle.jpeg", out filenameGlobalImage);

            string filenameCandidateImage = "";
            StaticPool.SaveImage(vehicleMotorEventArgs.VehicleImage, "CarImage.jpeg", out filenameCandidateImage);

            ucVehicleCar ucVehicle = GetVehicleMotorData(vehicleMotorEventArgs);

            VehicleThread = new Thread(() => EventQueue.Enqueue(ucVehicle));
            VehicleThread.Start();

            tblVehicleEvent.InsertMotorVehicle(ucVehicle, filenameGlobalImage, filenameCandidateImage);
            UISync.Execute(() =>
            {
                txtCarCount.Text = StaticPool.VehicleWithMotor + "";
            });
        }
        private void StreamReader_FaceStrangerEvent(object sender, FaceStrangerEventArgs e)
        {

            string StartTime = DateTime.Now.Add(new TimeSpan(0, 0, -25)).ToString("yyyy-MM-dd" + "T" + "HH:mm:ss" + "Z");
            string EndTime = DateTime.Now.ToString("yyyy-MM-dd" + "T" + "23:59:59" + "Z");
            int channel = Convert.ToInt32(e.CameraChannel) - 1;

            string imageName = "FaceStranger.jpg";
            string filePath = @".\Eventdata\" + DateTime.Now.ToString("yyyy_MM_dd");
            string savePath = StaticPool.SaveImageWithScale(e.FaceStrangerImage, 1000, 1000, imageName, filePath);

            //DahuaAPI.GetFaceHistoryUId(StartTime, EndTime, channel.ToString(), 80, 100, savePath);
        }
        private void MJpegStreamReader_FaceStrangerUIDEvent(object sender, FaceStrangerUIDEventArgs e)
        {
            StaticPool.mdb.ExecuteCommand($"Insert into tblFaceStranger(Datetime,UserID) values('{e._DateTime}','{e._UID}') ");
        }
        private void StreamReader_FaceCandidateEvent(object sender, FaceCandidateEventArgs faceCandidateEventArgs)
        {
            UISync.Execute(() =>
            {
                ucEventWithCandidate ucResultWithCandidate = new ucEventWithCandidate();
                GetCandidateFaceInfor(faceCandidateEventArgs, ucResultWithCandidate);

                FaceRepeatCheck faceStorageTimeOut = new FaceRepeatCheck();
                faceStorageTimeOut._DateTime = DateTime.Now;
                faceStorageTimeOut.Name = ucResultWithCandidate.Name;

                foreach (FaceRepeatCheck faceCheck in faceRecognizedList)
                {
                    if (faceCheck.Name == faceStorageTimeOut.Name)
                    {
                        faceCheck._DateTime = faceStorageTimeOut._DateTime;
                        return;
                    }
                }
                faceRecognizedList.Add(faceStorageTimeOut);

                bool isNewEvent = true;
                StaticPool.Logger_Info("Have Face" + DateTime.Now + ":" + faceCandidateEventArgs.PersonName);
                if (isNewEvent)
                {
                    StaticPool.Logger_Info("New face Event" + DateTime.Now + ":" + faceCandidateEventArgs.PersonName);
                    HumanThread = new Thread(() => EventQueue.Enqueue(ucResultWithCandidate));
                    HumanThread.Start();

                    //SendCheckInToServer(faceCandidateEventArgs.CardID,faceCandidateEventArgs.PersonName);

                    tblFaceEvent.InsertCandidateFace(faceCandidateEventArgs);

                }
            });
        }

        #region Concunrrent Queue
        public void AddQueue(ConcurrentQueue<UserControl> cq, UserControl ucNewEventData)
        {
            cq.Enqueue(ucNewEventData);
        }

        private void TimerGetDataFromQueue_Tick(object sender, EventArgs e)
        {
            UserControl QueueUC;
            /*
            if (QueueUC.Name.Contains("Face"))
            {
                FaceStorageTimeOut faceStorageTimeOut = new FaceStorageTimeOut();
                faceStorageTimeOut.DateTime = DateTime.Now;
                faceStorageTimeOut.Name = QueueUC.Name;

                foreach (FaceStorageTimeOut faceCheck in faceRecognizedList)
                {
                    if (faceCheck.Name == faceStorageTimeOut.Name)
                    {
                        faceCheck.DateTime = faceStorageTimeOut.DateTime;
                        return;
                    }
                }

                faceRecognizedList.Add(faceStorageTimeOut);
            }*/
            if (EventQueue.TryDequeue(out QueueUC))
            {

                
                if (flowLayoutPanel1.Controls.Count <= 20)
                {
                    flowLayoutPanel1.Controls.Add(QueueUC);
                }
                else
                {
                    flowLayoutPanel1.Controls.RemoveAt(0);
                    flowLayoutPanel1.Controls.Add(QueueUC);
                }
                this.ActiveControl = QueueUC;
                flowLayoutPanel1.SetFlowBreak(QueueUC, true);

                if (flowLayoutPanel1.VerticalScroll.Visible)
                {
                    flowLayoutPanel1.ScrollControlIntoView(QueueUC);
                }
                ucEventWithCandidate temp = (ucEventWithCandidate)QueueUC;
                StaticPool.personCount++;
                if (temp.Mask.Contains("Not wearing") ||temp.Mask.Contains("Không đeo"))
                {
                    StaticPool.personWithNoMask++;
                }
                if (!temp.Mask.Contains("Not") && !temp.Mask.Contains("Không"))
                {
                    StaticPool.personWithMask++;
                }

                txtPersonWithNoMask.Text = StaticPool.personWithNoMask.ToString();
                txtPersonWithMask.Text = StaticPool.personWithMask.ToString();
                txtPersonCount.Text = StaticPool.personCount.ToString();
                //
                SendCheckInToServer(temp.CardID, temp.PersonName);
            }
        }

        List<FaceRepeatCheck> repeatFaceList = new List<FaceRepeatCheck>();
        private void GCTimer_Tick(object sender, EventArgs e)
        {
            GetRepeatFaceList();
            ClearRepeatFaceList();
        }

        private void ClearRepeatFaceList()
        {
            if (repeatFaceList.Count > 0)
            {
                foreach (FaceRepeatCheck faceRepeatCheck in repeatFaceList)
                {
                    faceRecognizedList.Remove(faceRepeatCheck);
                }
            }
        }

        private void GetRepeatFaceList()
        {
            repeatFaceList.Clear();
            foreach (FaceRepeatCheck faceRepeatCheck in faceRecognizedList)
            {
                if (DateTime.Now - faceRepeatCheck._DateTime > TimeSpan.FromSeconds(20))
                {
                    repeatFaceList.Add(faceRepeatCheck);
                }
            }
        }
        #endregion
        #endregion

        #region: Face Method

        #region:Get Face Candidate Data
        private void GetCandidateFaceInfor(FaceCandidateEventArgs e, ucEventWithCandidate ucResultWithCandidate)
        {
            ucResultWithCandidate.Beard = e.Beard;
            ucResultWithCandidate.Mask = e.Mask;
            ucResultWithCandidate.PersonName = e.PersonName;
            /*
                speechSynthesizerObj.Dispose();
                speechSynthesizerObj = new SpeechSynthesizer(); 
                speechSynthesizerObj.SpeakAsync("Xin chao" + ucResultWithCandidate.PersonName);*/
            ucResultWithCandidate.GroupName = e.GroupName;
            ucResultWithCandidate.Sex = e.Sex;
            ucResultWithCandidate.Birthday = e.Birthday;
            ucResultWithCandidate.CardType = e.CardType;
            ucResultWithCandidate.CardID = e.CardNumber;
            string PersonID = e.PersonID;
            ucResultWithCandidate.PersonID = "Face" + PersonID;
            if (e.Position != null)
            {
                ucResultWithCandidate.Position = e.Position;
            }
            ucResultWithCandidate.FaceImage = e.FaceImage;
            ucResultWithCandidate.CandidateImage = e.CandidateImage;
        }
        #endregion

        #region: Check in
        private void SendCheckInToServer(string cardID, string perName)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            var client = new RestClient(CHECK_IN_SERVER_URL);
            client.Timeout = 500;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/soap+xml");
            request.AddParameter("application/x-www-form-urlencoded", GetCheckInAPI(cardID), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (!response.IsSuccessful)
            {
                client = new RestClient(CHECK_IN_SERVER_URL);
                client.Timeout = 500;
                request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/soap+xml");
                request.AddParameter("application/x-www-form-urlencoded", GetCheckInAPI(cardID), ParameterType.RequestBody);
                response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    txtCheckInStatus.Text = "Chấm công không thành công, hãy thử lại";
                    //MessageBox.Show("Please check in again" + response.Content);
                }
                else
                {
                    txtCheckInStatus.Text = perName + " Chấm công thành công";
                    /*frmCheckInDialog frm = new frmCheckInDialog();
                    frm.SetPersonName(faceCandidateEventArgs.PersonName);
                    frm.ShowDialog();*/
                }
            }
            else
            {
                txtCheckInStatus.Text = perName + " Chấm công thành công";
                /* frmCheckInDialog frm = new frmCheckInDialog();
                 frm.SetPersonName(faceCandidateEventArgs.PersonName);
                 frm.ShowDialog();*/
            }
        }
        #endregion
        private static string GetCheckInAPI(string cardID)
        {
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?> <soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\"> <soap12:Body> <CheckInByCardNumber xmlns=\"http://tempuri.org/\"> <CardNumber>" + cardID + "</CardNumber> </CheckInByCardNumber> </soap12:Body> </soap12:Envelope>";
        }
        #endregion

        #region: Vehicle Method        

        #region: Vehicle Motor
        private static ucVehicleCar GetVehicleMotorData(VehicleMotorEventArgs e)
        {
            ucVehicleCar ucVehicle = new ucVehicleCar();
            ucVehicle.VehicleColor = e.VehicleColor;
            ucVehicle.VehicleType = e.VehicleType;
            ucVehicle.PlateColor = e.PlateColor;
            ucVehicle.PlateNo = e.PlateNo;
            ucVehicle.SeatBelt = e.SeatBelt;
            ucVehicle.Smoking = e.Smoking;
            ucVehicle.GLobalImage = e.GlobalImage;
            ucVehicle.VehicleImage = e.VehicleImage;
            return ucVehicle;
        }
        #endregion

        #region: Vehicle NomMotor
        private static ucVehicleNonMotor GetVehicleNonMotorData(VehicleNonMotorEventArgs e)
        {
            ucVehicleNonMotor vehicleNonMotor = new ucVehicleNonMotor();
            vehicleNonMotor.Color = e.VehicleColor;
            vehicleNonMotor.GlobalImage = e.GlobalImage;
            vehicleNonMotor.VehicleImage = e.VehicleImage;
            return vehicleNonMotor;
        }

        #endregion

        #endregion

        #region: Camera Dahua Method
        private void Dahua_InitSDK()
        {
            this.disconnectCallback += Form1_disconnectCallback;
            this.reconnectCallback += Form1_reconnectCallback;
            if (!DHSDK_Init.CLIENT_Init(disconnectCallback, pUser))
            {
                lastError = DHSDK_Init.CLIENT_GetLastError() & 0x7FFFFFFF;
                MessageBox.Show(MultiLanguage.GetString("SDKInitError") + lastError);
                return;
            }
            else
            {
                DHSDK_Init.CLIENT_SetAutoReconnect(reconnectCallback, pUser);
                DHSDK_Init.CLIENT_SetConnectTime(NWAIT_TIME, NTRY_TIME);
            }
        }
        private void Form1_reconnectCallback(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            StaticPool.Logger_Error("Reconnect");
        }
        private void Form1_disconnectCallback(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            StaticPool.Logger_Error("Disconnect");
        }
        #endregion

        #region: SQL Method
        private void ConnectToSQLServer()
        {
            string cbSQLServerName = StaticPool.SQLServerName;
            string cbSQLDatabaseName = StaticPool.SQLDatabaseName;
            string cbSQLAuthentication = StaticPool.SQLAuthentication;
            string txtSQLUserName = StaticPool.SQLUserName;
            string txtSQLPassword = StaticPool.SQLPassword;
            StaticPool.mdb = new MDB(cbSQLServerName, cbSQLDatabaseName, cbSQLAuthentication, txtSQLUserName, txtSQLPassword);
        }
        #endregion

        #region: Method
        private void GetServerStatus(int statusIndex, int serverStatus)
        {
            picStatus.Image = imageList1.Images[statusIndex];
            StaticPool.server.ServerLastStatus = StaticPool.server.ServerCurrentStatus;
            StaticPool.server.ServerCurrentStatus = serverStatus;
        }
        private bool isPingSuccess()
        {
            try
            {
                Ping pingSender = new Ping();
                PingReply reply = null;
                reply = pingSender.Send(StaticPool.ServerName, 1000);
                if (reply != null && reply.Status == IPStatus.Success)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                StaticPool.Logger_Error(ex.Message);
                return false;
            }

        }
        private class UISync
        {
            private static ISynchronizeInvoke Sync;

            public static void Init(ISynchronizeInvoke sync)
            {
                Sync = sync;
            }
            public static void Execute(Action action)
            {
                Sync.BeginInvoke(action, null);
            }
        }

        public void AddTreeviewNode(TreeNode rootNode, string addNodeText, string addNodeName, int addNodeImageIndex)
        {
            TreeNode treeNode = new TreeNode();
            treeNode.Text = addNodeText;
            treeNode.Name = addNodeName;
            treeNode.ImageIndex = addNodeImageIndex;
            rootNode.Nodes.Add(treeNode);
        }
        private void UpdateServerStatus(int ServerStatus)
        {

            StaticPool.server.ServerLastStatus = ServerStatus;
            StaticPool.server.ServerCurrentStatus = ServerStatus;
            if (ServerStatus == SERVER_STATUS_DISCONNECT)
            {
                picStatus.Image = imageList1.Images[IMAGE_INDEX_DISCONNECT];
            }
            else
            {
                picStatus.Image = imageList1.Images[IMAGE_INDEX_CONNECT];
            }
        }
        private void ConnectServer()
        {
            try
            {
                DahuaAPI.GetGroupFace(StaticPool.groupFaces);
                DahuaAPI.GetPersonFace(StaticPool.groupFaces, StaticPool.personFaces);
                DahuaHelper.LoginCameraDahua(StaticPool.ServerName, 37777, StaticPool.ServerUsername, StaticPool.ServerPassword, ref userID, ref errorMessage);
                foreach (Camera camera in StaticPool.cams)
                {
                    if (camera.Type == DEVICE_TYPE_CAMERA)
                    {
                        AssignEvent(camera);
                    }
                }
            }
            catch (Exception ex)
            {
                StaticPool.Logger_Error(ex.Message);
            }
        }

        private void AssignEvent(Camera camera)
        {
            switch (StaticPool.CurrentDisplayMode)
            {
                case MODE_FACE:
                    EventReader.StartAsync(DahuaAPI.GetFaceEventCommand(StaticPool.ServerName, camera));
                    break;
                case MODE_VEHICLE:
                    EventReader.StartAsync(DahuaAPI.GetVehicleEventCommand(StaticPool.ServerName, camera));
                    break;
                case MODE_FACEandVEHICLE:
                    EventReader.StartAsync(DahuaAPI.GetFaceEventCommand(StaticPool.ServerName, camera));
                    EventReader.StartAsync(DahuaAPI.GetVehicleEventCommand(StaticPool.ServerName, camera));
                    break;
            }
        }
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                StaticPool.Logger_Error(ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
            }
        }

        private void aaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:44351/slots");
            client.Timeout = 500;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
        }

        public void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                StaticPool.Logger_Error(e.Exception.Message + "\n" + e.Exception.StackTrace);
            }
            finally
            {
            }
        }
        private static void SetDefaultLanguage(string language)
        {
            Properties.Settings.Default.Language = language;
            Properties.Settings.Default.Save();
            MessageBox.Show(MultiLanguage.GetString("changeLanguage_message", Properties.Settings.Default.Language));
        }
        #endregion
    }
}
