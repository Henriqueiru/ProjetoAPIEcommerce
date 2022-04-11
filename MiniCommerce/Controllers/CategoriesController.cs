using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCommerce.Models;
using MiniCommerce.Service.Commands;

namespace MiniCommerce.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ILogger<CategoriesController> _logger;
    public CategoriesController(IMediator mediator, ILogger<CategoriesController> logger)
    {
      _mediator = mediator;
      _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<DetailCategoryDto>> CreateCategory(CreateCategoryDto categoryDto)
    {
      try
      {
        var result = await _mediator.Send(new CreateCategoryCommand(categoryDto));
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
