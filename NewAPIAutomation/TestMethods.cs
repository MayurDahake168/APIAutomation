using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;


namespace Demo
{
    public class TestMethods
    {
        public GetUserDTO GetUsersTestDriven()
        {
            var restClient = new RestClient("https://reqres.in/");
            var restRequest = new RestRequest("/api/users?page=2", Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;
            var users = JsonConvert.DeserializeObject<GetUserDTO>(content);
            return users;

        }

        public PostUserDTO CreateUserTestDriven(string playload)
        {

            var restClient = new RestClient("https://reqres.in/");
            var restRequest = new RestRequest("api/users", Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", playload, ParameterType.RequestBody);
            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;
            var users = JsonConvert.DeserializeObject<PostUserDTO>(content);
            return users;

        }
        public PostUserDTO UpdateUserTestDriven(string playload)
        {

            var restClient = new RestClient("https://reqres.in/");
            var restRequest = new RestRequest("api/users/2", Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", playload, ParameterType.RequestBody);
            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;
            var users = JsonConvert.DeserializeObject<PostUserDTO>(content);
            return users;

        }
        public PostUserDTO DeleteUsersTestDriven()
        {
            var restClient = new RestClient("https://reqres.in/");
            var restRequest = new RestRequest("api/users/2", Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;
            var users = JsonConvert.DeserializeObject<PostUserDTO>(content);
            return users;

        }
        public PostUserDTO CreateUserDataDriven(PostUserDTO playload)
        {
            var restClient = new RestClient("https://reqres.in/");
            var jsonObj = JsonConvert.SerializeObject(playload, Formatting.Indented);
            var restRequest = new RestRequest("api/users", Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", jsonObj, ParameterType.RequestBody);
            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;
            var users = JsonConvert.DeserializeObject<PostUserDTO>(content);
            return users;

        }

        
    }
}
