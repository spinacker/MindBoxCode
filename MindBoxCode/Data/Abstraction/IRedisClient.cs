using System.Threading.Tasks;

namespace MindBoxCode.Data.Abstractions
{
	public interface IRedisClient
	{
		Task<int> Get(string type);
		Task Set(string type, int current);
	}
}
