using Application;
using Infrastructure;

namespace WebApi;

public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration) =>
        Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication();
        services.AddInfrastructure(Configuration);
        services.AddWebServices();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHealthChecks("/health");
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}"));

    }
}