using System.Reflection; //Used to look inside our project for configuration
using Microsoft.EntityFrameworkCore; //need these libraries for using framework.
using Starter_Bag.Entities; //Main library for EF core


namespace Starter_Bag.Data;
//namespace is folder/group name to keep code organized.

//here, the class DataContext tells EF core how to talk to the database
// this is the bridge between C# code and the tables

// following : constructor: This passes "options" (like which database to use, connection string,etc
//to the base DbContext class (from EF core.
//Without this, Ef core wouldnt know where and how to connect.
public sealed class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    // This special method lets us customize how out database tables should look
    //and how entities (C# classes) map to tables 
    //eg: we can say first name is required or email should be unique

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //ALways call base. OnModeCreating FIrst so Ef core can do its default setup 
        base.OnModelCreating(modelBuilder);

        //This line says :" Go look inside this project assembly(code library)
        //and apply all the entity confgurations you can find //
        // Example : it will find UserEntityConfiguration class and apply its rule 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).GetTypeInfo().Assembly);
    }

    public DbSet<User> Users { get; set; }
}