using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.Assets;
using GadgetGrove.Domain.Entities.VideoAudioBoxs;
using GadgetGrove.Service.DTOs.AudioVideoAssets;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.AudioVideoBoxAssets;
using GadgetGrove.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal;
using System.Threading.Channels;

namespace GadgetGrove.Service.Services.AudioVideoBoxAssets;

public class AudioVideoBoxAssetService : IAudioVideoBoxAssetService
{
    private readonly IMapper _mapper;
    private readonly IRepository<VideoAudiBox> _videoRepository;
    private readonly IRepository<AudioVideoBoxAsset> _videoAudioRepository;  

    public AudioVideoBoxAssetService(IMapper mapper, 
        IRepository<VideoAudiBox> videoRepository, 
        IRepository<AudioVideoBoxAsset> videoAudioRepository)
    {
        _mapper = mapper;
        _videoRepository = videoRepository;
        _videoAudioRepository = videoAudioRepository;
    }

    public async Task<AudioVideoBoxAssetForResultDto> AddAsync(long AudioId, IFormFile file)
    {
        var video = await _videoRepository.SelectAll()
            .Where(v => v.Id == AudioId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (video is null)
            throw new GadgetGroveException(404, "VideoAudio is not found");

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
        var rootPath = Path.Combine(EnvironmentContextHelper.WebRootPath, "Media", "Audios", "Images", fileName);

        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new AudioVideoBoxAsset()
        {
            VideoAudioId = AudioId,
            Name = file.Name,
            Size = file.Length,
            Type = file.ContentType,
            CreatedAt = DateTime.UtcNow,
            Extension = Path.GetExtension(file.FileName),
            Path = Path.Combine("Media", "Audios", "Images", file.FileName)
        };

        var result = await _videoAudioRepository.InsertAsync(mappedAsset);

        return _mapper.Map<AudioVideoBoxAssetForResultDto>(result);



    }

    public async Task<bool> RemoveAsync(long AudioId, long id)
    {
        var video = await _videoRepository.SelectAll()
            .Where(v => v.Id == AudioId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (video is null)
            throw new GadgetGroveException(404, "VideoAudio is not found");
        var asset = await _videoAudioRepository.SelectAll()
            .Where (v => v.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (asset is null)
            throw new GadgetGroveException(404, "Asset is not found");

        return await _videoAudioRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<AudioVideoBoxAssetForResultDto>> RetrieveAllAsync(long AudioId, PaginationParams @params)
    {
        var video = await _videoRepository.SelectAll()
            .Where(v => v.Id == AudioId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (video is null)
            throw new GadgetGroveException(404, "VideoAudio is not found");
        var asset = await _videoAudioRepository.SelectAll()
            .Include(v => v.VideoAudiBox)
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<AudioVideoBoxAssetForResultDto>>(asset);
    }

    public async Task<AudioVideoBoxAssetForResultDto> RetrieveByIdAsync(long AudioId, long id)
    {
        var video = await _videoRepository.SelectAll()
            .Where(v => v.Id == AudioId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (video is null)
            throw new GadgetGroveException(404, "VideoAudio is not found");
        var asset = await _videoAudioRepository.SelectAll()
            .Where(v => v.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (asset is null)
            throw new GadgetGroveException(404, "Asset is not found");

        return _mapper.Map<AudioVideoBoxAssetForResultDto>(asset);
    }
}
