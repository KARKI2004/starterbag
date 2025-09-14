using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product_Bag.Entities;

// this is our product entity

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedDate { get; set; } = DateTimeOffset.UtcNow;
}

public class ProductCreatedDto
{
    public string ProductName {get; set;} = string.Empty;
    public decimal Price {get; set;}
    public string Description {get; set;} = string.Empty;
    public DateTimeOffset CreatedDate {get; set;} = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedDate {get; set;} = DateTimeOffset.UtcNow;
}

//following is created when a product info is updated

public class ProductUpdatedDto
{
    public string ProductName {get; set;} = string.Empty;
    public decimal Price {get; set;}
}

public class ProductGetDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedDate { get; set; } = DateTimeOffset.UtcNow;
}

public class UserEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        //product id is primary key here 
        builder.HasKey(x => x.ProductId);
        
        //ProductName, price and Product description cannot be empty
        builder.Property(x => x.ProductName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Price)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500);


    }  
}
