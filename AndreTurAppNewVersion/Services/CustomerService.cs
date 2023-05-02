using AndreTurApp.Models;
using Newtonsoft.Json;
using System.Net;

namespace AndreTurAppNewVersion.Services
{
    public class CustomerService
    {
        static readonly HttpClient customerClient = new();

        public async Task<List<Customer>> GetCustomer()
        {
            try
            {
                HttpResponseMessage response = await CustomerService.customerClient.GetAsync("https://localhost:7215/api/Customers");
                response.EnsureSuccessStatusCode();
                string customer = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Customer>>(customer);
            }
            catch (HttpRequestException e)
            {
                throw new(e.Message);
            }
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                HttpResponseMessage response = await CustomerService.customerClient.GetAsync("https://localhost:7215/api/Customers/" + id);
                response.EnsureSuccessStatusCode();
                string customer = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(customer);
            }
            catch (HttpRequestException e)
            {
                throw new(e.Message);
            }
        }
        public async Task<HttpStatusCode> PostCustomer(Customer customer)
        {
            HttpResponseMessage response = await CustomerService.customerClient.PostAsJsonAsync("https://localhost:7215/api/Customers", customer);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
        public async Task<HttpStatusCode> PutCostumer(Customer customer)
        {
            HttpResponseMessage response = await CustomerService.customerClient.PutAsJsonAsync("https://localhost:7215/api/Customers", customer);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
        public async Task<HttpStatusCode> DeleteCustomer(int id)
        {
            try
            {
                HttpResponseMessage response = await CustomerService.customerClient.DeleteAsync("https://localhost:7215/api/Customers/" + id);
                response.EnsureSuccessStatusCode();
                string customer = await response.Content.ReadAsStringAsync();
                return HttpStatusCode.NoContent;
            }
            catch (HttpRequestException)
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}
