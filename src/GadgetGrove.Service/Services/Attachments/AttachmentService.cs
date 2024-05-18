using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Entities.Attechments;
using GadgetGrove.Service.DTOs.Attachments;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Interfaces.Attechments;
using GadgetGrove.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Service.Services.Attachments;

public class AttachmentService : IAttechmentService
{
    private readonly IRepository<Attachment> attachmentRepository;
    public AttachmentService(IRepository<Attachment> attachmentRepository)
    {
        this.attachmentRepository = attachmentRepository;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await attachmentRepository.SelectAll()
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if(entity is null)
            throw new GadgetGroveException(404, "Attachment not found");

        await attachmentRepository.DeleteAsync(id);

        return true;
    }

    public async Task<Attachment> UploadAsync(AttachmentForCreationDto dto)
    {
        // combining paths and create if not exists
        string path = Path.Combine(EnvironmentContextHelper.WebRootPath, "Files");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string fileName = $"{Guid.NewGuid()}{dto.FileExtension}";
        string fullPath = Path.Combine(path, fileName);

        // creating file in created or existed folder and write all content
        FileStream targetFile = new FileStream(fullPath, FileMode.OpenOrCreate);
        await targetFile.WriteAsync(dto.File);

        Attachment attachment = new Attachment
        {
            FileName = fileName,
            FilePath = fullPath,
            CreatedAt = DateTime.UtcNow,
        };
        var insertedFile = await this.attachmentRepository.InsertAsync(attachment);

        return insertedFile;
    }
}