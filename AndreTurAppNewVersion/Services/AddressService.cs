using AndreTurApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace AndreTurAppNewVersion.Services
{
    public class AddressService
    {
        static readonly HttpClient addressClient = new();

        public async Task<List<Address>> GetAddress()
        {
            try
            {
                HttpResponseMessage response = await AddressService.addressClient.GetAsync("https://localhost:7025/api/Addresses");
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Address>>(address);
            }
            catch (HttpRequestException e)
            {
                throw new(e.Message);
            }
        }
        public async Task<Address> GetAddressById(int id)
        {
            try
            {
                HttpResponseMessage response = await AddressService.addressClient.GetAsync("https://localhost:7025/api/Addresses/" + id);
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(address);
            }
            catch (HttpRequestException e)
            {
                throw new(e.Message);
            }
        }
        public async Task<HttpStatusCode> PostAddress(Address address)
        {
            HttpResponseMessage response = await AddressService.addressClient.PostAsJsonAsync("https://localhost:7025/api/Addresses", address);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
        public async Task<ActionResult<Address>> PutAddress(int id, Address address)
        {

                HttpResponseMessage responseGet = await AddressService.addressClient.GetAsync("https://localhost:7025/api/Addresses/" + id); 
                var addressFound = await responseGet.Content.ReadAsStringAsync();
                var addressReady = JsonConvert.DeserializeObject<Address>(addressFound);

                if (id != addressReady.Id)
                    return new NotFoundResult();

            try
            {
                HttpResponseMessage response = await AddressService.addressClient.PutAsJsonAsync("https://localhost:7025/api/Addresses/" + id, address);
                response.EnsureSuccessStatusCode() ;
                return address;
            }
            catch (Exception e)
            {
                throw new(e.Message);
            }

        }
        public async Task<HttpStatusCode> DeleteAddress(int id)
        {
            try
            {
                HttpResponseMessage response = await AddressService.addressClient.DeleteAsync("https://localhost:7025/api/Addresses/" + id);
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return HttpStatusCode.NoContent;
            }
            catch (HttpRequestException)
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}
