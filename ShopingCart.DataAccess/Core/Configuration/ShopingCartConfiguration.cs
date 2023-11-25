using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.DataAccess.Core.Configuration
{
    internal class ShopingCartConfiguration: IEntityTypeConfiguration<ShopingCart.Domain.Models.ShopingCart>
    {
        public void Configure(EntityTypeBuilder<ShopingCart.Domain.Models.ShopingCart> builder)
        {
            builder.Property(_ => _.Date).HasDefaultValueSql("GETUTCDATE");
        }
    }
}
