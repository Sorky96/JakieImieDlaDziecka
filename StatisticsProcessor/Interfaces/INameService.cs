using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StatisticsProcessor.Interfaces
{
    public interface INameService
    {
        Task<IEnumerable<NameRecord>> GetNamesAsync(int year);
    }
}