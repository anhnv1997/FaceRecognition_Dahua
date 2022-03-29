using FaceRecognition.Database;
using FaceRecognition.Objects;
using LazZiya.ImageResize;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognition
{
    public static class StaticPool
    {
        //Display Mode
        public static int FaceMode = 0;
        public static int VehicleMode = 1;
        public static int FaceAndVihicleMode = 2;
        public static int CurrentDisplayMode = Properties.Settings.Default.CurrentDisplayMode;
        //Language
        public static string Language = "";
        public static int personCount = 0;
        public static int personWithMask = 0;
        public static int personWithNoMask = 0;

        public static int VehicleNonMotor = 0;
        public static int VehicleWithMotor = 0;
        // CSDL
        public static MDB mdb = null; // new MDB(Application.StartupPath + "\\iParkingPGS.mdb", "17032008");

        // Thong tin CSDL
        public static string SQLServerName = Properties.Settings.Default.SQLServerName;
        public static string SQLDatabaseName = Properties.Settings.Default.SQLDatabaseName;
        public static string SQLAuthentication = Properties.Settings.Default.SQLAuthentication;
        public static string SQLUserName = Properties.Settings.Default.SQLUserName;
        public static string SQLPassword = Properties.Settings.Default.SQLPassword;

        // Thong tin dang nhap
        public static string FullName = "Anonymous";
        public static string UserCode = "";
        public static string UserName = Properties.Settings.Default.UserName;
        public static string Password = Properties.Settings.Default.Password;
        public static int Right1 = -1;
        public static bool IsRememberPassword = Properties.Settings.Default.IsRememberPassword;
        // Thong tin dau ghi
        public static string ServerName = Properties.Settings.Default.ServerName;
        public static string ServerUsername = Properties.Settings.Default.ServerUsername;
        public static string ServerPassword = Properties.Settings.Default.ServerPassword;
        public static string ImagePath = "";

        public static int DelayTime = 300;

        public static CameraCollection cams = new CameraCollection();
        public static UserCollection users = new UserCollection();
        public static PersonFaceCollection personFaces = new PersonFaceCollection();
        public static GroupFaceCollection groupFaces = new GroupFaceCollection();
        public static Server server = new Server();


        public static void Logger_Error(string s)
        {
            try
            {
                string pathFile = Path.GetDirectoryName(Application.ExecutablePath) + @"\logs\ERROR_LOG_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt";
                using (StreamWriter writer = new StreamWriter(pathFile, true))
                {
                    try
                    {
                        StackFrame callStack = new StackFrame(1, true);
                        writer.WriteLine("ERROR " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "-" + callStack.GetMethod().Name + " - " + s);
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
        }
        public static void Logger_Info(string s)
        {
            try
            {
                string pathFile = Path.GetDirectoryName(Application.ExecutablePath) + @"\logs\INFO_LOG_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt";
                using (StreamWriter writer = new StreamWriter(pathFile, true))
                {
                    try
                    {
                        writer.WriteLine("INFO " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " - " + s);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Logger_Error(ex.Message);
            }
        }
        public static string SaveImageWithScale(Image image, int width, int height, string fileName, string filePath)
        {
            var scaleImg = ImageResize.Scale(image, width, height);
            System.IO.Directory.CreateDirectory(filePath);
            string imageName = fileName;
            string savePath = filePath + @"\" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff") + imageName;
            scaleImg.SaveAs(savePath);
            return savePath;
        }
        public static void SaveImage(Image image, string imageName, out string savePath)
        {
            Bitmap _bitmap = new Bitmap(image);
            byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(_bitmap, typeof(byte[]));
            System.IO.Directory.CreateDirectory(@".\Eventdata\" + DateTime.Now.ToString("yyyy_MM_dd"));
            savePath = @".\Eventdata\" + DateTime.Now.ToString("yyyy_MM_dd") + @"\" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff") + imageName;
            File.WriteAllBytes(savePath, bytes);
        }
    }
}
