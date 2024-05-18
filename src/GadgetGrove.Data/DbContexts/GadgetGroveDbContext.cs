using GadgetGrove.Domain.Entities.AboutUs;
using GadgetGrove.Domain.Entities.Accessories;
using GadgetGrove.Domain.Entities.Addresses;
using GadgetGrove.Domain.Entities.Appliances;
using GadgetGrove.Domain.Entities.Assets;
using GadgetGrove.Domain.Entities.Attechments;
using GadgetGrove.Domain.Entities.Devices;
using GadgetGrove.Domain.Entities.Orders;
using GadgetGrove.Domain.Entities.Orders.Feedbacks;
using GadgetGrove.Domain.Entities.Users;
using GadgetGrove.Domain.Entities.VideoAudioBoxs;
using GadgetGrove.Domain.Entities.WhereHouses;
using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Data.DbContexts;

public class GadgetGroveDbContext : DbContext
{
    public GadgetGroveDbContext(DbContextOptions<GadgetGroveDbContext> options) : base(options)
    { }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<AboutUs> AboutUs { get; set; }
    public DbSet<Address> Addresss { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<AboutUsAsset> Assets { get; set; }
    public DbSet<Appliance> Appliances { get; set; }
    public DbSet<Accessory> Accessories { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<OrderAction> OrderActions { get; set; }
    public DbSet<DeviceAsset> DeviceAssets { get; set; }
    public DbSet<VideoAudiBox> VideoAudiBoxes { get; set; }
    public DbSet<ApplianceAsset> ApplianceAssets { get; set; }
    public DbSet<AccessoryAsset> AccessoriesAsset { get; set; }
    public DbSet<FeedbackAttachment> FeedbackAttachments { get; set; }
    public DbSet<AudioVideoBoxAsset> AudioVideoBoxesAsset { get; set;}
    public DbSet<ProductMallInventoryAssignment> ProductMallInventoryAssignments { get; set; }

}
