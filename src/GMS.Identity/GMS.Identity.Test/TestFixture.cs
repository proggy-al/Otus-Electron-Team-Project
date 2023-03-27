using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMS.Identity.WebHost.Configuration;

namespace GMS.Identity.Test;

public class TestFixture:IDisposable
{
    public IServiceProvider ServiceProvider { get; private set; }

    public TestFixture() 
    {
        var services = new ServiceCollection();

        services.ConfigureMapper();

        ServiceProvider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
    }
}
