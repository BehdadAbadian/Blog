using Framework.Domain;
using System.Linq.Expressions;

namespace Framework.Infrastructure
{
    public interface IRepository<TKey,T> where T : DomainBase<TKey>
    {
        void Create(T entity);
        T Get(TKey id);
        List<T> GetAll();
        bool Exists(Expression<Func<T, bool>> expression);
        void Save();

    }
}
