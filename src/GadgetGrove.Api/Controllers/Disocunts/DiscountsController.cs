using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.Devices;
using GadgetGrove.Service.DTOs.Discounts;
using GadgetGrove.Service.Interfaces.Discounts;
using Microsoft.AspNetCore.Mvc;

namespace GadgetGrove.Api.Controllers.Disocunts;

public class DiscountsController : BaseController
{
    private readonly IDiscountService _discountsService;

    public DiscountsController(IDiscountService discountsService)
    {
        _discountsService = discountsService;
    }

    /// <summary>
    /// Handles HTTP POST requests to insert a new user into the database.
    /// </summary>
    /// <param name="dto">Data for creating the new user.</param>
    /// <returns>Returns an IActionResult with the result of the insertion operation.</returns>
    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromForm] DiscountForCreationDto dto)
        => Ok(await _discountsService.AddAsync(dto));

    /// <summary>
    /// Handles HTTP GET requests to retrieve all users with optional pagination parameters.
    /// </summary>
    /// <returns>Returns an IActionResult with the result of the retrieval operation.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _discountsService.RetrieveAllAsync(@params));

    /// <summary>
    /// Handles HTTP GET requests to retrieve a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be retrieved.</param>
    /// <returns>Returns an IActionResult with the result of the retrieval operation.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        => Ok(await _discountsService.RetrieveByIdAsnyc(id));

    /// <summary>
    /// Handles HTTP PUT requests to update an existing user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be updated.</param>
    /// <param name="dto">Data for updating the existing user.</param>
    /// <returns>Returns an IActionResult with the result of the update operation.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] DiscountForUpdateDto dto)
        => Ok(await _discountsService.ModifyAsync(id, dto));
}
