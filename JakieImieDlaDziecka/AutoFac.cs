using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsProcessor
{
    public static class AutoFac
    {
        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder = new ContainerBuilder();

            builder.RegisterType<NameRecordMap>().AsSelf();
            builder.Build();
        }

    }
}
