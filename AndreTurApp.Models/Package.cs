namespace AndreTurApp.Models
{
    public class Package
    {
        #region[Properties]
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime RegisterDate { get; set; }
        public float Price { get; set; }
        public Customer Customer { get; set; }
        #endregion
    }
}
