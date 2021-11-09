namespace Starter.API.Models
{
    public class PayStatement
    {
        public long Id { get; set; }

        public DateTime PayDate { get; set; }

        public decimal Amount { get; set; }
    }
}
