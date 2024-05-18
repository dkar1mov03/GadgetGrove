namespace GadgetGrove.Service.DTOs.Attachments;

public class AttachmentForCreationDto
{
    public byte[] File { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
}
