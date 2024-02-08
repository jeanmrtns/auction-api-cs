using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contracts;

public interface IGetCurrentAuctionsUseCase
{
    Auction? Execute();
}
