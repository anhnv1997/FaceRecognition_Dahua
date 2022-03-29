using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Objects
{
    public class GroupFace
    {
        string _ID = "";
        string _GroupName = "";
        string _GroupDetail = "";
        int _GroupSize;
        public string ID { get; set; }
        public string GroupName { get; set; }
        public string GroupDetail { get; set; }
        public int GroupSize { get; set; }
    }
}
