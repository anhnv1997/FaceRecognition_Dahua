using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Objects
{
    public class CameraCollection : CollectionBase
    {
        // Constructor
        public CameraCollection()
        {

        }

        public Camera this[int index]
        {
            get { return (Camera)InnerList[index]; }
        }

        // Add
        public void Add(Camera camera)
        {
            InnerList.Add(camera);
        }

        // Remove
        public void Remove(Camera camera)
        {
            InnerList.Remove(camera);
        }

        // Get zg by it's zgID
        public Camera GetCameraById(string camId)
        {
            foreach (Camera cam in InnerList)
            {
                if (cam.Id == camId)
                {
                    return cam;
                }
            }
            return null;
        }
    }
}