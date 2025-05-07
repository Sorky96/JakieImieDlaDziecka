using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Enums;
using System;

namespace StatisticsProcessor
{
    public class EnumConverter<T> : DefaultTypeConverter where T : struct
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (!Enum.TryParse(text, out Gender sex))
            {   
                if (text == "M")
                {
                    return Gender.Male;
                }
                else if(text == "K")
                {
                    return Gender.Famale;
                }

                throw new InvalidCastException($"Invalid value to EnumConverter. Type: {typeof(T)} Value: {text}");
            }

            return sex;
        }
    }
}
