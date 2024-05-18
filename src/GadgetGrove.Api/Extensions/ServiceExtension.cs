using GadgetGrove.Data.IRepositories;
using GadgetGrove.Data.Repositories;
using GadgetGrove.Domain.Entities.Assets;
using GadgetGrove.Domain.Entities.VideoAudioBoxs;
using GadgetGrove.Service.Interfaces.AboutUsAssets;
using GadgetGrove.Service.Interfaces.AboutUsServices;
using GadgetGrove.Service.Interfaces.Accessories;
using GadgetGrove.Service.Interfaces.AccessoryAssets;
using GadgetGrove.Service.Interfaces.Addresses;
using GadgetGrove.Service.Interfaces.ApplianceAssets;
using GadgetGrove.Service.Interfaces.Appliances;
using GadgetGrove.Service.Interfaces.Attechments;
using GadgetGrove.Service.Interfaces.AudioVideoBoxAssets;
using GadgetGrove.Service.Interfaces.AudioVideoBoxes;
using GadgetGrove.Service.Interfaces.Authorizations;
using GadgetGrove.Service.Interfaces.DeviceAssets;
using GadgetGrove.Service.Interfaces.Devices;
using GadgetGrove.Service.Interfaces.Discounts;
using GadgetGrove.Service.Interfaces.Feedbacks;
using GadgetGrove.Service.Interfaces.Locations;
using GadgetGrove.Service.Interfaces.Orders;
using GadgetGrove.Service.Interfaces.OTP;
using GadgetGrove.Service.Interfaces.Payments;
using GadgetGrove.Service.Interfaces.ProductMalls;
using GadgetGrove.Service.Interfaces.Users;
using GadgetGrove.Service.Services.AboutUsServices;
using GadgetGrove.Service.Services.Accessories;
using GadgetGrove.Service.Services.AccessoryAssets;
using GadgetGrove.Service.Services.Addresses;
using GadgetGrove.Service.Services.ApplianceAssets;
using GadgetGrove.Service.Services.Appliances;
using GadgetGrove.Service.Services.Attachments;
using GadgetGrove.Service.Services.AudioVideoBoxAssets;
using GadgetGrove.Service.Services.AudioVideoBoxes;
using GadgetGrove.Service.Services.Authorizations;
using GadgetGrove.Service.Services.DeviceAssets;
using GadgetGrove.Service.Services.Devices;
using GadgetGrove.Service.Services.Discounts;
using GadgetGrove.Service.Services.Feedbacks;
using GadgetGrove.Service.Services.Locations;
using GadgetGrove.Service.Services.Orders;
using GadgetGrove.Service.Services.OTP;
using GadgetGrove.Service.Services.Payments;
using GadgetGrove.Service.Services.ProductMalls;
using GadgetGrove.Service.Services.Users;
using GadgetGrove.Shared.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace GadgetGrove.Api.Extensions;

public static class ServiceExtension
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        // Generic Reporitory
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // User Service
        services.AddScoped<IUserService, UserService>();

        // Auth Service
        services.AddScoped<IAuthService, AuthService>();

        // AboutUs Service
        services.AddScoped<IAboutUsService, AboutUsService>();

        // AboutUsAsset Service
        services.AddScoped<IAboutUsAssetService, AboutUsAssetService>();

        // Accessory Service
        services.AddScoped<IAccessoryService, AccessoryService>();

        // FileUpload service
        //services.AddScoped<IFileUploadService, FileUploadService>();

        // Address Service
        services.AddScoped<IAddressService, AddressService>();

        // Appliance Service
        services.AddScoped<IApplianceService, ApplianceService>();

        // Device Service
        services.AddScoped<IDeviceService, DeviceService>();

        // Feedback Service
        services.AddScoped<IFeedbackService, FeedbackService>();

        // Attachment Service
        services.AddScoped<IAttechmentService, AttachmentService>();

        services.AddScoped<EnvironmentContextHelper, EnvironmentContextHelper>();

        // Payment Service
        services.AddScoped<IPaymentService, PaymentService>();

        // Discount Service
        services.AddScoped<IDiscountService, DiscountService>();

        // AudioVideo Service
        services.AddScoped<IAudioVideoBoxService, AudioVideoBoxService>();

        // Assets
        services.AddScoped<IAccessoryAssetService, AccessoryAssetService>();
        services.AddScoped<IApplianceAssetService, ApplianceAssetService>();
        services.AddScoped<IAudioVideoBoxAssetService, AudioVideoBoxAssetService>();
        services.AddScoped<IDeviceAssetService, DeviceAssetService>();

        // Location Service
        services.AddScoped<ILocationService, LocationService>();

        // Order Service
        services.AddScoped<IOrderService, OrderService>();

        // OrderAction service
        services.AddScoped<IOrderActionService, OrderActionService>();

        // ProductMall Service
        services.AddScoped<IProductMallService, ProductMallService>();

        // Authorizations
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IRolePermissionService, RolePermissionService>();
        services.AddScoped<IRoleService, RoleService>();

        //Otp
        services.AddHttpClient();
        services.AddScoped<ISmsService, SmsService>();
        services.AddScoped<ISendSmsToUserService, SendSmsToUserService>();
    }
    /// <summary>
    /// Add JWT credentials from appsettings.json and configure it
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                ClockSkew = TimeSpan.Zero
            };
        });
    }

    /// <summary>
    /// Add CORS to give access for header, actions
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        });
    }
    public static void AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "GadgetGrove.Api", Version = "v1" });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
        });
    }
}
