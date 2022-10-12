using Microsoft.EntityFrameworkCore;

namespace E_commerce_1.Context
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_Role> User_Roles { get; set; }
        public DbSet<Product_Order> Product_Orders { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //role
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    Name = "Admin",
                    Description = "Responsible for adding, editing, deleting of products and products’ categories"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Customer",
                    Description = "Can add products to their shopping carts and submit purchasing orders"
                });

            //location
            modelBuilder.Entity<Location>().HasData(
                new Location()
                {
                    Id = 1,
                    Name = "Sharjah",
                },
                new Location()
                {
                    Id = 2,
                    Name = "Dubai",
                });

            //User
            modelBuilder.Entity<User>()
            .HasOne<Location>(s => s.Location)
            .WithMany(g => g.Users)
            .HasForeignKey(s => s.LocationId);

            modelBuilder.Entity<User>().HasData(
               new User()
               {
                   Id = 1,
                   FirstName = "Admin",
                   LastName = "Admin",
                   Age = 20,
                   Email = "admin@emaratech.ae",
                   Mobile = "0501234567",
                   Password = "123",
                   LocationId = 1,
               },
               new User()
               {
                   Id = 2,
                   FirstName = "Fatma",
                   LastName = "AlSayegh",
                   Age = 22,
                   Email = "fatma@emaratech.ae",
                   Mobile = "0501234567",
                   Password = "123",
                   LocationId = 2,
               },
               new User()
               {
                   Id = 3,
                   FirstName = "Customer",
                   LastName = "Customer",
                   Age = 22,
                   Email = "customer@emaratech.ae",
                   Mobile = "0501234567",
                   Password = "123",
                   LocationId = 2,
               });

            //User-Role
            modelBuilder.Entity<User_Role>()
               .HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<User_Role>()
               .HasOne<User>(sc => sc.User)
               .WithMany(s => s.User_Roles)
               .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<User_Role>()
                .HasOne<Role>(sc => sc.Role)
                .WithMany(s => s.User_Roles)
                .HasForeignKey(sc => sc.RoleId);

            modelBuilder.Entity<User_Role>().HasData(
                new User_Role()
                {
                    UserId = 1,
                    RoleId = 1
                },
            new User_Role()
            {
                UserId = 2,
                RoleId = 2
            },
            new User_Role()
            {
                UserId = 3,
                RoleId = 2
            });
            //category
            modelBuilder.Entity<Category>().HasData(
              new Category()
              {
                  Id = 1,
                  Name = "Shirts",
                  Description = "Shirts",
                  Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\shirt icon.png"

              },
              new Category()
              {
                  Id = 2,
                  Name = "Pants",
                  Description = "Pants",
                  Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\pants icon.png",

              }, new Category()
              {
                  Id = 3,
                  Name = "Dress",
                  Description = "dresses",
                  Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\dress icon.png"

              }, new Category()
              {
                Id = 4,
                  Name = "Shoes",
                  Description = "Shoes",
                  Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\shoe icon.png"
              });
            //product

            modelBuilder.Entity<Product>().HasData(
               new Product()
               {
                   Id = 1,
                   Name = "Balenciaga Dress",
                   Description = "Balenciaga v-neck green dress",
                   Price = "2000",
                   CategoryId = 3,
                   Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\Balenciaga dress.jpg"
               },
               new Product()
               {
                   Id = 2,
                   Name = "Dress Shoes",
                   Description = "Elegant brown business dress shoe",
                   Price = "200",
                   CategoryId = 4,
                   Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\elegant business dress shoe.jpg"

               },
               new Product()
               {
                   Id = 3,
                   Name = "Hermes Noir Sandal",
                   Description = "Hermes black noir heel sandal",
                   Price = "500",
                   CategoryId = 4,
                   Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\hermes black noir oasis heel sandal.jpg"

               },
               new Product()
               {
                   Id = 4,
                   Name = "Louis Vuitton Denim Pants",
                   Description = "Louis Vuitton Destroyed Carpenter Denim Pants",
                   Price = "60",
                   CategoryId = 2,
                   Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\Louis vuitton Destroyed Carpenter denim pants.jpg"

               },
               new Product()
               {
                   Id = 5,
                   Name = "Gucci Shirt",
                   Description = "Blue Gucci Shirt",
                   Price = "800",
                   CategoryId = 1,
                   Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\men gucci shirt.jpg"

               },
               new Product()
               {
                   Id = 6,
                   Name = "Nike Road Running shoes",
                   Description = "Nike Winflo 8 Road Running shoes",
                   Price = "300",
                   CategoryId = 4,
                   Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\nike winflo 8 mens road running shoes.jpg"

               },
               new Product()
               {
                   Id = 7,
                   Name = "Gucci Long Sleeve Shirt",
                   Description = "Gucci Brown Long Sleeve Shirt",
                   Price = "300",
                   CategoryId = 1,
                   Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\women gucci shirt.jpg"

               },
               new Product()
               {
                   Id = 8,
                   Name = "Zara Long Sleeve Shirt",
                   Description = "Zara Greeb Long Sleeve Shirt",
                   Price = "150",
                   CategoryId = 1,
                   Icon = "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\zara shirt.jpg"

               });
            //order
            modelBuilder.Entity<Order>()
            .HasOne<User>(s => s.Users)
            .WithMany(g => g.Orders)
            .HasForeignKey(s => s.UserId);

            //Product_Order
            modelBuilder.Entity<Product_Order>()
               .HasKey(x => new { x.ProductId, x.OrderId });

            modelBuilder.Entity<Product_Order>()
                            .HasOne<Product>(sc => sc.Product)
                            .WithMany(s => s.Product_Orders)
                            .HasForeignKey(sc => sc.ProductId);
            modelBuilder.Entity<Product_Order>()
               .HasOne<Order>(sc => sc.Order)
               .WithMany(s => s.Product_Orders)
               .HasForeignKey(sc => sc.OrderId);


        }
    }
}
