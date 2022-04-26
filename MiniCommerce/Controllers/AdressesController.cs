using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniCommerce.Models;
using MiniCommerce.Service.Commands;

namespace MiniCommerce.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AddressesController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ILogger<AddressesController> _logger;
    public AddressesController(IMediator mediator, ILogger<AddressesController> logger)
    {
      _mediator = mediator;
      _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<DetailAddressDto>> CreateAddress(CreateAddressDto addressDto)
    {
      try
      {
        var result = await _mediator.Send(new CreateAddressCommand(addressDto));
        if (result == null) { return BadRequest(); }
        return Ok(result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.ToString());
        return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
      }
    }
  }
}