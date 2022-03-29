using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition.Objects
{
    public class UserCollection : CollectionBase
    {
        // Constructor
        public UserCollection()
        {

        }

        public User this[int index]
        {
            get { return (User)InnerList[index]; }
        }

        // Add
        public void Add(User user)
        {
            InnerList.Add(user);
        }

        // Remove
        public void Remove(User user)
        {
            InnerList.Remove(user);
        }

        // Get zg by it's zgID
        public User GetUserById(string userId)
        {
            foreach (User user in InnerList)
            {
                if (user.ID == userId)
                {
                    return user;
                }
            }
            return null;
        }
    }
}