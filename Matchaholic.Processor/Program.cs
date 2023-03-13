using Matchaholic.Processor;
using Matchaholic.Processor.Model.Setings;
using Matchaholic.Processor.Services.Interfaces;
using Matchaholic.Processor.Services;
using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            IConfiguration configuration = hostContext.Configuration;
            services.Configure<SNSSettings>(configuration.GetSection("SNS"));
            services.AddSingleton<INotificationPublisher, SNSNotificationPublisher>();
            services.AddHostedService<Worker>();
        }).UseSerilog((context, _, config) =>
        {
            config.ReadFrom.Configuration(context.Configuration)
                .Enrich.FromLogContext();          
        })
    .Build();


await host.RunAsync();
