using Microsoft.Extensions.DependencyInjection; // ← ADICIONAR

namespace IntegracaoCepsaBrasil.Util.Helpers;

public static class DependencyInfectionHelper
{
    public static void RegisterAll<T>(IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {        
        var types = typeof(T).Assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(T)));

        foreach (var type in types)
        {
            var interfaceType = type.GetInterfaces().FirstOrDefault(i => i.Name == $"I{type.Name}");

            if (interfaceType is not null)
            {
                if (serviceLifetime == ServiceLifetime.Singleton)
                {
                    services.AddSingleton(interfaceType, type);
                }
                else if (serviceLifetime == ServiceLifetime.Scoped)
                {
                    services.AddScoped(interfaceType, type);
                }
                else if (serviceLifetime == ServiceLifetime.Transient)
                {
                    services.AddTransient(interfaceType, type);
                }
            }
        }
    }
}
