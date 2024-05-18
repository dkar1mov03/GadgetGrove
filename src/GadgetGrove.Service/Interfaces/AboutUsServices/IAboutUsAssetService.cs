using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.AboutUsAssets;

namespace GadgetGrove.Service.Interfaces.AboutUsAssets;

public interface IAboutUsAssetService
{
    Task<bool> RemoveAsync(long id);
    Task<AboutUsAssetForResultDto> RetrieveByIdAsync(long id);
    Task<AboutUsAssetForResultDto> AddAsync(AboutUsAssetForCreationDto dto);
    Task<AboutUsAssetForResultDto> ModifyAsync(long id, AboutUsAssetForUpdateDto dto);
    Task<IEnumerable<AboutUsAssetForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
