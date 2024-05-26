using FiapHackaton.WebApp.Contracts.Interface;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;

namespace FiapHackaton.WebApp.Contracts
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		private IHttpClientFactory _client;
		
		public BaseRepository(IHttpClientFactory client)
		{
			_client = client;
			
		}

		public async Task<bool> Create(string url, T obj)
		{
			var request = new HttpRequestMessage(HttpMethod.Post, url);
			if (obj == null)
			{
				return false;
			}
			request.Content = new StringContent(JsonConvert.SerializeObject(obj),
			   Encoding.UTF8, "application/json");
			var client = _client.CreateClient();
			HttpResponseMessage httpResponse = await client.SendAsync(request);
			if (httpResponse.StatusCode == System.Net.HttpStatusCode.Created)
			{
				return true;
			}
			return false;
		}

		public async Task<bool> Delete(string url, int id)
		{
			if (id < 0)
			{
				return false;
			}
			var request = new HttpRequestMessage(HttpMethod.Delete, url + id);

			var client = _client.CreateClient();
		
			HttpResponseMessage httpResponse = await client.SendAsync(request);
			if (httpResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
			{
				return true;
			}
			return false;
		}

		public async Task<T> Get(string url, int id)
		{

			var request = new HttpRequestMessage(HttpMethod.Get, url + id);
			var client = _client.CreateClient();
			HttpResponseMessage httpResponse = await client.SendAsync(request);
			if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
			{
				var content = await httpResponse.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(content);
			}
			return null;
		}
		public async Task<IList<T>> Get(string url)
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, url);

				var client = _client.CreateClient();
			
				HttpResponseMessage response = await client.SendAsync(request);

				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					var content = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<IList<T>>(content);
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				return null;

			}
		}

		public async Task<bool> Update(string url, T obj, int id)
		{
			var request = new HttpRequestMessage(HttpMethod.Put, url + id);
			if (obj == null)
			{
				return false;
			}
			request.Content = new StringContent(JsonConvert.SerializeObject(obj),
				Encoding.UTF8, "application/json");
			var client = _client.CreateClient();
		
			HttpResponseMessage httpResponse = await client.SendAsync(request);
			if (httpResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
			{
				return true;
			}
			return false;
		}

	

	}
}
