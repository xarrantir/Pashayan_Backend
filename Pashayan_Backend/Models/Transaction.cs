namespace Pashayan_Backend.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public int CarId { get; set; }

        public int Cost { get; set; }

        public String PayMethod { get; set; }

    }
}
