using System.Data.Objects;
using System.Linq;

namespace NeuCMS.Core.Repositories
{
	public interface IRepositoryContext
	{
		int Save();
		void Dispose();
		IObjectSet<T> ObjectSet<T>() where T : class ;
	}
}