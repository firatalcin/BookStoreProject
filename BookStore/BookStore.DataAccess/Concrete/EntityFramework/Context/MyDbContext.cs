using BookStore.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Concrete.EntityFramework.Context
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-MVQ36J3\SQLEXPRESS;database=BookStore;Trusted_Connection=True");
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Book_Cart> Book_Carts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Cart>().HasOne(x => x.Book).WithMany(b => b.Cart_Books).HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Book_Cart>().HasOne(x => x.Cart).WithMany(b => b.Cart_Books).HasForeignKey(x => x.CartId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<BookDetail>().HasOne(x => x.Book).WithOne(b => b.BookDetail).HasForeignKey<BookDetail>(x => x.BookId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
