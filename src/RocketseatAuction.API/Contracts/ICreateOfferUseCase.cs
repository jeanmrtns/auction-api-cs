using RocketseatAuction.API.Communication.Requests;

namespace RocketseatAuction.API.Contracts;

public interface ICreateOfferUseCase
{
    int Execute(int ItemId, RequestCreateOfferJson request);
}
