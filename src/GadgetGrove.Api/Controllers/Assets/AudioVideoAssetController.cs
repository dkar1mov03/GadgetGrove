using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.Interfaces.AudioVideoBoxAssets;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GadgetGrove.Api.Controllers.Assets;

public class AudioVideoAssetController : BaseController
{
    private readonly IAudioVideoBoxAssetService _audioVideoBoxAssetService;

    public AudioVideoAssetController(IAudioVideoBoxAssetService audioVideoBoxAssetService)
    {
        _audioVideoBoxAssetService = audioVideoBoxAssetService;
    }

    [HttpPost("{audio-id}")]
    public async Task<IActionResult> PostAsync([FromRoute(Name = "audio-id")] long audioid, [Required] IFormFile file)
        => Ok(await _audioVideoBoxAssetService.AddAsync(audioid, file));


    [HttpGet("{audio-id}")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute(Name = "audio-id")] long audioid)
    => Ok(await _audioVideoBoxAssetService.RetrieveAllAsync(audioid, @params));


    [HttpGet("{audio-id}/{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "audio-id")] long audioid, [FromRoute(Name = "id")] long id)
    => Ok(await _audioVideoBoxAssetService.RetrieveByIdAsync(audioid, id));


    [HttpDelete("{audio-id}/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "audio-id")] long audioid, [FromRoute(Name = "id")] long id)
        => Ok(await _audioVideoBoxAssetService.RemoveAsync(audioid, id));
}
