

using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(
               x =>
               {
                   

                   x.UsingRabbitMq((context, config) =>
                   {


                       config.Host(
                           "roedeer.rmq.cloudamqp.com",
                           "vpeeygzh",
                           credential =>
                           {
                               credential.Username("vpeeygzh");
                               credential.Password("t0mDd3KRsJkXRV3DXzmCUfRWmDFbFu42");
                           }
                       );

                       config.ConfigureEndpoints(context);
     

                   });
               }
           );

builder.Services.AddMassTransitHostedService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
