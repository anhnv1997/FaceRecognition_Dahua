using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Objects
{
    public class Camera
    {      
        private string _Id;
        private string _Name;
        private string _Code;
        private int _Type;
        private int _Com;
        private string _Ip;
        private string _Port;
        private string _Username;
        private string _Password;
        private int _Channel;
        private bool isLogin = false;
        private bool isLiveview = false;
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Type { get; set; }
        public int Com { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Channel { get; set; }
        public bool IsLogin { get; set; }
        public bool IsLiveview { get; set; }
        public long UserID { get; set; }

        public long m_lRealHandle { get; set; }
    }
}
