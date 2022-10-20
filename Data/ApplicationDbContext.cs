using FPTBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FPTBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Note: add dữ liệu cho bảng chứa PK trước (University)
            //rồi add dữ liệu cho bảng chứa FK sau (Student)

            //add dữ liệu khởi tạo cho bảng University
            Category(builder);

            //add dữ liệu khởi tạo (initial data) cho bảng Student
            Book(builder);

            
        }

        private void Book(ModelBuilder builder)
        {
            
        }

        private void Category(ModelBuilder builder)
        {
            var manga = new Category
            {
                Id = 10,
                Name = "Manga",
                Description = "Pham Van Bach",
            };
            var novel = new Category
            {
                Id = 30,
                Name = "Novel",
                Description = "Duy Tan",
            };
            builder.Entity<Category>().HasData(manga, novel);
        }
    }
}
