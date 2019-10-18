using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OwinDemo
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {


            app.UseWelcomePage("/Welcome");


            //app.Use<HeaderMiddleware>();
            //app.Use<BodyMiddleware>();
            //app.Use<FooterMiddleware>();

            app.Use((context, next) =>
            {
                context.Response.ContentType = "text/html";
                if (!string.IsNullOrWhiteSpace(context.Request.Query.Get("name")))
                {
                    return context.Response.WriteAsync(string.Concat("Hello", context.Request.Query.Get("name")));
                }
                else
                {
                    return context.Response.WriteAsync("Guest");
                }

            });

        }


    }
}