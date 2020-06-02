using BaseFramework.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MapConfig.Configprofile
{
    public class MapperConfig
    {
        public static void RegisterMappers()
        {
            MapperFactory.RegisterMappers();
        }
    }
}
