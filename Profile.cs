using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDataDLL
{
    [Serializable]
    internal class Profile
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public LogIn LoginDetails { get; private set; }

        public Profile(string fullName, string email, string username, string password)
        {
            FullName = fullName;
            Email = email;
            LoginDetails = new LogIn(username, password);
        }

        public bool Authorize(string username, string password)
        {
            return LoginDetails.ValidateCredentials(username, password);
        }

        public void DisplayInfo()
        {

        }
    }
}
