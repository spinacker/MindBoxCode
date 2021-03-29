using MindBoxCode.DAL.Abstractions;
using System.Threading.Tasks;

namespace MindBoxCode.DAL
{
    public class RedisClient : IRedisClient
    {
        public async Task<int> Get(string type)
        {
            //await some implementation
            return 1;
        }

        public async Task Set(string type, int current)
        {
            //await some implementation
        }
    }
}
