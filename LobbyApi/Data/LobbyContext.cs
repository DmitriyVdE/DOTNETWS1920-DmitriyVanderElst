using LobbyApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LobbyApi.Data
{
    public class LobbyContext : IdentityDbContext
        <
            User,
            Role,
            string,
            IdentityUserClaim<string>,
            UserRole,
            IdentityUserLogin<string>,
            IdentityRoleClaim<string>,
            IdentityUserToken<string>
        >
    {
        public LobbyContext(DbContextOptions<LobbyContext> options)
            : base(options)
        {
            //FakeDataFiller FDF = new FakeDataFiller(this);
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUserType> GroupUserTypes { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (modelBuilder == null) { throw new ArgumentNullException(nameof(modelBuilder)); }

            // COUNTRY
            modelBuilder.Entity<Country>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Country>()
                .HasIndex(c => c.Name)
                .IsUnique(true)
                .HasName("UQ_Name");

            // ROLE
            modelBuilder.Entity<Role>()
                .HasIndex(ut => ut.Description)
                .IsUnique(true)
                .HasName("UQ_Description");

            // USER
            modelBuilder.Entity<User>()
                .HasOne(u => u.Country)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            // USERROLE
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(g => g.User)
                .WithMany(g => g.UserRoles)
                .HasForeignKey(g => g.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserRole>()
                .HasOne(g => g.Role)
                .WithMany(u => u.RoleUsers)
                .HasForeignKey(g => g.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // FRIEND
            modelBuilder.Entity<Friend>()
                .HasKey(f => new { f.UserId, f.UserId2 });

            modelBuilder.Entity<Friend>()
                .HasOne(f => f.User)
                .WithMany(f => f.UserFriends)
                .HasForeignKey(f => f.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friend>()
                .HasOne(f => f.User2)
                .WithMany(u => u.FriendUsers)
                .HasForeignKey(f => f.UserId2)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // GROUP
            modelBuilder.Entity<Group>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Group>()
                .HasOne(g => g.GroupType)
                .WithMany(gt => gt.Groups)
                .HasForeignKey(g => g.GroupTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // GROUPUSER
            modelBuilder.Entity<GroupUser>()
                .HasKey(gu => new { gu.GroupId, gu.UserId });

            modelBuilder.Entity<GroupUser>()
                .HasOne(g => g.Group)
                .WithMany(g => g.GroupUsers)
                .HasForeignKey(g => g.GroupId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupUser>()
                .HasOne(g => g.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(g => g.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupUser>()
                .HasOne(gu => gu.GroupUserType)
                .WithMany(gt => gt.GroupUsers)
                .HasForeignKey(gu => gu.GroupUserTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // POST
            modelBuilder.Entity<Post>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.PostType)
                .WithMany(pt => pt.Posts)
                .HasForeignKey(p => p.PostTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.UserWall)
                .WithMany(u => u.UserWall)
                .HasForeignKey(p => p.UserWallId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.GroupWall)
                .WithMany(g => g.GroupWall)
                .HasForeignKey(p => p.GroupWallId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}