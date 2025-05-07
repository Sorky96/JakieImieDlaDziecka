using CsvHelper;
using Models;
using StatisticsProcessor;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CsvDataInitializer
    {      

        public IEnumerable<NameRecord> InitializeData(string csvFilePath)
        {
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<NameRecordMap>();
                return csv.GetRecords<NameRecord>();
            }
        }
    }
}
