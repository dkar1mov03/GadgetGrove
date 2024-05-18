using AutoMapper;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Domain.Configurations;
using GadgetGrove.Domain.Entities.VideoAudioBoxs;
using GadgetGrove.Service.DTOs.AudioVideoBoxes;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.Extensions;
using GadgetGrove.Service.Interfaces.AudioVideoBoxes;
using GadgetGrove.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace GadgetGrove.Service.Services.AudioVideoBoxes;

public class AudioVideoBoxService : IAudioVideoBoxService
{
    private readonly IMapper _mapper;
    private readonly IRepository<VideoAudiBox> _repository;

    public AudioVideoBoxService(IMapper mapper, 
        IRepository<VideoAudiBox> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<AudioVideoBoxForResultDto> AddAsync(AudioVideoBoxForCreationDto dto)
    {
        var video = await _repository.SelectAll()
            .Where(v => v.Price == dto.Price)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (video is not null)
            throw new GadgetGroveException(409, "VideoAudio is already exists ");

        var mappedUserDetail = _mapper.Map<VideoAudiBox>(dto);
        mappedUserDetail.CreatedAt = DateTime.UtcNow;

        var result = await _repository.InsertAsync(mappedUserDetail);

        return this._mapper.Map<AudioVideoBoxForResultDto>(result);
    }

    public async Task<AudioVideoBoxForResultDto> ModifyAsync(long id, AudioVideoBoxForUpdateDto dto)
    {
        var video = await _repository.SelectAll()
            .Where(v => v.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (video is null)
            throw new GadgetGroveException(404, "Audio is not found");

        var mappedUserDetail = this._mapper.Map(dto, video);
        mappedUserDetail.UpdatedAt = DateTime.UtcNow;

        await this._repository.UpdateAsync(mappedUserDetail);

        return this._mapper.Map<AudioVideoBoxForResultDto>(mappedUserDetail);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var video = await _repository.SelectAll()
            .Where(v => v.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (video is null)
            throw new GadgetGroveException(404, "Video is not found");

        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<AudioVideoBoxForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var video = await _repository.SelectAll()
                .AsNoTracking()
                .ToPagedList(@params)
                .ToListAsync();

        return _mapper.Map<IEnumerable<AudioVideoBoxForResultDto>>(video);
    }

    public async Task<AudioVideoBoxForResultDto> RetrieveByIdAsync(long id)
    {
        var video = await _repository.SelectAll()
                .Where(c => c.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (video is null)
            throw new GadgetGroveException(404, "Video is not found");

        return this._mapper.Map<AudioVideoBoxForResultDto>(video);
    }
}
