using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using Model;

public class LocationRepository : IRepository<Location>
{
    private FullExampleContext ctx;
    public LocationRepository(FullExampleContext ctx)
        => this.ctx = ctx;

    public async Task Add(Location obj)
    {
        await ctx.Locations.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<Location>> Filter(Expression<Func<Location, bool>> condition)
    {
        var query = ctx.Locations.Where(condition);
        return await query.ToListAsync();
    }
}
