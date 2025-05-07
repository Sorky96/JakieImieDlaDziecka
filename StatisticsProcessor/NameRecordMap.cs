using CsvHelper.Configuration;
using Enums;
using Models;

namespace StatisticsProcessor
{
    public sealed class NameRecordMap : ClassMap<NameRecord>
    {
        public NameRecordMap()
        {
            Map(m => m.Name).Name("Imie");
            Map(m => m.Year).Name("Rok");
            Map(m => m.Count).Name("Liczba");
            Map(m => m.Gender).Name("Plec").TypeConverter<EnumConverter<Gender>>();
        }
    }
}
