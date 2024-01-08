using Mc2.CrudTest.QuerySynchronizer.EF;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();