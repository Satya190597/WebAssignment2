using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using UserRegistrationPortal.Services;
using UserRegistrationPortal.Controllers;

namespace UserRegistrationPortal
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      container.RegisterType<ICurrentUserService,CurrentUserServiceImplementation>();

      container.RegisterType<IUploadFileService, UploadFileServiceImplementation>();

      container.RegisterType<IUserService, UserServiceImplementation>();

      container.RegisterType<IAuthenticationService, AuthenticationServiceImplementation>();

      container.RegisterType<IController, HomeController>("HomeServices");

      container.RegisterType<IController, UserController>("UserServices");

      container.RegisterType<IController, AccountController>("AccountServices");

      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}