using System;
using Microsoft.Extensions.DependencyInjection;
using OdinLog.Core;

namespace OdinLog
{
    public static class OdinLogInject
    {
        public static IServiceCollection AddOdinSingletonOdinLogs(
            this IServiceCollection services, 
            Action<OdinLogOption> action)
        {
            var opts = new OdinLogOption();
            action(opts);
            services.AddSingleton<IOdinLogs>(provider => new OdinLogs(opts));
            System.Console.WriteLine($"注入类型【 OdinLogs 】");
            return services;
        }
        
        public static IServiceCollection AddTransientOdinLogs(
            this IServiceCollection services, 
            Action<OdinLogOption> action)
        {
            var opts = new OdinLogOption();
            action(opts);
            services.AddTransient<IOdinLogs>(provider => new OdinLogs(opts));
            System.Console.WriteLine($"注入类型【 OdinLogs 】");
            return services;
        }
        
        public static IServiceCollection AddScopedOdinLogs(
            this IServiceCollection services, 
            Action<OdinLogOption> action)
        {
            var opts = new OdinLogOption();
            action(opts);
            services.AddScoped<IOdinLogs>(provider => new OdinLogs(opts));
            System.Console.WriteLine($"注入类型【 OdinLogs 】");
            return services;
        }
    }
}