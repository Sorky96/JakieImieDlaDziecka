using CsvHelper;
using Models;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StatisticsProcessor.Services
{
    public static class FileProcessor
    {
        public static List<NameRecord> InitialFeed()
        {
            List<NameRecord> years = new List<NameRecord>();
            using (var reader = new StreamReader(@"src/imiona2000-2019.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<NameRecordMap>();
                years = csv.GetRecords<NameRecord>()
                    .Where(_ => _.Year == 2019)
                    .OrderByDescending(_ => _.Count)
                    .Select(_ =>
                    {
                        _.Name = $"{_.Name[0]}{_.Name.Substring(1).ToLower()}";
                        return _;
                    }
                    )
                    .ToList();
            }

            return years;
        }
    }
}