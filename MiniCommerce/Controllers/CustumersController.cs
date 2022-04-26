using System;
using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniCommerce.Models;
using MiniCommerce.Service.Commands;
using MiniCommerce.Service.Handlers.Response;
using MiniCommerce.Service.Queries;

namespace MiniCommerce.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Consumes(MediaTypeNames.Application.Json)]
  [Produces(MediaTypeNames.Application.Json)]
  public class CustumersController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ILogger<CustumersController> _logger;

    public CustumersController(IMediator mediator, ILogger<CustumersController> logger)
    {
      _mediator = mediator;
      _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CustumerResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<CustumerResponse>> CreateCustumer(CreateCustumerDto custumerDto)
    {

      var result = await _mediator.Send(new CreateCustumerCommand(custumerDto));
      if (result == null) { return BadRequest(); }
      return CreatedAtAction("GetCustumerById", new { id = result.Id }, result);

    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(CustumerResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<CustumerResponse>> UpdateCustumer(int id, UpdateCustumerDto custumerDto)
    {

      var result = await _mediator.Send(new UpdateCustumerByIdCommand(id, custumerDto));
      if (result == null) { return BadRequest(); }
      return Ok(result);

    }

    [HttpGet]
    public async Task<ActionResult<List<DetailCustumerDto>>> GetCustumers()
    {
      var result = await _mediator.Send(new GetCustumersQuery());
      return Ok(result);
    }

    [HttpGet("id")]
    public async Task<ActionResult<DetailCustumerDto>> GetCustumerById(int id)
    {
      var custumer = await _mediator.Send(new GetCustumerByIdQuery(id));
      if (custumer == null) { return NotFound(); }
      return Ok(custumer);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(CustumerResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(CustumerResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCustumer(int id)
    {
      var command = new DeleteCustumerByIdCommand(id);
      var result = await _mediator.Send(command);
      if (!result) { return NotFound(); }
      return NoContent();
    }
  }

}