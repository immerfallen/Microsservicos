using Entities = Domain.Guest.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Guest
{
    internal class GuestConfiguration : IEntityTypeConfiguration<Domain.Guest.Entities.Guest>
    {
        public void Configure(EntityTypeBuilder<Domain.Guest.Entities.Guest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Document)
                .Property(x => x.Idnumber);
            builder.OwnsOne(x => x.Document)
                .Property(x => x.DocumentType);
        }
    }
}
