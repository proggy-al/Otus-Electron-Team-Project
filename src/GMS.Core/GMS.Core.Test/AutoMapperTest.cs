﻿using AutoMapper;
using GMS.Core.BusinessLogic.Mappings;
using GMS.Core.WebHost.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Core.Test
{
    public class AutoMapperTest
    {
        [Fact]
        public void AutoMapper_IsWorking_correctly()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FitnessClubMappingsProfile>();
                cfg.AddProfile<AreaMappingsProfile>();
                cfg.AddProfile<ProductMappingsProfile>();
                cfg.AddProfile<ContractMappingsProfile>();
                cfg.AddProfile<TimeSlotMappingsProfile>();
                cfg.AddProfile<TrainingMappingsProfile>();

                cfg.AddProfile<FitnessClubVmMappingsProfile>();
                cfg.AddProfile<AreaVmMappingsProfile>();
                cfg.AddProfile<ProductVmMappingsProfile>();
                cfg.AddProfile<ContractVmMappingsProfile>();
                cfg.AddProfile<TimeSlotVmMappingsProfile>();
                cfg.AddProfile<TrainingVmMappingsProfile>();
            });

            configuration.AssertConfigurationIsValid();
        }
    }
}
