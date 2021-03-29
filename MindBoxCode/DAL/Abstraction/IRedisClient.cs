using System.Threading.Tasks;

namespace MindBoxCode.DAL.Abstractions
{
	public interface IRedisClient
	{
		Task<int> Get(string type);
		Task Set(string type, int current);
	}
}
