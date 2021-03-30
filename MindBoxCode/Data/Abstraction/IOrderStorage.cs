using MindBoxCode.Infrastructure;
using System.Threading.Tasks;

namespace MindBoxCode.Data.Abstractions
{
	public interface IOrderStorage
	{
		// сохраняет оформленный заказ и возвращает сумму
		Task<double> Save(Order order);
	}
}
