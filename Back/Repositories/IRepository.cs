using System.Linq.Expressions;

public interface IRepository<T>
{
    Task Add(T obj);
    Task<List<T>> Filter(Expression<Func<T, bool>> condition);
    Task Delete(T obj); //task
    Task Update (T obj); //task

}
