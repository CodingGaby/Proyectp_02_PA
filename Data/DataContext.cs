using Microsoft.EntityFrameworkCore;
using Proyectp_02_PA.Data.Entities;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System;

namespace Proyectp_02_PA.Data
{
    public class DataContext : DbContext 
    {

        public DbSet<DailyActivity> DailyActivities { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<DiseaseDetail> DiseaseDetails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<NutrAI> NutrAIs { get; set; }
        public DbSet<Pantry> Pantries { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeDetail> RecipeDetails { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<DailyActivity>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Disease>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Ingredient>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Pantry>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Recipe>().HasIndex(x => x.Id).IsUnique();
        }
    }
}
