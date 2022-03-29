using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Objects
{
    public class User
    {
        public string ID { get; set; }
        public string Fullname { get; set; }
        public string Code { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Right { get; set; }
    }
}
