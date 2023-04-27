using Microsoft.Extensions.DependencyInjection;

namespace GMS.Core.WebHost.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectAttribute : Attribute
    {
        public InjectAttribute(ServiceLifetime lifetime) 
        { 
            LifeTime = lifetime;
        }
        public ServiceLifetime LifeTime { get; }
    }
}
