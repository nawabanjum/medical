using FiapHackaton.WebUI.Contracts.Interface;
using FiapHackaton.WebUI.Models;

namespace FiapHackaton.WebUI.Contracts
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
