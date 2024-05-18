using AutoMapper;
using GadgetGrove.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using GadgetGrove.Service.Exceptions;
using GadgetGrove.Service.DTOs.Users;
using GadgetGrove.Data.IRepositories;
using GadgetGrove.Service.DTOs.OTP.Sms;
using GadgetGrove.Domain.Entities.Users;
using GadgetGrove.Service.Interfaces.OTP;
using Microsoft.Extensions.Caching.Memory;
using GadgetGrove.Service.Interfaces.Users;
using GadgetGrove.Service.DTOs.Registrations;
using GadgetGrove.Service.Interfaces.Registrations;
using GadgetGrove.Service.DTOs.Registrations.UserRegistrations;

namespace GadgetGrove.Service.Services.Registrations;

public class UserRegistrationService : IUserRegistrationService
{
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;
    private readonly ISmsService _smsService;
    private readonly IUserService _userService;
    private readonly IRepository<User> _userRepository;


    public UserRegistrationService(IRepository<User> userRepository, 
        IMapper mapper, IMemoryCache cache,
        ISmsService smsService, IUserService userService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _cache = cache;
        _smsService = smsService;
        _userService = userService;
    }

    public async Task<UserRegistrationForResultDto> AddAsync(UserRegistrationForCreationDto dto)
    {
        var CheckUser = await this._userRepository.SelectAll()
            .Where(e => e.PhoneNumber == dto.PhoneNumber|| 
            e.Email == dto.Email && e.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (CheckUser != null)
        {
            throw new GadgetGroveException(400, "This User is exist");
        }

        if (dto.VerificationCode == null)
        {
            throw new GadgetGroveException(400, "Invalid Verifaction code");
        }
        if (CheckUser == null)
        {
            var PhoneVerification = new CodeVerification()
            {
                PhoneNumber = dto.PhoneNumber,
                VerificationCode = dto.VerificationCode,
            };

            var IsVerified = await VerifyCodeAsync(PhoneVerification);
            if (IsVerified == true)
            {
                _cache.Remove($"{dto.PhoneNumber}_VerificationCode");
                var HashedPassword = PasswordHelper.Hash(dto.Password);
                var NewUser = this._mapper.Map<UserForCreationDto>(dto);
                var Result = await this._userService.AddAsync(NewUser);
                return this._mapper.Map<UserRegistrationForResultDto>(Result);
            }
            else
            {
                throw new GadgetGroveException(400, "Verification code is not verified");
            }

        }

        throw new GadgetGroveException(400, "This User is Exist");
    }

    public async Task<string> SendVerificationCodeAsync(SendVerification dto)
    {
        var existingUser = await this._userRepository
                        .SelectAll()
                        .Where(e => e.PhoneNumber == dto.PhoneNumber && e.IsDeleted == false)
                        .FirstOrDefaultAsync();

        if (existingUser == null)
        {
            var verificationCode = GenerateCodeForPhoneNumberVerificationAsync();
            var cacheKey = $"{dto.PhoneNumber}_VerificationCode";
            var cacheExpiration = TimeSpan.FromSeconds(30000); // Set expiration time to 2 minutes

            try
            {
                // Store the verification code in the cache with a 2-minute expiration
                _cache.Set(cacheKey, verificationCode, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = cacheExpiration
                });

                // Send the verification code to the user via email
                var message = new Message()
                {
                    PhoneNumber = dto.PhoneNumber,
                    MessageContent = $"GadgetGrove tasdiqlash kodingiz: {verificationCode}"
                };

                await _smsService.SendAsync(message);

                return verificationCode;
            }
            catch (Exception ex)
            {
                // Handle exceptions related to cache or email sending
                // Log the exception or provide a more meaningful error message
                throw new GadgetGroveException(500, "Error occurred while sending verification code.");
            }
        }
        else
        {
            throw new GadgetGroveException(400, "This user already exists.");
        }
    }
    public async Task<bool> VerifyCodeAsync(CodeVerification dto)
    {
        var storedCode = _cache.Get<string>($"{dto.PhoneNumber}_VerificationCode");

        if (storedCode != null && storedCode == dto.VerificationCode)
        {
            return true;
        }

        return false;
    }

    private string GenerateCodeForPhoneNumberVerificationAsync()
    {
        string code = Guid.NewGuid().ToString("N").Substring(0, 6);
        return code;
    }
}

