using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login_Paging.Common;
using Login_Paging.Models;
using Microsoft.EntityFrameworkCore;

namespace Login_Paging.Data
{
    public class MyDbcontext :DbContext
    {
        public MyDbcontext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new HangHoaVmEntityConfiguration());
            modelBuilder.ApplyConfiguration(new NguoiDungEntityConfiguration());
            // base.OnModelCreating(modelBuilder);
        }

        public DbSet<HangHoaVM> HangHoas { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
    }

}
