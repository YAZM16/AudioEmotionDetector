// AppDbContext.cs
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AudioEmotionApp.Models;
using AudioEmotionApp.Data;

namespace AudioEmotionApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AudioRecord> AudioRecords { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
