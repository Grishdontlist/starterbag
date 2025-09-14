using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Starter_Bag.Entities;

public class User
{
    //primary key - this uniquely identifies a user in the database
    // think of this as a blueprint each user object  - one row in database -       

    public int UserId { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedDate { get; set; } = DateTimeOffset.UtcNow;
}
// This DTO is used when we UPDATE an existing user
// for ex: changing email , name or password
// and this is all about updatiung personal information.
public class UserCreateDto
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;


}

public class UserUpdateDto
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
}
public class UserGetDto
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    // Notice: No Password  - we never show password to the frontend

    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
}

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Every table needs a primary key here : UserId)
        builder.HasKey(x => x.UserId);

        // Firstname must NOT be empty , and max lenght 100
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(100);


        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(255);
    }
}
