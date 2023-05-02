namespace AndreTurApp.Models
{
    public class Ticket
    {
        #region[Properties]
        public int Id { get; set; }
        public Address Home { get; set; }
        public Address Destiny { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        #endregion
    }
}
