using Hangfire;
using Hangfire.SqlServer;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangFire.Mailer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage(
                    "MailerDb",
                    new SqlServerStorageOptions { QueuePollInterval = TimeSpan.FromSeconds(1) });


            app.UseHangfireDashboard();


            var options = new BackgroundJobServerOptions
            {
                Queues = new[] { "critical", "default" }
            };


            app.UseHangfireServer(options);


        }

    }
}