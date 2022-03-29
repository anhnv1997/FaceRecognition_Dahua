using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Objects
{
    public class PersonFace
    {
        private string _PersonID;
        private string _PersonName;
        private string _PersonSex;
        private string _PersonBirthDay;
        private string _PersonCardType;
        private string _PersonCardID;
        private string _GroupID;
        private string _GroupName;
        private string _ImagePath;
        private string _Country;
        private string _Position;
        public string Country { get; set; }
        public string PersonID { get; set; }
        public string PersonName { get; set; }
        public string PersonSex { get; set; }
        public string PersonBirthday { get; set; }
        public string PersonCardType { get; set; }
        public string PersonCardID { get; set; }
        public string GroupID { get; set; }
        public string GroupName { get; set; }
        public string ImagePath { get; set; }
        public string Position { get; set; }
    }
}
