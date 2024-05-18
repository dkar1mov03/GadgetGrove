using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.Interfaces.DeviceAssets;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GadgetGrove.Api.Controllers.Assets;

public class DeviceAssetController : BaseController
{
    private readonly IDeviceAssetService _deviceAssetService;

    public DeviceAssetController(IDeviceAssetService deviceAssetService)
    {
        _deviceAssetService = deviceAssetService;
    }

    [HttpPost("{device-id}")]
    public async Task<IActionResult> PostAsync([FromRoute(Name = "device-id")] long deviceid, [Required] IFormFile file)
        => Ok(await _deviceAssetService.AddAsync(deviceid, file));


    [HttpGet("{device-id}")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute(Name = "device-id")] long deviceid)
    => Ok(await _deviceAssetService.RetrieveAllAsync(deviceid, @params));


    [HttpGet("{device-id}/{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "device-id")] long deviceid, [FromRoute(Name = "id")] long id)
    => Ok(await _deviceAssetService.RetrieveByIdAsync(deviceid, id));


    [HttpDelete("{device-id}/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "accessory-id")] long deviceid, [FromRoute(Name = "id")] long id)
        => Ok(await _deviceAssetService.RemoveAsync(deviceid, id));
}
