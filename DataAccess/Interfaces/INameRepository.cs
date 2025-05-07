using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface INameRepository
    {
        Task<IEnumerable<NameRecord>> GetNamesByYearAsync(int year);
        Task<IEnumerable<NameRecord>> GetTopNamesByYearAsync(int year, int top);
        Task<NameRecord> GetNameByIdAsync(int id);
        Task AddNameRecordAsync(NameRecord nameRecord);
        Task UpdateNameRecordAsync(NameRecord nameRecord);
        Task DeleteNameRecordAsync(int id);
    }
}
