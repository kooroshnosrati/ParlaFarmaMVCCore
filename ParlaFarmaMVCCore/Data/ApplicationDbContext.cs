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
        public DbSet<TblSliders> Tbl_Sliders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
