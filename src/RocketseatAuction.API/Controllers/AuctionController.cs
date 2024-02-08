using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Controllers;

public class AuctionController : RocketseatAuctionControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction([FromServices] IGetCurrentAuctionsUseCase useCase)
    {
        var result = useCase.Execute();

        if (result is null)
            return NoContent();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateAuction()
    {
        return Created();
    }

    [HttpPut]
    public IActionResult UpdateAuction() 
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteAuction()
    {
        return Ok();
    }
}
