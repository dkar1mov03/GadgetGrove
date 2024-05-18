using AutoMapper;
using GadgetGrove.Domain.Entities.AboutUs;
using GadgetGrove.Domain.Entities.Accessories;
using GadgetGrove.Domain.Entities.Addresses;
using GadgetGrove.Domain.Entities.Appliances;
using GadgetGrove.Domain.Entities.Assets;
using GadgetGrove.Domain.Entities.Attechments;
using GadgetGrove.Domain.Entities.Authorizations;
using GadgetGrove.Domain.Entities.Devices;
using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Entities.Orders.Feedbacks;
using GadgetGrove.Domain.Entities.Users;
using GadgetGrove.Domain.Entities.VideoAudioBoxs;
using GadgetGrove.Domain.Entities.WhereHouses;
using GadgetGrove.Service.DTOs.AboutUs;
using GadgetGrove.Service.DTOs.AboutUsAssets;
using GadgetGrove.Service.DTOs.Accessories;
using GadgetGrove.Service.DTOs.AccessoryAssets;
using GadgetGrove.Service.DTOs.Addresses;
using GadgetGrove.Service.DTOs.ApplianceAssets;
using GadgetGrove.Service.DTOs.Appliances;
using GadgetGrove.Service.DTOs.Attachments;
using GadgetGrove.Service.DTOs.AudioVideoAssets;
using GadgetGrove.Service.DTOs.AudioVideoBoxes;
using GadgetGrove.Service.DTOs.Authorizations.Permissions;
using GadgetGrove.Service.DTOs.Authorizations.RolePermissions;
using GadgetGrove.Service.DTOs.Authorizations.Roles;
using GadgetGrove.Service.DTOs.DeviceAssets;
using GadgetGrove.Service.DTOs.Devices;
using GadgetGrove.Service.DTOs.Discounts;
using GadgetGrove.Service.DTOs.FeedbackAttachments;
using GadgetGrove.Service.DTOs.Feedbacks;
using GadgetGrove.Service.DTOs.Locations;
using GadgetGrove.Service.DTOs.OrderActions;
using GadgetGrove.Service.DTOs.Orders;
using GadgetGrove.Service.DTOs.Payments;
using GadgetGrove.Service.DTOs.ProductMalls;
using GadgetGrove.Service.DTOs.Registrations.UserRegistrations;
using GadgetGrove.Service.DTOs.Users;

