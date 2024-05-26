using FiapHackaton.WebApp.Contracts.Interface;
using FiapHackaton.WebApp.Models;

namespace FiapHackaton.WebApp.Contracts
{
	public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
	{
		private readonly IHttpClientFactory _client;
		
		public ScheduleRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
		{
			_client = httpClientFactory;
			
		}

	}
}
