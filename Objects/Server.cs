using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Objects
{
    public class Server
    {
        public string Name { get; set; }
        // Status 1: Valid
        //Status 0: Invalid
        private int _serverCurrentStatus = 1;
        public int ServerCurrentStatus {
            get
            {
                return _serverCurrentStatus;
            }
            set
            {
                this._serverCurrentStatus = value;
            } 
        }
        public int ServerLastStatus { get; set; }
    }
}
