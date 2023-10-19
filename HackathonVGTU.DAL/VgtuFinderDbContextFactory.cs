using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonVGTU.DAL
{
    internal sealed class VgtuFinderDbContextFactory : IDesignTimeDbContextFactory<VgtuFinderDbContext>
    {
        public VgtuFinderDbContextFactory() : base() { }

        public VgtuFinderDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VgtuFinderDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=vgtucontest;Username=postgres;password=prolodgy778");

            return new VgtuFinderDbContext(optionsBuilder.Options);
        }
    }
}
