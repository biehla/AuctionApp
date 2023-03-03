namespace Auction.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public float? Price { get; set; }
    }
}
