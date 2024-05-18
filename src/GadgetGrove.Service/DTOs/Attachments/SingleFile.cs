using Microsoft.AspNetCore.Http;

namespace GadgetGrove.Service.DTOs.Attachments;

public class SingleFile
{
    public IFormFile File { get; set; }
}
