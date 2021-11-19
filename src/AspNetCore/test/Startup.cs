namespace BizStream.AspNetCore.ViewComponentAssets.Tests
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public void ConfigureServices( IServiceCollection services )
        {
            services.AddMvc()
                .AddViewComponentAssets();
        }

        public void Configure( IApplicationBuilder app )
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints( endpoints => endpoints.MapDefaultControllerRoute() );
        }
    }
}
