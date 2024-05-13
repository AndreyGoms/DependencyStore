using DependencyStore.Repositories;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services;
using DependencyStore.Services.Contracts;

namespace DependencyStore;


public static class DependencyStore 
{
  public static void AddRepositories(this IServiceCollection services) 
  {
      services.AddTransient<ICustomerRepository, CustomerRepository>();
      services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
      services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
  }

  public static void AddServices(this IServiceCollection services)
  {
      services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
  }

}