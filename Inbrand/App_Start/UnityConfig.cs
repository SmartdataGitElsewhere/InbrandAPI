using Inbrand.Areas.HelpPage.Controllers;
using Inbrand.Controllers;
using Inbrand.FrotNoxAPI;
using Inbrand.FrotNoxAPI.Interface;
using Inbrand.Models;
using InbrandInterface;
using InbrandInterface.ServiceInterface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RepositoryLayer;
using ServiceLayer;
using System;
using System.Data.Entity;
using Unity;
using Unity.Injection;

namespace Inbrand
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
             container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IInvoiceRepository, InvoiceRepository>();
            container.RegisterType<IArticleRepository, ArticleRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
             container.RegisterType<ISubscriptionService, SubscriptionService>();
            container.RegisterType<IUserService, UserService>();
             container.RegisterType<IInvoiceService, InvoiceService>();
             container.RegisterType<IArticleService, ArticleService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<HelpController>(new InjectionConstructor());
            container.RegisterType<IIPAddressService, IPAddressService>();

        }
    }
}