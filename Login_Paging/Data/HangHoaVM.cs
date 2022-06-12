using Login_Paging.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Login_Paging.Data
{
    public class HangHoaVM : Identification
    {
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }
    }
    internal class HangHoaVmEntityConfiguration : IEntityTypeConfiguration<HangHoaVM>
    {
        public void Configure(EntityTypeBuilder<HangHoaVM> builder)
        {
            builder.ToTable("HangHoaVM");
            builder.Property(x => x.DonGia).IsRequired();
            builder.Property(x => x.TenHangHoa).IsRequired().HasMaxLength(250);
        }
    }
}
