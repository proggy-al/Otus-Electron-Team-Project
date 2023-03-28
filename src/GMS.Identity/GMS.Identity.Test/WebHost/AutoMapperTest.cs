using AutoMapper;
using GMS.Identity.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.Test.WebHost
{
    public class AutoMapperTest
    {
        [Fact]
        public void AutoMapper_IsWorking_correctly()
        {
            var configuration = new MapperConfiguration(cfg =>
                                cfg.AddProfile<MappingProfile>());
           

            configuration.AssertConfigurationIsValid();
        }
    }
}
