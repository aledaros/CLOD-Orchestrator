using Clod.Orchestrator;
using MassTransit;
using IHost = Microsoft.Extensions.Hosting.IHost;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddMassTransit(x => {
            x.UsingRabbitMq((context, config) =>
            {
                config.Host("roedeer.rmq.cloudamqp.com", "vpeeygzh",
                  credential => {
                      credential.Username("vpeeygzh");
                      credential.Password("t0mDd3KRsJkXRV3DXzmCUfRWmDFbFu42");
                  });
                config.ConfigureEndpoints(context);
            });
        });
        services.AddMassTransitHostedService();
    })
    .Build();

await host.RunAsync();
