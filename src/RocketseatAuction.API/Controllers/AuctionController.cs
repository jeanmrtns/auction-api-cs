using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

namespace RocketseatAuction.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction()
    {
        var useCase = new GetCurrentAuctionsUseCase();
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
