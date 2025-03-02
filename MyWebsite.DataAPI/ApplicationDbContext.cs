using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebsite.DataAPI.Entities;

namespace MyWebsite.DataAPI
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<BlogDetails> BlogDetails { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<MyProjects> MyProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comments>()
                .HasOne(c => c.BlogDetail)
                .WithMany(b => b.CommentList)
                .HasForeignKey(c => c.BlogDetailsId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BlogDetails>()
                .Ignore(b => b.AuthorName)
                .Ignore(b => b.AuthorEmail)
                .Ignore(b => b.AuthorRole);

            modelBuilder.Entity<Comments>()
                .Ignore(c => c.AuthorName)
                .Ignore(c => c.AuthorEmail);

            modelBuilder.Entity<BlogDetails>()
                .HasOne(bd => bd.Blog)
                .WithOne()
                .HasForeignKey<BlogDetails>(bd => bd.BlogId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comments>()
                .HasOne(c => c.BlogDetail)
                .WithMany(bd => bd.CommentList)
                .HasForeignKey(c => c.BlogDetailsId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
