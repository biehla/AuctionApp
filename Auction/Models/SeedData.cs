using Auction.Data;
using Microsoft.EntityFrameworkCore;

namespace Auction.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.AuctionItem.Any()) 
                {
                    return;   // DB has been seeded
                }


                var pcList = new List<Tag>
                {
                    new Tag { TagName = "Laptop" },
                    new Tag { TagName = "PC" }
                };

                var mugList = new List<Tag>
                {
                    new Tag { TagName = "coffee" },
                    new Tag { TagName = "tea" },
                    new Tag { TagName = "mug" }
                };

                context.AuctionItem.AddRange(
                    new AuctionItem
                    {
                        Title = "Laptop PC",
                        Description = "This is a really good laptop",
                        Tags = pcList
                    },
                    new AuctionItem
                    {
                        Title = "Mug",
                        Description = "This is a coffee mug with a handle",
                        Tags = pcList
                    }
                );

                context.SaveChanges();
            }
        }
    }
}