﻿// using System;
// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
// using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

// namespace TodoApi;

// public partial class ToDoDbContext : DbContext
// {
//     public ToDoDbContext()
//     {
//     }

//     public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
//         : base(options)
//     {
//     }

//     public virtual DbSet<Item> Items { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         => optionsBuilder.UseMySql("name=ToDodb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder
//             .UseCollation("utf8mb4_0900_ai_ci")
//             .HasCharSet("utf8mb4");

//         modelBuilder.Entity<Item>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PRIMARY");

//             entity.ToTable("items");

//             entity.Property(e => e.Name).HasMaxLength(100);
//         });

//         OnModelCreatingPartial(modelBuilder);
//     }

//     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
// }
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TodoApi;

public partial class ToDoDbContext : DbContext
{
    // DbSet של משתמשים
    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
    {
    }

    // הגדרת חיבור למסד הנתונים
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    Console.WriteLine("OnConfiguring is being called"); // לוג פשוט
    optionsBuilder.UseMySql("name=ToDodb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));
        Console.WriteLine("success"); // לוג פשוט

}

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseMySql("name=ToDodb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    // אפיון טבלאות ותכונות
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        // הגדרת טבלת Items
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("items");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        // הגדרת טבלת Users (למשתמשים)
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Username).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Password).HasMaxLength(255).IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
