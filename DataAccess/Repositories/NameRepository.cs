using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Models;
using DataAccess.Interfaces;

public class NameRepository : INameRepository
{
    private readonly AppDbContext _context;

    public NameRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<NameRecord>> GetNamesByYearAsync(int year)
    {
        return await _context.NameRecords
                             .Where(n => n.Year == year)
                             .ToListAsync();
    }

    public async Task<NameRecord> GetNameByIdAsync(int id)
    {
        return await _context.NameRecords
                             .FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task AddNameRecordAsync(NameRecord nameRecord)
    {
        _context.NameRecords.Add(nameRecord);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateNameRecordAsync(NameRecord nameRecord)
    {
        _context.Entry(nameRecord).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteNameRecordAsync(int id)
    {
        var nameRecord = await _context.NameRecords.FindAsync(id);
        if (nameRecord != null)
        {
            _context.NameRecords.Remove(nameRecord);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<NameRecord>> GetTopNamesByYearAsync(int year, int top)
    {
        return await _context.NameRecords
                             .Where(n => n.Year == year)
                             .OrderByDescending(_ => _.Count)
                             .Take(top)
                             .ToListAsync();
    }
}