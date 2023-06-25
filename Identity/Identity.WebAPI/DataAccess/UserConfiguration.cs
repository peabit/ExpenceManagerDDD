using Identity.WebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.WebAPI.DataAccess;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        FillTestData(builder);
    }

    private void FillTestData(EntityTypeBuilder<User> builder)
    {
        // Password: qweR_1
        builder.HasData(new User
        {
            Id = "9eadfc0a-bca1-44d5-b9b0-e73b1299fa58",
            Email = "dima@mail.com",
            NormalizedEmail = "DIMA@MAIL.COM",
            UserName = "Dima",
            NormalizedUserName = "DIMA",
            PasswordHash = "AQAAAAIAAYagAAAAEP1JOgzTVTvzHuXNawTXxpKt2xSazCSA2F0fmXNRl5I3hh3bSzbfqqZW0K8iRCNzhQ==",
            SecurityStamp = "KF2IMU7VUU2DXWYELDXSAPXWYAEQCGAS",
            ConcurrencyStamp = "a880b71f-ad2a-4b35-b8d8-465b12320204",
            LockoutEnabled = true
        });
    }
}