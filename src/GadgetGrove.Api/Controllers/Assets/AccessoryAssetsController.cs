using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.Interfaces.AccessoryAssets;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GadgetGrove.Api.Controllers.Assets;

public class AccessoryAssetsController : BaseController
{
    private readonly IAccessoryAssetService _accessoryAssetService;

    public AccessoryAssetsController(IAccessoryAssetService accessoryAssetService)
    {
        _accessoryAssetService = accessoryAssetService;
    }

    [HttpPost("{accessory-id}")]
    public async Task<IActionResult> PostAsync([FromRoute(Name = "accessory-id")] long accessoryid, [Required] IFormFile file)
        => Ok(await _accessoryAssetService.AddAsync(accessoryid, file));


    [HttpGet("{accessory-id}")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute(Name = "accessory-id")] long accessoryid)
    => Ok(await _accessoryAssetService.RetrieveAllAsync(accessoryid, @params));


    [HttpGet("{accessory-id}/{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "Accessory-id")] long AccessoryId, [FromRoute(Name = "id")] long id)
    => Ok(await _accessoryAssetService.RetrieveByIdASync(AccessoryId, id));


    [HttpDelete("{accessory-id}/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "accessory-id")] long AccessoryId, [FromRoute(Name = "id")] long id)
        => Ok(await _accessoryAssetService.RemoveAsync(AccessoryId, id));
}
