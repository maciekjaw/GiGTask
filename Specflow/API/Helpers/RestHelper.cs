using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Specflow.Helpers
{
    public static class RestHelper
    {
        static string baseURL = "https://reqres.in/";
        static readonly string password = "pistol";
        public static string Password { get { return password; } }

        #region POST

        public static (int responseCode, string token, string errorMessage) Post<T1>([Optional] string password, string registerEndpoint = "api/register", string email = "eve.holt@reqres.in")
        {
            string tokenKey = "token";
            string errorKey = "error";

            var client = new RestClient(baseURL);
            var request = new RestRequest(registerEndpoint, Method.POST);
            request.RequestFormat = DataFormat.Json;

            if (password != null)
            {
                request.AddJsonBody(new { email, password });
                var response = client.Execute(request);
                int responseCode = (int)response.StatusCode;

                var content = response.Content;
                var token = JObject.Parse(content)[tokenKey].ToString();

                return (responseCode, token, "");

            }
            else
            {
                request.AddJsonBody(new { email });
                var response = client.Execute(request);
                int responseCode = (int)response.StatusCode;
                var errorMessage = response.Content;
                var message = JObject.Parse(errorMessage)[errorKey].ToString();

                return (responseCode, "", message);

            }
        }
        #endregion

        #region GET

        public static (int responseCode, List<string> names) Get<T>(string userEndpoint = "api/users")
        {
            List<string> usersList = new List<string>();
            string data = "data";
            string first_name = "first_name";

            var client = new RestClient(baseURL);
            var request = new RestRequest(userEndpoint, Method.GET);
            var response = client.Execute(request);
            int responseCode = (int)response.StatusCode;

            var content = response.Content;
            var users = JObject.Parse(content)[data];
            var names = users.Values(first_name);

            foreach (var name in names)
            {
                usersList.Add(name.ToString());
            }

            return (responseCode, usersList);
        }
        #endregion
    }
}