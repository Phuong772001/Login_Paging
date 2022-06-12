using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Login_Paging.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Login_Paging.Data
{
    
    public class NguoiDung : Identification 
    {
        
        public string UserName { get; set; }
        
        public string Password { get; set; }

        public string  HoTen { get; set; }
        public string  Email { get; set; }
    }
    internal class NguoiDungEntityConfiguration : IEntityTypeConfiguration<NguoiDung>
    {
        public void Configure(EntityTypeBuilder<NguoiDung> builder)
        {
            builder.ToTable("NguoiDung");
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(250);
            builder.Property(x => x.HoTen).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }
}
