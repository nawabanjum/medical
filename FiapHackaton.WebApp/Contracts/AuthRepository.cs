using Blazored.LocalStorage;
using FiapHackaton.WebApp.Contracts.Interface;
using FiapHackaton.WebApp.DTO;
using FiapHackaton.WebApp.Models;
using FiapHackaton.WebApp.Static;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FiapHackaton.WebApp.Contracts
{
	public class AuthRepository : IAuthRepository
	{
		private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStorage;
        public AuthRepository(IHttpClientFactory client, ILocalStorageService  localStorage)
		{
			_client = client;
			_localStorage = localStorage;

        }

	
		public async Task<bool> Login(LoginDTO user)
		{
	
			var request = new HttpRequestMessage(HttpMethod.Post
			   , Endpoints.LoginEndPoint);
			request.Content = new StringContent(JsonConvert.SerializeObject(user)
				, Encoding.UTF8, "application/json");

			var client = _client.CreateClient();
			HttpResponseMessage response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<UserProfile>(content);
            if (obj != null)
			{
				await _localStorage.SetItemAsync("UserId", obj.UserId.ToString());
				await _localStorage.SetItemAsync("UserTypeId", obj.UserTypeId.ToString());
			}
			if (!response.IsSuccessStatusCode)
			{
				return false;
			}
			return true;
		}

		public async Task Logout()
		{
			
		}

		public async Task<bool> Register(UserDto user)
		{
			var request = new HttpRequestMessage(HttpMethod.Post
				, Endpoints.RegisterEndpoint)
			{
				Content = new StringContent(JsonConvert.SerializeObject(user)
				, Encoding.UTF8, "application/json")
			};

			var client = _client.CreateClient();
			HttpResponseMessage response = await client.SendAsync(request);

			return response.IsSuccessStatusCode;
		}
	}
}
