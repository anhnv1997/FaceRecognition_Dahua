using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Objects
{
    public class GroupFaceCollection : CollectionBase
    {
        public GroupFaceCollection()
        {

        }

        public GroupFace this[int index]
        {
            get { return (GroupFace)InnerList[index]; }
        }

        // Add
        public void Add(GroupFace groupFace)
        {
            InnerList.Add(groupFace);
        }

        // Remove
        public void Remove(GroupFace groupFace)
        {
            InnerList.Remove(groupFace);
        }

        // Get zg by it's zgID
        public GroupFace GetGroupFaceById(string gFId)
        {
            foreach (GroupFace groupFace in InnerList)
            {
                if (groupFace.ID == gFId)
                {
                    return groupFace;
                }
            }
            return null;
        }
    }
}
