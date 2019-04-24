using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;

namespace WinFormsCampusApp.Services
{
    public class AuthService
    {

        public bool Authenticate(string user, string password )
        {
            bool result = false;
            string url = "http://localhost/api/login";

            try
            {
                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection();
                    data["username"] = user;
                    data["password"] = password;

                    var response = wb.UploadValues(url, "POST", data);
                    string responseInString = Encoding.UTF8.GetString(response);
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }           

            return result;
        }
    }
}
