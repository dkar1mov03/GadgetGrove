using GadgetGrove.Domain.Configurations;
using GadgetGrove.Service.DTOs.AudioVideoBoxes;

namespace GadgetGrove.Service.Interfaces.AudioVideoBoxes;

public interface IAudioVideoBoxService
{
    Task<bool> RemoveAsync(long id);
    Task<AudioVideoBoxForResultDto> RetrieveByIdAsync(long id);
    Task<AudioVideoBoxForResultDto> AddAsync(AudioVideoBoxForCreationDto dto);
    Task<AudioVideoBoxForResultDto> ModifyAsync(long id, AudioVideoBoxForUpdateDto dto);
    Task<IEnumerable<AudioVideoBoxForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
