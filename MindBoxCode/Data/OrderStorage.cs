using MindBoxCode.Data.Abstractions;
using MindBoxCode.Infrastructure;
using System.Threading.Tasks;

namespace MindBoxCode.Data
{
    public class OrderStorage : IOrderStorage
    {
        public async Task<double> Save(Order order)
        {
            //await some implementations

            await Task.Delay(1);
            return 100.0;
        }
    }
}
