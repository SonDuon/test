using _CNPM___08___Nhóm_12__QLKS.Domain;
using _CNPM___08___Nhóm_12__QLKS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace _CNPM___08___Nhóm_12__QLKS.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    // Create Hotel table 
    // After finish adding Properties for Hotel run below to create create table
    // dotnet ef migrations add AddHotelDB --project '.\[CNPM] [08] [Nhóm 12] QLKS.Infrastructure\[CNPM] [08] [Nhóm 12] QLKS.Infrastructure.csproj'
    // And continue run follow command to update changes database
    // dotnet ef database update --project '.\[CNPM] [08] [Nhóm 12] QLKS.Infrastructure\[CNPM] [08] [Nhóm 12] QLKS.Infrastructure.csproj'
    //   public DbSet<Hotel> hotels { get; set; }
    // After create table uncomment below and fill data to seed to database
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //   modelBuilder.Entity<Hotel>().HasData();
    // }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<HotelNumber> HotelNumbers { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
    public DbSet<Member> Members { get; set; }
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     //base.OnModelCreating(modelBuilder);
    //     modelBuilder.Entity<Hotel>().HasData(
    //           new Hotel
    //           {
    //               ID = 1,
    //               Name = "Royal Hotel",
    //               Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
    //               ImageUrl = "https://placehold.co/600x400",
    //               Occupancy = 4,
    //               Price = 200,
    //               Sqm = 550,
    //           },
    //         new Hotel
    //         {
    //             ID = 2,
    //             Name = "Premium Pool Hotel",
    //             Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
    //             ImageUrl = "https://placehold.co/600x401",
    //             Occupancy = 4,
    //             Price = 300,
    //             Sqm = 550,
    //         },
    //         new Hotel
    //         {
    //             ID = 3,
    //             Name = "Luxury Pool Hotel",
    //             Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
    //             ImageUrl = "https://placehold.co/600x402",
    //             Occupancy = 4,
    //             Price = 400,
    //             Sqm = 750,
    //         });
    //     modelBuilder.Entity<HotelNumber>().HasData(
    //         new HotelNumber
    //         {
    //             Hotel_Number = 101,
    //             HotelId = 1,
    //         },
    //         new HotelNumber
    //         {
    //             Hotel_Number = 102,
    //             HotelId = 1,
    //         },
    //         new HotelNumber
    //         {
    //             Hotel_Number = 201,
    //             HotelId = 2,
    //         },
    //         new HotelNumber
    //         {
    //             Hotel_Number = 202,
    //             HotelId = 2,
    //         },
    //         new HotelNumber
    //         {
    //             Hotel_Number = 301,
    //             HotelId = 3,
    //         },
    //         new HotelNumber
    //         {
    //             Hotel_Number = 302,
    //             HotelId = 3,
    //         }
    //         );
    //     modelBuilder.Entity<Amenity>().HasData(
    //   new Amenity
    //   {
    //       Id = 1,
    //       HotelId = 1,
    //       Name = "Private Pool"
    //   }, new Amenity
    //   {
    //       Id = 2,
    //       HotelId = 1,
    //       Name = "Microwave"
    //   }, new Amenity
    //   {
    //       Id = 3,
    //       HotelId = 1,
    //       Name = "Private Balcony"
    //   }, new Amenity
    //   {
    //       Id = 4,
    //       HotelId = 1,
    //       Name = "1 king bed and 1 sofa bed"
    //   },

    //   new Amenity
    //   {
    //       Id = 5,
    //       HotelId = 2,
    //       Name = "Private Plunge Pool"
    //   }, new Amenity
    //   {
    //       Id = 6,
    //       HotelId = 2,
    //       Name = "Microwave and Mini Refrigerator"
    //   }, new Amenity
    //   {
    //       Id = 7,
    //       HotelId = 2,
    //       Name = "Private Balcony"
    //   }, new Amenity
    //   {
    //       Id = 8,
    //       HotelId = 2,
    //       Name = "king bed or 2 double beds"
    //   },

    //   new Amenity
    //   {
    //       Id = 9,
    //       HotelId = 3,
    //       Name = "Private Pool"
    //   }, new Amenity
    //   {
    //       Id = 10,
    //       HotelId = 3,
    //       Name = "Jacuzzi"
    //   }, new Amenity
    //   {
    //       Id = 11,
    //       HotelId = 3,
    //       Name = "Private Balcony"
    //   });
    //     modelBuilder.Entity<Member>().HasData(
    //         new Member { MSSV = "DH52112120", Name = "Trần Đức Vượng", Email = "dh52112120@student.stu.edu.vn" },
    //         new Member { MSSV = "DH52113526", Name = "Trần Thái Duy", Email = "DH52113526@student.stu.edu.vn" },
    //         new Member { MSSV = "DH52110733", Name = "Nguyễn Sơn Dương", Email = "DH52110733@student.stu.edu.vn" },
    //         new Member { MSSV = "DH52110812", Name = "Trương Thanh Đông", Email = "DH52110812@student.stu.edu.vn" },
    //         new Member { MSSV = "DH52111142", Name = "Nguyễn Huỳnh Thanh Khoa", Email = "DH52113526@student.stu.edu.vn" }
    //     );
    // }
}
