using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.AudioVideoAssets;
using Microsoft.AspNetCore.Http;

namespace GadgetGrove.Service.Interfaces.AudioVideoBoxAssets;

public interface IAudioVideoBoxAssetService
{
    public Task<bool> RemoveAsync(long AudioId, long id);
    public Task<AudioVideoBoxAssetForResultDto> AddAsync(long AudioId, IFormFile file);
    public Task<AudioVideoBoxAssetForResultDto> RetrieveByIdAsync(long AudioId, long id);
    public Task<IEnumerable<AudioVideoBoxAssetForResultDto>> RetrieveAllAsync(long AudioId, PaginationParams @params);
}
