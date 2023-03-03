namespace Auction.Models
{
    public class AuctionItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Tag>? Tags { get; set; }
        public IEnumerable<Bid>? Bids { get; set; }
    }
}
