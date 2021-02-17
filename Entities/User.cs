using System.Collections.Generic;
namespace Entities
{
    public class User
    {

        public static readonly User USER1 = new User("username1", "password1");
        public static readonly User USER2 = new User("username2", "password2");
        //public static readonly User USER3 = new User("username3", "password3");
        public static IEnumerable<User> Values
        {
            get
            {
                yield return USER1;
                yield return USER2;
                //yield return USER3;
            }
        }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        private User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public string GetUserName() { return UserName; }
        public string GetPassword() { return Password; }
    }
}