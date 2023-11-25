using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.DataAccess.Core.Configuration
{
    internal class ShopingCartDetailsConfiguration: IEntityTypeConfiguration<ShopingCart.Domain.Models.ShopingDetails>
    {
        public void Configure(EntityTypeBuilder<ShopingCart.Domain.Models.ShopingDetails> builder)
        {
            builder.ToTable(_ => _.HasCheckConstraint("Count", "Count > 0 AND Count <= 10")
                .HasName("CK_Product_Count"));
        }
    }
}
