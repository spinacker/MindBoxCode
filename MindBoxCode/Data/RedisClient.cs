using MindBoxCode.Data.Abstractions;
using System.Threading.Tasks;

namespace MindBoxCode.Data
{
    public class RedisClient : IRedisClient
    {
        public async Task<int> Get(string type)
        {
            //await some implementation
            await Task.Delay(1);
            return 1;
        }

        public async Task Set(string type, int current)
        {
            //await some implementation
        }
    }
}
