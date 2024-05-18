using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.Discounts;
using GadgetGrove.Service.DTOs.ProductMalls;
using GadgetGrove.Service.Interfaces.ProductMalls;
using Microsoft.AspNetCore.Mvc;

namespace GadgetGrove.Api.Controllers.ProductMalls;

public class ProductMallsController : BaseController
{
    private readonly IProductMallService _productMallService;

    public ProductMallsController(IProductMallService productMallService)
    {
        _productMallService = productMallService;
    }

    /// <summary>
    /// Handles HTTP POST requests to insert a new user into the database.
    /// </summary>
    /// <param name="dto">Data for creating the new user.</param>
    /// <returns>Returns an IActionResult with the result of the insertion operation.</returns>
    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromForm] ProductMallForCreationDto dto)
        => Ok(await _productMallService.AddAsync(dto));

    /// <summary>
    /// Handles HTTP GET requests to retrieve all users with optional pagination parameters.
    /// </summary>
    /// <returns>Returns an IActionResult with the result of the retrieval operation.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _productMallService.RetrieveAllAsync(@params));

    /// <summary>
    /// Handles HTTP GET requests to retrieve a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be retrieved.</param>
    /// <returns>Returns an IActionResult with the result of the retrieval operation.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        => Ok(await _productMallService.RetrieveByIdAsync(id));
    /// <summary>
    /// Handles HTTP DELETE requests to remove a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be removed.</param>
    /// <returns>Returns an IActionResult with the result of the removal operation.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        => Ok(await _productMallService.RemoveAsync(id));
    /// <summary>
    /// Handles HTTP PUT requests to update an existing user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be updated.</param>
    /// <param name="dto">Data for updating the existing user.</param>
    /// <returns>Returns an IActionResult with the result of the update operation.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] ProductMallForUpdateDto dto)
        => Ok(await _productMallService.ModifyAsync(id, dto));
}
