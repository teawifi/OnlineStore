# OnlineStore
***
### I have used the following technologies:
##### ASP.NET MVC 5;
##### ASP.NET Identity
##### HTML 5;
##### JavaScript/jQuery;
##### Entity Framework 6;
##### MS SQL Server 2014;
##### Microsoft Visual Studio Community 2015
***
###### To run the project you have to EXECUTE next commands: 
###### 1) in Package Manager Console - "enable-migrations";
###### 2) to modify the Seed() method of the Configuration.cs class in the Migrations directory to the next code:

```C#
            using (var dbContext = ApplicationDbContext.Create())
            {
                IEnumerable<Product> productsIntermediateList = dbContext.Products
                    .Where(prod => (prod.CategoryID == 3) || (prod.CategoryID == 1));

                /* 
                 * There are 25 items in the dbo.Products table, where CateoryID equals 3 or 1. 
                 * The restrict (25 items * 50 times = 1250) is set to avoid the repeated duplication of entries in the table
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
                // According to the task condition, records duplicate 50 times
                for (int i = 0; i < 50; i++)
                {
                    dbContext.Products.AddRange(productList);
                    dbContext.SaveChanges();
                }
            }
        
```

###### 3) To add namespaces to the Configuration.cs class:

```C#
			using Models;
			using System.Collections.Generic;
```

###### 4) in Package Manager Console - "add-migration 'SomeName'"
###### 	(DELETE the creating "dbo.Categories" and "dbo.Products" tables from the Up() method of 'SomeName' migration class)
###### 5) "update-database".
***
# Examples of the application
#
#### Homepage of the app
![Homepage of the app](https://github.com/teawifi/OnlineStore/blob/master/SecondaryImages/StartPage.JPG)
***
#### The example of good description
![The example of good description](https://github.com/teawifi/OnlineStore/blob/master/SecondaryImages/GoodDescription.JPG)
***
#### The example of cart of user who not logged in
![The example of cart of user who not logged in](https://github.com/teawifi/OnlineStore/blob/master/SecondaryImages/CartOfNotLoggedInUser.JPG)
***
#### Log in
![Log in](https://github.com/teawifi/OnlineStore/blob/master/SecondaryImages/LogIn.JPG)
***
#### The example of cart of user who logged in
![The example of cart of user who logged in](https://github.com/teawifi/OnlineStore/blob/master/SecondaryImages/CartOfLoggedInUser.JPG)
***
#### Finish line
![Finish line](https://github.com/teawifi/OnlineStore/blob/master/SecondaryImages/Finish_Line.JPG)
