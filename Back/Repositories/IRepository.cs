using System.Linq.Expressions;

public interface IRepository<T>
{
    Task Add(T obj);
    Task<List<T>> Filter(Expression<Func<T, bool>> condition);
    void Delete(T obj); //task
    void Update (T obj); //task


}
