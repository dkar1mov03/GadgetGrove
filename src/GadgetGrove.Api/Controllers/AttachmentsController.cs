using GadgetGrove.Service.DTOs.Attachments;
using GadgetGrove.Service.DTOs.Users;
using GadgetGrove.Service.Interfaces.Attechments;
using Microsoft.AspNetCore.Mvc;

namespace GadgetGrove.Api.Controllers;

public class AttachmentsController : BaseController
{
    private readonly IAttechmentService _attechmentsService;

    public AttachmentsController(IAttechmentService attechmentsService)
    {
        _attechmentsService = attechmentsService;
    }

    /// <summary>
    /// Handles HTTP POST requests to insert a new user into the database.
    /// </summary>
    /// <param name="dto">Data for creating the new user.</param>
    /// <returns>Returns an IActionResult with the result of the insertion operation.</returns>
    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromForm] AttachmentForCreationDto dto)
        => Ok(await _attechmentsService.UploadAsync(dto));

    /// <summary>
    /// Handles HTTP DELETE requests to remove a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be removed.</param>
    /// <returns>Returns an IActionResult with the result of the removal operation.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        => Ok(await _attechmentsService.DeleteAsync(id));
}
