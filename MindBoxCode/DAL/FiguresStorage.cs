using MindBoxCode.DAL.Abstractions;
using MindBoxCode.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindBoxCode.DAL
{
	public class FiguresStorage : IFiguresStorage
	{
		// корректно сконфигурированный и готовый к использованию клиент Редиса
		private readonly IRedisClient _redisClient;
	
		public FiguresStorage(IRedisClient redisClient)
		{
			_redisClient = redisClient;
		}

		public async Task<bool> CheckIfAvailable(string type, int count)
		{
			return await _redisClient.Get(type) >= count;
		}

		public async Task Reserve(string type, int count)
		{
			var current = await _redisClient.Get(type);

			await _redisClient.Set(type, current - count);
		}

		public async Task ReserveList(IEnumerable<(string, int)> positions)
		{
			foreach (var position in positions)
			{
				await Reserve(position.Item1, position.Item2);
			}
		}

		public async Task<bool> CheckIfListAvailable(IEnumerable<(string, int)> positions)
		{
			foreach (var position in positions)
			{
				if (!await CheckIfAvailable(position.Item1, position.Item2))
				{
					return false;
				}
			}
			return true;
		}
	}

}
