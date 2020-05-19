using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParlaFarmaMVCCore.Models;

namespace ParlaFarmaMVCCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Dictionary> Tbl_Dictionary { get; set; }
        public DbSet<Slider> Tbl_Sliders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
