using GadgetGrove.Domain.Entities.Attechments;
using GadgetGrove.Service.DTOs.Attachments;

namespace GadgetGrove.Service.Interfaces.Attechments;

public interface IAttechmentService
{
    Task<Attachment> UploadAsync(AttachmentForCreationDto dto);
    Task<bool> DeleteAsync(long id);
}
