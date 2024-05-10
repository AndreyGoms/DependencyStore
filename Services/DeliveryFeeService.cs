using DependencyStore.Services.Contracts;
using RestSharp;

namespace DependencyStore.Services;

public class DeliveryFeeService : IDeliveryFeeService
{
    private readonly Configuration _configuration;

    public DeliveryFeeService(Configuration configuration) => _configuration = configuration;

    public async Task<decimal> GetDeliveryFeeAsync(string zipCode)
    {
        //https://consultafrete.io/cep/
        //var client = new RestClient("http://api.myorg.com");
        var client = new RestClient(_configuration.DeliveryFeeServiceUrl);
        var request = new RestRequest()
            .AddJsonBody( new 
            {
                ZipCode = zipCode   
            });

        var response = await client.PostAsync<decimal>(request);
        return response < 5 ? 5 : response;
    }
}