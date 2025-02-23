﻿using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class
{
    protected ApplicationDbContext _context { get; set; }
    protected DbSet<T> _dbset { get; set; }

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbset = context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbset.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        T entity = await _dbset.FindAsync(id);
        _dbset.Remove(entity);
        await _context.SaveChangesAsync();
        
    }

    public async Task<IEnumerable<T>> GetAllAsyncs()
    {
        return await _dbset.ToListAsync();
    }

    public async Task<T> GetIdByAsync(int id, QueryOptions<T> options)
    {
        IQueryable<T> query = _dbset;

        if (options.HasWhere)
        {
            query = query.Where(options.Where);
        }
        if (options.HasOrderBy)
        {
            query = query.OrderBy(options.OrderBy);
        }
        foreach (string include in options.GetIncludes())
        {
            query = query.Include(include);
        }

        var key = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();
        string primaryKeyName = key?.Name;

        return await query.FirstOrDefaultAsync(x => EF.Property<int>(x, primaryKeyName) == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
