using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Hosting;
using System.Web.Mvc;
using Hangfire;
using HangFire.Mailer.Models;
using Newtonsoft.Json;
using Postal;

namespace HangFire.Mailer.Controllers
{
    public class HomeController : Controller
    {
        private readonly MailerDbContext _db = new MailerDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            var comments = _db.Comments.OrderBy(x => x.Id).ToList();
            return View(comments);
        }

        [HttpPost]
        public ActionResult Create(Comment model)
        {
            if (ModelState.IsValid)
            {
                _db.Comments.Add(model);
                _db.SaveChanges();
            }

            BackgroundJob.Enqueue(() => NotifyNewComment(model.Id));

            return RedirectToAction("Index");
        }

        [Queue("critical")]
        public static void NotifyNewComment(int commentId)
        {
            // Prepare Postal classes to work outside of ASP.NET request
            var viewsPath = Path.GetFullPath(HostingEnvironment.MapPath(@"~/Views/Emails"));
            var engines = new ViewEngineCollection();
            engines.Add(new FileSystemRazorViewEngine(viewsPath));

            var emailService = new EmailService(engines);

            // Get comment and send a notification.
            using (var db = new MailerDbContext())
            {
                var comment = db.Comments.Find(commentId);

                var email = new NewCommentEmail
                {
                    To = "yourmail@example.com",
                    UserName = comment.UserName,
                    Comment = comment.Text
                };

                emailService.Send(email);
            }
        }

        [HttpGet]
        public ActionResult About()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult About(string mensaje)
        {

            BackgroundJob.Enqueue(() => CallApi());

            return RedirectToAction("Index");
        }

        public static void CallApi()
        {

            string urlToken = ConfigurationManager.AppSettings["ApiUrl"];
            string grant_type = ConfigurationManager.AppSettings["grant_type"];
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];

            var form = new Dictionary<string, string>
                {
                    {"grant_type", grant_type},
                    {"client_id", username},
                    {"client_secret", password},
                };


            using (var httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("cache-control", "no-cache");


                //HttpResponseMessage tokenResponse = httpClient.PostAsync(url, new FormUrlEncodedContent(form));

                var tokenResponse = httpClient.PostAsync(urlToken, new FormUrlEncodedContent(form)).Result;
                
                var jsonContent = tokenResponse.Content.ReadAsStringAsync().Result;

                Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);

                tok.ToString();

            }
        }
       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}