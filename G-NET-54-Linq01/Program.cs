

using G_NET_54_Linq01;
using LINQ.DataSources;
using System.Diagnostics.Metrics;





#region Question1
// 1. Get all products from the "Seafood" category. Print each product's name and price.

var seafoodProducts = Source.ProductList
    .Where(p => string.Equals(
        p.Category,
        "Seafood",
        StringComparison.OrdinalIgnoreCase))
    .Select(p => new { 
        p.ProductName,
        p.UnitPrice
    }).ToList();

foreach (var product in seafoodProducts)
{
    Console.WriteLine($"{product.ProductName} {product.UnitPrice}");
}


#endregion



#region Question2
//Get a list of only the product names from ProductList. Print each name.

var productNames = Source.ProductList
    .Select(p => p.ProductName)
    .ToList();

foreach( var product in productNames)
{
    Console.WriteLine($"{product}");
}

#endregion


#region Question3
//Sort all products by UnitPrice (ascending). Print each product's name and price.

var productByPrice = Source.ProductList
    .OrderBy(p => p.UnitPrice)
    .Select(p =>
    new
    {
        p.ProductName,
        p.UnitPrice
    })
    .ToList();
foreach (var product in productByPrice)
{
    Console.WriteLine($"{product.ProductName}  {product.UnitPrice}");
}

#endregion


#region Question4
//Get all products where UnitPrice is between 10 and 30
var productBetweenPrice = Source.ProductList
    .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30)
    .ToList();

foreach(var product in productBetweenPrice)
{
    Console.WriteLine($"{product.ProductName} {product.UnitPrice}");
}
#endregion

#region Question5
//Get all products that are in stock (UnitsInStock > 0) and belong to the "Condiments" category.

var productCondiment = Source.ProductList
    .Where(p => p.UnitsInStock > 0 && string.Equals(
        p.Category,
        "Condiments",
        StringComparison.OrdinalIgnoreCase))
    .ToList();
foreach(var product in productCondiment)
{
    Console.WriteLine($"{product.ProductName} {product.UnitsInStock} {product.Category}");
}
#endregion


#region Question6
/*
 
Create a new anonymous type with three properties:
● Name → the product name
● Price → the unit price
● StockStatus → a string: "Available" if UnitsInStock > 0,
otherwise "Out of Stock"
● Print the result.
 */

var productAnon = Source.ProductList
    .Select(p => new
    {
        name = p.ProductName,
        price = p.UnitPrice,
        stockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"

    })
    .ToList();

foreach(var product in productAnon)
{
    Console.WriteLine($"Name:{product.name} Price:{product.price} StockStatus:{product.stockStatus}");
}
#endregion


#region Question7
//Print each product's name along with its position (1-based) in the list. Expected format: 1.Chai, 2.Chang, etc.
var productPositions = Source.ProductList
    .Select((p, i) =>new
    {
        index = i +1,
        Name = p.ProductName

    })
    .ToList ();
foreach (var product in productPositions)
{
    Console.WriteLine($"{product.index} {product.Name}");
}


#endregion


#region Question8
//Sort ProductList by Category ascending, then within each category, sort by UnitPrice descending.

var sortedProducts = Source.ProductList
    .OrderBy(p=> p.Category)
    .ThenByDescending(p=> p.UnitPrice)
    .ToList();
foreach (var product in sortedProducts)
{
    Console.WriteLine($"{product.ProductName} {product.Category} {product.UnitPrice}");
}


#endregion



#region Question9
//Get all products from the "Beverages" category, sorted by UnitsInStock descending. Print name and stock.

var beverageProducts = Source.ProductList
    .Where(p => string.Equals(
        p.Category,
        "Beverages",
        StringComparison.OrdinalIgnoreCase
        ))
    .OrderByDescending(p => p.UnitsInStock)
    .Select(p => new
    {
        p.ProductName,
        p.UnitsInStock
    })
    .ToList();
foreach (var product in beverageProducts)
{
    Console.WriteLine($"{product.ProductName} {product.UnitsInStock}"); 
}

#endregion


#region Question10 
//Using QUERY SYNTAX with a compound from clause, list all orders placed in 1997 or later showing CustomerID and OrderDate.

var orders =

    from customer in Source.CustomerList
    from order in customer.Orders
    where order.OrderDate >= new DateTime(1997, 1, 1)
    select new
    {
        customer.CustomerID,
        order.OrderDate
    };
foreach (var order in orders)
{
    Console.WriteLine($"{order.CustomerID}  {order.OrderDate}");
}

#endregion

#region Question11
//Show position number alongside ProductName

var productNamePosition = Source.ProductList
    .Select((p,index) => new
    {
     index,
     p.ProductName
    })
    .ToList ();
foreach (var product in productNamePosition)
{
    Console.WriteLine($"{product.index} {product.ProductName}");
}

#endregion


#region Question12
//Sort first by-word length and then by a case -insensitive sort of the words in an array.

String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

var sortedWords = Arr.OrderBy(word=>word.Length)
    .ThenBy(word => word,StringComparer.OrdinalIgnoreCase)
    .ToList();

#endregion


#region Question13
//Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
var sortedArray = Source.ProductList
    .Where(p=>p.ProductName.Length >1 && char.ToLower(p.ProductName[1]) == 'i' )
    .Reverse()
  .ToList ();
foreach (var product in sortedArray)
{
    Console.WriteLine($"{product.ProductName}");
}
#endregion