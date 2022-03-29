using FaceRecognition.Objects;
using LazZiya.ImageResize;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FaceRecognition
{
    public static class MJpegStreamReader
    {
        public static event FaceStrangerUIDEventHandler FaceStrangerUIDEvent;
        public static event FaceSHistoryEventHandler FaceHistoryEvent;
        // JPEG delimiters
        const byte picMarker = 0xFF;
        const byte picStart = 0xD8;
        const byte picEnd = 0xD9;
        public static string TextResponse;
        public static Image ImageResponse;

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
        public async static Task StartAsync(string url, string login = null, string password = null, CancellationToken? token = null, int chunkMaxSize = 1024, int frameBufferSize = 1024 * 1024, int textBufferSize = 1024 * 1024)
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
                    var streamBuffer = new byte[chunkMaxSize];      // Stream chunk read
                    var frameBuffer = new byte[frameBufferSize];    // Frame buffer
                    var textBuffer = new byte[textBufferSize];

                    var frameIdx = 0;       // Last written byte location in the frame buffer
                    var textIdx = 0;
                    var inText = true;
                    var inPicture = false;  // Are we currently parsing a picture ?
                    var endData = false;
                    byte current = 0x00;    // The last byte read
                    byte previous = 0x00;   // The byte before

                    // Continuously pump the stream. The cancellationtoken is used to get out of there
                    while (true)
                    {
                        var streamLength = await stream.ReadAsync(streamBuffer, 0, chunkMaxSize, tok).ConfigureAwait(false);
                        int idx = 0;
                        parseData(textBuffer, frameBuffer, ref frameIdx, ref textIdx, ref streamLength, streamBuffer, ref idx, ref inPicture, ref inText, ref endData, ref previous, ref current);
                        if (endData)
                        {
                            break;
                        }
                    };
                }
            }
        }
        static void parseData(byte[] textBuffer, byte[] frameBuffer, ref int frameIdx, ref int textIdx, ref int streamLenth, byte[] streamBuffer, ref int idx, ref bool inPicture, ref bool inText, ref bool endData, ref byte previous, ref byte current)
        {
            do
            {
                if (inText)
                {
                    previous = current;
                    current = streamBuffer[idx++];
                    textBuffer[textIdx++] = current;

                    // JPEG picture end ?
                    if (previous == picMarker && current == picStart)
                    {
                        TextResponse = Encoding.UTF8.GetString(textBuffer);

                        inPicture = true;
                        inText = false;
                        frameIdx = 2;
                        frameBuffer[0] = picMarker;
                        frameBuffer[1] = picStart;
                    }
                }
                if (inPicture)
                {
                    frameBuffer[frameIdx] = streamBuffer[idx];
                    idx++;
                    frameIdx++;
                    bool pic2MarkerSuccess = frameBuffer[frameIdx - 2] == picMarker;
                    bool pic2endSuccess = frameBuffer[frameIdx - 1] == picEnd;
                    //Th co 2 anh
                    if (pic2MarkerSuccess && pic2endSuccess)
                    {
                        using (var s = new MemoryStream(frameBuffer, 0, frameIdx - 2))
                        {
                            try
                            {
                                ImageResponse = Image.FromStream(s);
                            }
                            catch
                            {
                                // We dont care about badly decoded pictures
                            }
                        }
                        inPicture = false;
                        endData = true;
                        string _UID = TextResponse.Substring(TextResponse.IndexOf("\"UID\""), TextResponse.IndexOf("\"Sex\"") - TextResponse.IndexOf("\"UID\""));
                        string UID = _UID.Substring(_UID.IndexOf(":") + 3, _UID.IndexOf(",") - _UID.IndexOf(":") - 4);
                        DataTable dtbDateTime = StaticPool.mdb.FillData($"Select Datetime from tblFaceStranger where UserID ='{UID}'");
                        string dateTime = "";
                        if (dtbDateTime != null && dtbDateTime.Rows.Count > 0)
                        {
                            dateTime = dtbDateTime.Rows[0]["Datetime"].ToString();
                        }
                        string _Sex = TextResponse.Substring(TextResponse.IndexOf("\"Sex\""), TextResponse.IndexOf("\"Age\"") - TextResponse.IndexOf("\"Sex\""));
                        string Sex = _Sex.Substring(_Sex.IndexOf(":") + 3, _Sex.IndexOf(",") - _Sex.IndexOf(":") - 4);

                        string _Age = TextResponse.Substring(TextResponse.IndexOf("\"Age\""), TextResponse.IndexOf("\"Glasses\"") - TextResponse.IndexOf("\"Age\""));
                        string Age = _Age.Substring(_Age.IndexOf(":") + 2, _Age.IndexOf(",") - _Age.IndexOf(":") - 2);

                        Bitmap _bitmap = new Bitmap(ImageResponse);
                        Image image1 = _bitmap;
                        Image imageResize = ImageResize.Scale(ImageResponse, 150, 150);


                        FaceStrangerUIDEventArgs faceStrangerUIDEventArgs = new FaceStrangerUIDEventArgs();
                        DateTime datetimeRecognize = DateTime.Now;
                        faceStrangerUIDEventArgs._UID = UID;
                        faceStrangerUIDEventArgs._DateTime = datetimeRecognize;
                        FaceStrangerUIDEvent?.Invoke(null, faceStrangerUIDEventArgs);

                        FaceSHistoryEventArgs faceSHistoryEventArgs = new FaceSHistoryEventArgs();
                        faceSHistoryEventArgs._UID = UID;
                        faceSHistoryEventArgs._DateTime = dateTime;
                        faceSHistoryEventArgs.Sex = Sex;
                        faceSHistoryEventArgs.Age = Age;
                        FaceHistoryEvent?.Invoke(null, faceSHistoryEventArgs);
                        return;
                    }
                }
            }
            while (idx < streamLenth);
        }
    }

}

