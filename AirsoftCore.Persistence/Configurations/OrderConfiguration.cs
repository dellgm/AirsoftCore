//using AirsoftCore.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace AirsoftCore.Persistence.Configurations
//{
//    public class OrderConfiguration : IEntityTypeConfiguration<Order>
//    {
//        public void Configure(EntityTypeBuilder<Order> builder)
//        {
//            builder.HasKey(e => e.OrderId);

//            builder.Property(e => e.OrderId).HasColumnName("OrderId");

//            builder.Property(e => e.CustomerId)
//                .HasColumnName("CustomerId")
//                .HasMaxLength(5);

//            builder.Property(e => e.Total)
//                .HasColumnType("money")
//                .HasDefaultValueSql("((0))");

//            builder.Property(e => e.OrderDate).HasColumnType("datetime");

//            builder.Property(e => e.RequiredDate).HasColumnType("datetime");

//            builder.Property(e => e.ShipAddress).HasMaxLength(60);

//            builder.Property(e => e.ShipCity).HasMaxLength(15);

//            builder.Property(e => e.ShipCountry).HasMaxLength(15);

//            builder.Property(e => e.ShipName).HasMaxLength(40);

//            builder.Property(e => e.ShipPostalCode).HasMaxLength(10);

//            builder.Property(e => e.ShipRegion).HasMaxLength(15);

//            builder.Property(e => e.ShippedDate).HasColumnType("datetime");

//            builder.HasOne(d => d.Customer)
//                .WithMany(p => p.Orders)
//                .HasForeignKey(d => d.CustomerId)
//                .HasConstraintName("FK_Orders_Customers");
//        }
//    }
//}
