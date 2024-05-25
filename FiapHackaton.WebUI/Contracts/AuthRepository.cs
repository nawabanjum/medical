using FiapHackaton.WebUI.Contracts.Interface;
using FiapHackaton.WebUI.DTO;
using FiapHackaton.WebUI.Model;
using FiapHackaton.WebUI.Static;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FiapHackaton.WebUI.Contracts
{
	public class AuthRepository : IAuthRepository
	{
		private readonly IHttpClientFactory _client;

		public AuthRepository(IHttpClientFactory client)
		{
			_client = client;
		
		}

	
		public async Task<bool> Login(LoginDTO user)
		{
			user.Email = "";
			user.Password = "";
			var request = new HttpRequestMessage(HttpMethod.Post
			   , Endpoints.LoginEndPoint);
			request.Content = new StringContent(JsonConvert.SerializeObject(user)
				, Encoding.UTF8, "application/json");

			var client = _client.CreateClient();
			HttpResponseMessage response = await client.SendAsync(request);

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
