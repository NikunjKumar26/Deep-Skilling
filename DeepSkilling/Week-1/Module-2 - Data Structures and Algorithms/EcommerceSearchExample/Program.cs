using EcommerceSearchExample;

Product[] products =
{
    new Product(101, "Laptop", "Electronics"),
    new Product(102, "Mobile", "Electronics"),
    new Product(103, "Shoes", "Fashion"),
    new Product(104, "Watch", "Accessories"),
    new Product(105, "Book", "Education")
};

Console.WriteLine("Linear Search:");

var linearResult = SearchOperations.LinearSearch(products, 104);

if (linearResult != null)
{
    Console.WriteLine($"Found: {linearResult.ProductName}");
}

Console.WriteLine();

Console.WriteLine("Binary Search:");

var binaryResult = SearchOperations.BinarySearch(products, 104);

if (binaryResult != null)
{
    Console.WriteLine($"Found: {binaryResult.ProductName}");
}