﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Document)
                .Property(x => x.Idnumber);
            builder.OwnsOne(x => x.Document)
                .Property(x => x.DocumentType);
        }
    }
}
