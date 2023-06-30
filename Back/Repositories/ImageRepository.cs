using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using Back.Model;

public class ImageRepository : IRepository<ImageDatum>
{
    private BadditContext ctx;
    public ImageRepository(BadditContext ctx)
        => this.ctx = ctx;

    public async Task Add(ImageDatum obj)
    {
        await ctx.ImageData.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public void Delete(ImageDatum obj)
    {
        throw new NotImplementedException();
    }

    // public Task Delete(ImageDatum obj)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task<List<ImageDatum>> Filter(Expression<Func<ImageDatum, bool>> condition)
    {
        var query = ctx.ImageData.Where(condition);
        return await query.ToListAsync();
    }

    public Task<List<ImageDatum>> GetAll(ImageDatum ctx)
    {
        throw new NotImplementedException();
    }

    // public Task Update(ImageDatum obj)
    // {
    //     throw new NotImplementedException();
    // }

    public void Update(ImageDatum obj)
    {
        throw new NotImplementedException();
    }
}
