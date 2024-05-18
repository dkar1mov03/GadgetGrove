using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.Interfaces.ApplianceAssets;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GadgetGrove.Api.Controllers.Assets;

public class ApplianceAssetController : BaseController
{
    private readonly IApplianceAssetService _applianceAssetService;

    public ApplianceAssetController(IApplianceAssetService applianceAssetService)
    {
        _applianceAssetService = applianceAssetService;
    }

    [HttpPost("{appliance-id}")]
    public async Task<IActionResult> PostAsync([FromRoute(Name = "appliance-id")] long applianceId, [Required] IFormFile file)
        => Ok(await _applianceAssetService.AddAsync(applianceId, file));


    [HttpGet("{appliance-id}")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromRoute(Name = "Appliance-id")] long ApplianceId)
    => Ok(await _applianceAssetService.RetrieveAllAsync(ApplianceId, @params));


    [HttpGet("{appliance-id}/{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "Appliance-id")] long ApplianceId, [FromRoute(Name = "id")] long id)
    => Ok(await _applianceAssetService.RetrieveByIdAsync(ApplianceId, id));


    [HttpDelete("{appliance-id}/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "Appliance-id")] long ApplianceId, [FromRoute(Name = "id")] long id)
        => Ok(await _applianceAssetService.RemoveAsync(ApplianceId, id));
}
