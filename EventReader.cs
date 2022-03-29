using FaceRecognition.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FaceRecognition
{
    class EventReader
    {
        public static event FaceCandidateHandler FaceCandidateEvent;
        public static event FaceStrangerHandler FaceStrangerEvent;
        public static event VehicleMotorHandler VehicleMotorEvent;
        public static event VehicleNonMotorHandler VehicleNonMotorEvent;


        const byte PIC_MARKER_BYTE = 0xFF;
        const byte PIC_START_BYTE = 0xD8;
        const byte PIC_END_BYTE = 0xD9;

        const byte EventIndex0 = 0x45;//E
        const byte EventIndex1 = 0x76;//v
        const byte EventIndex2 = 0x65;//e
        const byte EventIndex3 = 0x6E;//n
        const byte EventIndex4 = 0x74;//t
        
        static string TextResponse = "";
        static Image pic1 = null;
        static Image pic2 = null;
        static Image pic3 = null;
        /// <summary>
        /// Start a MJPEG on a http stream
        /// </summary>
        /// <param name="action">Delegate to run at each frame</param>
        /// <param name="url">url of the http stream (only basic auth is implemented)</param>
        /// <param name="login">optional login</param>
        /// <param name="password">optional password (only basic auth is implemented)</param>
        /// <param name="token">cancellation token used to cancel the stream parsing</param>
        /// <param name="chunkMaxSize">Max chunk byte size when reading stream</param>
        /// <param name="frameBufferSize">Maximum frame byte size</param>
        /// <returns></returns>
        /// 
        public async static Task StartAsync(string url, string login = null, string password = null, CancellationToken? token = null, int chunkMaxSize = 2048, int frameBufferSize = 1024 * 1024, int textBufferSize = 1024 * 1024)
        {

            var tok = token ?? CancellationToken.None;
            tok.ThrowIfCancellationRequested();

            var credCache = new CredentialCache();
            credCache.Add(new Uri(url), "Digest", new NetworkCredential("admin", "admin123"));

            using (var cli = new HttpClient(new HttpClientHandler() { Credentials = credCache }))
            {
                cli.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                using (var stream = await cli.GetStreamAsync(url).ConfigureAwait(false))
                {
                    var streamBuffer = new byte[chunkMaxSize];
                    var dataBuffer = new byte[1024 * 1024];

                    var dataIndex = 0;

                    var inData = false;
                    var inText = false;
                    var inPic1 = false;
                    var inPic2 = false;
                    var isHavePic3 = false;
                    var inPic3 = false;

                    while (true)
                    {
                        var streamLength = await stream.ReadAsync(streamBuffer, 0, chunkMaxSize, tok).ConfigureAwait(false);
                        parseStreamBuffer(url,ref streamBuffer, streamLength, ref dataIndex, dataBuffer, ref inData, ref inText, ref inPic1, ref inPic2, ref isHavePic3, ref inPic3);
                    };
                }
            }
        }

        // Parse the stream buffer
        static void parseStreamBuffer(string url,ref byte[] streamBuffer, int streamLength, ref int dataIndex, byte[] dataBuffer, ref bool inData, ref bool inText, ref bool inPic1, ref bool inPic2, ref bool isHavePic3, ref bool inPic3)
        {
            var streamBufferIndex = 0;
            while (streamBufferIndex < streamLength)
            {
                if (inData)
                {
                    ParseData(url,ref streamBuffer, ref streamLength, ref streamBufferIndex, dataBuffer, ref dataIndex, ref inText, ref inPic1, ref inPic2, ref isHavePic3, ref inPic3, ref inData);
                }
                else
                {
                    SearchData(ref streamBuffer, ref streamLength, ref streamBufferIndex, ref dataIndex, dataBuffer, ref inData, ref inText);
                }
            }
        }
        //input: StreamBuffer, streamlength
        //index: index chuoi doc ve; index cua chuoi kq
        //outbut: databuffer
        //data: Start with Event
        static void SearchData(ref byte[] streamBuffer, ref int streamLength, ref int streamBufferIndex, ref int dataIndex, byte[] dataBuffer, ref bool inData, ref bool inText)
        {
            do
            {
                dataBuffer[0] = dataBuffer[1];
                dataBuffer[1] = dataBuffer[2];
                dataBuffer[2] = dataBuffer[3];
                dataBuffer[3] = dataBuffer[4];
                dataBuffer[4] = streamBuffer[streamBufferIndex];
                
                streamBufferIndex++;
                // Bat dau data? -  Nhan duoc chuoi Event?
                bool index0Success = dataBuffer[0] == EventIndex0;
                bool index1Success = dataBuffer[1] == EventIndex1;
                bool index2Success = dataBuffer[2] == EventIndex2;
                bool index3Success = dataBuffer[3] == EventIndex3;
                bool index4Success = dataBuffer[4] == EventIndex4;
                if (index0Success && index1Success && index2Success && index3Success && index4Success)
                {
                    dataIndex = 5;
                    inData = true;
                    inText = true;
                    return;
                }
            }
            while (streamBufferIndex < streamLength);
        }
        static void ParseData(string url, ref byte[] streamBuffer, ref int streamLength, ref int streamBufferIndex, byte[] dataBuffer, ref int dataIndex, ref bool inText, ref bool inPic1, ref bool inPic2, ref bool isHavePic3, ref bool inPic3, ref bool inData)
        {
            do
            {
                GetTextData(streamBuffer, ref streamBufferIndex, dataBuffer, ref dataIndex, ref inText, ref inPic1);
                GetPic1Data(streamBuffer, ref streamBufferIndex, dataBuffer, ref dataIndex, ref inPic1, ref inPic2);

                #region: Pic2
                if (inPic2)
                {
                    dataBuffer[dataIndex] = streamBuffer[streamBufferIndex];
                    dataIndex++;
                    streamBufferIndex++;
                    if (dataIndex > 4)
                    {
                        bool isHavePic3Byte1 = dataBuffer[dataIndex - 2] == 45;
                        bool isHavePic3Byte2 = dataBuffer[dataIndex - 1] == 45;
                        bool pic2MarkerSuccess = dataBuffer[dataIndex - 4] == PIC_MARKER_BYTE;
                        bool pic2endSuccess = dataBuffer[dataIndex - 3] == PIC_END_BYTE;
                        //Th co 2 anh
                        if (pic2MarkerSuccess && pic2endSuccess)
                        {
                            inPic2 = false;
                            using (var s = new MemoryStream(dataBuffer, 0, dataIndex - 2))
                            {
                                try
                                {
                                    pic2 = Image.FromStream(s);

                                    Bitmap _bitmap = new Bitmap(pic2);
                                    byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(_bitmap, typeof(byte[]));
                                    System.IO.Directory.CreateDirectory(@".\Eventdata\" + DateTime.Now.ToString("yyyy_MM_dd"));
                                    string savePath = @"D:\New folder\test2.png";
                                    File.WriteAllBytes(savePath, bytes);
                                }
                                catch (Exception ex)
                                {
                                    StaticPool.Logger_Error("Convert Image2 Error " + ex.ToString());
                                }
                            }
                            if (isHavePic3Byte1 && isHavePic3Byte2)
                            {
                                isHavePic3 = true;
                                Array.Clear(dataBuffer, 0, dataBuffer.Length);
                                dataIndex = 0;
                            }
                            else
                            {
                                isHavePic3 = false;
                                inPic3 = false;
                                inData = false;

                                //if (TextResponse.Contains("HumanFace"))
                                //{
                                //    //StaticPool.personCount++;
                                //    FaceStrangerEventArgs faceStrangerEventArgs = new FaceStrangerEventArgs();
                                //    faceStrangerEventArgs.FaceStrangerImage = pic1;
                                //    string channel = url.Substring(url.IndexOf("channel"));
                                //    faceStrangerEventArgs.CameraChannel = channel.Substring(channel.IndexOf("=") + 1, channel.IndexOf("&") - channel.IndexOf("=") - 1);
                                //    FaceStrangerEvent?.Invoke(null, faceStrangerEventArgs);
                                //}
            //                    else if (IsVehicleCar(TextResponse))
            //                    {
            //                        StaticPool.VehicleWithMotor++;
            //                        VehicleMotorEventArgs vehicleMotorEventArgs = new VehicleMotorEventArgs();
            //                        string[] result = TextResponse.Split("\r\n");
            //                        /*
            //                         * ucVehicleCar ucVehicle = new ucVehicleCar();
            //string VehicleColor = data.Substring(data.IndexOf("Events[0].TrafficCar.VehicleColor"), data.IndexOf("Events[0].SceneImage.Offset") - data.IndexOf("Events[0].TrafficCar.VehicleColor"));
            //ucVehicle.VehicleColor = VehicleColor.Substring(VehicleColor.IndexOf("=") + 1);

            ////string VehicleType = data.Substring(data.IndexOf("Events[0].TrafficCar.VehicleColor"), data.IndexOf("Events[0].SceneImage.Offset") - data.IndexOf("Events[0].TrafficCar.VehicleColor"));
            //ucVehicle.VehicleType = "";

            //string PlateColor = data.Substring(data.IndexOf("Events[0].Vehicle.PlateColor"), data.IndexOf("Events[0].Vehicle.OriginalBoundingBox[0]") - data.IndexOf("Events[0].Vehicle.PlateColor"));
            //ucVehicle.PlateColor = PlateColor.Substring(PlateColor.IndexOf("=") + 1);

            ////string PlateNo = data.Substring(data.IndexOf("Events[0].TrafficCar.VehicleColor"), data.IndexOf("Events[0].SceneImage.Offset") - data.IndexOf("Events[0].TrafficCar.VehicleColor"));
            //ucVehicle.PlateNo = "";

            //string SeatBelt = data.Substring(data.IndexOf("Events[0].CommInfo.Seat[0].SafeBelt"), data.IndexOf("Events[0].CommInfo.Seat[0].Status[0]") - data.IndexOf("Events[0].CommInfo.Seat[0].SafeBelt"));
            //ucVehicle.SeatBelt = SeatBelt.Substring(SeatBelt.IndexOf("=") + 1);

            //string Calling = data.Substring(data.IndexOf("Events[0].CommInfo.Seat[0].Status[1]"), data.IndexOf("Events[0].CommInfo.Seat[0].SunShade") - data.IndexOf("Events[0].CommInfo.Seat[0].Status[1]"));
            //ucVehicle.Calling = Calling.Substring(Calling.IndexOf("=") + 1);

            //string Smoking = data.Substring(data.IndexOf("Events[0].CommInfo.Seat[0].Status[0]"), data.IndexOf("Events[0].CommInfo.Seat[0].Status[1]") - data.IndexOf("Events[0].CommInfo.Seat[0].Status[0]"));
            //ucVehicle.Smoking = Smoking.Substring(Smoking.IndexOf("=") + 1);
            //ucVehicle.GLobalImage = image;
            //ucVehicle.VehicleImage = image1;
            //return ucVehicle;
            //                         * */
            //                        VehicleMotorEvent?.Invoke(null, vehicleMotorEventArgs);
            //                    }
            //                    else
            //                    {
            //                        StaticPool.VehicleNonMotor++;
            //                        VehicleNonMotorEventArgs vehicleNonMotorEventArgs = new VehicleNonMotorEventArgs();
            //                        string[] result = TextResponse.Split("\r\n");
            //                        vehicleNonMotorEventArgs.VehicleImage = pic2;
            //                        vehicleNonMotorEventArgs.GlobalImage = pic1;
            //                        vehicleNonMotorEventArgs.VehicleColor = result[57].Substring(result[57].IndexOf("=") + 1);
            //                        VehicleNonMotorEvent?.Invoke(null, vehicleNonMotorEventArgs);
            //                    }
                                return;
                            }
                        }
                    }

                }
                if (isHavePic3 && inPic3 == false)
                {
                    dataBuffer[dataIndex] = streamBuffer[streamBufferIndex];
                    dataIndex++;
                    streamBufferIndex++;
                    //kiem tra bat dau pic3?
                    if (dataIndex > 2)
                    {
                        bool picMarkerSuccess = dataBuffer[dataIndex - 2] == PIC_MARKER_BYTE;
                        bool picStartSuccess = dataBuffer[dataIndex - 1] == PIC_START_BYTE;
                        if (picMarkerSuccess && picStartSuccess)
                        {
                            inPic3 = true;
                            Array.Clear(dataBuffer, 0, dataBuffer.Length);
                            dataBuffer[0] = PIC_MARKER_BYTE;
                            dataBuffer[1] = PIC_START_BYTE;
                            dataIndex = 2;
                        }
                    }

                }
                #endregion

                #region:pic3
                // Neu co pic 3, nhan het du lieu cua pic3 ket thuc data
                if (inPic3)
                {
                    dataBuffer[dataIndex] = streamBuffer[streamBufferIndex];
                    dataIndex++;
                    streamBufferIndex++;
                    //kiem tra ket thuc pic3?
                    bool picMarkerSuccess = dataBuffer[dataIndex - 2] == PIC_MARKER_BYTE;
                    bool picEndSuccess = dataBuffer[dataIndex - 1] == PIC_END_BYTE;
                    if (picMarkerSuccess && picEndSuccess)
                    {
                        using (var s = new MemoryStream(dataBuffer, 0, dataIndex))
                        {
                            try
                            {
                                pic3 = Image.FromStream(s);
                            }
                            catch (Exception ex)
                            {
                                StaticPool.Logger_Error("Convert Image3 Error: " + ex.ToString());
                            }
                        }
                        isHavePic3 = false;
                        inPic3 = false;
                        inData = false;
                        if (TextResponse.Contains("Candidates"))
                        {
                            try
                            {
                                FaceCandidateEventArgs faceCandidateEventArgs = new FaceCandidateEventArgs();
                                faceCandidateEventArgs.GetPersonInfor(TextResponse);
                                faceCandidateEventArgs.GlobalImage = pic1;
                                faceCandidateEventArgs.FaceImage = pic2;
                                faceCandidateEventArgs.CandidateImage = pic3;
                                FaceCandidateEvent?.Invoke(null, faceCandidateEventArgs);
                            }
                            catch (Exception ex)
                            {
                                StaticPool.Logger_Error("Get Face Candidate infor Error: " + ex.ToString());
                            }
                        }

                        return;
                    }

                }
                #endregion
            }
            while (streamBufferIndex < streamLength);
        }

        private static void GetPic1Data(byte[] streamBuffer, ref int streamBufferIndex, byte[] dataBuffer, ref int dataIndex, ref bool inPic1, ref bool inPic2)
        {
            if (inPic1)
            {
                dataBuffer[dataIndex] = streamBuffer[streamBufferIndex];
                dataIndex++;
                streamBufferIndex++;
                //kiem tra bat dau pic2?
                bool isMarkerPic2Byte = dataBuffer[dataIndex - 2] == PIC_MARKER_BYTE;
                bool isStartPic2Byte = dataBuffer[dataIndex - 1] == PIC_START_BYTE;
                if (isMarkerPic2Byte && isStartPic2Byte)
                {
                    using (var s = new MemoryStream(dataBuffer, 0, dataIndex - 2))
                    {
                        try
                        {
                            pic1 = Image.FromStream(s);
                            Bitmap _bitmap = new Bitmap(pic1);
                            byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(_bitmap, typeof(byte[]));
                            System.IO.Directory.CreateDirectory(@".\Eventdata\" + DateTime.Now.ToString("yyyy_MM_dd"));
                            string savePath = @"D:\New folder\test.png";
                            File.WriteAllBytes(savePath, bytes);
                        }
                        catch (Exception ex)
                        {
                            StaticPool.Logger_Error("Convert Image1 Error: " + ex.ToString());
                        }
                    }
                    inPic1 = false;
                    inPic2 = true;
                    Array.Clear(dataBuffer, 0, dataBuffer.Length);
                    dataBuffer[0] = PIC_MARKER_BYTE;
                    dataBuffer[1] = PIC_START_BYTE;
                    dataIndex = 2;
                }
            }
        }
        private static void GetTextData(byte[] streamBuffer, ref int streamBufferIndex, byte[] dataBuffer, ref int dataIndex, ref bool inText, ref bool inPic1)
        {
            if (inText)
            {
                dataBuffer[dataIndex] = streamBuffer[streamBufferIndex];
                dataIndex++;
                streamBufferIndex++;
                //kiem tra ket thuc text?
                bool isMarkerPic1Byte = dataBuffer[dataIndex - 2] == PIC_MARKER_BYTE;
                bool isStartPic1Byte = dataBuffer[dataIndex - 1] == PIC_START_BYTE;
                if (isMarkerPic1Byte && isStartPic1Byte)
                {
                    TextResponse = Encoding.UTF8.GetString(dataBuffer);
                    Array.Clear(dataBuffer, 0, dataBuffer.Length);
                    inText = false;
                    inPic1 = true;
                    dataBuffer[0] = PIC_MARKER_BYTE;
                    dataBuffer[1] = PIC_START_BYTE;
                    dataIndex = 2;
                }
            }
        }
        

        #region: Vehicle Event
        private static bool IsVehicleCar(string data)
        {
            return data.Contains("Vehicle");
        }
        #endregion
        
    }
}