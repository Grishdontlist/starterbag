// libraries are for Entity Framework- the tool that talks to our database

using Microsoft.EntityFrameworkCore; // framework
using System.Reflection;             // used to look inside our project for configuration 
using Starter_Bag.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;         // Main library for ENtity frame work core 

namespace Starter_Bag.Data; // Namespace - folder / group name to keep the code organized 

// this class DataContext tells EF core how to talk to the DB

// its a bridge betwn C# code and the db tables

public sealed class DataContext : DbContext
{

    // Constructor : This passes "options" (like which database to use 
    // to the base Dbcontext class (from EF core)
    // without this, EF core wouldnt know where/ how to connect

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    // this special method lets us  customize how our database tables should look
    // and how entities (C# classes) map to tables.
    // Example: we can say the "firstname is required " or "Email must be unique"

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ALways call base.OnMOdelCreating first so EF core can do its default setup
        base.OnModelCreating(modelBuilder);
        // this line says : " go look inside this project assembly (code library)
        // and apply all the entity configurations you can find.
        // Example : It will find our "UserEntityConfiguration" class and apply its rules.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).GetTypeInfo().Assembly);
    }
    public DbSet<User> Users { get; set; }
}





// this line says: " Go look inside this project assembly (code library)
    // 
    