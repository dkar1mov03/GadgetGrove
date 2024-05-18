using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.OrderActions;
using GadgetGrove.Service.Interfaces.Orders;
using Microsoft.AspNetCore.Mvc;

namespace GadgetGrove.Api.Controllers.Orders;

public class OrderActionsController : BaseController
{
    private readonly IOrderActionService _orderActionService;

    public OrderActionsController(IOrderActionService orderActionService)
    {
        _orderActionService = orderActionService;
    }
    /// <summary>
    /// Handles HTTP POST requests to insert a new user into the database.
    /// </summary>
    /// <param name="dto">Data for creating the new user.</param>
    /// <returns>Returns an IActionResult with the result of the insertion operation.</returns>
    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromForm] OrderActionForCreationDto dto)
        => Ok(await _orderActionService.AddAsync(dto));


    /// <summary>
    /// Handles HTTP GET requests to retrieve all users with optional pagination parameters.
    /// </summary>
    /// <param name="@params">Optional pagination parameters for controlling the result set.</param>
    /// <returns>Returns an IActionResult with the result of the retrieval operation.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _orderActionService.RetrieveAllAsync(@params));


    /// <summary>
    /// Handles HTTP GET requests to retrieve a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be retrieved.</param>
    /// <returns>Returns an IActionResult with the result of the retrieval operation.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        => Ok(await _orderActionService.RetrieveByIdAsync(id));


    /// <summary>
    /// Handles HTTP DELETE requests to remove a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be removed.</param>
    /// <returns>Returns an IActionResult with the result of the removal operation.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        => Ok(await _orderActionService.RemoveAsync(id));


    /// <summary>
    /// Handles HTTP PUT requests to update an existing user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be updated.</param>
    /// <param name="dto">Data for updating the existing user.</param>
    /// <returns>Returns an IActionResult with the result of the update operation.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] OrderActionForUpdateDto dto)
        => Ok(await  _orderActionService.ModifyAsync(id, dto));
}
