using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindBoxCode.DAL.Abstractions
{
    public interface IFiguresStorage
    {
        Task<bool> CheckIfAvailable(string type, int count);
        Task<bool> CheckIfListAvailable(IEnumerable<(string, int)> positions);
        Task Reserve(string type, int count);
		Task ReserveList(IEnumerable<(string, int)> positions);
	}
}
