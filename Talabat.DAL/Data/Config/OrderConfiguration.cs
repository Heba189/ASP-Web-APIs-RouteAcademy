using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities.Order_Aggregate;

namespace Talabat.DAL.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
          builder.OwnsOne(o=>o.ShipToAddress , Address => Address.WithOwner());

            builder.Property(o => o.Status)
                   .HasConversion(
                      OStatus => OStatus.ToString(),
                      OStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), OStatus)
                    );
            builder.HasMany(o=>o.Items).WithOne().OnDelete(DeleteBehavior.Cascade);


        }
    }
}
