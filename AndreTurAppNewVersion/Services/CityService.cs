using AndreTurApp.Models;
using Newtonsoft.Json;
using System.Net;

namespace AndreTurAppNewVersion.Services
{
    public class CityService
    {
        static readonly HttpClient cityClient = new();
        public async Task<List<City>> Get()
        {
            try
            {
                HttpResponseMessage response = await CityService.cityClient.GetAsync("https://localhost:7263/api/Cities");
                response.EnsureSuccessStatusCode();
                string city = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<City>>(city);
            }
            catch (HttpRequestException e)
            {
                throw new(e.Message);
            }
        }
        public async Task<City> GeById(int id)
        {
            try
            {
                HttpResponseMessage response = await CityService.cityClient.GetAsync("https://localhost:7263/api/Cities/" + id);
                response.EnsureSuccessStatusCode();
                string city = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<City>(city);
            }
            catch (HttpRequestException e)
            {
                throw new(e.Message);
            }
        }
        public async Task<City> PostCity(City city)
        {
            try
            {
                HttpResponseMessage response = await CityService.cityClient.PostAsJsonAsync("https://localhost:7263/api/Cities", city);
                response.EnsureSuccessStatusCode();
                return city;
            }
            catch (HttpRequestException e)
            {
                throw new (e.Message);
            }
        }
        public async Task<City> PutCity(City city)
        {
            try
            {
                HttpResponseMessage response = await CityService.cityClient.PutAsJsonAsync("https://localhost:7263/api/Cities", city);
                response.EnsureSuccessStatusCode();
                return city;
            }
            catch (HttpRequestException e)
            {
                throw new (e.Message);
            }
        }
        public async Task<HttpStatusCode> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await CityService.cityClient.DeleteAsync("https://localhost:7263/api/Cities/" + id);
                response.EnsureSuccessStatusCode();
                string city = await response.Content.ReadAsStringAsync();
                return HttpStatusCode.NoContent;
            }
            catch (HttpRequestException)
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}
