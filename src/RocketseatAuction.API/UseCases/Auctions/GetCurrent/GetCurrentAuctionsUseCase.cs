using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionsUseCase
{
    public Auction? Execute()
    {
        var repository = new RocketseatAuctionDbContext();
        var today = DateTime.UtcNow;

        return repository
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => auction.Ends >= today && auction.Starts <= today);
    }
}
