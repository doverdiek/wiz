using AbstractModels;
using DataModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlDBCrudLibrary
{
    public class WizDBContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProperty> CategoryProperties { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sqldatabase; Database=Wiz; User id=sa;Password=8jkGh47hnDw89Haq8LN2;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProperty>()
            .Property(e => e.Values)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Category>()
            .Property(e => e.ProductIds)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Category>()
            .Property(e => e.Products)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
               v => JsonConvert.DeserializeObject<List<Product>>(v));
             modelBuilder.Entity<Category>()
            .Property(e => e.SubCategoriesIds)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Category>()
            .Property(e => e.SubCategories)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
               v => JsonConvert.DeserializeObject<List<Category>>(v));
            modelBuilder.Entity<Category>()
            .Property(e => e.Properties)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
               v => JsonConvert.DeserializeObject<List<CategoryProperty>>(v));
            modelBuilder.Entity<Product>()
            .Property(e => e.Images)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<string[]>(v));
            modelBuilder.Entity<Product>()
            .Property(e => e.Properties)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
               v => JsonConvert.DeserializeObject<List<CategoryProperty>>(v));
            modelBuilder.Entity<User>()
            .Property(e => e.Domains)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<string[]>(v));
        }
    }

    }