namespace GadgetGrove.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // Users
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();

        // AboutAssets
        CreateMap<AboutUsAsset,AboutUsAssetForCreationDto>().ReverseMap();
        CreateMap<AboutUsAsset,AboutUsAssetForResultDto>().ReverseMap();
        CreateMap<AboutUsAsset,AboutUsAssetForUpdateDto>().ReverseMap();

        // AboutUs
        CreateMap<AboutUs,AboutUsForCreationDto>().ReverseMap();
        CreateMap<AboutUs,AboutUsForResultDto>().ReverseMap();
        CreateMap<AboutUs,AboutUsForUpdateDto>().ReverseMap();

        // Accessory 
        CreateMap<Accessory,AccessoryForCreationDto>().ReverseMap();
        CreateMap<Accessory,AccessoryForResultDto>().ReverseMap();
        CreateMap<Accessory,AccessoryForUpdateDto>().ReverseMap();

        // Address 
        CreateMap<Address, AddressForCreationDto>().ReverseMap();
        CreateMap<Address, AddressForResultDto>().ReverseMap();

        // Appliance
        CreateMap<Appliance,ApplianceForCreationDto>().ReverseMap();
        CreateMap<Appliance,ApplianceForResultDto>().ReverseMap();
        CreateMap<Appliance,ApplianceForUpdateDto>().ReverseMap();

        // Attachment
        CreateMap<Attachment,AttachmentForCreationDto>().ReverseMap();
        CreateMap<Attachment, AttachmentForResultDto>().ReverseMap();
        CreateMap<Attachment,SingleFile>().ReverseMap();

        // Device
        CreateMap<Device,DeviceForCreationDto>().ReverseMap();
        CreateMap<Device,DeviceForResultDto>().ReverseMap();
        CreateMap<Device,AudioVideoForUpdateDto>().ReverseMap();

        // Feedback
        CreateMap<Feedback,FeedbackForCreationDto>().ReverseMap();
        CreateMap<Feedback,FeedbackForResultDto>().ReverseMap();
        CreateMap<Feedback,FeedbackForUpdateDto>().ReverseMap();

        // FeedbackAttachment
        CreateMap<FeedbackAttachment,FeedbackAttachmentForCreationDto>().ReverseMap();
        CreateMap<FeedbackAttachment, FeedbackAttachmentForResutlDto>().ReverseMap();
        CreateMap<FeedbackAttachment,FeedbackAttachmentForUpdateDto>().ReverseMap();

        // Payment
        CreateMap<Payment,PaymentForCreationDto>().ReverseMap();
        CreateMap<Payment,PaymentForResultDto>().ReverseMap();
        CreateMap<Payment,PaymentForUpdateDto>().ReverseMap();

        // Discount
        CreateMap<Discount,DiscountForCreationDto>().ReverseMap();
        CreateMap<Discount,DiscountForResultDto>().ReverseMap();
        CreateMap<Discount,DiscountForUpdateDto>().ReverseMap();

        // AudioVideo
        CreateMap<VideoAudiBox,AudioVideoBoxForCreationDto>().ReverseMap();
        CreateMap<VideoAudiBox,AudioVideoBoxForResultDto>().ReverseMap();
        CreateMap<VideoAudiBox,AudioVideoBoxForUpdateDto>().ReverseMap();

        // Assets
        CreateMap<AccessoryAsset,AccessoryAssetForResultDto>().ReverseMap();
        CreateMap<ApplianceAsset, ApplianceAssetForResultDto>().ReverseMap();
        CreateMap<AudioVideoBoxAsset, AudioVideoBoxAssetForResultDto>().ReverseMap();
        CreateMap<DeviceAsset, DeviceAssetForResultDto>().ReverseMap();

        // Location
        CreateMap<Location,LocationForCreationDto>().ReverseMap();
        CreateMap<Location,LocationForResultDto>().ReverseMap();

        // Orders
        CreateMap<Order,OrderForCreationDto>().ReverseMap();
        CreateMap<Order,OrderForResultDto>().ReverseMap();
        CreateMap<Order,OrderForUpdateDto>().ReverseMap();

        // OrderActions
        CreateMap<OrderAction,OrderActionForCreationDto>().ReverseMap();
        CreateMap<OrderAction,OrderActionForResultDto>().ReverseMap();
        CreateMap<OrderAction, OrderActionForUpdateDto>().ReverseMap(); 

        // ProductMalls
        CreateMap<ProductMallInventoryAssignment,ProductMallForCreationDto>().ReverseMap();
        CreateMap<ProductMallInventoryAssignment,ProductMallForResultDto>().ReverseMap();
        CreateMap<ProductMallInventoryAssignment,ProductMallForUpdateDto>().ReverseMap();

        // Role
        CreateMap<Role, RoleForResultDto>().ReverseMap();
        CreateMap<Role, RoleForCreationDto>().ReverseMap();
        CreateMap<Role, RoleForUpdateDto>().ReverseMap();

        // RolePermission
        CreateMap<RolePermission, RolePermissionForResultDto>().ReverseMap();
        CreateMap<RolePermission, RolePermissionForCreationDto>().ReverseMap();
        CreateMap<RolePermission, RolePermissionForUpdateDto>().ReverseMap();

        // Permission
        CreateMap<Permission, PermissionForResultDto>().ReverseMap();
        CreateMap<Permission, PermissionForCreationDto>().ReverseMap();
        CreateMap<Permission, PermissionForUpdateDto>().ReverseMap();

        //Registration 
        CreateMap<UserForCreationDto, UserRegistrationForCreationDto>().ReverseMap();
        CreateMap<UserForResultDto, UserRegistrationForResultDto>().ReverseMap();
    }
}
