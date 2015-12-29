using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Models
{
    public class BookContext : DbContext
    {
        public BookContext() : base("ContextConnection")
        {

        }

        public DbSet<Book> Books{ get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithMany(t => t.Authors)
                .Map(
                m =>
                {
                    m.MapLeftKey("BookId");
                    m.MapRightKey("AuthorId");
                    m.ToTable("AuthorToBook");
                }
                );

            modelBuilder.Entity<Category>()
                .HasMany(a => a.books)
                .WithMany(t => t.Categories)
                .Map(
                m =>
                {
                    m.MapLeftKey("BookId");
                    m.MapRightKey("CategoryId");
                    m.ToTable("CategoryToBook");
                }
                );

        }
    }

    }
   

