using MindBoxCode.Domain;
using System.Threading.Tasks;

namespace MindBoxCode.DAL.Abstractions
{
	public interface IOrderStorage
	{
		// сохраняет оформленный заказ и возвращает сумму
		Task<decimal> Save(Order order);
	}
}
