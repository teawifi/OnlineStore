namespace OnlineStore.Migrations
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            using (var dbContext = ApplicationDbContext.Create())
            {
                IEnumerable<Product> productsIntermediateList = dbContext.Products
                    .Where(prod => (prod.CategoryID == 3) || (prod.CategoryID == 1));

                /* 
                 * There are 25 items in the dbo.Products table, where CateoryID equals 3 or 1. 
                 * The restrict (25*50 = 1250) is set to avoid the repeated duplication of entries in the table
                 */

                if (productsIntermediateList.Count() > 1250)
                {
                    return;
                }

                var productList = new List<Product>();

                foreach (var item in productsIntermediateList)
                {
                    productList.Add(new Product
                    {
                        ProductName = item.ProductName,
                        SupplierID = item.SupplierID,
                        CategoryID = item.CategoryID,
                        QuantityPerUnit = item.QuantityPerUnit,
                        UnitPrice = item.UnitPrice,
                        UnitsInStock = item.UnitsInStock,
                        UnitsOnOrder = item.UnitsOnOrder,
                        ReorderLevel = item.ReorderLevel,
                        Discontinued = item.Discontinued
                    });
                }

                for (int i = 0; i < 50; i++)
                {
                    dbContext.Products.AddRange(productList);
                    dbContext.SaveChanges();
                }                              
            }
        }
    }
}
