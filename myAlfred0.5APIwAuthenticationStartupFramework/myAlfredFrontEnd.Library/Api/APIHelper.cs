using myAlfred0._5APIwAuthenticationStartupFramework.Models;
using myAlfredFrontEnd.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace myAlfredFrontEnd.Library.Api
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient apiClient; //One HttpClient for the lifespan of our application to prevent clogging of network
        private ILoggedInUserModel _loggedInUser;

        public APIHelper(ILoggedInUserModel loggedInUser)
        {
            InitalizeClient(); //Whenever a new APIHelper is crerated it will initialize the client
            _loggedInUser = loggedInUser;
        }

        private void InitalizeClient() // Creates new HttpClient for lifetime use in react instance
        {
            string api = ConfigurationManager.AppSettings["api"];

            apiClient = new HttpClient(); // Lives for lifespan of instance of react project
            apiClient.BaseAddress = new Uri("");
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//Getting Data data back
        }

        public async Task<AuthenticatedUser> Authenticate(string username, string password) //This method should allow us to call the token using the password and get back a response
        { // Creates form-urlencoded content and posts token which says if it is sucessful or not
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            using (HttpResponseMessage response = await apiClient.PostAsync("/api/Token", data))//(Url for Api Endpoint (localhost/azure), send formatted data)
            {
                if (response.IsSuccessStatusCode)
                { //Authentication Succeeded
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return result; //If Authentication Sucess then grab info from content and put it into AuthenticatedUser Momdel and return Model
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task GetLoggedInUserInfo(string token)
        {
            apiClient.DefaultRequestHeaders.Clear();
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//Getting Data data back
            apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { token }"); // Send credentials (short-lived token) along with every call header to ensure call is authorized

            using (HttpResponseMessage response = await apiClient.GetAsync("/api/User")) // User endpoint
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<LoggedInUserModel>();
                    _loggedInUser.CreatedDate = result.CreatedDate;
                    _loggedInUser.EmailAddress = result.EmailAddress;
                    _loggedInUser.FirstName = result.FirstName;
                    _loggedInUser.Id = result.Id;
                    _loggedInUser.LastName = result.LastName;
                    _loggedInUser.Token = token;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}