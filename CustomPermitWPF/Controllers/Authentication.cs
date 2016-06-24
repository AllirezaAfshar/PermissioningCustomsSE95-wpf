using CustomPermitWPF.Domain;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace CustomPermitWPF.Controllers
{
    public static class Authentication
    {
        public static bool Login(string username, string password)
        {
            using (CustomPermission dbConnector = new CustomPermission())
            {
                User user = dbConnector.Users.Where(u=>u.Username == username).FirstOrDefault();

                if (user == null)
                    return false;
                else
                {
                    CustomPermission.active_user = user;
                    return user.Password == password;
                }
            }
        }

        public static bool Register(string username, string password, string role)
        {
            using (CustomPermission dbConnector = new CustomPermission())
            {
                if (dbConnector.Users.Where(u => u.Username == username).FirstOrDefault() != null)
                    return false;
                else
                {
                    dbConnector.Users.Add(new Domain.User(username, password, role));
                    dbConnector.SaveChanges();
                    return true;
                }
            }
        }
    }
}