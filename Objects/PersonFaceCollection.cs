using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognition.Objects
{

    public class PersonFaceCollection : CollectionBase
    {
        public PersonFaceCollection()
        {

        }

        public PersonFace this[int index]
        {
            get { return (PersonFace)InnerList[index]; }
        }

        // Add
        public void Add(PersonFace personFace)
        {
            InnerList.Add(personFace);
        }

        // Remove
        public void Remove(PersonFace personFace)
        {
            InnerList.Remove(personFace);
        }

        // Get ps by it's psID
        public PersonFace GetPersonFaceById(string personID)
        {
            foreach (PersonFace personFace in InnerList)
            {
                if (personFace.PersonID == personID)
                {
                    return personFace;
                }
            }
            return null;
        }

        public PersonFace GetPersonFaceById(string personID, string groupID)
        {
            foreach (PersonFace personFace in InnerList)
            {
                if (personFace.PersonID == personID && personFace.GroupID == groupID)
                {
                    return personFace;
                }
            }
            return null;
        }
    }
}
