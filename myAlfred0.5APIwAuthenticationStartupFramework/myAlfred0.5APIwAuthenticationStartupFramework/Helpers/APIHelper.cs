using myAlfred0._5APIwAuthenticationStartupFramework.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace myAlfred0._5APIwAuthenticationStartupFramework.Helpers
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient apiClient; //One HttpClient for the lifespan of our application to prevent clogging of network

        public APIHelper()
        {
            InitalizeClient(); //Whenever a new APIHelper is crerated it will initialize the client
        }

        private void InitalizeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri("");
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//Getting Data data back
        }

        public async Task<AuthenticatedUser> Authenticate(string username, string password) //This method should allow us to call the token using the password and get back a response
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            using (HttpResponseMessage response = await apiClient.PostAsync("/Token", data))//(Url for Api Endpoint (localhost/azure), send formatted data)
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
    }
}