using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using Model;

public class ImageRepository : IRepository<ImageDatum>
{
    private ProjRedditContext ctx;
    public ImageRepository(ProjRedditContext ctx)
        => this.ctx = ctx;

    public async Task Add(ImageDatum obj)
    {
        await ctx.ImageData.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<ImageDatum>> Filter(Expression<Func<ImageDatum, bool>> condition)
    {
        var query = ctx.ImageData.Where(condition);
        return await query.ToListAsync();
    }
}
