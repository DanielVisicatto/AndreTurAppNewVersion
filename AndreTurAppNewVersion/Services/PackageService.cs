using AndreTurApp.Models;
using Newtonsoft.Json;
using System.Net;

namespace AndreTurAppNewVersion.Services
{
    public class PackageService
    {
        static readonly HttpClient packageClient = new();

        public async Task<List<Package>> GetPackage()
        {
            try
            {
                HttpResponseMessage response = await PackageService.packageClient.GetAsync("https://localhost:7278/api/Packages");
                response.EnsureSuccessStatusCode();
                string package = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Package>>(package);
            }
            catch (HttpRequestException e)
            {
                throw new(e.Message);
            }
        }

        public async Task<Package> GetPackageId(int id)
        {
            try
            {
                HttpResponseMessage response = await PackageService.packageClient.GetAsync("https://localhost:7278/api/Packages/" + id);
                response.EnsureSuccessStatusCode();
                string package = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Package>(package);
            }
            catch (HttpRequestException e)
            {
                throw new(e.Message);
            }
        }
        public async Task<HttpStatusCode> PostPackage(Package package)
        {           
                HttpResponseMessage response = await PackageService.packageClient.PostAsJsonAsync("https://localhost:7278/api/Packages", package);
                response.EnsureSuccessStatusCode();                
                return response.StatusCode;            
        }
        public async Task<HttpStatusCode> PutPackage(Package package)
        {
                HttpResponseMessage response = await PackageService.packageClient.PutAsJsonAsync("https://localhost:7278/api/Packages", package);
                response.EnsureSuccessStatusCode();
                return response.StatusCode;      
        }
        public async Task<HttpStatusCode> DeletePackage(int id)
        {
            try
            {
                HttpResponseMessage response = await PackageService.packageClient.DeleteAsync("https://localhost:7278/api/Packages/" + id);
                response.EnsureSuccessStatusCode();
                string package = await response.Content.ReadAsStringAsync();
                return HttpStatusCode.NoContent;
            }
            catch (HttpRequestException)
            {
                return HttpStatusCode.BadRequest;
            }
        }
        
    }
}
