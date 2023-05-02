using AndreTurApp.Models;
using Newtonsoft.Json;
using System.Net;

namespace AndreTurAppNewVersion.Services
{
    public class HotelService
    {
        static readonly HttpClient hotelClient = new();
        public async Task<List<Hotel>> GetHotel()
        {
            try
            {
                HttpResponseMessage response = await HotelService.hotelClient.GetAsync("https://localhost:7088/api/Hotels");
                response.EnsureSuccessStatusCode();
                string hotel = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Hotel>>(hotel);
            }
            catch (HttpRequestException e)
            {
                throw new(e.Message);
            }
        }
        public async Task<Hotel> GetHotel(int id)
        {
            try
            {
                HttpResponseMessage response = await HotelService.hotelClient.GetAsync("https://localhost:7088/api/Hotels/" + id);
                response.EnsureSuccessStatusCode();
                string hotel = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Hotel>(hotel);
            }
            catch (HttpRequestException e)
            {
                throw new(e.Message);
            }
        }
        public async Task<HttpStatusCode> PostHotel(Hotel hotel)
        {
            HttpResponseMessage response = await HotelService.hotelClient.PostAsJsonAsync("https://localhost:7088/api/Hotels", hotel);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;

        }
        public async Task<HttpStatusCode> PutHotel(Hotel hotel)
        {
            HttpResponseMessage response = await HotelService.hotelClient.PutAsJsonAsync("https://localhost:7088/api/Hotels", hotel);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;

        }
        public async Task<HttpStatusCode> DeleteHotel(int id)
        {
            try
            {
                HttpResponseMessage response = await HotelService.hotelClient.DeleteAsync("https://localhost:7088/api/Hotels/" + id);
                response.EnsureSuccessStatusCode();
                string hotel = await response.Content.ReadAsStringAsync();
                return HttpStatusCode.NoContent;
            }
            catch (HttpRequestException)
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}
