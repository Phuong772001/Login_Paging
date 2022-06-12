using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Login_Paging.Common
{
    public class Identification 
    {
        [Key]
        public Guid Id { get; set; }
    }
    internal class IdentificationEntityConfiguration : IEntityTypeConfiguration<Identification>
    {
        public void Configure(EntityTypeBuilder<Identification> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
