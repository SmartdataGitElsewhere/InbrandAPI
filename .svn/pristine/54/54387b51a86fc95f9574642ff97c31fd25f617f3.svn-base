using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using Inbrand.Providers;
using System.Web.Http;
using Microsoft.Owin.Security.DataProtection;
using Inbrand.Models;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.AspNet.Identity;
using Unity.WebApi;
using Unity.SelfHostWebApiOwin;
using Microsoft.AspNet.Identity.EntityFramework;
using Inbrand.CoreEntities;
using InbrandInterface;
using RepositoryLayer;

[assembly: OwinStartup(typeof(Inbrand.Startup))]

namespace Inbrand
{   
    public partial class Startup
    {
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }

        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {
            var issuer = ConfigurationManager.AppSettings["as:Issuer"];
            var audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            var audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            

        }
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            HttpConfiguration config = new HttpConfiguration();

            

            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            ConfigureOAuth(app);
            createRolesandUsers();
            DataProtectionProvider = app.GetDataProtectionProvider();
            
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());

            WebApiConfig.Register(config);
            //app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);



        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                        
                var user = new ApplicationUser();
                user.UserName = "mattias@gmail.com";
                user.Email = "mattias@gmail.com";

                string userPWD = "aA123456!";
                var chkUser = UserManager.Create(user, userPWD);                

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
                UnitOfWork worker = new UnitOfWork();
                User userdetails = new User();
                userdetails.AspNetUserId = user.Id;
                userdetails.FirstName = "Mattias";
                userdetails.LastName = "Jacobsson";
                userdetails.Email = "mattias@gmail.com";
                userdetails.UserName = "mattias@gmail.com";
                userdetails.Password = "aA123456!";
                userdetails.Status = true;
                worker.Users.Add(userdetails);
                worker.SaveChanges();
            }

            // creating Creating Manager role
            //if (!roleManager.RoleExists("Manager"))
            //{

            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Manager";
            //    roleManager.Create(role);
            //}
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            PublicClientId = "12232389#434%%%%&&@#@#";
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {

                TokenEndpointPath = new PathString("/token"),   
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new ApplicationOAuthProvider(PublicClientId),
               
                // Note: Remove the following line before you deploy to production:
                AllowInsecureHttp = true,
            };



            // Add Unity DependencyResolver



            // Enable the application to use bearer tokens to authenticate users
            // Token Generation
            
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
