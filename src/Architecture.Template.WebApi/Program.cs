using WebApi;

var host = CreateHostBuilder(args).Build();
host.Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
                webBuilder.UseStartup<Startup>());


//TODO - ver de colocar a startup injetada
//var builder = WebApplication.CreateBuilder(args);

//var startup = new Startup(builder.Configuration);
//startup.ConfigureServices(builder.Services);

//var app = builder.Build();
//startup.Configure(app, app.Environment);
//app.Run();