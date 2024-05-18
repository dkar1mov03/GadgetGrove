using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Enums.PaymentStatuses;
using GadgetGrove.Service.DTOs.Payments;
using GadgetGrove.Service.Interfaces.Payments;
using Microsoft.AspNetCore.Mvc;

namespace GadgetGrove.Api.Controllers.Payments;

public class PaymentsController : BaseController
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    /// <summary>
    /// Handles HTTP POST requests to insert a new user into the database.
    /// </summary>
    /// <param name="dto">Data for creating the new user.</param>
    /// <returns>Returns an IActionResult with the result of the insertion operation.</returns>
    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromForm] PaymentForCreationDto dto)
        => Ok(await _paymentService.AddAsync(dto));


    /// <summary>
    /// Handles HTTP GET requests to retrieve all users with optional pagination parameters.
    /// </summary>
    /// <param name="@params">Optional pagination parameters for controlling the result set.</param>
    /// <returns>Returns an IActionResult with the result of the retrieval operation.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _paymentService.RetrieveAllAsync(@params));


    /// <summary>
    /// Handles HTTP GET requests to retrieve a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be retrieved.</param>
    /// <returns>Returns an IActionResult with the result of the retrieval operation.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        => Ok(await _paymentService.RetrieveByIdAsync(id));


    /// <summary>
    /// Handles HTTP DELETE requests to remove a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be removed.</param>
    /// <returns>Returns an IActionResult with the result of the removal operation.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        => Ok(await _paymentService.RemoveAsync(id));


    /// <summary>
    /// Handles HTTP PUT requests to update an existing user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be updated.</param>
    /// <param name="dto">Data for updating the existing user.</param>
    /// <returns>Returns an IActionResult with the result of the update operation.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] PaymentForUpdateDto dto)
        => Ok(await _paymentService.ModifyAsync(id, dto));
    /// <summary>
    /// Handles HTTP PUT requests to change the status of an payment by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the payment to have its status changed.</param>
    /// <param name="status">The new status to be set for the payment.</param>
    /// <returns>Returns an IActionResult with the result of the status change operation.</returns>
    [HttpPost("{id}")]
    public async Task<IActionResult> ChangeStatus([FromRoute] long id, [FromQuery] PaymentStatus status)
        => Ok(await _paymentService.ChangeStatusAsync(id, status));
}
