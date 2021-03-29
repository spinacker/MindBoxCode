using MindBoxCode.DAL.Abstractions;
using MindBoxCode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindBoxCode.DAL
{
    public class OrderStorage : IOrderStorage
    {
        public async Task<decimal> Save(Order order)
        {
            await Task.Delay(1);
            return 100.0m;
        }
    }
}
