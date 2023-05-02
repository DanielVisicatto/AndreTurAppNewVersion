using AndreTurApp.Models;
using Newtonsoft.Json;
using System.Net;

namespace AndreTurAppNewVersion.Services
{
    public class TicketService
    {
        static readonly HttpClient ticketClient = new();

        public async Task<List<Ticket>> GetTicket()
        {
            try
            {
                HttpResponseMessage response = await TicketService.ticketClient.GetAsync("https://localhost:7027/api/Tickets");
                response.EnsureSuccessStatusCode();
                string ticket = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Ticket>>(ticket);
            }
            catch (HttpRequestException e)
            {
                throw new(e.Message);
            }
        }
        public async Task<Ticket> GetTicketById(int id)
        {
            try
            {
                HttpResponseMessage response = await TicketService.ticketClient.GetAsync("https://localhost:7027/api/Tickets/" + id);
                response.EnsureSuccessStatusCode();
                string ticket = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Ticket>(ticket);
            }
            catch (HttpRequestException e)
            {
                throw new(e.Message);
            }
        }
        public async Task<HttpStatusCode> PostTicket(Ticket ticket)
        {

            HttpResponseMessage response = await TicketService.ticketClient.PostAsJsonAsync("https://localhost:7027/api/Tickets", ticket);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
        public async Task<HttpStatusCode> PutTiclet(Ticket ticket)
        {
            HttpResponseMessage response = await TicketService.ticketClient.PutAsJsonAsync("https://localhost:7027/api/Tickets", ticket);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
        public async Task<HttpStatusCode> DeleteTicket(int id)
        {
            try
            {
                HttpResponseMessage response = await TicketService.ticketClient.DeleteAsync("https://localhost:7027/api/Tickets/" + id);
                response.EnsureSuccessStatusCode();
                string ticket = await response.Content.ReadAsStringAsync();
                return HttpStatusCode.NoContent;
            }
            catch (HttpRequestException)
            {
                return HttpStatusCode.BadRequest;
            }

        }
    }
}
