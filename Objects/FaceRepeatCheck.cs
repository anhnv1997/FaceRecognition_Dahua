using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Objects
{
    public class FaceRepeatCheck
    {
        private string name;
        private DateTime dateTime;

        public string Name { get => name; set => name = value; }
        public DateTime _DateTime { get => dateTime; set => dateTime = value; }
    }
}
