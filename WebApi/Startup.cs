using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.SqlServer;

[assembly: OwinStartup(typeof(Startup))]
public class Startup
{
    private static string CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    public void Configuration(IAppBuilder app)
    {
      
        //hangfire set up            
        var options = new SqlServerStorageOptions
        {
            PrepareSchemaIfNecessary = true
        };

        GlobalConfiguration.Configuration.UseSqlServerStorage(CONNECTION_STRING,options);
        app.UseHangfireDashboard();
        //var options = new BackgroundJobServerOptions { WorkerCount = 1 };
        app.UseHangfireServer();

        //DoctorService.PopulateList();//first time initialise

        //Doctor list will populate every 5 minutes 
        //RecurringJob.AddOrUpdate(()=>DoctorService.PopulateList(), "*/5 * * * *");
    }
}
