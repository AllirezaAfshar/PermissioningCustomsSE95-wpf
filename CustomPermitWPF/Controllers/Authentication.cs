using CustomPermitWPF.Domain;
using System.Diagnostics.Eventing.Reader;

namespace CustomPermitWPF.Controllers
{
    public static class Authentication
    {
        public static bool Login(string username, string password)
        {
            using (CustomPermission dbConnector = new CustomPermission())
            {
                User user = dbConnector.Users.Find(username);

                if (user == null)
                    return false;
                return user.Password == password;
            }
        }

        public static bool Register(string username, string password)
        {
            using (CustomPermission dbConnector = new CustomPermission())
            {
                if (dbConnector.Users.Find(username) != null)
                    return false;
                else
                {
                    dbConnector.Users.Add(new Domain.User(username, password));
                    return true;
                }
            }
        }
    }
}