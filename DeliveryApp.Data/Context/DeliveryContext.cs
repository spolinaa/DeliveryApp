using DeliveryApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Models;

public class DeliveryContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    public DeliveryContext(DbContextOptions<DeliveryContext> options)
    : base(options)
    {
    }
}