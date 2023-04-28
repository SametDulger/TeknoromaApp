using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace DataAccessLayer.SeedData
{
    public static class SeedDatas
    {
        public static void SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, Context context)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedUse(context);
        }

        private static void SeedUsers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                AppUser Admin = new AppUser();
                Admin.UserName = "Admin";
                Admin.Email = "admin@teknoroma.com";
                Admin.FirstName = "Yönetici";
                Admin.LastName = "Kullanıcısı";
                Admin.Status = EntityLayer.Enum.Status.Active;
                Admin.CreatedBy = "Test";
                Admin.CreatedComputerName = "Test";
                Admin.CreatedDate = DateTime.Now;
                Admin.CreatedIP = "^Test";
                Admin.Address = "Test";
                Admin.Salary = 10000;
                Admin.PhoneNumber = "05555555555";

                AppUser Cashier = new AppUser();
                Cashier.UserName = "Cashier";
                Cashier.Email = "Cashier@teknoroma.com";
                Cashier.FirstName = "Kasiyer";
                Cashier.LastName = "Kullanıcısı";
                Cashier.Status = EntityLayer.Enum.Status.Active;
                Cashier.CreatedBy = "Test";
                Cashier.CreatedComputerName = "Test";
                Cashier.CreatedDate = DateTime.Now;
                Cashier.CreatedIP = "^Test";
                Cashier.Address = "Test";
                Cashier.Salary = 10000;
                Cashier.PhoneNumber = "05555555555";

                AppUser Accounting = new AppUser();
                Accounting.UserName = "Accounting";
                Accounting.Email = "Accounting@teknoroma.com";
                Accounting.FirstName = "Muhasebeci";
                Accounting.LastName = "Kullanıcısı";
                Accounting.Status = EntityLayer.Enum.Status.Active;
                Accounting.CreatedBy = "Test";
                Accounting.CreatedComputerName = "Test";
                Accounting.CreatedDate = DateTime.Now;
                Accounting.CreatedIP = "^Test";
                Accounting.Address = "Test";
                Accounting.Salary = 10000;
                Accounting.PhoneNumber = "05555555555";

                AppUser MobileSales = new AppUser();
                MobileSales.UserName = "MobileSales";
                MobileSales.Email = "MobileSales@teknoroma.com";
                MobileSales.FirstName = "Mobil Satış";
                MobileSales.LastName = "Kullanıcısı";
                MobileSales.Status = EntityLayer.Enum.Status.Active;
                MobileSales.CreatedBy = "Test";
                MobileSales.CreatedComputerName = "Test";
                MobileSales.CreatedDate = DateTime.Now;
                MobileSales.CreatedIP = "^Test";
                MobileSales.Address = "Test";
                MobileSales.Salary = 10000;
                MobileSales.PhoneNumber = "05555555555";

                AppUser StockRoom = new AppUser();
                StockRoom.UserName = "StockRoom";
                StockRoom.Email = "StockRoom@teknoroma.com";
                StockRoom.FirstName = "Depo Görevlisi";
                StockRoom.LastName = "Kullanıcısı";
                StockRoom.Status = EntityLayer.Enum.Status.Active;
                StockRoom.CreatedBy = "Test";
                StockRoom.CreatedComputerName = "Test";
                StockRoom.CreatedDate = DateTime.Now;
                StockRoom.CreatedIP = "^Test";
                StockRoom.Address = "Test";
                StockRoom.Salary = 10000;
                StockRoom.PhoneNumber = "05555555555";

                AppUser TechnicalService = new AppUser();
                TechnicalService.UserName = "TechnicalService";
                TechnicalService.Email = "TechnicalService@teknoroma.com";
                TechnicalService.FirstName = "Teknik Servis";
                TechnicalService.LastName = "Kullanıcısı";
                TechnicalService.Status = EntityLayer.Enum.Status.Active;
                TechnicalService.CreatedBy = "Test";
                TechnicalService.CreatedComputerName = "Test";
                TechnicalService.CreatedDate = DateTime.Now;
                TechnicalService.CreatedIP = "^Test";
                TechnicalService.Address = "Test";
                TechnicalService.Salary = 10000;
                TechnicalService.PhoneNumber = "05555555555";


                var resultAdmin = userManager.CreateAsync(Admin, "Pass123--").Result;
                if (resultAdmin.Succeeded)
                {
                    userManager.AddToRoleAsync(Admin, "Admin").Wait();
                }


                var resultKasiyer = userManager.CreateAsync(Cashier, "Pass123--").Result;
                if (resultKasiyer.Succeeded)
                {
                    userManager.AddToRoleAsync(Cashier, "Cashier").Wait();
                }


                var resultAccounting = userManager.CreateAsync(Accounting, "Pass123--").Result;
                if (resultAccounting.Succeeded)
                {
                    userManager.AddToRoleAsync(Accounting, "Accounting").Wait();
                }


                var resultMobileSales = userManager.CreateAsync(MobileSales, "Pass123--").Result;
                if (resultMobileSales.Succeeded)
                {
                    userManager.AddToRoleAsync(MobileSales, "MobileSales").Wait();
                }


                var resultStockRoom = userManager.CreateAsync(StockRoom, "Pass123--").Result;
                if (resultStockRoom.Succeeded)
                {
                    userManager.AddToRoleAsync(StockRoom, "StockRoom").Wait();
                }


                var resultTechnicalService = userManager.CreateAsync(TechnicalService, "Pass123--").Result;
                if (resultTechnicalService.Succeeded)
                {
                    userManager.AddToRoleAsync(TechnicalService, "TechnicalService").Wait();
                }

            }
        }

        private static void SeedRoles(RoleManager<AppRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                AppRole role = new AppRole();
                role.Name = "Admin";
                var roleResult = roleManager.CreateAsync(role).Result;

            }

            if (!roleManager.RoleExistsAsync("Cashier").Result)
            {
                AppRole role = new AppRole();
                role.Name = "Cashier";
                var roleResult = roleManager.CreateAsync(role).Result;


            }
            if (!roleManager.RoleExistsAsync("Accounting").Result)
            {
                AppRole role = new AppRole();
                role.Name = "Accounting";
                var roleResult = roleManager.CreateAsync(role).Result;


            }
            if (!roleManager.RoleExistsAsync("MobileSales").Result)
            {
                AppRole role = new AppRole();
                role.Name = "MobileSales";
                var roleResult = roleManager.CreateAsync(role).Result;


            }
            if (!roleManager.RoleExistsAsync("StockRoom").Result)
            {
                AppRole role = new AppRole();
                role.Name = "StockRoom";
                var roleResult = roleManager.CreateAsync(role).Result;

            }
            if (!roleManager.RoleExistsAsync("TechnicalService").Result)
            {
                AppRole role = new AppRole();
                role.Name = "TechnicalService";
                var roleResult = roleManager.CreateAsync(role).Result;

            }
        }

        private static void SeedUse(Context context)
        {
            if (context.Categories.Count() == 0)
            {
                Category category = new Category();
                category.CategoryName = "Telefon";
                category.Description = "Telefonlar bu kategoride listelenecek.";
                category.Id = new Guid();
                context.Categories.Add(category);

                Category category1 = new Category();
                category1.CategoryName = "Beyaz Eşya";
                category1.Description = "Beyaz eşyalar bu kategoride listelenecek.";
                category1.Id = new Guid();
                context.Categories.Add(category1);

                Category category2 = new Category();
                category2.CategoryName = "Televizyon";
                category2.Description = "Televizyonlar bu kategoride listelenecek.";
                category2.Id = new Guid();
                context.Categories.Add(category2);



                SubCategory subCategory = new SubCategory();
                subCategory.Id = new Guid();
                subCategory.SubCategoryName = "Android Telefon";
                subCategory.Description = "Android işletim sistemine sahip telefonlar bu alt kategoride listelenecek.";
                subCategory.CategoryId = category.Id;
                context.SubCategories.Add(subCategory);

                SubCategory subCategory1 = new SubCategory();
                subCategory1.Id = new Guid();
                subCategory1.SubCategoryName = "Ios Telefon";
                subCategory1.Description = "Ios işletim sistemine sahip telefonlar bu alt kategoride listelenecek.";
                subCategory1.CategoryId = category.Id;
                context.SubCategories.Add(subCategory1);

                SubCategory subCategory2 = new SubCategory();
                subCategory2.Id = new Guid();
                subCategory2.SubCategoryName = "Buzdolabı";
                subCategory2.Description = "Buzdolapları bu alt kategoride listelenecek.";
                subCategory2.CategoryId = category1.Id;
                context.SubCategories.Add(subCategory2);

                SubCategory subCategory3 = new SubCategory();
                subCategory3.Id = new Guid();
                subCategory3.SubCategoryName = "Smart Tv";
                subCategory3.Description = "Smart Tv özelliğine sahip televizyonlar bu alt kategoride listelenecek.";
                subCategory3.CategoryId = category2.Id;
                context.SubCategories.Add(subCategory3);


                Customer customer = new Customer();
                customer.Id = new Guid();
                customer.CustomerName = "Müşteri 1";
                customer.Gender = EntityLayer.Enum.Gender.Male;
                customer.EmailAddress = "Musteri1@mail.com";
                customer.Phone = "05555555555";
                customer.Address = "İstanbul";
                customer.BirthDate = DateTime.Now;
                customer.TC = "11111111111";
                context.Customers.Add(customer);

                Customer customer1 = new Customer();
                customer1.Id = new Guid();
                customer1.CustomerName = "Müşteri 2";
                customer1.Gender = EntityLayer.Enum.Gender.Female;
                customer1.EmailAddress = "Musteri2@mail.com";
                customer1.Phone = "05444444444";
                customer1.Address = "Ankara";
                customer1.BirthDate = DateTime.Now;
                customer1.TC = "22222222222";
                context.Customers.Add(customer1);

                Customer customer2 = new Customer();
                customer2.Id = new Guid();
                customer2.CustomerName = "Müşteri 3";
                customer2.Gender = EntityLayer.Enum.Gender.Male;
                customer2.EmailAddress = "Musteri3@mail.com";
                customer2.Phone = "05333333333";
                customer2.Address = "İzmir";
                customer2.BirthDate = DateTime.Now;
                customer2.TC = "33333333333";
                context.Customers.Add(customer2);

                Supplier supplier = new Supplier();
                supplier.Id = new Guid();
                supplier.PhoneNumber = "05333333333";
                supplier.CompanyName = "Apple";
                supplier.ContactName = "Apple Supplier";
                supplier.Email = "Supplier@apple.com";
                supplier.Address = "Test";
                context.Suppliers.Add(supplier);

                Supplier supplier1 = new Supplier();
                supplier1.Id = new Guid();
                supplier1.PhoneNumber = "05322222222";
                supplier1.CompanyName = "Bosch";
                supplier1.ContactName = "Bosch Supplier";
                supplier1.Email = "Supplier@bosch.com";
                supplier1.Address = "Test";
                context.Suppliers.Add(supplier1);

                Supplier supplier2 = new Supplier();
                supplier2.Id = new Guid();
                supplier2.PhoneNumber = "05466666666";
                supplier2.CompanyName = "Samsung";
                supplier2.ContactName = "Samsung Supplier";
                supplier2.Email = "Supplier@samsung.com";
                supplier2.Address = "Test";
                context.Suppliers.Add(supplier2);

                Supplier supplier3 = new Supplier();
                supplier3.Id = new Guid();
                supplier3.PhoneNumber = "05422222222";
                supplier3.CompanyName = "Arçelik";
                supplier3.ContactName = "Arçelik Supplier";
                supplier3.Email = "Supplier@arcelik.com";
                supplier3.Address = "Test";
                context.Suppliers.Add(supplier3);


                Product product = new Product();
                product.BarcodeNumber = "0000000000001";
                product.Id = new Guid();
                product.SubCategoryId = subCategory1.Id;
                product.ProductName = "Iphone 14";
                product.SupplierId = supplier.Id;
                product.UnitPrice = 30000;
                product.UnıtsInStock = 100;
                product.ImageName = "a64ea584-6c0a-449d-b910-5f846d1bd6f1.png";
                context.Products.Add(product);

                Product product1 = new Product();
                product1.BarcodeNumber = "0000000000002";
                product1.Id = new Guid();
                product1.SubCategoryId = subCategory1.Id;
                product1.ProductName = "Iphone 13";
                product1.SupplierId = supplier.Id;
                product1.UnitPrice = 25000;
                product1.UnıtsInStock = 100;
                product1.ImageName = "ae326f15-68a2-4d53-845a-80cc73d87696.png";

                context.Products.Add(product1);

                Product product2 = new Product();
                product2.BarcodeNumber = "0000000000003";
                product2.Id = new Guid();
                product2.SubCategoryId = subCategory1.Id;
                product2.ProductName = "Iphone 12";
                product2.SupplierId = supplier.Id;
                product2.UnitPrice = 20000;
                product2.UnıtsInStock = 100;
                product2.ImageName = "23210382-230c-4612-a493-675f4ccc6fc8.png";

                context.Products.Add(product2);

                Product product3 = new Product();
                product3.BarcodeNumber = "0000000000004";
                product3.Id = new Guid();
                product3.SubCategoryId = subCategory2.Id;
                product3.ProductName = "Bosch Tek Kapılı Buzdolabı";
                product3.SupplierId = supplier1.Id;
                product3.UnitPrice = 25000;
                product3.UnıtsInStock = 100;
                product3.ImageName = "4341346c-24c9-4033-8121-eb8ee4acf77a.png";

                context.Products.Add(product3);

                Product product4 = new Product();
                product4.BarcodeNumber = "0000000000005";
                product4.Id = new Guid();
                product4.SubCategoryId = subCategory2.Id;
                product4.ProductName = "Bosch Çift Kapılı Buzdolabı";
                product4.SupplierId = supplier1.Id;
                product4.UnitPrice = 30000;
                product4.UnıtsInStock = 100;
                product4.ImageName = "63e15127-7fc5-4784-a2ee-318b2b0595fe.png";

                context.Products.Add(product4);

                Product product5 = new Product();
                product5.BarcodeNumber = "0000000000006";
                product5.Id = new Guid();
                product5.SubCategoryId = subCategory2.Id;
                product5.ProductName = "Arçelik Buzdolabı";
                product5.SupplierId = supplier3.Id;
                product5.UnitPrice = 20000;
                product5.UnıtsInStock = 100;
                product5.ImageName = "816f556e-504a-4e5f-8871-199c3b6733f0.png";

                context.Products.Add(product5);

                Product product6 = new Product();
                product6.BarcodeNumber = "0000000000007";
                product6.Id = new Guid();
                product6.SubCategoryId = subCategory.Id;
                product6.ProductName = "Samsung S23 Ultra ";
                product6.SupplierId = supplier2.Id;
                product6.UnitPrice = 40000;
                product6.UnıtsInStock = 100;
                product6.ImageName = "44104401-39f5-4d00-8e08-445a3656e4f5.png";

                context.Products.Add(product6);

                Product product7 = new Product();
                product7.BarcodeNumber = "0000000000008";
                product7.Id = new Guid();
                product7.SubCategoryId = subCategory2.Id;
                product7.ProductName = "Samsung 50Q60B Smart Tv";
                product7.SupplierId = supplier3.Id;
                product7.UnitPrice = 15000;
                product7.UnıtsInStock = 100;
                product7.ImageName = "ee6e724d-08bb-4e34-aea0-e5de128b76be.png";

                context.Products.Add(product7);


                SupplierExpense expense = new SupplierExpense();
                expense.Id = new Guid();
                expense.ProductId = product.Id;
                expense.Price = 100000;
                expense.Quantity = 100;                
                context.SupplierExpenses.Add(expense);

                SupplierExpense expense1 = new SupplierExpense();
                expense1.Id = new Guid();
                expense1.ProductId = product1.Id;
                expense1.Price = 100000;
                expense1.Quantity = 100;
                context.SupplierExpenses.Add(expense1);

                SupplierExpense expense2 = new SupplierExpense();
                expense2.Id = new Guid();
                expense2.ProductId = product2.Id;
                expense2.Price = 100000;
                expense2.Quantity = 100;
                context.SupplierExpenses.Add(expense2);

                SupplierExpense expense3 = new SupplierExpense();
                expense3.Id = new Guid();
                expense3.ProductId = product3.Id;
                expense3.Price = 100000;
                expense3.Quantity = 100;
                context.SupplierExpenses.Add(expense3);

                SupplierExpense expense4 = new SupplierExpense();
                expense4.Id = new Guid();
                expense4.ProductId = product4.Id;
                expense4.Price = 100000;
                expense4.Quantity = 100;
                context.SupplierExpenses.Add(expense4);

                SupplierExpense expense5 = new SupplierExpense();
                expense5.Id = new Guid();
                expense5.ProductId = product5.Id;
                expense5.Price = 100000;
                expense5.Quantity = 100;
                context.SupplierExpenses.Add(expense5);

                SupplierExpense expense6 = new SupplierExpense();
                expense6.Id = new Guid();
                expense6.ProductId = product6.Id;
                expense6.Price = 100000;
                expense6.Quantity = 100;
                context.SupplierExpenses.Add(expense6);

                SupplierExpense expense7 = new SupplierExpense();
                expense7.Id = new Guid();
                expense7.ProductId = product7.Id;
                expense7.Price = 100000;
                expense7.Quantity = 100;
                context.SupplierExpenses.Add(expense7);



                context.SaveChanges();
            }
        }
    }
}
