using GadgetGrove.Service.DTOs.AboutUs;

namespace GadgetGrove.Service.Interfaces.AboutUsServices;

public interface IAboutUsService
{
    Task<bool> RemoveAsync(long id);
    Task<AboutUsForResultDto> GetByIdAsync(long id);
    Task<AboutUsForResultDto> AddAsync(AboutUsForCreationDto dto);
    Task<IEnumerable<AboutUsForResultDto>> RetrieveAllAsync();
    Task<AboutUsForResultDto> ModifyAsync(long id, AboutUsForUpdateDto dto);
}
