using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : RocketseatAuctionControllerBase
{
    [HttpPost]
    [Route("{itemId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreateOfferJson request, [FromServices] CreateOfferUseCase useCase)
    {
        var offerId = useCase.Execute(itemId, request);
        return Created(string.Empty, offerId);
    }
}
