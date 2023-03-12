using Matchaholic.Processor;
using Matchaholic.Processor.Model.Setings;
using Matchaholic.Processor.Services.Interfaces;
using Matchaholic.Processor.Services;

IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            IConfiguration configuration = hostContext.Configuration;
            services.Configure<SNSSettings>(configuration.GetSection("SNS"));
            services.AddSingleton<INotificationPublisher, SNSNotificationPublisher>();
            services.AddHostedService<Worker>();
        })
    .Build();


await host.RunAsync();
